
using DevAzt.FormsX.Net.HttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAzt.FormsX.ApplicationModel.Programming.Interface
{
    public interface IDevAztApi<T>
    {
        Task<AddResult> Add(T element);

        Task<AddResult> Add(List<Param> formdata);

        Task<AddResult> Add(Dictionary<string, object> formdata);

        Task<Result<T>> Get(Param param);

        Task<UpdateResult> Update(int id, Dictionary<string, object> formdata);

        Task<UpdateResult> Update(int id, List<Param> formdata);

        Task<SearchResult<T>> Search(Dictionary<string, object> formdata);

        Task<SearchResult<T>> Search(List<Param> formdata);

    }
}
