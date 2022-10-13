using Microsoft.AspNetCore.Mvc;
using TauThuyenViet.Models;

namespace TauThuyenViet.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        [Route("/lien-he", Name = "Contact")]
        [Route("/contact")]
        public IActionResult Index()
        {
            ViewBag.Title = "Liên Hệ";
            ViewBag.MassageType = "alert alert-info";
            ViewBag.MassageText = "Mời nhập thông tin";
            return View();
        }

        [HttpPost]
        [Route("/lien-he", Name = "Contact")]
        [Route("/contact")]
        public IActionResult Index(Contact item)
        {
            //Kiểm tra lỗi
            if(item == null)
            {
                ViewBag.MassageType = "alert alert-danger";
                ViewBag.MassageText = "Mời nhập thông tin";
                ViewBag.Title = "Liên Hệ";
                return View();
            }

            if (string.IsNullOrEmpty(item.FullName))
            {
                ViewBag.MassageType = "alert alert-danger";
                ViewBag.MassageText = "Mời nhập họ tên";
                ViewBag.Title = "Liên Hệ";
                return View();
            }

            if (string.IsNullOrEmpty(item.Mobi))
            {
                ViewBag.MassageType = "alert alert-danger";
                ViewBag.MassageText = "Mời nhập số điện thoại";
                ViewBag.Title = "Liên Hệ";
                return View();
            }
            
            if (string.IsNullOrEmpty(item.Content))
            {
                ViewBag.MassageType = "alert alert-danger";
                ViewBag.MassageText = "Mời nhập nội dung";
                ViewBag.Title = "Liên Hệ";
                return View();
            }

            item.CreateTime = DateTime.Now;
            item.Status = false;

            DBContext db = new DBContext();
            db.Contacts.Add(item);
            db.SaveChanges();

            ViewBag.MassageType = "alert alert-success";
            ViewBag.MassageText = "Cảm ơn đã liên hệ, chúng tôi sẽ liên hệ sớm";
            ViewBag.Title = "Liên Hệ";

            //Xóa trắng form đã nhập
            ModelState.Clear();

            return View();
        }
    }
}
