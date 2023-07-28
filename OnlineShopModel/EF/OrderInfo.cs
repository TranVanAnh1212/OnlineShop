namespace OnlineShopModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderInfo")]
    public partial class OrderInfo
    {
        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        public string ProductID { get; set; }

        [Required]
        [StringLength(250)]
        public string ProductCount { get; set; }

        public long OrderID { get; set; }
    }
}
