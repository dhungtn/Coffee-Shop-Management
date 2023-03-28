using System;
using System.Data;

namespace DAO
{
    public class KieuTaiKhoanDAO
    {
        private static KieuTaiKhoanDAO instance;

        public static KieuTaiKhoanDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KieuTaiKhoanDAO();
                return KieuTaiKhoanDAO.instance;
            }
        }

        public KieuTaiKhoanDAO() { }

        public DataTable GetAllAccountType()
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery("select * from AccountType");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}