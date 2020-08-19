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
    public partial class Form1 : Form
    {
        private InventoryBUL inventoryBUL = new InventoryBUL();
        List<InventoryDTO> inventoryDTOs = new List<InventoryDTO>();
        public Form1()
        {
            InitializeComponent();
          
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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
            dataGridView1.ColumnCount = 8;
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
            }
           


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            inventoryDTOs = inventoryBUL.DocDanhSachInventory();
            SapXepDuLieuDataGridView(inventoryDTOs);
            HienThiDuLieuLenDataGridView(inventoryDTOs);
            
           
        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {   
            if(e.ColumnIndex == 6)
            HienThiDuLieuLenDataGridView(inventoryDTOs);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexColumn = e.ColumnIndex;
            int indexRow = e.RowIndex;
            if(indexColumn == 7)//remove
            {
                string partName = dataGridView1.Rows[indexRow].Cells[0].Value.ToString();
                string destinationName = dataGridView1.Rows[indexRow].Cells[5].Value.ToString();
                double chenhlechPart = 
                    inventoryBUL.TinhChenhLechTongAmountLoaiHangHoaNhapVaoKhoTheoPartNameVaWareNameVoiMinimumAmountCuaPart(partName, destinationName);
                double amountChuanBiXoa = double.Parse(dataGridView1.Rows[indexRow].Cells[3].Value.ToString());
                if(chenhlechPart < amountChuanBiXoa)
                {
                    MessageBox.Show("Không thể xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    DialogResult a = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (a == DialogResult.Yes)
                    {
                        inventoryBUL.XoaMotDong(inventoryDTOs[indexRow].OrderItemID);
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1_Load(sender, e);
                    }
                }

            }
            
        }
    }
}
