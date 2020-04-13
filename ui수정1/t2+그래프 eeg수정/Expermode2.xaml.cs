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
    /// Expermode2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Expermode2 : Window
    {
        public StreamWriter wr;
        public Expermode2()
        {
            InitializeComponent();          
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Expermode1 exper1 = new Expermode1();
            App.Current.MainWindow = exper1;
            exper1.Show();
            this.Close();
        }
        private void ad1_Click(object sender, RoutedEventArgs e)
        {
            wr = new StreamWriter(@"C:\Users\user\Desktop\" + "start" + ".txt");
            wr.WriteLine("s");
            wr.Close();

            Ad1 ad1 = new Ad1();
            App.Current.MainWindow = ad1;
            ad1.Show();
            this.Close();
        }

        private void ad2_Click(object sender, RoutedEventArgs e)
        {
            wr = new StreamWriter(@"C:\Users\user\Desktop\" + "start" + ".txt");
            wr.WriteLine("s");
            wr.Close();

            Ad2 ad2 = new Ad2();
            App.Current.MainWindow = ad2;
            ad2.Show();
            this.Close();

        }

        private void ad3_Click(object sender, RoutedEventArgs e)
        {
            wr = new StreamWriter(@"C:\Users\user\Desktop\" + "start" + ".txt");
            wr.WriteLine("s");
            wr.Close();

            Ad3 ad3 = new Ad3();
            App.Current.MainWindow = ad3;
            ad3.Show();
            this.Close();

        }

        private void ad4_Click(object sender, RoutedEventArgs e)
        {
            wr = new StreamWriter(@"C:\Users\user\Desktop\" + "start" + ".txt");
            wr.WriteLine("s");
            wr.Close();

            Ad4 ad4 = new Ad4();
            App.Current.MainWindow = ad4;
            ad4.Show();
            this.Close();

        }

        private void ad5_Click(object sender, RoutedEventArgs e)
        {
            wr = new StreamWriter(@"C:\Users\user\Desktop\" + "start" + ".txt");
            wr.WriteLine("s");
            wr.Close();

            Ad5 ad5 = new Ad5();
            App.Current.MainWindow = ad5;
            ad5.Show();
            this.Close();
        }

        private void ad6_Click(object sender, RoutedEventArgs e)
        {
            wr = new StreamWriter(@"C:\Users\user\Desktop\" + "start" + ".txt");
            wr.WriteLine("s");
            wr.Close();

            Ad6 ad6 = new Ad6();
            App.Current.MainWindow = ad6;
            ad6.Show();
            this.Close();
        }

        private void ad7_Click(object sender, RoutedEventArgs e)
        {
            wr = new StreamWriter(@"C:\Users\user\Desktop\" + "start" + ".txt");
            wr.WriteLine("s");
            wr.Close();

            Ad7 ad7 = new Ad7();
            App.Current.MainWindow = ad7;
            ad7.Show();
            this.Close();
        }

        private void ad8_Click(object sender, RoutedEventArgs e)
        {
            wr = new StreamWriter(@"C:\Users\user\Desktop\" + "start" + ".txt");
            wr.WriteLine("s");
            wr.Close();

            Ad8 ad8 = new Ad8();
            App.Current.MainWindow = ad8;
            ad8.Show();
            this.Close();
        }

        private void ad9_Click(object sender, RoutedEventArgs e)
        {
            wr = new StreamWriter(@"C:\Users\user\Desktop\" + "start" + ".txt");
            wr.WriteLine("s");
            wr.Close();

            Ad9 ad9 = new Ad9();
            App.Current.MainWindow = ad9;
            ad9.Show();
            this.Close();
        }

        private void ad10_Click(object sender, RoutedEventArgs e)
        {
            wr = new StreamWriter(@"C:\Users\user\Desktop\" + "start" + ".txt");
            wr.WriteLine("s");
            wr.Close();

            Ad10 ad10 = new Ad10();
            App.Current.MainWindow = ad10;
            ad10.Show();
            this.Close();
        }
    }
}
