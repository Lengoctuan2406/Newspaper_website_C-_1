using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogcongnghe.Areas.Admin.Models;

namespace Blogcongnghe.Areas.Admin.Controllers
{
    public class ThanhvienController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.Laytatcathanhvien();
            context.Layquantrivien();
            return View(context);
        }
        [Area("Admin")]
        public IActionResult IndexTinnhan()
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.Laytatcathanhvien();
            context.Layquantrivien();
            return View(context);
        }
        [Area("Admin")]
        public IActionResult Traloitinnhan(string TIN, string EMAIL)
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.Xulyguigmail(TIN, EMAIL);
            return Redirect("/Admin/Thanhvien/IndexTinnhan");
        }
        [Area("Admin")]
        public IActionResult Chitietthanhvien(int MATV)
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.LaythanhvienMATV1 = context.LaythanhvienMATV(MATV);
            context.LaybaivietMATV1 = context.LaybaivietMATV(MATV);
            context.Layquantrivien();
            return View(context);
        }
    }
}
