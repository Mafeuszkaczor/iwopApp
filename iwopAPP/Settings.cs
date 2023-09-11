using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;

namespace iwopAPP
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        public string apiKey = string.Empty;
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public List<string> websiteList = new List<string>();

        public void loadData()
        {
            try
            {
                if (File.Exists("data.xml"))
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXml("data.xml");
                    dataGridWebsites.Columns.Clear();
                    try
                    {
                        dataGridWebsites.DataSource = dataSet.Tables[0];
                    }
                    catch
                    {
                        dataGridWebsites.Columns.Add("websites", "websites");
                    }
                    apikeyTB.Text = dataSet.Tables[1].Rows[0][0].ToString();

                    foreach (DataGridViewRow row in dataGridWebsites.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            websiteList.Add(row.Cells[0].Value.ToString());
                        }
                    }
                }
                else
                {
                    dataGridWebsites.Columns.Add("websites", "websites");
                }
                apiKey = apikeyTB.Text;
            }
            catch
            {
                DialogResult result = MessageBox.Show("data.xml is broken\ndo you want to delete this file?", "Loading data failed", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete("data.xml");
                        MessageBox.Show("data.xml deleted", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridWebsites.Columns.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Can't delete data.xml file: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                dataGridWebsites.Columns.Add("websites", "websites");
            }
        }

        public void Settings_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void apply_Click(object sender, EventArgs e)
        {
            DataTable dataTable = getDataTableFromDGV(dataGridWebsites);
            DataTable apiKey = new DataTable();
            apiKey.Columns.Add("apiKey");
            apiKey.Rows.Add(apikeyTB.Text);

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);
            dataSet.Tables.Add(apiKey);
            File.Delete("data.xml");
            dataSet.WriteXml("data.xml");
            this.Close();
        }

        private DataTable getDataTableFromDGV(DataGridView dgv)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add(dgv.Columns[0].Name.ToString());
            object[] cellValues = new object[dgv.Columns.Count];

            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRow newRow = dataTable.NewRow();

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (row.Cells[i].Value != null)
                    {
                        newRow[i] = row.Cells[i].Value.ToString();
                        dataTable.Rows.Add(newRow);
                    }
                }
            }
            return dataTable;
        }

        private async void checkApi_Click(object sender, EventArgs e)
        {
            await apiResponse();
        }
        private async Task apiResponse()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address=test&key={apikeyTB.Text}";

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        JObject json = JObject.Parse(responseBody);

                        if (responseBody.Contains("error_message"))
                        {
                            string errormessage = json["error_message"].ToString();
                            MessageBox.Show($"{errormessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show($"Google maps api key is valid", "API", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
