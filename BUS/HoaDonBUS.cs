using System;
using System.Data;

using DAO;
using DTO;

namespace BUS
{
    public class HoaDonBUS
    {
        private static HoaDonBUS instance;

        public static HoaDonBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new HoaDonBUS();
                return HoaDonBUS.instance;
            }
        }

        private HoaDonBUS() { }

        public int GetUnCheckBillIDByTableID(int id)
        {
            try
            {
                return HoaDonDAO.Instance.GetUnCheckBillIDByTableID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertBill(int tableID)
        {
            try
            {
                HoaDonDAO.Instance.InsertBill(tableID);
            }
            catch { }
        }

        public int GetMaxBillID()
        {
            try
            {
                return HoaDonDAO.Instance.GetMaxBillID();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CheckOut(int billID, int discount, int totalPrice)
        {
            try
            {
                HoaDonDAO.Instance.CheckOut(billID, discount, totalPrice);
            }
            catch { }
        }

        public DataTable GetListBillByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                return HoaDonDAO.Instance.GetListBillByDate(fromDate, toDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteBill(int id)
        {
            try
            {
                return HoaDonDAO.Instance.DeleteBill(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}