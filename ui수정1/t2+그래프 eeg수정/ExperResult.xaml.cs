using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace t2
{
    /// <summary>
    /// ExperResult.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ExperResult : Window
    {
        public ExperResult()
        {
            InitializeComponent();
            showColumnChart();
            showText();
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            ExperOpen user1 = new ExperOpen();
            App.Current.MainWindow = user1;
            user1.Show();
            this.Close();
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ma = new MainWindow();
            App.Current.MainWindow = ma;
            ma.Show();
            this.Close();
        }

        private void showText()
        {
            StreamReader endReader;
            string endpath= @"C:\Users\user\Desktop\ne_po\end.txt";
            endReader = new StreamReader(endpath);
            string res = endReader.ReadLine();
            endResult.AppendText(res);
            endReader.Close();

            StreamReader p300Reader;
            string p300path = @"C:\Users\user\Desktop\p300\p300res.txt";
            p300Reader = new StreamReader(p300path);
            string p = p300Reader.ReadLine();
            p300.AppendText(p);
            p300Reader.Close();

            StreamReader npReader;
            string nppath = @"C:\Users\user\Desktop\ne_po\npres.txt";
            npReader = new StreamReader(nppath);
            string np = npReader.ReadLine();
            nepo.AppendText(np);
            npReader.Close();

            StreamReader maxnpReader;
            string maxnppath = @"C:\Users\user\Desktop\ne_po\maxNptime.txt";
            maxnpReader = new StreamReader(maxnppath);
            string maxnp = maxnpReader.ReadLine();
            maxNp.AppendText(maxnp);
            maxnpReader.Close();

            StreamReader maxp300Reader;
            string maxp300path = @"C:\Users\user\Desktop\p300\maxP300time.txt";
            maxp300Reader = new StreamReader(maxp300path);
            string maxp300 = maxp300Reader.ReadLine();
            maxP300.AppendText(maxp300);
            maxp300Reader.Close();
        }

        private void showColumnChart()
        {
            List<KeyValuePair<int, double>> valueList = new List<KeyValuePair<int, double>>();
            List<KeyValuePair<int, double>> valueList2 = new List<KeyValuePair<int, double>>();
            List<KeyValuePair<int, double>> valueList3 = new List<KeyValuePair<int, double>>();

            StreamReader srtReader;
            StreamReader srtReader2;
            for (int i = 0; i < 30; i++)
            {
                string filePath = @"C:\Users\user\Desktop\p300\" + i + ".txt";                
                srtReader = new StreamReader(filePath);              
                string num = srtReader.ReadLine();
                double val = Convert.ToDouble(num);
                valueList.Add(new KeyValuePair<int, double>(i, val));
            }

            for (int i = 0; i < 26; i++)
            {
                string filePath2 = @"C:\Users\user\Desktop\ne_po\" + i + ".txt";
                srtReader2 = new StreamReader(filePath2);
                string num2 = srtReader2.ReadLine();
                double val2 = Convert.ToDouble(num2);

                valueList2.Add(new KeyValuePair<int, double>(i, val2));
            }

            //Setting data for line chart
            lineChart.DataContext = valueList;
            lineChart2.DataContext = valueList2;


        }

    }
}
