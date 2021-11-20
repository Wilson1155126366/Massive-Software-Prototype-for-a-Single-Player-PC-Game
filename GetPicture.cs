using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IERG3080_____Pokemon_Go
{
    public static class GetPicture
    {
        public static Image Source(string filename)
        {
            string image_source = (Directory.GetCurrentDirectory() + "..\\..\\..\\..\\useful_picture\\" + filename + ".PNG").ToString();
            Image img = new Image
            {
                Source = new BitmapImage(new Uri(image_source, UriKind.RelativeOrAbsolute)),
            };
            return img;
        }
        public static string Source_mp3(string filename)
        {
            string image_source = (Directory.GetCurrentDirectory() + "..\\..\\..\\..\\bgm\\" + filename + ".mp3").ToString();
            return image_source;
        }
        public static string Source_gif(string filename)
        {
            string image_source = (Directory.GetCurrentDirectory() + "..\\..\\..\\..\\animation\\" + filename + ".gif").ToString();
            return image_source;
        }
    }
}
