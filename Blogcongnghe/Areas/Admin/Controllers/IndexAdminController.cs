using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogcongnghe.Areas.Admin.Models;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Blogcongnghe.Areas.Admin.Controllers
{
    public class IndexAdminController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public IndexAdminController(IWebHostEnvironment hostEnvironment)
        {
            this._hostEnvironment = hostEnvironment;
        }
        [Area("Admin")]
        public IActionResult Index()
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.LaysoluongBaiviet();
            context.LaysoluongThanhvien();
            context.LaysoluongBinhluan();
            context.Lay5BaivietnhieuLuotthich();
            context.Lay5ThanhviennhieuBaiviet();
            context.Layquantrivien();
            return View(context);
        }
        [Area("Admin")]
        public IActionResult Thongtinquantrivien()
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.Layquantrivien();
            return View(context);
        }
        [Area("Admin")]
        public async Task<IActionResult> Xulythanhvien(thanhvien tv, IFormFile ANH)
        {
            if (ANH != null)
            {
                string wwwrootpath = _hostEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(ANH.FileName);
                string extension = Path.GetExtension(ANH.FileName);
                tv.ANHDD = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwrootpath + "/img_add/", filename);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await ANH.CopyToAsync(fileStream);
                }
            }
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.XulycapnhapThongtin(tv);
            return Redirect("/Admin/IndexAdmin/Thongtinquantrivien");
        }
        [Area("Admin")]
        public IActionResult Xulythaydoimk(string mkcu, string mkmoi)
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.XulymkThongtin(mkcu, mkmoi);
            return Redirect("/Admin/IndexAdmin/Thongtinquantrivien");
        }
        [Area("Admin")]
        public IActionResult Dangxuat()
        {
            StoreContext context = new StoreContext("server=localhost;user id=root;password=;port=3306;database=blogcongnghe;");
            context.Dangxuattaikhoan();
            return Redirect("/Index/Index");
        }
    }
}
