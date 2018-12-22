using Admin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Admin.Helpers
{
    public static class HtmlHelpers
    {
        public static List<MenuItem> topMenuList= new List<MenuItem>();
        
        public static void topMenuListAdd(MenuItem mi)
        {
            if (topMenuList.Where(m => m.Name == mi.Name && m.UserIdentity == mi.UserIdentity).FirstOrDefault() == null)
                topMenuList.Add(mi);
        }
        public static void topMenuListClear(MenuItem mi)
        {
            if (topMenuList.Where(m => m.Name == mi.Name && m.UserIdentity == mi.UserIdentity).FirstOrDefault() == null)
                topMenuList.Clear();
        }


        public static string IsActive(string View, string value)
        {
            var returnActive = (View == value);

            return returnActive ? "active" : "";
        }
        public static string IsActive(string View, string value1, string value2)
        {
            var returnActive = (View == value1 || View == value2);

            return returnActive ? "active" : "";
        }
        public static string IsActive(string View, string value1, string value2, string value3)
        {
            var returnActive = (View == value1 || View == value2 || View == value3);

            return returnActive ? "active" : "";
        }
        public static string IsActive(string View, string value1, string value2, string value3, string value4)
        {
            var returnActive = (View == value1 || View == value2 || View == value3 || View == value4);

            return returnActive ? "active" : "";
        }
        public static string IsActive(string View, string value1, string value2, string value3, string value4, string value5)
        {
            var returnActive = (View == value1 || View == value2 || View == value3 || View == value4 || View == value5);

            return returnActive ? "active" : "";
        }
        public static string IsActive(string View, string value1, string value2, string value3, string value4, string value5, string value6)
        {
            var returnActive = (View == value1 || View == value2 || View == value3 || View == value4 || View == value5 || View == value6);

            return returnActive ? "active" : "";
        }

        public static string IsActive(string View, string value1, string value2, string value3, string value4, string value5, string value6, string value7)
        {
            var returnActive = (View == value1 || View == value2 || View == value3 || View == value4 || View == value5 || View == value6 || View == value7);

            return returnActive ? "active" : "";
        }
        public static string IsActive(string View, string value1, string value2, string value3, string value4, string value5, string value6, string value7, string value8)
        {
            var returnActive = (View == value1 || View == value2 || View == value3 || View == value4 || View == value5 || View == value6 || View == value7 || View == value8);

            return returnActive ? "active" : "";
        }
    }
    public class MenuItem
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public string UserIdentity { get; set; }
    }

    public class Account
    {
        public List<Menu> AccessMenu(string UserName)
        {
            List<Menu> mlist = new List<Menu>();
            using (DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2())
            {
                var C = (from m in DB.tblMenus
                         join rm in DB.tblRoleMenus on m.MenuId equals rm.MenuId
                         join ru in DB.tblRoleUsers on rm.RoleId equals ru.RoleId
                         where ru.UserName == UserName
                         select new { m.MenuId, m.Name, m.ParentMenuId, m.CSSClass, m.DisplayOrder, m.URL }).OrderBy(x => x.DisplayOrder);

                foreach (var ele in C)
                {
                    mlist.Add(new Menu()
                    {
                        MenuId = ele.MenuId,
                        Name = ele.Name,
                        DisplayOrder = ele.DisplayOrder,
                        ParentMenuId = ele.ParentMenuId,
                        CSSClass = ele.CSSClass,
                        URL = ele.URL
                    });
                }
            }
            return mlist;
        }

    }
}