using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Classes
{
    class PurchaseOrder
    {
        public string OrderNo { get; set; }
        public DateTime Date { get; set; }
        public double InvoiceVal { get; set; }
        public string Remarks { get; set; }

        public static string NextOrderNo
        {
            get
            {
                DBConnect dbConnect = new DBConnect();
                string nextOrderNo = dbConnect.GetNextOrderNo("purch_order_no_sequence", false);
                return nextOrderNo;
            }
        }
    }
}
