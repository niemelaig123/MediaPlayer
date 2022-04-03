using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Assignment1_W0197064
{
    /// <summary>
    /// Interaction logic for AudioPlayer.xaml
    /// </summary>
    /// 

    // The code for the progrtess bar is based heavily off of code found here. SRC: https://wpf-tutorial.com/audio-video/how-to-creating-a-complete-audio-video-player/
    public partial class AudioPlayer : UserControl
    {
        // Members
        public bool isPlaying = false;
        public bool sliderIsDragging = false;
        
        public AudioPlayer()
        {
            InitializeComponent();
            // The dispatch timer is for updating the progress bar and timer
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += TimerIncrement;
            timer.Start();
        }

        private void TimerIncrement(object sender, EventArgs e)
        {
            if((MediaPlayer.Source != null) && (!sliderIsDragging) && (MediaPlayer.NaturalDuration.HasTimeSpan)) 
            {
                SongProgressSlider.Minimum = 0;
                SongProgressSlider.Maximum = MediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                SongProgressSlider.Value = MediaPlayer.Position.TotalSeconds;
            }
        }

        // Progress Slider Methods
        private void SongProgressSlider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            sliderIsDragging = true;
        }

        private void SongProgressSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            sliderIsDragging = false;
            MediaPlayer.Position = TimeSpan.FromSeconds(SongProgressSlider.Value);
        }

        private void SongProgressSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimerText.Text = TimeSpan.FromSeconds(SongProgressSlider.Value).ToString(@"hh\:mm\:ss");
        }


    }
}
