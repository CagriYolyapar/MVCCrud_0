using MVCCrud_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCrud_0.ViewModels
{
    public class ProductVM
    {
        public List<Product> Products { get; set; }
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }

    }
}