﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int columnNumber = 1;
            foreach (var headline in _columnHeadlines)
            {
                pipelineData.Columns.Add(headline);
            }

            //Populate the rows from the remaining data in the bulkDataInLines Array
            for (int i = 1; i < bulkDataInLines.Length; i++)
            {
                string[] lineOfData = bulkDataInLines[i].Split('\t');

                pipelineData.Rows.Add(lineOfData);
            }

            _table = pipelineData;
        }

        /// <summary>
        /// Method to get a stringarray of all column names
        /// </summary>
        /// <returns></returns>
        public string[] GetHeadlines()
        {
            string[] headlineCopy = new string[_columnHeadlines.Length];
            _columnHeadlines.CopyTo(headlineCopy, 0);
            return headlineCopy;
        }
    }
}