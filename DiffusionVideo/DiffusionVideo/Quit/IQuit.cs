using System.Windows.Controls;

namespace DiffusionVideo
{
    public abstract class IQuit
    {
        public bool IsLoaded;
        internal MediaElement TopM;
        internal Diffusion dif;

        public abstract void quit();

        public abstract bool getIsLoaded();
    }
}