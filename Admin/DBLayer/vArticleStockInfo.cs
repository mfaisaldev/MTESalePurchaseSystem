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
    
    public partial class vArticleStockInfo
    {
        public Nullable<int> WareHouseNo { get; set; }
        public string ArticleNo { get; set; }
        public string Location { get; set; }
        public Nullable<int> CountedUnit { get; set; }
        public Nullable<int> LotNo { get; set; }
        public Nullable<int> UnitOnPurchase { get; set; }
        public Nullable<int> MaxStock { get; set; }
        public Nullable<int> MinStock { get; set; }
        public Nullable<int> UnitInStock { get; set; }
        public Nullable<int> UnitOnOrder { get; set; }
        public Nullable<int> UnitOnReminder { get; set; }
        public Nullable<System.DateTime> LastMovementDate { get; set; }
        public Nullable<int> UnitPacked { get; set; }
        public Nullable<int> CountedYesNo { get; set; }
        public Nullable<int> UnitOnLoan { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public Nullable<int> LastUpdatedBy { get; set; }
        public Nullable<int> QtyManualReserved { get; set; }
        public Nullable<int> QtyReserved { get; set; }
        public Nullable<System.DateTime> LastStockCountDate { get; set; }
        public Nullable<bool> IsUpdated { get; set; }
    }
}