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
using System.Windows.Shapes;

namespace PipelineParser
{
    /// <summary>
    /// Interaction logic for ResultsWindow.xaml
    /// </summary>
    public partial class ResultsWindow : Window
    {
        public ResultsWindow(PipelineData pipelineData)
        {
            InitializeComponent();

            string column = pipelineData.GetHeadlines()[3];

            labelMonth.Content = column;
            txtBoxMonth1Sum.Text = pipelineData.GetSumOfMonth(column);
            txtBoxMonth1WeightedSum.Text = pipelineData.GetWeightedSumOfMonth(column);
        }
    }
}
