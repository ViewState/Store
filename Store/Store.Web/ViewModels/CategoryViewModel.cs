using System;
using System.Collections.Generic;

namespace Store.Web.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public String Name { get; set; }

        public List<GadgetViewModel> Gadgets { get; set; } 
    }
}