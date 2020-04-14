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
    /// ExperOpen.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ExperOpen : Window
    {
        public ExperOpen()
        {
            InitializeComponent();
            showText();
        }



        private void showText()
        {
            StreamReader endReader;
            string endpath = @"C:\Users\user\Desktop\ne_po\end.txt";
            endReader = new StreamReader(endpath);
            string res = endReader.ReadLine();
            endResult.AppendText(res);
            endReader.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExperResult experr = new ExperResult();
            App.Current.MainWindow = experr;
            experr.Show();
            this.Close();
        }

        private void endResult_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
