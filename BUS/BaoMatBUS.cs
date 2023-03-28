using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAO;

namespace BUS
{
	public class BaoMatBUS
	{
		private static BaoMatBUS instance;

		public static BaoMatBUS Instance
		{
			get
			{
				if (instance == null)
                    instance = new BaoMatBUS();
				return instance;
			}
		}

		public BaoMatBUS() { }

		public void BackupData(string path)
		{
			try
			{
                BaoMatDAO.Instance.BackupData(path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void RestoreData(string path)
		{
			try
			{
                BaoMatDAO.Instance.RestoreData(path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
