using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogcongnghe.Models;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Blogcongnghe.Controllers
{
    public class ThongtinThanhvienController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public ThongtinThanhvienController(IWebHostEnvironment hostEnvironment)
        {
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Blogcongnghe.Models.StoreContext)) as StoreContext;
            context.Laythanhvien();
            context.Laytheloai();
            return View(context);
        }
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
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Blogcongnghe.Models.StoreContext)) as StoreContext;
            context.XulycapnhapThongtin(tv);
            return RedirectToAction("Index");
        }
        public IActionResult Xulythaydoimk(string mkcu, string mkmoi)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Blogcongnghe.Models.StoreContext)) as StoreContext;
            context.XulymkThongtin(mkcu, mkmoi);
            return RedirectToAction("Index");
        }
        public IActionResult Xulydoinen(string MAUNEN)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Blogcongnghe.Models.StoreContext)) as StoreContext;
            context.Doinen(MAUNEN);
            return RedirectToAction("Index");
        }
    }
}
