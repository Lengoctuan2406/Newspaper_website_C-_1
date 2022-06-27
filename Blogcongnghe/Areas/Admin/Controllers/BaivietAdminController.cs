using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogcongnghe.Areas.Admin.Models;

namespace Blogcongnghe.Areas.Admin.Controllers
{
    public class BaivietAdminController : Controller
    {
        [Area("Admin")]
        public IActionResult IndexBaivietChapnhan()
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.Laybaivietdachapnhan();
            context.Layquantrivien();
            return View(context);
        }
        [Area("Admin")]
        public IActionResult IndexBaivietDangduyet()
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.Laybaivietdangduyet();
            context.Layquantrivien();
            return View(context);
        }
        [Area("Admin")]
        public IActionResult IndexBaivietTuchoi()
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.Laybaiviettuchoi();
            context.Layquantrivien();
            return View(context);
        }
        [Area("Admin")]
        public IActionResult Xembaiviet(int MABAIDANG)
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.Laybaiviet1 = context.Laybaiviet(MABAIDANG);
            context.Layquantrivien();
            return View(context);
        }
        [Area("Admin")]
        public IActionResult Xoabaiviet(int MABAIDANG)
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.XoabaivietMABAIDANG(MABAIDANG);
            return Redirect("/Admin/BaivietAdmin/IndexBaivietDangduyet");
        }
        [Area("Admin")]
        public IActionResult ChapnhanBaiviet(int MABAIDANG)
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.Chapnhan(MABAIDANG);
            return Redirect("/Admin/BaivietAdmin/IndexBaivietDangduyet");
        }
        [Area("Admin")]
        public IActionResult TuchoiBaiviet(int MABAIDANG)
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.Tuchoi(MABAIDANG);
            return Redirect("/Admin/BaivietAdmin/IndexBaivietDangduyet");
        }
    }
}
