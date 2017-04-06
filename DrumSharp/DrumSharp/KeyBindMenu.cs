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
        TextBox[] boxes;
        public KeyBindMenu()
        {
            InitializeComponent();
            boxes = new TextBox[6];
            boxes[0] = snareBox1;
            boxes[1] = snareBox2;
            boxes[2] = bassBox1;
            boxes[3] = bassBox2;
            boxes[4] = cymbolBox1;
            boxes[5] = cymbolBox2;
        }
        
        private void textboxChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            string propertyName = textBox.Name;
            for (int i = 0; i < boxes.Length; ++i)
            {
                if (textBox == boxes[i] && textBox.TextLength > 0)
                {
                    char c = textBox.Text[0];
                    Key key = (Key)Enum.Parse(typeof(Key), c.ToString(), ignoreCase: true);
                    Keybinds.keyMap[i].First = key;
                }
            }
        }
    }
}
