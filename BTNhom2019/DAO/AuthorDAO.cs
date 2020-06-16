using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;
using BTNhom2019.Model;

namespace BTNhom2019.DAO
{
    public class AuthorDAO
    {
        public XmlDocument doc;
        public XmlNode root;
        String connectString = "~/App_Data/BookStore.xml";

        public AuthorDAO()
        {
            doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(connectString));
            root = doc.SelectSingleNode("//Authors");
        }

        public Author getAuthorByID(String AuthorID)
        {
            XmlNode nAuthor = root.SelectSingleNode("Author[@AuthorID = '" + AuthorID + "']");
            Author author = new Author();
            author.AuthorID = nAuthor.Attributes["AuthorID"].Value.ToString();
            author.AuthorName = nAuthor["AuthorName"].InnerText.ToString();
            author.AuthorContact = nAuthor["AuthorContact"].InnerText.ToString();
            return author;
        }

        public Author getAuthorByIndex(int index)
        {
            Author author = new Author();
            XmlNode nAuthor = root.ChildNodes[index];
            author.AuthorID = nAuthor.Attributes["AuthorID"].Value.ToString();
            author.AuthorName = nAuthor["AuthorName"].InnerText.ToString();
            author.AuthorContact = nAuthor["AuthorContact"].InnerText.ToString();
            return author;
        }

        public void addAuthor(Author author)
        {
            XmlNode nAuthor = root.ChildNodes[0];
            XmlNode newAuthor = nAuthor.CloneNode(true);
            newAuthor.Attributes["AuthorID"].Value = author.AuthorID;
            newAuthor["AuthorName"].InnerText = author.AuthorName;
            newAuthor["AuthorContact"].InnerText = author.AuthorContact;
            root.AppendChild(newAuthor);
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public void deleteAuthor(Author author)
        {
            String AuthorID = author.AuthorID;
            XmlNode nAuthor = root.SelectSingleNode("Author[@AuthorID = '" + AuthorID + "']");
            root.RemoveChild(nAuthor);
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public void updateAuthor(Author author)
        {
            String AuthorID = author.AuthorID;
            XmlNode nAuthor = root.SelectSingleNode("Author[@AuthorID = '" + AuthorID + "']");
            nAuthor["AuthorName"].InnerText = author.AuthorName;
            nAuthor["AuthorContact"].InnerText = author.AuthorContact;
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public List<Author> getListAuthors()
        {
            List<Author> listAuthors = new List<Author>();

            foreach (XmlNode node in root.ChildNodes)
            {
                Author author = new Author();
                author.AuthorID = node.Attributes["AuthorID"].Value.ToString();
                author.AuthorName = node["AuthorName"].InnerText.ToString();
                author.AuthorContact = node["AuthorContact"].InnerText.ToString();

                listAuthors.Add(author);
            }

            return listAuthors;
        }

        public DataTable toDataTable()
        {
            List<Author> listAuthors = getListAuthors();

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Tác giả", typeof(String));
            dt.Columns.Add("Tên Tác giả", typeof(String));
            dt.Columns.Add("Liên lạc", typeof(String));
            foreach (Author author in listAuthors)
            {
                DataRow dr = dt.NewRow();
                dr["Mã Tác giả"] = author.AuthorID;
                dr["Tên Tác giả"] = author.AuthorName;
                dr["Liên lạc"] = author.AuthorContact;
                dt.Rows.Add(dr);
            }

            return dt;
        }

        public String genMaxID()
        {
            String rs = "";

            String lastID = root.LastChild.Attributes["AuthorID"].Value.ToString();
            int num = int.Parse(lastID.Split('-')[1]);
            String str = "" + (num + 1);
            rs = "AU-" + str.PadLeft(3, '0');

            return rs;
        }
    }
}