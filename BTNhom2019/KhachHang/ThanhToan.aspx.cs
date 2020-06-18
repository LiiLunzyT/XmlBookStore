using BTNhom2019.DAO;
using BTNhom2019.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
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
                    bindData();
                }
            }
        }

        public void bindData()
        {
            CustomerDAO dao = new CustomerDAO();
            String CustomerID = dao.getCustomerByUserID(Session["ID"].ToString()).CustomerID;

            XmlCart.TransformSource = Server.MapPath("~/XSLT/ThanhToan.xslt");
            XmlCart.DocumentSource = Server.MapPath("~/App_Data/BookStore.xml");
            XsltArgumentList args = new XsltArgumentList();
            args.AddParam("CustomerID", "", CustomerID);

            XmlCart.TransformArgumentList = args;
        }
    }
}