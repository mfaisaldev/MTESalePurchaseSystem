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
    
    public partial class vArticleGroupMain
    {
        public int MainGroupNo { get; set; }
        public string Name { get; set; }
        public Nullable<int> StockControlYesNo { get; set; }
        public Nullable<int> RemainderOrderYesNo { get; set; }
        public Nullable<int> RemainderPurchasingYesNo { get; set; }
        public Nullable<int> AutoConsumptionYesNo { get; set; }
        public Nullable<int> AutoPriceVarianceYesNo { get; set; }
        public Nullable<int> ParentMainGroupNo { get; set; }
        public Nullable<int> FIFOYesNo { get; set; }
        public Nullable<int> InActiveYesNo { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public Nullable<int> LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ShowInShoppingCart { get; set; }
        public bool IsUpdated { get; set; }
    }
}
