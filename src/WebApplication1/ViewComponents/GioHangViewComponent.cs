using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entites;

namespace WebApplication1.ViewComponents
{
    public class GioHangViewComponent: ViewComponent
    {
        public List<GioHang> LayGioHang()
        {
            List<GioHang> list;
            if (HttpContext.Session.GetString("SessionGioHang")==null)
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
        public int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> listGioHang = LayGioHang();
            if (listGioHang != null)
            {
                iTongSoLuong = listGioHang.Sum(x => x.SoLuong);
            }
            return iTongSoLuong;
        }

        public decimal? TongTien()
        {
            decimal? TongTien = 0;
            List<GioHang> listGioHang = LayGioHang();
            if (listGioHang != null)
            {
                TongTien = listGioHang.Sum(x => x.ThanhTien);
            }
            return TongTien;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (TongSoLuong() == 0)
            {
                return View("GioHangPartial");
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View("GioHangPartial");
        }
    }
}
