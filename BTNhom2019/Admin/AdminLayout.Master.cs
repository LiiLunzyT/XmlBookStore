using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTNhom2019.DAO;

namespace BTNhom2019.Admin
{
    public partial class AdminLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"] == null)
                {
                    Response.Redirect(String.Format("{0}?ReturnUrl={1}", "DangNhap.aspx", Request.RawUrl));
                } else
                {
                    StaffDAO dao = new StaffDAO();
                    String name = dao.getStaffByUserID(Session["ID"].ToString()).StaffName;
                    welcome.InnerText = "Xin chào " + name + "!";
                }
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["Login"] = null;
            Response.Redirect("DangNhap.aspx");
        }
    }
}