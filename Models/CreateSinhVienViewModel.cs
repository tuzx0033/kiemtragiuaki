using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace _7485_NguyenVanHien.Models
{
    public class CreateSinhVienViewModel
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string MaNganh { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? Hinh { get; set; } 

        public SelectList StudiesList { get; set; }
    }
}
