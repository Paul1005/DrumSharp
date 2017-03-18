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
        //Note[] snareNotes;
        //Note[] cymbolNotes;

        public Beat()
        {
            //snareNotes = new Note[10];
            bassNotes = new List<Note>();
            //cymbolNotes = new Note[10];
            long time = 0;
            for (int i = 0; i < 100; i++)
            {
                bassNotes.Add(new Note(new System.Windows.Point(25, 0), new Ellipse(), time));
                time += 1000;
            }
          /*  for (int i = 0; i < 10; i++)
            {
                snareNotes[i] = new Note(new System.Windows.Point(0, 235), new Ellipse());
            }
            for (int i = 0; i < 10; i++)
            {
                cymbolNotes[i] = new Note(new System.Windows.Point(0, 445), new Ellipse());
            }*/
        }

        public List<Note> BassNotes
        {
            get { return bassNotes; }
        }
        //public getBass
    }
}
