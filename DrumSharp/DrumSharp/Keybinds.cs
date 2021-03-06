﻿using DrumSharp.Drums;
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
        public static List<Pair<Key, Drum>> keyList;
        public static Dictionary<Key, Drum> keyMap;

        public static Snare snare;
        public static Bass bass;
        public static HighHat highHat;

        public static void init()
        {
            keyList = new List<Pair<Key, Drum>>();
            keyMap = new Dictionary<Key, Drum>();
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
            //the pairs are put in a list to easily remove/replace when rebinding
            keyList.Add(new Pair<Key, Drum>(Key.A, snare));
            keyList.Add(new Pair<Key, Drum>(Key.S, snare));
            //the pairs are put in a map to easily play the correct sound
            keyMap.Add(Key.A, snare);
            keyMap.Add(Key.S, snare);

            keyList.Add(new Pair<Key, Drum>(Key.G, highHat));
            keyList.Add(new Pair<Key, Drum>(Key.H, highHat));
            keyMap.Add(Key.G, highHat);
            keyMap.Add(Key.H, highHat);

            keyList.Add(new Pair<Key, Drum>(Key.C, bass));
            keyList.Add(new Pair<Key, Drum>(Key.Space, bass));
            keyMap.Add(Key.C, bass);
            keyMap.Add(Key.Space, bass);


        }

    }
}
