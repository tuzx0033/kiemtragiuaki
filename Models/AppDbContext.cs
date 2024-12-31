using _7485_NguyenVanHien.Models.Entities;
using Microsoft.EntityFrameworkCore;
using static NuGet.Packaging.PackagingConstants;

namespace _7485_NguyenVanHien.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<NganhHoc> NganhHoc { get; set; }
        public DbSet<SinhVien> SinhVien { get; set; }
        public DbSet<HocPhan> HocPhan { get; set; }
        public DbSet<DangKy> DangKy { get; set; }
        public DbSet<ChiTietDangKy> ChiTietDangKy { get; set; }
    }
}
