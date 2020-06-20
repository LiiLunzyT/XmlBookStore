using BTNhom2019.DAO;
using BTNhom2019.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Xsl;

namespace BTNhom2019.KhachHang
{
    public partial class ThanhToan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Login"] != "Khách hàng")
                {
                    Response.Redirect("DangNhap.aspx");
                }
                else
                {
                    
                }
            }
            bindData();
        }

        public void bindData()
        {
            CustomerDAO dao = new CustomerDAO();
            Customer customer = dao.GetCustomerByUserID(Session["ID"].ToString());
            OrderDAO orderDAO = new OrderDAO();
            String CustomerID = customer.CustomerID;

            XmlCart.TransformSource = Server.MapPath("~/XSLT/ThanhToan.xslt");
            XmlCart.DocumentSource = Server.MapPath("~/App_Data/BookStore.xml");
            XsltArgumentList args = new XsltArgumentList();
            args.AddParam("CustomerID", "", CustomerID);

            Total.InnerText = String.Format("{0:###,###,###}" ,orderDAO.CountTotal(customer.Cart));

            XmlCart.TransformArgumentList = args;
            XmlCart.DataBind();
        }

        [WebMethod]
        public static void BtnIncreaseOnClick(String BookID)
        {
            CustomerDAO dao = new CustomerDAO();

            String UserID = HttpContext.Current.Session["ID"].ToString();
            Customer customer = dao.GetCustomerByUserID(UserID);

            dao.AddNewItemToCart(customer.CustomerID, BookID);
        }

        protected void btnRemoveCart_Click(object sender, EventArgs e)
        {

        }

        protected async void btnSubmitCart_Click(object sender, EventArgs e)
        {
            CustomerDAO dao = new CustomerDAO();
            Customer customer = dao.GetCustomerByUserID(Session["ID"].ToString());
            OrderDAO orderDAO = new OrderDAO();
            String CustomerID = customer.CustomerID;
            orderDAO.NewOrderFromCustomer(customer);

            bindData();
        }
    }
}