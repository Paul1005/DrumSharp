using DrumSharp.Drums;
using DrumSharp.Notes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace DrumSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stopwatch watch;
        private long startTime;
        private Beat beat;
        //private Note testNote;
        private Point pos1 = new Point(25, 0);
        /*private Point pos2 = new Point(235, 0);
        private Point pos3 = new Point(445, 0);*/
        private Dictionary<Key, Drum> map;
        Snare snare;
        Bass bass;
        HighHat highHat;

        public MainWindow()
        {
            InitializeComponent();

            map = new Dictionary<Key, Drum>();

            snare = new Snare(
                new Uri(@"../../Images/poop.png", UriKind.Relative),
                new Uri(@"../../sounds/snare.mp3", UriKind.Relative));

            bass = new Bass(
                new Uri(@"../../Images/poop.png", UriKind.Relative),
                new Uri(@"../../sounds/kick.wav", UriKind.Relative));

            highHat = new HighHat(
                new Uri(@"../../Images/poop.png", UriKind.Relative),
                new Uri(@"../../sounds/highhat_open.mp3", UriKind.Relative));

            map.Add(Key.A, highHat);
            map.Add(Key.S, highHat);

            map.Add(Key.G, snare);
            map.Add(Key.H, snare);

            map.Add(Key.C, bass);
            map.Add(Key.Space, bass);

            beat = new Beat();
            //testNote = new Note(pos1, new Ellipse());
            //Canvas.SetLeft(testNote.Ellipse, testNote.Position.X);

            watch = new Stopwatch();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(gameTick);

            watch.Start();
            timer.Interval = new TimeSpan(10000);
            timer.Start();
        }

        private void gameTick(object sender, EventArgs e)
        {
            //checks if a new note can be added and adds it to the gamescreen
            addNewNotes();
            //updates the game's GUI
            update();
        }

        private void addNewNotes()
        {
            foreach (Note n in beat.BassNotes)
            {
                if (!n.Added && watch.ElapsedMilliseconds - startTime > n.Time)
                {
                    canvas.Children.Add(n.Ellipse);
                    n.Added = true;
                    break;
                }

            }
        }

        private void update()
        {
            for (int i = 0; i < beat.BassNotes.Count; i++)
            {
                if (beat.BassNotes[i].Added)
                {
                    if (beat.BassNotes[i].moveDown())
                    {
                        Canvas.SetTop(beat.BassNotes[i].Ellipse, beat.BassNotes[i].Position.Y);
                        Canvas.SetLeft(beat.BassNotes[i].Ellipse, beat.BassNotes[i].Position.X);
                    }
                    else
                    {
                        canvas.Children.Remove(beat.BassNotes[i].Ellipse);
                        beat.BassNotes.Remove(beat.BassNotes[i]);
                        i--;
                    }
                }
            }
            canvas.UpdateLayout();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (map.ContainsKey(e.Key))
            {
                map[e.Key].playSound();
                if (e.Key == Key.C || e.Key == Key.Space)
                {
                    if (beat.BassNotes.Count > 0 && beat.BassNotes[0].Position.Y > 200)
                    {
                        canvas.Children.Remove(beat.BassNotes[0].Ellipse);
                        beat.BassNotes.Remove(beat.BassNotes[0]);
                    }
                }
                else if (e.Key == Key.A || e.Key == Key.S)
                {
                }
                else if (e.Key == Key.G || e.Key == Key.H)
                {
                }
            }
        }
    }
}
