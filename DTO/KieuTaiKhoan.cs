namespace DTO
{
    public class KieuTaiKhoan
    {
        public int ID { get; set; }
        public string TypeName { get; set; }

        public KieuTaiKhoan() { }

        public KieuTaiKhoan(int id, string typeName)
        {
            this.ID = id;
            this.TypeName = typeName;
        }
    }
}