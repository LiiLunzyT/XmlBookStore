using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTNhom2019.Model
{
    public class Author
    {
        public String AuthorID;
        public String AuthorName;
        public String AuthorContact;
    }

    public class Producer
    {
        public String ProducerID;
        public String ProducerName;
        public String ProducerAddress;
        public String ProducerContact;

    }

    public class Category
    {
        public String CategoryID;
        public String CategoryName;
        public String CategoryDesc;
    }

    public class Book
    {
        public String BookID;
        public String BookName;

        public int Pages;
        public int Year;
        public String Size;
        public String Description;

        public int BookPrice;
        public int BookQuantity;
        public int BookDiscount;
        public String AuthorID;
        public String CategoryID;
        public String ProducerID;
    }

    public class Item
    {
        public String BookID;
        public int Quantity;
    }

    public class Customer
    {
        public String CustomerID;
        public String CustomerName;
        public String CustomerAddress;
        public String CustomerContact;
        public List<Item> Cart;
        public String UserID;
    }

    public class Order
    {
        public String OrderID;
        public List<Item> Details;
        public DateTime OrderDate;
        public String OrderStatus;
        public String CustomerID;
    }

    public class Staff
    {
        public String StaffID;
        public String StaffName;
        public String StaffAddress;
        public String StaffContact;
        public String UserID;
    }

    public class User
    {
        public String UserID;
        public String UserName;
        public String Password;
        public String UserRole;
    }
}