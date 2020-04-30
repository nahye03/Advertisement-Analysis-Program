using System;
using System.Collections.Generic;
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
    /// Usermode1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Usermode1 : Window
    {
        public Usermode1()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window1 = new MainWindow();
            App.Current.MainWindow = window1;
            window1.Show();
            this.Close();
        }

        private void analysis_Click(object sender, RoutedEventArgs e)
        {
            Analysis ana = new Analysis();
            App.Current.MainWindow = ana;
            ana.Show();
            this.Close();
        }

        private void result_Click(object sender, RoutedEventArgs e)
        {
            UserOpen res = new UserOpen();
            App.Current.MainWindow = res;
            res.Show();
            this.Close();
        }
    }
}
