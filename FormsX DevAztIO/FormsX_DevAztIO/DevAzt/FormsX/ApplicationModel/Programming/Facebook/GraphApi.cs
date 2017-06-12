using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAzt.FormsX.ApplicationModel.Programming.Facebook
{
    public class GraphApi
    {

        public string AccessToken
        {
            get; set;
        }

        public GraphApi(string accesstoken)
        {
            AccessToken = accesstoken;
        }

        public async Task<T> Explorer<T>(string path)
        {
            try
            {
                string requestUrl = $"https://graph.facebook.com/v2.7{path}&access_token={AccessToken}";
                var httpClient = DevAzt.FormsX.Net.HttpClient.RestForms.Instance;
                Debug.WriteLine(requestUrl);
                var response = await httpClient.Get<T>(requestUrl, new Dictionary<string, object>());
                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            return default(T);
        }

    }
}
