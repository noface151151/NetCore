using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entites
{
    public class DonHangDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ngày giao không được để trống")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayGiao { get; set; }

        [Required(ErrorMessage = "Người nhận không được để trống")]
        public string NguoiNhan { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string SoDienThoai { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string DiaChi { get; set; }


    }
}
