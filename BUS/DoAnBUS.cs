using System;
using System.Collections.Generic;
using System.Data;

using DTO;
using DAO;

namespace BUS
{
    public class DoAnBUS
    {
        private static DoAnBUS instance;

        public static DoAnBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new DoAnBUS();
                return DoAnBUS.instance;
            }
        }

        private DoAnBUS() { }

        public DataTable GetAllFood()
        {
            try
            {
                return DoAnDAO.Instance.GetAllFood();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetListFoodByCategoryID(int categoryID)
        {
            try
            {
                return DoAnDAO.Instance.GetListFoodByCategoryID(categoryID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DoAn> SearchFoodByName(string name)
        {
            DataTable table;
            try
            {
                table = DoAnDAO.Instance.SearchFoodByName(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            List<DoAn> lstFood = new List<DoAn>();
            foreach (DataRow row in table.Rows)
            {
                DoAn food = new DoAn(row);
                lstFood.Add(food);
            }
            return lstFood;
        }

        public bool InsertFood(DoAn newFood)
        {
            return DoAnDAO.Instance.InsertFood(newFood);
        }

        public bool UpdateFood(DoAn food)
        {
            return DoAnDAO.Instance.UpdateFood(food);
        }

        public bool DeleteFood(int ID)
        {
            return DoAnDAO.Instance.DeleteFood(ID);
        }
    }
}