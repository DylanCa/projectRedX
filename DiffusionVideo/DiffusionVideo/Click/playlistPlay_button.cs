namespace DiffusionVideo.Click
{
    internal class playlistPlay_button : Iclick_button
    {
        public playlistPlay_button(mediaControl medContr, Diffusion dif)
        {
            if (medContr.listUri.Count != 0) // ?? la logique 
            {
                dif.Show();
                dif.Focus();
                medContr.playlistPlay();
            }
            else //  Sinon afficher une erreur via la popup
            {
                Popup popup = new Popup();
                popup.textBox.Text = "Playlist non configurée.";
                popup.ShowDialog();
            }
        }
    }
}