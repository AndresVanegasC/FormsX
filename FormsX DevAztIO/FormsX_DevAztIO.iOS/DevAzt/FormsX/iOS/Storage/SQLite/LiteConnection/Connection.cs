
using DevAzt.FormsX.Storage.SQLite.LiteConnection;
using System;
using System.IO;
using DevAzt.FormsX.Storage.SQLite.StandarDB;

[assembly: Xamarin.Forms.Dependency(typeof(DevAzt.FormsX.iOS.Storage.SQLite.LiteConnection.Connection))]
namespace DevAzt.FormsX.iOS.Storage.SQLite.LiteConnection
{
    public class Connection : IDataBase
    {
        public LocalDB GetDataBase()
        {
            string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, Keys.DataBaseName);
            return new LocalDB(path);
        }
    }
}
