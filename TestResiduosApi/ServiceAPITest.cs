using NUnit.Framework;
using ResiduosApi.Common;
using ResiduosApi.Common.Interface;
using ResiduosApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace TestResiduosApi
{
    class ServiceAPITest
    {



        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ObtenerResiduosTestNull()
        {

            ServiceAPI service = new ServiceAPI();
            var result = await service.ObtenerResiduos();
            if (result != null)
            {
                Assert.IsNotNull(result);

            }
            else
            {
                Assert.IsNull(result);

            }
        }
    }
}
