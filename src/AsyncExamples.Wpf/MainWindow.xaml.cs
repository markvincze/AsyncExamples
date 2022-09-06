#pragma warning disable SYSLIB0014 // Type or member is obsolete
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace AsyncExamples.Wpf.UIBlock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            tbServerResponse.Text = "Downloading...";

            WebClient wc = new WebClient();

            var sb = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var content = await wc.DownloadStringTaskAsync(new Uri("http://localhost:5000/weatherforecast?waitTimeMs=500"));

                    sb.Append(content);
                }
                catch
                {
                    break;
                }
            }

            tbServerResponse.Text = sb.ToString();
        }
    }
}
