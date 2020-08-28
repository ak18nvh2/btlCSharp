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
using DALs;
using DTOs;

namespace InventoryManagement
{
    public partial class PurchaseOrder : Form
    {
        SuppliersBUL suppliersBUL = new SuppliersBUL();
        WarehousesBUL warehousesBUL = new WarehousesBUL();
        OrderItemsBUL orderItemsBUL = new OrderItemsBUL();
        OrdersBUL ordersBUL = new OrdersBUL();
        PartBUL partBUL = new PartBUL();
        string orderID = "";
        public PurchaseOrder()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        public PurchaseOrder(string orderID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.orderID = orderID;
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

            List<PartsDTO> partsDTOs = partBUL.DocDanhSachPart();
            var bindingSourcePart = new BindingSource();
            bindingSourcePart.DataSource = partsDTOs;
            cbbPartName.DataSource = bindingSourcePart.DataSource;
            cbbPartName.DisplayMember = "Name";
            cbbPartName.ValueMember = "ID";
        }
        private void showPartListToDataGridView(List<string> partNames, List<string> batchNumbers,
                                                List<double> amounts)
        {
            grvPart.Rows.Clear();
            grvPart.ColumnCount = 4;
            for (int i = 0; i < partNames.Count; i++)
            {
                grvPart.Rows.Add();
                grvPart.Rows[i].Cells[0].Value = partNames[i];
                grvPart.Rows[i].Cells[1].Value = batchNumbers[i];
                grvPart.Rows[i].Cells[2].Value = amounts[i].ToString();
                grvPart.Rows[i].Cells[3].Value = "remove";
            }
        }
        List<string> partNames = new List<string>();
        List<string> batchNumbers = new List<string>();
        List<double> amounts = new List<double>();
        private void button1_Click(object sender, EventArgs e)
        {
            int checkAmount = 1;
            double amount = 0;

            if (txtAmount.Text == "")
            {
                checkAmount = 0;
                MessageBox.Show("Amount must not empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    amount = double.Parse(txtAmount.Text);
                }
                catch (FormatException)
                {
                    checkAmount = 0;
                    MessageBox.Show("Amount needs to be of positive decimal value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (checkAmount == 1)
            {

                if (amount <= 0)
                {
                    MessageBox.Show("Amount needs to be of positive decimal value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string partName = cbbPartName.Text;
                    string idPart = cbbPartName.SelectedValue.ToString();


                    int batchNumberHasRequired = partBUL.TimBatchNumberHasRequiredBangID(idPart);
                    if (batchNumberHasRequired == 1)
                    {
                        if (txtBatchNumber.Text == "")
                        {
                            MessageBox.Show("Must type Batch Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (partNames.Contains(partName))
                            {
                                int checkBatchNumber = 1;
                                for (int i = 0; i < partNames.Count; i++)
                                {
                                    List<string> batchNumberChild = new List<string>();
                                    if (partNames[i] == partName)
                                    {
                                        if (txtBatchNumber.Text == batchNumbers[i])
                                        {
                                            checkBatchNumber = 0;
                                            break;
                                        }

                                    }
                                }

                                if (checkBatchNumber == 1)
                                {
                                    batchNumbers.Add(txtBatchNumber.Text);
                                    amounts.Add(amount);
                                    partNames.Add(partName);
                                    this.showPartListToDataGridView(partNames, batchNumbers, amounts);
                                }
                                else
                                {
                                    MessageBox.Show("Had this batch number on this list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                batchNumbers.Add(txtBatchNumber.Text);
                                amounts.Add(amount);
                                partNames.Add(partName);
                                this.showPartListToDataGridView(partNames, batchNumbers, amounts);
                            }



                        }
                    }
                    else
                    {
                        if (!partNames.Contains(partName))
                        {
                            batchNumbers.Add("");
                            amounts.Add(amount);
                            partNames.Add(partName);
                            this.showPartListToDataGridView(partNames, batchNumbers, amounts);
                        }
                        else
                        {
                            MessageBox.Show("Had this part name on this list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }




            }






        }

        private void grvPart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexColumn = e.ColumnIndex;
            int indexRow = e.RowIndex;
            if(indexColumn == 3)
            {
                DialogResult a = MessageBox.Show("Are you sure delete this record?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.Yes)
                {
                    partNames.RemoveAt(indexRow);
                    batchNumbers.RemoveAt(indexRow);
                    amounts.RemoveAt(indexRow);
                    MessageBox.Show("Successfully! Record has been deleted!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showPartListToDataGridView(partNames, batchNumbers, amounts);
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Are you sure submit?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                if(partNames.Count > 0)
                {
                    int soLuongBanGhiOrder = ordersBUL.DemSoLuongOrder();


                    string orderID = (soLuongBanGhiOrder + 1000).ToString();
                    string transactionTypeID = "1";
                    string supplierID = cbbSupplier.SelectedValue.ToString();
                    string sourceWareHouseID = "";
                    string destionationWareHouseID = cbbWarehouse.SelectedValue.ToString();
                    DateTime d = dateTimePicker1.Value;
                    if (d > DateTime.Now)
                    {
                        MessageBox.Show("Error in Date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        OrdersDTO ordersDTO = new OrdersDTO(orderID, transactionTypeID, supplierID, sourceWareHouseID, destionationWareHouseID, d);
                        ordersBUL.ThemMotOrder(ordersDTO);

                        for (int i = 0; i < partNames.Count; i++)
                        {
                            OrderItemsDTO orderItemsDTO = new OrderItemsDTO();
                            orderItemsDTO.OrderID = orderID;
                            orderItemsDTO.ID = (orderItemsBUL.DemSoLuongOrderItem() + 10000).ToString();
                            orderItemsDTO.PartID = partBUL.TimPartIDTheoTen(partNames[i]);
                            orderItemsDTO.BatchNumber = batchNumbers[i];
                            orderItemsDTO.Amount = amounts[i];
                            orderItemsBUL.ThemMotOrderItem(orderItemsDTO);
                        }

                        MessageBox.Show("Successfully! Record has been added!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }

                    //  MessageBox.Show(orderID + " " + transactionTypeID + " " + supplierID + " " + sourceWareHouseID + " "
                    //     + destionationWareHouseID + " " + d);

                }
                else
                {
                    MessageBox.Show("No one on this part list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            

        }
    }
}
