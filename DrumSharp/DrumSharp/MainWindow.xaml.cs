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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DrumSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point pos1 = new Point(25, 0);
        /*private Point pos2 = new Point(235, 0);
        private Point pos3 = new Point(445, 0);*/
        private Dictionary<Key, Drum> map;
        public MainWindow()
        {
            InitializeComponent();

            map = new Dictionary<Key, Drum>();

            Snare snare = new Snare(
                new Uri(@"../../Images/poop.png", UriKind.Relative),
                new Uri(@"../../sounds/snare.mp3", UriKind.Relative));

            Bass bass = new Bass(
                new Uri(@"../../Images/poop.png", UriKind.Relative),
                new Uri(@"../../sounds/kick.wav", UriKind.Relative));

            HighHat highHat = new HighHat(
                new Uri(@"../../Images/poop.png", UriKind.Relative),
                new Uri(@"../../sounds/highhat_open.mp3", UriKind.Relative));

            map.Add(Key.A, highHat);
            map.Add(Key.S, highHat);

            map.Add(Key.G, snare);
            map.Add(Key.H, snare);

            map.Add(Key.C, bass);
            map.Add(Key.Space, bass);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(gameTick);

            timer.Interval = new TimeSpan(10000);
            timer.Start();
        }

        private void gameTick(object sender, EventArgs e)
        {
            pos1.Y += 1;
            createNote(pos1);
           /* pos2.Y += 1;
            createNote(pos2);
            pos3.Y += 1;
            createNote(pos3);*/
        }

        private void createNote(Point position)
        {
            Ellipse newEllipse = new Ellipse();
            newEllipse.Fill = Brushes.Black;
            newEllipse.Width = 55;
            newEllipse.Height = 40;

            Canvas.SetTop(newEllipse, position.Y);
            Canvas.SetLeft(newEllipse, position.X);

            int count = canvas.Children.Count;
            canvas.Children.Add(newEllipse);
            if (count > 6)
            {
                canvas.Children.RemoveAt(count - 1);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (map.ContainsKey(e.Key))
            {
                map[e.Key].playSound();
            }
        }
    }
}
