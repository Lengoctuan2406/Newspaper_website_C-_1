using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogcongnghe.Models;

namespace Blogcongnghe.Controllers
{
    public class ChitietBaivietController : Controller
    {
        public IActionResult Index(int MABAIDANG)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Blogcongnghe.Models.StoreContext)) as StoreContext;
            context.Laythanhvien();
            context.Layluotthich1 = context.Layluotthich(MABAIDANG);
            context.LaydulieuBaivietchitiet1 = context.LaydulieuBaivietchitiet(MABAIDANG);
            context.Laybinhluanchitiet1 = context.Laybinhluanchitiet(MABAIDANG);
            return View(context);
        }
        public IActionResult Xulycongluotthich(int MABAIDANG)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Blogcongnghe.Models.StoreContext)) as StoreContext;
            context.Congluotthich(MABAIDANG);
            return Redirect("/ChitietBaiviet/Index?MABAIDANG=" + MABAIDANG);
        }
        public IActionResult Xulytruluotthich(int MABAIDANG)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Blogcongnghe.Models.StoreContext)) as StoreContext;
            context.Truluotthich(MABAIDANG);
            return Redirect("/ChitietBaiviet/Index?MABAIDANG=" + MABAIDANG);
        }
        public IActionResult XulyBinhLuan(binhluan cm)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Blogcongnghe.Models.StoreContext)) as StoreContext;
            context.XulyBinhluanchitietBaiviet(cm);
            return Redirect("/ChitietBaiviet/Index?MABAIDANG=" + cm.MABAIDANG);
        }
        public IActionResult XulyBinhluankhac(int MABAIDANG, string NOIDUNG, string EMAIL, string TENTHANHVIEN)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Blogcongnghe.Models.StoreContext)) as StoreContext;
            context.XulyBinhluanchitietBaivietkhac(MABAIDANG, NOIDUNG, EMAIL, TENTHANHVIEN);
            return Redirect("/ChitietBaiviet/Index?MABAIDANG=" + MABAIDANG);
        }
    }
}
