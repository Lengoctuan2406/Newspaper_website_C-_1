using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogcongnghe.Areas.Admin.Models;

namespace Blogcongnghe.Areas.Admin.Controllers
{
    public class BinhluanController : Controller
    {
        [Area("Admin")]
        public IActionResult IndexBinhluanDangduyet()
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.Laybinhluandangduyet();
            context.Layxulybinhluan();
            context.Layquantrivien();
            return View(context);
        }
        [Area("Admin")]
        public IActionResult IndexBinhluanChapnhan()
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.Laybinhluandaduyet();
            context.Layquantrivien();
            return View(context);
        }
        [Area("Admin")]
        public IActionResult XoaBinhluan(int MABL)
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.XoaBinhluanMABL(MABL);
            return Redirect("/Admin/Binhluan/IndexBinhluanDangduyet");
        }
        [Area("Admin")]
        public IActionResult ChapnhanBinhluan(int MABL)
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.ChapnhanBinhluanMABL(MABL);
            return Redirect("/Admin/Binhluan/IndexBinhluanDangduyet");
        }
        [Area("Admin")]
        public IActionResult DuyetBinhluan(duyet duyet)
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.Duyet(duyet);
            return Redirect("/Admin/Binhluan/IndexBinhluanDangduyet");
        }
    }
}
