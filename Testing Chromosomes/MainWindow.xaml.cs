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
using Laga;

namespace Testing_Chromosomes
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

        Laga.GeneticAlgorithm.GenrChromosome chrom;
        
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string strNum = txtBoxIter.Text;
            strNum = (strNum == "") ? "10" : strNum;

            int intChromosome = Convert.ToInt16(strNum);

            chrom = new Laga.GeneticAlgorithm.GenrChromosome(intChromosome);
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            char[] chrChromData = chrom.BinaryChromosomeChr();
            string[] arrString = new string[] { new string(chrChromData) };
            Laga.Graphics.Notebook.PrintLines(txtBoxChar, arrString, false);
            
        }
    }
}
