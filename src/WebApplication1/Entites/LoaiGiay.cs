using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entites
{
    public partial class LoaiGiay
    {
        public LoaiGiay()
        {
            SanPham = new HashSet<SanPham>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Tên loại sản phẩm không được để trống")]
        public string TenLoai { get; set; }

        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
