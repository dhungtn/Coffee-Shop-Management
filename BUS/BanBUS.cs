using System;
using System.Collections.Generic;
using System.Data;

using DAO;
using DTO;

namespace BUS
{
    public class BanBUS
    {
        private static BanBUS instance;

        public static BanBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new BanBUS();
                return BanBUS.instance;
            }
        }

        public DataTable GetAllTable()
        {
            try
            {
                return BanDAO.Instance.GetAllTable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ban> GetTableList()
        {
            DataTable table;
            try
            {
                table = BanDAO.Instance.GetTableList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            List<Ban> lstTable = new List<Ban>();
            foreach (DataRow row in table.Rows)
            {
                Ban tb = new Ban(row);
                lstTable.Add(tb);
            }
            return lstTable;
        }

        public void SwitchTable(int tableID1, int tableID2)
        {
            try
            {
                BanDAO.Instance.SwitchTable(tableID1, tableID2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MergeTable(int tableID1, int tableID2)
        {
            try
            {
                BanDAO.Instance.MergeTable(tableID1, tableID2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertTable(string name)
        {
            return BanDAO.Instance.InsertTable(name);
        }

        public bool UpdateTable(int id, string name)
        {
            return BanDAO.Instance.UpdateTable(id, name);
        }

        public bool DeleteTable(int id)
        {
            return BanDAO.Instance.DeleteTable(id);
        }
    }
}