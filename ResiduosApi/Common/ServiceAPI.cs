using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ResiduosApi.Common.Interface;
using ResiduosApi.DTO;
//using Newtonsoft.Json;
using System.Text.Json;
using System.Net.Http.Json;
using Amazon.Runtime;
using Amazon;
using Amazon.DynamoDBv2.DocumentModel;
using System.Net.Http.Headers;

namespace ResiduosApi.Common
{
    public class ServiceAPI : IServiceAPI
    {

        private JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public async Task<List<DataInput>> ObtenerResiduos()
        {

            using (var client = new HttpClient())
            {
                //var result = await client.GetAsync("https://www.datos.gov.co/resource/m2y3-brbe.json");
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-api-key", "DxJmxeZkZ73HXxOE2RxzA1LbTFgoD0bW49ZDU92P");
                client.DefaultRequestHeaders.Add("x-api-key", "DxJmxeZkZ73HXxOE2RxzA1LbTFgoD0bW49ZDU92P");
                var result = await client.GetAsync("https://mjwn207x3a.execute-api.us-east-1.amazonaws.com/dev/prueba");
                var contentResult = result.Content.ReadAsStringAsync();
                //var a = JsonConvert.DeserializeObject<DataInput>(await contentResult,);
                var jsonResult = JsonSerializer.Deserialize<List<DataInput>>(contentResult.Result, options);


                //return CrearDataInput(JsonConvert.DeserializeObject());
                return jsonResult;

            }

        }

        public async Task<object> ObtenerUsuariosPCO()
        {
            using (var client = new HttpClient())
            {
                //var result = await client.GetAsync("https://www.datos.gov.co/resource/m2y3-brbe.json");
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-api-key", "DxJmxeZkZ73HXxOE2RxzA1LbTFgoD0bW49ZDU92P");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer 8ac03ef6-64ee-4aba-952b-54b1d204af81");
                client.DefaultRequestHeaders.Add("token", "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6ImRlZmF1bHRfc3NsX2tleSJ9.ew0KCSJpc3MiIDoiaHR0cHM6Ly9hcGkucHVudG9zY29sb21iaWEuY29tOjg0NDMiLA0KCSJzdWIiOiAiaHR0cHM6Ly9hcGkucHVudG9zY29sb21iaWEuY29tOjg0NDN8ZmFicml6aW9AcXVpY2tjb21tLmNvfGZhYnJpemlvQHF1aWNrY29tbS5jbyIsDQoJImF1ZCI6WyJsNzExODEyNjUxM2ZkMTQ3OTlhMmNjNGM3ZDc3ZWFlZGE5Il0sDQoJIm5vbmNlIjoibm9uZSIsDQoJImV4cCI6IjE2NzQ4MzM3NTQiLA0KCSJpYXQiOiIxNjc0ODMzNzU0IiwNCgkiYXRfaGFzaCI6IiIsDQoJImNfaGFzaCI6ICJhZmQ2ZjBmZC04MjM0LTQ4M2YtYjZlNi1jN2Y2MTViMzRjMjIiLA0KCSJhenAiOiJsNzExODEyNjUxM2ZkMTQ3OTlhMmNjNGM3ZDc3ZWFlZGE5IiwNCgkiYWNyIjoiMCINCn0.f_xCdT7UlhtVdwGRzpNbmxuZYfdo6E7fi4IGszGddsqIsKSOK9LvQCEnDmwqV6SEJMxrIIPRgttIi2JITuLR0boLdLtLkb3obOdMCsJJ56_hTdZYxVFnSGQY8AkF5oQmCQMdHswVuGh2BVmJWTd1gqjxSQZTgS4qIpHEG0FBCvKtrTycGYALCZARpd-wMIdOK7oqj0_BnG0SGr76XRxzX-2gHxXzczdODYlSG_EhL_MEBhZxZhJyolrrwg4p0LqUoPloGD6la8hQqJs1zuvFyShUKodYb4ZmK6gyv63uDnCgUVGruXPyWry3Q_0q_9TTVEPkJVB7K2uyeTXNzHHMEw");
                var result = await client.GetAsync("https://api.puntoscolombia.com/pco-openid/connect/v1/userinfo");
                var contentResult = result.Content.ReadAsStringAsync();
                //var a = JsonConvert.DeserializeObject<DataInput>(await contentResult,);
                var jsonResult = JsonSerializer.Deserialize<Object>(contentResult.Result, options);


                //return CrearDataInput(JsonConvert.DeserializeObject());
                return jsonResult;

            }
        }

        //public async Task<Object> ObtenerUsurioPCO()
        //{

        //    using (var client = new HttpClient())
        //    {
        //        //var result = await client.GetAsync("https://www.datos.gov.co/resource/m2y3-brbe.json");
        //        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-api-key", "DxJmxeZkZ73HXxOE2RxzA1LbTFgoD0bW49ZDU92P");
        //        client.DefaultRequestHeaders.Add("Authorization", "Bearer 8ac03ef6-64ee-4aba-952b-54b1d204af81");
        //        client.DefaultRequestHeaders.Add("token", "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6ImRlZmF1bHRfc3NsX2tleSJ9.ew0KCSJpc3MiIDoiaHR0cHM6Ly9hcGkucHVudG9zY29sb21iaWEuY29tOjg0NDMiLA0KCSJzdWIiOiAiaHR0cHM6Ly9hcGkucHVudG9zY29sb21iaWEuY29tOjg0NDN8ZmFicml6aW9AcXVpY2tjb21tLmNvfGZhYnJpemlvQHF1aWNrY29tbS5jbyIsDQoJImF1ZCI6WyJsNzExODEyNjUxM2ZkMTQ3OTlhMmNjNGM3ZDc3ZWFlZGE5Il0sDQoJIm5vbmNlIjoibm9uZSIsDQoJImV4cCI6IjE2NzQ4MzM3NTQiLA0KCSJpYXQiOiIxNjc0ODMzNzU0IiwNCgkiYXRfaGFzaCI6IiIsDQoJImNfaGFzaCI6ICJhZmQ2ZjBmZC04MjM0LTQ4M2YtYjZlNi1jN2Y2MTViMzRjMjIiLA0KCSJhenAiOiJsNzExODEyNjUxM2ZkMTQ3OTlhMmNjNGM3ZDc3ZWFlZGE5IiwNCgkiYWNyIjoiMCINCn0.f_xCdT7UlhtVdwGRzpNbmxuZYfdo6E7fi4IGszGddsqIsKSOK9LvQCEnDmwqV6SEJMxrIIPRgttIi2JITuLR0boLdLtLkb3obOdMCsJJ56_hTdZYxVFnSGQY8AkF5oQmCQMdHswVuGh2BVmJWTd1gqjxSQZTgS4qIpHEG0FBCvKtrTycGYALCZARpd-wMIdOK7oqj0_BnG0SGr76XRxzX-2gHxXzczdODYlSG_EhL_MEBhZxZhJyolrrwg4p0LqUoPloGD6la8hQqJs1zuvFyShUKodYb4ZmK6gyv63uDnCgUVGruXPyWry3Q_0q_9TTVEPkJVB7K2uyeTXNzHHMEw");
        //        var result = await client.GetAsync("https://api.puntoscolombia.com/pco-openid/connect/v1/userinfo");
        //        var contentResult = result.Content.ReadAsStringAsync();
        //        //var a = JsonConvert.DeserializeObject<DataInput>(await contentResult,);
        //        var jsonResult = JsonSerializer.Deserialize<Object>(contentResult.Result, options);


        //        //return CrearDataInput(JsonConvert.DeserializeObject());
        //        return jsonResult;

        //    }

        //}

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

        public async Task<EventSend> EnviarEvento(EventSend evento)
        {
            EventSend eventSend = new EventSend();
            eventSend = evento;
            //eventSend.Event = "sns.send";
            //eventSend.payload.titulo = "c#";
            //eventSend.payload.descripcion = "Prueba";
            //eventSend.payload.valor = 34;
            //eventSend.payload.flag = false;

            using (var client = new HttpClient())
            {
                JsonContent content = JsonContent.Create(eventSend);

                var result = await client.PostAsync("http://localhost:3000/sns/sqsevent", content);
                var contentResult = result.Content.ReadAsStringAsync();
                var jsonResult = JsonSerializer.Deserialize<EventSend>(contentResult.Result, options);
                return eventSend;

            }

        }
        public async Task<EventoWebHook> EnviarEventoHook(EventoWebHook evento)
        {
            EventoWebHook eventSend = new EventoWebHook();
            eventSend = evento;
            //eventSend.Event = "sns.send";
            //eventSend.payload.titulo = "c#";
            //eventSend.payload.descripcion = "Prueba";
            //eventSend.payload.valor = 34;
            //eventSend.payload.flag = false;
            //var appConfig = new 
            //{
            //    AwsAccessKey = "J55SZUZK3L4J....",
            //    AwsSecretKey = "OrLprpicS81rzBrX......",
            //    AwsRegion = RegionEndpoint.U4SEast2
            //};

            //data.Fecha = fecha;
            var credentials = new BasicAWSCredentials("AKIAXGXL3RJCZEBCA7OM", "MVeN/t7+jLSXuLFY/bNw5cV2aBZv0Sockx5/AW76");
            var client = new Amazon.DynamoDBv2.AmazonDynamoDBClient(credentials, RegionEndpoint.USEast1);
            string nombreTabla = "Hook";
            //SearchRecordsByDocumentModel(nombreTabla);
            //var tableResponse = client.ListTablesAsync();
            //if (!tableResponse.TableNames.Contains(nombreTabla))
            //{
            //    // Create our table if it doesn't exist
            //}
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("es-Es");
            //string fecha = DateTime.Now.ToString("yyyy-MM-dd");

            Amazon.DynamoDBv2.DocumentModel.Table table = Amazon.DynamoDBv2.DocumentModel.Table.LoadTable(client, nombreTabla);
            Document dato = new Document();
            dato["Id"] = eventSend.data.id + eventSend.eventType;
            dato["Event"] = JsonSerializer.Serialize(eventSend);
            //dato["Flujo"] = data.Flujo;
            //dato["Frecuencia"] = data.Frecuencia;
            //dato["Ph"] = data.Ph;
            //dato["Ozono"] = data.Ozono;
            //dato["SumaTanques"] = data.SumaTanques;
            await table.PutItemAsync(dato);
            return eventSend;

            //using (var client = new HttpClient())
            //{
            //    JsonContent content = JsonContent.Create(eventSend);

            //    var result = await client.PostAsync("http://localhost:3000/sns/sqsevent", content);
            //    var contentResult = result.Content.ReadAsStringAsync();
            //    var jsonResult = JsonSerializer.Deserialize<EventSend>(contentResult.Result, options);
            //    return eventSend;

            //}

        }




        //private List<DataInput> CrearDataInput()
        //{
        //    return null;
        //}

    }
}
