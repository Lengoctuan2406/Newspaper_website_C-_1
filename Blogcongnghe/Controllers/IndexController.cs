using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogcongnghe.Models;
using System.IO;

namespace Blogcongnghe.Controllers
{
    public class IndexController : Controller
    {
        public IActionResult Index(string CHUOI = "")
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Blogcongnghe.Models.StoreContext)) as StoreContext;
            context.LaydulieuBaiviet1 = context.LaydulieuBaiviet(CHUOI);
            context.Laythanhvien();
            context.Laytheloai();
            return View(context);
        }
    }
}
