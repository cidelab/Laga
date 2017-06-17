using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Laga.Graphics
{
    /// <summary>
    /// Static class to write in textboxes.
    /// </summary>
    public static class Notebook
    {

        /// <summary>
        /// Print line by line in a textbox. For appareance and other properties refer to xaml. 
        /// </summary>
        /// <param name="textBox">the textbox</param>
        /// <param name="arrMessages">array of strings</param>
        /// <param name="clear">in case you want to clean the textbox before</param>
        public static void PrintLines(TextBox textBox, string[] arrMessages, bool clear)
        {
            if (clear)
            {
                textBox.Clear();
            }
            else
            {
                textBox.AppendText("\r\n");
            }

            foreach (string r in arrMessages)
            {
                textBox.AppendText(r + "\r\n");
            }

        }

    }
}
