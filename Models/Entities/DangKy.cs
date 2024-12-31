using System.ComponentModel.DataAnnotations;

namespace _7485_NguyenVanHien.Models.Entities
{
    public class DangKy
    {
        [Key]
        public int MaDK { get; set; }
        public DateTime NgayDK { get; set; }
        public string MaSV { get; set; } = string.Empty;
    }
}
