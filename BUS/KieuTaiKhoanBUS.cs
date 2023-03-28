using System;
using System.Data;

using DAO;

namespace BUS
{
    public class KieuTaiKhoanBUS
    {
        private static KieuTaiKhoanBUS instance;

        public static KieuTaiKhoanBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new KieuTaiKhoanBUS();
                return KieuTaiKhoanBUS.instance;
            }
        }

        public KieuTaiKhoanBUS() { }

        public DataTable GetAllAccountType()
        {
            try
            {
                return KieuTaiKhoanDAO.Instance.GetAllAccountType();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}