using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogcongnghe.Models;

namespace Blogcongnghe.Controllers
{
    public class ChitietTacgiaController : Controller
    {
        public IActionResult Index(int MATV)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Blogcongnghe.Models.StoreContext)) as StoreContext;
            context.Laythanhvien();
            context.LaythongtinTacgia1 = context.LaythongtinTacgia(MATV);
            context.LaybaivietTacgia1 = context.LaybaivietTacgia(MATV);
            return View(context);
        }
    }
}
