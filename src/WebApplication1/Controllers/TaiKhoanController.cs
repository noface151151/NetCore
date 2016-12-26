using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entites.DAL;
using WebApplication1.Entites;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebApplication1.Interface;



// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class TaiKhoanController : Controller
    {

        private ITaiKhoanService _TaiKhoanService;

        public TaiKhoanController(ITaiKhoanService TaiKhoanService) {
            _TaiKhoanService = TaiKhoanService;
        }
        [HttpPost]
        public IActionResult DangKy([FromBodyAttribute]TaiKhoan tk)
        {

            bool check = _TaiKhoanService.ThemTaiKhoan(tk);
            if (check == true)
                return Json(new { status = true });
            else
                return Json(new { status = false });
        }

        [HttpPost]
        public IActionResult DangNhap([FromBodyAttribute]TaiKhoan tk)
        {
            var taikhoan = _TaiKhoanService.GetbyUsername(tk.TaiKhoan1);
            if(taikhoan==null)
            {
                return Json(new { data = 0 });
            }
            else if(taikhoan.MatKhau!=tk.MatKhau)
            {
                return Json(new { data = 1 });
            }
            else
            {
                HttpContext.Session.SetString("taikhoan", JsonConvert.SerializeObject(taikhoan));
                return Json(new { data = "success" });
            }
         
        }
        public RedirectToActionResult DangXuat()
        {
            HttpContext.Session.Remove("taikhoan");
            return RedirectToAction("Index", "Home");
        }
    }
}

