using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using shopapp.Models;
using System.Web.Mvc;
using System.Drawing;
using System.Data.SqlClient;

namespace shopapp.Controllers
{
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            HomePageViewModel p = new HomePageViewModel();
            using (Model1 db = new Model1())
            {
                var top = db.tblProducts.Include("tblFile").Select(x => new { x.ProductId, x.Name, x.ShortDescription, x.FileId, x.tblFile.FileName, x.tblFile.ContentData  }).Take(7).ToList();
                foreach(var l in top)
                {
                    p.TopProducts.Add(new ProductViewModel { Id = l.ProductId, Name = l.Name, Category = l.ShortDescription, TheImage = l.ContentData, ImgId = (Guid)l.FileId});                    
                }
             //   var featured = db.tblProducts.Select(x => new { x.ProductId, x.Name, x.Price, x.ShortDescription, x.ImgURL }).Where(l => l.Price > 0).Take(3).ToList();
               var featured =  db.tblProducts.Include("tblFile").Select(x => new { x.ProductId, x.Name, x.ShortDescription, x.FileId, x.tblFile.FileName, x.tblFile.ContentData, x.Price }).Where(l=>l.Price>0).Take(3).ToList();
                foreach (var l in featured)
                {
                    p.Featured.Add(new ProductViewModel { Id = l.ProductId, Name = l.Name, Category = l.ShortDescription, TheImage = l.ContentData, ImgId = (Guid)l.FileId });
                }
              //  var bestseller = db.tblProducts.Select(x => new { x.ProductId, x.Name, x.Price, x.ShortDescription, x.ImgURL }).Where(l => l.Price > 100).Take(3).ToList();
                var bestseller = db.tblProducts.Include("tblFile").Select(x => new { x.ProductId, x.Name, x.ShortDescription, x.FileId, x.tblFile.FileName, x.tblFile.ContentData, x.Price }).Where(l=>l.Price>100).Take(3).ToList();
                foreach (var l in bestseller)
                {
                    p.BestSeller.Add(new ProductViewModel { Id = l.ProductId, Name = l.Name, Category = l.ShortDescription, TheImage = l.ContentData, ImgId = (Guid)l.FileId });
                }
                //var trends = db.tblProducts.Select(x => new { x.ProductId, x.Name, x.Price, x.ShortDescription, x.ImgURL }).Where(l => l.Price > 50 && l.Price < 100).Take(3).ToList();
                var trends = db.tblProducts.Include("tblFile").Select(x => new { x.ProductId, x.Name, x.ShortDescription, x.FileId, x.tblFile.FileName, x.tblFile.ContentData, x.Price }).Where(l=>l.Price>50 && l.Price<100).Take(3).ToList();
                foreach (var l in trends)
                {
                   
                    p.Trends.Add(new ProductViewModel { Id = l.ProductId, Name = l.Name, Category = l.ShortDescription, TheImage = l.ContentData, ImgId = (Guid)l.FileId });
                }
            }
            return View(p);
        }
        public ActionResult RetriveImage(Guid id)
        {
            byte[] cover = GetImageFromDb(id);
            if(cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }
        public byte[] GetImageFromDb(Guid id)
        {
            using(Model1 db = new Model1())
            {
                var data = db.tblFiles.Find(id);
                byte[] Image = data.ContentData;
                return Image;
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            return View();
        }
    }
}