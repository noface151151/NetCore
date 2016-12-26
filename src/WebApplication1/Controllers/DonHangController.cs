using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entites.DAL;
using WebApplication1.Interface;
using WebApplication1.Entites;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class DonHangController : Controller
    {
        private IDonHangService _DonHangService;
        private ISanPhamService _SanPhamService;
        public DonHangController(IDonHangService DonHangService, ISanPhamService SanPhamService) {
            _DonHangService = DonHangService;
            _SanPhamService = SanPhamService;
    }
        // GET: /<controller>/
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

        [HttpGet]
        public IActionResult ThanhToan()
        {
           
            return View("DonHang");
        }

        [HttpPost]
        public IActionResult ThanhToan(DonHangDTO dh)
        {
            if(ModelState.IsValid)
            {
                var sessionTaiKhoan = HttpContext.Session.GetString("taikhoan");
                var taikhoan = JsonConvert.DeserializeObject<TaiKhoan>(sessionTaiKhoan);
                var lisgiohang = LayGioHang();
                DonHang donhang = new DonHang();
                donhang.NgayDat = DateTime.Now;
                donhang.NgayGiao = dh.NgayGiao;
                donhang.NguoiNhan = dh.NguoiNhan;
                donhang.DiaChi = dh.DiaChi;
                donhang.SoDienThoai = dh.SoDienThoai;
                donhang.TrangThai = false;
                donhang.IdKhachHang = taikhoan.Id;
                donhang.TongTien = lisgiohang.Sum(x => x.ThanhTien);

                bool checkDonHang=_DonHangService.ThemDonHang(donhang);
                if(checkDonHang==true)
                {
                    foreach(var item in lisgiohang)
                    {
                        CtdonHang ctdh = new CtdonHang();
                        ctdh.IdDonHang = donhang.Id;
                        ctdh.IdSanPham = item.Id;
                        ctdh.SoLuong = item.SoLuong;
                      var checkCTDH= _DonHangService.ThemCTDonHang(ctdh);
                        if(checkCTDH==true)
                        {
                            _SanPhamService.UpdateSoLuong(item.Id,item.SoLuong);
                        }

                    }
                    HttpContext.Session.Remove("SessionGioHang");
                    ViewBag.ThongBao = "Đã đặt hàng thành công";
                    ModelState.Clear();
                    return View("DonHang");
                }
                
            }
            return View("DonHang");
        }
        public IActionResult DonHangKhachHang(int makh)
        {
            return View("DonHangKhachHang", makh);
        }
        public IActionResult ChiTietDonHang(int idDonHang)
        {
            return View("ChiTietDonHang", idDonHang);
        }
    }
}
