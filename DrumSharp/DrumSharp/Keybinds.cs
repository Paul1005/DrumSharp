using DrumSharp.Drums;
using DrumSharp.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DrumSharp
{
    public static class Keybinds
    {
        public static List<Pair<Key, Drum>> keyMap;

        public static Snare snare;
        public static Bass bass;
        public static HighHat highHat;

        public static void init()
        {
            keyMap = new List<Pair<Key, Drum>>();
            //The 3 instruments are instatiated using their image file and sound file.
            snare = new Snare(
                new Uri(@"../../Images/poop.png", UriKind.Relative),
                new Uri(@"../../sounds/snare.mp3", UriKind.Relative));

            bass = new Bass(
                new Uri(@"../../Images/poop.png", UriKind.Relative),
                new Uri(@"../../sounds/kick.wav", UriKind.Relative));

            highHat = new HighHat(
                new Uri(@"../../Images/poop.png", UriKind.Relative),
                new Uri(@"../../sounds/highhat_open.mp3", UriKind.Relative));

            //Each instrument is then mapped to 2 keys
            keyMap.Add(new Pair<Key, Drum>(Key.A, snare));
            keyMap.Add(new Pair<Key, Drum>(Key.S, snare));

            keyMap.Add(new Pair<Key, Drum>(Key.G, highHat));
            keyMap.Add(new Pair<Key, Drum>(Key.H, highHat));

            keyMap.Add(new Pair<Key, Drum>(Key.C, bass));
            keyMap.Add(new Pair<Key, Drum>(Key.Space, bass));
        }

    }
}
