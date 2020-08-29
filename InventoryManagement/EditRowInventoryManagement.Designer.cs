namespace InventoryManagement
{
    partial class EditRowInventoryManagement
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.cbbPartName = new System.Windows.Forms.ComboBox();
            this.cbbTransactionType = new System.Windows.Forms.ComboBox();
            this.cbbSource = new System.Windows.Forms.ComboBox();
            this.cbbDestination = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Part Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Transaction Type";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(75, 81);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(158, 20);
            this.txtAmount.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(607, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Source";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(555, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Destination ";
            // 
            // dpTransactionDate
            // 
            this.dpTransactionDate.CustomFormat = "yyyy/MM/dd";
            this.dpTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpTransactionDate.Location = new System.Drawing.Point(661, 29);
            this.dpTransactionDate.Name = "dpTransactionDate";
            this.dpTransactionDate.Size = new System.Drawing.Size(153, 20);
            this.dpTransactionDate.TabIndex = 3;
            // 
            // cbbPartName
            // 
            this.cbbPartName.FormattingEnabled = true;
            this.cbbPartName.Location = new System.Drawing.Point(75, 25);
            this.cbbPartName.Name = "cbbPartName";
            this.cbbPartName.Size = new System.Drawing.Size(214, 21);
            this.cbbPartName.TabIndex = 4;
            // 
            // cbbTransactionType
            // 
            this.cbbTransactionType.FormattingEnabled = true;
            this.cbbTransactionType.Location = new System.Drawing.Point(400, 26);
            this.cbbTransactionType.Name = "cbbTransactionType";
            this.cbbTransactionType.Size = new System.Drawing.Size(190, 21);
            this.cbbTransactionType.TabIndex = 4;
            // 
            // cbbSource
            // 
            this.cbbSource.FormattingEnabled = true;
            this.cbbSource.Location = new System.Drawing.Point(344, 79);
            this.cbbSource.Name = "cbbSource";
            this.cbbSource.Size = new System.Drawing.Size(190, 21);
            this.cbbSource.TabIndex = 4;
            // 
            // cbbDestination
            // 
            this.cbbDestination.FormattingEnabled = true;
            this.cbbDestination.Location = new System.Drawing.Point(624, 81);
            this.cbbDestination.Name = "cbbDestination";
            this.cbbDestination.Size = new System.Drawing.Size(190, 21);
            this.cbbDestination.TabIndex = 4;
            // 
            // EditRowInventoryManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 143);
            this.Controls.Add(this.cbbDestination);
            this.Controls.Add(this.cbbSource);
            this.Controls.Add(this.cbbTransactionType);
            this.Controls.Add(this.cbbPartName);
            this.Controls.Add(this.dpTransactionDate);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "EditRowInventoryManagement";
            this.Text = "EditRowInventoryManagement";
            this.Load += new System.EventHandler(this.EditRowInventoryManagement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dpTransactionDate;
        private System.Windows.Forms.ComboBox cbbPartName;
        private System.Windows.Forms.ComboBox cbbTransactionType;
        private System.Windows.Forms.ComboBox cbbSource;
        private System.Windows.Forms.ComboBox cbbDestination;
    }
}