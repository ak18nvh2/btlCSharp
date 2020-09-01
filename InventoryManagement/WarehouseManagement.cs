using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
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
            try
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

                List<string> dsPartTungDuaHangDenKho = partBUL.TimDanhSachPartIDTungDuaHangDenKhoTheoIDKho(cbbSourceWarehouse.SelectedValue.ToString());
                List<string> dsPartHienThiLenCBB = new List<string>();
                for (int i = 0; i < dsPartTungDuaHangDenKho.Count; i++)
                {
                    string partName = partBUL.TimKiemTenTheoPartID(dsPartTungDuaHangDenKho[i]);
                    double curentStock = inventoryBUL.TinhChenhLechTongAmountLoaiHangHoaNhapVaoKhoTheoPartNameVaWareNameVoiMinimumAmountCuaPart(partName, cbbSourceWarehouse.Text) + partBUL.TimKiemMinimumAmountTheoID(dsPartTungDuaHangDenKho[i]);
                    if (curentStock > 0)
                    {
                        dsPartHienThiLenCBB.Add(partName);
                    }

                }
                cbbPartName.DataSource = dsPartHienThiLenCBB;

            } catch (Exception)
            {
                MessageBox.Show("Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            try
            {
                List<string> dsBatchNumber =
                ordersBUL.DocDanhSachBatchNumberTheoPartID(partBUL.TimPartIDTheoTen(cbbPartName.Text));
                cbbBatchNumber.DataSource = dsBatchNumber;
            }
            catch
            {
                MessageBox.Show("Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    try
                    {
                        string partName = cbbPartName.Text;
                        string idPart = partBUL.TimPartIDTheoTen(partName);
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

                    } catch (Exception)
                    {
                        MessageBox.Show("Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    try
                    {
                        int checkHopLe = -1;
                        double negativeAmount = 0;
                        for (int i = 0; i < partNames.Count; i++)
                        {
                            double chenhlechPart =
                            inventoryBUL.TinhChenhLechTongAmountLoaiHangHoaNhapVaoKhoTheoPartNameVaWareNameVoiMinimumAmountCuaPart(partNames[i], cbbSourceWarehouse.Text, batchNumbers[i]);
                            double amountChuanBiXoa = amounts[i];
                            if (chenhlechPart < amountChuanBiXoa)
                            {
                                checkHopLe = i + 1;
                                negativeAmount = amountChuanBiXoa - chenhlechPart;
                                break;
                            }
                        }
                        if (checkHopLe != -1)
                        {
                            string batchNumberX = "";
                            if (cbbBatchNumber.Text != "")
                            {
                                batchNumberX = " with batch number " + batchNumbers[checkHopLe - 1];
                            }
                            MessageBox.Show("Error in line " + checkHopLe + "! The inventory for a part " + partNames[checkHopLe - 1] + batchNumberX + " negative " + negativeAmount + "!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int soLuongBanGhiOrder = ordersBUL.DemSoLuongOrder();
                            string orderID = (soLuongBanGhiOrder + 1000).ToString();
                            string transactionTypeID = "2";
                            string supplierID = "";
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
                                ordersBUL.ThemMotOrder2(ordersDTO);
                                int orderItemID = orderItemsBUL.DemSoLuongOrderItem() + 1000;
                                for (int i = 0; i < partNames.Count; i++)
                                {
                                    OrderItemsDTO orderItemsDTO = new OrderItemsDTO();
                                    orderItemsDTO.OrderID = orderID;
                                    orderItemsDTO.ID = (++orderItemID).ToString();
                                    orderItemsDTO.PartID = partBUL.TimPartIDTheoTen(partNames[i]);
                                    orderItemsDTO.BatchNumber = batchNumbers[i];
                                    orderItemsDTO.Amount = amounts[i];
                                    orderItemsBUL.ThemMotOrderItem(orderItemsDTO);
                                }

                                MessageBox.Show("Successfully! Record has been added!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();

                            }

                        }
                    } catch
                    {
                        MessageBox.Show("Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No one on this part list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbSourceWarehouse_DropDownClosed(object sender, EventArgs e)
        {
            // tìm danh sách
            try
            {
                List<string> dsPartTungDuaHangDenKho = partBUL.TimDanhSachPartIDTungDuaHangDenKhoTheoIDKho(cbbSourceWarehouse.SelectedValue.ToString());
                List<string> dsPartHienThiLenCBB = new List<string>();
                for (int i = 0; i < dsPartTungDuaHangDenKho.Count; i++)
                {
                    string partName = partBUL.TimKiemTenTheoPartID(dsPartTungDuaHangDenKho[i]);
                    double curentStock = inventoryBUL.TinhChenhLechTongAmountLoaiHangHoaNhapVaoKhoTheoPartNameVaWareNameVoiMinimumAmountCuaPart(partName, cbbSourceWarehouse.Text) + partBUL.TimKiemMinimumAmountTheoID(dsPartTungDuaHangDenKho[i]);
                    if (curentStock > 0)
                    {
                        dsPartHienThiLenCBB.Add(partName);
                    }

                }
                cbbPartName.DataSource = dsPartHienThiLenCBB;

            }
            catch
            {
                MessageBox.Show("Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            } 
    }
}
