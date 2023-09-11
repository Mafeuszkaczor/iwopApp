namespace iwopAPP
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridWebsites = new DataGridView();
            cancel = new Button();
            label1 = new Label();
            apikeyTB = new TextBox();
            label2 = new Label();
            apply = new Button();
            checkApi = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridWebsites).BeginInit();
            SuspendLayout();
            // 
            // dataGridWebsites
            // 
            dataGridWebsites.AllowUserToResizeRows = false;
            dataGridWebsites.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridWebsites.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridWebsites.Location = new Point(12, 102);
            dataGridWebsites.Name = "dataGridWebsites";
            dataGridWebsites.RowTemplate.Height = 25;
            dataGridWebsites.Size = new Size(280, 158);
            dataGridWebsites.TabIndex = 0;
            // 
            // cancel
            // 
            cancel.Location = new Point(218, 269);
            cancel.Name = "cancel";
            cancel.Size = new Size(75, 23);
            cancel.TabIndex = 1;
            cancel.Text = "Cancel";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += cancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(119, 15);
            label1.TabIndex = 2;
            label1.Text = "GoogleMaps API key:";
            // 
            // apikeyTB
            // 
            apikeyTB.Location = new Point(12, 45);
            apikeyTB.Name = "apikeyTB";
            apikeyTB.Size = new Size(280, 23);
            apikeyTB.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 79);
            label2.Name = "label2";
            label2.Size = new Size(108, 15);
            label2.TabIndex = 4;
            label2.Text = "Websites to search:";
            // 
            // apply
            // 
            apply.Location = new Point(137, 269);
            apply.Name = "apply";
            apply.Size = new Size(75, 23);
            apply.TabIndex = 5;
            apply.Text = "Apply";
            apply.UseVisualStyleBackColor = true;
            apply.Click += apply_Click;
            // 
            // checkApi
            // 
            checkApi.Location = new Point(217, 16);
            checkApi.Name = "checkApi";
            checkApi.Size = new Size(75, 23);
            checkApi.TabIndex = 6;
            checkApi.Text = "Check";
            checkApi.UseVisualStyleBackColor = true;
            checkApi.Click += checkApi_Click;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 301);
            ControlBox = false;
            Controls.Add(checkApi);
            Controls.Add(apply);
            Controls.Add(label2);
            Controls.Add(apikeyTB);
            Controls.Add(label1);
            Controls.Add(cancel);
            Controls.Add(dataGridWebsites);
            MaximumSize = new Size(320, 340);
            MinimumSize = new Size(320, 340);
            Name = "Settings";
            Text = "Settings";
            Load += Settings_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridWebsites).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridWebsites;
        private Button cancel;
        private Label label1;
        private TextBox apikeyTB;
        private Label label2;
        private Button apply;
        private Button checkApi;
    }
}