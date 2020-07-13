using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EEG_Data_Logger
{
    class PeakDetection
    {
        private int lastindex = 0;
        private double lastval;

        public PeakDetection(double[] data)
        {
            Excute(data);
        }

        public void Excute(double[] result)
        {
            lastval = result[0];
            bool dirpos = true;
            for (int i = 0; i < result.Length; i++)
            {
                var currentval = result[i];
                if (dirpos && currentval < lastval)
                {
                    //Console.WriteLine(string.Format("i: {0} value: {1}", lastindex, result[lastindex]));
                    dirpos = false;
                }
                if (currentval >= lastval)
                    dirpos = true;

                lastval = currentval;
                lastindex = i;
            }
        }

        public int GetIndex()
        {
            return lastindex;
        }

        public double GetValue()
        {
            return lastval;
        }
    }
}
