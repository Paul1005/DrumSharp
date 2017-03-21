using System;

namespace DrumSharp.Drums
{
    /// <summary>
    /// HighHat is the class that represents a highhat drum in the DrumSharp game.
    /// Although it does not have any additional functionality
    /// </summary>
    class HighHat : Drum
    {
        /// <summary>
        /// <para/>Purpose: Constructor for HighHat 
        /// <para/>Input: 
        ///     imageUri: filepath of the image file
        ///     soundUri: filepath of the sound file
        /// <para/>Output: none
        /// <para/>Author: Connor Goudie
        /// <para/>Date: March 14, 2017
        /// <para/>Updated by: 
        /// <para/>Date: March 20, 2017
        /// </summary>
        public HighHat(Uri imageUri, Uri soundUri) : base(imageUri, soundUri) { }
    }
}
