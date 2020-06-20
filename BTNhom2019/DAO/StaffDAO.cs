using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using BTNhom2019.Model;

namespace BTNhom2019.DAO
{
    public class StaffDAO
    {
        public XmlDocument doc;
        public XmlNode root;
        String connectString = "~/App_Data/BookStore.xml";
        public StaffDAO()
        {
            doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(connectString));
            root = doc.SelectSingleNode("//Staffs");
        }

        public Staff getStaffByUserID(String UserID)
        {
            Staff staff = new Staff();

            foreach(XmlNode nStaff in root.ChildNodes)
            {
                if(nStaff["UserID"].InnerText == UserID)
                {
                    staff.StaffID = nStaff["StaffID"].Value;
                    staff.StaffName = nStaff["StaffName"].InnerText;
                    staff.StaffAddress = nStaff["StaffAddress"].InnerText;
                    staff.StaffContact = nStaff["StaffContact"].InnerText;
                    return staff;
                }
            }

            return null;
        }
    }

}