using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace iwopAPP
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
        }

        public List<string> list = new List<string>();
        private Boolean searchStatus = false;
        private Boolean isSearching = false;

        gmImport GMImport = new gmImport();

        TextWriter _writer = null;


        private void Main_Load(object sender, EventArgs e)
        {
            _writer = new TextBoxStreamWriter(txtConsole);
            Console.SetOut(_writer);
        }
        private async void startButton_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.loadData();

            if (settings.apiKey.ToString() == string.Empty)
            {
                MessageBox.Show("Please fill out your Google Maps API Key in settings window!", "API Key missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (filedirectory != null)
                {
                    filePicker.Enabled = false;

                    List<string> webList = settings.websiteList;

                    searchStatus = true;
                    if (!isSearching)
                    {
                        isSearching = true;
                        await SearchData(webList, settings.apiKey);
                    }
                }
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            searchStatus = false;
        }

        private async Task SearchData(List<string> webList, string apiKey)
        {
            int i = 0;
            foreach (var item in list)
            {
                if (searchStatus)
                {
                    i++;
                    await GMImport.Import(item, webList, apiKey);
                    if (GMImport.errorBool)
                    {
                        break;
                        GMImport.errorBool = false;
                    }
                    string result = GMImport.result.ToString();
                    if (result.Contains("/"))
                    {
                        Console.WriteLine($"{i}: {result}");

                        if (!foundTable.Columns.Contains($"href.{webList[0].ToString()}"))
                        {
                            foreach (string web in webList)
                            {
                                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                                column.HeaderText = $"href.{web}";
                                column.Name = $"href.{web}";
                                foundTable.Columns.Add(column);
                            }
                            foreach (string web in webList)
                            {
                                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                                column.HeaderText = $"src.{web}";
                                column.Name = $"src.{web}";
                                foundTable.Columns.Add(column);
                            }
                        }

                        string prepValues = $"{i}; {result}";
                        string[] values = prepValues.Split(';');

                        int inRow = foundTable.Rows.Add();

                        int y = 0;

                        foreach (string value in values)
                        {
                            if (y < foundTable.ColumnCount)
                            {
                                foundTable.Rows[inRow].Cells[y].Value = value.Trim();
                                y++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        string prepValues = $"{i}; {result}";
                        string[] values = prepValues.Split(';');
                        int inRow = notFoundTable.Rows.Add();

                        int y = 0;

                        foreach (string value in values)
                        {
                            if (y < notFoundTable.ColumnCount)
                            {
                                notFoundTable.Rows[inRow].Cells[y].Value = value.Trim();
                                y++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    countLabel.Text = $"{i}/{list.Count.ToString()}";
                    while (!searchStatus)
                    {
                        await Task.Delay(1);
                    }
                }
            }
        }

        public string filedirectory { get; set; }

        private void filePicker_Click(object sender, EventArgs e)
        {
            searchStatus = false;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files (*.xlsx, *.xls)|*.xlsx;*.xls|All Files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filedirectory = ofd.FileName;
                    filedir.Text = filedirectory;
                    ExcelApp excel = new ExcelApp(filedirectory);
                    excel.ShowDialog();

                    list = new List<string>();
                    list = excel.dataList.ToList();
                    countLabel.Text = list.Count.ToString();
                    cellLabel.Text = excel.cellLoc.ToString();
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void export_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add(Missing.Value);

            string sheet1Name = null;
            foreach (Excel.Worksheet sheet in workbook.Sheets)
            {
                sheet1Name = sheet.Name;
            }

            Excel.Worksheet foundSheet = (Excel.Worksheet)workbook.Sheets.Add();
            foundSheet.Name = "Found Data";

            // Dodaj oryginalne nazwy kolumn
            for (int col = 0; col < foundTable.Columns.Count; col++)
            {
                foundSheet.Cells[1, col + 1] = foundTable.Columns[col].HeaderText;
            }

            // Zapisz dane z foundTable do arkusza Excela
            for (int row = 0; row < foundTable.Rows.Count; row++)
            {
                for (int col = 0; col < foundTable.Columns.Count; col++)
                {
                    foundSheet.Cells[row + 2, col + 1] = foundTable.Rows[row].Cells[col].Value?.ToString();
                }
            }

            Excel.Worksheet notFoundSheet = (Excel.Worksheet)workbook.Sheets.Add();
            notFoundSheet.Name = "Not Found Data";

            // Dodaj oryginalne nazwy kolumn
            for (int col = 0; col < notFoundTable.Columns.Count; col++)
            {
                notFoundSheet.Cells[1, col + 1] = notFoundTable.Columns[col].HeaderText;
            }

            // Zapisz dane z notFoundTable do drugiego arkusza Excela
            for (int row = 0; row < notFoundTable.Rows.Count; row++)
            {
                for (int col = 0; col < notFoundTable.Columns.Count; col++)
                {
                    notFoundSheet.Cells[row + 2, col + 1] = notFoundTable.Rows[row].Cells[col].Value?.ToString();
                }
            }

            Excel.Range foundRange = foundSheet.UsedRange;
            Excel.Range notFoundRange = notFoundSheet.UsedRange;

            // Dodaj tabele w arkuszach
            foundRange.Worksheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange,
                foundRange, Type.Missing, Excel.XlYesNoGuess.xlYes, Type.Missing).Name = "FoundTable";

            notFoundRange.Worksheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange,
                notFoundRange, Type.Missing, Excel.XlYesNoGuess.xlYes, Type.Missing).Name = "NotFoundTable";

            if (sheet1Name != null)
            {
                Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[sheet1Name];
                sheet1.Delete();
            }

            // Zapisz plik Excela
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.ShowDialog();

            if (!string.IsNullOrWhiteSpace(saveFileDialog.FileName))
            {
                workbook.SaveAs(saveFileDialog.FileName);
                workbook.Close();
                excelApp.Quit();
                ReleaseObject(foundSheet);
                ReleaseObject(notFoundSheet);
                ReleaseObject(workbook);
                ReleaseObject(excelApp);
                MessageBox.Show("Data saved to excel file!");
            }
        }

        private void ReleaseObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Error during release object: " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void restart_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to restart this application?", "Restart", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string appPath = Application.ExecutablePath;
                Application.Exit();
                Process.Start(appPath);
            }
        }
    }
}