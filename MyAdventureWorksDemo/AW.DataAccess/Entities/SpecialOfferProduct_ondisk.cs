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
    
    public partial class SpecialOfferProduct_ondisk
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SpecialOfferProduct_ondisk()
        {
            this.SalesOrderDetail_ondisk = new HashSet<SalesOrderDetail_ondisk>();
        }
    
        public int SpecialOfferID { get; set; }
        public int ProductID { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual Product_ondisk Product_ondisk { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrderDetail_ondisk> SalesOrderDetail_ondisk { get; set; }
        public virtual SpecialOffer_ondisk SpecialOffer_ondisk { get; set; }
    }
}
