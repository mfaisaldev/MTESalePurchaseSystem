using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;
namespace Admin.Controllers
{
    public class CountriesController : Controller
    {
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                Collection<Country> myColl = new Collection<Country>();
                IEnumerable<Country> items = null;
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var C = (from g in DB.tblCountries
                             join status in DB.tblStatus
                             on g.StatusId equals status.StatusId
                             where g.StatusId == new Guid(Utilities.Status_Active) 
                             select new { g.CountryId, g.Name, g.DisplayOrder }).OrderBy(x => x.DisplayOrder);

                    foreach (var ele in C)
                    {
                        myColl.Add(new Country()
                        {
                            CountryId = ele.CountryId,
                            Name = ele.Name,
                            DisplayOrder = ele.DisplayOrder
                        });
                    }
                    items = myColl as IEnumerable<Country>;
                    return View(items);
                }
            }
            catch
            {
                return View();
            }
        }


        [Authorize]
        [HttpGet]
        public ActionResult Create(string Id)
        {
            try
            {
                if (Id != null)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        Guid CountryId = Guid.Parse(Id);
                        DBLayer.tblCountry tbl = (from g in DB.tblCountries
                                                  where g.CountryId == CountryId
                                                  select g).SingleOrDefault();
                        Country m = new Country();
                        m.CountryId = tbl.CountryId;
                        m.DisplayOrder = tbl.DisplayOrder;
                        m.Name = tbl.Name;
                        m.StatusId = tbl.StatusId;
                        return View(m);
                    }
                }
                else
                {
                    Country m = new Country();
                    return View(m);
                }
            }
            catch(Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Create Country")]
        public ActionResult Create(Country m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblCountry tbl= DB.tblCountries.Where(u => u.Name.ToLower() == m.Name.ToLower()&& u.StatusId !=new Guid(Utilities.Status_Delete)).FirstOrDefault();
                        if (tbl == null)
                        {
                            tbl = new DBLayer.tblCountry();
                            tbl.CountryId = Guid.NewGuid(); 
                            tbl.Name = m.Name;
                            tbl.DisplayOrder = m.DisplayOrder;
                            tbl.StatusId = new Guid(Utilities.Status_Active);
                            DB.tblCountries.Add(tbl);
                            DB.SaveChanges();
                            return RedirectToAction("Index", "Countries");
                        }
                        else
                        {
                            ViewBag.Error = "Country Name Already Exists";
                            return View(m);
                        }
                    }
                }
                else
                {
                    return View(m);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View();
            }
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Edit Country")]
        public ActionResult Edit(Country m)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblCountry tblcheck = DB.tblCountries.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete) && u.CountryId!= m.CountryId).FirstOrDefault();
                        if (tblcheck == null)
                        {
                            DBLayer.tblCountry tbl = (from g in DB.tblCountries
                                                      where g.CountryId == m.CountryId
                                                      select g).SingleOrDefault();
                            tbl.Name = m.Name;
                            tbl.DisplayOrder = m.DisplayOrder;
                            tbl.StatusId = new Guid(Utilities.Status_Active);
                            DB.SaveChanges();
                            return RedirectToAction("Index", "Countries");
                        }
                        else
                        {
                            ViewBag.Error = "Country Name Already Exists";
                            return View(m);
                        }
                    }
                }
                else
                {
                    return View(m);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View();
            }
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Delete Country")]
        public ActionResult Delete(Country m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblCountry tbl = (from g in DB.tblCountries
                                                  where g.CountryId == m.CountryId
                                                  select g).SingleOrDefault();
                        tbl.StatusId = new Guid(Utilities.Status_Delete);
                        DB.SaveChanges();
                        return RedirectToAction("Index", "Countries");
                    }
                }
                else
                {
                    return View(m);
                }
            }

            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View();
            }

        }
    }
}
