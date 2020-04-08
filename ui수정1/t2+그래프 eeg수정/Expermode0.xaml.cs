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
    /// Expermode0.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Expermode0 : Window
    {
        public Expermode0()
        {
            InitializeComponent();
        }

        private void exper_Click(object sender, RoutedEventArgs e)
        {
            Expermode1 window2 = new Expermode1();
            App.Current.MainWindow = window2;
            window2.Show();
            this.Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ma = new MainWindow();
            App.Current.MainWindow = ma;
            ma.Show();
            this.Close();
        }

        private void result_Click(object sender, RoutedEventArgs e)
        {
            ExperOpen re = new ExperOpen();
            App.Current.MainWindow = re;
            re.Show();
            this.Close();

        }
    }
}
