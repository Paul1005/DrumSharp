using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace DrumSharp.Drums
{

    abstract class Drum
    {
        private MediaPlayer[] playerArray;
        private int currentPlayerIndex;
        protected BitmapImage image;
        private Key binding1 = Key.A;
        private Key binding2 = Key.S;

        public Drum(Uri imageUri, Uri soundUri)
        {
            if (imageUri != null && soundUri != null)
            {
                image = new BitmapImage(imageUri);
                playerArray = new MediaPlayer[3];

                for (int i = 0; i < playerArray.Length; i++)
                {
                    playerArray[i] = new MediaPlayer();
                    playerArray[i].Open(soundUri);
                }
            }
        }

        public void playSound()
        {
            playerArray[currentPlayerIndex].Play();
            playerArray[currentPlayerIndex++].Position = System.TimeSpan.FromMilliseconds(0);
            if (currentPlayerIndex > 2)
            {
                currentPlayerIndex = 0;
            }
        }

        public BitmapImage Image { get; }
    }
}