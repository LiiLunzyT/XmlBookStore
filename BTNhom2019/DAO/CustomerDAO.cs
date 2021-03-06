﻿using BTNhom2019.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace BTNhom2019.DAO
{
    public class CustomerDAO
    {
        public XmlDocument doc;
        public XmlNode root;
        String connectString = "~/App_Data/BookStore.xml";
        public CustomerDAO()
        {
            doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(connectString));
            root = doc.SelectSingleNode("//Customers");
        }

        public Customer GetCustomerByUserID(String UserID)
        {
            Customer customer = new Customer();

            foreach (XmlNode nCustomer in root.ChildNodes)
            {
                if (nCustomer["UserID"].InnerText == UserID)
                {
                    customer.CustomerID = nCustomer["CustomerID"].InnerText;
                    customer.CustomerName = nCustomer["CustomerName"].InnerText;
                    customer.CustomerAddress = nCustomer["CustomerAddress"].InnerText;
                    customer.CustomerContact = nCustomer["CustomerContact"].InnerText;
                    List<Item> cart = new List<Item>();
                    foreach(XmlNode nItem in nCustomer["Cart"].ChildNodes)
                    {
                        Item item = new Item();
                        item.BookID = nItem["BookID"].InnerText;
                        item.Quantity = int.Parse(nItem["Quantity"].InnerText);
                        cart.Add(item);
                    }
                    customer.Cart = cart;

                    return customer;
                }
            }

            return null;
        }

        public Customer GetCustomerByCustomerID(String CustomerID)
        {
            Customer customer = new Customer();
            XmlNode nCustomer = root.SelectSingleNode("Customer[CustomerID = '" + CustomerID + "']");

            customer.CustomerID = nCustomer["CustomerID"].InnerText;
            customer.CustomerName = nCustomer["CustomerName"].InnerText;
            customer.CustomerAddress = nCustomer["CustomerAddress"].InnerText;
            customer.CustomerContact = nCustomer["CustomerContact"].InnerText;
            List<Item> cart = new List<Item>();
            foreach (XmlNode nItem in nCustomer["Cart"].ChildNodes)
            {
                Item item = new Item();
                item.BookID = nItem["BookID"].InnerText;
                item.Quantity = int.Parse(nItem["Quantity"].InnerText);
                cart.Add(item);
            }
            customer.Cart = cart;

            return customer;
        }

        public Customer AddNewItemToCart(String CustomerID, String BookID)
        {
            XmlNode nCustomer = root.SelectSingleNode("Customer[CustomerID = '" + CustomerID + "']");
            XmlNode nCart = nCustomer["Cart"];
            Boolean isExist = false;
            foreach(XmlNode nItem in nCart.ChildNodes)
            {
                if(nItem["BookID"].InnerText == BookID)
                {
                    nItem["Quantity"].InnerText = (int.Parse(nItem["Quantity"].InnerText) + 1).ToString();
                    isExist = true;
                }
            }
            if(!isExist)
            {
                XmlNode nItem = doc.CreateElement("CartItem");

                XmlNode nBook = doc.CreateElement("BookID");
                nBook.InnerText = BookID;
                nItem.AppendChild(nBook);

                XmlNode nQuantity = doc.CreateElement("Quantity");
                nQuantity.InnerText = "1";
                nItem.AppendChild(nQuantity);

                nCart.AppendChild(nItem);
            }

            Save();
            return GetCustomerByCustomerID(CustomerID);
        }

        public Customer RemoveItemFromCart(String CustomerID, String BookID)
        {
            XmlNode nCustomer = root.SelectSingleNode("Customer[CustomerID = '" + CustomerID + "']");
            XmlNode nCart = nCustomer["Cart"];
            foreach (XmlNode nItem in nCart.ChildNodes)
            {
                if (nItem["BookID"].InnerText == BookID)
                {
                    if(nItem["Quantity"].InnerText == "1")
                    {

                    } else
                    {
                        nItem["Quantity"].InnerText = (int.Parse(nItem["Quantity"].InnerText) - 1).ToString();
                    }
                }
            }
            Save();
            return GetCustomerByCustomerID(CustomerID);
        }

        public void EmptyCart(String CustomerID)
        {
            XmlNode nCustomer = root.SelectSingleNode("Customer[CustomerID = '" + CustomerID + "']");
            nCustomer["Cart"].InnerXml = "";
        }
        public void EmptyCart(Customer customer)
        {
            String CustomerID = customer.CustomerID;
            XmlNode nCustomer = root.SelectSingleNode("Customer[CustomerID = '" + CustomerID + "']");
            nCustomer["Cart"].InnerXml = "";
            Save();
        }

        private void Save()
        {
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }
    }
}