using System;

namespace DrumSharp.Drums
{
    /// <summary>
    /// Snare is the class that represents a snare drum in the DrumSharp game.
    /// Although it does not have any additional functionality
    /// </summary>
    class Snare : Drum
    {
        /// <summary>
        /// <para/>Purpose: Constructor for Snare 
        /// <para/>Input: 
        ///     imageUri: filepath of the image file
        ///     soundUri: filepath of the sound file
        /// <para/>Output: none
        /// <para/>Author: Connor Goudie
        /// <para/>Date: March 14, 2017
        /// <para/>Updated by: 
        /// <para/>Date: March 20, 2017
        /// </summary>
        public Snare(Uri imageUri, Uri soundUri) : base(imageUri, soundUri) { }
    }
}
