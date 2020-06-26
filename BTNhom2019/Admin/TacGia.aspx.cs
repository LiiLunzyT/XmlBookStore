using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTNhom2019.DAO;
using BTNhom2019.Model;

namespace BTNhom2019.Admin
{
    public partial class TacGia : System.Web.UI.Page
    {
        static String mode = "view";

        protected void Page_Load(object sender, EventArgs e)
        {
            bindData();
            init();
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
            AuthorDAO dao = new AuthorDAO();
            DataTable dt = dao.ToDataTable();

            grdTacGia.DataSource = dt;
            grdTacGia.DataBind();
        }

        protected void parseData()
        {
            AuthorDAO dao = new AuthorDAO();
            Author author = dao.GetAuthorByID(grdTacGia.SelectedRow.Cells[1].Text);

            inAuthorID.Value = author.AuthorID;
            inAuthorName.Value = author.AuthorName;
            inAuthorContact.Value = author.AuthorContact;
        }

        private void emptyForm()
        {
            inAuthorID.Value = "";
            inAuthorName.Value = "";
            inAuthorContact.Value = "";
        }

        protected void grdTacGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            mode = "selected";
            setButtonEnable(false, true, false, true, true);

            parseData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AuthorDAO dao = new AuthorDAO();
            String newID = dao.GenMaxID();
            mode = "add";
            inAuthorID.Value = newID;
            setButtonEnable(false, false, true, true, false);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            setButtonEnable(false, false, true, true, false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AuthorDAO dao = new AuthorDAO();

            if (mode == "add")
            {
                Author author = new Author();
                author.AuthorID = inAuthorID.Value;
                author.AuthorName = inAuthorName.Value;
                author.AuthorContact = inAuthorContact.Value;
                dao.AddAuthor(author);
            }
            if (mode == "edit")
            {
                Author author = new Author();
                author.AuthorID = inAuthorID.Value;
                author.AuthorName = inAuthorName.Value;
                author.AuthorContact = inAuthorContact.Value;
                dao.UpdateAuthor(author);
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
            AuthorDAO dao = new AuthorDAO();

            Author author = new Author();
            author.AuthorID = inAuthorID.Value;
            author.AuthorName = inAuthorName.Value;
            author.AuthorContact = inAuthorContact.Value;
            dao.DeleteAuthor(author);

            init();
            bindData();
        }

        protected void grdTacGia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTacGia.PageIndex = e.NewPageIndex;
            bindData();
        }
    }
}