
using System;
using System.IO;
using Xamarin.Forms;
using DevAzt.FormsX.Storage.SQLite.LiteConnection;
using DevAzt.FormsX.Storage.SQLite.StandarDB;

[assembly: Dependency(typeof(DevAzt.FormsX.Droid.SQLite.LiteConnection.Connection))]
namespace DevAzt.FormsX.Droid.SQLite.LiteConnection
{
    public class Connection : IDataBase
    {
        public LocalDB GetDataBase()
        {
            var fileName = Keys.DataBaseName;
            var internalpath = Android.OS.Environment.ExternalStorageDirectory.Path;
            var path = Path.Combine(internalpath, fileName);
            //var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //var path = Path.Combine(documentsPath, fileName);
            return new LocalDB(path);
        }
    }
}