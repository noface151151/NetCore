using System;
using System.Collections.Generic;

namespace WebApplication1.Entites
{
    public partial class CtdonHang
    {
        public int IdSanPham { get; set; }
        public int IdDonHang { get; set; }
        public int? SoLuong { get; set; }

        public virtual DonHang IdDonHangNavigation { get; set; }
        public virtual SanPham IdSanPhamNavigation { get; set; }
    }
}
