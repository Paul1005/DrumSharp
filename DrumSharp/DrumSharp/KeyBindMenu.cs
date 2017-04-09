using System;
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
            boxes[4] = highHatBox1;
            boxes[5] = highHatBox2;
            string temp;
            for (int i = 0; i < boxes.Length; ++i)
            {
                temp = Keybinds.keyList[i].First.ToString();
                if (temp.Equals("Space"))
                {
                    //boxes[i].Text += " ";
                }
                else
                {
                    boxes[i].Text += temp;
                }
            }
        }

        private void textboxChanged(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            Key k = KeyInterop.KeyFromVirtualKey((int)e.KeyCode);
            for (int i = 0; i < boxes.Length; ++i)
            {
                if (textBox == boxes[i])
                {
                    if (!Keybinds.keyMap.ContainsKey(k))
                    {
                        Console.WriteLine(k);
                        Keybinds.keyMap.Add(k, Keybinds.keyList[i].Second);
                        Keybinds.keyMap.Remove(Keybinds.keyList[i].First);
                    }
                    Keybinds.keyList[i].First = k;
                }
            }
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            textbox.SelectionStart = 0;
            textbox.SelectionLength = textbox.Text.Length;
        }
    }
}
