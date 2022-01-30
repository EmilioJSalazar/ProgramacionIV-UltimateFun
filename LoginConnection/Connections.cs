using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;
using LoginModelsUWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginConnection
{
    public class Connections : DataConnection
    {
        public Connections(): base(new SqlServerDataProvider("",SqlServerVersion.v2012),
            "Data Source=LAPTOP-1745L0OO\\SQLEXPRESS;Database=EntreteniminetoBD;Integrated Security=True;")
        {}

        public ITable<TUsers> TUsers => GetTable<TUsers>();
    }
}
