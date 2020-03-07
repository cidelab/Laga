using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Laga.GeneticAlgorithm;
using LagaUnity;

namespace Laga.Graphics
{
    /// <summary>
    /// Static class to write in textboxes.
    /// </summary>
    public static class Notebook
    {
        private static string jumpLine = "\r\n";
        
        /// <summary>
        /// Print line by line in a textbox. For appareance and other properties refer to xaml. 
        /// </summary>
        /// <param name="textBox">the textbox</param>
        /// <param name="arrMessages">array of strings</param>
        /// <param name="clear">in case you want to clean the textbox before to write</param>
        public static void PrintLines(TextBox textBox, string[] arrMessages, bool clear)
        {
            if (clear)
            {
                textBox.Clear();
            }
            else
            {
                textBox.AppendText(jumpLine);
            }

            foreach (string r in arrMessages)
            {
                textBox.AppendText(r + jumpLine);
            }

        }

        /// <summary>
        /// Print line by line in a text box the content in a population. For appearence and other properties refer to xaml.
        /// </summary>
        /// <param name="textBox">the textbox</param>
        /// <param name="population">the popupation to write</param>
        /// <param name="prefix">an array of prefixs between chromosomes in the population</param>
        /// <param name="inLine">a char to define if you want to print in line: 'i' or under line: any other char.</param>
        /// <param name="sep">The string to use as a separator between genes in the chromosome</param>
        /// <param name="clear">in case you want to clean the textbox before to write</param>
        public static void PrintPopulation(TextBox textBox, double[][] population, string[] prefix, char inLine, string sep, bool clear)
        {
            if (clear)
            {
                textBox.Clear();
            }
            else
            {
                textBox.AppendText(jumpLine);
            }
            string chroMessage = "";
            int i = 0;

            if (prefix.Length == population.Length)
            {
                if (inLine == 'i')
                {
                    foreach (double[] chromosome in population)
                    {
                        chroMessage = String.Join(sep, GeneticAlgorithm.LagaTools.Parse(chromosome));
                        textBox.AppendText(prefix[i] + chroMessage + jumpLine);
                        i++;
                    }
                }
                else
                {
                    foreach (double[] chromosome in population)
                    {
                        textBox.AppendText(prefix[i] + jumpLine);
                        i++;

                        chroMessage = String.Join(sep, GeneticAlgorithm.LagaTools.Parse(chromosome));
                        textBox.AppendText(chroMessage + jumpLine);
                    }
                }
            }
            else
            {
                foreach (double[] chromosome in population)
                {
                    chroMessage = String.Join(sep, GeneticAlgorithm.LagaTools.Parse(chromosome));
                    textBox.AppendText(chroMessage + jumpLine);
                }
            }
        }

        /// <summary>
        /// Print line by line in a text box the content in a population. For appearence and other properties refer to xaml.
        /// </summary>
        /// <param name="textBox">the textbox</param>
        /// <param name="population">the popupation to write</param>
        /// <param name="prefix">an array of prefixs between chromosomes in the population</param>
        /// <param name="sep">The string to use as a separator between genes in the chromosome</param>
        /// <param name="clear">in case you want to clean the textbox before to write</param>
        public static void PrintPopulation(TextBox textBox, float[][] population, string[] prefix, string sep, bool clear)
        {
            if (clear)
            {
                textBox.Clear();
            }
            else
            {
                textBox.AppendText(jumpLine);
            }
            string chroMessage = "";
            int i = 0;

            if (prefix.Length == population.Length)
            {
                foreach (float[] chromosome in population)
                {
                    textBox.AppendText(prefix[i] + jumpLine);
                    i++;

                    chroMessage = String.Join(sep, GeneticAlgorithm.LagaTools.Parse(chromosome));
                    textBox.AppendText(chroMessage + jumpLine);
                }
            }
            else
            {
                foreach (float[] chromosome in population)
                {
                    chroMessage = String.Join(sep, GeneticAlgorithm.LagaTools.Parse(chromosome));
                    textBox.AppendText(chroMessage + jumpLine);
                }
            }
        }

        /// <summary>
        /// Print line by line in a text box the content in a population. For appearence and other properties refer to xaml.
        /// </summary>
        /// <param name="textBox">the textbox</param>
        /// <param name="population">the popupation to write</param>
        /// <param name="prefix">an array of prefixs between chromosomes in the population</param>
        /// <param name="sep">The string to use as a separator between genes in the chromosome</param>
        /// <param name="clear">in case you want to clean the textbox before to write</param>
        public static void PrintPopulation(TextBox textBox, int[][] population, string[] prefix, string sep, bool clear)
        {
            if (clear)
            {
                textBox.Clear();
            }
            else
            {
                textBox.AppendText(jumpLine);
            }
            string chroMessage = "";
            int i = 0;

            if (prefix.Length == population.Length)
            {
                foreach (int[] chromosome in population)
                {
                    textBox.AppendText(prefix[i] + jumpLine);
                    i++;

                    chroMessage = String.Join(sep, GeneticAlgorithm.LagaTools.Parse(chromosome));
                    textBox.AppendText(chroMessage + jumpLine);
                }
            }
            else
            {
                foreach (int[] chromosome in population)
                {
                    chroMessage = String.Join(sep, GeneticAlgorithm.LagaTools.Parse(chromosome));
                    textBox.AppendText(chroMessage + jumpLine);
                }
            }
        }

        /// <summary>
        /// Print line by line in a text box the content in a population. For appearence and other properties refer to xaml.
        /// </summary>
        /// <param name="textBox">the textbox</param>
        /// <param name="population">the popupation to write</param>
        /// <param name="prefix">an array of prefixs between chromosomes in the population</param>
        /// <param name="inLine">a char to define if you want to print in line: 'i' or under line: any other char.</param>
        /// <param name="sep">The string to use as a separator between genes in the chromosome</param>
        /// <param name="clear">in case you want to clean the textbox before to write</param>
        public static void PrintPopulation(TextBox textBox, char[][] population, string[] prefix, char inLine, string sep, bool clear)
        {
            if (clear)
            {
                textBox.Clear();
            }
            else
            {
                textBox.AppendText(jumpLine);
            }
            string chroMessage = "";
            int i = 0;

            if (prefix.Length == population.Length)
            {
                if (inLine == 'i')
                {
                    foreach (char[] chromosome in population)
                    {
                        chroMessage = String.Join(sep, GeneticAlgorithm.LagaTools.Parse(chromosome));
                        textBox.AppendText(prefix[i] + chroMessage + jumpLine);
                        i++;
                    }
                }
                else
                {
                    foreach (char[] chromosome in population)
                    {
                        textBox.AppendText(prefix[i] + jumpLine);
                        i++;

                        chroMessage = String.Join(sep, GeneticAlgorithm.LagaTools.Parse(chromosome));
                        textBox.AppendText(chroMessage + jumpLine);
                    }
                }
            }
            else
            {
                foreach (char[] chromosome in population)
                {
                    chroMessage = String.Join(sep, LagaTools.Parse(chromosome));
                    textBox.AppendText(chroMessage + jumpLine);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="population"></param>
        /// <param name="prefix"></param>
        /// <param name="sep"></param>
        /// <param name="r"></param>
        /// <param name="clear"></param>
        public static void PrintPopulation(TextBox textBox, LagaUnity.Point[][] population, string[] prefix, string sep, int r, bool clear)
        {
            if (clear)
            {
                textBox.Clear();
            }
            else
            {
                textBox.AppendText(jumpLine);
            }
            string chroMessage = "";
            int i = 0;

            if (prefix.Length == population.Length)
            {
                foreach (LagaUnity.Point[] chromosome in population)
                {
                    textBox.AppendText(prefix[i] + jumpLine);
                    i++;
                    chroMessage = string.Join(sep, LagaTools.Parse(chromosome, r));
                    textBox.AppendText(chroMessage + jumpLine);
                }
            }
            else
            {
                foreach (LagaUnity.Point[] chromosome in population)
                {
                    chroMessage = string.Join(sep, LagaTools.Parse(chromosome, r));
                    textBox.AppendText(chroMessage + jumpLine);
                }
            }
        }
    }
}

