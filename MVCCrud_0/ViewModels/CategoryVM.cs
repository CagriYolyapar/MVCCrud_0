using MVCCrud_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCrud_0.ViewModels
{
    public class CategoryVM
    {
        public List<Category> Categories { get; set; }
        public Category Category { get; set; }


    }
}