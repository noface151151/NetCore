using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entites;

namespace WebApplication1.Interface
{
    public interface ISanPhamService
    {
        List<SanPham> GetAll();
        List<SanPham> GiayNamPartial();
        List<SanPham> GiayNuPartial();
        IQueryable<SanPham> SanPhamTheoLoai(int id);
        SanPham SanPhamTheoID(int id);
        List<SanPham> SPLienQuanPartial(int id);
        void UpdateSoLuong(int idsp, int soluong);
        bool ThemSanPham(SanPham sp);
        bool SuaSanPham(SanPham sp);
    }
}
