namespace UniversityIot.VitoControlApi.Http.Binders
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;
    using System.Web.Http.Controllers;
    using System.Web.Http.ModelBinding;
    using UniversityIot.VitoControlApi.Http.Attributes;
    using UniversityIot.VitoControlApi.Models;

    /// <summary>
    /// CustomModel binder
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public class CustomModelBinder<TRequest, TResponse> : IModelBinder where TRequest : AsyncRequestBase<TResponse>, new()
    {
        /// <summary>
        /// Binds the model to a value by using the specified controller context and binding context.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <param name="bindingContext">The binding context.</param>
        /// <returns>
        /// True if model binding is successful; otherwise, false.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// ActionContext
        /// or
        /// bindingContext
        /// </exception>
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException(nameof(actionContext));
            }

            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var model = new TRequest();

            var routeDataValues = actionContext
                .RequestContext
                .RouteData
                .Values
                .ToDictionary(x => x.Key.ToUpper(CultureInfo.InvariantCulture), x => x.Value?.ToString() ?? string.Empty);

            BindRouteData(model, routeDataValues);
            BindQueryNameValuePairs(model, routeDataValues, actionContext);

            bindingContext.Model = model;
            return true;
        }

        /// <summary>
        /// Binds the route data.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="routeDataValues">The route data values.</param>
        private static void BindRouteData(TRequest model, Dictionary<string, string> routeDataValues)
        {
            if (!routeDataValues.Any())
            {
                return;
            }

            var properties = model.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(x => x.Name.ToUpper(CultureInfo.InvariantCulture), x => x);

            FillModelProperties(model, routeDataValues, properties);
        }

        /// <summary>
        /// Binds the query name value pairs.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="routeDataValues">The route data values.</param>
        /// <param name="actionContext">The action context.</param>
        private static void BindQueryNameValuePairs(TRequest model, Dictionary<string, string> routeDataValues, HttpActionContext actionContext)
        {
            var queryParameters = actionContext
                .Request
                .GetQueryNameValuePairs()
                .GroupBy(x => x.Key)
                .ToDictionary(x => x.Key.ToUpper(CultureInfo.InvariantCulture), x => x.Select(y => y.Value).FirstOrDefault());

            if (!queryParameters.Any())
            {
                return;
            }

            var decalredProperties = model.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => !p.DeclaringType.IsDefined(typeof(IgnoreQueryBindingAttribute), false) && !p.IsDefined(typeof(IgnoreQueryBindingAttribute), false))
                .ToDictionary(x => x.Name.ToUpper(CultureInfo.InvariantCulture), x => x);

            FillModelProperties(model, queryParameters.Where(i => !routeDataValues.ContainsKey(i.Key.ToUpper(CultureInfo.InvariantCulture))), decalredProperties);
        }

        /// <summary>
        /// Fills the model properties.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="values">The values.</param>
        /// <param name="properties">The properties.</param>
        private static void FillModelProperties(TRequest model, IEnumerable<KeyValuePair<string, string>> values, Dictionary<string, PropertyInfo> properties)
        {
            foreach (var keyValuePair in values)
            {
                PropertyInfo prop;
                if (properties.TryGetValue(keyValuePair.Key, out prop))
                {
                    try
                    {
                        object value = Convert.ChangeType(keyValuePair.Value, prop.PropertyType, CultureInfo.InvariantCulture);
                        prop.SetValue(model, value);
                    }
                    catch (FormatException)
                    {
                    }
                }
            }
        }
    }
}