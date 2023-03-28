using System;
using System.Data;
using System.Collections.Generic;

using DAO;
using DTO;

namespace BUS
{
    public class DanhMucBUS
    {
        private static DanhMucBUS instance;

        public static DanhMucBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new DanhMucBUS();
                return DanhMucBUS.instance;
            }
        }

        private DanhMucBUS() { }

        public DataTable GetAllCategory()
        {
            try
            {
                return DanhMucDAO.Instance.GetAllCategory();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertCategory(string name)
        {
            try
            {
                return DanhMucDAO.Instance.InsertCategory(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateCategory(int id, string name)
        {
            try
            {
                return DanhMucDAO.Instance.UpdateCategory(id, name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeteleCategory(int id)
        {
            try
            {
                return DanhMucDAO.Instance.DeteleCategory(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DanhMuc> SearchCategoryByName(string name)
        {
            try
            {
                return DanhMucDAO.Instance.SearchCategoryByName(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}