using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DevAzt.FormsX.Net.HttpClient;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;

using DevAzt.FormsX.Json;
using Patrimonio.FormsX.Helpers;

[assembly: Dependency(typeof(DevAzt.FormsX.UWP.Net.Http.RestForms))]
namespace DevAzt.FormsX.UWP.Net.Http
{
    public class RestForms : IRestForms
    {
        public async Task<T> Delete<T>(string url, int id)
        {

            try
            {
                HttpClient client = new HttpClient();
                Debugger.WriteLine("RestForms: " + url);
                var response = await client.DeleteAsync(url);
                Debugger.WriteLine("RestForms: " + response);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Debugger.WriteLine("RestForms: " + json);
                    return json.DeserializeObject<T>();
                }
            }
            catch (Exception ex)
            {
                Debugger.WriteLine("RestForms: " + ex.StackTrace);
            }

            return default(T);
        }

        public async Task<T> Get<T>(string url, Dictionary<string, object> formdata = null)
        {
            try
            {
                HttpClient client = new HttpClient();
                List<string> parametrosnoserializados = new List<string>();
                foreach (var form in formdata)
                {
                    parametrosnoserializados.Add($"{form.Key}={form.Value}");
                }

                string serializedata = string.Join("&", parametrosnoserializados);
                url += $"?{serializedata}";
                Debugger.WriteLine("RestForms: " + url);
                var response = await client.GetAsync(url);
                Debugger.WriteLine("RestForms: " + response);
                if (response != null)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        Debugger.WriteLine("RestForms: " + json);
                        return json.DeserializeObject<T>();
                    }
                }
            }
            catch (Exception ex)
            {
                Debugger.WriteLine("RestForms: " + ex.StackTrace);
            }
            return default(T);
        }
        
        public async Task<T> Post<T>(string url, Dictionary<string, object> simpleparams = null, List<Param> complexparams = null)
        {
            try
            {
                var client = new HttpClient();

                Dictionary<string, string> formurldictionary = new Dictionary<string, string>();
                MultipartFormDataContent content = new MultipartFormDataContent();
                if (simpleparams != null)
                {
                    foreach (var item in simpleparams)
                    {
                        content.Add(new StringContent(item.Value.ToString()), item.Key);
                    }
                }
                
                if (complexparams != null)
                {
                    foreach (var item in complexparams)
                    {
                        switch (item.Type)
                        {
                            case ParamType.File:
                                var stream = new MemoryStream(item.Bytes);
                                content.Add(new StreamContent(stream), item.Name, item.FileName);
                                break;
                            case ParamType.String:
                                content.Add(new StringContent(item.Element.ToString()), item.Name);
                                break;
                        }
                    }
                }
                Debugger.WriteLine("RestForms: " + url);
                var response = await client.PostAsync(url, content);
                if (response != null)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        Debugger.WriteLine("RestForms: " + json);
                        return json.DeserializeObject<T>();
                    }
                }
            }
            catch (Exception ex)
            {
                Debugger.WriteLine("RestForms: " + ex.StackTrace);
            }
            return default(T);
        }

        public async Task<T> Post<T, K>(string url, K objecttosend)
        {
            try
            {
                var client = new HttpClient();
                var json = objecttosend.SerializeObject();
                Debugger.WriteLine("RestForms: " + json);
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                Debugger.WriteLine("RestForms: " + url);
                var response = await client.PostAsync(url, content);
                if (response != null)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var jsonresponse = await response.Content.ReadAsStringAsync();
                        Debugger.WriteLine("RestForms: " + jsonresponse);
                        return jsonresponse.DeserializeObject<T>();
                    }
                }
            }
            catch (Exception ex)
            {
                Debugger.WriteLine("RestForms: " + ex.StackTrace);
            }
            return default(T);
        }
    }
}