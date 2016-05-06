using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Classes
{
    class OrderLine
    {
        public string OrderNo { get; set; }
        public int LineNo { get; set; }
        public string PartNo { get; set; }
        public string PartDescription { get; set; }
        public string partCategory { get; set; }
        public int Qty { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }
        public double DiscountedPrice { get; set; }
    }
}
