using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scheduler.Controller;
using System.Threading;
namespace Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            var objCustomers = new Customers();
            var objArticles = new Articles();
            var objUnits = new Units();
            var objCustomerAddresses = new CustomersAddresses();
            var objArticleGroups = new ArticleGroups();
            var objArticleIntermediateGroups = new ArticleIntermediateGroups(); 
            var objArticleSubGroups = new ArticleSubGroups();
            var objArticlesUnitTypes = new ArticlesUnitTypes();
            var objSuppliers = new Suppliers();
            var objEmployees = new Employees();
            var objArticleCustomFields = new ArticleCustomFields();
            var objArticleStockInfoes = new ArticleStockInfoes();
            var objPO = new POs();
            var objSO = new SOs();
            //var t = Task.Run(() => objCustomers.GetCustomers());
            // t = Task.Run(() => objCustomerAddresses.GetCustomerAddressses());
            // t = Task.Run(() => objEmployees.GetEmployees());
            // t = Task.Run(() => objSuppliers.GetSuppliers());
            // t = Task.Run(() => objUnits.GetUnits());
            //var t = Task.Run(() => objArticleGroups.GetArticleGroups());
            // t = Task.Run(() => objArticleIntermediateGroups.GetArticleIntermediateGroups());
            //t = Task.Run(() => objArticleSubGroups.GetArticleSubGroups());
            //  t = Task.Run(() => objArticles.GetArticles());
            // var t = Task.Run(() => objArticleCustomFields.GetArticlesCustomFields());
            //t = Task.Run(() => objArticlesUnitTypes.GetArticlesUnitTypes());
            // var t = Task.Run(() => objArticleStockInfoes.GetArticlesStockInfo());

            // var t = Task.Run(() => objArticles.GetArticleFromFile()); 
            // var t = Task.Run(() => objPO.GetPOes());
            var t = Task.Run(() => objSO.GetSOes());
            t.Wait();

            //objCustomers.UpdateCustomer();
            //objCustomers.UpdateShippingAddress();
            //objEmployees.UpdateEmployee();
            //objSuppliers.UpdateSupplier();
            //objUnits.UpdateUnit();
            //objArticles.UpdateArticleMainGroup();
            //objArticles.UpdateArticleIntermediateGroup();
            //objArticles.UpdateArticleSubGroup();
            // objArticles.UpdateArticle();
            
        }
    }
}
