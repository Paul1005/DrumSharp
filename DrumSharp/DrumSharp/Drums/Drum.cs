using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DrumSharp.Drums
{

    abstract class Drum
    {
        private MediaPlayer player;
        protected BitmapImage image;

        public Drum(Uri imageUri, Uri soundUri)
        {
            if (imageUri != null && soundUri != null)
            {
                image = new BitmapImage(imageUri);
                player = new MediaPlayer();
                player.Open(soundUri);
            }
        }

        public void playSound()
        {
            player.Play();
        }

        public BitmapImage Image { get; }
    }
}


