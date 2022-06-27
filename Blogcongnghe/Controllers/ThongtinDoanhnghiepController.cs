using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogcongnghe.Models;

namespace Blogcongnghe.Controllers
{
    public class ThongtinDoanhnghiepController : Controller
    {
        public IActionResult Index()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Blogcongnghe.Models.StoreContext)) as StoreContext;
            context.LaytatcaQuantrivien();
            context.Laythanhvien();
            return View(context);
        }
        public IActionResult Xulyguitin(thanhvien tv)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Blogcongnghe.Models.StoreContext)) as StoreContext;
            context.GuitinDoanhnghiep(tv);
            return RedirectToAction("Index");
        }
        public IActionResult Xulyguitinkhac(thanhvien tv)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Blogcongnghe.Models.StoreContext)) as StoreContext;
            context.GuitinDoanhnghiepKhac(tv);
            return RedirectToAction("Index");
        }
    }
}
