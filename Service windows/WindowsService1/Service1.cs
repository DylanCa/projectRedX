using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Timers;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        private static PerformanceCounter ramCounter;
        private static PerformanceCounter cpuCounter;
        private static string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\dylan\\OneDrive\\Documents\\perfanalyser.mdf;Integrated Security = True; Connect Timeout = 30";

        public Service1()
        {
            InitializeComponent();
            InitializeCounter();

            Timer aTimer = new Timer();

            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            aTimer.Interval = 1000;
            aTimer.Start();

        }

        protected override void OnStart(string[] args)
        {

        }

        protected override void OnStop()
        {
        }

        private static void InitializeCounter()
        {
            ramCounter = new PerformanceCounter("Memory", "Available MBytes", true);
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "Update performances SET RAMDISPO = @RAMDISPO, CPUPERCENT = @CPUPERCENT Where ID = 1";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@RAMDISPO", SqlDbType.Float).Value = ramCounter.NextValue();
                cmd.Parameters.Add("@CPUPERCENT", SqlDbType.Float).Value = cpuCounter.NextValue();
                cmd.CommandType = CommandType.Text;
                // Console.WriteLine("Valeurs dans la requete : {0} , {1}", cmd.Parameters["@RAMDISPO"].Value, cmd.Parameters["@CPUPERCENT"].Value);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
