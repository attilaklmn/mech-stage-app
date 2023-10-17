using KalmanAttila_3DHistech_homework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Shapes;
using System.Security.Policy;
using System.Windows.Media;

namespace KalmanAttila_3DHistech_homework.Controller
{
    public class MoveController
    {
        public Motor MotorX { get; }
        public Motor MotorY { get; }
        public Motor MotorZ { get; }
        private readonly Rectangle slide;
        private readonly Canvas canvas;
        ScaleTransform ScaleTransform { get; set; }
        public MoveController(Motor motorX, Motor motorY, Motor motorZ, Rectangle targylemez, Canvas canvas)
        {
            MotorX = motorX;
            MotorY = motorY;
            MotorZ = motorZ;
            this.slide = targylemez;
            this.canvas = canvas;
            ScaleTransform = new ScaleTransform();
        }

        public void MoveLeft()
        {
            bool remainsMiddle = Canvas.GetLeft(slide) + slide.ActualWidth - 10 >= canvas.ActualWidth / 2;

            if (remainsMiddle)
            {
                DoubleAnimation animation = new DoubleAnimation(Canvas.GetLeft(slide), Canvas.GetLeft(slide) - 10, TimeSpan.FromMilliseconds(500/MotorX.Speed));
                slide.BeginAnimation(Canvas.LeftProperty, animation);
                MotorX.MoveNegative();
            } else
            {
                MessageBox.Show("Further moving is not possible");
            }
        }

        public void MoveRight()
        {
            bool remainsMiddle = Canvas.GetLeft(slide) + 10 <= canvas.ActualWidth / 2;

            if (remainsMiddle)
            {
                DoubleAnimation animation = new DoubleAnimation(Canvas.GetLeft(slide), Canvas.GetLeft(slide) + 10, TimeSpan.FromMilliseconds(500/MotorX.Speed));
                slide.BeginAnimation(Canvas.LeftProperty, animation);
                MotorX.MovePositive();
            } else
            {
                MessageBox.Show("Further moving is not possible");
            }
        }

        public void MoveUp()
        {
            bool remainsMiddle = Canvas.GetTop(slide) + slide.ActualHeight - 10 >= canvas.ActualHeight / 2;

            if (remainsMiddle)
            {
                DoubleAnimation animation = new DoubleAnimation(Canvas.GetTop(slide), Canvas.GetTop(slide) - 10, TimeSpan.FromMilliseconds(500/MotorY.Speed));
                slide.BeginAnimation(Canvas.TopProperty, animation);
                MotorY.MoveNegative();
            } else
            {
                MessageBox.Show("Further moving is not possible");
            }
        }

        public void MoveDown()
        {
            bool remainsMiddle = Canvas.GetTop(slide) + 10 <= canvas.ActualHeight / 2;

            if (remainsMiddle)
            {
                DoubleAnimation animation = new DoubleAnimation(Canvas.GetTop(slide), Canvas.GetTop(slide) + 10, TimeSpan.FromMilliseconds(500/MotorY.Speed));
                slide.BeginAnimation(Canvas.TopProperty, animation);
                MotorY.MovePositive();
            } else
            {
                MessageBox.Show("Further moving is not possible");
            }
        }

        public void ZoomIn()
        {
            if (ScaleTransform.ScaleX < 2)
            {
                DoubleAnimation zoomAnimation = new DoubleAnimation();
                zoomAnimation.To = ScaleTransform.ScaleX + 0.1;
                zoomAnimation.Duration = TimeSpan.FromMilliseconds(500/MotorZ.Speed);

                ScaleTransform.CenterX = canvas.ActualWidth / 2;
                ScaleTransform.CenterY = canvas.ActualHeight / 2;
                canvas.RenderTransform = ScaleTransform;
                ScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, zoomAnimation);
                ScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, zoomAnimation);

                MotorZ.MovePositive();
            } else
            {
                MessageBox.Show("Further zooming is not possible");
            }
            
        }

        public void ZoomOut()
        {
            if (ScaleTransform.ScaleX > 1)
            {
                DoubleAnimation zoomAnimation = new DoubleAnimation();
                zoomAnimation.To = ScaleTransform.ScaleX - 0.1;
                zoomAnimation.Duration = TimeSpan.FromMilliseconds(500/MotorZ.Speed);

                ScaleTransform.CenterX = canvas.ActualWidth / 2;
                ScaleTransform.CenterY = canvas.ActualHeight / 2;
                canvas.RenderTransform = ScaleTransform;
                ScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, zoomAnimation);
                ScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, zoomAnimation);

                MotorZ.MoveNegative();
            } else
            {
                MessageBox.Show("Further zooming is not possible");
            }
        }
    }
}
