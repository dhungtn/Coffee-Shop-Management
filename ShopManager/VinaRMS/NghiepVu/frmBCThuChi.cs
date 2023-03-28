using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace VinaRMS.NghiepVu
{
    public partial class frmBCThuChi : DevExpress.XtraEditors.XtraForm
    {
        public frmBCThuChi()
        {
            InitializeComponent();
        }

        private void cboTuyChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTuyChon.EditValue.ToString() == "Tùy chọn")
            {
                dateTuNgay.Enabled = true;
                dateDenNgay.Enabled = true;
                dateTuNgay.EditValue = DateTime.Now;
                dateDenNgay.EditValue = DateTime.Now;
            }
            else
            {
                dateTuNgay.Enabled = false;
                dateDenNgay.Enabled = false;
                if (cboTuyChon.EditValue.ToString() == "Hôm nay")
                {
                    dateTuNgay.EditValue = DateTime.Today;
                    dateDenNgay.EditValue = DateTime.Today;
                }
                if (cboTuyChon.EditValue.ToString() == "Tuần này")
                {
                    DateTime d = DateTime.Now;
                    while (d.DayOfWeek != DayOfWeek.Monday) d = d.AddDays(-1); // tìm đầu tuần
                    dateTuNgay.EditValue = d;//DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = d.AddDays(6);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng này")
                {
                    dateTuNgay.EditValue = TTHUtils.LayNgayDauThang();
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)) + "/" + string.Format("{0,2:00}", DateTime.Now.Month) + "/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Quý này")
                {

                    int m = DateTime.Now.Month;
                    DateTime d = DateTime.Now;
                    DateTime d1 = DateTime.Now;
                    if (m <= 3)
                    {
                        d = DateTime.ParseExact("01/01/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                        d1 = DateTime.ParseExact("31/03/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    }
                    else if (m <= 6)
                    {
                        d = DateTime.ParseExact("01/04/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                        d1 = DateTime.ParseExact("30/06/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    }
                    else if (m <= 9)
                    {
                        d = DateTime.ParseExact("01/07/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                        d1 = DateTime.ParseExact("30/09/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    }
                    else
                    {
                        d = DateTime.ParseExact("01/10/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                        d1 = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 12)) + "/12/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    }
                    dateTuNgay.EditValue = d;
                    dateDenNgay.EditValue = d1;
                }
                if (cboTuyChon.EditValue.ToString() == "Năm nay")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/01/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 12)) + "/12/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 1")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/01/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 1)) + "/01/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 2")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/02/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 2)) + "/02/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 3")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/03/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 3)) + "/03/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 4")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/04/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 4)) + "/04/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 5")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/05/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 5)) + "/05/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 6")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/06/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 6)) + "/06/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 7")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/07/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 7)) + "/07/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 8")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/08/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 8)) + "/08/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 9")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/09/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 9)) + "/09/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 10")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/10/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 10)) + "/10/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 11")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/11/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 11)) + "/11/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 12")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/12/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 12)) + "/12/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Quý 1")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/01/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact("31/03/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Quý 2")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/04/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact("30/06/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Quý 3")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/07/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact("30/09/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Quý 4")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/10/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 12)) + "/12/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
            }
        }

        private void frmBCThuChi_Load(object sender, EventArgs e)
        {
            cboTuyChon.Text = "Hôm nay";
        }
    }
}