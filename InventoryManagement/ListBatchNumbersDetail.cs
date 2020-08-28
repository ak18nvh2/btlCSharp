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

namespace InventoryManagement
{
    public partial class ListBatchNumbersDetail : Form
    {
        String partID = "";
        private OrdersBUL ordersBUL = new OrdersBUL();
        private InventoryBUL inventoryBUL = new InventoryBUL();
        private PartBUL partBUL = new PartBUL();
        List<string> batchNumbers = new List<string>();
        List<double> currentStocks = new List<double>();
        List<double> receivedStocks = new List<double>();
        public ListBatchNumbersDetail()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public ListBatchNumbersDetail(string partID, string wareHouseID, string partName, string wareHouseName)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.partID = partID;
            batchNumbers = ordersBUL.DocDanhSachBatchNumberTheoPartID(this.partID);
            for(int i =0; i<batchNumbers.Count; i++)
            {
                double currentStock = inventoryBUL.TinhChenhLechTongAmountLoaiHangHoaNhapVaoKhoTheoPartNameVaWareNameVoiMinimumAmountCuaPart(partName,wareHouseName, batchNumbers[i]) + partBUL.TimKiemMinimumAmountTheoID(this.partID);
                double receivedStock = inventoryBUL.TinhTongAmountCuaPartMaKhoDaNhanTheoIDKhoVaIDPart(wareHouseID, partID, batchNumbers[i]);
                currentStocks.Add(currentStock);
                receivedStocks.Add(receivedStock);
            }
            lbPartName.Text = partName;
            lbWarehouseName.Text = wareHouseName;
        }
        private void showDataToGridView(List<string> batchNumbers, List<double> currentStocks, List<double> receivedStocks)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 3;
            for (int i = 0; i < batchNumbers.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = batchNumbers[i];
                dataGridView1.Rows[i].Cells[1].Value = currentStocks[i];
                dataGridView1.Rows[i].Cells[2].Value = receivedStocks[i];
                
            }
        }
        private void ListBatchNumbersDetail_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            showDataToGridView(batchNumbers, currentStocks, receivedStocks);
        }
    }
}
