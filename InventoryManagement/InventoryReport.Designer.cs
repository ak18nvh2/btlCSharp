namespace InventoryManagement
{
    partial class InventoryReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.session4DataSet1 = new DALs.Session4DataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbWarehouse = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnCurrentStock = new System.Windows.Forms.RadioButton();
            this.rbtnReceivedStock = new System.Windows.Forms.RadioButton();
            this.rbtnOutOfStock = new System.Windows.Forms.RadioButton();
            this.grvResult = new System.Windows.Forms.DataGridView();
            this.ColumnPartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceivedStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAction = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.session4DataSet1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Warehouse:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // session4DataSet1
            // 
            this.session4DataSet1.DataSetName = "Session4DataSet";
            this.session4DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Result:";
            // 
            // cbbWarehouse
            // 
            this.cbbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWarehouse.FormattingEnabled = true;
            this.cbbWarehouse.Location = new System.Drawing.Point(12, 67);
            this.cbbWarehouse.Name = "cbbWarehouse";
            this.cbbWarehouse.Size = new System.Drawing.Size(312, 21);
            this.cbbWarehouse.TabIndex = 1;
            this.cbbWarehouse.DropDownClosed += new System.EventHandler(this.cbbWarehouse_DropDownClosed);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnOutOfStock);
            this.groupBox1.Controls.Add(this.rbtnReceivedStock);
            this.groupBox1.Controls.Add(this.rbtnCurrentStock);
            this.groupBox1.Location = new System.Drawing.Point(330, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 54);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inventory Report";
            // 
            // rbtnCurrentStock
            // 
            this.rbtnCurrentStock.AutoSize = true;
            this.rbtnCurrentStock.Location = new System.Drawing.Point(23, 19);
            this.rbtnCurrentStock.Name = "rbtnCurrentStock";
            this.rbtnCurrentStock.Size = new System.Drawing.Size(90, 17);
            this.rbtnCurrentStock.TabIndex = 0;
            this.rbtnCurrentStock.TabStop = true;
            this.rbtnCurrentStock.Text = "Current Stock";
            this.rbtnCurrentStock.UseVisualStyleBackColor = true;
            this.rbtnCurrentStock.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbtnReceivedStock
            // 
            this.rbtnReceivedStock.AutoSize = true;
            this.rbtnReceivedStock.Location = new System.Drawing.Point(184, 19);
            this.rbtnReceivedStock.Name = "rbtnReceivedStock";
            this.rbtnReceivedStock.Size = new System.Drawing.Size(102, 17);
            this.rbtnReceivedStock.TabIndex = 1;
            this.rbtnReceivedStock.TabStop = true;
            this.rbtnReceivedStock.Text = "Received Stock";
            this.rbtnReceivedStock.UseVisualStyleBackColor = true;
            this.rbtnReceivedStock.CheckedChanged += new System.EventHandler(this.rbtnReceivedStock_CheckedChanged);
            // 
            // rbtnOutOfStock
            // 
            this.rbtnOutOfStock.AutoSize = true;
            this.rbtnOutOfStock.Location = new System.Drawing.Point(330, 19);
            this.rbtnOutOfStock.Name = "rbtnOutOfStock";
            this.rbtnOutOfStock.Size = new System.Drawing.Size(85, 17);
            this.rbtnOutOfStock.TabIndex = 2;
            this.rbtnOutOfStock.TabStop = true;
            this.rbtnOutOfStock.Text = "Out of Stock";
            this.rbtnOutOfStock.UseVisualStyleBackColor = true;
            this.rbtnOutOfStock.CheckedChanged += new System.EventHandler(this.rbtnOutOfStock_CheckedChanged);
            // 
            // grvResult
            // 
            this.grvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPartName,
            this.ColumnCurrentStock,
            this.ColumnReceivedStock,
            this.ColumnAction});
            this.grvResult.Location = new System.Drawing.Point(12, 149);
            this.grvResult.Name = "grvResult";
            this.grvResult.Size = new System.Drawing.Size(776, 267);
            this.grvResult.TabIndex = 3;
            this.grvResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ColumnPartName
            // 
            this.ColumnPartName.HeaderText = "Part Name";
            this.ColumnPartName.Name = "ColumnPartName";
            this.ColumnPartName.Width = 250;
            // 
            // ColumnCurrentStock
            // 
            this.ColumnCurrentStock.HeaderText = "Current Stock";
            this.ColumnCurrentStock.Name = "ColumnCurrentStock";
            this.ColumnCurrentStock.Width = 150;
            // 
            // ColumnReceivedStock
            // 
            this.ColumnReceivedStock.HeaderText = "Received Stock";
            this.ColumnReceivedStock.Name = "ColumnReceivedStock";
            this.ColumnReceivedStock.Width = 150;
            // 
            // ColumnAction
            // 
            this.ColumnAction.HeaderText = "Action";
            this.ColumnAction.Name = "ColumnAction";
            this.ColumnAction.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnAction.Width = 183;
            // 
            // InventoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 438);
            this.Controls.Add(this.grvResult);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbbWarehouse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InventoryReport";
            this.Text = "Inventory Report";
            this.Load += new System.EventHandler(this.InventoryReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.session4DataSet1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DALs.Session4DataSet session4DataSet1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbWarehouse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnOutOfStock;
        private System.Windows.Forms.RadioButton rbtnReceivedStock;
        private System.Windows.Forms.RadioButton rbtnCurrentStock;
        private System.Windows.Forms.DataGridView grvResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceivedStock;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnAction;
    }
}