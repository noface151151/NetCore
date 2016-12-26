using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entites.DAL;
using WebApplication1.Interface;

namespace WebApplication1.ViewComponents
{
    public class LoaiSPViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() {
            return View("LoaiSPViewComponent");
        }
    }
}
