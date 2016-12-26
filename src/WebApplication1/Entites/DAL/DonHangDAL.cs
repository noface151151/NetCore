using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entites;
using WebApplication1.Interface;

namespace WebApplication1.Entites.DAL
{
    public class DonHangDAL: IDonHangService
    {
        ShopGiayDBContext db = null;
        public DonHangDAL() { db = new ShopGiayDBContext(); }

        public List<CtdonHang> CTDonHang(int madh)
        {
            return db.CtdonHang.Where(x => x.IdDonHang == madh).ToList();
        }

        public List<DonHang> DonHangKhachHang(int makh)
        {
            return db.DonHang.Where(x => x.IdKhachHang == makh).ToList();
        }

        public List<DonHang> GetAll()
        {
            return db.DonHang.ToList();
        }

        public bool SuaTrangThai(int id)
        {
            try
            {
                var donhang = db.DonHang.Where(x => x.Id == id).SingleOrDefault();
                donhang.TrangThai = true;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ThemCTDonHang(CtdonHang ct)
        {
            try
            {
                db.CtdonHang.Add(ct);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ThemDonHang(DonHang dh)
        {
            try
            {
                db.DonHang.Add(dh);
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
