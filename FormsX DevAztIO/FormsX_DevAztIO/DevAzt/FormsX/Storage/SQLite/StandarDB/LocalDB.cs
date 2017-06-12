
using DevAzt.FormsX.Storage.SQLite.LiteConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAzt.FormsX.Storage.SQLite.StandarDB
{
    public class LocalDB : DataBase
    {
        public LocalDB(string databasePath, bool storeDateTimeAsTicks = true) : base(databasePath, storeDateTimeAsTicks)
        {

        }
    }
}
