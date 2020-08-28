using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BULs;
using DTOs;

namespace InventoryManagement
{
    public partial class InventoryManagement : Form
    {
        private InventoryBUL inventoryBUL = new InventoryBUL();
        private OrderItemsBUL orderItemsBUL = new OrderItemsBUL();
        List<InventoryDTO> inventoryDTOs = new List<InventoryDTO>();
        public InventoryManagement()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            InventoryReport inventoryReport = new InventoryReport();
            inventoryReport.ShowDialog();

            this.WindowState = FormWindowState.Normal;
            showDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            PurchaseOrder purchaseOrderForm = new PurchaseOrder();
            purchaseOrderForm.ShowDialog();

            this.WindowState = FormWindowState.Normal;
            showDataGridView();
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void SapXepDuLieuDataGridView(List<InventoryDTO> inventoryDTOs)
        {
            for (int i = 0; i < inventoryDTOs.Count; i++)
            {
                for (int j = i + 1; j < inventoryDTOs.Count; j++)
                {
                    if (inventoryDTOs[i].CompareTo(inventoryDTOs[j]) == 1)
                    {
                        InventoryDTO temp = inventoryDTOs[i];
                        inventoryDTOs[i] = inventoryDTOs[j];
                        inventoryDTOs[j] = temp;
                    }
                }
            }
        }
        private void HienThiDuLieuLenDataGridView(List<InventoryDTO> inventoryDTOs)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 9;
            for (int i = 0; i < inventoryDTOs.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = inventoryDTOs[i].PartName;
                dataGridView1.Rows[i].Cells[1].Value = inventoryDTOs[i].TransactionType;
                dataGridView1.Rows[i].Cells[2].Value = inventoryDTOs[i].TransactionDate.ToString("yyyy-MM-dd");
                dataGridView1.Rows[i].Cells[3].Value = inventoryDTOs[i].Amount;
                if (inventoryDTOs[i].TransactionType == "Purchase Order")
                {
                    dataGridView1.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                }
                dataGridView1.Rows[i].Cells[4].Value = inventoryDTOs[i].Source;
                dataGridView1.Rows[i].Cells[5].Value = inventoryDTOs[i].Destination;
                dataGridView1.Rows[i].Cells[6].Value = "edit";
                dataGridView1.Rows[i].Cells[7].Value = "remove";
                dataGridView1.Rows[i].Cells[8].Value = inventoryDTOs[i].OrderItemID;
            }
               
           
       
        }
        void showDataGridView()
        {
            inventoryDTOs = inventoryBUL.DocDanhSachInventory();
            SapXepDuLieuDataGridView(inventoryDTOs);
            HienThiDuLieuLenDataGridView(inventoryDTOs);
        }
        int checkHienThiHeader = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            showDataGridView();
            checkHienThiHeader++;
            if(checkHienThiHeader == 1)
            {
                dataGridView1.ColumnHeadersHeight = dataGridView1.ColumnHeadersHeight * 2;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);
                dataGridView1.Paint += new PaintEventHandler(dataGridView1_Paint);
                dataGridView1.Scroll += new ScrollEventHandler(dataGridView1_Scroll);
                dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(dataGridView1_ColumnWidthChanged);
            }
        }
        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r1 = dataGridView1.GetCellDisplayRectangle(6, -1, true);
            int w2 = dataGridView1.GetCellDisplayRectangle(7, -1, true).Width;
            r1.X += 1;
            r1.Y += 1;
            r1.Width = r1.Width + w2;
            r1.Height = r1.Height-2;
            e.Graphics.FillRectangle(new SolidBrush(Color.White), r1);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString("Actions", dataGridView1.ColumnHeadersDefaultCellStyle.Font,
                new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor), r1, format);
        }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = dataGridView1.DisplayRectangle;
            rtHeader.Height = dataGridView1.ColumnHeadersHeight / 2 - 10;
            dataGridView1.Invalidate(rtHeader);
        }
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = dataGridView1.DisplayRectangle;
            rtHeader.Height = dataGridView1.ColumnHeadersHeight / 2 - 10;
            dataGridView1.Invalidate(rtHeader);
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height += e.CellBounds.Height / 2;
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }
        }
        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {   
            if(e.ColumnIndex == 6)
            HienThiDuLieuLenDataGridView(inventoryDTOs);
        }
        int nut0 = 0, nut1 = 0, nut2 = 0, nut3 = 0, nut4 = 0, nut5 = 0;
        private void setDefaultHeaderDataGridView()
        {
            dataGridView1.Columns[0].HeaderText = "Part Name";
            dataGridView1.Columns[1].HeaderText = "Transaction Type";
            dataGridView1.Columns[2].HeaderText = "Date";
            dataGridView1.Columns[3].HeaderText = "Amount";
            dataGridView1.Columns[4].HeaderText = "Source";
            dataGridView1.Columns[5].HeaderText = "Destination";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexColumn = e.ColumnIndex;
            int indexRow = e.RowIndex;
           if(indexRow >= 0)
            {
                if (indexColumn == 7)//remove
                {
                    string partName = dataGridView1.Rows[indexRow].Cells[0].Value.ToString();
                    string destinationName = dataGridView1.Rows[indexRow].Cells[5].Value.ToString();
                    string orderItemID = dataGridView1.Rows[indexRow].Cells[8].Value.ToString();
                    string batchNumber = orderItemsBUL.TimBatchNumberBangID(orderItemID);
                    double chenhlechPart =
                        inventoryBUL.TinhChenhLechTongAmountLoaiHangHoaNhapVaoKhoTheoPartNameVaWareNameVoiMinimumAmountCuaPart(partName, destinationName, batchNumber);
                    double amountChuanBiXoa = double.Parse(dataGridView1.Rows[indexRow].Cells[3].Value.ToString());
                    if (chenhlechPart < amountChuanBiXoa)
                    {
                        MessageBox.Show("Can't remove this record ! If remove this record, the inventory of a part in "+destinationName +" negative "+(amountChuanBiXoa-chenhlechPart) +"! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DialogResult a = MessageBox.Show("Are you sure delete this record?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (a == DialogResult.Yes)
                        {

                            inventoryBUL.XoaMotDong(orderItemID);
                            MessageBox.Show("Successfully! Record has been deleted!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            showDataGridView();
                        }
                    }

                }
            }
           else
            {   
                
                switch (indexColumn)
                {   
                    case 0:
                        {
                            setDefaultHeaderDataGridView();
                            nut1 = 0; nut2 = 0;nut3 = 0;nut4 = 0;nut5 = 0;
                            nut0++;
                           
                            if(nut0 == 3)
                            {
                                nut0 = 0;
                                showDataGridView();
                                dataGridView1.Columns[0].HeaderText = "Part Name";
                            }
                            else if(nut0 == 2)
                            {
                                dataGridView1.Columns[0].HeaderText = "🔼  Part Name";
                                for(int i = 0; i < this.inventoryDTOs.Count; i++)
                                {
                                    for(int j=i+1; j< this.inventoryDTOs.Count; j++)
                                    {
                                        if( String.Compare(this.inventoryDTOs[i].PartName, this.inventoryDTOs[j].PartName) > 0)
                                        {
                                            InventoryDTO temp = inventoryDTOs[i];
                                            inventoryDTOs[i] = inventoryDTOs[j];
                                            inventoryDTOs[j] = temp;
                                        }
                                    }
                                }
                                HienThiDuLieuLenDataGridView(this.inventoryDTOs);


                            } else if(nut0 == 1)
                            {
                                dataGridView1.Columns[0].HeaderText = "🔽  Part Name";
                                for (int i = 0; i < this.inventoryDTOs.Count; i++)
                                {
                                    for (int j = i + 1; j < this.inventoryDTOs.Count; j++)
                                    {
                                        if (String.Compare(this.inventoryDTOs[i].PartName, this.inventoryDTOs[j].PartName) < 0)
                                        {
                                            InventoryDTO temp = inventoryDTOs[i];
                                            inventoryDTOs[i] = inventoryDTOs[j];
                                            inventoryDTOs[j] = temp;
                                        }
                                    }
                                }
                                HienThiDuLieuLenDataGridView(this.inventoryDTOs);
                            }
                           
                        } break;
                    case 1:
                        {
                            setDefaultHeaderDataGridView();
                            nut0 = 0; nut2 = 0; nut3 = 0; nut4 = 0; nut5 = 0;
                            nut1++;
                            if (nut1 == 3)
                            {
                                nut1 = 0;
                                showDataGridView();
                                dataGridView1.Columns[1].HeaderText = "Transaction Type";
                            }
                            else if (nut1 == 2)
                            {
                                dataGridView1.Columns[1].HeaderText = "🔼  Transaction Type";
                                for (int i = 0; i < this.inventoryDTOs.Count; i++)
                                {
                                    for (int j = i + 1; j < this.inventoryDTOs.Count; j++)
                                    {
                                        if (String.Compare(this.inventoryDTOs[i].TransactionType, this.inventoryDTOs[j].TransactionType) > 0)
                                        {
                                            InventoryDTO temp = inventoryDTOs[i];
                                            inventoryDTOs[i] = inventoryDTOs[j];
                                            inventoryDTOs[j] = temp;
                                        }
                                    }
                                }
                                HienThiDuLieuLenDataGridView(this.inventoryDTOs);


                            }
                            else if (nut1 == 1)
                            {
                                dataGridView1.Columns[1].HeaderText = "🔽  Transaction Type";
                                for (int i = 0; i < this.inventoryDTOs.Count; i++)
                                {
                                    for (int j = i + 1; j < this.inventoryDTOs.Count; j++)
                                    {
                                        if (String.Compare(this.inventoryDTOs[i].TransactionType, this.inventoryDTOs[j].TransactionType) < 0)
                                        {
                                            InventoryDTO temp = inventoryDTOs[i];
                                            inventoryDTOs[i] = inventoryDTOs[j];
                                            inventoryDTOs[j] = temp;
                                        }
                                    }
                                }
                                HienThiDuLieuLenDataGridView(this.inventoryDTOs);
                            }
                            break;
                        }
                    case 2:
                        {
                            setDefaultHeaderDataGridView();
                            nut0 = 0; nut1 = 0; nut3 = 0; nut4 = 0; nut5 = 0;
                            nut2++;
                            if (nut2 == 3)
                            {
                                nut2 = 0;
                                showDataGridView();
                                dataGridView1.Columns[2].HeaderText = "Date";
                            }
                            else if (nut2 == 2)
                            {
                                dataGridView1.Columns[2].HeaderText = "🔼 Date";
                                for (int i = 0; i < this.inventoryDTOs.Count; i++)
                                {
                                    for (int j = i + 1; j < this.inventoryDTOs.Count; j++)
                                    {
                                        if (this.inventoryDTOs[i].TransactionDate > this.inventoryDTOs[j].TransactionDate)
                                        {
                                            InventoryDTO temp = inventoryDTOs[i];
                                            inventoryDTOs[i] = inventoryDTOs[j];
                                            inventoryDTOs[j] = temp;
                                        }
                                    }
                                }
                                HienThiDuLieuLenDataGridView(this.inventoryDTOs);

                            }
                            else if (nut2 == 1)
                            {
                                dataGridView1.Columns[2].HeaderText = "🔽 Date";
                                for (int i = 0; i < this.inventoryDTOs.Count; i++)
                                {
                                    for (int j = i + 1; j < this.inventoryDTOs.Count; j++)
                                    {
                                        if (this.inventoryDTOs[i].TransactionDate < this.inventoryDTOs[j].TransactionDate)
                                        {
                                            InventoryDTO temp = inventoryDTOs[i];
                                            inventoryDTOs[i] = inventoryDTOs[j];
                                            inventoryDTOs[j] = temp;
                                        }
                                    }
                                }
                                HienThiDuLieuLenDataGridView(this.inventoryDTOs);
                            }
                             break;
                        }
                    case 3:
                        {
                            nut0 = 0; nut1 = 0; nut2 = 0; nut4 = 0; nut5 = 0;
                            setDefaultHeaderDataGridView();
                            nut3++;
                            if (nut3 == 3)
                            {
                                nut3 = 0;
                                showDataGridView();
                                dataGridView1.Columns[3].HeaderText = "Amount";
                            }
                            else if (nut3 == 2)
                            {
                                dataGridView1.Columns[3].HeaderText = "🔼  Amount";
                                for (int i = 0; i < this.inventoryDTOs.Count; i++)
                                {
                                    for (int j = i + 1; j < this.inventoryDTOs.Count; j++)
                                    {
                                        if (this.inventoryDTOs[i].Amount > this.inventoryDTOs[j].Amount)
                                        {
                                            InventoryDTO temp = inventoryDTOs[i];
                                            inventoryDTOs[i] = inventoryDTOs[j];
                                            inventoryDTOs[j] = temp;
                                        }
                                    }
                                }
                                HienThiDuLieuLenDataGridView(this.inventoryDTOs);

                            }
                            else if (nut3 == 1)
                            {
                                dataGridView1.Columns[3].HeaderText = "🔽  Amount";
                                for (int i = 0; i < this.inventoryDTOs.Count; i++)
                                {
                                    for (int j = i + 1; j < this.inventoryDTOs.Count; j++)
                                    {
                                        if (this.inventoryDTOs[i].Amount < this.inventoryDTOs[j].Amount)
                                        {
                                            InventoryDTO temp = inventoryDTOs[i];
                                            inventoryDTOs[i] = inventoryDTOs[j];
                                            inventoryDTOs[j] = temp;
                                        }
                                    }
                                }
                                HienThiDuLieuLenDataGridView(this.inventoryDTOs);
                            }
                             break;
                        }
                    case 4:
                        {
                            nut0 = 0; nut1 = 0; nut2 = 0; nut3 = 0; nut5 = 0;
                            setDefaultHeaderDataGridView();
                            nut4++;
                            if (nut4 == 3)
                            {
                                nut4 = 0;
                                showDataGridView();
                                dataGridView1.Columns[4].HeaderText = "Source";
                            }
                            else if (nut4 == 2)
                            {
                                dataGridView1.Columns[4].HeaderText = "🔼  Source";
                                for (int i = 0; i < this.inventoryDTOs.Count; i++)
                                {
                                    for (int j = i + 1; j < this.inventoryDTOs.Count; j++)
                                    {
                                        if (String.Compare(this.inventoryDTOs[i].Source, this.inventoryDTOs[j].Source) > 0)
                                        {
                                            InventoryDTO temp = inventoryDTOs[i];
                                            inventoryDTOs[i] = inventoryDTOs[j];
                                            inventoryDTOs[j] = temp;
                                        }
                                    }
                                }
                                HienThiDuLieuLenDataGridView(this.inventoryDTOs);

                            }
                            else if (nut4 == 1)
                            {
                                dataGridView1.Columns[4].HeaderText = "🔽  Source";
                                for (int i = 0; i < this.inventoryDTOs.Count; i++)
                                {
                                    for (int j = i + 1; j < this.inventoryDTOs.Count; j++)
                                    {
                                        if (String.Compare(this.inventoryDTOs[i].Source, this.inventoryDTOs[j].Source) < 0)
                                        {
                                            InventoryDTO temp = inventoryDTOs[i];
                                            inventoryDTOs[i] = inventoryDTOs[j];
                                            inventoryDTOs[j] = temp;
                                        }
                                    }
                                }
                                HienThiDuLieuLenDataGridView(this.inventoryDTOs);
                            }
                             break;
                        }
                    case 5:
                        {
                            nut0 = 0; nut1 = 0; nut2 = 0; nut3 = 0; nut4 = 0;
                            setDefaultHeaderDataGridView();
                            nut5++;
                            if (nut5 == 3)
                            {
                                nut5 = 0;
                                showDataGridView();
                                dataGridView1.Columns[5].HeaderText = "Destination";
                            }
                            else if (nut5 == 2)
                            {
                                dataGridView1.Columns[5].HeaderText = "🔼  Destination";
                                for (int i = 0; i < this.inventoryDTOs.Count; i++)
                                {
                                    for (int j = i + 1; j < this.inventoryDTOs.Count; j++)
                                    {
                                        if (String.Compare(this.inventoryDTOs[i].Destination, this.inventoryDTOs[j].Destination) > 0)
                                        {
                                            InventoryDTO temp = inventoryDTOs[i];
                                            inventoryDTOs[i] = inventoryDTOs[j];
                                            inventoryDTOs[j] = temp;
                                        }
                                    }
                                }
                                HienThiDuLieuLenDataGridView(this.inventoryDTOs);

                            }
                            else if (nut5 == 1)
                            {
                                dataGridView1.Columns[5].HeaderText = "🔽  Destination";
                                for (int i = 0; i < this.inventoryDTOs.Count; i++)
                                {
                                    for (int j = i + 1; j < this.inventoryDTOs.Count; j++)
                                    {
                                        if (String.Compare(this.inventoryDTOs[i].Destination, this.inventoryDTOs[j].Destination) < 0)
                                        {
                                            InventoryDTO temp = inventoryDTOs[i];
                                            inventoryDTOs[i] = inventoryDTOs[j];
                                            inventoryDTOs[j] = temp;
                                        }
                                    }
                                }
                                HienThiDuLieuLenDataGridView(this.inventoryDTOs);
                            }
                            break;
                        }


                    default:
                        break;
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            WarehouseManagement warehouseManagementForm = new WarehouseManagement();
            warehouseManagementForm.ShowDialog();
            this.WindowState = FormWindowState.Normal;
            Form1_Load(sender, e);
        }
    }
}
