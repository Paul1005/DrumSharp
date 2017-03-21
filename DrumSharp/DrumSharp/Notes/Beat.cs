using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace DrumSharp.Notes
{
    class Beat
    {
        private List<Note> bassNotes;
        private List<Note> snareNotes;
        private List<Note> cymbolNotes;

        public Beat()
        {
            bassNotes = new List<Note>();
            snareNotes = new List<Note>();
            cymbolNotes = new List<Note>();

            long time = 1000;
            for (int i = 0; i < 100; i++)
            {
                bassNotes.Add(new Note(new System.Windows.Point(25, 0), new Ellipse(), time));
                time += 1000;
            }
            time = 500;
            for (int i = 0; i < 100; i++)
            {
                snareNotes.Add(new Note(new System.Windows.Point(235, 0), new Ellipse(), time));
                time += 1000;
            }
            time = 1000;
            for (int i = 0; i < 200; i++)
            {
                cymbolNotes.Add(new Note(new System.Windows.Point(445, 0), new Ellipse(), time));
                time += 500;
            }
        }

        public List<Note> BassNotes
        {
            get { return bassNotes; }
        }

        public List<Note> SnareNotes
        {
            get { return snareNotes; }
        }

        public List<Note> CymbolNotes
        {
            get { return cymbolNotes; }
        }
    }
}
