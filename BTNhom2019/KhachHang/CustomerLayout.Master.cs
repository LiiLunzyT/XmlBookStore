using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTNhom2019.DAO;

namespace BTNhom2019.KhachHang
{
    public partial class CustomerLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getAccount();
            }
        }

        protected void getAccount()
        {
            CustomerDAO dao = new CustomerDAO();

            if (Session["Login"] != "Khách hàng")
            {
                welcome.InnerText = "Chào khách viễn lai, bạn chưa đăng nhập!";
                login.Visible = true;
                logout.Visible = false;
                cart.Visible = false;
            } else
            {
                String name = dao.getCustomerByUserID(Session["ID"].ToString()).CustomerName;
                welcome.InnerText = "Chào khách hàng " + name + "!";
                login.Visible = false;
                logout.Visible = true;
                cart.Visible = true;
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["Login"] = null;
            Session["ID"] = null;
            Response.Redirect(Request.RawUrl);
        }
    }
}