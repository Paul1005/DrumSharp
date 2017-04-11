using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;
using DrumSharp.Notes;

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
            Beat beat;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "beat|*.beat";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if ((bool)openFileDialog.ShowDialog())
            {
                try
                {
                    beat = Beat.loadFromFile(openFileDialog.FileName);
                    Switcher.Switch(new Game(beat));
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File not found");
                }
                catch (IOException)
                {
                    Console.WriteLine("Invalid IO");
                }
            }
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Settings());
        }

        private void makeBeat_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MakeBeat());
        }
    }
}
