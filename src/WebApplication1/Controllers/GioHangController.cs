using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebApplication1.Entites.DAL;
using WebApplication1.Entites;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class GioHangController : Controller
    {
        SanPhamDAL spDAL = new SanPhamDAL();

        public List<GioHang> LayGioHang()
        {
            List<GioHang> list;
            if (HttpContext.Session.GetString("SessionGioHang") == null)

            {
                list = new List<GioHang>();
                HttpContext.Session.SetString("SessionGioHang", JsonConvert.SerializeObject(list));
            }

            else
            {
                list = JsonConvert.DeserializeObject<List<GioHang>>(HttpContext.Session.GetString("SessionGioHang"));
            }
            return list;
        }
        // GET: /<controller>/
       
        public RedirectResult Themgiohang(int idSP,string url)
        {
            List<GioHang> ListGioHang = LayGioHang();
            GioHang sanpham = ListGioHang.Find(x => x.Id == idSP);
            if(sanpham==null)
            {
                var newsp = spDAL.SanPhamTheoID(idSP);
                GioHang gh = new GioHang();
                gh.Id = newsp.Id;
                gh.TenSanPham = newsp.TenSanPham;
                gh.SoLuong = 1;
                gh.HinhAnh = newsp.HinhAnh;
                gh.Gia = newsp.Gia;
                ListGioHang.Add(gh);

            }
            else
            {
                sanpham.SoLuong++;
            }
            HttpContext.Session.SetString("SessionGioHang", JsonConvert.SerializeObject(ListGioHang));
            return Redirect(url);
        }
        public ActionResult TrangGioHang()
        {
            List<GioHang> ListGioHang = LayGioHang();
            ViewBag.TongCong = ListGioHang.Sum(x => x.ThanhTien);
            return View("TrangGioHang", ListGioHang);
        }
        public RedirectToActionResult XoaGioHang(int masp)
        {
            List<GioHang> ListGioHang = LayGioHang();
            foreach(var item in ListGioHang)
            {
                if(item.Id==masp)
                {
                    ListGioHang.Remove(item);
                    break;
                }
            }
            HttpContext.Session.SetString("SessionGioHang", JsonConvert.SerializeObject(ListGioHang));
            return RedirectToAction("TrangGioHang", "GioHang");
        }
     [HttpPost]
        public JsonResult SuaGioHang(int masp,int txtsoluong)
        {
            List<GioHang> ListGioHang = LayGioHang();

            foreach (var item in ListGioHang)
            {
                if (item.Id == masp)
                {
                    if (txtsoluong == 0)
                    {
                        ListGioHang.Remove(item);
                        break;
                    }
                    else
                    {
                        item.SoLuong = 0;
                        item.SoLuong = txtsoluong;
                        break;
                    }
                }
            }
            HttpContext.Session.SetString("SessionGioHang", JsonConvert.SerializeObject(ListGioHang));
            return Json(new { data = "success" });
        }


    }
}
