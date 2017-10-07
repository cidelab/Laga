using System;
using System.Windows;
using Laga.GeneticAlgorithm;
using Laga.Graphics;

namespace PiscoSour
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            char[] fitness;
            int popSize = 100;
            int sizeChro = 9; //length of the chromosome
            int cant = 12; //number of chromosome selected in the natural selection...
            float crossPercentPop = 0.4f;
            int cutter = 4;
            float percentMutPop = 0.002f;
            float percentMutChro = 0.001f;
            string[] arrPr = arrPrefix(popSize);

            fitness = new char[] { 'p', 'i', 's', 'c', 'o','s', 'o', 'u', 'r' };
            lblTarget.Content = new string(fitness);
            
            GenrPopulation pop = new GenrPopulation(popSize);
            RankingSort rs = new RankingSort();
            NaturalSelection ns = new NaturalSelection();
            Crossover cs = new Crossover();
            Mutation mut = new Mutation(0.002f);
            Replacement re = new Replacement();

            char[][] chrPop;
            char[][] selChro;
            char[][] sonPop;
            char[][] mutPop;
            char[][] newPop;
            char[][] repPop;

            chrPop = pop.CharPopulation(sizeChro, 97, 122);
            Notebook.PrintPopulation(txtPop, chrPop, arrPr, 'i', "-", false);
            
            for(int k = 0; k < 500; k++)
            {

         
            int[] score = new int[popSize];
            int i = 0;
            foreach (char[] arrCh in chrPop)
            {
                score[i] = CalcFitness(arrCh, fitness);
                i++;
            }
            Notebook.PrintLines(txtResults,LagaTools.Parse(score), false);
            
            rs.BidirectionalBubbleSort(chrPop, score, true); //sort
            Notebook.PrintPopulation(txtPop_Sort, chrPop, arrPr, 'i', "-", false);
            Notebook.PrintLines(txtResults_Sort, LagaTools.Parse(score), false);
            Notebook.PrintPopulation(txtPop_best, new char[][] { chrPop[0] }, arrPr, 'i', "-", false);

                selChro = ns.Elitism(chrPop, cant);
                Notebook.PrintPopulation(txtPop_NatSelect, selChro, arrPr, 'i', "-", false);

                sonPop = cs.SinglePointCrossover(selChro, crossPercentPop, cutter); //crossover
            string[] comb = ChromosomeCombinations(cs.IndexParent);
            Notebook.PrintPopulation(txtPop_Crossover, sonPop, comb, 'i', "-", false);

                mutPop = mut.CharMutation(sonPop, 0.001f, 97, 122); //mutation
            Notebook.PrintPopulation(txtPop_Mutation, mutPop, arrPr, 'i', "-", false);

            chrPop = re.CharRandomReplace(mutPop, popSize, 97, 122); //replacement
            Notebook.PrintPopulation(txtPop_Replacement, chrPop, arrPr, 'i', "-", false);

            }
        }

        private static string[] ChromosomeCombinations(int[] arrIndex)
        {
            string[] arrComb = new string[arrIndex.Length];
            int inc = 0;
            string a, b;
            for (int i = 0; i < arrIndex.Length - 1; i += 2)
            {
                a = arrIndex[i].ToString();
                b = arrIndex[i + 1].ToString();
                arrComb[inc] = "c: " + a + "<>" + b + " ";
                inc++;
                arrComb[inc] = "c: " + b + "<>" + a + " ";
                inc++;
            }
            return arrComb;
        }

        private static string[] arrPrefix(int s)
        {
            string[] arrPref = new string[s];
            for (int i = 0; i < s; i++) arrPref[i] = "ind_" + i.ToString() + "  ";
            return arrPref;
        }


        private static int CalcFitness(char[] ind, char[] target)
        {
            int c = 0;
            for (int i = 0; i < ind.Length; i++)
            {
                if (ind[i] == target[i])
                    c++;
            }
            return c;
        }
    }
}
