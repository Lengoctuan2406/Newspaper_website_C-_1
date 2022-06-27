using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogcongnghe.Models;
using System.Text.RegularExpressions;

namespace Blogcongnghe.Controllers
{
    public class DangnhapDangkiController : Controller
    {
        public IActionResult Index(string Thongbao="")
        {
            ViewBag.Thongbao = Thongbao;
            return View();
        }
        public IActionResult XulyDangnhap(string EMAIL, string MATKHAU)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            if (!regexItem.IsMatch(MATKHAU))
            {
                return RedirectToAction("Index", "DangnhapDangki", new { Thongbao = "Có kí tự đặt biệt, yêu cầu nhập lại" });
            }
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Blogcongnghe.Models.StoreContext)) as StoreContext;
            int count = context.XulyDangnhapTK(EMAIL, MATKHAU);
            if (count > 0)
            {
                return RedirectToAction("Index", "Index");
            }
            else
            {
                return RedirectToAction("Quentaikhoan", "DangnhapDangki", new { Email = EMAIL });
            }
        }
        public IActionResult Dangki()
        {
            return View();
        }
        public IActionResult XulyDangki(string TENTHANHVIEN, string EMAIL, string MATKHAU)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Blogcongnghe.Models.StoreContext)) as StoreContext;
            context.XulyDangkiTK(TENTHANHVIEN, EMAIL, MATKHAU);
            return RedirectToAction("Index", "Index");
        }
        public IActionResult Quentaikhoan(string Email="")
        {
            ViewBag.Email = Email;
            return View();
        }
        public IActionResult Xulyquentk(string EMAIL)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Blogcongnghe.Models.StoreContext)) as StoreContext;
            context.XulyQuentaikhoan(EMAIL);
            return RedirectToAction("Index", "Index");
        }
    }
}
