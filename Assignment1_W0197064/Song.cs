using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_W0197064
{
    public class Song
    {
        // member fields
        public string songTitle { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public int Year { get; set; }


        // Constructor
        public Song(string title, string artist, string album, int year)
        {
            songTitle = title;
            Artist = artist;
            Album = album;
            Year = year;
        }
        public Song()
        {
            songTitle = "blank";
            Artist = "blank";
            Album = "blank";
            Year = 1999;
        }
    }
}
