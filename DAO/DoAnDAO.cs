using System;
using System.Collections.Generic;
using System.Data;

using DTO;

namespace DAO
{
    public class DoAnDAO
    {
        private static DoAnDAO instance;

        public static DoAnDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DoAnDAO();
                return DoAnDAO.instance;
            }
        }

        private DoAnDAO() { }

        public DataTable GetAllFood()
        {
            string query = "USP_GetAllFood";
            try
            {
                return DataProvider.Instance.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetListFoodByCategoryID(int categoryID)
        {
            string query = "USP_GetListFoodByCategoryID @CategoryID";
            try
            {
                return DataProvider.Instance.ExecuteQuery(query, new object[] { categoryID });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchFoodByName(string name)
        {
            string query = string.Format("USP_SearchFoodByName @Name");
            try
            {
                return DataProvider.Instance.ExecuteQuery(query, new object[] { name });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertFood(DoAn newFood)
        {
            string query = string.Format("USP_InsertFood @Name , @CategoryID , @Price");
            int result;
            try
            {
                result = DataProvider.Instance.ExecuteNonQuery(query,
                    new object[] { newFood.Name, newFood.CategoryID, newFood.Price });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result > 0;
        }

        public bool UpdateFood(DoAn food)
        {
            string query = string.Format("USP_UpdateFood @ID , @Name , @CategoryID , @Price");
            int result;
            try
            {
                result = DataProvider.Instance.ExecuteNonQuery(query,
                    new object[] { food.ID, food.Name, food.CategoryID, food.Price });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result > 0;
        }

        public bool DeleteFood(int ID)
        {
            int result;
            try
            {
                result = DataProvider.Instance.ExecuteNonQuery("USP_DeleteFood @ID", new object[] { ID });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result > 0;
        }
    }
}