using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Classes
{
    class CustomerOrder
    {
        public string OrderNo { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string DelAddress { get; set; }
        public DateTime DelDate { get; set; }
        public double NetAmount { get; set; }
        public double DiscAmount { get; set; }
        public double InvoiceVal { get; set; }
        public string Status { get; set; }
        public string PaymentType { get; set; }
        public string ChequeNo { get; set; }

        public static string NextOrderNo
        {
            get
            {
                DBConnect dbConnect = new DBConnect();
                string nextOrderNo = dbConnect.GetNextOrderNo("order_no_sequence", false);
                return nextOrderNo;
            }
        }
    }
}
