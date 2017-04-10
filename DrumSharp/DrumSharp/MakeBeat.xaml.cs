using DrumSharp.Drums;
using DrumSharp.Misc;
using DrumSharp.Notes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DrumSharp
{
    /// <summary>
    /// Interaction logic for MakeBeat.xaml
    /// </summary>
    public partial class MakeBeat : UserControl
    {

        private bool isPaused;
        //used for measuring elapsed time during the game loop.
        private Stopwatch watch;

        //This holds the different musical notes seen in game.
        private Beat beat;

        //Holds ellipses corrisponding to specific notes.
        private Dictionary<Note, Ellipse> ellipses;
        DispatcherTimer timer = new DispatcherTimer();

        long curtime, starttime;

        private Button pauseButton;

        /// <summary>
        /// <para/>Purpose: Creates the window and loads the game
        /// <para/>Input: none
        /// <para/>Output: none
        /// <para/>Author: Connor Goudie, Paul McCarlie
        /// <para/>Date: March 9, 2017
        /// <para/>Updated by: Connor Goudie, Paul McCarlie
        /// <para/>Date: March 20, 2017
        /// </summary>
        public MakeBeat()
        {
            InitializeComponent();

            //sets up pause logic; sets pause state to false and programmatically creates the pause button. 
            isPaused = false;
            pauseButton = new Button();
            pauseButton.Width = 50;
            pauseButton.Height = 20;
            pauseButton.Content = "Pause";
            pauseButton.Click += new RoutedEventHandler(pauseButton_Click);
            
            //adds pause button to the canvas
            canvas.Children.Add(pauseButton);
            Canvas.SetTop(pauseButton, 10);
            Canvas.SetLeft(pauseButton, 85);

            //Adds the 3 drum ellipses to the canvas.
            canvas.Children.Add(Keybinds.bass.ellipse);
            Canvas.SetTop(Keybinds.bass.ellipse, 605);
            Canvas.SetLeft(Keybinds.bass.ellipse, 25);

            canvas.Children.Add(Keybinds.snare.ellipse);
            Canvas.SetTop(Keybinds.snare.ellipse, 605);
            Canvas.SetLeft(Keybinds.snare.ellipse, 235);

            canvas.Children.Add(Keybinds.highHat.ellipse);
            Canvas.SetTop(Keybinds.highHat.ellipse, 605);
            Canvas.SetLeft(Keybinds.highHat.ellipse, 445);

            //allows keypresses to be registered
            Focusable = true;
            Focus();

            ellipses = new Dictionary<Note, Ellipse>();

            starttime = curtime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            beat = new Beat();

            watch = new Stopwatch();
            //This calls the gameTick method on every Tick of the timer
            timer.Tick += new EventHandler(gameTick);

            watch.Start();
            timer.Interval = new TimeSpan(10000);
            timer.Start();

            curtime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }



        /// <summary>
        /// <para/>Purpose: This method is called on every Tick of the dispatchTimer, it updates the 
        /// position of current notes and adds new ones when required.
        /// <para/>Input: 
        ///     object sender: object calling this method
        ///     EventArgs e: event arguments recieved from caller
        /// <para/>Output: none
        /// <para/>Author: 
        /// <para/>Date: March 20, 2017
        /// <para/>Updated by: 
        /// <para/>Date: March 20, 2017
        /// </summary>
        private void gameTick(object sender, EventArgs e)
        {
            //updates the game's GUI
            update();
        }

        /// <summary>
        /// <para/>Purpose: Iterates through the beat and moves notes held by it down the
        /// screen if they are currently displayed.
        /// <para/>Input: none
        /// <para/>Output: none
        /// <para/>Author: Connor Goudie
        /// <para/>Date: March 17, 2017
        /// <para/>Updated by: Andrew Busto
        /// <para/>Date: March 30, 2017
        /// </summary>
        private void update()
        {
            curtime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            //refreshes the screen
            canvas.UpdateLayout();
        }

        /// <summary>
        /// <para/> When user presses a key during gameplay, this method checks which key is pressed
        ///         to see if it matches the mapped keys to any of the instruments, and plays them if so.
        /// <para/>Input: none
        /// <para/>Output: none
        /// <para/>Author: Connor Goudie
        /// <para/>Date: March 15, 2017
        /// <para/>Updated by: Andrew Busto
        /// <para/>Date: March 30, 2017
        /// </summary>
        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.IsRepeat && Keybinds.keyMap.ContainsKey(e.Key))
            {
                Keybinds.keyMap[e.Key].playSound();

                if (e.Key == Keybinds.keyList[0].First || e.Key == Keybinds.keyList[1].First)
                {
                    hitNote(beat.SnareNotes, Keybinds.keyMap[e.Key], 235);
                }
                else if (e.Key == Keybinds.keyList[2].First || e.Key == Keybinds.keyList[3].First)
                {
                    hitNote(beat.CymbolNotes, Keybinds.keyMap[e.Key], 445);
                }
                else if (e.Key == Keybinds.keyList[4].First || e.Key == Keybinds.keyList[5].First)
                {
                    hitNote(beat.BassNotes, Keybinds.keyMap[e.Key], 25);
                }
            }

        }

        /// <summary>
        /// <para/> Resets the color of a the drum corresponding to the key being released to back to white.
        /// <para/>Input: none
        /// <para/>Output: none
        /// <para/>Author: Paul McCarlie
        /// <para/>Date: April 08, 2017
        /// </summary>
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (Keybinds.keyMap.ContainsKey(e.Key))
            {
                Keybinds.keyMap[e.Key].ellipse.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
        }

        /// <summary>
        /// <para/> Plays a specified Drum.  Increments/decrements score based on
        ///         whether the drum was played correctly.  Removes the corrisponding
        ///         ellipse from the screen if the drum was played correctly.
        /// <para/>Input: none
        /// <para/>Output: none
        /// <para/>Author: Andrew Busto
        /// <para/>Date: March 30, 2017
        /// </summary>
        private void hitNote(List<Note> notes, Drum drum, int pos)
        {
            //color drum green
            drum.ellipse.Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            notes.Add(new Note(new Point(pos, 0), new Ellipse(), curtime - starttime));
        }

        /// <summary>
        /// <para/> Will switch the screen to whatever is passed in.
        /// <para/>Input: none
        /// <para/>Output: none
        /// <para/>Author: Connor Goudie
        /// <para/>Date: March 30, 2017
        /// </summary>
        public void UtilizeState(object state)
        {
            Switcher.Switch((UserControl)state);
        }

        /// <summary>
        /// <para/> Returns the user to the main menue.
        /// <para/>Input: none
        /// <para/>Output: none
        /// <para/>Author: Connor Goudie
        /// <para/>Date: April 08, 2017
        /// </summary>
        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            //children removed so game doesn't crash on next startup
            canvas.Children.Remove(Keybinds.bass.ellipse);
            canvas.Children.Remove(Keybinds.snare.ellipse);
            canvas.Children.Remove(Keybinds.highHat.ellipse);

            beat.saveToFile();

            UtilizeState(new MainMenu());
        }

        /// <summary>
        /// <para/> Will pause/unpause the game by stopping the timer and watch as well as reset the curtime.
        /// <para/>Input: none
        /// <para/>Output: none
        /// <para/>Author: Paul McCarlie
        /// <para/>Date: April 08, 2017
        /// </summary>
        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isPaused)
            {
                timer.Stop();
                watch.Stop();
                pauseButton.Content = "Unpause";
            }
            else if (isPaused)
            {
                curtime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                timer.Start();
                watch.Start();
                pauseButton.Content = "Pause";
            }
            isPaused = !isPaused;
        }

        public static Dictionary<Key, Drum> KeyMap { get; set; }

    }
}
