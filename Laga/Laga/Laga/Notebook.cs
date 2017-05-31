using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Laga.Graphics
{
    public class Notebook
    {
            public Notebook()
        {

        }
        public static void PrintLines(TextBox textBox, string[] messages, bool clear)
        {
            if(clear)
            textBox.Clear();

            foreach (string r in messages)
            {
                textBox.AppendText(r + "\r\n");
            }

        }

    }
}
