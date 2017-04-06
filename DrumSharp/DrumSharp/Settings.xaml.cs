using DrumSharp.Drums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrumSharp
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : System.Windows.Controls.UserControl, ISwitchable
    {
        public Settings()
        {
            InitializeComponent();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }

        private void change_keybinds_Click(object sender, RoutedEventArgs e)
        {
            KeyBindMenu menu = new KeyBindMenu();
            menu.Show();
            if (menu.DialogResult == DialogResult.OK)
            {
                //The 3 instruments are instatiated using their image file and sound file.
                /*Snare snare = new Snare(
                    new Uri(@"../../Images/poop.png", UriKind.Relative),
                    new Uri(@"../../sounds/snare.mp3", UriKind.Relative));

                Bass bass = new Bass(
                    new Uri(@"../../Images/poop.png", UriKind.Relative),
                    new Uri(@"../../sounds/kick.wav", UriKind.Relative));

                HighHat highHat = new HighHat(
                    new Uri(@"../../Images/poop.png", UriKind.Relative),
                    new Uri(@"../../sounds/highhat_open.mp3", UriKind.Relative));
                */
                //MainWindow.KeyMap = new Dictionary<Key, Drum>();
                //MainWindow.KeyMap.Add(key, snare);
                menu.Close();
                menu = null;
                Console.WriteLine("AYY YO WUDDUP");
            }
        }
    }
}
