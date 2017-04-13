using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DrumSharp.Misc
{
    /// <summary>
    /// The player class, stores the score of the player.
    /// </summary>
    public class Player : INotifyPropertyChanged
    {
        //Players current score
        private int score;
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                //Updates screen when set
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Does stuff.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(
            [CallerMemberName]string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(caller));
            }
        }
    }
}
