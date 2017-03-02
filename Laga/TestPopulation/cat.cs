using System;
using System.Collections.Generic;
using System.Text;

namespace TestPopulation
{
    class cat
    {
        private int year;
        private double weight;
        private string name;

        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public cat() { }
    }
}
