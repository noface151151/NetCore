using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interface;

namespace WebApplication1.Entites.DAL
{
    public class TaiKhoanDAL: ITaiKhoanService
    {
        ShopGiayDBContext db = null;
        public TaiKhoanDAL() { db = new ShopGiayDBContext(); }
        public bool ThemTaiKhoan(TaiKhoan tk)
        {
            if(GetbyUsername(tk.TaiKhoan1)!=null)
            {
                return false;
            }
            try
            {
                db.TaiKhoan.Add(tk);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public TaiKhoan GetbyUsername(string username)
        {
            return db.TaiKhoan.Where(x => x.TaiKhoan1.ToLower() == username.ToLower()).SingleOrDefault();
        }
    }
}
