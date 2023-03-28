using System;
using System.Data;

namespace DTO
{
    public class HoaDon
    {
        public int ID { get; set; }
        public DateTime CheckIn { get; set; }
        public int Status { get; set; }
        public int Discount { get; set; }

        public HoaDon(int id, DateTime checkIn, int status, int discount = 0)
        {
            this.ID = id;
            this.CheckIn = checkIn;
            this.Status = status;
            this.Discount = discount;
        }

        public HoaDon(DataRow row)
        {
            this.ID = (int)row["id"];
            this.CheckIn = (DateTime)row["checkIn"];

            this.Status = (int)row["status"];

            if (row["discount"].ToString() != "")
                this.Discount = (int)row["discount"];
        }
    }
}