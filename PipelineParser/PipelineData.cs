using System;
using System.Data;
using System.Diagnostics;

namespace PipelineParser
{
    public class PipelineData
    {
        private DataTable _table;
        private string[] _columnHeadlines;

        public DataTable Table
        {
            get
            {
                return _table.Copy();
            }
        }
        
        //Constructor
        public PipelineData(string bulkData)
        {
            ParseBulkData(bulkData);
        }

        private void ParseBulkData(string bulkData)
        {
            string[] bulkDataInLines = bulkData.Trim().Split('\n');

            for (int i = 0; i < bulkDataInLines.Length; i++)
            {
                bulkDataInLines[i] = bulkDataInLines[i].Replace("\r", "");
            }
            
            _columnHeadlines = bulkDataInLines[0].Split('\t');

            DataTable pipelineData = new DataTable();

            //Create the columns in the DataTable, from the Array of headlines
            foreach (var headline in _columnHeadlines)
            {
                pipelineData.Columns.Add(headline);
            }

            //Populate the rows from the remaining data in the bulkDataInLines Array
            for (int i = 1; i < bulkDataInLines.Length; i++)
            {
                string[] lineOfData = bulkDataInLines[i].Split('\t');

                pipelineData.Rows.Add(lineOfData);

                foreach (var item in lineOfData)
                {
                    Debug.Print(item);
                }
            }

            _table = pipelineData;
        }

        /// <summary>
        /// Method to get a stringarray of all column names.
        /// </summary>
        /// <returns></returns>
        public string[] GetHeadlines()
        {
            string[] headlineCopy = new string[_columnHeadlines.Length];
            _columnHeadlines.CopyTo(headlineCopy, 0);
            return headlineCopy;
        }

        /// <summary>
        /// Gets the sum of a single months revenue.
        /// </summary>
        /// <param name="columnHeadline">The name of the column to get the sum from.</param>
        /// <returns></returns>
        public decimal GetSumOfMonth(string columnHeadline)
        {
            decimal sum = 0;

            foreach (DataRow row in _table.Rows)
            {
                sum += Convert.ToDecimal(row[columnHeadline]);
            }

            return sum;
        }

        /// <summary>
        /// Gets the weighted sum of a single month.
        /// The sum of the individual individual offers divided with the pipeline-%
        /// </summary>
        /// <param name="columnHeadline">The name of the column to get the weighted sum from</param>
        /// <returns></returns>
        public decimal GetWeightedSumOfMonth(string columnHeadline)
        {
            decimal sum = 0;

            foreach (DataRow row in _table.Rows)
            {
                decimal revenue = Convert.ToDecimal(row[columnHeadline]);
                decimal pipelinePercentage = Convert.ToDecimal(row[1]);
                sum += revenue * (pipelinePercentage / 100);
            }

            return sum;
        }

        /// <summary>
        /// Gets the percentage that the weighted revenue makes of the total revenue.
        /// </summary>
        /// <param name="columnHeadline">The name of the column to get the weighted percentage from</param>
        /// <returns></returns>
        public string GetWeightedPercentage(string columnHeadline)
        {
            decimal sumOfMonth = GetSumOfMonth(columnHeadline);
            decimal weightedSumOfMonth = GetWeightedSumOfMonth(columnHeadline);

            decimal percentage = weightedSumOfMonth / sumOfMonth;

            return string.Format("{0:0.##\\%}", percentage*100);
        }
    }
}
