using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalmanAttila_3DHistech_homework.Model
{
    public class Motor
    {
        public event EventHandler<EventArgs> PositionChanged;
        private double position;
        public double Position
        {
            get { return position; }
            set
            {
                if (position != value)
                {
                    position = value;
                    PositionChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        private double stepSize;
        public double Speed { get; set; }

        public Motor(double stepSize)
        {
            Position = 0.0;
            this.stepSize = stepSize;
            Speed = 1.0;
        }

        public void MovePositive()
        {
            Position += stepSize;

            if (Position >= 360)
            {
                Position -= 360;
            }
        }

        public void MoveNegative()
        {
            Position -= stepSize;

            if (Position < 0)
            {
                Position += 360;
            }
        }
    }
}
