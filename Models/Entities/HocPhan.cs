using System.ComponentModel.DataAnnotations;

namespace _7485_NguyenVanHien.Models.Entities
{
    public class HocPhan
    {
        [Key]
        public string MaHP { get; set; } = string.Empty;
        public string TenHP { get; set; } = string.Empty;
        public int SoTinChi { get; set; }

    }
}
