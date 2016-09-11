namespace UniversityIot.KolibriService.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Configuration;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using UniversityIot.Messages;
    using Viessmann.Estrella.Components.KolibriApi;
    using Viessmann.Estrella.Components.KolibriApi.Exceptions;
    using Viessmann.Estrella.Components.KolibriApi.Interfaces;

    /// <summary>
    /// Kolibri controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("kolibri")]
    public class KolibriController : ApiController
    {
        /// <summary>
        /// The kolibri client
        /// </summary>
        private readonly IKolibriClient kolibriClient;

        public KolibriController(IKolibriClient kolibriClient)
        {
            this.kolibriClient = kolibriClient;
        }

        /// <summary>
        /// Posts the specified kolibri value.
        /// </summary>
        /// <param name="kolibriValue">The kolibri value.</param>
        /// <returns></returns>
        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody] KolibriValue kolibriValue)
        {
            if (kolibriValue == null)
            {
                return BadRequest();
            }

            var kolibriRequest = new WriteRpcRequest()
            {
                Params = new WriteRpcRequestParam()
                {
                    Nodes = new Collection<WriteRpcRequestNodeParam>(new List<WriteRpcRequestNodeParam>()
                    {
                        new WriteRpcRequestNodeParam()
                        {
                            Value = Convert.ToInt32(kolibriValue.Value),
                            Path = this.GetPath(kolibriValue.HexAddress)
                        }
                    })
                }
            };

            try
            {
                await this.kolibriClient.RequestAsync<WriteRpcResponse>(kolibriRequest);
                return Ok();
            }
            catch (KolibriApiException ex)
            {
                return BadRequest(ex.KolibriErrorMessage);
            }
        }

        /// <summary>
        /// Gets the specified addresses.
        /// </summary>
        /// <param name="addresses">The addresses.</param>
        /// <returns></returns>
        [Route("")]
        public async Task<IHttpActionResult> Get([FromUri] string[] addresses)
        {
            if (addresses == null)
            {
                return BadRequest();
            }

            var kolibriRequest = new ReadRpcRequest()
            {
                Params = new Collection<ReadRpcRequestParam>(addresses.Select(x => new ReadRpcRequestParam()
                {
                    Path = this.GetPath(x)
                }).ToList())
            };

            var response = await this.kolibriClient.RequestAsync<ReadRpcResponse>(kolibriRequest);

            var kolibriValues = response.Result.Select(x => new KolibriValue { Value = x.Value?.ToString(), HexAddress = x.Path.Substring(x.Path.LastIndexOf('/') + 1) });

            return Ok(kolibriValues);
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <param name="hexAddress">The hexadecimal address.</param>
        /// <returns>Path</returns>
        /// <exception cref="System.Exception">device type not found</exception>
        private string GetPath(string hexAddress)
        {
            var deviceSerial = ConfigurationManager.AppSettings["KolibriConfig:DeviceSerial"];
            var deviceType = ConfigurationManager.AppSettings["KolibriConfig:DeviceType"];

            if (deviceType.Equals("lancard", StringComparison.InvariantCultureIgnoreCase))
            {
                return $"/lancard-{deviceSerial}/data/i2c/0/vs/{hexAddress}";

            }

            if (deviceType.Equals("vitoconnect", StringComparison.InvariantCultureIgnoreCase))
            {
                return $"/vitoconnect-{deviceSerial}/data/ol/0/vs/{hexAddress}";

            }

            throw new Exception("device type not found");
        }
    }
}