using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevAzt.FormsX.Reflection
{
    public class FormClass
    {

        public virtual bool Check()
        {
            foreach (PropertyInfo pi in this.GetType().GetRuntimeProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = pi.GetValue(this).ToString();
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new NullReferenceException(pi.Name);
                    }
                }
            }
            return true;
        }

        public virtual Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (PropertyInfo pi in this.GetType().GetRuntimeProperties())
            {
                var value = pi.GetValue(this).ToString();
                dictionary.Add(pi.Name, value);
            }
            return dictionary;
        }

    }
}
