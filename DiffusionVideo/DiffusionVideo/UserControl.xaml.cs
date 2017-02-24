using DiffusionVideo.Click;
using System;
using System.Windows;

namespace DiffusionVideo
{
    public partial class UserControl : Window
    {
        private Diffusion diff;
        private Iclick_button buttonClick;

        public mediaControl medContr { get; set; }

        public UserControl()
        {
            InitializeComponent();
            diff = new Diffusion(this);

            medContr = diff.medContr;
            medContr.usrContr = this;

            Closing += this.OnWindowClosing;
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            buttonClick = new playlistPlay_button(medContr, diff);
        }

        private void choose_Click(object sender, RoutedEventArgs e)
        {
            buttonClick = new file_button(this, medContr);
        }

        private void addPlay_Click(object sender, RoutedEventArgs e)
        {
            buttonClick = new playlistAdd_button(medContr, this);
        }

        private void delPlay_Click(object sender, RoutedEventArgs e)
        {
            buttonClick = new playlistDel_button(medContr, this);
        }

        public void filePlay_Click(object sender, RoutedEventArgs e)
        {
            buttonClick = new play_button(diff, this, medContr);
        }

        private void OnWindowClosing(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}