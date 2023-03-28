using System;
using System.Data;
using System.Collections.Generic;

using DAO;
using DTO;

namespace BUS
{
    public class HoaDonTamBUS
    {
        private static HoaDonTamBUS instance;

        public static HoaDonTamBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new HoaDonTamBUS();
                return HoaDonTamBUS.instance;
            }
        }

        private HoaDonTamBUS() { }

        public List<TempBill> GetListTempBillByTableID(int tableID)
        {
            DataTable table;
            try
            {
                table = HoaDonTamDAO.Instance.GetListTempBillByTableID(tableID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            List<TempBill> lstTempBill = new List<TempBill>();
            foreach (DataRow row in table.Rows)
            {
                TempBill tmp = new TempBill(row);
                lstTempBill.Add(tmp);
            }
            return lstTempBill;
        }
    }
}