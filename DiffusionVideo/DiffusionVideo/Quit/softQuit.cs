using System.Windows;
using System.Windows.Controls;

namespace DiffusionVideo
{
    internal class softQuit : IQuit // Quitter la diffusion mais reafficher le lanceur
    {
        public softQuit(MediaElement TopM, Diffusion dif)
        {
            base.TopM = TopM;
            base.dif = dif;
            IsLoaded = true;
        }

        public override void quit()
        {
            TopM.Pause();

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Voulez-vous quitter la projection ?", "Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                dif.cacher();
            }
            else if (messageBoxResult == MessageBoxResult.No)
            {
                TopM.Play();
            }
        }

        public override bool getIsLoaded()
        {
            return IsLoaded;
        }
    }
}