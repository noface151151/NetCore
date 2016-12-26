using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interface;

namespace WebApplication1.Entites.DAL
{
    public class LoaiSPDAL: ITheLoaiService
    {
        ShopGiayDBContext db = null;
        public LoaiSPDAL() { db = new ShopGiayDBContext(); }
        public List<LoaiGiay> DanhSachLoaiSP()
        {
            return db.LoaiGiay.ToList();
        }
        public LoaiGiay LaytheoID(int id)
        {
            return db.LoaiGiay.Where(x => x.Id == id).SingleOrDefault();
        }

        public bool SuaTheLoai(LoaiGiay loai)
        {
            var loaisp = db.LoaiGiay.Where(x => x.Id == loai.Id).SingleOrDefault();
            if (loaisp == null)
                return false;
            try
            {
                loaisp.TenLoai = loai.TenLoai;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ThemTheLoai(LoaiGiay loai)
        {
            try
            {
                db.LoaiGiay.Add(loai);
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
