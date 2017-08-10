using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrimonio.FormsX.Helpers
{
    public class Debugger
    {

        public static bool PrintInfo { get; set; }

        public static void WriteLine(object printobject)
        {
            if (PrintInfo)
            {
                System.Diagnostics.Debug.WriteLine(printobject);
            }
        }

    }
}
