<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/KhachHang/CustomerLayout.Master" CodeBehind="Sach.aspx.cs" Inherits="BTNhom2019.KhachHang.Sach" %>

<asp:Content ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ContentPlaceHolderID="Content" runat="server">
        <asp:Xml ID="Xml1" runat="server"
            DocumentSource="~/App_Data/BookStore.xml"
            TransformSource="~/XSLT/Sach.xslt">
        </asp:Xml>
</asp:Content>

<asp:Content ContentPlaceHolderID="Script" runat="server">

    <script type="text/javascript">
        function addToCart(BookID) {
            const cartFloat = document.getElementById('cartFloat')

            PageMethods.set_path("Sach.aspx")
            PageMethods.AddBookToCart(BookID, function (data) {
                if (data == "Bạn chưa đăng nhập") {
                    alert(data)
                } else {
                    alert(`Bạn đã thêm Sách(Mã: ${BookID} vào giỏ hàng thành công!`)
                    cartFloat.innerText = JSON.parse(data).length
                }
                console.log(data)
            }, function (err) {
                console.log(err)
            })
        }
    </script>
</asp:Content>
