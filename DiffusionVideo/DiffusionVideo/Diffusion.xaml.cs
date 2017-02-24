using DiffusionVideo.Click;
using System;
using System.Windows;
using System.Windows.Media;

namespace DiffusionVideo
{
    public partial class Diffusion : Window
    {
        private VisualBrush v;
        private UserControl userContr;
        private Iclick_button button_click;

        public mediaControl medContr { get; set; }

        public Diffusion(UserControl m)
        {
            InitializeComponent(); // Initialisation de la fenetre de diffusion

            userContr = m;
            medContr = new mediaControl(TopM, this);
            v = new VisualBrush(TopM); // creation du pinceau visual brush (copie colle ce qui a dans topm)

            v.Stretch = Stretch.Uniform;
            LeftRect.Fill = BotRect.Fill = RightRect.Fill = v;

            KeyDown += new System.Windows.Input.KeyEventHandler(medContr.OnButtonKeyDown); // Instcription a l'event "pression de touche"
            Closing += OnWindowClosing; // Inscrption a l'event closing #observer
        }

        public void cacher() // "Soft Quit"
        {
            Hide();
            TopM.Stop();
            userContr.Show();
        }

        public void chooseFile() // A METTRE DANS MEDIACONTROL
        {
            button_click = new file_button(userContr, medContr);
            button_click = new play_button(this, userContr, medContr);
        }

        private void OnWindowClosing(object o, EventArgs e) // CHECK E
        {
            Application.Current.Shutdown();
        }
    }
}