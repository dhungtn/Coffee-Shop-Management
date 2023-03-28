using System.Collections.Generic;
using System.Data;

using DTO;

namespace DAO
{
    public class ThongTinHoaDonDAO
    {
        private static ThongTinHoaDonDAO instance;

        public static ThongTinHoaDonDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThongTinHoaDonDAO();
                return ThongTinHoaDonDAO.instance;
            }
        }

        private ThongTinHoaDonDAO() { }

        public void InsertBillInfo(int billID, int foodID, int amount)
        {
            string query = "USP_InsertBillInfo @BillID , @FoodID , @Amount";
            try
            {
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { billID, foodID, amount });
            }
            catch { }
        }

        public void DeleteBillInfoByBillID(int billID)
        {
            string query = string.Format("USP_DeleteBillInfoByBillID @BillID");
            try
            {
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { billID });
            }
            catch { }
        }
    }
}