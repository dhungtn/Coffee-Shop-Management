﻿using System;
using System.Collections.Generic;
using System.Data;

using DTO;

namespace DAO
{
    public class BanDAO
    {
        private static BanDAO instance;
        public static BanDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BanDAO();
                return instance;
            }
        }

        private BanDAO() { }

        public DataTable GetAllTable()
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery("USP_GetAllTable");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetTableList()
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery("USP_GetListTable");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SwitchTable(int tableID1, int tableID2)
        {
            try
            {
                DataProvider.Instance.ExecuteQuery("USP_SwitchTable @TableID1 , @TableID2", new object[] { tableID1, tableID2 });
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
                DataProvider.Instance.ExecuteNonQuery("USP_MergeTable @TableID1 , @TableID2", new object[] { tableID1, tableID2 });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertTable(string name)
        {
            string query = "USP_InsertTable @Name";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name });
            return result > 0;
        }

        public bool UpdateTable(int id, string name)
        {
            string query = "USP_UpdateTable @ID , @Name";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, name });
            return result > 0;
        }

        public bool DeleteTable(int id)
        {
            string query = string.Format("USP_DeleteTableFood @ID");
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
            return result > 0;
        }
    }
}