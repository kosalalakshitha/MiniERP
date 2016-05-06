using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Classes
{
    class Part
    {
        public string PartNo { get; set; }
        public string PartDescription { get; set; }
        public string Catagory { get; set; }
        public double Size { get; set; }
        public string UOM { get; set; }
        public int QtyInStock { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
    }
}
