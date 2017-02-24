namespace DiffusionVideo.Click
{
    internal class playlistDel_button : Iclick_button
    {
        public playlistDel_button(mediaControl medContr, UserControl usrContr)
        {
            for (int i = 0; i < medContr.listUri.Count; i++)
            {
                if (medContr.listUri[i] == usrContr.listBox.SelectedItem) // Si le fichier séléctionné et l'uri "matchent"
                {
                    medContr.listUri.Remove(medContr.listUri[i]); // Enlever l'uri de la liste
                    usrContr.listBox.Items.Remove(usrContr.listBox.SelectedItem); // enlever l'uri de la playlist'
                }
            }
        }
    }
}