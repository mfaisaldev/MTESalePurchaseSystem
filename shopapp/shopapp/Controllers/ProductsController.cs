using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopapp.Models;
using System.Net;

namespace shopapp.Controllers
{
    public class ProductsController : Controller
    {

        private Model1 db = new Model1();
        // GET: Products
        public ActionResult Index()
        {
           
            var C = (from p in db.tblProducts
                     join f in db.tblFiles
                     on p.FileId equals f.FileId
                     where p.StatusId == new Guid("a0a990b4-6c4f-4463-a3af-ae2abf789bd6")
                     && p.ProductStock >0
                     select new { p.ProductId, p.Name, p.ShortDescription, p.FileId, f.FileName, f.ContentData, p.DisplayOrder}).OrderBy(x => x.DisplayOrder);

            List<ProductViewModel> product = new List<ProductViewModel>();
            foreach (var p in C)
            {
                product.Add(new ProductViewModel { Id = p.ProductId, Category = p.ShortDescription, Name = p.Name, ImgId = (Guid)p.FileId, TheImage = p.ContentData });
            }
            return View(product);
        }
        public JsonResult Index2()
        {
            
            var list = db.tblProducts.Select( i =>  new { i.ProductId, i.Name, i.Price });
            return Json(list, JsonRequestBehavior.AllowGet);                       
        }
        public JsonResult LatestProducts()
        {
            var list = db.tblProducts.Select(i => new {i.ProductId, i.Name, i.Price, i.ShortDescription,i.ImgURL, i.CreationDate }).OrderBy(l =>l.CreationDate).Where(l=>l.ImgURL != null).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.tblProducts.Where(p => p.ProductId == id).FirstOrDefault();
            if(product == null)
            {
                return HttpNotFound();
            }


            return View(product);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}