using System;
using System.Collections.Generic;
using System.Data;

using DTO;

namespace DAO
{
    public class HoaDonTamDAO
    {
        private static HoaDonTamDAO instance;

        public static HoaDonTamDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new HoaDonTamDAO();
                return HoaDonTamDAO.instance;
            }
        }

        private HoaDonTamDAO() { }

        public DataTable GetListTempBillByTableID(int tableID)
        {

            string query = "USP_GetListTempBillByTableID @TableID";
            try
            {
                return DataProvider.Instance.ExecuteQuery(query, new object[] { tableID });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}