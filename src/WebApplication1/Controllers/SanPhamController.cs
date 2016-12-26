using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entites.DAL;
using WebApplication1.Interface;
using WebApplication1.Entites;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class SanPhamController : Controller
    {
        private ISanPhamService _SanPhamService;
        private ITheLoaiService _TheLoaiService;
        public SanPhamController(ISanPhamService SanPhamService, ITheLoaiService TheLoaiService)
        {
            _SanPhamService = SanPhamService;
            _TheLoaiService= TheLoaiService;
        }

        // GET: /<controller>/

          public IActionResult SanPhamTheoLoai(int? page,int id = 0)
       {
            int pageNumber = (page ?? 1);
            int pageSize = 4;
            var data = _SanPhamService.SanPhamTheoLoai(id);
            var pagedata = data.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return View("SanPhamTheoLoai", new SanPhamPhanTrang {SanPhams=pagedata,PagingInfo=new PagingInfo
            {
                CurrentPage = pageNumber,
                ItemsPerPage = pageSize,
                TotalItems = data.Count()
            }
            });
        }
        public IActionResult ChiTietSanPham(int id=0)
        {
            var sp = _SanPhamService.SanPhamTheoID(id);
            if(sp==null)
            {
                string error = "Không tồn tại sản phẩm";
                return View("Error", error);
            }
            var theloaiSP = _TheLoaiService.LaytheoID(sp.Loai.Value);
            ViewBag.TenLoaiSP = theloaiSP.TenLoai;
            ViewBag.Id = theloaiSP.Id;
            return View("ChiTietSanPham", id);
        }
    }
}
