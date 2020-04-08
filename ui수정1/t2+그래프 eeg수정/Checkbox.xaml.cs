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
    /// Checkbox.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Checkbox : Window
    {
        public Checkbox()
        {
            InitializeComponent();
        }

        private void commercial_checkbox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Analysis um = new Analysis();
            App.Current.MainWindow = um;
            um.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Analysis3 ana1 = new Analysis3();
            App.Current.MainWindow = ana1;
            ana1.Show();
            this.Close();
        }
    }
}
