using System.Data;
using System.Data.SqlClient;

namespace DiffusionVideo
{
    internal class checkBDD
    {
        // A tester sur une machine avec MySQL bien configuré ( théoriquement, ça marche, ça retourne les valeurs ramDispo et cpuPercent en Double qui
        // sont dans la BDD.

        //private string connStringMySQL;
        //private double ramDispo;
        //private double cpuPercent;

        //public void checkPerf()
        //{
        //    using (SqlConnection conn = new SqlConnection(@"Server = localhost; Database = perfanalyzer; Uid = csharp; Pwd = csharp;"))
        //    {
        //        conn.Open();
        //        string sql = "select * from performances";
        //        SqlCommand cmd = new SqlCommand(sql, conn);
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            ramDispo = reader.GetDouble(0);
        //            cpuPercent = reader.GetDouble(1);
        //        }
        //    }
        //}
    }
}