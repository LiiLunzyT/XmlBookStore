<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/KhachHang/CustomerLayout.Master" AutoEventWireup="true" CodeBehind="ThanhToan.aspx.cs" Inherits="BTNhom2019.KhachHang.ThanhToan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .cart-list {
            margin: 0 auto;
            display: flex;
            flex-direction: column;
            align-items: center;
            width: 800px;
        }
        h1 {
            margin: 20px;
        }
        table {
            width: 100%;
            background-color: white;
        }
        th {
            font-size: 20px;
        }
        th, td {
            padding: 5px;
        }
        .total {
            align-self: flex-end;
            font-weight: 600;
            margin: 10px 0;
            font-size: 20px;
        }
        .btn {
            padding: 2px;
            margin: 0 10px;
        }
        .cart-control {
            margin-top: 10px;
            align-self: flex-end;
        }
        .btn-control {
            padding: 10px;
            font-size: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="cart-list">
        <p class="title">GIỎ HÀNG CỦA BẠN</p>
        <asp:Xml ID="XmlCart" runat="server"></asp:Xml>
        <p class="total">Tổng cộng: <span id="Total" runat="server">0</span> VNĐ</p>
        <div class="cart-control">
            <asp:Button ID="btnRemoveCart" CssClass="btn-control" runat="server" Text="Xoá giỏ hàng" OnClick="btnRemoveCart_Click" />
            <asp:Button ID="btnSubmitCart" CssClass="btn-control" runat="server" Text="Đặt hàng" OnClick="btnSubmitCart_Click" />
        </div>
    </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
    <script type="text/javascript">
        function btnIncreaseOnClick(BookID) {
            PageMethods.set_path("ThanhToan.aspx")
            PageMethods.BtnIncreaseOnClick(BookID, function () {
            }, function (err) {
                console.log(err)
            })
        }
        function btnDecreaseOnClick(BookID) {
            PageMethods.set_path("ThanhToan.aspx")
            PageMethods.BtnDecreaseOnClick(BookID, function () {
            }, function (err) {
                console.log(err)
            })
        }
    </script>
</asp:Content>
