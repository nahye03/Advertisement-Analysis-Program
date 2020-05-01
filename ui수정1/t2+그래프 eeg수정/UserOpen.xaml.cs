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
    /// UserOpen.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserOpen : Window
    {
        public UserOpen()
        {
            InitializeComponent();
            showText();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            Result window2 = new Result();
            App.Current.MainWindow = window2;
            window2.Show();
            this.Close();
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
            Result rr = new Result();
            App.Current.MainWindow = rr;
            rr.Show();
            this.Close();
        }
    }
}
