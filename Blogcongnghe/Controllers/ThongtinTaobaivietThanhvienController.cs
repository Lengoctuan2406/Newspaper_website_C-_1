using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogcongnghe.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Blogcongnghe.Controllers
{
    public class ThongtinTaobaivietThanhvienController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public ThongtinTaobaivietThanhvienController(IWebHostEnvironment hostEnvironment)
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
        public async Task<IActionResult> Taobaiviet(baiviet bv, IFormFile ANH1, IFormFile ANH2, IFormFile ANH3)
        {
            if (ANH1 != null && ANH2 == null && ANH3 == null)
            {
                string wwwrootpath = _hostEnvironment.WebRootPath;
                string filename1 = Path.GetFileNameWithoutExtension(ANH1.FileName);
                string extension1 = Path.GetExtension(ANH1.FileName);
                bv.ANH1 = filename1 = filename1 + DateTime.Now.ToString("yymmssfff") + extension1;
                string path1 = Path.Combine(wwwrootpath + "/img_post/", filename1);
                using (var fileStream = new FileStream(path1, FileMode.Create))
                {
                    await ANH1.CopyToAsync(fileStream);
                }
            }
            else if (ANH1 == null && ANH2 != null && ANH3 == null)
            {
                string wwwrootpath = _hostEnvironment.WebRootPath;
                string filename2 = Path.GetFileNameWithoutExtension(ANH2.FileName);
                string extension2 = Path.GetExtension(ANH2.FileName);
                bv.ANH2 = filename2 = filename2 + DateTime.Now.ToString("yymmssfff") + extension2;
                string path2 = Path.Combine(wwwrootpath + "/img_post/", filename2);
                using (var fileStream = new FileStream(path2, FileMode.Create))
                {
                    await ANH2.CopyToAsync(fileStream);
                }
            }
            else if (ANH1 == null && ANH2 == null && ANH3 != null)
            {
                string wwwrootpath = _hostEnvironment.WebRootPath;
                string filename3 = Path.GetFileNameWithoutExtension(ANH3.FileName);
                string extension3 = Path.GetExtension(ANH3.FileName);
                bv.ANH3 = filename3 = filename3 + DateTime.Now.ToString("yymmssfff") + extension3;
                string path3 = Path.Combine(wwwrootpath + "/img_post/", filename3);
                using (var fileStream = new FileStream(path3, FileMode.Create))
                {
                    await ANH3.CopyToAsync(fileStream);
                }
            }
            else if (ANH1 != null && ANH2 != null && ANH3 == null)
            {
                string wwwrootpath = _hostEnvironment.WebRootPath;
                string filename1 = Path.GetFileNameWithoutExtension(ANH1.FileName);
                string filename2 = Path.GetFileNameWithoutExtension(ANH2.FileName);
                string extension1 = Path.GetExtension(ANH1.FileName);
                string extension2 = Path.GetExtension(ANH2.FileName);
                bv.ANH1 = filename1 = filename1 + DateTime.Now.ToString("yymmssfff") + extension1;
                bv.ANH2 = filename2 = filename2 + DateTime.Now.ToString("yymmssfff") + extension2;
                string path1 = Path.Combine(wwwrootpath + "/img_post/", filename1);
                string path2 = Path.Combine(wwwrootpath + "/img_post/", filename2);
                using (var fileStream = new FileStream(path1, FileMode.Create))
                {
                    await ANH1.CopyToAsync(fileStream);
                }
                using (var fileStream = new FileStream(path2, FileMode.Create))
                {
                    await ANH2.CopyToAsync(fileStream);
                }
            }
            else if (ANH1 == null && ANH2 != null && ANH3 != null)
            {
                string wwwrootpath = _hostEnvironment.WebRootPath;
                string filename2 = Path.GetFileNameWithoutExtension(ANH2.FileName);
                string filename3 = Path.GetFileNameWithoutExtension(ANH3.FileName);
                string extension2 = Path.GetExtension(ANH2.FileName);
                string extension3 = Path.GetExtension(ANH3.FileName);
                bv.ANH2 = filename2 = filename2 + DateTime.Now.ToString("yymmssfff") + extension2;
                bv.ANH3 = filename3 = filename3 + DateTime.Now.ToString("yymmssfff") + extension3;
                string path2 = Path.Combine(wwwrootpath + "/img_post/", filename2);
                string path3 = Path.Combine(wwwrootpath + "/img_post/", filename3);
                using (var fileStream = new FileStream(path2, FileMode.Create))
                {
                    await ANH2.CopyToAsync(fileStream);
                }
                using (var fileStream = new FileStream(path3, FileMode.Create))
                {
                    await ANH3.CopyToAsync(fileStream);
                }
            }
            else if (ANH1 != null && ANH2 == null && ANH3 != null)
            {
                string wwwrootpath = _hostEnvironment.WebRootPath;
                string filename1 = Path.GetFileNameWithoutExtension(ANH1.FileName);
                string filename3 = Path.GetFileNameWithoutExtension(ANH3.FileName);
                string extension1 = Path.GetExtension(ANH1.FileName);
                string extension3 = Path.GetExtension(ANH3.FileName);
                bv.ANH1 = filename1 = filename1 + DateTime.Now.ToString("yymmssfff") + extension1;
                bv.ANH3 = filename3 = filename3 + DateTime.Now.ToString("yymmssfff") + extension3;
                string path1 = Path.Combine(wwwrootpath + "/img_post/", filename1);
                string path3 = Path.Combine(wwwrootpath + "/img_post/", filename3);
                using (var fileStream = new FileStream(path1, FileMode.Create))
                {
                    await ANH1.CopyToAsync(fileStream);
                }
                using (var fileStream = new FileStream(path3, FileMode.Create))
                {
                    await ANH3.CopyToAsync(fileStream);
                }
            }
            else if (ANH1 != null && ANH2 != null && ANH3 != null)
            {
                string wwwrootpath = _hostEnvironment.WebRootPath;
                string filename1 = Path.GetFileNameWithoutExtension(ANH1.FileName);
                string filename2 = Path.GetFileNameWithoutExtension(ANH2.FileName);
                string filename3 = Path.GetFileNameWithoutExtension(ANH3.FileName);
                string extension1 = Path.GetExtension(ANH1.FileName);
                string extension2 = Path.GetExtension(ANH2.FileName);
                string extension3 = Path.GetExtension(ANH3.FileName);
                bv.ANH1 = filename1 = filename1 + DateTime.Now.ToString("yymmssfff") + extension1;
                bv.ANH2 = filename2 = filename2 + DateTime.Now.ToString("yymmssfff") + extension2;
                bv.ANH3 = filename3 = filename3 + DateTime.Now.ToString("yymmssfff") + extension3;
                string path1 = Path.Combine(wwwrootpath + "/img_post/", filename1);
                string path2 = Path.Combine(wwwrootpath + "/img_post/", filename2);
                string path3 = Path.Combine(wwwrootpath + "/img_post/", filename3);
                using (var fileStream = new FileStream(path1, FileMode.Create))
                {
                    await ANH1.CopyToAsync(fileStream);
                }
                using (var fileStream = new FileStream(path2, FileMode.Create))
                {
                    await ANH2.CopyToAsync(fileStream);
                }
                using (var fileStream = new FileStream(path3, FileMode.Create))
                {
                    await ANH3.CopyToAsync(fileStream);
                }
            }
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Blogcongnghe.Models.StoreContext)) as StoreContext;
            context.TaoBaivietThanhvien(bv);
            return Redirect("/ThongtinBaivietThanhvien/Index");
        }
    }
}
