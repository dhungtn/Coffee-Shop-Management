using System;
using System.Data;
using System.Collections.Generic;

using DAO;
using DTO;

namespace BUS
{
    public class TaiKhoanBUS
    {
        private static TaiKhoanBUS instance;

        public static TaiKhoanBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new TaiKhoanBUS();
                return instance;
            }
        }

        private TaiKhoanBUS() { }

        public bool CheckLogin(TaiKhoan account)
        {
            if (account.UserName == "")
                return false;
            if (account.Password == "")
                return false;

            try
            {
                return TaiKhoanDAO.Instance.CheckLogin(account);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAllAcount()
        {
            try
            {
                return TaiKhoanDAO.Instance.GetAllAcount();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TaiKhoan GetAccountByUserName(string userName)
        {
            DataTable table;
            try
            {
                table = TaiKhoanDAO.Instance.GetAccountByUserName(userName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new TaiKhoan(table.Rows[0]);
        }

        public bool Insert(string userName, string displayName, int type)
        {
            try
            {
                return TaiKhoanDAO.Instance.Insert(userName, displayName, type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(string userName)
        {
            try
            {
                return TaiKhoanDAO.Instance.Delete(userName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ResetPassword(string userName)
        {
            try
            {
                return TaiKhoanDAO.Instance.ResetPassword(userName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateInformation(string userName, string displayName, string password, string newPass)
        {
            try
            {
                return TaiKhoanDAO.Instance.UpdateInformation(userName, displayName, password, newPass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TaiKhoan> SearchAccountByUserName(string userName)
        {
            List<TaiKhoan> listAccount = new List<TaiKhoan>();
            DataTable table;
            try
            {
                table = TaiKhoanDAO.Instance.SearchAccountByUserName(userName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            foreach (DataRow row in table.Rows)
            {
                TaiKhoan account = new TaiKhoan(row);
                listAccount.Add(account);
            }
            return listAccount;
        }
    }
}