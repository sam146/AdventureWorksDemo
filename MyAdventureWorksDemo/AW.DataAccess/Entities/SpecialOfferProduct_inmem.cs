//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AW.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class SpecialOfferProduct_inmem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SpecialOfferProduct_inmem()
        {
            this.SalesOrderDetail_inmem = new HashSet<SalesOrderDetail_inmem>();
        }
    
        public int SpecialOfferID { get; set; }
        public int ProductID { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual Product_inmem Product_inmem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrderDetail_inmem> SalesOrderDetail_inmem { get; set; }
        public virtual SpecialOffer_inmem SpecialOffer_inmem { get; set; }
    }
}
