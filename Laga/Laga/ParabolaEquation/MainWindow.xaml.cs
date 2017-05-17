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
using Laga.GeneticAlgorithm;

namespace ParabolaEquation
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

        private int popSize = 10; //population size...
        private int chromeSize = 4; //chromosome size....
        private float eval;
        private float[] mResults;
        private float[] mParams;

        private char[][] charPop;
        private char[][] selChro;
        private char[][] sonPop;
        private char[][] mutPop;

        GenrPopulation genPop;
        RankingSort rs;
        NaturalSelection ns;
        Crossover cs;
        Mutation mut;

        private void noteBook_Loaded(object sender, RoutedEventArgs e)
        {
            //when loads intialize all the GA parameters...
            rs = new RankingSort();
            ns = new NaturalSelection();
            cs = new Crossover();
            mut = new Mutation(0.01f);

            RunOnce();

        }

        private void RunGA()
        {
            do
            {
                Evaluation(charPop, out mResults, out mParams); //eval the data...
                PrintData(noteBook.txtEvolve, mResults, mParams, "Maximise f(x) = -x2 + 4x + 5");

                rs.BidirectionalBubbleSort(charPop, mResults, true);

                eval = mResults[0]; //we get the highest fitness in the population
                label4.Content = "best : " + eval.ToString() + " = 9?"; //print

                selChro = ns.Elitism(charPop, 5); //select the top five chromosomes...
                sonPop = cs.SinglePointCrossover(selChro, 0.2f, 2);
                mutPop = mut.BinaryCharMutation(sonPop, 1f); //we are going to mutate the whole chromosome...

                PrintData(noteBook.txtEvolve_Copy1, selChro);//print the selected individuals for crossover...
                PrintData(noteBook.txtSonAndMutation, sonPop, ""); //print the selected crossover...
                PrintData(noteBook.txtSonAndMutation_Copy, mutPop, "");  //print the mutated crossover

                charPop = ReplacementPop(selChro, mutPop, sonPop, popSize);
                PrintData(noteBook.txtEvolve_Copy, charPop, "");

            } while (eval != 9);

        }

        private void RunOnce()
        {
            genPop = new GenrPopulation(popSize);
            charPop = genPop.BinaryPopulationChr(chromeSize);
            PrintData(noteBook.textBox, charPop, "Original pop");
            Evaluation(charPop, out mResults, out mParams); //eval the data...
            PrintData(noteBook.txtEvolve, mResults, mParams, "Maximise f(x) = -x2 + 4x + 5");
        }

        private static char[][] ReplacementPop(char[][] selIndividuals, char[][] mutPop, char[][] sonPop, int sizePop)
        {
            char[][] replacement = new char[sizePop][];
            char[] tempChromosome;
            int count = 0;
            for (int i = 0; i < mutPop.Length; ++i)
            {
                tempChromosome = new char[mutPop[i].Length];
                tempChromosome = mutPop[i];
                replacement[count] = tempChromosome;
                count++;
            }

            for (int i = 0; i < selIndividuals.Length; ++i)
            {
                tempChromosome = new char[selIndividuals[i].Length];
                tempChromosome = selIndividuals[i];
                replacement[count] = tempChromosome;
                count++;
            }

            for (int i = 0; i < sonPop.Length; ++i)
            {
                tempChromosome = new char[sonPop[i].Length];
                tempChromosome = sonPop[i];
                replacement[count] = tempChromosome;
                count++;
            }

            if (count < sizePop)
            {
                for (int i = count; i < sizePop; ++i)
                {
                    tempChromosome = new char[mutPop[0].Length];
                    tempChromosome = mutPop[0];
                    replacement[i] = tempChromosome;
                }
            }


            return replacement;
        }

        /// <summary>
        /// print data TextBox...
        /// </summary>
        /// <param name="textBox">the textBox itself...</param>
        /// <param name="CharPopulation">the population to display</param>
        /// <param name="header">(optional) header in the textbox...</param>
        private void PrintData(TextBox textBox, char[][] CharPopulation, string header = "")
        {
            string s = "";

           textBox.Clear();

            if (header != "")
            {
                textBox.Text = header + "\r\n";
            }

            foreach (char[] arrChromosome in CharPopulation)
            {
                s = new string(arrChromosome);
                textBox.AppendText(s + "\r\n");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrCh"></param>
        /// <param name="e"></param>
        /// <param name="c"></param>
        private static void PrintData(TextBox textBox, float[] results, float[] parameters, string header = "")
        {
            string dta = "";
            int c = 0;
            string strR, strP;
            textBox.Clear();
            if (header != "")
            {
                textBox.Text = header + "\r\n";
            }

            foreach(float r in results)
            {
                strR = r.ToString();
                strP = parameters[c].ToString();

                dta = c.ToString() + ":   " + strP + "^2 + 4*" + strP + " + 5 = " + strR;
                textBox.AppendText(dta + "\r\n");
                c++;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="population"></param>
        /// <param name="results"></param>
        /// <param name="parameters"></param>
        private void Evaluation(char[][] population, out float[] results, out float[] parameters) //maximise f(x) = -x2 + 4x + 5
        {
            string f = "";
            int x;

            int count = 0;
            results = new float[population.Length];
            parameters = new float[population.Length];

            foreach (char[] chromosome in population)
            {
                f = new string(chromosome);
                x = Convert.ToInt32(f, 2);
                results[count] = (float)(-Math.Pow(x, 2) + 4 * x + 5);
                parameters[count] = x;

                count++;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            RunOnce();
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            RunGA();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            eval = 9;
        }
    }
}
