using DrumSharp.Drums;
using DrumSharp.Notes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

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

        //Will hold the varies notes with there respective keys
        private Dictionary<Key, Drum> map;

        //The 3 current instruments we have
        Snare snare;
        Bass bass;
        HighHat highHat;

        // <summary>
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

            map = new Dictionary<Key, Drum>();
            
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
            map.Add(Key.A, highHat);
            map.Add(Key.S, highHat);

            map.Add(Key.G, snare);
            map.Add(Key.H, snare);

            map.Add(Key.C, bass);
            map.Add(Key.Space, bass);

            beat = new Beat();

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
            addNewNotes();
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
        private void addNewNotes()
        {
            //Adds bass notes to the screen
            foreach (Note n in beat.BassNotes)
            {
                if (!n.Added && watch.ElapsedMilliseconds > n.Time)
                {
                    canvas.Children.Add(n.Ellipse);
                    n.Added = true;
                    break;
                }
            }
            //Adds snare notes to the screen
            foreach (Note n in beat.SnareNotes)
            {
                if (!n.Added && watch.ElapsedMilliseconds > n.Time)
                {
                    canvas.Children.Add(n.Ellipse);
                    n.Added = true;
                    break;
                }
            }
            // adds cymbol notes to the screen
            foreach (Note n in beat.CymbolNotes)
            {
                if (!n.Added && watch.ElapsedMilliseconds > n.Time)
                {
                    canvas.Children.Add(n.Ellipse);
                    n.Added = true;
                    break;
                }
            }
        }

        /// <summary>
        /// <para/>Purpose: Iterates through the beat and moves notes held by it down the
        /// screen if they are currently displayed.
        /// <para/>Input: none
        /// <para/>Output: none
        /// <para/>Author: Connor Goudie
        /// <para/>Date: March 17, 2017
        /// <para/>Updated by: Connor Goudie
        /// <para/>Date: March 20, 2017
        /// </summary>
        private void update()
        {
            //moves bass notes on the screen down
            for (int i = 0; i < beat.BassNotes.Count; i++)
            {
                if (beat.BassNotes[i].Added)
                {
                    if (beat.BassNotes[i].moveDown())
                    {
                        Canvas.SetTop(beat.BassNotes[i].Ellipse, beat.BassNotes[i].Position.Y);
                        Canvas.SetLeft(beat.BassNotes[i].Ellipse, beat.BassNotes[i].Position.X);
                    }
                    //removes the note from the screen if it is below the threshold
                    else
                    {
                        canvas.Children.Remove(beat.BassNotes[i].Ellipse);
                        beat.BassNotes.Remove(beat.BassNotes[i]);
                        i--;
                        break;
                    }
                }
            }
            //moves snare notes on the screen down
            for (int i = 0; i < beat.SnareNotes.Count; i++)
            {
                if (beat.SnareNotes[i].Added)
                {
                    if (beat.SnareNotes[i].moveDown())
                    {
                        Canvas.SetTop(beat.SnareNotes[i].Ellipse, beat.SnareNotes[i].Position.Y);
                        Canvas.SetLeft(beat.SnareNotes[i].Ellipse, beat.SnareNotes[i].Position.X);
                    }
                    //removes the note from the screen if it is below the threshold
                    else
                    {
                        canvas.Children.Remove(beat.SnareNotes[i].Ellipse);
                        beat.SnareNotes.Remove(beat.SnareNotes[i]);
                        i--;
                        break;
                    }
                }
            }
            //moves cymbol notes on the screen down
            for (int i = 0; i < beat.CymbolNotes.Count; i++)
            {
                if (beat.CymbolNotes[i].Added)
                {
                    if (beat.CymbolNotes[i].moveDown())
                    {
                        Canvas.SetTop(beat.CymbolNotes[i].Ellipse, beat.CymbolNotes[i].Position.Y);
                        Canvas.SetLeft(beat.CymbolNotes[i].Ellipse, beat.CymbolNotes[i].Position.X);
                    }
                    //removes the note from the screen if it is below the threshold
                    else
                    {
                        canvas.Children.Remove(beat.CymbolNotes[i].Ellipse);
                        beat.CymbolNotes.Remove(beat.CymbolNotes[i]);
                        i--;
                    }
                }
            }
            //refreshes the screen
            canvas.UpdateLayout();
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
            if (!e.IsRepeat && map.ContainsKey(e.Key))
            {
                map[e.Key].playSound();

                if (e.Key == Key.C || e.Key == Key.Space)
                {
                    //if note is within a playable range, remove it from the screen
                    if (beat.BassNotes.Count > 0 && beat.BassNotes[0].Position.Y > 235 &&
                        beat.BassNotes[0].Position.Y < 275)
                    {
                        canvas.Children.Remove(beat.BassNotes[0].Ellipse);
                        beat.BassNotes.Remove(beat.BassNotes[0]);
                    }
                }
                else if (e.Key == Key.G || e.Key == Key.H)
                {
                    //if note is within a playable range, remove it from the screen
                    if (beat.SnareNotes.Count > 0 && beat.SnareNotes[0].Position.Y > 235 && 
                        beat.SnareNotes[0].Position.Y < 275)
                    {
                        canvas.Children.Remove(beat.SnareNotes[0].Ellipse);
                        beat.SnareNotes.Remove(beat.SnareNotes[0]);
                    }
                }
                else if (e.Key == Key.A || e.Key == Key.S)
                {
                    //if note is within a playable range, remove it from the screen
                    if (beat.CymbolNotes.Count > 0 && beat.CymbolNotes[0].Position.Y > 235 && 
                        beat.CymbolNotes[0].Position.Y < 275)
                    { 
                        canvas.Children.Remove(beat.CymbolNotes[0].Ellipse);
                        beat.CymbolNotes.Remove(beat.CymbolNotes[0]);
                    }
                }

            }
        }
    }
}
