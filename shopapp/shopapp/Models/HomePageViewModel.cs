using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopapp.Models
{
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            TopProducts = new List<ProductViewModel>();
            Featured = new List<ProductViewModel>();
            BestSeller = new List<ProductViewModel>();
            Trends = new List<ProductViewModel>();
        }
        public List<ProductViewModel> TopProducts { get; set; }
        public List<ProductViewModel> Featured { get; set; }
        public List<ProductViewModel> BestSeller { get; set; }
        public List <ProductViewModel> Trends { get; set; }
    }
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }        
        public Guid ImgId { get; set; }
        public byte[] TheImage { get; set; }
    }
}