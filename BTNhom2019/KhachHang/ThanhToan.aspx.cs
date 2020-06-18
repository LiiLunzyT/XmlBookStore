using BTNhom2019.DAO;
using BTNhom2019.Model;
using System;
using System.Collections.Generic;
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
            }
        }

        protected void Xml1_DataBinding(object sender, EventArgs e)
        {
            CustomerDAO dao = new CustomerDAO();
            String CustomerID = dao.getCustomerByUserID(Session["ID"].ToString()).CustomerID;

            XsltArgumentList xsltPara = new XsltArgumentList();
            xsltPara.AddParam("CustomerID", "", CustomerID);
        }
    }
}