using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Globalization;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;

using BUS;
using DTO;

namespace GUI
{
    public partial class fMain : DevExpress.XtraEditors.XtraForm
    {
        private SimpleButton currentClickButton = new SimpleButton();

        public fMain()
        {
            InitializeComponent();
            currentClickButton = null;
           btnChangeTable.Enabled = false;
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            LoadTable();
            LoadCategory();
            LoadLookUpEditTable();
            SplashScreenManager.CloseForm();
        }

        private void LoadTable()
        {
            flpListTable.Controls.Clear();
            List<Ban> tableList = BanBUS.Instance.GetTableList();

            foreach (Ban item in tableList)
            {
                SimpleButton button = new SimpleButton() { Width = 80, Height = 80 };
                button.Text = item.Name;
                button.Click += btn_Click;
                button.Tag = item;
                button.ImageList = imageList;

                switch (item.Status)
                {
                    case "Có người":
                        button.ImageIndex = 0;
                        break;
                    default:
                        break;
                }
                flpListTable.Controls.Add(button);
            }
        }

        private void LoadCategory()
        {
            lkedPickCategory.Properties.DataSource = DanhMucBUS.Instance.GetAllCategory();
            lkedPickCategory.Properties.DisplayMember = "Name";
            lkedPickCategory.Properties.ValueMember = "ID";
        }

        private void LoadLookUpEditTable()
        {
            lkedPickTable.Properties.DataSource = BanBUS.Instance.GetTableList();
            lkedPickTable.Properties.DisplayMember = "Name";
            lkedPickTable.Properties.ValueMember = "ID";
        }

        private void ShowBill(int tableID)
        {
            lsvBill.Items.Clear();
            List<TempBill> listTempBill = new List<TempBill>();
            try
            {
                listTempBill = HoaDonTamBUS.Instance.GetListTempBillByTableID(tableID);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex);
            }

            int totalPrice = 0;
            foreach (TempBill item in listTempBill)
            {
                ListViewItem lsvItem = new ListViewItem(item.Food.ToString());
                lsvItem.SubItems.Add(item.AmountFood.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.Total.ToString());

                totalPrice += item.Total;
                lsvBill.Items.Add(lsvItem);
            }

            CultureInfo culture = new CultureInfo("vi-VN");
            // Thread.CurrentThread.CurrentCulture = culture;
            txtTotalPrice.Text = totalPrice.ToString("c", culture);
        }

        void btn_Click(object sender, EventArgs e)
        {
            if ((sender as SimpleButton) != currentClickButton)
            {
                if (currentClickButton != null)
                {
                    if ((currentClickButton.Tag as Ban).Status == "Có người")
                        currentClickButton.ImageIndex = 0;
                    else
                        currentClickButton.ImageIndex = -1;
                }
            }

            (sender as SimpleButton).ImageIndex = 1;
            int tableID = ((sender as SimpleButton).Tag as Ban).ID;
            lsvBill.Tag = (sender as SimpleButton).Tag;
            ShowBill(tableID);
            currentClickButton = sender as SimpleButton;
            btnChangeTable.Enabled = true;
          
        }

        private void lkedPickCategory_EditValueChanged(object sender, EventArgs e)
        {
            int id = (int)lkedPickCategory.EditValue;
            GetListFoodByCategory(id);
        }

        private void GetListFoodByCategory(int categoryID)
        {
            lkedPickFood.Properties.DataSource = DoAnBUS.Instance.GetListFoodByCategoryID(categoryID);
            lkedPickFood.Properties.DisplayMember = "Name";
            lkedPickFood.Properties.ValueMember = "ID";
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Ban table = lsvBill.Tag as Ban;
            if (table == null)
            {
                XtraMessageBox.Show("Hãy chọn bàn");
                return;
            }

            if (spAmount.Value == 0)
                return;
            int amount = (int)spAmount.Value;

            int billID = HoaDonBUS.Instance.GetUnCheckBillIDByTableID(table.ID);

            if (lkedPickFood.EditValue == null)
            {
                XtraMessageBox.Show("Hãy chọn món");
                return;
            }
            int foodID = (int)lkedPickFood.EditValue;

            if (billID == -1)
            {
                try
                {
                    HoaDonBUS.Instance.InsertBill(table.ID);
                    ThongTinHoaDonBUS.Instance.InsertBillInfo(HoaDonBUS.Instance.GetMaxBillID(), foodID, amount);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Error: " + ex);
                }
            }
            else
            {
                try
                {
                    ThongTinHoaDonBUS.Instance.InsertBillInfo(billID, foodID, amount);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Eror: " + ex);
                }
            }
            ShowBill(table.ID);
            LoadTable();
            LoadLookUpEditTable();
        }

        private void btnChangeTable_Click(object sender, EventArgs e)
        {
            int id1 = (lsvBill.Tag as Ban).ID;
            int id2;
            if (lkedPickTable.EditValue == null)
            {
                XtraMessageBox.Show("Hãy chọn bàn muốn chuyển");
                return;
            }
            else
                id2 = (int)lkedPickTable.EditValue;

            if (XtraMessageBox.Show(string.Format("Bạn có thật sự muốn chuyển {0} sang {1}?",
                (lsvBill.Tag as Ban).Name, lkedPickTable.Text),
                "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                NhatKy.WriteLog("change " + (lsvBill.Tag as Ban).Name + " to " + lkedPickTable.Text);
                BanBUS.Instance.SwitchTable(id1, id2);
                LoadTable();
                LoadLookUpEditTable();
                btnChangeTable.Enabled = false;

                foreach (SimpleButton item in flpListTable.Controls)
                    if ((item.Tag as Ban).ID == id2)
                    {
                        lsvBill.Tag = item.Tag;
                        break;
                    }
            }
        }

        

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Ban table = lsvBill.Tag as Ban;
            if (table == null)
                return;

            int billID = -1;
            try
            {
                billID = HoaDonBUS.Instance.GetUnCheckBillIDByTableID(table.ID);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex);
            }

            int discount = (int)spDiscount.Value;
            double totalPrice = Convert.ToDouble(txtTotalPrice.Text.Split(',')[0]) * 1000;
            double finalPrice = totalPrice - (totalPrice / 100) * discount;
            if (billID != -1)
            {
                if (XtraMessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho {0}?", table.Name),
                    "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    // Print bill
                    List<TempBill> lstTempBill = new List<TempBill>();
                    try
                    {
                        lstTempBill = HoaDonTamBUS.Instance.GetListTempBillByTableID(table.ID);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Error: " + ex);
                    }

                    SplashScreenManager.ShowForm(typeof(WaitForm1));
                    XtraReport report = new XtraReport();
                    report.DataSource = lstTempBill;
                    report.Parameters["TableName"].Value = table.ID;
                    report.Parameters["Discount"].Value = discount;
                    report.Parameters["CreateDate"].Value = DateTime.Now;
                    report.Parameters["TotalPrice"].Value = finalPrice;
                    ReportPrintTool tool = new ReportPrintTool(report);
                    tool.ShowPreview();
                    SplashScreenManager.CloseForm();

                    // Save bill to database
                    HoaDonBUS.Instance.CheckOut(billID, discount, (int)finalPrice);
                    ShowBill(table.ID);
                    LoadTable();
                    LoadLookUpEditTable();

                    NhatKy.WriteLog("check new Bill, ID = " + billID + ", Total price = " + finalPrice);
                }
            } 
        }

        private void fMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                SplashScreenManager.ShowForm(typeof(WaitForm1));
                LoadTable();
                LoadCategory();
                LoadLookUpEditTable();
                SplashScreenManager.CloseForm();
            }
        }
    }
}