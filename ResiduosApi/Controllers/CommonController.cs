using Amazon;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResiduosApi.Common.Interface;
using ResiduosApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ResiduosApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {

        private readonly ICommonService _commonService;


        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [HttpGet("partner")]
        public async Task<IActionResult> ObtenerResiduos()
        {
            try
            {
                var result = await _commonService.ObtenerPartner();

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(
                        new DataError
                        {
                            Error = "Error mensaje",
                            Valor = "3",
                            FechaHora = DateTime.Now
                        }
                        );
                }
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }

        [HttpPost("partnerHook")]
        public async Task<IActionResult> EventoHook([FromBody] Object evento)
        {
            try
            {
                var result =evento;
                var credentials = new BasicAWSCredentials("AKIA3RTZWEJ35GLJ7H4H", "NTIYdjfPsRz0fIbKDxLfkv2oNEJWRfr6N/kyHeYF");
                var client = new Amazon.DynamoDBv2.AmazonDynamoDBClient(credentials, RegionEndpoint.USEast2);
                string nombreTabla = "Hook";

                Amazon.DynamoDBv2.DocumentModel.Table table = Amazon.DynamoDBv2.DocumentModel.Table.LoadTable(client, nombreTabla);
                Document dato = new Document();
                dato["Id"] = Guid.NewGuid().ToString();
                dato["Event"] = JsonSerializer.Serialize(evento);
                await table.PutItemAsync(dato);
                //var result = await _commonService.EventoPartner(evento);
                //var result = evento;
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(
                        new DataError
                        {
                            Error = "Error mensaje",
                            Valor = "3",
                            FechaHora = DateTime.Now
                        }
                        );
                }
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);
                //return (ex.ToString());

            }
        }

    }
}
