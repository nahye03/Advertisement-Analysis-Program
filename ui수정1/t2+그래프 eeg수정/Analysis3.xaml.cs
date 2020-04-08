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
    /// Analysis3.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Analysis3 : Window
    {
        public Analysis3()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ma = new MainWindow();
            App.Current.MainWindow = ma;
            ma.Show();
            this.Close();
        }
    }
}
