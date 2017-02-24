using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DiffusionVideo
{
    public class mediaControl
    {
        private MediaElement TopM;
        private Diffusion diff;

        private bool currPlaying = false;
        private bool mute = false; // STOP MUTE SI SON MONTÉ !!!
        private int i;

        public List<Uri> listUri = new List<Uri>();
        public IQuit q;
        public Uri u { get; set; }
        public UserControl usrContr { get; set; }

        public mediaControl(MediaElement m, Diffusion dif)
        {
            TopM = m;
            diff = dif;

            q = new softQuit(TopM, diff);
        }

        public void OnButtonKeyDown(object sender, KeyEventArgs e) // DP Observer // SWITCH ? ELSE IF ?
        {
            if (e.Key == Key.F)
            {
                if (diff.WindowState == WindowState.Normal)
                {
                    diff.WindowStyle = WindowStyle.None;
                    diff.WindowState = WindowState.Maximized;
                }
                else if (diff.WindowState == WindowState.Maximized)
                {
                    diff.WindowStyle = WindowStyle.SingleBorderWindow;
                    diff.WindowState = WindowState.Normal;
                }
            }

            if (e.Key == Key.Space)
            {
                if (currPlaying == true)
                { // DPOBSERVER
                    TopM.Pause();
                    currPlaying = !currPlaying;
                }
                else if (currPlaying == false)
                {
                    TopM.Play();
                    currPlaying = !currPlaying;
                }
            }
            if (e.Key == Key.L)
            {
                diff.chooseFile(); // POSSIBILITE D'UTILISER LE BUTTONCLICK DPOBS
            }
            if (e.Key == Key.N)
            {
                playlistNext();
            }

            if (e.Key == Key.P)
            {
                playlistPrev();
            }

            if (e.Key == Key.Escape)
            {
                OnWindowClosing("softQuit");
            }

            if (e.Key == Key.S)
            {
                TopM.Stop();
                currPlaying = false;
            }

            if (e.Key == Key.M)
            {
                if (mute == false)
                {
                    TopM.IsMuted = true;
                    mute = !mute;
                }
                else if (mute == true)
                {
                    TopM.IsMuted = false;
                    mute = !mute;
                }
            }

            if (e.Key == Key.Up)
            {
                TopM.Volume = TopM.Volume + 0.05;
            }
            if (e.Key == Key.Down)
            {
                TopM.Volume = TopM.Volume - 0.05;
            }
            if (e.Key == Key.Left)
            {
                TopM.Position = TopM.Position - new TimeSpan(0, 0, 5);
            }

            if (e.Key == Key.Right)
            {
                TopM.Position = TopM.Position + new TimeSpan(0, 0, 5);
            }
        }

        public void setURL(Uri u)
        {
            currPlaying = true;

            usrContr.Hide();

            listUri.Add(u);
            playlistPlay();

            diff.Show();
            diff.Focus();
        }

        public void playlistPlay()
        {
            if (usrContr.rImageLoop.IsChecked == true)
            {
                System.Timers.Timer aTimer = new System.Timers.Timer();
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                aTimer.Interval = 10000;
                aTimer.Enabled = true;
            }
            else if (usrContr.rStop.IsChecked == true)
            {
                diff.TopM.UnloadedBehavior = MediaState.Stop;
            }
            else if (usrContr.rNormal.IsChecked == true)
            {
                diff.TopM.MediaEnded += OnMediaEnded;
            }

            if (Path.GetExtension(listUri[0].ToString()) == ".txt")
            {
                //using() // IDISPOSABLE ?
                //{
                diff.LeftText.Text = diff.TopText.Text = diff.RightText.Text = diff.BotText.Text = File.ReadAllText(listUri[0].OriginalString);
                //}
            }
            else
            {
                TopM.Source = listUri[0];
                TopM.Play();
                currPlaying = true;
            }
        }

        public void playlistNext()
        {
            if (listUri.Count == 1)
            {
                if (Path.GetExtension(listUri[0].ToString()) == ".txt")
                {
                    TopM.Stop();
                    TopM.Source = null;
                    diff.LeftText.Text = diff.TopText.Text = diff.RightText.Text = diff.BotText.Text = File.ReadAllText(listUri[0].OriginalString);
                }
                else
                {
                    diff.LeftText.Text = diff.TopText.Text = diff.RightText.Text = diff.BotText.Text = null;
                    TopM.Source = listUri[0];
                    TopM.Play();
                }
                currPlaying = true;
            }
            else if (i < (listUri.Count - 1))
            {
                i++;

                if (Path.GetExtension(listUri[i].ToString()) == ".txt")
                {
                    TopM.Stop();
                    TopM.Source = null;
                    diff.LeftText.Text = diff.TopText.Text = diff.RightText.Text = diff.BotText.Text = File.ReadAllText(listUri[i].OriginalString);
                }
                else
                {
                    diff.LeftText.Text = diff.TopText.Text = diff.RightText.Text = diff.BotText.Text = null;
                    TopM.Source = listUri[i];
                    TopM.Play();
                }
                currPlaying = true;
            }
            else if (i == (listUri.Count - 1))
            {
                i = 0;
                if (Path.GetExtension(listUri[i].ToString()) == ".txt")
                {
                    TopM.Stop();
                    TopM.Source = null;
                    diff.LeftText.Text = diff.TopText.Text = diff.RightText.Text = diff.BotText.Text = File.ReadAllText(listUri[i].OriginalString);
                }
                else
                {
                    diff.LeftText.Text = diff.TopText.Text = diff.RightText.Text = diff.BotText.Text = null;
                    TopM.Source = listUri[i];
                    TopM.Play();
                }
                currPlaying = true;
            }
        }

        // A REDUIRE !! !! ! !! !!! !! !! !! !! !! !! !! ( Répétitions de méthodes )
        public void playlistPrev()
        {
            if (listUri.Count == 1)
            {
                if (Path.GetExtension(listUri[0].ToString()) == ".txt")
                {
                    TopM.Stop();
                    TopM.Source = null;
                    diff.LeftText.Text = diff.TopText.Text = diff.RightText.Text = diff.BotText.Text = File.ReadAllText(listUri[0].OriginalString);
                }
                else
                {
                    diff.LeftText.Text = diff.TopText.Text = diff.RightText.Text = diff.BotText.Text = null;
                    TopM.Source = listUri[0];
                    TopM.Play();
                }
                currPlaying = true;
            }
            else if (i > 0)
            {
                i = i - 1;
                if (Path.GetExtension(listUri[i].ToString()) == ".txt")
                {
                    TopM.Stop();
                    TopM.Source = null;
                    diff.LeftText.Text = diff.TopText.Text = diff.RightText.Text = diff.BotText.Text = File.ReadAllText(listUri[i].OriginalString);
                }
                else
                {
                    diff.LeftText.Text = diff.TopText.Text = diff.RightText.Text = diff.BotText.Text = null;
                    TopM.Source = listUri[i];
                    TopM.Play();
                }
                currPlaying = true;
            }
            else if (i == 0 && listUri.Count != 0)
            {
                i = (listUri.Count - 1);
                if (Path.GetExtension(listUri[i].ToString()) == ".txt")
                {
                    TopM.Stop();
                    TopM.Source = null;
                    diff.LeftText.Text = diff.TopText.Text = diff.RightText.Text = diff.BotText.Text = File.ReadAllText(listUri[i].OriginalString);
                }
                else
                {
                    diff.LeftText.Text = diff.TopText.Text = diff.RightText.Text = diff.BotText.Text = null;
                    TopM.Source = listUri[i];
                    TopM.Play();
                }
                currPlaying = true;
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e) // A BOSSER
        {
            diff.Dispatcher.Invoke((Action)(() =>
            {
                playlistNext();
            }));
        }

        private void OnMediaEnded(object sender, RoutedEventArgs e)
        {
            playlistNext();
        }

        public void OnWindowClosing(string s)
        {
            switch (s)
            {
                case "hardQuit":
                    q = new hardQuit(TopM, diff);
                    break;

                case "softQuit":
                    q = new softQuit(TopM, diff);
                    break;

                default:
                    break;
            }

            q.quit();
        }
    }
}