using _7485_NguyenVanHien.Models;
using _7485_NguyenVanHien.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace _7485_NguyenVanHien.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appdbcontext;
        public HomeController(AppDbContext appdbcontext)
        {
            _appdbcontext = appdbcontext;
        }
        public async Task<IActionResult> Index()
        {
            var r = await _appdbcontext.SinhVien.Select(r => new ListSinhVienVm()
            {
                MaSV = r.MaSV,
                HoTen = r.HoTen,
                GioiTinh = r.GioiTinh,
                NgaySinh = r.NgaySinh,
                Hinh = r.Hinh,
                MaNganh = r.MaNganh,
            }).ToListAsync();
            return View(r);
        }
        public IActionResult Create()
        {
            var StudiesList = _appdbcontext.NganhHoc.Select(r => new ListNganhHocVm()
            {
                MaNganh = r.MaNganh,
                TenNganh = r.TenNganh,
            }).ToList();

            ViewBag.StudiesList = new SelectList(StudiesList, "MaNganh","TenNganh");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSinhVienViewModel s)
        {
            if (string.IsNullOrEmpty(s.MaSV))
            {
                TempData["Message"] = "Mã sinh viên không được trống.";
                return RedirectToAction("Create");
            }
            if (string.IsNullOrEmpty(s.HoTen))
            {
                TempData["Message"] = "Họ tên không được trống.";
                return RedirectToAction("Create");
            }
            if (s.NgaySinh.Year.ToString() == "1" || s.NgaySinh.Date.ToString() == "1" || s.NgaySinh.Date.ToString() == "1")
            {
                TempData["Message"] = "Ngày sinh không được trống.";
                return RedirectToAction("Create");
            }
            try
            {
                var sinhVien = new SinhVien
                {
                    MaSV = s.MaSV,
                    HoTen = s.HoTen,
                    GioiTinh = s.GioiTinh,
                    NgaySinh = s.NgaySinh,
                    MaNganh = s.MaNganh
                };

                if (s.Hinh != null && s.Hinh.Length > 0)
                {
                    var fileName = Path.GetFileName(Guid.NewGuid().ToString() + Path.GetExtension(s.Hinh.FileName));
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content/images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        s.Hinh.CopyTo(stream);
                    }
                    sinhVien.Hinh = fileName;
                }

                _appdbcontext.Add(sinhVien);
                await _appdbcontext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {

            }
            return View(s);
        }
        public async Task<IActionResult> Edit(string MaSV)
        {
            if (MaSV == null)
            {
                return NotFound();
            }

            var StudiesList = _appdbcontext.NganhHoc.Select(r => new ListNganhHocVm()
            {
                MaNganh = r.MaNganh,
                TenNganh = r.TenNganh,
            }).ToList();

            ViewBag.StudiesList = new SelectList(StudiesList, "MaNganh", "TenNganh");

            var v = await _appdbcontext.SinhVien.FindAsync(MaSV);
            if (v == null)
            {
                return NotFound();
            }
            return View(v);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SinhVien s, IFormFile? Hinh)
        {
            if (string.IsNullOrEmpty(s.HoTen))
            {
                TempData["Message"] = "Họ tên không được trống.";
                return RedirectToAction("Edit", "Home", new { MaSV = s.MaSV });
            }
            if (s.NgaySinh.Year.ToString() == "1" || s.NgaySinh.Date.ToString() == "1" || s.NgaySinh.Date.ToString() == "1")
            {
                TempData["Message"] = "Ngày sinh không được trống.";
                return RedirectToAction("Edit", "Home", new { MaSV = s.MaSV });
            }
            try
            {
                if (Hinh != null && Hinh.Length > 0)
                {
                    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content", "images");
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Hinh.FileName);
                    string filePath = Path.Combine(uploadsFolder, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await Hinh.CopyToAsync(fileStream);
                    }

                    s.Hinh = fileName;
                }
                _appdbcontext.Update(s);
                await _appdbcontext.SaveChangesAsync();
            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
            return View(s);
        }
        public async Task<IActionResult> Details(string MaSV)
        {
            if (MaSV == null)
            {
                return NotFound();
            }

            var v = await _appdbcontext.SinhVien.FindAsync(MaSV);
            if (v == null)
            {
                return NotFound();
            }
            return View(v);
        }
        public async Task<IActionResult> Delete(string MaSV)
        {
            if (MaSV == null)
            {
                return NotFound();
            }

            var v = await _appdbcontext.SinhVien.FindAsync(MaSV);
            if (v == null)
            {
                return NotFound();
            }
            return View(v);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(SinhVien s)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _appdbcontext.Remove(s);
                    await _appdbcontext.SaveChangesAsync();
                }
                catch
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(s);
        }
    }
}
