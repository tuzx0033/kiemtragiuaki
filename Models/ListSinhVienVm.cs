namespace _7485_NguyenVanHien.Models
{
    public class ListSinhVienVm
    {
        public string MaSV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public string GioiTinh { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string? Hinh { get; set; }
        public string MaNganh { get; set; } = string.Empty;
    }
}
