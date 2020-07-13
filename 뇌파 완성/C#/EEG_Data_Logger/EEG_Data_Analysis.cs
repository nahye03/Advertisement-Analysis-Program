using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EEG_Data_Logger
{
    class EEG_Data_Analysis
    {
        double[][] rawEEG;

        public EEG_Data_Analysis() 
        {
            rawEEG = new double[14][];
        }

        public double[][] GetRawEEG(double[][] src) //채널별 뇌파로 전체 뇌파
        {
            Array.Copy(src, rawEEG, 128*14);
            return rawEEG;
        }

        public double GetP300(double[] channel) //p300선택
        {
            double[] src = new double[32];
            Array.Copy(channel, 32, src, 0, 32);

            PeakDetection peak = new PeakDetection(channel);

            var p300 = peak.GetValue();
            return p300;
        }
    }
}
