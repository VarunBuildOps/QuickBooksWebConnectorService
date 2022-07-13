using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCWebService.Model
{
    public class Item
    {
        public string listId { get; set; }
        public string name { get; set; }
        public double qty { get; set; }
        public double rate { get; set; }
        public double amount { get; set; }
    }
}