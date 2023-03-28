using System;
using System.Collections.Generic;

using DAO;
using DTO;

namespace BUS
{
    public class ThongTinHoaDonBUS
    {
        private static ThongTinHoaDonBUS instance;

        public static ThongTinHoaDonBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThongTinHoaDonBUS();
                return ThongTinHoaDonBUS.instance;
            }
        }

        private ThongTinHoaDonBUS() { }

        public void InsertBillInfo(int billID, int foodID, int amount)
        {
            try
            {
                ThongTinHoaDonDAO.Instance.InsertBillInfo(billID, foodID, amount);
            }
            catch { }
        }

        public void DeleteBillInfoByBillID(int billID)
        {
            try
            {
                ThongTinHoaDonDAO.Instance.DeleteBillInfoByBillID(billID);
            }
            catch { }
        }
    }
}