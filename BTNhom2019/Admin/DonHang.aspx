<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="DonHang.aspx.cs" Inherits="BTNhom2019.Admin.DonHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Duyệt Đơn hàng</title>
    <style>
        .box-donhang {
            width: 800px;
        }
        label {
            width: 150px !important;
        }
        .box-control input {
            width: 150px !important;
        }
    </style>
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
            RowStyle-CssClass="grid-view-row" OnPageIndexChanging="grdDonHang_PageIndexChanging" OnSelectedIndexChanged="grdDonHang_SelectedIndexChanged">
            <Columns>
                <asp:CommandField SelectText="Xem chi tiết" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>

    <div class="edit-box box-donhang">
        <h2>Thông tin đơn hàng</h2>
        <div class="box">
            <div class="small-box small-box-1">
                <div class="box-group">
                    <label for="ProducerID">Mã Đơn hàng</label>
                    <input id="inOrderID" runat="server" name="inOrderID" type="text" disabled="disabled" />
                </div>
                <div class="box-group">
                    <label for="ProducerID">Ngày đặt hàng</label>
                    <input id="inDate" runat="server" name="inDate" type="text" disabled="disabled" />
                </div>
                <div class="box-group">
                    <label for="ProducerID">Tổng tiền</label>
                    <input id="inTotal" runat="server" name="inTotal" type="text" disabled="disabled" />
                </div>
            </div>
            <div class="small-box small-box-2">
                <div class="box-group">
                    <label for="ProducerID">Mã Khách hàng</label>
                    <input id="inCustomerID" runat="server" name="inCustomerID" type="text" disabled="disabled" />
                </div>
                <div class="box-group">
                    <label for="ProducerID">Tên Khách hàng</label>
                    <input id="inCustomerName" runat="server" name="inCustomerName" type="text" disabled="disabled" />
                </div>
                <div class="box-group">
                    <label for="ProducerID">Địa chỉ</label>
                    <input id="inAddress" runat="server" name="inAddress" type="text" disabled="disabled" />
                </div>
            </div>
        </div>
        <div class="box-control">
            <asp:Button ID="btnAccept" runat="server" Text="Duyệt Đơn hàng" OnClick="btnAccept_Click"/>
            <asp:Button ID="btnDelete" runat="server" Text="Xoá Đơn hàng" OnClick="btnDelete_Click"/>
            <asp:Button ID="btnCancel" runat="server" Text="Huỷ" OnClick="btnCancel_Click"/>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
