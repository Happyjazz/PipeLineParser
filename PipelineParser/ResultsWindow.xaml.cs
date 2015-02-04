using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PipelineParser
{
    /// <summary>
    ///     Interaction logic for ResultsWindow.xaml
    /// </summary>
    public partial class ResultsWindow : Window
    {
        private readonly List<Label> labelMonths;
        private readonly List<TextBox> txtBoxSums;
        private readonly List<TextBox> txtBoxWeightedPercentages;
        private readonly List<TextBox> txtBoxWeightedSums;

        public ResultsWindow(PipelineData pipelineData)
        {
            try
            {
                InitializeComponent();

                labelMonths = new List<Label>();
                txtBoxSums = new List<TextBox>();
                txtBoxWeightedSums = new List<TextBox>();
                
                txtBoxWeightedPercentages = new List<TextBox>();

                PopulateLists();

                for (int i = 2; i < pipelineData.GetHeadlines().Length; i++)
                {
                    int index = i - 2;
                    string column = pipelineData.GetHeadlines()[i];

                    //labelMonths[index].Content = column; //Used to enable dynamic month names - according to Excel Headlines
                    txtBoxSums[index].Text = pipelineData.GetSumOfMonth(column).ToString("c2");
                    string temp = pipelineData.GetWeightedSumOfMonth(column).ToString("c2");
                    txtBoxWeightedSums[index].Text = temp;
                    txtBoxWeightedPercentages[index].Text = pipelineData.GetWeightedPercentage(column);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulateLists()
        {
            //Populate labelMonths List
            labelMonths.Add(labelMonth1);
            labelMonths.Add(labelMonth2);
            labelMonths.Add(labelMonth3);
            labelMonths.Add(labelMonth4);
            labelMonths.Add(labelMonth5);
            labelMonths.Add(labelMonth6);
            labelMonths.Add(labelMonth7);
            labelMonths.Add(labelMonth8);
            labelMonths.Add(labelMonth9);
            labelMonths.Add(labelMonth10);
            labelMonths.Add(labelMonth11);
            labelMonths.Add(labelMonth12);

            //Populate txtBoxSums List
            txtBoxSums.Add(txtBoxMonth1Sum);
            txtBoxSums.Add(txtBoxMonth2Sum);
            txtBoxSums.Add(txtBoxMonth3Sum);
            txtBoxSums.Add(txtBoxMonth4Sum);
            txtBoxSums.Add(txtBoxMonth5Sum);
            txtBoxSums.Add(txtBoxMonth6Sum);
            txtBoxSums.Add(txtBoxMonth7Sum);
            txtBoxSums.Add(txtBoxMonth8Sum);
            txtBoxSums.Add(txtBoxMonth9Sum);
            txtBoxSums.Add(txtBoxMonth10Sum);
            txtBoxSums.Add(txtBoxMonth11Sum);
            txtBoxSums.Add(txtBoxMonth12Sum);

            //Populate txtBoxWeightedSums
            txtBoxWeightedSums.Add(txtBoxMonth1WeightedSum);
            txtBoxWeightedSums.Add(txtBoxMonth2WeightedSum);
            txtBoxWeightedSums.Add(txtBoxMonth3WeightedSum);
            txtBoxWeightedSums.Add(txtBoxMonth4WeightedSum);
            txtBoxWeightedSums.Add(txtBoxMonth5WeightedSum);
            txtBoxWeightedSums.Add(txtBoxMonth6WeightedSum);
            txtBoxWeightedSums.Add(txtBoxMonth7WeightedSum);
            txtBoxWeightedSums.Add(txtBoxMonth8WeightedSum);
            txtBoxWeightedSums.Add(txtBoxMonth9WeightedSum);
            txtBoxWeightedSums.Add(txtBoxMonth10WeightedSum);
            txtBoxWeightedSums.Add(txtBoxMonth11WeightedSum);
            txtBoxWeightedSums.Add(txtBoxMonth12WeightedSum);

            //Populate txtBoxWeightedPercentages
            txtBoxWeightedPercentages.Add(txtBoxMonth1WeightedPercentage);
            txtBoxWeightedPercentages.Add(txtBoxMonth2WeightedPercentage);
            txtBoxWeightedPercentages.Add(txtBoxMonth3WeightedPercentage);
            txtBoxWeightedPercentages.Add(txtBoxMonth4WeightedPercentage);
            txtBoxWeightedPercentages.Add(txtBoxMonth5WeightedPercentage);
            txtBoxWeightedPercentages.Add(txtBoxMonth6WeightedPercentage);
            txtBoxWeightedPercentages.Add(txtBoxMonth7WeightedPercentage);
            txtBoxWeightedPercentages.Add(txtBoxMonth8WeightedPercentage);
            txtBoxWeightedPercentages.Add(txtBoxMonth9WeightedPercentage);
            txtBoxWeightedPercentages.Add(txtBoxMonth10WeightedPercentage);
            txtBoxWeightedPercentages.Add(txtBoxMonth11WeightedPercentage);
            txtBoxWeightedPercentages.Add(txtBoxMonth12WeightedPercentage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}