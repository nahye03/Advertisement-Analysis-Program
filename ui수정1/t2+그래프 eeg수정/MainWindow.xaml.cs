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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace t2
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void expermode_Click(object sender, RoutedEventArgs e)
        {

            Expermode0 window1 = new Expermode0();
            App.Current.MainWindow = window1;
            window1.Show();
            this.Close();
        }

        private void usermode_Click(object sender, RoutedEventArgs e)
        {
            Usermode1 user1 = new Usermode1();
            App.Current.MainWindow = user1;
            user1.Show();
            this.Close();
        }
    }
}
