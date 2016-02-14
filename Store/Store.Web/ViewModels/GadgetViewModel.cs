using System;

namespace Store.Web.ViewModels
{
    public class GadgetViewModel
    {
        public int GadgetID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
        public String Image { get; set; }

        public int CategoryID { get; set; }
    }
}