namespace DiffusionVideo.Click
{
    internal class playlistAdd_button : Iclick_button
    {
        public playlistAdd_button(mediaControl medContr, UserControl usrContr)
        {
            if (medContr.u != null) // Si un fichier a ete selectionné
            {
                medContr.listUri.Add(medContr.u); // Ajouter le chemin du fichier a la playlist
                usrContr.listBox.Items.Add(medContr.u);
            }
            else
            {
                Popup popup = new Popup(); // Sinon ça veut dire qu'il faut sélectionner un fichier, donc on ouvre la boite de dialogue
                popup.textBox.Text = "Sélectionnez un fichier.";
                popup.ShowDialog();
            }
        }
    }
}