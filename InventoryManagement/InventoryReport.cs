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
        private PartBUL partBUL = new PartBUL();
        private InventoryBUL inventoryBUL = new InventoryBUL();
        public InventoryReport()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InventoryReport_Load(object sender, EventArgs e)
        {
            try
            {
                this.TopMost = true;
                List<WarehousesDTO> warehousesDTOs = warehousesBUL.LayDanhSachWarehouse();
                cbbWarehouse.DataSource = warehousesDTOs;
                cbbWarehouse.DisplayMember = "Name";
                cbbWarehouse.ValueMember = "ID";
            }
            catch (Exception)
            {
                MessageBox.Show("Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        List<string> partNames = new List<string>();
        List<double> currentStocks = new List<double>();
        List<double> receivedStocks = new List<double>();
        List<string> actions = new List<string>();
        private void showDataToResult(List<string> partNames, List<double> currentStocks, List<double> receivedStocks,
             List<string> actions)
        {
            grvResult.Rows.Clear();
            grvResult.ColumnCount = 4;
            for (int i = 0; i < partNames.Count; i++)
            {
                grvResult.Rows.Add();
                grvResult.Rows[i].Cells[0].Value = partNames[i];
                grvResult.Rows[i].Cells[1].Value = currentStocks[i];
                grvResult.Rows[i].Cells[2].Value = receivedStocks[i];
                grvResult.Rows[i].Cells[3].Value = actions[i];
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbtnCurrentStock.Checked)
                {
                    grvResult.Rows.Clear();
                    partNames.Clear();
                    currentStocks.Clear();
                    receivedStocks.Clear();
                    actions.Clear();
                    rbtnCurrentStock.Checked = true;
                    string wareHouseName = cbbWarehouse.Text;
                    List<string> dsPartID = partBUL.TimDanhSachPartIDTheoWarehouseID(cbbWarehouse.SelectedValue.ToString());

                    for (int i = 0; i < dsPartID.Count; i++)
                    {
                        string partName = partBUL.TimKiemTenTheoPartID(dsPartID[i]);
                        double curentStock = inventoryBUL.TinhChenhLechTongAmountLoaiHangHoaNhapVaoKhoTheoPartNameVaWareNameVoiMinimumAmountCuaPart(partName, wareHouseName) + partBUL.TimKiemMinimumAmountTheoID(dsPartID[i]);
                        if (curentStock > 0)
                        {
                            partNames.Add(partName);
                            currentStocks.Add(curentStock);
                            receivedStocks.Add(inventoryBUL.TinhTongAmountDuocNhapCuaPartTrongWarehouse(cbbWarehouse.SelectedValue.ToString(), dsPartID[i]));
                            if (partBUL.TimBatchNumberHasRequiredBangID(dsPartID[i]) == 1)
                                actions.Add("View Batch Numbers");
                            else
                                actions.Add("");
                        }

                    }

                    showDataToResult(partNames, currentStocks, receivedStocks, actions);
                }

            } catch (Exception)
            {
                MessageBox.Show("Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                if (rbtnReceivedStock.Checked)
                {
                    grvResult.Rows.Clear();
                    partNames.Clear();
                    currentStocks.Clear();
                    receivedStocks.Clear();
                    actions.Clear();
                    rbtnReceivedStock.Checked = true;
                    string wareHouseName = cbbWarehouse.Text;
                    List<string> dsPartID = partBUL.TimDanhSachPartIDTheoWarehouseID(cbbWarehouse.SelectedValue.ToString());

                    for (int i = 0; i < dsPartID.Count; i++)
                    {
                        string partName = partBUL.TimKiemTenTheoPartID(dsPartID[i]);
                        double curentStock = inventoryBUL.TinhChenhLechTongAmountLoaiHangHoaNhapVaoKhoTheoPartNameVaWareNameVoiMinimumAmountCuaPart(partName, wareHouseName) + partBUL.TimKiemMinimumAmountTheoID(dsPartID[i]);

                        partNames.Add(partName);
                        currentStocks.Add(curentStock);
                        receivedStocks.Add(inventoryBUL.TinhTongAmountDuocNhapCuaPartTrongWarehouse(cbbWarehouse.SelectedValue.ToString(), dsPartID[i]));
                        if (partBUL.TimBatchNumberHasRequiredBangID(dsPartID[i]) == 1)
                            actions.Add("View Batch Numbers");
                        else
                            actions.Add("");


                    }

                    showDataToResult(partNames, currentStocks, receivedStocks, actions);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void rbtnOutOfStock_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbtnOutOfStock.Checked)
                {
                    grvResult.Rows.Clear();
                    partNames.Clear();
                    currentStocks.Clear();
                    receivedStocks.Clear();
                    actions.Clear();
                    rbtnOutOfStock.Checked = true;
                    string wareHouseName = cbbWarehouse.Text;
                    List<string> dsPartID = partBUL.TimDanhSachPartIDTheoWarehouseID(cbbWarehouse.SelectedValue.ToString());

                    for (int i = 0; i < dsPartID.Count; i++)
                    {
                        string partName = partBUL.TimKiemTenTheoPartID(dsPartID[i]);
                        double curentStock = inventoryBUL.TinhChenhLechTongAmountLoaiHangHoaNhapVaoKhoTheoPartNameVaWareNameVoiMinimumAmountCuaPart(partName, wareHouseName) + partBUL.TimKiemMinimumAmountTheoID(dsPartID[i]);
                        if (curentStock <= 0)
                        {
                            partNames.Add(partName);
                            currentStocks.Add(curentStock);
                            receivedStocks.Add(inventoryBUL.TinhTongAmountDuocNhapCuaPartTrongWarehouse(cbbWarehouse.SelectedValue.ToString(), dsPartID[i]));
                            if (partBUL.TimBatchNumberHasRequiredBangID(dsPartID[i]) == 1)
                                actions.Add("View Batch Numbers");
                            else
                                actions.Add("");
                        }

                    }

                    showDataToResult(partNames, currentStocks, receivedStocks, actions);
                }

            } catch (Exception)
            {
                MessageBox.Show("Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void setSateComponents()
        {
            rbtnCurrentStock.Checked = false;
            rbtnOutOfStock.Checked = false;
            rbtnReceivedStock.Checked = false;
            grvResult.Rows.Clear();
            partNames.Clear();
            currentStocks.Clear();
            receivedStocks.Clear();
            actions.Clear();
        }
        private void cbbWarehouse_DropDownClosed(object sender, EventArgs e)
        {
            setSateComponents();
        }

        private void grvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            
            if(rowIndex > -1)
            {
                if(columnIndex == 3)
                {
                    if(grvResult.Rows[rowIndex].Cells[3].Value != null)
                    {
                        if (grvResult.Rows[rowIndex].Cells[3].Value.ToString() != "")
                        {
                            string pn = grvResult.Rows[rowIndex].Cells[0].Value.ToString();
                            string whn = cbbWarehouse.Text;
                            string whid = cbbWarehouse.SelectedValue.ToString();
                            string pid = partBUL.TimPartIDTheoTen(pn);
                            this.WindowState = FormWindowState.Minimized;
                            ListBatchNumbersDetail listBatchNumbersDetail = new ListBatchNumbersDetail(pid, whid, pn, whn);
                            listBatchNumbersDetail.ShowDialog();
                            this.WindowState = FormWindowState.Normal;
                        }
                    }
                }
            }
        }
    }
}
