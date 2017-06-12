using Forms.DevAzt.FormsX.Net.HttpClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(DevAzt.FormsX.iOS.Net.Http.RestForms))]
namespace DevAzt.FormsX.iOS.Net.Http
{
    public class RestForms : IRestForms
    {
        public async Task<T> Get<T>(string url, Dictionary<string, object> formdata = null)
        {
            try
            {
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(RestSharp.Method.GET);
                foreach (var item in formdata)
                {
                    request.AddParameter(item.Key, item.Value);
                }
                var response = await client.ExecuteTaskAsync(request);
                if (response != null)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Content);
                    }
                }
            }
            catch
            {

            }
            return default(T);
        }

        public async Task<T> Post<T>(string url, Dictionary<string, object> simpleparams = null, List<Param> complexparams = null)
        {
            try
            {
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(RestSharp.Method.POST);
                if (simpleparams != null)
                {
                    foreach (var item in simpleparams)
                    {
                        request.AddParameter(item.Key, item.Value);
                    }
                }

                if (complexparams != null)
                {
                    foreach (var item in complexparams)
                    {
                        switch (item.Type)
                        {
                            case ParamType.File:
                                request.AddFileBytes(item.Name, item.Bytes, item.FileName, item.ContentType);
                                break;
                            case ParamType.String:
                                request.AddParameter(item.Name, item.Element);
                                break;
                        }
                    }
                }
                var response = await client.ExecuteTaskAsync(request);
                if (response != null)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Content);
                    }
                }
            }
            catch
            {

            }
            return default(T);
        }

        public async Task<T> Post<T, K>(string url, K objecttosend)
        {
            try
            {
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(RestSharp.Method.POST);
                request.AddJsonBody(objecttosend);
                var response = await client.ExecuteTaskAsync(request);
                if (response != null)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Content);
                    }
                }
            }
            catch
            {

            }
            return default(T);
        }
    }
}