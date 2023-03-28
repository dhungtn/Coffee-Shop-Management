using System.Data;

namespace DTO
{
    public class Ban
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public Ban(int id, string name, string status)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
        }

        public Ban(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.Name = row["Name"].ToString();
            this.Status = row["Status"].ToString();
        }
    }
}