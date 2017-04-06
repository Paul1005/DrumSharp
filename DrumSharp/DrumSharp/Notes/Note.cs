using System.Windows.Shapes;
using System.Windows;
using System;

namespace DrumSharp.Notes
{
    /// <summary>
    /// Note is the object that falls from the top of the screen to the bottom
    /// in the DrumSharp game. Notes that are near the bottom of the screen are 
    /// playable when the player presses the key corresponding to it.
    /// </summary>
    [Serializable()]
    class Note
    {
        //current position on the screen
        private Point position;
        //when the note should be added to the screen
        private long time;
        //if the note has been added to the screen
        private bool added;

        /// <summary>
        /// <para/>Purpose: Constructor for Note
        /// <para/>Input:
        ///     Position position: x and y position on the screen
        ///     Ellipse ellipse: ellipse that will represent the note
        ///     long time: when the note is added to the screen 
        /// <para/>Output: none
        /// <para/>Author: Connor Goudie 
        /// <para/>Date: March 16, 2017
        /// <para/>Updated by: Connor Goudie
        /// <para/>Date: March 20, 2017
        /// </summary>
        public Note(Point position, Ellipse ellipse, long time)
        {
            this.time = time;
            this.position = position;
        }

        /// <summary>
        /// <para/>Purpose: Moves the Note downwards on the screen, and 
        /// returns if the note is below the threshold to be removed from the screen
        /// <para/>Input: time - time since last update in ms.
        /// <para/>Output: none
        /// <para/>Author: Connor Goudie
        /// <para/>Date: March 16, 2017
        /// <para/>Updated by: Connor Goudie
        /// <para/>Date: March 17, 2017
        /// </summary>
        public bool moveDown(long time)
        {
            position.Y += (((double)time)/1000) * 75;
            return position.Y < 275;
        }

        /// <summary>
        /// Getter for current position
        /// </summary>
        public Point Position
        {
            get { return position; }
        }

        /// <summary>
        /// Getter for time
        /// </summary>
        public long Time
        {
            get { return time; }
        }

        /// <summary>
        /// Getter and setter for added
        /// </summary>
        public bool Added
        {
            get { return added; }
            set { added = value; }
        }
    }
}