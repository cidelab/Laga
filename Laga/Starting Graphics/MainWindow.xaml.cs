using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Laga.GeneticAlgorithm;

namespace Starting_Graphics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GenrPopulation pop = new GenrPopulation(10);

            point[][] popPts = pop.PointPopulation(4, 0, ink.ActualWidth, 0, ink.ActualHeight, 0, 10);

            Ellipse elly;
            int step = (int)255 / 10;
            int r = step;
            int g = 1;
            int b = 10;

            foreach (point[] chromo in popPts)
            {
                elly = new Ellipse();
                b = 100;

               Brush br = new SolidColorBrush(Color.FromArgb(255, (byte)r, (byte)g, (byte)b));

                foreach(point p in chromo)
                {
                    elly = CreateEllipse(10, 10, p.X, p.Y);

                    elly.Stroke = br;
                    elly.Fill = br;
                    ink.Children.Add(elly);
                }

                r = r + step;
                b = b + 10;
                g = r - b;
            }

        }

        Ellipse CreateEllipse(double width, double height, double desiredCenterX, double desiredCenterY)
        {
            Ellipse ellipse = new Ellipse { Width = width, Height = height };
            double left = desiredCenterX - (width / 2);
            double top = desiredCenterY - (height / 2);

            ellipse.Margin = new Thickness(left, top, 0, 0);
            return ellipse;
        }
    }
}
