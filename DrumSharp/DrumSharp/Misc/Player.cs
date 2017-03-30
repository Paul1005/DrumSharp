using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DrumSharp.Misc
{
    public class Player : INotifyPropertyChanged
    {
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
                OnPropertyChanged();
            }
        }
        public static Player GetPlayer()
        {
            var player = new Player()
            {
                Score = 0
            };
            return player;
        }

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
