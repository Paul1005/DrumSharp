using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Shapes;

namespace DrumSharp.Notes
{
    /// <summary>
    /// Beat is a container for the notes that can be played while the game is running.
    /// There will be a different Beat for any given level, 
    /// and said Beats will be saved/loaded to/from files.
    /// </summary>
    [Serializable()]
    public class Beat
    {
        ///Notes that can be played
        private List<Note> bassNotes;
        private List<Note> snareNotes;
        private List<Note> cymbolNotes;

        /// <summary>
        /// <para/>Purpose: Constructor for Beat
        /// <para/>Input: none
        /// <para/>Output: none
        /// <para/>Author: Connor Goudie
        /// <para/>Date: March 17, 2017
        /// <para/>Updated by: Connor Goudie
        /// <para/>Date: March 20, 2017
        /// </summary>
        public Beat()
        {
            bassNotes = new List<Note>();
            snareNotes = new List<Note>();
            cymbolNotes = new List<Note>();

            /*NOTE: this code is primarily for esting purpose

            //base time a note can be played (in milliseconds)
            long time = 0;

            //populates bassNotes with 100 notes, playable at 1 second intervals
            for (int i = 0; i < 100; i++)
            {
                bassNotes.Add(new Note(new System.Windows.Point(25, 0), new Ellipse(), time));
                time += 1000;
            }
            
            //offset when the notes are playable by half a second
            time = 500;

            //populates snareNotes with 100 notes, playable at 1 second intervals
            for (int i = 0; i < 100; i++)
            {
                snareNotes.Add(new Note(new System.Windows.Point(235, 0), new Ellipse(), time));
                time += 1000;
            }

            //reset time to base time
            time = 0;

            //populates cymbolNotes with 200 notes, playable at .5 second intervals
            for (int i = 0; i < 200; i++)
            {
                cymbolNotes.Add(new Note(new System.Windows.Point(445, 0), new Ellipse(), time));
                time += 500;
            }*/
        }

        /// <summary>
        /// <para/>Purpose: Saves the Beat to a file
        /// <para/>Input: none
        /// <para/>Output: none
        /// <para/>Author: Andrew Busto
        /// <para/>Date: March 20, 2017
        /// </summary>
        public void saveToFile()
        {
            IFormatter formatter = new BinaryFormatter();

            Stream stream = new FileStream("hello", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        /// <summary>
        /// <para/>Purpose: Loads a beat from a file.
        /// <para/>Input: none
        /// <para/>Output: The Beat loaded.
        /// <para/>Author: Andrew Busto
        /// <para/>Date: April 04, 2017
        /// </summary>
        public static Beat loadFromFile(String filename)
        {
            IFormatter formatter = new BinaryFormatter();
            Beat output;

            Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
            output = (Beat) formatter.Deserialize(stream);
            stream.Close();

            return output;
        }

        /// <summary>
        /// Getter for bassNotes
        /// </summary>
        public List<Note> BassNotes
        {
            get { return bassNotes; }
        }

        /// <summary>
        /// Getter for snareNotes
        /// </summary>
        public List<Note> SnareNotes
        {
            get { return snareNotes; }
        }

        /// <summary>
        /// Getter for cymbolNotes
        /// </summary>
        public List<Note> CymbolNotes
        {
            get { return cymbolNotes; }
        }
    }
}
