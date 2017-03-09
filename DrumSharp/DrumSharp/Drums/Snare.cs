using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DrumSharp.Drums
{
    class Snare : Drum
    {

        private static Key binding1 = Key.A;
        private static Key binding2 = Key.S;

        public Snare(Uri imageUri, Uri soundUri) : base(imageUri, soundUri)
        {

        }

        public static Key Binding1 { get; set; }
        public static Key Binding2 { get; set; }
    }
}
