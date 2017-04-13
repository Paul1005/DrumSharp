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

        /// <summary>
        /// <para/> saves the beat and returns the user to the main menu.
        /// <para/>Input:   object state - unused
        /// <para/>Output: none
        /// <para/>Author: Andrew Busto
        /// <para/>Date: April 09, 2017
        /// </summary>
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// <para/> saves the beat and returns the user to the main menu.
        /// <para/>Input:  object sender - the object which sent the command.  Unused.
        ///                RountedEventArgs e - unused.
        /// <para/>Output: none
        /// <para/>Author: Andrew Busto
        /// <para/>Date: April 09, 2017
        /// </summary>
        private void back_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }

        /// <summary>
        /// <para/> saves the beat and returns the user to the main menu.
        /// <para/>Input:   object sender - the object which sent the command.  Unused.
        ///                 RountedEventArgs e - unused.
        /// <para/>Output: none
        /// <para/>Author: Andrew Busto
        /// <para/>Date: April 09, 2017
        /// </summary>
        private void change_keybinds_Click(object sender, RoutedEventArgs e)
        {
            KeyBindMenu menu = new KeyBindMenu();
            if (menu.ShowDialog() == DialogResult.OK)
            {
                menu.Close();
                menu = null;
            }
        }
    }
}
