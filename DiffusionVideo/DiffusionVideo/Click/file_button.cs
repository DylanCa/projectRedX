using System;
using System.IO;
using System.Windows;

namespace DiffusionVideo.Click
{
    internal class file_button : Iclick_button
    {
        public file_button(UserControl usrContr, mediaControl medContr) // Bouton choix fichier
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Image Files (JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF|Video Files (MP4,AVI,MKV)|*.MP4;*.AVI;*.MKV|Sound Files(MP3,OGG,FLAC)|*.MP3;*.OGG;*.FLAC|Text Files(TXT)|*.TXT|All Files(*.*)|*.*"; // rajout de filtre en extension, la syntaxe est : type | ext

            Nullable<bool> file = dlg.ShowDialog(); // Nullable bool = file : true, false, null 

            if (file == true) // Si il y a un fichier 
            {
                medContr.u = new Uri(dlg.FileName); // Recup Uri
                usrContr.textBox.Text = dlg.SafeFileName;
            }
        }
    }
}