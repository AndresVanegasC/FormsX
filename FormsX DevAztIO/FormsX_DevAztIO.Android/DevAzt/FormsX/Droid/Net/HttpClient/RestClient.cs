using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using DevAzt.FormsX.Net.HttpClient;
using System.Net;
using System.IO;
using DevAzt.FormsX.Json;
using Patrimonio.FormsX.Helpers;

[assembly: Dependency(typeof(DevAzt.FormsX.Droid.Net.Http.RestForms))]
namespace DevAzt.FormsX.Droid.Net.Http
{
    public class RestForms : IRestForms
    {
        public async Task<T> Delete<T>(string url, int id)
        {
            try
            {
                Debugger.WriteLine("RestSharp: " + url);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(RestSharp.Method.DELETE);
                var response = await client.ExecuteTaskAsync(request);
                if (response != null)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Debugger.WriteLine("RestSharp: " + response.Content);
                        return response.Content.DeserializeObject<T>();
                    }
                }
            }
            catch (Exception ex)
            {
                Debugger.WriteLine("RestSharp: " + ex.StackTrace);
            }
            return default(T);
        }

        public async Task<T> Get<T>(string url, Dictionary<string, object> formdata = null)
        {
            try
            {
                Debugger.WriteLine("RestSharp: " + url);
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
                        Debugger.WriteLine("RestSharp: " + response.Content);
                        return response.Content.DeserializeObject<T>();
                    }
                }
            }
            catch (Exception ex)
            {
                Debugger.WriteLine("RestSharp: " + ex.StackTrace);
            }
            return default(T);
        }

        public async Task<T> Post<T>(string url, Dictionary<string, object> simpleparams = null, List<Param> complexparams = null)
        {
            try
            {
                Debugger.WriteLine("RestSharp: " + url);
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
                        Debugger.WriteLine("RestSharp: " + response.Content);
                        return response.Content.DeserializeObject<T>();
                    }
                }
            }
            catch (Exception ex)
            {
                Debugger.WriteLine("RestSharp: " + ex.StackTrace);
            }
            return default(T);
        }

        public async Task<T> Post<T, K>(string url, K objecttosend)
        {
            try
            {
                Debugger.WriteLine("RestSharp: " + url);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(RestSharp.Method.POST);
                var jsonstring = objecttosend.SerializeObject();
                request.AddJsonBody(jsonstring);
                request.RequestFormat = RestSharp.DataFormat.Json;
                var response = await client.ExecuteTaskAsync(request);
                if (response != null)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Debugger.WriteLine("RestSharp: " + response.Content);
                        return response.Content.DeserializeObject<T>();
                    }
                }
            }
            catch (Exception ex)
            {
                Debugger.WriteLine("RestSharp: " + ex.StackTrace);
            }
            return default(T);
        }
    }
}