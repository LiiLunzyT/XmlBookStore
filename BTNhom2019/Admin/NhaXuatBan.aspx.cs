using BTNhom2019.DAO;
using BTNhom2019.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTNhom2019.Admin
{
    public partial class NhaXuatBan : System.Web.UI.Page
    {
        static int index = -1;
        static String mode = "view";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["login"] == null)
                {
                    Response.Redirect(String.Format("{0}?ReturnUrl={1}", "DangNhap.aspx", Request.RawUrl));
                }
                bindData();
                init();
            }
        }

        private void setButtonEnable(Boolean add, Boolean edit, Boolean save, Boolean cancel, Boolean delete)
        {
            btnAdd.Enabled = add;
            btnEdit.Enabled = edit;
            btnSave.Enabled = save;
            btnCancel.Enabled = cancel;
            btnDelete.Enabled = delete;
        }

        private void init()
        {
            setButtonEnable(true, false, false, false, false);
            bindData();
        }

        private void bindData()
        {
            ProducerDAO dao = new ProducerDAO();
            DataTable dt = dao.toDataTable();

            grdNhaXuatBan.DataSource = dt;
            grdNhaXuatBan.DataBind();
        }

        protected void parseData()
        {
            ProducerDAO dao = new ProducerDAO();
            Producer producer = dao.geProducerByIndex(index);

            inProducerID.Value = producer.ProducerID;
            inProducerName.Value = producer.ProducerName;
            inProducerContact.Value = producer.ProducerContact;
            inProducerAddress.Value = producer.ProducerAddress;
        }

        private void emptyForm()
        {
            inProducerID.Value = "";
            inProducerName.Value = "";
            inProducerContact.Value = "";
            inProducerAddress.Value = "";
        }

        protected void grdNhaXuatBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = grdNhaXuatBan.SelectedIndex;

            mode = "selected";
            setButtonEnable(false, true, false, true, true);

            parseData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ProducerDAO dao = new ProducerDAO();
            String newID = dao.genMaxID();
            mode = "add";
            inProducerID.Value = newID;
            setButtonEnable(false, false, true, true, false);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            setButtonEnable(false, false, true, true, false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ProducerDAO dao = new ProducerDAO();

            if (mode == "add")
            {
                Producer producer = new Producer();
                producer.ProducerID = inProducerID.Value;
                producer.ProducerName = inProducerName.Value;
                producer.ProducerContact = inProducerContact.Value;
                producer.ProducerAddress = inProducerAddress.Value;
                dao.addProducer(producer);
            }
            if (mode == "edit")
            {
                Producer producer = new Producer();
                producer.ProducerID = inProducerID.Value;
                producer.ProducerName = inProducerName.Value;
                producer.ProducerContact = inProducerContact.Value;
                producer.ProducerAddress = inProducerAddress.Value;
                dao.updateProducer(producer);
            }

            init();
            emptyForm();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mode = "view";
            emptyForm();
            init();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ProducerDAO dao = new ProducerDAO();

            Producer producer = new Producer();
            producer.ProducerID = inProducerID.Value;
            producer.ProducerName = inProducerName.Value;
            producer.ProducerContact = inProducerContact.Value;
            producer.ProducerAddress = inProducerAddress.Value;
            dao.deleteProducer(producer);

            init();
            bindData();
        }
    }
}