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
    /// Ad6.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Ad6 : Window
    {
        public Ad6()
        {
            InitializeComponent();
            ad6.Play();
        }
        private void Element_MediaOpened(object sender, EventArgs e)
        {
            timelineSlider.Maximum = ad6.NaturalDuration.TimeSpan.TotalMilliseconds;
        }

        // When the media playback is finished. Stop() the media to seek to media start.
        private void Element_MediaEnded(object sender, EventArgs e)
        {
            ad6.Stop();
            Expermode3 mode3 = new Expermode3();
            App.Current.MainWindow = mode3;
            mode3.Show();
            this.Close();
        }
    }
}
