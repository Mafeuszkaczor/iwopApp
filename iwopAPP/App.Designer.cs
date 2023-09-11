namespace iwopAPP
{
    partial class App
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            filedir = new Label();
            label1 = new Label();
            filePicker = new Button();
            stopButton = new Button();
            export = new Button();
            startButton = new Button();
            label3 = new Label();
            countLabel = new Label();
            cellLabel = new Label();
            txtConsole = new TextBox();
            exitButton = new Button();
            foundTable = new DataGridView();
            No = new DataGridViewTextBoxColumn();
            oppName = new DataGridViewTextBoxColumn();
            address = new DataGridViewTextBoxColumn();
            phone = new DataGridViewTextBoxColumn();
            website = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            notFoundTable = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            settingsButton = new Button();
            restart = new Button();
            ((System.ComponentModel.ISupportInitialize)foundTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)notFoundTable).BeginInit();
            SuspendLayout();
            // 
            // filedir
            // 
            filedir.AutoSize = true;
            filedir.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            filedir.Location = new Point(329, 19);
            filedir.Name = "filedir";
            filedir.Size = new Size(12, 15);
            filedir.TabIndex = 5;
            filedir.Text = "*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(251, 19);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 4;
            label1.Text = "File directory:";
            // 
            // filePicker
            // 
            filePicker.Location = new Point(16, 15);
            filePicker.Name = "filePicker";
            filePicker.Size = new Size(99, 23);
            filePicker.TabIndex = 3;
            filePicker.Text = "Choose file";
            filePicker.UseVisualStyleBackColor = true;
            filePicker.Click += filePicker_Click;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(121, 44);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(99, 23);
            stopButton.TabIndex = 8;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // export
            // 
            export.Location = new Point(575, 44);
            export.Name = "export";
            export.Size = new Size(99, 23);
            export.TabIndex = 9;
            export.Text = "Export";
            export.UseVisualStyleBackColor = true;
            export.Click += export_Click;
            // 
            // startButton
            // 
            startButton.Location = new Point(16, 44);
            startButton.Name = "startButton";
            startButton.Size = new Size(99, 23);
            startButton.TabIndex = 10;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(251, 52);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 11;
            label3.Text = "progress";
            // 
            // countLabel
            // 
            countLabel.AutoSize = true;
            countLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            countLabel.Location = new Point(251, 37);
            countLabel.Name = "countLabel";
            countLabel.Size = new Size(12, 15);
            countLabel.TabIndex = 12;
            countLabel.Text = "*";
            // 
            // cellLabel
            // 
            cellLabel.AutoSize = true;
            cellLabel.Location = new Point(121, 19);
            cellLabel.Name = "cellLabel";
            cellLabel.Size = new Size(0, 15);
            cellLabel.TabIndex = 13;
            // 
            // txtConsole
            // 
            txtConsole.BackColor = SystemColors.MenuText;
            txtConsole.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtConsole.ForeColor = Color.Gainsboro;
            txtConsole.Location = new Point(16, 83);
            txtConsole.Multiline = true;
            txtConsole.Name = "txtConsole";
            txtConsole.ScrollBars = ScrollBars.Vertical;
            txtConsole.Size = new Size(658, 111);
            txtConsole.TabIndex = 14;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(575, 15);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(99, 23);
            exitButton.TabIndex = 17;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // foundTable
            // 
            foundTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            foundTable.Columns.AddRange(new DataGridViewColumn[] { No, oppName, address, phone, website, email });
            foundTable.Location = new Point(16, 224);
            foundTable.Name = "foundTable";
            foundTable.RowTemplate.Height = 25;
            foundTable.Size = new Size(658, 150);
            foundTable.TabIndex = 18;
            // 
            // No
            // 
            No.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            No.HeaderText = "No.";
            No.Name = "No";
            No.Width = 51;
            // 
            // oppName
            // 
            oppName.HeaderText = "oppName";
            oppName.Name = "oppName";
            // 
            // address
            // 
            address.HeaderText = "address";
            address.Name = "address";
            // 
            // phone
            // 
            phone.HeaderText = "phone";
            phone.Name = "phone";
            // 
            // website
            // 
            website.HeaderText = "website";
            website.Name = "website";
            // 
            // email
            // 
            email.HeaderText = "email";
            email.Name = "email";
            // 
            // notFoundTable
            // 
            notFoundTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            notFoundTable.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            notFoundTable.Location = new Point(16, 405);
            notFoundTable.Name = "notFoundTable";
            notFoundTable.RowTemplate.Height = 25;
            notFoundTable.Size = new Size(658, 150);
            notFoundTable.TabIndex = 19;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTextBoxColumn1.HeaderText = "No.";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 51;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTextBoxColumn2.HeaderText = "oppName";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 85;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "address";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "phone";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // settingsButton
            // 
            settingsButton.Location = new Point(470, 15);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(99, 23);
            settingsButton.TabIndex = 20;
            settingsButton.Text = "Settings";
            settingsButton.UseVisualStyleBackColor = true;
            settingsButton.Click += settingsButton_Click;
            // 
            // restart
            // 
            restart.Location = new Point(470, 44);
            restart.Name = "restart";
            restart.Size = new Size(99, 23);
            restart.TabIndex = 21;
            restart.Text = "Restart";
            restart.UseVisualStyleBackColor = true;
            restart.Click += restart_Click;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 571);
            ControlBox = false;
            Controls.Add(restart);
            Controls.Add(settingsButton);
            Controls.Add(notFoundTable);
            Controls.Add(foundTable);
            Controls.Add(exitButton);
            Controls.Add(txtConsole);
            Controls.Add(cellLabel);
            Controls.Add(countLabel);
            Controls.Add(label3);
            Controls.Add(startButton);
            Controls.Add(export);
            Controls.Add(stopButton);
            Controls.Add(filedir);
            Controls.Add(label1);
            Controls.Add(filePicker);
            MaximumSize = new Size(705, 610);
            MinimizeBox = false;
            MinimumSize = new Size(705, 610);
            Name = "App";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "iwopGMD";
            Load += Main_Load;
            ((System.ComponentModel.ISupportInitialize)foundTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)notFoundTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label filedir;
        private Label label1;
        private Button filePicker;
        private Button stopButton;
        private Button export;
        private Button startButton;
        private Label label3;
        private Label countLabel;
        private Label cellLabel;
        private TextBox txtConsole;
        private Button exitButton;
        private DataGridView foundTable;
        private DataGridView notFoundTable;
        private Button settingsButton;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn No;
        private DataGridViewTextBoxColumn oppName;
        private DataGridViewTextBoxColumn address;
        private DataGridViewTextBoxColumn phone;
        private DataGridViewTextBoxColumn website;
        private DataGridViewTextBoxColumn email;
        private Button restart;
    }
}