using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllBdd
{
    public class dll1
    {
        public void OpenConnection(SqlConnection conn)
        {
            conn.Open();
        }
    }
}
