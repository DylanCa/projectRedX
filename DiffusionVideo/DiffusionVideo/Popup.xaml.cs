using System.Windows;
using System.Windows.Controls;

namespace DiffusionVideo
{
    /// <summary>
    /// Logique d'interaction pour Popup.xaml
    /// </summary>
    public partial class Popup : Window
    {
        public Popup()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}