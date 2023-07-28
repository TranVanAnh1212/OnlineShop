namespace OnlineShopModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contacts
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Content { get; set; }

        public bool Status { get; set; }
    }
}
