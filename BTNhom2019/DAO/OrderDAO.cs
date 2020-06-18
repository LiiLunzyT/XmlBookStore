using BTNhom2019.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using BTNhom2019.Model;
using System.Data;

namespace BTNhom2019.DAO
{
    public class OrderDAO
    {
        XmlDocument doc;
        XmlNode root;
        String connectString = "~/App_Data/BookStore.xml";

        public OrderDAO()
        {
            doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(connectString));
            root = doc.SelectSingleNode("//Orders");
        }

        public Order getOrderByID(String OrderID)
        {
            XmlNode nOrder = root.SelectSingleNode("Order[@OrderID = '" + OrderID + "']");
            Order order = new Order();
            List<Item> listItems = new List<Item>();

            order.OrderID = nOrder.Attributes["OrderID"].Value.ToString();
            order.OrderDate = DateTime.Parse(nOrder["OrderDate"].InnerText);
            order.OrderStatus = nOrder["OrderStatus"].InnerText.ToString();
            order.CustomerID = nOrder["Customer"].Attributes["CustomerID"].Value;

            foreach(XmlNode nItem in nOrder["OrderDetail"].ChildNodes)
            {
                Item item = new Item();
                item.BookID = nItem["Book"].Attributes["BookID"].Value;
                item.Quantity = int.Parse(nItem["Quantity"].InnerText);
                listItems.Add(item);
            }
            order.Details = listItems;

            return order;
        }
        public Order getOrderByIndex(int index)
        {
            Order order = new Order();
            XmlNode nOrder = root.ChildNodes[index];
            List<Item> listItems = new List<Item>();

            order.OrderID = nOrder.Attributes["OrderID"].Value.ToString();
            order.OrderDate = DateTime.Parse(nOrder["OrderDate"].InnerText);
            order.OrderStatus = nOrder["OrderStatus"].InnerText.ToString();
            order.CustomerID = nOrder["Customer"].Attributes["CustomerID"].Value;

            foreach (XmlNode nItem in nOrder["OrderDetail"].ChildNodes)
            {
                Item item = new Item();
                item.BookID = nItem["Book"].Attributes["BookID"].Value;
                item.Quantity = int.Parse(nItem["Quantity"].InnerText);
                listItems.Add(item);
            }
            order.Details = listItems;

            return order;
        }

        public void newOrderFromCustomer(Customer customer)
        {
            XmlNode nOrder = doc.CreateElement("Order");
            nOrder.Attributes["OrderID"].Value = genMaxID();

            XmlNode nDetails = doc.CreateElement("OrderDetail");
            foreach(Item item in customer.Cart)
            {
                XmlNode nItem = doc.CreateElement("Detail");

                XmlNode nBook = doc.CreateElement("Book");
                nBook["BookID"].Value = item.BookID;
                nItem.AppendChild(nBook);

                XmlNode nQuantity = doc.CreateElement("Quantity");
                nQuantity.InnerText = item.Quantity.ToString();
                nItem.AppendChild(nQuantity);
                nDetails.AppendChild(nItem);
            }
            nOrder.AppendChild(nDetails);

            XmlNode nOrderDate = doc.CreateElement("OrderDate");
            nOrderDate.InnerText = DateTime.Now.ToString();
            nOrder.AppendChild(nOrderDate);

            XmlNode nOrderStatus = doc.CreateElement("OrderStatus");
            nOrderStatus.InnerText = "Chờ duyệt";
            nOrder.AppendChild(nOrderStatus);

            XmlNode nCustomer = doc.CreateElement("Customer");
            nCustomer["CustomerID"].Value = customer.CustomerID;
            nOrder.AppendChild(nCustomer);

            root.AppendChild(nOrder);
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public void deleteOrder(String OrderID)
        {
            XmlNode nOrder = root.SelectSingleNode("Order[@OrderID = '" + OrderID + "']");
            root.RemoveChild(nOrder);
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public void checkOrder(String OrderID)
        {
            XmlNode nOrder = root.SelectSingleNode("Order[@OrderID = '" + OrderID + "']");
            nOrder["OrderStatus"].InnerText = "Đã duyệt";
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public List<Order> getListOrders(String OrderFilter = "Tất cả")
        {
            List<Order> listOrders = new List<Order>();

            foreach (XmlNode node in root.ChildNodes)
            {
                Order order = new Order();
                order.OrderID = node.Attributes["OrderID"].Value.ToString();
                order.OrderDate = DateTime.Parse(node["OrderDate"].InnerText);
                order.OrderStatus = node["OrderStatus"].InnerText.ToString();
                List<Item> listItems = new List<Item>();
                foreach(XmlNode nItem in node["OrderDetail"].ChildNodes)
                {
                    Item item = new Item();
                    item.BookID = nItem["Book"].Attributes["BookID"].Value;
                    item.Quantity = int.Parse(nItem["Quantity"].InnerText);
                    listItems.Add(item);
                }
                order.Details = listItems;

                if (order.OrderStatus == OrderFilter || OrderFilter == "Tất cả") {
                    listOrders.Add(order);
                }
            }

            return listOrders;
        }

        public DataTable toDataTable(String OrderFilter = "Tất cả")
        {
            List<Order> listOrders = getListOrders(OrderFilter);

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Đơn hàng", typeof(String));
            dt.Columns.Add("Ngày đặt hàng", typeof(String));
            dt.Columns.Add("Tổng tiền", typeof(String));
            dt.Columns.Add("Trạng thái", typeof(String));
            foreach (Order order in listOrders)
            {
                DataRow dr = dt.NewRow();
                dr["Mã Đơn hàng"] = order.OrderID;
                dr["Ngày đặt hàng"] = order.OrderDate;
                dr["Tổng tiền"] = countTotal(order).ToString();
                dr["Trạng thái"] = order.OrderStatus;
                dt.Rows.Add(dr);
            }

            return dt;
        }
        public String genMaxID()
        {
            String rs = "";

            String lastID = root.LastChild.Attributes["OrderID"].Value.ToString();
            int num = int.Parse(lastID.Split('-')[1]);
            String str = "" + (num + 1);
            rs = "OD-" + str.PadLeft(3, '0');

            return rs;
        }

        public int countTotal(Order order)
        {
            int sum = 0;
            foreach(Item item in order.Details)
            {
                Book book = new BookDAO().getBookByID(item.BookID);
                sum += book.BookPrice * item.Quantity;
            }
            return sum;
        }
    }
}