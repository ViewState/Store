using System;

namespace Store.Model
{
    public class Gadget
    {
        public int GadgetID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
        public String Image { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}