namespace OnlineShopModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public long ID { get; set; }

        public long CustomerID { get; set; }

        [Required]
        [StringLength(500)]
        public string ConsigneeName { get; set; }

        [Required]
        [StringLength(500)]
        public string DiliveryAddress { get; set; }

        [Required]
        [StringLength(250)]
        public string ConsigneeEmail { get; set; }

        [Required]
        [StringLength(20)]
        public string ConsigneePhone { get; set; }

        [Required]
        [StringLength(250)]
        public string PaymentMethod { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(250)]
        public string ShippingMethod { get; set; }

        [Column(TypeName = "ntext")]
        public string OrderNote { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalAmount { get; set; }
    }
}
