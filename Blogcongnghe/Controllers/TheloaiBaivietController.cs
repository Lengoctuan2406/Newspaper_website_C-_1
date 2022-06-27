using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogcongnghe.Models;

namespace Blogcongnghe.Controllers
{
    public class TheloaiBaivietController : Controller
    {
        public IActionResult Index(int MATL)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Blogcongnghe.Models.StoreContext)) as StoreContext;
            context.LaydulieuBaivietTheloai1 = context.LaydulieuBaivietTheloai(MATL);
            context.Laythanhvien();
            context.Laytheloai();
            return View(context);
        }
    }
}
