//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Admin.DBLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class vArticleUnitType
    {
        public int UnitTypeNo { get; set; }
        public string ArticleNo { get; set; }
        public Nullable<int> WareHouseNo { get; set; }
        public string Name { get; set; }
        public string UnitNamePurchase { get; set; }
        public Nullable<int> Factor { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public Nullable<int> LastUpdatedBy { get; set; }
        public string ISOCode { get; set; }
        public Nullable<int> Height { get; set; }
        public Nullable<bool> VariableQtyYesNo { get; set; }
        public Nullable<int> Width { get; set; }
        public Nullable<int> Length { get; set; }
        public Nullable<int> Volume { get; set; }
        public Nullable<int> Rounding { get; set; }
        public Nullable<int> PriceListNo { get; set; }
        public string Comment { get; set; }
        public Nullable<int> UnitInPurchase { get; set; }
        public Nullable<int> SplitPurchaseYesNo { get; set; }
        public Nullable<int> UnitInSales { get; set; }
        public Nullable<bool> SplitSalesYesNo { get; set; }
        public Nullable<int> FactorCalcMethod { get; set; }
        public Nullable<int> Weight { get; set; }
        public Nullable<int> UnitNo { get; set; }
        public string PackingType { get; set; }
        public Nullable<bool> ComparableUnitYesNo { get; set; }
        public string Location { get; set; }
        public Nullable<int> UnitInStockControl { get; set; }
        public bool IsUpdated { get; set; }
    }
}
