using System.ComponentModel.DataAnnotations;

namespace _7485_NguyenVanHien.Models.Entities
{
    public class ChiTietDangKy
    {
        [Key]
        public int MaDK { get; set; }
        public string MaHP { get; set; } = string.Empty;
    }
}
