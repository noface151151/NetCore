using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entites;

namespace WebApplication1.Interface
{
    public interface ITaiKhoanService
    {
        bool ThemTaiKhoan(TaiKhoan tk);
        TaiKhoan GetbyUsername(string username);
    }
}
