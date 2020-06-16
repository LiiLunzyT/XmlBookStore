using BTNhom2019.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;

namespace BTNhom2019.DAO
{
    public class BookDAO
    {
        public XmlDocument doc;
        public XmlNode root;
        String connectString = "~/App_Data/BookStore.xml";

        public BookDAO()
        {
            doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(connectString));
            root = doc.SelectSingleNode("//Books");
        }

        public Book getBookByID(String BookID)
        {
            XmlNode nBook = root.SelectSingleNode("Book[@BookID = '" + BookID + "']");
            XmlNode nBookInfo = nBook["BookInfo"];
            Book book = new Book();
            book.BookID = nBook.Attributes["BookID"].Value.ToString();
            book.BookName = nBook["BookName"].InnerText.ToString();
            book.BookPrice = int.Parse(nBook["BookPrice"].InnerText.ToString());
            book.BookQuantity = int.Parse(nBook["BookQuantity"].InnerText.ToString());
            book.BookDiscount = int.Parse(nBook["BookDiscount"].InnerText.ToString());

            book.Pages = int.Parse(nBookInfo["Pages"].InnerText);
            book.Size = nBookInfo["Size"].InnerText;
            book.Year = int.Parse(nBookInfo["Year"].InnerText);
            book.Description = nBookInfo["Description"].InnerText;

            book.AuthorID = nBook["BookAuthor"].Attributes["AuthorID"].Value;
            book.CategoryID = nBook["BookCategory"].Attributes["CategoryID"].Value;
            book.ProducerID = nBook["BookProducer"].Attributes["ProducerID"].Value;

            return book;
        }

        public Book geBookByIndex(int index)
        {
            XmlNode nBook = root.ChildNodes[index];
            XmlNode nBookInfo = nBook["BookInfo"];
            Book book = new Book();
            book.BookID = nBook.Attributes["BookID"].Value.ToString();
            book.BookName = nBook["BookName"].InnerText.ToString();
            book.BookPrice = int.Parse(nBook["BookPrice"].InnerText.ToString());
            book.BookQuantity = int.Parse(nBook["BookQuantity"].InnerText.ToString());
            book.BookDiscount = int.Parse(nBook["BookDiscount"].InnerText.ToString());

            book.Pages = int.Parse(nBookInfo["Pages"].InnerText);
            book.Size = nBookInfo["Size"].InnerText;
            book.Year = int.Parse(nBookInfo["Year"].InnerText);
            book.Description = nBookInfo["Description"].InnerText;

            book.AuthorID = nBook["BookAuthor"].Attributes["AuthorID"].Value;
            book.CategoryID = nBook["BookCategory"].Attributes["CategoryID"].Value;
            book.ProducerID = nBook["BookProducer"].Attributes["ProducerID"].Value;

            return book;
        }

        public void addBook(Book book)
        {
            XmlNode nBook = root.ChildNodes[0];
            XmlNode newBook = nBook.CloneNode(true);
            XmlNode newBookInfo = newBook["BookInfo"];
            newBook.Attributes["BookID"].Value = book.BookID;
            newBook["BookName"].InnerText = book.BookName;
            newBook["BookPrice"].InnerText = book.BookPrice.ToString();
            newBook["BookQuantity"].InnerText = book.BookQuantity.ToString();
            newBook["BookDiscount"].InnerText = book.BookDiscount.ToString();

            newBook["BookCategory"].Attributes["CategoryID"].Value = book.CategoryID;
            newBook["BookAuthor"].Attributes["AuthorID"].Value = book.AuthorID;
            newBook["BookProducer"].Attributes["ProducerID"].Value = book.ProducerID;

            newBookInfo["Pages"].InnerText = book.Pages.ToString();
            newBookInfo["Size"].InnerText = book.Size;
            newBookInfo["Year"].InnerText = book.Year.ToString();
            newBookInfo["Description"].InnerText = book.Description;

            newBook["BookInfo"].InnerXml = newBookInfo.InnerXml;
            root.AppendChild(newBook);
            doc.Save(HttpContext.Current.Server.MapPath(connectString));

        }

        public void deleteBook(Book book)
        {
            String BookID = book.BookID;
            XmlNode nBook = root.SelectSingleNode("Book[@BookID = '" + BookID + "']");
            root.RemoveChild(nBook);
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public void updateBook(Book book)
        {
            String BookID = book.BookID;
            XmlNode nBook = root.SelectSingleNode("Book[@BookID = '" + BookID + "']");
            XmlNode nBookInfo = nBook["BookInfo"];
            nBook["BookName"].InnerText = book.BookName;
            nBook["BookPrice"].InnerText = book.BookPrice.ToString();
            nBook["BookQuantity"].InnerText = book.BookQuantity.ToString();
            nBook["BookDiscount"].InnerText = book.BookDiscount.ToString();

            nBook["BookCategory"].Attributes["CategoryID"].Value = book.CategoryID;
            nBook["BookAuthor"].Attributes["AuthorID"].Value = book.AuthorID;
            nBook["BookProducer"].Attributes["ProducerID"].Value = book.ProducerID;

            nBookInfo["Pages"].InnerText = book.Pages.ToString();
            nBookInfo["Size"].InnerText = book.Size.ToString();
            nBookInfo["Year"].InnerText = book.Year.ToString();
            nBookInfo["Description"].InnerText = book.Description.ToString();

            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public List<Book> getListBooks()
        {
            List<Book> listBooks = new List<Book>();

            foreach (XmlNode node in root.ChildNodes)
            {
                XmlNode nBookInfo = node["BookInfo"];
                Book book = new Book();
                book.BookID = node.Attributes["BookID"].Value.ToString();
                book.BookName = node["BookName"].InnerText.ToString();
                book.BookPrice = int.Parse(node["BookPrice"].InnerText.ToString());
                book.BookQuantity = int.Parse(node["BookQuantity"].InnerText.ToString());
                book.BookDiscount = int.Parse(node["BookDiscount"].InnerText.ToString());

                book.Pages = int.Parse(nBookInfo["Pages"].InnerText);
                book.Size = nBookInfo["Size"].InnerText;
                book.Year = int.Parse(nBookInfo["Year"].InnerText);
                book.Description = nBookInfo["Description"].InnerText;

                book.AuthorID = node["BookAuthor"].Attributes["AuthorID"].Value;
                book.CategoryID = node["BookCategory"].Attributes["CategoryID"].Value;
                book.ProducerID = node["BookProducer"].Attributes["ProducerID"].Value;

                listBooks.Add(book);
            }

            return listBooks;
        }

        public DataTable toDataTable()
        {
            List<Book> listBooks = getListBooks();

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Sách", typeof(String));
            dt.Columns.Add("Tên Sách", typeof(String));
            dt.Columns.Add("Gía tiền", typeof(int));
            dt.Columns.Add("Số lượng", typeof(int));
            dt.Columns.Add("Giảm giá", typeof(int));
            foreach (Book book in listBooks)
            {
                DataRow dr = dt.NewRow();
                dr["Mã Sách"] = book.BookID;
                dr["Tên Sách"] = book.BookName;
                dr["Gía tiền"] = book.BookPrice;
                dr["Số lượng"] = book.BookQuantity;
                dr["Giảm giá"] = book.BookDiscount;
                dt.Rows.Add(dr);
            }

            return dt;
        }

        public String genMaxID()
        {
            String rs = "";

            String lastID = root.LastChild.Attributes["BookID"].Value.ToString();
            int num = int.Parse(lastID.Split('-')[1]);
            String str = "" + (num + 1);
            rs = "BK-" + str.PadLeft(3, '0');

            return rs;
        }
    }
}