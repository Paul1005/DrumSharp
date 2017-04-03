using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace DrumSharp.Drums
{
    /// <summary>
    /// Drum is the base class for all Drum objects in the game.
    /// All drums have 3 media players, an image, and 2 Keys that play a sound
    /// when the user presses either.
    /// </summary>
    abstract class Drum
    {
        //Array of sound players for concurrent audio playback
        private MediaPlayer[] playerArray;
        //Index in the player array for concurrent audio playback
        private int currentPlayerIndex = 0;
        //Image of the drum
        protected BitmapImage image;
        //Keys for gameplay
        private Key binding1 = Key.A;
        private Key binding2 = Key.S;

        /// <summary>
        /// <para/>Purpose: Constructor for Drum
        /// <para/>Input: 
        ///     imageUri: filepath of the image file
        ///     soundUri: filepath of the sound file
        /// <para/>Output: none
        /// <para/>Author: Connor Goudie
        /// <para/>Date: March 14, 2017
        /// <para/>Updated by: 
        /// <para/>Date: March 20, 2017
        /// </summary>
        public Drum(Uri imageUri, Uri soundUri)
        {
            if (imageUri != null && soundUri != null)
            {
                image = new BitmapImage(imageUri);

                //creates and populates array of MediaPlayers
                playerArray = new MediaPlayer[10];
                for (int i = 0; i < playerArray.Length; i++)
                {
                    playerArray[i] = new MediaPlayer();
                    playerArray[i].IsMuted = true;
                    playerArray[i].MediaOpened += Drum_MediaOpened;
                    playerArray[i].Open(soundUri);
                }
            }
        }

        private void Drum_MediaOpened(object sender, EventArgs e)
        {
            Console.WriteLine("yes");
            MediaPlayer tmp = (MediaPlayer)sender;
            tmp.Pause();
            tmp.IsMuted = false;
        }

        /// <summary>
        /// <para/>Purpose: Plays drum sound
        /// <para/>Input: none
        /// <para/>Output: none
        /// <para/>Author: Connor Goudie
        /// <para/>Date: March 14, 2017
        /// <para/>Updated by: 
        /// <para/>Date: March 20, 2017
        /// </summary>
        public void playSound()
        {
            playerArray[currentPlayerIndex].Position = System.TimeSpan.FromMilliseconds(0);
            playerArray[currentPlayerIndex].Play();
            
            if (++currentPlayerIndex >= playerArray.Length)
            {
                currentPlayerIndex = 0;
            }
        }

        /// <summary>
        /// Getter for for image
        /// </summary>
        public BitmapImage Image { get; }

        /// <summary>
        /// Getter for PlayerArray
        /// </summary>
        public MediaPlayer[] PlayerArray { get; }
    }
}