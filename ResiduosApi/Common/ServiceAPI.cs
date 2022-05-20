using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ResiduosApi.Common.Interface;
using ResiduosApi.DTO;
//using Newtonsoft.Json;
using System.Text.Json;

namespace ResiduosApi.Common
{
    public class ServiceAPI : IServiceAPI
    {

        private JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public async Task<List<DataInput>> ObtenerResiduos()
        {

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("https://www.datos.gov.co/resource/m2y3-brbe.json");
                var contentResult = result.Content.ReadAsStringAsync();
                //var a = JsonConvert.DeserializeObject<DataInput>(await contentResult,);
                var jsonResult = JsonSerializer.Deserialize<List<DataInput>>(contentResult.Result,options);


                //return CrearDataInput(JsonConvert.DeserializeObject());
                return jsonResult;

            }

        }

        public async Task<List<DataInput>> ObtenerResiduosXCiudad(string ciudad)
        {
            using (var client = new HttpClient())
            {

                var result = await client.GetAsync("https://www.datos.gov.co/resource/m2y3-brbe.json?ciudad=" + ciudad);
                var contentResult = result.Content.ReadAsStringAsync();
                var jsonResult = JsonSerializer.Deserialize<List<DataInput>>(contentResult.Result, options);
                return jsonResult;

            }

        }

        //private List<DataInput> CrearDataInput()
        //{
        //    return null;
        //}

    }
}
