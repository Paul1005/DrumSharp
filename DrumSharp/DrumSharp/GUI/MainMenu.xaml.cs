using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DrumSharp
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>C:\Users\Connor\Documents\BCIT\Term_3\COMP3951_TechPro\DrumSharp\DrumSharp\DrumSharp\MainMenu.xaml
    public partial class MainMenu : UserControl, ISwitchable
    {
        public MainMenu()
        {
            InitializeComponent();
            if (Keybinds.keyMap == null)
            {
                Keybinds.init();
            }
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void Play_Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainWindow());
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Settings());
        }
    }
}
