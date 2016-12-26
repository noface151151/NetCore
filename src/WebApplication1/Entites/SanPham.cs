using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entites
{
    public partial class SanPham
    {
        public SanPham()
        {
            CtdonHang = new HashSet<CtdonHang>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string TenSanPham { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Giá bán phải là số")]
        public decimal? Gia { get; set; }

        [Required(ErrorMessage = "Số lượng không được để trống")]
        public int? SoLuong { get; set; }

        [Required(ErrorMessage = "Mô tả không được để trống")]
        public string MoTa { get; set; }

        public int? Loai { get; set; }
        public string HinhAnh { get; set; }

        public virtual ICollection<CtdonHang> CtdonHang { get; set; }
        public virtual LoaiGiay LoaiNavigation { get; set; }
    }
}
