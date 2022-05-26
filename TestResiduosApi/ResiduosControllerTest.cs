using NUnit.Framework;
using ResiduosApi.Common.Interface;
using ResiduosApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResiduosApi.Controllers;
using Moq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;


namespace TestResiduosApi
{
    class ResiduosControllerTest
    {

        //private readonly IServiceAPI _serviceAPI;


        //public ResiduosControllerTest(IServiceAPI servicioAPI)
        //{
        //    _serviceAPI = servicioAPI;
        //}


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ObtenerResiduosTest()
        {


            List<DataInput> dataInputDTO = new List<DataInput>()
            {
                new DataInput{
                    Nombre_punto_de_recolecci = "PALACIO DE GOBIERNO  SEDE PRINCIPAL(CUPULA CHATA)",
                    Direcci_n_punto_de_recolecci = "Av. 5A #13-82, Cúcuta, Norte de Santander",
                    Ciudad = "Cúcuta",
                    Departamento = "Norte de Santander",
                    Pa_s = "Colombia",
                    Categoria_residuo = "Pilas",
                    Tipo_residuo = "De todo tipo",
                    Ubicacion = "(4.570868, -74.297333)",
                    Horario = "LUN,MAR,MIE,JUE,VIE 08:00:00 a 14:00:00",
                    Nombre_programa_posconsumo = "Corporacion pilas con el ambiente",
                    Persona_contacto = "WWW.PILASCOLOMBIA.COM",
                    Correo_electr_nico = "direccion@pilascolombia.com"
                },
                new DataInput{
                    Nombre_punto_de_recolecci = "COMFAMILIARES SEDE PRINCIPAL",
                    Direcci_n_punto_de_recolecci = "Cra. 24 #50-14, Manizales, Caldas, Colombia",
                    Ciudad = "Manizales",
                    Departamento = "Caldas",
                    Pa_s = "Colombia",
                    Categoria_residuo = "Pilas",
                    Tipo_residuo = "De todo tipo",
                    Ubicacion = "(5.063356633697, -75.498621595701)",
                    Horario = "SAB,DOM 08:00:00 a 17:00:00",
                    Nombre_programa_posconsumo = "Corporacion pilas con el ambiente",
                    Persona_contacto = "WWW.PILASCOLOMBIA.COM",
                    Correo_electr_nico = "direccion@pilascolombia.com"
                },
            };

            Mock<IServiceAPI> servicioAPi = new Mock<IServiceAPI>();
            servicioAPi.Setup(a => a.ObtenerResiduos()).Returns(ObtenerDataInputAsincrono(dataInputDTO));
            ResiduosController controller = new ResiduosController(servicioAPi.Object);

            OkObjectResult result = (OkObjectResult)await controller.ObtenerResiduos();
            //OkObjectResult okObject = new OkObjectResult(result);
            Assert.AreEqual(200, result.StatusCode);

            //var result = await _serviceAPI.ObtenerResiduos();
            Assert.Pass();
        }
       
        private async Task<List<DataInput>> ObtenerDataInputAsincrono(List<DataInput> dataInputDTO)
        {
            return dataInputDTO;
        }

    }
}
