using DrumSharp.Drums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace DrumSharp
{
    public partial class KeyBindMenu : Form
    {
        public KeyBindMenu()
        {
            InitializeComponent();
        }

        private void snareBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.TextLength > 0)
            {
                char c = textBox.Text[0];
                Key key = (Key)Enum.Parse(typeof(Key), c.ToString(), ignoreCase: true);
                Console.WriteLine(key);
                Keybinds.keyMap[0].First = key; 
            }
        }
    }
}
