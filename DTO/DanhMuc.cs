using System.Data;

namespace DTO
{
    public class DanhMuc
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public DanhMuc() { }

        public DanhMuc(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public DanhMuc(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.Name = row["Name"].ToString();
        }
    }
}