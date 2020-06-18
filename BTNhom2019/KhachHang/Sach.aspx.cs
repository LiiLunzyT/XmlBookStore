using BTNhom2019.DAO;
using BTNhom2019.Model;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.FriendlyUrls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace BTNhom2019.KhachHang
{
    public partial class Sach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static String Test(String BookID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("~/App_Data/Test.xml"));
            XmlNode root = doc.SelectSingleNode("Test");
            root.AppendChild(doc.CreateElement("Add"));
            doc.Save(HttpContext.Current.Server.MapPath("~/App_Data/Test.xml"));
            return "Hello " + BookID;
        }

        [System.Web.Services.WebMethod]
        public static String addBookToCart(String BookID)
        {
            CustomerDAO dao = new CustomerDAO();
            
            if(HttpContext.Current.Session["Login"] != "Khách hàng")
            {
                return "Bạn chưa đăng nhập";
            }

            String UserID = HttpContext.Current.Session["ID"].ToString();
            Customer customer = dao.getCustomerByUserID(UserID);

            dao.addNewItemToCart(customer.CustomerID, BookID);

            return JsonConvert.SerializeObject(dao.getCustomerByUserID(UserID).Cart);
        }
    }
}