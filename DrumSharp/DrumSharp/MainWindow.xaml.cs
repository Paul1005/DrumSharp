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
    public partial class MainWindow : UserControl, ISwitchable
    {
        
        //Player for game
        private Player player;
        //used for measuring elapsed time during the game loop.
        private Stopwatch watch;

        //This holds the different musical notes seen in game.
        private Beat beat;

        //Will hold the various notes with there respective keys

        //Holds ellipses corrisponding to specific notes.
        private Dictionary<Note, Ellipse> ellipses;
        DispatcherTimer timer = new DispatcherTimer();

        private Ellipse ellipse;
        //The 3 current instruments we have
        Snare snare;
        Bass bass;
        HighHat highHat;
        
        
    
        /// <summary>
        /// <para/>Purpose: Creates the window and loads the game
        /// <para/>Input: none
        /// <para/>Output: none
        /// <para/>Author: Connor Goudie, Paul McCarlie
        /// <para/>Date: March 9, 2017
        /// <para/>Updated by: Connor Goudie, Paul McCarlie
        /// <para/>Date: March 20, 2017
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Focusable = true;
            Focus();
            //BringToFront();
            ellipses = new Dictionary<Note, Ellipse>();
            
            //Initializes player's score to zero
            player = new Player()
            {
                Score = 0
            };
            DataContext = player;

            
            
            
            //Each instrument is then mapped to 2 keys
            

            beat = Beat.loadFromFile("hello");
            //beat.saveToFile();

            watch = new Stopwatch();

            //This timer is used to create the gameloop

            //This calls the gameTick method on every Tick of the timer
            timer.Tick += new EventHandler(gameTick);

            watch.Start();
            timer.Interval = new TimeSpan(10000);
            timer.Start();
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
                    if (notes[i].moveDown())
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
        
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            foreach (Pair<Key, Drum> k in Keybinds.keyMap) {
                if (!e.IsRepeat && k.First == e.Key)
                {
                    k.Second.playSound();

                    if (e.Key == Key.C || e.Key == Key.Space)
                    {
                        hitNote(beat.BassNotes, "Bass");
                    }
                    else if (e.Key == Key.G || e.Key == Key.H)
                    {
                        hitNote(beat.SnareNotes, "Snare");
                    }
                    else if (e.Key == Key.A || e.Key == Key.S)
                    {
                        hitNote(beat.CymbolNotes, "Cymbol");
                    }

                }
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            ellipse.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
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
        private void hitNote(List<Note> notes, String type)
        {
            int drum = -1;

            if (type.Equals("Bass"))
            {
                drum = 0;
            } else if (type.Equals("Snare"))
            {
                drum = 1;
            } else if (type.Equals("Cymbol"))
            {
                drum = 2;
            }

            ellipse = (Ellipse)canvas.Children[drum];
            //if note is within a playable range, remove it from the screen
            if (notes.Count > 0 && notes[0].Position.Y > 235 && notes[0].Position.Y < 275)
            {

                if(notes[0].Position.Y > 250 && notes[0].Position.Y < 260)
                {
                    ellipse.Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                    //Give player 2 point
                    player.Score++;
                    player.Score++;
                }
                else
                {
                    ellipse.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0));
                    //Give player a point
                    player.Score++;
                }
                canvas.Children.Remove(ellipses[notes[0]]);
                ellipses.Remove(notes[0]);
                notes.Remove(notes[0]);
            }
            else
            {
                ellipse.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                //take point away
                player.Score--;
            }
            Stopwatch colorWatch = new Stopwatch();
            colorWatch.Start();
        }

        public void UtilizeState(object state)
        {
            Switcher.Switch((UserControl)state);
        }

        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();

            //removes hanging reference (fixes massive memory leak) DO NOT CHANGE
            timer = null;
            watch = null;
            UtilizeState(new MainMenu());
        }

        public static Dictionary<Key, Drum> KeyMap{ get; set; }

    }
}
