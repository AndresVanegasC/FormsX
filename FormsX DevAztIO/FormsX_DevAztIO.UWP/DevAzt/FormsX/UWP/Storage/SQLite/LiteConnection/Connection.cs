
using System;
using System.IO;
using Xamarin.Forms;
using DevAzt.FormsX.Storage.SQLite.LiteConnection;
using DevAzt.FormsX.Storage.SQLite.StandarDB;
using Windows.Storage;

[assembly: Dependency(typeof(DevAzt.FormsX.UWP.SQLite.LiteConnection.Connection))]
namespace DevAzt.FormsX.UWP.SQLite.LiteConnection
{
    public class Connection : IDataBase
    {
        public LocalDB GetDataBase()
        {
            var fileName = Keys.DataBaseName;
            var folder = ApplicationData.Current.LocalFolder;
            var path = Path.Combine(folder.Path, fileName);
            return new LocalDB(path);
        }
    }
}