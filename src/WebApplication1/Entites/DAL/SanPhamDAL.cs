using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interface;

namespace WebApplication1.Entites.DAL
{
    public class SanPhamDAL:ISanPhamService
    {
        ShopGiayDBContext db = null;
        public SanPhamDAL() { db = new ShopGiayDBContext(); }

         public List<SanPham> GetAll()
         {
             return db.SanPham.ToList();
         }
         public List<SanPham> GiayNamPartial() {
             return db.SanPham.Where(x => x.Loai == 1&&x.SoLuong>0).Take(5).ToList();
         }
         public List<SanPham> GiayNuPartial() {
             return db.SanPham.Where(x => x.Loai == 2&&x.SoLuong>0).Take(5).ToList();
         }
         public IQueryable<SanPham> SanPhamTheoLoai(int id)
         {
             return db.SanPham.Where(x => x.Loai == id&&x.SoLuong > 0);
         }
         public SanPham SanPhamTheoID(int id)
         {
             return db.SanPham.Where(x => x.Id == id&& x.SoLuong > 0).SingleOrDefault();
         }
         public List<SanPham> SPLienQuanPartial(int id)
         {
            List<SanPham> sp= db.SanPham.Where(x => x.Loai == id && x.SoLuong > 0).Take(5).ToList();
            return sp;
         }

        public void UpdateSoLuong(int idsp, int soluong)
        {
            var sp = db.SanPham.Where(x => x.Id == idsp && x.SoLuong > 0).SingleOrDefault();
            sp.SoLuong = sp.SoLuong - soluong;
            db.SaveChanges();
        }

        public bool ThemSanPham(SanPham sp)
        {
            try
            {
                db.SanPham.Add(sp);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool SuaSanPham(SanPham sp)
        {
            try
            {
                var sanpham = db.SanPham.Where(x => x.Id == sp.Id).SingleOrDefault();
                if(sanpham==null)
                {
                    return false;
                }
                sanpham.TenSanPham = sp.TenSanPham;
                sanpham.Gia = sp.Gia;
                sanpham.HinhAnh = sp.HinhAnh;
                sanpham.Loai = sp.Loai;
                sanpham.MoTa = sp.MoTa;
                sanpham.SoLuong = sp.SoLuong;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
