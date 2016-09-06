namespace UniversityIot.VitoControlApi.Http.Attributes
{
    using System;
    using System.Configuration;
    using System.Net;
    using System.Net.Http.Headers;
    using System.Security.Principal;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http.Filters;
    using System.Web.Http.Results;
    using RestSharp;
    using RestSharp.Authenticators;
    using UniversityIot.Messages;

    /// <summary>
    /// Basic Authentication Attribute
    /// </summary>
    /// <seealso cref="System.Attribute" />
    /// <seealso cref="System.Web.Http.Filters.IAuthenticationFilter" />
    public class BasicAuthenticationAttribute : Attribute, IAuthenticationFilter
    {

        /// <summary>
        /// Gets a value indicating whether more than one instance of the indicated attribute can be specified for a single program element.
        /// </summary>
        public bool AllowMultiple => true;

        /// <summary>
        /// Authenticates the request.
        /// </summary>
        /// <param name="context">The authentication context.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>
        /// A Task that will perform authentication.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Context</exception>
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }


            var req = context.Request;

            if (req.Headers.Authorization != null
                && req.Headers.Authorization.Scheme.Equals(BasicAuthenticationHeaderValue.Schema, StringComparison.OrdinalIgnoreCase))
            {
                var authParam = req.Headers.Authorization.Parameter;
                string username;
                string password;

                int userId;
                if (TryExtractCredentials(authParam, out username, out password))
                {
                    var isAuthorized = this.AuthorizeUser(username, password, out userId);
                    if (isAuthorized)
                    {
                        var identity = new GenericIdentity(username);
                        SetPrincipal(new IdPrincipal(identity, userId));
                        return;
                    }
                }
            }

            context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], context.Request);
        }

        /// <summary>
        /// Challenges the asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Awaitable task</returns>
        /// <exception cref="System.ArgumentNullException">context</exception>
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }

                string realm = context.Request.RequestUri.Host;
                var challenge = new BasicAuthenticationHeaderValue(realm);
                context.Result = new AddChallengeOnUnauthorizedResult(context.Request, challenge, context.Result);
                return Task.FromResult(0);
            }
        }

        /// <summary>
        /// Sets the principal.
        /// </summary>
        /// <param name="principal">The principal.</param>
        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        /// <summary>
        /// Tries the extract credentials.
        /// </summary>
        /// <param name="authParam">The authentication parameter.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>True if credentials have been extracted correctly, false otherwise</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "We do not care about the exception - only the result is important.")]
        private static bool TryExtractCredentials(string authParam, out string userName, out string password)
        {
            userName = string.Empty;
            password = string.Empty;
            if (!string.IsNullOrWhiteSpace(authParam))
            {
                string credentials = null;
                var encoding = Encoding.UTF8;
                try
                {
                    credentials = encoding.GetString(Convert.FromBase64String(authParam));
                }
                catch
                {
                    return false;
                }

                if (!string.IsNullOrWhiteSpace(credentials))
                {
                    int separatorIndex = credentials.IndexOf(':');
                    if (separatorIndex > -1)
                    {
                        userName = credentials.Substring(0, separatorIndex);
                        password = credentials.Substring(separatorIndex + 1);
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Verifies the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// True if authorized
        /// </returns>
        private bool AuthorizeUser(string user, string password, out int userId)
        {
            userId = 0;
            var restClient = new RestClient(ConfigurationManager.AppSettings["ServiceEndpoints:Users"])
            {
                Authenticator = new HttpBasicAuthenticator(ConfigurationManager.AppSettings["ServiceEndpoints:Username"], ConfigurationManager.AppSettings["ServiceEndpoints:Password"])
            };

            var userRequest = new RestRequest("users/verify", Method.POST);

            var verifyUserBody = new VerifyUser()
            {
                Username = user,
                Password = password
            };

            userRequest.RequestFormat = DataFormat.Json;
            userRequest.AddBody(verifyUserBody);

            var userResponse = restClient.Execute<Messages.User>(userRequest);

            if (userResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                return false;
            }

            userId = userResponse.Data.Id;
            return true;
        }
    }
}