using System.ComponentModel.DataAnnotations;

namespace _7485_NguyenVanHien.Models.Entities
{
    public class SinhVien
    {
        [Key]
        public string MaSV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public string GioiTinh { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string Hinh { get; set; } = string.Empty;
        public string MaNganh { get; set; } = string.Empty;
    }
}
