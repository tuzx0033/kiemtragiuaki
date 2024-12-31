using System.ComponentModel.DataAnnotations;

namespace _7485_NguyenVanHien.Models.Entities
{
    public class NganhHoc
    {
        [Key]
        public string MaNganh { get; set; } = string.Empty;
        public string TenNganh { get; set; } = string.Empty;
    }
}
