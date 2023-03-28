using System.Data;

namespace DTO
{
    public class DoAn
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public int Price { get; set; }

        public DoAn(string name, int categoryID, int price)
        {
            this.Name = name;
            this.CategoryID = categoryID;
            this.Price = price;
        }

        public DoAn(int id, string name, int categoryID, int price)
        {
            this.ID = id;
            this.Name = name;
            this.CategoryID = categoryID;
            this.Price = price;
        }

        public DoAn(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.Name = row["Name"].ToString();
            this.CategoryID = (int)row["CategoryID"];
            this.Price = (int)row["Price"];
        }
    }
}