using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using BTNhom2019.Model;

namespace BTNhom2019.DAO
{
    public class UserDAO
    {
        public XmlDocument doc;
        public XmlNode root;
        String connectString = "~/App_Data/BookStore.xml";

        public UserDAO()
        {
            doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(connectString));
            root = doc.SelectSingleNode("//Users");
        }

        public String AdminLogin(String username, String password)
        {
            foreach(XmlNode user in root.ChildNodes)
            {
                if(user["UserName"].InnerText == username && user["Password"].InnerText == password && user["UserRole"].InnerText == "Nhân viên")
                {
                    return user.Attributes["UserID"].Value;
                }
            }

            return "wrong";
        }
    }
}