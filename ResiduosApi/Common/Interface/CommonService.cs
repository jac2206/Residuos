using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ResiduosApi.Common.Interface
{
    public class CommonService : ICommonService
    {

        private JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public Task<Object> EventoPartner(Object partner)
        {
            return null;
        }

        public async Task<List<object>> ObtenerPartner()
        {
            using (var client = new HttpClient())
            {
                //var result = await client.GetAsync("https://www.datos.gov.co/resource/m2y3-brbe.json");
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-api-key", "DxJmxeZkZ73HXxOE2RxzA1LbTFgoD0bW49ZDU92P");
                //client.DefaultRequestHeaders.Add("x-api-key", "DxJmxeZkZ73HXxOE2RxzA1LbTFgoD0bW49ZDU92P");
                var result = await client.GetAsync("https://ws-puntos-uat.clm-comarch.com/acc-api/accounts/partners?page=1&limit=100");
                var contentResult = result.Content.ReadAsStringAsync();
                if(result.StatusCode == System.Net.HttpStatusCode.OK || result.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    //var jsonResult = JsonSerializer.Deserialize<List<Object>>(contentResult.Result, options);
                    return JsonSerializer.Deserialize<List<Object>>(contentResult.Result, options); ;
                }
                //var a = JsonConvert.DeserializeObject<DataInput>(await contentResult,);           
                //var jsonResult = JsonSerializer.Deserialize<List<Object>>(contentResult.Result, options);


                //return CrearDataInput(JsonConvert.DeserializeObject());
                return null;

            }
        }
    }
}
