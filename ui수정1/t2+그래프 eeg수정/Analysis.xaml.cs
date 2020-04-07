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
    /// Analysis.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Analysis : Window
    {
        public Analysis()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Usermode1 um = new Usermode1();
            App.Current.MainWindow = um;
            um.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Checkbox ana1 = new Checkbox();
            App.Current.MainWindow = ana1;
            ana1.Show();
            this.Close();
        }
    }
}
