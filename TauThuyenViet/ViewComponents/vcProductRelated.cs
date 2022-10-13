using Microsoft.AspNetCore.Mvc;
using TauThuyenViet.Models;

namespace TauThuyenViet.ViewComponents
{
    public class vcProductRelated : ViewComponent
    {
        public IViewComponentResult Invoke(int? catID)
        {
            DBContext db = new DBContext();
            var data = db.Products
                         .Where(x => x.Status == true)
                         .OrderByDescending(x => x.CreateTime)
                         .AsQueryable(); ///Câu truy vấn còn dang dở, có thể tiếp tục

            if(catID > 0)
            {
                data = data.Where(x => x.ProductCategoryID == catID);
            }

            return View(data.Take(6).ToList());
        }
    }
}
