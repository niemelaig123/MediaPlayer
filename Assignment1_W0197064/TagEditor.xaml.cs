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

namespace Assignment1_W0197064
{
    /// <summary>
    /// Interaction logic for TagEditor.xaml
    /// </summary>
    ///

    public partial class TagEditor : UserControl
    {
        public TagEditor()
        {
            InitializeComponent();
        }

        public void FillEditor(string title, string artist, string album, int year)
        {
            SongTitleTagBlock.Text = title;
            ArtistTagBlock.Text = artist;
            AlbumTagBlock.Text = album;
            YearTagBlock.Text = year.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        // Getters for getting field contents
        public string Title()
        {
            return SongTitleTagBlock.Text;
        }

        public string Artist()
        {
            return ArtistTagBlock.Text;
        }

        public string Album()
        { return AlbumTagBlock.Text;}
        public uint Year()
        {
            if(uint.TryParse(YearTagBlock.Text, out uint result))
            {
                return uint.Parse(YearTagBlock.Text);
            }
            else
            {
                MessageBox.Show("The Year must be an integer", "Error");
                return 0;
            }
            
        }
    }
}
