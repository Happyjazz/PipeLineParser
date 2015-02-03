using System;
using System.Collections.Generic;
using System.Data;
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

namespace PipelineParser
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string bulkData = txtBoxBulkData.Text.Trim();
            string[] bulkDataInLines = bulkData.Split('\n');

            string[] firstLineData = bulkDataInLines[0].Split('\t');

            DataTable pipelineData = new DataTable();

            foreach (var headline in firstLineData)
            {
                pipelineData.Columns.Add(headline);
            }

            for (int i = 1; i < bulkDataInLines.Length; i++)
            {
                string[] lineOfData = bulkDataInLines[i].Split('\t');

                pipelineData.Rows.Add(lineOfData);
            }
        }
    }
}
