using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ENT_PagosTwocheckout
    {
        public int quantity { get; set; }
        public decimal amount { get; set; }
        public Int64 numberOrder { get; set; }
        public string packageCod { get; set; }
        public string description { get; set; }
        public string key { set; get; }
        public string country { set; get; }
        public string payMethod { set; get; }
        public string email { set; get; }
        public int licenceId { get; set; }
        public int invoiceId { get; set; }

    }
}