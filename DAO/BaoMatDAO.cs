using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BaoMatDAO
    {
        private static BaoMatDAO instance;

        public static BaoMatDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BaoMatDAO();
                return BaoMatDAO.instance;
            }
        }

        private BaoMatDAO() { }

        public void BackupData(string strpath)
        {
            string query = string.Format("BACKUP DATABASE CoffeeManagement TO DISK='{0}'", strpath);
            try
            {
                DataProvider.Instance.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RestoreData(string strpath)
        {
            string query = string.Format("USE master RESTORE DATABASE CoffeeManagement FROM DISK='{0}'", strpath);
            try
            {
                DataProvider.Instance.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}