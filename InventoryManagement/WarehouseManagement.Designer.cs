namespace InventoryManagement
{
    partial class WarehouseManagement
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
            this.Sou = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbSourceWarehouse = new System.Windows.Forms.ComboBox();
            this.cbbDestinationWarehouse = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnPartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBatchNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAction = new System.Windows.Forms.DataGridViewLinkColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbBatchNumber = new System.Windows.Forms.ComboBox();
            this.cbbPartName = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Sou
            // 
            this.Sou.AutoSize = true;
            this.Sou.Location = new System.Drawing.Point(44, 31);
            this.Sou.Name = "Sou";
            this.Sou.Size = new System.Drawing.Size(102, 13);
            this.Sou.TabIndex = 0;
            this.Sou.Text = "Source Warehouse:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(458, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destination Warehouse:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Date:";
            // 
            // cbbSourceWarehouse
            // 
            this.cbbSourceWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSourceWarehouse.FormattingEnabled = true;
            this.cbbSourceWarehouse.Location = new System.Drawing.Point(47, 48);
            this.cbbSourceWarehouse.Name = "cbbSourceWarehouse";
            this.cbbSourceWarehouse.Size = new System.Drawing.Size(239, 21);
            this.cbbSourceWarehouse.TabIndex = 2;
            this.cbbSourceWarehouse.DropDownClosed += new System.EventHandler(this.cbbSourceWarehouse_DropDownClosed);
            // 
            // cbbDestinationWarehouse
            // 
            this.cbbDestinationWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDestinationWarehouse.FormattingEnabled = true;
            this.cbbDestinationWarehouse.Location = new System.Drawing.Point(461, 48);
            this.cbbDestinationWarehouse.Name = "cbbDestinationWarehouse";
            this.cbbDestinationWarehouse.Size = new System.Drawing.Size(241, 21);
            this.cbbDestinationWarehouse.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(86, 100);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(108, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbbBatchNumber);
            this.groupBox1.Controls.Add(this.cbbPartName);
            this.groupBox1.Location = new System.Drawing.Point(13, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 265);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Parts List ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPartName,
            this.ColumnBatchNumber,
            this.ColumnAmount,
            this.ColumnAction});
            this.dataGridView1.Location = new System.Drawing.Point(6, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(763, 180);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ColumnPartName
            // 
            this.ColumnPartName.HeaderText = "Part Name";
            this.ColumnPartName.Name = "ColumnPartName";
            this.ColumnPartName.Width = 240;
            // 
            // ColumnBatchNumber
            // 
            this.ColumnBatchNumber.HeaderText = "Batch Number";
            this.ColumnBatchNumber.Name = "ColumnBatchNumber";
            this.ColumnBatchNumber.Width = 180;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.HeaderText = "Amount";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.Width = 179;
            // 
            // ColumnAction
            // 
            this.ColumnAction.ActiveLinkColor = System.Drawing.Color.Blue;
            this.ColumnAction.HeaderText = "Action";
            this.ColumnAction.Name = "ColumnAction";
            this.ColumnAction.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnAction.VisitedLinkColor = System.Drawing.Color.Blue;
            this.ColumnAction.Width = 120;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(694, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "+ Add to list";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(607, 30);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(82, 20);
            this.txtAmount.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(555, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Amount:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Batch Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Part Name:";
            // 
            // cbbBatchNumber
            // 
            this.cbbBatchNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBatchNumber.FormattingEnabled = true;
            this.cbbBatchNumber.Location = new System.Drawing.Point(425, 29);
            this.cbbBatchNumber.Name = "cbbBatchNumber";
            this.cbbBatchNumber.Size = new System.Drawing.Size(124, 21);
            this.cbbBatchNumber.TabIndex = 2;
            this.cbbBatchNumber.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbbBatchNumber_MouseClick);
            // 
            // cbbPartName
            // 
            this.cbbPartName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPartName.FormattingEnabled = true;
            this.cbbPartName.Location = new System.Drawing.Point(84, 30);
            this.cbbPartName.Name = "cbbPartName";
            this.cbbPartName.Size = new System.Drawing.Size(251, 21);
            this.cbbPartName.TabIndex = 2;
            this.cbbPartName.DropDownClosed += new System.EventHandler(this.cbbPartName_DropDownClosed);
            this.cbbPartName.TextChanged += new System.EventHandler(this.cbbPartName_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(224, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Submit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(504, 415);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // WarehouseManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cbbDestinationWarehouse);
            this.Controls.Add(this.cbbSourceWarehouse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Sou);
            this.Name = "WarehouseManagement";
            this.Text = "Warehouse Management";
            this.Load += new System.EventHandler(this.WarehouseManagement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Sou;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbSourceWarehouse;
        private System.Windows.Forms.ComboBox cbbDestinationWarehouse;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbBatchNumber;
        private System.Windows.Forms.ComboBox cbbPartName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBatchNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnAction;
    }
}