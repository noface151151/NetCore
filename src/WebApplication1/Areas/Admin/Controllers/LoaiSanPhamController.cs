using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interface;
using WebApplication1.Entites;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoaiSanPhamController : Controller
    {

        private ISanPhamService _SanPhamService;
        private ITheLoaiService _TheLoaiService;
        public LoaiSanPhamController(ISanPhamService SanPhamService, ITheLoaiService TheLoaiService)
        {
            _SanPhamService = SanPhamService;
            _TheLoaiService = TheLoaiService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public IActionResult ThemTheLoai()
        {
            return View("ThemTheLoai");
        }

        [HttpPost]
        public IActionResult ThemTheLoai(LoaiGiay loai)
        {
            if(ModelState.IsValid)
            {
                if(_TheLoaiService.ThemTheLoai(loai))
                {
                    ModelState.Clear();
                    ViewBag.ThanhCong = "Thêm thể loại thành công";
                }
                else
                {
                    ModelState.AddModelError("","Thêm thể loại thất bại");
                }
            }
            return View("ThemTheLoai");
        }
        [HttpGet]
        public IActionResult SuaTheLoai(int id)
        {
            return View("SuaTheLoai",_TheLoaiService.LaytheoID(id));
        }

        [HttpPost]
        public IActionResult SuaTheLoai(LoaiGiay loai)
        {
            if (ModelState.IsValid)
            {
                if (_TheLoaiService.SuaTheLoai(loai))
                {
                    ModelState.Clear();
                    ViewBag.ThanhCong = "Sửa thể loại thành công";
                }
                else
                {
                    ModelState.AddModelError("", "Sửa thể loại thất bại");
                }
            }
            return View("SuaTheLoai", _TheLoaiService.LaytheoID(loai.Id));
        }

    }
}
