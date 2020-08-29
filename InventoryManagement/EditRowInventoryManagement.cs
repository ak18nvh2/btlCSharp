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
    public partial class EditRowInventoryManagement : Form
    {
        WarehousesBUL warehousesBUL = new WarehousesBUL();
        TransactionTypesBUL typesBUL = new TransactionTypesBUL();
        PartBUL partBUL = new PartBUL();
        public EditRowInventoryManagement()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;

        }

        private void EditRowInventoryManagement_Load(object sender, EventArgs e)
        {
            List<PartsDTO> partsDTOs = partBUL.DocDanhSachPart();
            cbbPartName.DataSource = partsDTOs;
            cbbPartName.DisplayMember = "Name";
            cbbPartName.ValueMember = "ID";

            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
