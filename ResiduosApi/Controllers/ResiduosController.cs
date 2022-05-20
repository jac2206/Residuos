using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResiduosApi.Common;
using Microsoft.AspNetCore.Cors;
using ResiduosApi.Common.Interface;
using ResiduosApi.DTO;
using System.ComponentModel.DataAnnotations;

namespace ResiduosApi.Controllers
{

    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ResiduosController : ControllerBase
    {

        private readonly IServiceAPI _serviceAPI;


        public ResiduosController(IServiceAPI servicioAPI)
        {
            _serviceAPI = servicioAPI;
        }

        //[EnableCors("MyPolicy")]
        //[Route("~/ObtenerValorTotalProductoInventario")]
        [HttpGet("ObtenerResiduos")]
        public async Task<IActionResult> ObtenerResiduos()
        {
            try
            {
                //var servicioApi = new ServiceAPI();
                //var result = await servicioApi.ObtenerResiduos();

                var result = await _serviceAPI.ObtenerResiduos();

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
                        ) ;
                }
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);
                //return (ex.ToString());

            }
        }

        [HttpGet("ObtenerResiduosXCiudad/{ciudad}")]
        public async Task<IActionResult> ObtenerResiduosXCiudad(string ciudad)
        {
            try
            {

                var result = await _serviceAPI.ObtenerResiduosXCiudad(ciudad);

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

        [HttpGet("ObtenerResiduosXCiudad")]
        public async Task<IActionResult> ObtenerResiduosXCiudadQueryParam([Required] string ciudad, int valor)
        {
            try
            {

                var result = await _serviceAPI.ObtenerResiduosXCiudad(ciudad);

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
