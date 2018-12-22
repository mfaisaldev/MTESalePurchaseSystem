//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Scheduler
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProductUnitType
    {
        public System.Guid ProductUnitTypeId { get; set; }
        public System.Guid ProductId { get; set; }
        public System.Guid UnitId { get; set; }
        public string Name { get; set; }
        public string UnitNamePurchase { get; set; }
        public Nullable<int> Factor { get; set; }
        public string ISOCode { get; set; }
        public Nullable<int> Height { get; set; }
        public Nullable<bool> VariableQty { get; set; }
        public Nullable<int> Width { get; set; }
        public Nullable<int> Length { get; set; }
        public Nullable<int> Volume { get; set; }
        public Nullable<int> Rounding { get; set; }
        public string Comment { get; set; }
        public Nullable<int> UnitInPurchase { get; set; }
        public Nullable<int> SplitPurchase { get; set; }
        public Nullable<int> UnitInSales { get; set; }
        public Nullable<bool> SplitSales { get; set; }
        public Nullable<int> Weight { get; set; }
        public string PackingType { get; set; }
        public Nullable<bool> ComparableUnit { get; set; }
        public string Location { get; set; }
        public Nullable<int> UnitInStockControl { get; set; }
        public Nullable<int> UnitTypeNo { get; set; }
        public System.Guid StatusId { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public bool IsVISMA { get; set; }
        public string CreateBy { get; set; }
    
        public virtual tblProduct tblProduct { get; set; }
        public virtual tblStatu tblStatu { get; set; }
        public virtual tblUnit tblUnit { get; set; }
    }
}