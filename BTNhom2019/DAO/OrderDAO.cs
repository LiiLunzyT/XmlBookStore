using BTNhom2019.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using BTNhom2019.Model;
using System.Data;
using System.Threading.Tasks;

namespace BTNhom2019.DAO
{
    public class OrderDAO
    {
        readonly XmlDocument doc;
        readonly XmlNode root;
        readonly String connectString = "~/App_Data/BookStore.xml";

        public OrderDAO()
        {
            doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(connectString));
            root = doc.SelectSingleNode("//Orders");
        }

        public Order GetOrderByID(String OrderID)
        {
            XmlNode nOrder = root.SelectSingleNode("Order[OrderID = '" + OrderID + "']");
            Order order = new Order();
            List<Item> listItems = new List<Item>();

            order.OrderID = nOrder["OrderID"].InnerText.ToString();
            order.OrderDate = DateTime.Parse(nOrder["OrderDate"].InnerText);
            order.OrderStatus = nOrder["OrderStatus"].InnerText.ToString();
            order.CustomerID = nOrder["CustomerID"].InnerText;

            foreach(XmlNode nItem in nOrder["OrderDetail"].ChildNodes)
            {
                Item item = new Item();
                item.BookID = nItem["BookID"].InnerText;
                item.Quantity = int.Parse(nItem["Quantity"].InnerText);
                listItems.Add(item);
            }
            order.Details = listItems;

            return order;
        }
        public Order GetOrderByIndex(int index)
        {
            Order order = new Order();
            XmlNode nOrder = root.ChildNodes[index];
            List<Item> listItems = new List<Item>();

            order.OrderID = nOrder["OrderID"].InnerText.ToString();
            order.OrderDate = DateTime.Parse(nOrder["OrderDate"].InnerText);
            order.OrderStatus = nOrder["OrderStatus"].InnerText.ToString();
            order.CustomerID = nOrder["CustomerID"].InnerText;

            foreach (XmlNode nItem in nOrder["OrderDetail"].ChildNodes)
            {
                Item item = new Item();
                item.BookID = nItem["BookID"].InnerText;
                item.Quantity = int.Parse(nItem["Quantity"].InnerText);
                listItems.Add(item);
            }
            order.Details = listItems;

            return order;
        }

        public void NewOrderFromCustomer(Customer customer)
        {
            XmlNode nOrder = doc.CreateElement("Order");

            XmlNode nOrderID = doc.CreateElement("OrderID");
            nOrderID.InnerText = GenMaxID();
            nOrder.AppendChild(nOrderID);

            XmlNode nOrderDetail = doc.CreateElement("OrderDetail");
            foreach (Item item in customer.Cart)
            {
                XmlNode nDetail = doc.CreateElement("Detail");

                XmlNode nBookID = doc.CreateElement("BookID");
                nBookID.InnerText = item.BookID;
                nDetail.AppendChild(nBookID);

                XmlNode nQuantity = doc.CreateElement("Quantity");
                nQuantity.InnerText = item.Quantity.ToString();
                nDetail.AppendChild(nQuantity);

                nOrderDetail.AppendChild(nDetail);
            }
            nOrder.AppendChild(nOrderDetail);

            XmlNode nOrderDate = doc.CreateElement("OrderDate");
            nOrderDate.InnerText = DateTime.Now.ToString();
            nOrder.AppendChild(nOrderDate);

            XmlNode nOrderStatus = doc.CreateElement("OrderStatus");
            nOrderStatus.InnerText = "Chờ duyệt";
            nOrder.AppendChild(nOrderStatus);

            XmlNode nCustomerID = doc.CreateElement("CustomerID");
            nCustomerID.InnerText = customer.CustomerID;
            nOrder.AppendChild(nCustomerID);

            root.AppendChild(nOrder);
            doc.Save(HttpContext.Current.Server.MapPath(connectString));

            CustomerDAO dao = new CustomerDAO();
            dao.EmptyCart(customer);
        }

        public void DeleteOrder(String OrderID)
        {
            XmlNode nOrder = root.SelectSingleNode("Order[OrderID = '" + OrderID + "']");
            root.RemoveChild(nOrder);
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public void CheckOrder(String OrderID)
        {
            XmlNode nOrder = root.SelectSingleNode("Order[OrderID = '" + OrderID + "']");
            nOrder["OrderStatus"].InnerText = "Đã duyệt";
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public List<Order> GetListOrders(String OrderFilter = "Tất cả")
        {
            List<Order> listOrders = new List<Order>();

            foreach (XmlNode node in root.ChildNodes)
            {
                Order order = new Order();
                order.OrderID = node["OrderID"].InnerText.ToString();
                order.OrderDate = DateTime.Parse(node["OrderDate"].InnerText);
                order.OrderStatus = node["OrderStatus"].InnerText.ToString();
                List<Item> listItems = new List<Item>();
                foreach(XmlNode nItem in node["OrderDetail"].ChildNodes)
                { 
                    Item item = new Item();
                    item.BookID = nItem["BookID"].InnerText;
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

        public DataTable ToDataTable(String OrderFilter = "Tất cả")
        {
            List<Order> listOrders = GetListOrders(OrderFilter);

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
                dr["Tổng tiền"] = CountTotal(order.Details).ToString();
                dr["Trạng thái"] = order.OrderStatus;
                dt.Rows.Add(dr);
            }

            return dt;
        }
        public String GenMaxID()
        {
            if (root.ChildNodes.Count == 0) return "OD-001";

            String lastID = root.LastChild["OrderID"].InnerText.ToString();
            int num = int.Parse(lastID.Split('-')[1]);
            String str = "" + (num + 1);
            return "OD-" + str.PadLeft(3, '0');
        }

        public int CountTotal(List<Item> list)
        {
            int sum = 0;
            foreach(Item item in list)
            {
                Book book = new BookDAO().GetBookByID(item.BookID);
                sum += book.BookPrice * item.Quantity;
            }
            return sum;
        }
    }
}