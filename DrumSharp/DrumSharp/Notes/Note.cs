using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;
using System;

namespace DrumSharp.Notes
{
    class Note
    {
        private Point position;
        private Ellipse ellipse;

        public Note(Point position, Ellipse ellipse)
        {
            Console.WriteLine(position.X + " " + position.Y);
            this.position = position;
            this.ellipse = ellipse;
            this.ellipse.Fill = Brushes.Black;
            this.ellipse.Width = 10;
            this.ellipse.Height = 10;
        }

        public bool moveDown()
        {
            this.position.Y++;
            return position.Y > 350;
        }

        public Point Position
        {
            get { return position; }
        }
        public Ellipse Ellipse
        {
            get { return ellipse; }
        }

    }
}