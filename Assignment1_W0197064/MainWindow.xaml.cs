// .NET Application Programming - Assignment 1
// By Gideon Niemelainen W0197064


using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Members
        public AudioPlayer AudioPlayer { get; set; }
        public TagEditor TagEditor { get; set; }
        public Song Song { get; set; }
        public TagLib.File TagLibSelection;
        public Uri SourceFileName;

        public MainWindow()
        {
            InitializeComponent();
        }

      
        /*=============== Application Commands ====================*/
        // In regards to proper architecture, I wasnt sure if I should let these commands be localized to their own user controls or make them application wide.
        // I went with application wide (thus storing them here in Main Window) but I am unsure if that was the correct decision or not
        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // You should be able to open and select a new file whenever you like
            e.CanExecute = true;
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                // resetting the deck when you open a new file
                
            
                // Instantiate an openfiledialog object
                OpenFileDialog fileDlg = new OpenFileDialog();

                // Create a file filter
                fileDlg.Filter = "MP3 files (*.mp3)|*.mp3";
                if(fileDlg.ShowDialog() == true)
                {
                    TagLibSelection = null;
                    Song = null;
                    MainAudioPlayer.MediaPlayer.Stop();
                    TagLibSelection = TagLib.File.Create(fileDlg.FileName);
            
                    SourceFileName = new Uri(fileDlg.FileName);
                    MainAudioPlayer.MediaPlayer.Source = SourceFileName;
                    LoadSong(TagLibSelection);
                    LoadImage(TagLibSelection);
            
                    MakeVisible();
                }
     
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File Open Error");
            }
            
              
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // You shouldnt be allowed to save when there is no file selected
            if (TagLibSelection != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            // Saving time location of media source for saving
            double songPosition = MainAudioPlayer.SongProgressSlider.Value;
            // Disabling media source to avoid "In Use" conflicts
            MainAudioPlayer.MediaPlayer.Source = null;
            try
            {
                if (MainTagEditor.Title() != "" && MainTagEditor.Title() != null)
                {
                    TagLibSelection.Tag.Title = MainTagEditor.Title();
                }
                if (MainTagEditor.Artist() != "" && MainTagEditor.Artist() != null)
                {
                    TagLibSelection.Tag.Performers = new[] { MainTagEditor.Artist() };
                }
                if(MainTagEditor.Album() != "" && MainTagEditor.Album() != null)
                {
                    TagLibSelection.Tag.Album = MainTagEditor.Album();
                }
                if(MainTagEditor.Year() != 0)
                {
                    TagLibSelection.Tag.Year = MainTagEditor.Year();
                }
        
                // Interestingly this sometimes gives me "Access to Path Denied" errors depending on the source im choosing. I was unable to figure out an adequate handler for those cases
                TagLibSelection.Mode = TagLib.File.AccessMode.Write;
                TagLibSelection.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Error");
            }
            

            // Resetting media source to prior source for continuity, so you can continue playback
            MainAudioPlayer.MediaPlayer.Source = SourceFileName;
            MainAudioPlayer.MediaPlayer.Position = TimeSpan.FromSeconds(songPosition);
            MainAudioPlayer.SongProgressSlider.Value = MainAudioPlayer.MediaPlayer.Position.TotalSeconds;
        }
        private void Exit_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
        /*================== Media Commands ===================*/
        private void PlayButton_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!MainAudioPlayer.isPlaying && TagLibSelection != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void PlayButton_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
             MainAudioPlayer.MediaPlayer.Play();
             MainAudioPlayer.isPlaying = true;

        }

        private void PauseButton_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (MainAudioPlayer.isPlaying)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void PauseButton_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MainAudioPlayer.MediaPlayer.Pause();
            MainAudioPlayer.isPlaying = false;

        }

        private void StopButton_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (MainAudioPlayer.isPlaying)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void StopButton_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MainAudioPlayer.MediaPlayer.Stop();
            MainAudioPlayer.isPlaying = false;
        }
       


        /*======================= Helper Functions ======================*/
        // Function to toggle the visibility of various user controls
        public void MakeInvisible()
        {        
            MainAudioPlayer.Visibility = Visibility.Hidden;
            MainTagEditor.Visibility = Visibility.Hidden;
            AlbumImageBlock.Visibility = Visibility.Hidden;                     
        }

        public void MakeVisible()
        {
            MainAudioPlayer.Visibility = Visibility.Visible;
            MainTagEditor.Visibility = Visibility.Visible;
            AlbumImageBlock.Visibility = Visibility.Visible;
        }


        // Function to populate appropriate data fields and reveal user controls
        public void LoadSong(TagLib.File fileSrc)
        {
            string songArtist = "";
            foreach (string text in TagLibSelection.Tag.Performers)
            {
                songArtist += text.ToString();
            }
            // This is a very specific edge case :P
            if (songArtist == "ACDC")
            {
                songArtist = "AC/DC";
            }
            try
            {
                Song = new Song(
                    TagLibSelection.Tag.Title,
                    songArtist,
                    TagLibSelection.Tag.Album,
                    (int)TagLibSelection.Tag.Year
                    );


                MainTagEditor.FillEditor(
                    Song.songTitle,
                    Song.Artist,
                    Song.Album,
                    Song.Year
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Error");
            }

        }
     
        // Function to load the album art image to image holder. This was far more complicated than I was expecting
        public void LoadImage(TagLib.File fileSrc)
        {
            // Some help from here https://stackoverflow.com/questions/17904184/using-taglib-to-display-the-cover-art-in-a-image-box-in-wpf
            try
            {
                TagLib.Picture albumArt = new TagLib.Picture(fileSrc.Tag.Pictures[0]);
            
                if (albumArt != null)
                {
                    MemoryStream ms = new MemoryStream(albumArt.Data.Data);
                    ms.Seek(0, SeekOrigin.Begin);

                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = ms;
                    image.EndInit();

                    System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                    img.Source = image;
                    AlbumImageBlock.Source = img.Source;

                }
                else
                {
                    AlbumImageBlock.Source = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Image Error");
            }
            
        }

        
    }
}
