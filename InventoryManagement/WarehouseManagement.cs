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
    
    public partial class WarehouseManagement : Form
    {
        private WarehousesBUL warehousesBUL = new WarehousesBUL();
        private PartBUL partBUL = new PartBUL();
        private OrdersBUL ordersBUL = new OrdersBUL();
        private InventoryBUL inventoryBUL = new InventoryBUL();
        private OrderItemsBUL orderItemsBUL = new OrderItemsBUL();
        public WarehouseManagement()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void WarehouseManagement_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            List<WarehousesDTO> listSourceWarehouse = warehousesBUL.LayDanhSachWarehouse();
            var bindingSourceWarehouse = new BindingSource();
            bindingSourceWarehouse.DataSource = listSourceWarehouse;
            cbbSourceWarehouse.DataSource = bindingSourceWarehouse.DataSource;
            cbbSourceWarehouse.DisplayMember = "Name";
            cbbSourceWarehouse.ValueMember = "ID";

            List<WarehousesDTO> listDestinationWarehouse = warehousesBUL.LayDanhSachWarehouse();
            var bindingDestinationWarehouse = new BindingSource();
            bindingDestinationWarehouse.DataSource = listDestinationWarehouse;
            cbbDestinationWarehouse.DataSource = bindingDestinationWarehouse.DataSource;
            cbbDestinationWarehouse.DisplayMember = "Name";
            cbbDestinationWarehouse.ValueMember = "ID";


            List<PartsDTO> partsDTOs = partBUL.DocDanhSachPart();
            var bindingSourcePart = new BindingSource();
            bindingSourcePart.DataSource = partsDTOs;
            cbbPartName.DataSource = bindingSourcePart.DataSource;
            cbbPartName.DisplayMember = "Name";
            cbbPartName.ValueMember = "ID";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbBatchNumber_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void cbbPartName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cbbPartName_DropDownClosed(object sender, EventArgs e)
        {
            List<string> dsBatchNumber =
                ordersBUL.DocDanhSachBatchNumberTheoPartID(cbbPartName.SelectedValue.ToString());
            cbbBatchNumber.DataSource = dsBatchNumber;
        }
        List<string> partNames = new List<string>();
        List<string> batchNumbers = new List<string>();
        List<double> amounts = new List<double>();
        private void showPartListToDataGridView(List<string> partNames, List<string> batchNumbers,
                                                List<double> amounts)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 4;
            for (int i = 0; i < partNames.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = partNames[i];
                dataGridView1.Rows[i].Cells[1].Value = batchNumbers[i];
                dataGridView1.Rows[i].Cells[2].Value = amounts[i].ToString();
                dataGridView1.Rows[i].Cells[3].Value = "remove";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int checkAmount = 1;
            double amount = 0;

            if (txtAmount.Text == "")
            {
                checkAmount = 0;
                MessageBox.Show("Error in Amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Error in Amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (checkAmount == 1)
            {

                if (amount <= 0)
                {
                    MessageBox.Show("Error in Amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string partName = cbbPartName.Text;
                    string idPart = cbbPartName.SelectedValue.ToString();
                    int batchNumberHasRequired = partBUL.TimBatchNumberHasRequiredBangID(idPart);
                    string batchNumber = cbbBatchNumber.Text;
                    if (batchNumberHasRequired == 1)
                    {

                        int checkBatchNumber = 1;
                        for (int i = 0; i < partNames.Count; i++)
                        {
                            List<string> batchNumberChild = new List<string>();
                            if (partNames[i] == partName)
                            {
                                if (cbbBatchNumber.Text == batchNumbers[i])
                                {
                                    checkBatchNumber = 0;
                                    break;
                                }

                            }
                        }

                        if (checkBatchNumber == 1)
                        {
                            batchNumbers.Add(cbbBatchNumber.Text);
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
                        if (!partNames.Contains(partName))
                        {
                            partNames.Add(partName);
                            batchNumbers.Add(batchNumber);
                            amounts.Add(amount);
                            showPartListToDataGridView(partNames, batchNumbers, amounts);
                        }
                        else
                        {
                            MessageBox.Show("Had this part name on this list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    

                }
            }



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexColumn = e.ColumnIndex;
            int indexRow = e.RowIndex;
            if (indexColumn == 3)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if(partNames.Count > 0)
            {
                if(cbbSourceWarehouse.Text == cbbDestinationWarehouse.Text)
                {
                    MessageBox.Show("The source and the destination warehouses must not same!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int checkHopLe = 1;
                    for(int i=0; i< partNames.Count; i++)
                    {
                        double chenhlechPart =
                        inventoryBUL.TinhChenhLechTongAmountLoaiHangHoaNhapVaoKhoTheoPartNameVaWareNameVoiMinimumAmountCuaPart(partNames[i], cbbSourceWarehouse.Text, batchNumbers[i]);
                        double amountChuanBiXoa = amounts[i];
                        if(chenhlechPart < amountChuanBiXoa)
                        {
                            checkHopLe = 0;
                            break;
                        }
                    }
                    if(checkHopLe == 0)
                    {
                        MessageBox.Show("This list has part can't use!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int soLuongBanGhiOrder = ordersBUL.DemSoLuongOrder();
                        string orderID = (soLuongBanGhiOrder + 100).ToString();
                        string transactionTypeID = "2";
                        string supplierID = null;
                        string sourceWareHouseID = cbbSourceWarehouse.SelectedValue.ToString();
                        string destionationWareHouseID = cbbDestinationWarehouse.SelectedValue.ToString();
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
                                orderItemsDTO.ID = (orderItemsBUL.DemSoLuongOrderItem() + 1000).ToString();
                                orderItemsDTO.PartID = partBUL.TimPartIDTheoTen(partNames[i]);
                                orderItemsDTO.BatchNumber = batchNumbers[i];
                                orderItemsDTO.Amount = amounts[i];
                                orderItemsBUL.ThemMotOrderItem(orderItemsDTO);
                            }

                            MessageBox.Show("Successfully! Record has been added!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();

                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("No one on this part list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
