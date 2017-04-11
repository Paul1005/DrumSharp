using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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
        private List<Note> highHatNotes;

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
            highHatNotes = new List<Note>();
        }

        /// <summary>
        /// <para/>Purpose: Saves the Beat to a file
        /// <para/>Input: none
        /// <para/>Output: none
        /// <para/>Author: Andrew Busto
        /// <para/>Date: March 20, 2017
        /// </summary>
        public void saveToFile(String name)
        {
            IFormatter formatter = new BinaryFormatter();

            Stream stream = new FileStream(name, FileMode.Create, FileAccess.Write, FileShare.None);
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
        /// Getter for highHatNotes
        /// </summary>
        public List<Note> HighHatNotes
        {
            get { return highHatNotes; }
        }
    }
}
