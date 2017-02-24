namespace DiffusionVideo.Click
{
    internal class play_button : Iclick_button
    {
        public play_button(Diffusion diff, UserControl usrContr, mediaControl medContr)
        {
            if (medContr.q.IsLoaded == true) // A corriger ( ne se relance pas )
            {
                if (medContr.u != null)
                {
                    medContr.setURL(medContr.u); // ?
                }
                else
                {
                    Popup popup = new Popup(); // Afficher la popup avec le texte en fonction de la condition 
                    popup.ShowDialog();
                }
            }
            else
            {
                diff = new Diffusion(usrContr);
                usrContr.medContr = diff.medContr; // Diffusion du média element 
            }
        }
    }
}