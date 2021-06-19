using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestUngDung.Areas.KHANHHUNG.Models
{
    public class ProductModel
    {
        [Required]
        public int id { get; set; }
        public string name { get; set; }
        public decimal unitcost { get; set; }
        public int quantity { get; set; }
        public int type { get; set; }
    }
}