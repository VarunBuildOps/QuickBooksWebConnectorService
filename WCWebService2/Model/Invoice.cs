using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCWebService.Model
{
    public class Invoice
    {
        public string txnId { get; set; }
        public string txnDate { get; set; }
        public string repCode { get; set; }
        public string repName { get; set; }
        public string customerListId { get; set; }
        public string customerName{ get; set; }
        public string netSales { get; set; }
        public List<Item> items { get; set; }

        public Invoice()
        {
            items = new List<Item>();
        }
    }
}