using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using excel = Microsoft.Office.Interop.Excel;

namespace iwopAPP
{
    public partial class ExcelApp : Form
    {
        public ExcelApp(string filedir)
        {
            InitializeComponent();
            UploadFile(filedir);
        }

        public List<string> dataList = new List<string>();
        public string cellLoc = string.Empty;

        public void UploadFile(string file)
        {
            ExcelFileUpload(file);
        }

        private void excelTableSelect(object sender, DataGridViewCellEventArgs e)
        {
            dataList.Clear();
            foreach (DataGridViewRow row in dataTableExcel.Rows)
            {
                if (row.Index >= e.RowIndex)
                {
                    if (row.Cells[e.ColumnIndex].Value.ToString() != "")
                    {
                        dataList.Add(row.Cells[e.ColumnIndex].Value.ToString());
                    }
                }
            }
            cellLoc = $"col {e.ColumnIndex} / row {e.RowIndex}";
            labelCell.Text = cellLoc;
            valueLabel.Text = $"List created from: {dataList[0]}";
        }

        public void ExcelFileUpload(string filedir)
        {
            excel.Application xlApp;
            excel.Workbook xlWorkbook;
            excel.Worksheet xlWorksheet;
            excel.Range xlRange;

            DataTable tempTable = new DataTable();

            if (filedir != null)
            {
                xlApp = new excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(filedir);
                xlWorksheet = xlWorkbook.Worksheets[1];
                xlRange = xlWorksheet.UsedRange;

                object[,] excelData = (object[,])xlRange.Value;

                int numRows = excelData.GetLength(0);
                int numCols = excelData.GetLength(1);

                for (int col = 1; col <= numCols; col++)
                {
                    tempTable.Columns.Add("Column " + col);
                }

                for (int row = 1; row <= numRows; row++)
                {
                    DataRow dataRow = tempTable.NewRow();
                    for (int col = 1; col <= numCols; col++)
                    {
                        dataRow[col - 1] = excelData[row, col];
                    }
                    tempTable.Rows.Add(dataRow);
                }
                xlWorkbook.Close();
                xlApp.Quit();
            }
            dataTableExcel.DataSource = tempTable;
            dataTableExcel.AutoGenerateColumns = true;
            dataTableExcel.Refresh();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
