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
    public partial class PurchaseOrder : Form
    {
        SuppliersBUL suppliersBUL = new SuppliersBUL();
        WarehousesBUL warehousesBUL = new WarehousesBUL();
        public PurchaseOrder()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            List<SuppliersDTO> listSupplier = suppliersBUL.LayDanhSachSuplier();
            var bindingSourceSupplier = new BindingSource();
            bindingSourceSupplier.DataSource = listSupplier;
            cbbSupplier.DataSource = bindingSourceSupplier.DataSource;
            cbbSupplier.DisplayMember = "Name";
            cbbSupplier.ValueMember = "ID";

            List<WarehousesDTO> listWarehouse = warehousesBUL.LayDanhSachWarehouse();
            var bindingSourceWarehouse = new BindingSource();
            bindingSourceWarehouse.DataSource = listWarehouse;
            cbbWarehouse.DataSource = bindingSourceWarehouse.DataSource;
            cbbWarehouse.DisplayMember = "Name";
            cbbWarehouse.ValueMember = "ID";
        }
    }
}
