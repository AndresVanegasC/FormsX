
using DevAzt.FormsX.Net.HttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAzt.FormsX.ApplicationModel.Programming.Interface
{
    public class DevAztApi<T> : IDevAztApi<T>
    {
        public string BaseUrl { get; set; }

        public DevAztApi(string baseurl)
        {
            BaseUrl = baseurl;
        }

        public string Controller { get; set; }

        public virtual async Task<AddResult> Add(T element)
        {
            try
            {
                var url = $"{BaseUrl}/{Controller}/add";
                var client = RestForms.Instance;
                var result = await client.Post<AddResult, T>(url, element);
                System.Diagnostics.Debug.WriteLine("DevAztApi: url={0} element={1}", url, element);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DevAztApi: Exception encontrada={0}", ex.StackTrace);
            }
            return null;
        }

        public virtual async Task<AddResult> Add(List<Param> formdata)
        {
            try
            {
                var url = $"{BaseUrl}/{Controller}/add";
                var client = RestForms.Instance;
                var result = await client.Post<AddResult>(url, complexparams: formdata);
                System.Diagnostics.Debug.WriteLine("DevAztApi: url={0} formdata={1}", url, formdata);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DevAztApi: Exception encontrada={0}", ex.StackTrace);
            }
            return null;
        }

        public virtual async Task<AddResult> Add(Dictionary<string, object> formdata)
        {
            try
            {
                var url = $"{BaseUrl}/{Controller}/add";
                var client = RestForms.Instance;
                var result = await client.Post<AddResult>(url, simpleparams: formdata);
                System.Diagnostics.Debug.WriteLine("DevAztApi: url={0} formdata={1}", url, formdata);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DevAztApi: Exception encontrada={0}", ex.StackTrace);
            }
            return null;
        }

        public virtual async Task<Result<T>> Get(Param param)
        {
            try
            {
                var url = $"{BaseUrl}/{Controller}/get";
                var client = RestForms.Instance;
                if (param.Type == ParamType.File)
                {
                    throw new Exception("El parametro no puede ser de tipo Strean o ByteArray");
                }
                Dictionary<string, object> data = new Dictionary<string, object>
                {
                    { param.Name, param.Element.ToString() }  
                };
                var result = await client.Get<Result<T>>(url, data);
                System.Diagnostics.Debug.WriteLine("DevAztApi: url={0} param={1}", url, param);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DevAztApi: Exception encontrada={0}", ex.StackTrace);
            }
            return null;
        }

        public virtual async Task<UpdateResult> Update(int id, Dictionary<string, object> formdata)
        {
            try
            {
                var url = $"{BaseUrl}/{Controller}/update/{id}";
                var client = RestForms.Instance;
                var result = await client.Post<UpdateResult>(url, simpleparams: formdata);
                System.Diagnostics.Debug.WriteLine("DevAztApi: url={0} formdata={1}", url, formdata);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DevAztApi: Exception encontrada={0}", ex.StackTrace);
            }
            return null;
        }
        
        public virtual async Task<UpdateResult> Update(int id, List<Param> formdata)
        {
            try
            {
                var url = $"{BaseUrl}/{Controller}/update/{id}";
                var client = RestForms.Instance;
                var result = await client.Post<UpdateResult>(url, complexparams: formdata);
                System.Diagnostics.Debug.WriteLine("DevAztApi: url={0} formdata={1}", url, formdata);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DevAztApi: Exception encontrada={0}", ex.StackTrace);
            }
            return null;
        }

        public async Task<SearchResult<T>> Search(Dictionary<string, object> formdata)
        {
            try
            {
                var url = $"{BaseUrl}/{Controller}/search";
                var client = RestForms.Instance;
                var result = await client.Post<SearchResult<T>>(url, simpleparams: formdata);
                System.Diagnostics.Debug.WriteLine("DevAztApi: url={0} formdata={1}", url, formdata);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DevAztApi: Exception encontrada={0}", ex.StackTrace);
            }
            return null;
        }

        public async Task<SearchResult<T>> Search(List<Param> formdata)
        {
            try
            {
                var url = $"{BaseUrl}/{Controller}/search";
                var client = RestForms.Instance;
                var result = await client.Post<SearchResult<T>>(url, complexparams: formdata);
                System.Diagnostics.Debug.WriteLine("DevAztApi: url={0} formdata={1}", url, formdata);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DevAztApi: Exception encontrada={0}", ex.StackTrace);
            }
            return null;
        }
    }
}
