using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interface;
using WebApplication1.Entites;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamAdController : Controller
    {
        private ISanPhamService _SanPhamService;
        private ITheLoaiService _TheLoaiService;
        private IHostingEnvironment _environment;
        public SanPhamAdController(ISanPhamService SanPhamService, ITheLoaiService TheLoaiService, IHostingEnvironment environment)
        {
            _SanPhamService = SanPhamService;
            _TheLoaiService = TheLoaiService;
            _environment = environment;
        }
        // GET: /<controller>/
        public IActionResult ChiTietSanPhamAd(int id)
        {
            return View("ChiTietSanPhamAd",id);
        }

        [HttpGet]
        public IActionResult ThemSanPham()
        {
            return View("ThemSanPham");
        }

        [HttpPost]
        public async Task<IActionResult> ThemSanPham(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                int flag = 0;
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        flag = 1;
                        var file = Image;
                        var uploads = Path.Combine(_environment.WebRootPath, "images");

                        if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse
                                (file.ContentDisposition).FileName.Trim('"');
                            var path = Path.Combine(uploads, file.FileName);
                            if (System.IO.File.Exists(path))
                            {
                                ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                                return View("ThemSanPham");
                            }
                            else
                            {
                                using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                                {
                                    await file.CopyToAsync(fileStream);
                                    sp.HinhAnh = file.FileName;
                                }
                            }
                        }
                    }

                }
                if(flag==0)
                {
                    ViewBag.ThongBao = "Chưa chọn hình ảnh";
                    return View("ThemSanPham");
                }
               if(_SanPhamService.ThemSanPham(sp))
                {
                    ViewBag.ThanhCong = "Sản phẩm thêm thành công";
                    ModelState.Clear();
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }
            }
            return View("ThemSanPham");
        }
        [HttpGet]
        public IActionResult SuaSanPham(int id)
        {
            var sanpham = _SanPhamService.SanPhamTheoID(id);
            if(sanpham==null)
            {
                ViewBag.KhongTonTai = "Không tồn tại sản phẩm";
                return View("SuaSanPham");
            }
            return View("SuaSanPham",sanpham);
        }

        [HttpPost]
        public async Task<IActionResult> SuaSanPham(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                int flag = 0;
                var spbandau = _SanPhamService.SanPhamTheoID(sp.Id);
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        flag = 1;
                        var file = Image;
                        var uploads = Path.Combine(_environment.WebRootPath, "images");

                        if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse
                                (file.ContentDisposition).FileName.Trim('"');
                            var path = Path.Combine(uploads, file.FileName);
                            if (System.IO.File.Exists(path))
                            {
                                ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                                return View("SuaSanPham", spbandau);
                            }
                            else
                            {
                                using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                                {
                                    await file.CopyToAsync(fileStream);
                                    sp.HinhAnh = file.FileName;
                                }
                            }
                        }
                    }

                }
                if(flag==0)
                {
                    sp.HinhAnh = spbandau.HinhAnh;
                }
                if (_SanPhamService.SuaSanPham(sp))
                {
                    ViewBag.ThanhCong = "Sản phẩm được sửa thành công";
                    ModelState.Clear();
                }
                else
                {
                    ModelState.AddModelError("", "Sửa thất bại thất bại");
                }
            }
            return View("SuaSanPham",_SanPhamService.SanPhamTheoID(sp.Id));
        }
        public IActionResult SachTheoTheLoai(int id)
        {
            return View("SachTheoTheLoai", id);
        }
    }
}
