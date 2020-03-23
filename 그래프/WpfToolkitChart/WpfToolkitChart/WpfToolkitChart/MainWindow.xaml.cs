using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfToolkitChart
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      showColumnChart();
    }

    private void showColumnChart()
    {
      List<KeyValuePair<int, double>> valueList = new List<KeyValuePair<int, double>>();
            //valueList.Add(new KeyValuePair<string, int>("1",60));
            //valueList.Add(new KeyValuePair<string, int>("2", 20));
            //valueList.Add(new KeyValuePair<string, int>("3", 50));
            //valueList.Add(new KeyValuePair<string, int>("4", 30));
            //valueList.Add(new KeyValuePair<string, int>("5", 40));
            //valueList.Add(new KeyValuePair<string, int>("343", 40));
            //valueList.Add(new KeyValuePair<string, int>("342",60));
          StreamReader srtReader;
          for (int i=0;i<30;i++)
            {
                string filePath = @"C:\Users\정민지\Desktop\p300\" + i + ".txt";
                srtReader = new StreamReader(filePath);
                string num = srtReader.ReadLine();
                double val = Convert.ToDouble(num);

                string fileName = i.ToString();
                valueList.Add(new KeyValuePair<int, double>(i, val));
            }



      //Setting data for line chart
      lineChart.DataContext = valueList;
    }

  }
}
