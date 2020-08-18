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

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private InventoryBUL inventoryBUL = new InventoryBUL();
        private void Form1_Load(object sender, EventArgs e)
        {   
            
            List<InventoryDTO> inventoryDTOs = inventoryBUL.DocDanhSachInventory();
            for(int i=0; i< inventoryDTOs.Count; i++)
            {   
                for(int j=i+1; j<inventoryDTOs.Count; j++)
                {
                    if (inventoryDTOs[i].CompareTo(inventoryDTOs[j]) == 1)
                    {
                        InventoryDTO temp = inventoryDTOs[i];
                        inventoryDTOs[i] = inventoryDTOs[j];
                        inventoryDTOs[j] = temp;
                    }
                        
                            
                }
               
            }
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 7;
            for(int i=0; i<inventoryDTOs.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = inventoryDTOs[i].PartName;
                dataGridView1.Rows[i].Cells[1].Value = inventoryDTOs[i].TransactionType;
                dataGridView1.Rows[i].Cells[2].Value = inventoryDTOs[i].TransactionDate.ToString("yyyy-MM-dd");
                dataGridView1.Rows[i].Cells[3].Value = inventoryDTOs[i].Amount;
                if(inventoryDTOs[i].TransactionType == "Purchase Order")
                {
                    dataGridView1.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                }
                dataGridView1.Rows[i].Cells[4].Value = inventoryDTOs[i].Source;
                dataGridView1.Rows[i].Cells[5].Value = inventoryDTOs[i].Destination;
                
            }
        }
    }
}
