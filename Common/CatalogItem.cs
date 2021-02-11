using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ASPNETExample.Models
{
    public class CatalogItem
    {
        [DisplayName("Id")]
        public int CatalogItemId { get; set; }
        [DisplayName("Name")]
        public string CatalogItemName { get; set; }
        [DisplayName("Description")]
        public string CatalogItemDescription { get; set; }
        [DisplayName("Price")]
        public double CatalogItemPrice { get; set; }
    }
}