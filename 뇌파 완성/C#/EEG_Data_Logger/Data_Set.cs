using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EEG_Data_Logger
{
    class Data_Set
    {
        public double[,] series;
        public Data_Set()
        {
            series = new double[26, 128];
        }
        public void AddData(int i, int j, double data)
        {
            series[i, j] = data;
        }
    }
}