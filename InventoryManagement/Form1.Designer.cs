namespace InventoryManagement
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnPartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTransactionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDestination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ActionDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(-4, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(996, 34);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(369, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(159, 31);
            this.button3.TabIndex = 0;
            this.button3.TabStop = false;
            this.button3.Text = "Inventory Report";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(198, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 31);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Text = "Warehouse Management";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Purchase Order Management";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPartName,
            this.ColumnTransactionType,
            this.ColumnDate,
            this.ColumnAmount,
            this.ColumnSource,
            this.ColumnDestination,
            this.ActionEdit,
            this.ActionDelete});
            this.dataGridView1.Location = new System.Drawing.Point(11, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(956, 402);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseDoubleClick);
            // 
            // ColumnPartName
            // 
            this.ColumnPartName.HeaderText = "Part Name";
            this.ColumnPartName.Name = "ColumnPartName";
            this.ColumnPartName.Width = 196;
            // 
            // ColumnTransactionType
            // 
            this.ColumnTransactionType.HeaderText = "Transaction Type";
            this.ColumnTransactionType.MaxInputLength = 45000;
            this.ColumnTransactionType.Name = "ColumnTransactionType";
            this.ColumnTransactionType.Width = 150;
            // 
            // ColumnDate
            // 
            this.ColumnDate.HeaderText = "Date";
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.Width = 90;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.HeaderText = "Amount";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.Width = 80;
            // 
            // ColumnSource
            // 
            this.ColumnSource.HeaderText = "Source";
            this.ColumnSource.Name = "ColumnSource";
            this.ColumnSource.Width = 120;
            // 
            // ColumnDestination
            // 
            this.ColumnDestination.HeaderText = "Destination";
            this.ColumnDestination.Name = "ColumnDestination";
            this.ColumnDestination.Width = 150;
            // 
            // ActionEdit
            // 
            this.ActionEdit.HeaderText = "Actions";
            this.ActionEdit.Name = "ActionEdit";
            this.ActionEdit.Text = "Edit";
            this.ActionEdit.Width = 50;
            // 
            // ActionDelete
            // 
            this.ActionDelete.HeaderText = "";
            this.ActionDelete.Name = "ActionDelete";
            this.ActionDelete.Text = "Remove";
            this.ActionDelete.Width = 60;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 493);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Inventory Management";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTransactionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDestination;
        private System.Windows.Forms.DataGridViewLinkColumn ActionEdit;
        private System.Windows.Forms.DataGridViewLinkColumn ActionDelete;
    }
}

