using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entites
{
    public class GioHang
    {
        public int Id { get; set; }
        public string TenSanPham { get; set; }
        public decimal? Gia { get; set; }
        public int SoLuong { get; set; }
        public string HinhAnh { get; set; }
        public decimal? ThanhTien { get { return SoLuong * Gia; } }
    }
}
