using System.Windows.Forms;

namespace iwopAPP
{
    partial class ExcelApp
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
            dataTableExcel = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            labelCell = new Label();
            applyButton = new Button();
            valueLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataTableExcel).BeginInit();
            SuspendLayout();
            // 
            // dataTableExcel
            // 
            dataTableExcel.AllowUserToAddRows = false;
            dataTableExcel.AllowUserToDeleteRows = false;
            dataTableExcel.AllowUserToResizeRows = false;
            dataTableExcel.BackgroundColor = SystemColors.ControlLight;
            dataTableExcel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataTableExcel.Location = new Point(12, 51);
            dataTableExcel.Name = "dataTableExcel";
            dataTableExcel.RowHeadersVisible = false;
            dataTableExcel.RowTemplate.Height = 25;
            dataTableExcel.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataTableExcel.Size = new Size(804, 413);
            dataTableExcel.TabIndex = 0;
            dataTableExcel.CellClick += excelTableSelect;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(13, 33);
            label1.Name = "label1";
            label1.Size = new Size(210, 15);
            label1.TabIndex = 1;
            label1.Text = "Click on cell to create a list for checking";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 14);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 2;
            label2.Text = "Selected:";
            // 
            // labelCell
            // 
            labelCell.AutoSize = true;
            labelCell.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelCell.Location = new Point(66, 14);
            labelCell.Name = "labelCell";
            labelCell.Size = new Size(12, 15);
            labelCell.TabIndex = 3;
            labelCell.Text = "*";
            // 
            // applyButton
            // 
            applyButton.Location = new Point(741, 14);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(75, 23);
            applyButton.TabIndex = 4;
            applyButton.Text = "Apply";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += applyButton_Click;
            // 
            // valueLabel
            // 
            valueLabel.AutoSize = true;
            valueLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            valueLabel.Location = new Point(168, 14);
            valueLabel.Margin = new Padding(0, 0, 3, 0);
            valueLabel.MaximumSize = new Size(500, 15);
            valueLabel.MinimumSize = new Size(200, 15);
            valueLabel.Name = "valueLabel";
            valueLabel.Size = new Size(200, 15);
            valueLabel.TabIndex = 6;
            // 
            // ExcelApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(828, 476);
            ControlBox = false;
            Controls.Add(valueLabel);
            Controls.Add(applyButton);
            Controls.Add(labelCell);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataTableExcel);
            MaximumSize = new Size(844, 515);
            MinimumSize = new Size(844, 515);
            Name = "ExcelApp";
            Text = "Excel import";
            ((System.ComponentModel.ISupportInitialize)dataTableExcel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dataTableExcel;

        #endregion

        private DataGridViewTextBoxColumn Column0;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private Label label1;
        private Label label2;
        private Label labelCell;
        private Button applyButton;
        private Label valueLabel;
    }
}