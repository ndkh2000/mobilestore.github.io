using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestUngDung.Areas.KHANHHUNG.Models
{
    public class CategoryModel
    {
        [Required]
        public int id { get; set; }
        public string name { get; set; }
    }
}