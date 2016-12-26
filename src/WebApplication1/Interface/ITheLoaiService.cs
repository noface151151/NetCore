using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entites;


namespace WebApplication1.Interface
{
    public interface ITheLoaiService
    {
        List<LoaiGiay> DanhSachLoaiSP();
        LoaiGiay LaytheoID(int id);
        bool ThemTheLoai(LoaiGiay loai);
        bool SuaTheLoai(LoaiGiay loai);
    }
}
