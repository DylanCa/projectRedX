using System.Windows.Controls;

namespace DiffusionVideo
{
    internal class hardQuit : IQuit // Quit via la croix
    {
        public override void quit()
        {
            base.IsLoaded = false;
        }

        public hardQuit(MediaElement TopM, Diffusion dif)
        {
            base.TopM = TopM;
            base.dif = dif;
            IsLoaded = false;
        }

        public override bool getIsLoaded()
        {
            return IsLoaded;
        }
    }
}