using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;
using System.Collections.ObjectModel;

namespace Admin.Controllers
{
    public class ProductSearchsController : Controller
    {
        public ActionResult Index(ProductSearch m)
        {
            try
            {

                Collection<Product> myColl = new Collection<Product>();
                IEnumerable<Product> items = null;
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    ViewBag.Categories = DB.tblCategories.Where(x => x.StatusId != new Guid(Utilities.Status_Delete));

                    var C = (from g in DB.tblProducts
                             join status in DB.tblStatus
                             on g.StatusId equals status.StatusId
                             join pc in DB.tblProductCategories
                             on g.ProductId equals pc.ProductId
                             where g.StatusId != new Guid(Utilities.Status_Delete)
                            && (m.ProductName == null || g.Name.Contains(m.ProductName))
                            && ((m.Category == null || pc.CategoryId == m.Category))
                             let Status = status.Name
                             let StatusId = status.StatusId
                             select new { g.ProductId, g.Name,  Status, StatusId, }).OrderBy(x => x.Name);

                    foreach (var ele in C)
                    {
                        myColl.Add(new Product()
                        {
                            ProductId = ele.ProductId,
                            Name = ele.Name,
                            myStatus = ele.Status,
                            StatusId = ele.StatusId,
                        });
                    }
                    items = myColl as IEnumerable<Product>;
                    return View(items);
                }
            }
            catch
            {
                return View();
            }

        }
    }
}