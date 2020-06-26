using BTNhom2019.DAO;
using BTNhom2019.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BTNhom2019.Admin
{
    public partial class Sach : System.Web.UI.Page
    {
        static String mode = "view";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getCombobox();
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

        public void init()
        {
            emptyForm();
            disableForm();
            bindData();
            setButtonEnable(true, false, false, false, false);
        }

        private void bindData()
        {
            BookDAO dao = new BookDAO();
            DataTable dt = dao.ToDataTable();

            grdSach.DataSource = dt;
            grdSach.DataBind();
        }

        private void disableForm()
        {
            inBookName.Disabled = true;
            inBookPrice.Disabled = true;
            inBookQuantity.Disabled = true;
            inBookDiscount.Disabled = true;
            inAuthor.Enabled = false;
            inCategory.Enabled = false;
            inProducer.Enabled = false;
            inYear.Disabled = true;
            inPages.Disabled = true;
            inSize.Disabled = true;
            inDescription.Disabled = true;
        }
        
        private void enableForm()
        {
            inBookName.Disabled = false;
            inBookPrice.Disabled = false;
            inBookQuantity.Disabled = false;
            inBookDiscount.Disabled = false;
            inAuthor.Enabled = true;
            inCategory.Enabled = true;
            inProducer.Enabled = true;
            inYear.Disabled = false;
            inPages.Disabled = false;
            inSize.Disabled = false;
            inDescription.Disabled = false;
        }

        private Boolean isFormValid()
        {
            int errors = 0;
            if(inBookName.Value.Trim() == "")
            {
                inBookName.Style["border-color"] = "pink";
                errors++;
            }
            if (inBookPrice.Value.Trim() == "")
            {
                inBookPrice.Style["border-color"] = "pink";
                errors++;
            }
            if (inBookQuantity.Value.Trim() == "")
            {
                inBookQuantity.Style["border-color"] = "pink";
                errors++;
            }

            if (inBookDiscount.Value.Trim() == "")
            {
                inBookDiscount.Style["border-color"] = "pink";
                errors++;
            }

            if (inAuthor.SelectedValue.Trim() == "empty")
            {
                inAuthor.Style["border-color"] = "pink";
                errors++;
            }

            if (inCategory.SelectedValue.Trim() == "empty")
            {
                inCategory.Style["border-color"] = "pink";
                errors++;
            }

            if (inProducer.SelectedValue.Trim() == "empty")
            {
                inProducer.Style["border-color"] = "pink";
                errors++;
            }

            if (inYear.Value.Trim() == "")
            {
                inYear.Style["border-color"] = "pink";
                errors++;
            }

            if (inPages.Value.Trim() == "")
            {
                inPages.Style["border-color"] = "pink";
                errors++;
            }

            if (inSize.Value.Trim() == "")
            {
                inSize.Style["border-color"] = "pink";
                errors++;
            }

            if (errors > 0)
            {
                return false;
            }
            return true;
        }

        private void getCombobox()
        {
            AuthorDAO aDAO = new AuthorDAO();
            DataTable dt1 = aDAO.ToDataTable();
            DataRow empty1 = dt1.NewRow();
            empty1["Mã Tác giả"] = "empty";
            empty1["Tên Tác giả"] = "--Chọn--";
            empty1["Liên lạc"] = "";
            dt1.Rows.InsertAt(empty1, 0);
            inAuthor.DataSource = dt1;
            inAuthor.DataTextField = "Tên Tác giả";
            inAuthor.DataValueField = "Mã Tác giả";
            inAuthor.DataBind();

            CategoryDAO cDAO = new CategoryDAO();
            DataTable dt2 = cDAO.ToDataTable();
            DataRow empty2 = dt2.NewRow();
            empty2["Mã Thể loại"] = "empty";
            empty2["Tên Thể loại"] = "--Chọn--";
            empty2["Mô tả"] = "";
            dt2.Rows.InsertAt(empty2, 0);
            inCategory.DataSource = dt2;
            inCategory.DataTextField = "Tên Thể loại";
            inCategory.DataValueField = "Mã Thể loại";
            inCategory.DataBind();

            ProducerDAO pDAO = new ProducerDAO();
            DataTable dt3 = pDAO.toDataTable();
            DataRow empty3 = dt3.NewRow();
            empty3["Mã Nhà xuất bản"] = "empty";
            empty3["Tên Nhà xuất bản"] = "--Chọn--";
            empty3["Liên Hệ"] = "";
            empty3["Địa Chỉ"] = "";
            dt3.Rows.InsertAt(empty3, 0);
            inProducer.DataSource = dt3;
            inProducer.DataTextField = "Tên Nhà xuất bản";
            inProducer.DataValueField = "Mã Nhà xuất bản";
            inProducer.DataBind();
        }

        protected void parseData()
        {
            BookDAO dao = new BookDAO();
            Book book = dao.GetBookByID(grdSach.SelectedRow.Cells[1].Text);

            inBookID.Value = book.BookID;
            inBookName.Value = book.BookName;
            inBookPrice.Value = book.BookPrice.ToString();
            inBookQuantity.Value = book.BookQuantity.ToString();
            inBookDiscount.Value = book.BookDiscount.ToString();
            inAuthor.SelectedValue = book.AuthorID;
            inCategory.SelectedValue = book.CategoryID;
            inProducer.SelectedValue = book.ProducerID;
            inPages.Value = book.Pages.ToString();
            inSize.Value = book.Size;
            inYear.Value = book.Year.ToString();
            inDescription.Value = book.Description;
        }

        private void emptyForm()
        {
            inBookID.Value = "";
            inBookName.Value = "";
            inBookPrice.Value = "";
            inBookQuantity.Value = "";
            inBookDiscount.Value = "";
            inPages.Value = "";
            inSize.Value = "";
            inYear.Value = "";
            inDescription.Value = "";
        }

        protected void grdSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            mode = "selected";
            setButtonEnable(false, true, false, true, true);

            parseData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BookDAO dao = new BookDAO();
            String newID = dao.GenMaxID();
            mode = "add";
            enableForm();
            inBookID.Value = newID;
            setButtonEnable(false, false, true, true, false);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            enableForm();
            setButtonEnable(false, false, true, true, false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BookDAO dao = new BookDAO();

            if (mode == "add")
            {
                if(isFormValid())
                {

                    Book book = new Book();
                    book.BookID = inBookID.Value;
                    book.BookName = inBookName.Value;
                    book.BookPrice = int.Parse(inBookPrice.Value);
                    book.BookQuantity = int.Parse(inBookQuantity.Value);
                    book.BookDiscount = int.Parse(inBookDiscount.Value);

                    book.AuthorID = inAuthor.SelectedValue;
                    book.CategoryID = inCategory.SelectedValue;
                    book.ProducerID = inProducer.SelectedValue;

                    book.Pages = int.Parse(inPages.Value);
                    book.Size = inSize.Value;
                    book.Year = int.Parse(inYear.Value);
                    book.Description = inDescription.Value;

                    dao.AddBook(book);
                    init();
                }
            }
            if (mode == "edit")
            {
                Book book = new Book();
                book.BookID = inBookID.Value;
                book.BookName = inBookName.Value;
                book.BookPrice = int.Parse(inBookPrice.Value);
                book.BookQuantity = int.Parse(inBookQuantity.Value);
                book.BookDiscount = int.Parse(inBookDiscount.Value);

                book.AuthorID = inAuthor.SelectedValue;
                book.CategoryID = inCategory.SelectedValue;
                book.ProducerID = inProducer.SelectedValue;

                book.Pages = int.Parse(inPages.Value);
                book.Size = inSize.Value;
                book.Year = int.Parse(inYear.Value);
                book.Description = inDescription.Value;

                dao.UpdateBook(book);
                init();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mode = "view";
            init();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BookDAO dao = new BookDAO();

            dao.DeleteBook(inBookID.Value);

            init();
        }

        protected void grdSach_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdSach.PageIndex = e.NewPageIndex;
            bindData();
        }
    }
}