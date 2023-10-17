using KalmanAttila_3DHistech_homework.Controller;
using KalmanAttila_3DHistech_homework.Model;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows;

namespace KalmanAttila_3DHistech_homework.View
{
    public class MoveViewModel : INotifyPropertyChanged
    {
        public MoveController MoveController { get; }
        public ICommand MoveLeftCommand { get; }
        public ICommand MoveRightCommand { get; }
        public ICommand MoveUpCommand { get; }
        public ICommand MoveDownCommand { get; }
        public ICommand ZoomInCommand { get; }
        public ICommand ZoomOutCommand { get; }

        private double motorXPosition;

        public double MotorXPosition
        {
            get
            {
                return motorXPosition;
            }
            set
            {
                if (motorXPosition != value)
                {
                    motorXPosition = value;
                    OnPropertyChanged(nameof(MotorXPosition));
                }
            }
        }

        private double motorYPosition;

        public double MotorYPosition
        {
            get
            {
                return motorYPosition;
            }
            set
            {
                if (motorYPosition != value)
                {
                    motorYPosition = value;
                    OnPropertyChanged(nameof(MotorYPosition));
                }
            }
        }

        private double motorZPosition;

        public double MotorZPosition
        {
            get
            {
                return motorZPosition;
            }
            set
            {
                if (motorZPosition != value)
                {
                    motorZPosition = value;
                    OnPropertyChanged(nameof(MotorZPosition));
                }
            }
        }

        private double speedX;

        public double SpeedX
        {
            get
            {
                return speedX;
            }
            set
            {
                if (speedX != value)
                {
                    speedX = value;
                    OnPropertyChanged(nameof(SpeedX));
                    MoveController.MotorX.Speed = speedX;
                }
            }
        }
        private double speedY;

        public double SpeedY
        {
            get
            {
                return speedY;
            }
            set
            {
                if (speedY != value)
                {
                    speedY = value;
                    OnPropertyChanged(nameof(SpeedY));
                    MoveController.MotorY.Speed = speedY;
                }
            }
        }
        private double speedZ;

        public double SpeedZ
        {
            get
            {
                return speedZ;
            }
            set
            {
                if (speedZ != value)
                {
                    speedZ = value;
                    OnPropertyChanged(nameof(SpeedZ));
                    MoveController.MotorZ.Speed = speedZ;
                }
            }
        }

        public MoveViewModel(Motor motorX, Motor motorY, Motor motorZ, Rectangle slide, Canvas canvas)
        {
            MoveController = new MoveController(motorX, motorY, motorZ, slide, canvas);

            MoveLeftCommand = new MoveCommand(() => MoveController.MoveLeft());
            MoveRightCommand = new MoveCommand(() => MoveController.MoveRight());
            MoveUpCommand = new MoveCommand(() => MoveController.MoveUp());
            MoveDownCommand = new MoveCommand(() => MoveController.MoveDown());
            ZoomInCommand = new MoveCommand(() => MoveController.ZoomIn());
            ZoomOutCommand = new MoveCommand(() => MoveController.ZoomOut());

            MoveController.MotorX.PositionChanged += (sender, args) =>
            {
                MotorXPosition = MoveController.MotorX.Position;
            };
            MoveController.MotorY.PositionChanged += (sender, args) =>
            {
                MotorYPosition = MoveController.MotorY.Position;
            };
            MoveController.MotorZ.PositionChanged += (sender, args) =>
            {
                MotorZPosition = MoveController.MotorZ.Position;
            };
            speedX = motorX.Speed;
            speedY = motorY.Speed;
            speedZ = motorZ.Speed;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
