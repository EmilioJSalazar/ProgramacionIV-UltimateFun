using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginConnection
{
    public class Connections : DataConnection
    {
        public Connections(): base(new SqlServerDataProvider("",SqlServerVersion.v2017),
            "Data Source=DESKTOP-SL1SN3F\\SQLEXPRESS;Database=EntreteniminetoBD;Integrated Security=True;")
        {

        }
    }
}
