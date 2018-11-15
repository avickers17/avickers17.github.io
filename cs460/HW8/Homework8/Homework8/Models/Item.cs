namespace Homework8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            Bids = new HashSet<Bid>();
        }

        [Display(Name = "Item Number"), Required]
        public int ID { get; set; }

        [Display(Name = "Item Name:"), Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Description of the Item:"), Required]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string SellerFullName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bid> Bids { get; set; }

        public virtual Seller Seller { get; set; }
    }
}
