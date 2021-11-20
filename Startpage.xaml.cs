using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace IERG3080_____Pokemon_Go
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Startpage : Page
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        private TimeSpan interval3 = new TimeSpan(0, 0, 5);
        bool flag;
        private MediaPlayer bgm = new MediaPlayer();
        private TimeSpan interval = new TimeSpan(0, 1, 0);
        public Startpage()
        {
            InitializeComponent();

            loading.Source = (GetPicture.Source("loading")).Source;
            title.Source = (GetPicture.Source("title")).Source;
            theme.Source = new Uri(GetPicture.Source_gif("theme"));

            string link = GetPicture.Source_mp3("title_song");
            bgm.Open(new Uri(link, UriKind.Relative));
            bgm.Volume = 0.1;
            bgm.Play();

            theme.Play();

            timer();
        }
        private void timer()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer(); // adding the timer to the form
            dispatcherTimer.Tick += Timer_Tick; // linking the timer event
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(20); // running the timer every 20 milliseconds
            dispatcherTimer.Start(); // starting the timer
        }
        private void start_game(object sender, RoutedEventArgs e)
        {
            bgm.Stop();
            flag = false;
            NavigationService.Navigate(new Map());
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (flag == false)
            {
                dispatcherTimer.Tick -= Timer_Tick;
                dispatcherTimer.Stop();
            }

            if (bgm.Position > interval)
            {
                bgm.Position = TimeSpan.Zero;
                bgm.Play();
            }

            if (bgm.Position > interval3)
            {
                theme.Position = TimeSpan.Zero;
                theme.Play();
            }
        }
    }
}
