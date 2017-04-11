using DrumSharp.Drums;
using DrumSharp.Misc;
using DrumSharp.Notes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media;

namespace DrumSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Game : UserControl, ISwitchable
    {
        private bool isPaused;
        //Player for game
        private Player player;
        //used for measuring elapsed time during the game loop.
        private Stopwatch watch;

        //This holds the different musical notes seen in game.
        private Beat beat;

        //Holds ellipses corrisponding to specific notes.
        private Dictionary<Note, Ellipse> ellipses;
        DispatcherTimer timer = new DispatcherTimer();

        long curtime, prevtime;

        /// <summary>
        /// <para/>Purpose: Creates the window and loads the game
        /// <para/>Input: none
        /// <para/>Output: none
        /// <para/>Author: Connor Goudie, Paul McCarlie
        /// <para/>Date: March 9, 2017
        /// <para/>Updated by: Connor Goudie, Paul McCarlie
        /// <para/>Date: March 20, 2017
        /// </summary>
        public Game(Beat beat)
        {
            InitializeComponent();

            this.beat = beat;

            //sets up pause logic; sets pause state to false and programmatically creates the pause button. 
            isPaused = false;

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

            //Initializes player's score to zero
            player = new Player()
            {
                Score = 0
            };
            DataContext = player;

            watch = new Stopwatch();

            //This timer is used to create the gameloop

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
            //checks if a new note can be added and adds it to the gamescreen
            addNewNotes(beat.BassNotes);
            addNewNotes(beat.SnareNotes);
            addNewNotes(beat.CymbolNotes);
            //updates the game's GUI
            update();
        }

        /// /// <summary>
        /// <para/>Iterates through the beat to see if any notes held can be added to 
        /// the game.
        /// <para/>Input: none
        /// <para/>Output: none
        /// <para/>Author: Connor Goudie
        /// <para/>Date: March 17, 2017
        /// <para/>Updated by: 
        /// <para/>Date: March 20, 2017
        /// </summary>
        private void addNewNotes(List<Note> notes)
        {
            //Adds notes to the screen
            foreach (Note n in notes)
            {
                if (!n.Added && watch.ElapsedMilliseconds > n.Time)
                {
                    addNote(n);
                    break;
                }
            }
        }

        /// <summary>
        /// <para/>Purpose: Adds an ellipse to the ellipses map 
        ///                 and marks the corrisponding note as added.
        /// <para/>Input: n - the note being aded.
        /// <para/>Output: none
        /// <para/>Author: Andrew Busto
        /// <para/>Date: april 3, 2017
        /// </summary>
        private void addNote(Note n)
        {
            ellipses.Add(n, new Ellipse());
            ellipses[n].Width = 55;
            ellipses[n].Height = 40;
            ellipses[n].Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            canvas.Children.Add(ellipses[n]);
            n.Added = true;
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
            prevtime = curtime;
            curtime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            //moves bass notes on the screen down
            moveNotes(beat.BassNotes);

            //moves snare notes on the screen down
            moveNotes(beat.SnareNotes);

            //moves cymbol notes on the screen down
            moveNotes(beat.CymbolNotes);

            //refreshes the screen
            canvas.UpdateLayout();
        }

        /// <summary>
        /// <para/>Purpose: Iterates through the notes and moves them down
        /// if they are currently displayed.
        /// <para/>Input: notes - the notes to be moved/removed.
        /// <para/>Output: none
        /// <para/>Author: Andrew Busto
        /// <para/>Date: March 30, 2017
        /// </summary>
        private void moveNotes(List<Note> notes)
        {
            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].Added)
                {
                    if (notes[i].moveDown(curtime - prevtime))
                    {
                        Canvas.SetTop(ellipses[notes[i]], notes[i].Position.Y);
                        Canvas.SetLeft(ellipses[notes[i]], notes[i].Position.X);
                    }
                    //removes the note from the screen if it is below the threshold
                    else
                    {
                        canvas.Children.Remove(ellipses[notes[i]]);
                        ellipses.Remove(notes[i]);
                        notes.Remove(notes[i]);
                        i--;
                        player.Score--;
                    }
                }
            }
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
                    hitNote(beat.SnareNotes, Keybinds.keyMap[e.Key]);
                }
                else if (e.Key == Keybinds.keyList[2].First || e.Key == Keybinds.keyList[3].First)
                {
                    hitNote(beat.CymbolNotes, Keybinds.keyMap[e.Key]);
                }
                else if (e.Key == Keybinds.keyList[4].First || e.Key == Keybinds.keyList[5].First)
                {
                    hitNote(beat.BassNotes, Keybinds.keyMap[e.Key]);
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
        /// <para/>Author: Connor Goudie/Andrew Busto
        /// <para/>Date: March 30, 2017
        /// </summary>
        private void hitNote(List<Note> notes, Drum drum)
        {
            if (!isPaused)
            {
                //if note is within a playable range(within 25 units of the passing drum), and if so,
                //remove it from the screen
                if (notes.Count > 0 && notes[0].Position.Y > 585 && notes[0].Position.Y < 625)
                {
                    //checks to see if player hit note withing 5 units of the passing note
                    if (notes[0].Position.Y > 600 && notes[0].Position.Y < 610)
                    {
                        //color drum green
                        drum.ellipse.Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0));

                        //Give player 2 point
                        player.Score += 2;
                    }
                    else
                    {
                        //colors drum yellow
                        drum.ellipse.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0));
                        //Give player a point
                        player.Score++;
                    }
                    canvas.Children.Remove(ellipses[notes[0]]);
                    ellipses.Remove(notes[0]);
                    notes.Remove(notes[0]);
                }
                else
                {
                    //colors drum red
                    drum.ellipse.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));

                    //take 2 points away
                    player.Score -= 2;
                }
            }
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
        /// <para/> Returns the player to the main menue.
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
            Button pauseButton = (Button)sender;
            if (!isPaused)
            {
                timer.Stop();
                watch.Stop();
                pauseButton.Content = "Unpause";
            } else if (isPaused)
            {
                prevtime = curtime;
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
