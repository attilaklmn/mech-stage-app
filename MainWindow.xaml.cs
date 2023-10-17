using KalmanAttila_3DHistech_homework.Controller;
using KalmanAttila_3DHistech_homework.Model;
using KalmanAttila_3DHistech_homework.View;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KalmanAttila_3DHistech_homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Motor motorX = new Motor(36.0);
            Motor motorY = new Motor(36.0);
            Motor motorZ = new Motor(36.0);

            DataContext = new MoveViewModel(motorX, motorY, motorZ, slide, canvas);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double canvasWidth = canvas.ActualWidth;
            double canvasHeight = canvas.ActualHeight;

            double rectWidth = slide.Width;
            double rectHeight = slide.Height;

            double centerX = (canvasWidth - rectWidth) / 2;
            double centerY = (canvasHeight - rectHeight) / 2;

            Canvas.SetLeft(slide, centerX);
            Canvas.SetTop(slide, centerY);

            CreateGrid(canvas, 20, 20);
        }

        private void CreateGrid(Canvas canvas, int rowCount, int columnCount)
        {
            double canvasWidth = canvas.ActualWidth;
            double canvasHeight = canvas.ActualHeight;

            double rowHeight = canvasHeight / rowCount;
            double columnWidth = canvasWidth / columnCount;

            for (int i = 1; i < rowCount; i++)
            {
                Line horizontalLine = new Line
                {
                    X1 = 0,
                    Y1 = i * rowHeight,
                    X2 = canvasWidth,
                    Y2 = i * rowHeight,
                    Stroke = Brushes.Black,
                    StrokeThickness = i == rowCount / 2 ? 3 : 1
                };
                canvas.Children.Add(horizontalLine);
            }

            for (int i = 1; i < columnCount; i++)
            {
                Line verticalLine = new Line
                {
                    X1 = i * columnWidth,
                    Y1 = 0,
                    X2 = i * columnWidth,
                    Y2 = canvasHeight,
                    Stroke = Brushes.Black,
                    StrokeThickness = i == columnCount / 2 ? 3 : 1
                };
                canvas.Children.Add(verticalLine);
            }
        }

        

    }
}
