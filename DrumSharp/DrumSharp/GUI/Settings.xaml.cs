using System;
using System.Windows;
using System.Windows.Forms;

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
            if (menu.ShowDialog() == DialogResult.OK)
            {
                menu.Close();
                menu = null;
                Console.WriteLine("AYY YO WUDDUP");
            }
        }
    }
}
