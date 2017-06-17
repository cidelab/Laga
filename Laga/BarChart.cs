using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;

namespace Laga.Graphics
{
    public class BarChart
    {
        private InkCanvas mInk;
        private double w;
        private double h;

        public BarChart(InkCanvas inkCanvas)
        {
            mInk = inkCanvas;
            w = mInk.ActualWidth;
            h = mInk.ActualHeight;
            drawFrame();
        }

        void drawFrame()
        {
            Line myLine;
            
            myLine = new Line();
            myLine.Stroke = Brushes.Red;
            myLine.StrokeThickness = 1;

            myLine.X1 = 10;
            myLine.X2 = 10;
            myLine.Y1 = 10;
            myLine.Y2 =  h - 10;

            mInk.Children.Add(myLine);
        }


    }
}
