using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interface;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DonHangController : Controller
    {
        private IDonHangService _DonHangService;
        public DonHangController(IDonHangService DonHangService)
        {
            _DonHangService = DonHangService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("Index");
        }
        public IActionResult ChiTietDonHang(int id)
        {
            return View("ChiTietDonHang",id);
        }

        [HttpPost]
        public JsonResult DoiTrangThai(int id)
        {
            if(_DonHangService.SuaTrangThai(id))
            {
                return Json(new { status = true });
            }
            else
            {
                return Json(new { status = false });
            }
        }
    }
}
