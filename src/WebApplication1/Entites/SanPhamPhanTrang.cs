using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entites
{
    public class SanPhamPhanTrang
    {
        public List<SanPham> SanPhams { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
