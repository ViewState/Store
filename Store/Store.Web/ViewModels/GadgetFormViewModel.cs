using System;
using System.Web;

namespace Store.Web.ViewModels
{
    public class GadgetFormViewModel
    {
        public HttpPostedFileBase File { get; set; }
        public String GadgetTitle { get; set; }
        public String GadgetDescription { get; set; }
        public Decimal GadgetPrice { get; set; }
        public int GadgetCategory { get; set; }
    }
}