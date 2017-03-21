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
        private long time;
        private bool added;

        public Note(Point position, Ellipse ellipse, long timing)
        {
            time = timing;
            this.position = position;
            this.ellipse = ellipse;
            this.ellipse.Fill = Brushes.Black;
            this.ellipse.Width = 55;
            this.ellipse.Height = 40;
        }

        public bool moveDown()
        {
            this.position.Y++;
            return position.Y < 275;
        }

        public Point Position
        {
            get { return position; }
        }
        public Ellipse Ellipse
        {
            get { return ellipse; }
        }
        public long Time
        {
            get { return time; }
        }
        public bool Added
        {
            get { return added; }
            set { added = value; }
        }
    }
}