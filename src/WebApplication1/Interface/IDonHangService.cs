using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entites;

namespace WebApplication1.Interface
{
    public interface IDonHangService
    {
        bool ThemDonHang(DonHang dh);
        List<DonHang> DonHangKhachHang(int makh);
        List<CtdonHang> CTDonHang(int madh);
        bool ThemCTDonHang(CtdonHang ct);
        List<DonHang> GetAll();
        bool SuaTrangThai(int id);

    }
}
