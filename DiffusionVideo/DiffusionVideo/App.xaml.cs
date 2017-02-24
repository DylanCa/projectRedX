using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace DiffusionVideo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dylan\Desktop\perfanalyser.mdf;Integrated Security=True;Connect Timeout=30"; // Chaine de connexion a la bdd

        private static Application app = new Application();

        [STAThread]
        public static void Main(string[] args)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "select * from performances Where ID = 1"; // rq sql glissée a la commande
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader(); // execution rq sql

                while (reader.Read())
                {
                    if (reader.GetDouble(0) < 85 && reader.GetDouble(1) > 550) // Si les resultats de la rq sql sont positifs, alors on lance l'app
                    {
                        UserControl usrContr = new UserControl();
                        app.Run(usrContr);
                    }
                    else
                    {
                        Popup pop = new Popup(); // Affichage d'une popup en cas de non respect des conditions d'utilisation cpu / memoire
                        pop.Height = 260;
                        pop.Width = 290;
                        pop.textBox.Height = 200;
                        pop.textBox.Width = 250;
                        pop.textBox.Text = String.Format("\n\nLes conditions requises pour lancer l'application ne sont pas présentes. ( 550mb RAM & 15% CPU )\n\nVous avez {0}% de CPU de libre et {1} MB de RAM de libre.\n\nVeuillez fermer certaines applications consommant trop de mémoire ( Jeux, Google Chrome ..) et relancer l'application.", String.Format("{0:0.00}", reader.GetDouble(0)), reader.GetDouble(1));
                        app.Run(pop);
                    }
                }
            }
        }
    }
}