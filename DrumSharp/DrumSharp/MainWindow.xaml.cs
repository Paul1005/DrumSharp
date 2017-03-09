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
        Point pos = new Point(100, 0);
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("test");
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(gameTick);

            timer.Interval = new TimeSpan(10000);
            timer.Start();
        }

        private void gameTick(object sender, EventArgs e)
        {
            pos.Y += 1;
            createNote(pos);
        }

        private void createNote(Point position)
        {
            Ellipse newEllipse = new Ellipse();
            newEllipse.Fill = Brushes.Black;
            newEllipse.Width = 10;
            newEllipse.Height = 10;

            Canvas.SetTop(newEllipse, position.Y);
            Canvas.SetLeft(newEllipse, position.X);
            int count = canvas.Children.Count;
            canvas.Children.Add(newEllipse);
            if (count > 0)
            {
                canvas.Children.RemoveAt(count - 1);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Drum d = new Snare(new Uri(@"../../Images/poop.png", UriKind.Relative), new Uri(@"../../sounds/highhat_open.mp3", UriKind.Relative));
            d.playSound();
        }
    }
}
