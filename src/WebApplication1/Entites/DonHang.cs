using System;
using System.Collections.Generic;

namespace WebApplication1.Entites
{
    public partial class DonHang
    {
        public DonHang()
        {
            CtdonHang = new HashSet<CtdonHang>();
        }

        public int Id { get; set; }
        public DateTime? NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }
        public string NguoiNhan { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public bool? TrangThai { get; set; }
        public int? IdKhachHang { get; set; }
        public decimal? TongTien { get; set; }

        public virtual ICollection<CtdonHang> CtdonHang { get; set; }
        public virtual TaiKhoan IdKhachHangNavigation { get; set; }
    }
}
