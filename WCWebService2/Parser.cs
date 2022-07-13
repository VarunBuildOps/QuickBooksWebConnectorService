using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml; //XML Parsing
using WCWebService.Model;
using System.Globalization;

namespace WCWebService
{
    public class Parser
    {
        public List<Customer> parseCustomers(string xmlCustomers)
        { 
            List<Customer> customersLst = new List<Customer>();
            XmlDocument xmlDoc = new XmlDocument(); // Create an XML document object
            xmlDoc.LoadXml(xmlCustomers);
            // Get elements
            XmlNodeList listIDnd = xmlDoc.GetElementsByTagName("CustomerRet");
            for (int i = 0; i < listIDnd.Count; i++)
            {
                string xml = listIDnd[i].InnerXml;
                XmlNodeList listCont = listIDnd[i].ChildNodes;
                Customer customer = new Customer();
                foreach (XmlNode node in listCont)
                {
                    switch (node.Name)
                    {
                        case "ListID":
                            customer.sClientCode = node.InnerText;
                            break;
                        case "Name":
                            customer.sClientName = node.InnerText;
                            break;
                        case "SalesRepRef":
                            XmlNodeList repNodes = node.ChildNodes;
                            foreach (XmlNode repNode in repNodes)
                            {
                                switch (repNode.Name)
                                {
                                    case "ListID":
                                        customer.sRepCode = repNode.InnerText;
                                        break;
                                }
                            }
                            break;
                        case "Email":
                            customer.sEmail = node.InnerText;
                            break;
                        case "BillAddress":
                            XmlNodeList billAddrNodes = node.ChildNodes;
                            foreach (XmlNode baNode in billAddrNodes)
                            {
                                switch (baNode.Name)
                                {
                                    case "Addr3":
                                        customer.sAddress = baNode.InnerText;
                                        break;
                                    case "PostalCode":
                                        customer.sPostCode = baNode.InnerText;
                                        break;
                                    case "City":
                                        customer.sCity = baNode.InnerText;
                                        break;
                                    case "Country":
                                        customer.sCountry = baNode.InnerText;
                                        break;
                                    case "State":
                                        customer.sProv = baNode.InnerText;
                                        break;
                                }
                            }
                            break;
                        case "DataExtRet":
                            string dataExtName = "";
                            string dataExtValue = "";
                            XmlNodeList dataExtNodes = node.ChildNodes;
                            foreach (XmlNode dataExtNode in dataExtNodes)
                            {
                                switch (dataExtNode.Name)
                                {
                                    case "DataExtName":
                                        dataExtName = dataExtNode.InnerText;
                                        break;
                                    case "DataExtValue":
                                        dataExtValue = dataExtNode.InnerText;
                                        break;
                                }
                            }

                            switch (dataExtName.ToLower())
                            {
                                case "birthday":
                                    customer.dDateOfBirth = DateTime.Parse(dataExtValue);
                                    break;
                            }
                            break;
                    }
                }

                customersLst.Add(customer);
            }

            return customersLst;
        }

        public List<Product> parseItems(string xmlItems, Product.ProductType type)
        {
            List<Product> itemLst = new List<Product>();
            XmlDocument xmlDoc = new XmlDocument(); // Create an XML document object
            xmlDoc.LoadXml(xmlItems);
            // Get elements
            string retTag = "";
            switch (type)
            {
                case Product.ProductType.Service:
                    retTag = "ItemServiceRet";
                    break;
                case Product.ProductType.Inventory:
                    retTag = "ItemInventoryRet";
                    break;
            }

            XmlNodeList listIDnd = xmlDoc.GetElementsByTagName(retTag);
            for (int i = 0; i < listIDnd.Count; i++)
            {
                string xml = listIDnd[i].InnerXml;
                XmlNodeList listCont = listIDnd[i].ChildNodes;
                Product item = new Product();
                foreach (XmlNode node in listCont)
                {
                    switch (node.Name)
                    {
                        case "ListID":
                            item.sSkuCode = node.InnerText;
                            break;
                        case "Name":
                            item.sSkuName = node.InnerText;
                            break;
                        case "TimeCreated":
                            item.dLaunch = DateTime.Parse(node.InnerText);
                            break;
                        case "SalesAndPurchase":
                        case "SalesOrPurchase":
                            XmlNodeList salesnPurchNodes = node.ChildNodes;
                            foreach (XmlNode salesnPurchNode in salesnPurchNodes)
                            {
                                switch (salesnPurchNode.Name)
                                {
                                    case "SalesPrice":
                                    case "Price":
                                        item.fPrice = Decimal.Parse(salesnPurchNode.InnerText);
                                        break;
                                    case "PurchaseCost":
                                        item.fCost = Decimal.Parse(salesnPurchNode.InnerText);
                                        break;
                                }
                            }
                            break;
                    }
                }

                itemLst.Add(item);
            }

            return itemLst;
        }

        public List<Invoice> parseInvoices(string xmlInvoices)
        {
            List<Invoice> invoicesLst = new List<Invoice>();
            XmlDocument xmlDoc = new XmlDocument(); // Create an XML document object
            xmlDoc.LoadXml(xmlInvoices);
            // Get elements
            XmlNodeList listIDnd = xmlDoc.GetElementsByTagName("InvoiceRet");
            for (int i = 0; i < listIDnd.Count; i++)
            {
                string xml = listIDnd[i].InnerXml;
                XmlNodeList listCont = listIDnd[i].ChildNodes;
                Invoice invoice = new Invoice();
                foreach (XmlNode node in listCont)
                {
                    switch (node.Name)
                    {
                        case "TxnID":
                            invoice.txnId = node.InnerText;
                            break;
                        case "ListID":
                            break;
                        case "CustomerRef":
                            XmlNodeList custNodes = node.ChildNodes;
                            foreach (XmlNode custNode in custNodes)
                            {
                                switch (custNode.Name)
                                {
                                    case "ListID":
                                        invoice.customerListId = custNode.InnerText;
                                        break;
                                    case "FullName":
                                        invoice.customerName = custNode.InnerText;
                                        break;
                                }
                            }
                            break;
                        case "InvoiceLineGroupRet":
                            XmlNodeList invLGNodes = node.ChildNodes;
                            foreach (XmlNode invNode in invLGNodes)
                                if (invNode.Name.Equals("InvoiceLineRet"))
                                    parseInvoiceLine(invNode, ref invoice);
                            break;
                        case "InvoiceLineRet":
                            parseInvoiceLine(node, ref invoice);
                            break;
                        case "TxnDate":
                            invoice.txnDate = node.InnerText;
                            break;
                        case "Subtotal":
                            invoice.netSales = node.InnerText;
                            break;
                        case "SalesRepRef":
                            XmlNodeList salesRepNodes = node.ChildNodes;
                            foreach (XmlNode repNode in salesRepNodes)
                                switch (repNode.Name)
                                {
                                    case "ListID":
                                        invoice.repCode = repNode.InnerText;
                                        break;
                                    case "FullName":
                                        invoice.repName = repNode.InnerText;
                                        break;
                                }
                            break;
                    }
                }

                invoicesLst.Add(invoice);
            }

            return invoicesLst;
        }

        void parseInvoiceLine(XmlNode node, ref Invoice invoice)
        {
            string listId = "";
            string name = "";
            double qty = 0.0;
            double rate = 0.0;
            double amount = 0.0;
            XmlNodeList invLineNodes = node.ChildNodes;
            foreach (XmlNode invNode in invLineNodes)
            {
                switch (invNode.Name)
                {
                    case "ItemRef":
                    case "ClassRef":
                        XmlNodeList itemNodes = invNode.ChildNodes;
                        foreach (XmlNode itemNode in itemNodes)
                        {
                            switch (itemNode.Name)
                            {
                                case "ListID":
                                    listId = itemNode.InnerText;
                                    break;
                                case "FullName":
                                    name = itemNode.InnerText;
                                    break;
                            }
                        }
                        break;
                    case "Quantity":
                        qty = Double.Parse(invNode.InnerText, CultureInfo.InvariantCulture);
                        break;
                    case "Rate":
                        rate = Double.Parse(invNode.InnerText, CultureInfo.InvariantCulture);
                        break;
                    case "Amount":
                        amount = Double.Parse(invNode.InnerText, CultureInfo.InvariantCulture);
                        break;
                }
            }
            Item item = new Item();
            item.listId = listId;
            item.name = name;
            item.qty = qty;
            item.rate = rate;
            item.amount = amount;
            invoice.items.Add(item);
        }
    }
}