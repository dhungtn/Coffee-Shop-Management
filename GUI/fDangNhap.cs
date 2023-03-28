using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

using BUS;
using DTO;

namespace GUI
{
    public partial class fDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public fDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));

            TaiKhoan account = new TaiKhoan(txtUserName.Text, txtPassword.Text);
            try
            {
                if (TaiKhoanBUS.Instance.CheckLogin(account))
                {
                    NhatKy.WriteLog("----------" + account.UserName + " log in ----------");

                    TaiKhoan acc = TaiKhoanBUS.Instance.GetAccountByUserName(account.UserName);

                    fQuanLy form = new fQuanLy(acc);
                    SplashScreenManager.CloseForm();
                    this.Hide();
                    form.ShowDialog();
                    this.Show();
                }
                else
                {
                    SplashScreenManager.CloseForm();
                    XtraMessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có thật sự muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                e.Cancel = true;
        }
    }
}