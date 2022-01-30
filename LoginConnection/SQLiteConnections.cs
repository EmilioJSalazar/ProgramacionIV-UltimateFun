
using LoginModelsUWP;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginConnection
{
    public class SQLiteConnections
    {
        private SQLiteConnection connection;

        public SQLiteConnections()
        {
            var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.EntretenimientoBD");
            connection = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            connection.CreateTable<TUsers>();
        }

        public SQLiteConnection Connection
        {
            get
            {
                return connection;
            }
        }
    }
}
