using System.ComponentModel;
using System.Runtime.CompilerServices;
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
