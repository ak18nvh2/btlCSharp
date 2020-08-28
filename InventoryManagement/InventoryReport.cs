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
    public partial class InventoryReport : Form
    {
        private WarehousesBUL warehousesBUL = new WarehousesBUL();
        public InventoryReport()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InventoryReport_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            List<WarehousesDTO> warehousesDTOs = warehousesBUL.LayDanhSachWarehouse();
            cbbWarehouse.DataSource = warehousesDTOs;
            cbbWarehouse.DisplayMember = "Name";
            cbbWarehouse.ValueMember = "ID";

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnCurrentStock.Checked)
            {
                MessageBox.Show(cbbWarehouse.SelectedValue.ToString());
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rbtnReceivedStock_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnReceivedStock.Checked)
            {

            }
           
        }

        private void rbtnOutOfStock_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnOutOfStock.Checked)
            {

            }
            
        }

        private void cbbWarehouse_DropDownClosed(object sender, EventArgs e)
        {
            rbtnCurrentStock.Checked = false;
            rbtnOutOfStock.Checked = false;
            rbtnReceivedStock.Checked = false;
        }
    }
}
