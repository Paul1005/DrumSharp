using DrumSharp.Drums;
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
    public partial class MainWindow : Window
    {
        //used for measuring elapsed time during the game loop.
        private Stopwatch watch;

        //This holds the different musical notes seen in game.
        private Beat beat;

        //Will hold the various notes with there respective keys
        private Dictionary<Key, Drum> keyMap;

        //Holds ellipses corrisponding to specific notes.
        private Dictionary<Note, Ellipse> ellipses;

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

            ellipses = new Dictionary<Note, Ellipse>();
            keyMap = new Dictionary<Key, Drum>();
            
            //The 3 instruments are instatiated using their image file and sound file.
            snare = new Snare(
                new Uri(@"../../Images/poop.png", UriKind.Relative),
                new Uri(@"../../sounds/snare.mp3", UriKind.Relative));

            bass = new Bass(
                new Uri(@"../../Images/poop.png", UriKind.Relative),
                new Uri(@"../../sounds/kick.wav", UriKind.Relative));

            highHat = new HighHat(
                new Uri(@"../../Images/poop.png", UriKind.Relative),
                new Uri(@"../../sounds/highhat_open.mp3", UriKind.Relative));
            
            //Each instrument is then mapped to 2 keys
            keyMap.Add(Key.A, highHat);
            keyMap.Add(Key.S, highHat);

            keyMap.Add(Key.G, snare);
            keyMap.Add(Key.H, snare);

            keyMap.Add(Key.C, bass);
            keyMap.Add(Key.Space, bass);

            beat = new Beat();
            beat.save();

            watch = new Stopwatch();

            //This timer is used to create the gameloop
            DispatcherTimer timer = new DispatcherTimer();

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
                    }
                }
            }
        }
        
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <summary>
        /// <para/>When user presses a key during gameplay, this method checks which key is pressed
        /// to see if it matches the mapped keys to any of the instruments, and plays them if so.
        /// <para/>Input: none
        /// <para/>Output: none
        /// <para/>Author: Connor Goudie
        /// <para/>Date: March 15, 2017
        /// <para/>Updated by: Connor Goudie
        /// <para/>Date: March 20, 2017
        /// </summary>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.IsRepeat && keyMap.ContainsKey(e.Key))
            {
                keyMap[e.Key].playSound();

                if (e.Key == Key.C || e.Key == Key.Space)
                {
                    hitNote(beat.BassNotes);
                }
                else if (e.Key == Key.G || e.Key == Key.H)
                {
                    hitNote(beat.SnareNotes);
                }
                else if (e.Key == Key.A || e.Key == Key.S)
                {
                    hitNote(beat.CymbolNotes);
                }

            }
        }

        private void hitNote(List<Note> notes)
        {
            //if note is within a playable range, remove it from the screen
            if (notes.Count > 0 && notes[0].Position.Y > 235 &&
                        notes[0].Position.Y < 275)
            {
                canvas.Children.Remove(ellipses[notes[0]]);
                ellipses.Remove(notes[0]);
                notes.Remove(notes[0]);
            }
        }
    }
}
