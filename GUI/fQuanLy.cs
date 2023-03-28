using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraBars.Helpers;
using System.IO;
using DevExpress.LookAndFeel;

using DTO;
using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace GUI
{
    public partial class fQuanLy : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private TaiKhoan loginAccount;
        public TaiKhoan LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; DisplayAccount(loginAccount.TypeID); }
        }

        public fQuanLy(TaiKhoan loginAccount)
        {
            InitializeComponent();
            this.LoginAccount = loginAccount;
            LoadSkin();
        }

        DefaultLookAndFeel defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel();

        private void LoadSkin()
        {
            //defaultLookAndFeel.LookAndFeel.SkinName = "Blue";
            BonusSkins.Register();
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(ribbonGalleryBarItem1, true);

            string fileName = "Skins.txt";
            if (File.Exists(fileName) == false)
                defaultLookAndFeel.LookAndFeel.SetSkinStyle("Default");
            else
            {
                StreamReader sr = new StreamReader(fileName, false);
                defaultLookAndFeel.LookAndFeel.SetSkinStyle(sr.ReadLine());
                sr.Close();
            }
        }

        private void fManager_Load(object sender, EventArgs e)
        {
            ribbonPageGroupSystem.Text = loginAccount.DisplayName;
            bsTextDate.Caption = "Chào " + loginAccount.DisplayName;
        }

        private void DisplayAccount(int type)
        {
            ribbonPageManager.Visible = type == 1; // admin
        }

        private Form CheckFormExist(Type fType)
        {
            foreach (Form f in MdiChildren)
            {
                if (f.GetType() == fType)
                    return f;
            }
            return null;
        }

        private void btnShowForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckFormExist(typeof(fMain));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                fMain f = new fMain();
                f.MdiParent = this;
                f.Show();
            }
        }

     

        private void btnAccountInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckFormExist(typeof(fThongTinTaiKhoan));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                fThongTinTaiKhoan f = new fThongTinTaiKhoan(loginAccount);
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnLogOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnViewFood_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckFormExist(typeof(fDoAn));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                fDoAn f = new fDoAn();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnViewCategoryFood_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckFormExist(typeof(fDanhMuc));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                fDanhMuc f = new fDanhMuc();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnViewTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckFormExist(typeof(fBan));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                fBan f = new fBan();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnViewAccount_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckFormExist(typeof(fTaiKhoan));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                fTaiKhoan f = new fTaiKhoan();
                f.LoginUserName = loginAccount.UserName;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnViewBill_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckFormExist(typeof(fHoaDon));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                fHoaDon f = new fHoaDon();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnStatistic_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            Form frm = this.CheckFormExist(typeof(fThongKe));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                fThongKe f = new fThongKe();
                f.MdiParent = this;
                f.Show();
            }
            SplashScreenManager.CloseForm();
        }

      

      

        private void btnLog_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void fManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                fManager_Load(sender, e);
        }

        private void fManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            NhatKy.WriteLog("----------" + loginAccount.UserName + " log out ----------");

            string skinsName = defaultLookAndFeel.LookAndFeel.SkinName;
            string fileName = "Skins.txt";
            StreamWriter sw = new StreamWriter(fileName, false);
            sw.WriteLine(skinsName);
            sw.Close();
        }
	}
}