using Admin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class CurrenciesController : Controller
    {
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                Collection<Currency> myColl = new Collection<Currency>();
                IEnumerable<Currency> items = null;
                using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                {
                    var C = (from g in DB.tblCurrencies
                             join status in DB.tblStatus
                             on g.StatusId equals status.StatusId
                             where g.StatusId == new Guid(Utilities.Status_Active)
                             select new { g.CurrencyId, g.Name, g.Symbol,  g.DisplayOrder }).OrderBy(x => x.DisplayOrder);

                    foreach (var ele in C)
                    {
                        myColl.Add(new Currency()
                        {
                            CurrencyId = ele.CurrencyId,
                            Name = ele.Name,
                            Symbol= ele.Symbol,
                            DisplayOrder = ele.DisplayOrder
                        });
                    }
                    items = myColl as IEnumerable<Currency>;
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
                        Guid CurrencyId = Guid.Parse(Id);
                        DBLayer.tblCurrency tbl = (from g in DB.tblCurrencies
                                                  where g.CurrencyId == CurrencyId
                                                  select g).SingleOrDefault();
                        Currency m = new Currency();
                        m.CurrencyId = tbl.CurrencyId;
                        m.DisplayOrder = tbl.DisplayOrder;
                        m.Name = tbl.Name;
                        m.Symbol = tbl.Symbol;
                        m.StatusId = tbl.StatusId;
                        return View(m);
                    }
                }
                else
                {
                    Currency m = new Currency();
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Create Currency")]
        public ActionResult Create(Currency m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblCurrency tbl = DB.tblCurrencies.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete)).FirstOrDefault();
                        if (tbl == null)
                        {
                            tbl = new DBLayer.tblCurrency();
                            tbl.CurrencyId = Guid.NewGuid();
                            tbl.Name = m.Name;
                            tbl.Symbol = m.Symbol;
                            tbl.DisplayOrder = m.DisplayOrder;
                            tbl.StatusId = new Guid(Utilities.Status_Active);
                            DB.tblCurrencies.Add(tbl);
                            DB.SaveChanges();
                            return RedirectToAction("Index", "Currencies");
                        }
                        else
                        {
                            ViewBag.Error = "Currency Name Already Exists";
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Edit Currency")]
        public ActionResult Edit(Currency m)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblCurrency tblcheck = DB.tblCurrencies.Where(u => u.Name.ToLower() == m.Name.ToLower() && u.StatusId != new Guid(Utilities.Status_Delete) && u.CurrencyId != m.CurrencyId).FirstOrDefault();
                        if (tblcheck == null)
                        {
                            DBLayer.tblCurrency tbl = (from g in DB.tblCurrencies
                                                      where g.CurrencyId == m.CurrencyId
                                                      select g).SingleOrDefault();
                            tbl.Name = m.Name;
                            tbl.Symbol = m.Symbol;
                            tbl.DisplayOrder = m.DisplayOrder;
                            tbl.StatusId = new Guid(Utilities.Status_Active);
                            DB.SaveChanges();
                            return RedirectToAction("Index", "Currencies");
                        }
                        else
                        {
                            ViewBag.Error = "Currency Name Already Exists";
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
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Delete Currency")]
        public ActionResult Delete(Currency m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
                    {
                        DBLayer.tblCurrency tbl = (from g in DB.tblCurrencies
                                                  where g.CurrencyId == m.CurrencyId
                                                  select g).SingleOrDefault();
                        tbl.StatusId = new Guid(Utilities.Status_Delete);
                        DB.SaveChanges();
                        return RedirectToAction("Index", "Currencies");
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