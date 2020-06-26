<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="DonHang.aspx.cs" Inherits="BTNhom2019.Admin.DonHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <h1 class="page-title">
        Danh sách Đơn hàng</h1>
    <div class="order-select">
        <label>Đơn hàng: </label>
        <asp:DropDownList ID="orderFilter" runat="server"
            OnSelectedIndexChanged="orderFilter_SelectedIndexChanged"
            AutoPostBack="true">
            <asp:ListItem Selected="True" Value="Tất cả">Tất cả</asp:ListItem>
            <asp:ListItem Value="Chờ duyệt">Chờ duyệt</asp:ListItem>
            <asp:ListItem Value="Đã duyệt">Đã duyệt</asp:ListItem>
        </asp:DropDownList>&nbsp;</div>
    <div class="grid-view-container">
        <asp:GridView ID="grdDonHang" runat="server"
            CssClass="grid-view"
            AllowPaging="true"
            PageSize="7"
            HeaderStyle-CssClass="grid-view-header"
            RowStyle-CssClass="grid-view-row" OnPageIndexChanging="grdDonHang_PageIndexChanging">
            <Columns>
                <asp:CommandField SelectText="Xem chi tiết" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
