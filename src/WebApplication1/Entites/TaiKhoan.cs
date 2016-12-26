using System;
using System.Collections.Generic;

namespace WebApplication1.Entites
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            DonHang = new HashSet<DonHang>();
        }

        public int Id { get; set; }
        public string TaiKhoan1 { get; set; }
        public string MatKhau { get; set; }

        public virtual ICollection<DonHang> DonHang { get; set; }
    }
}
