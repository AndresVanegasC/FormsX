using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAzt.FormsX.ApplicationModel.Programming.Interface
{
    public class Result<T> : StandarResult
    {

        public T Element { get; set; }

    }
}
