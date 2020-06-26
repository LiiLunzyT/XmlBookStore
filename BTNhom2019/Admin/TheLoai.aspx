<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/AdminLayout.Master" CodeBehind="TheLoai.aspx.cs" Inherits="BTNhom2019.Admin.TheLoai" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Quản lý Thể loại</title>
    <style>
        .box-theloai {
            width: 500px;
        }
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <h1 class="page-title"> Quản lý Thể loại</h1>
        <div class="grid-view-container">
            <asp:GridView ID="grdTheLoai" runat="server" CssClass="grid-view"
                OnSelectedIndexChanged="grdTheLoai_SelectedIndexChanged"
                AllowPaging="True"
                PageSize="7"
                OnPageIndexChanging="grdTheLoai_PageIndexChanging"
                HeaderStyle-CssClass="grid-view-header"
                RowStyle-CssClass="grid-view-row"
                HorizontalAlign="Center">
                <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Xem chi tiết" />
                </Columns>

<HeaderStyle CssClass="grid-view-header"></HeaderStyle>

                <PagerSettings FirstPageText="Trang đầu" LastPageText="Trang cuối" Mode="NumericFirstLast" PageButtonCount="5" />

<RowStyle CssClass="grid-view-row"></RowStyle>
            </asp:GridView>
        </div>
        <div class="edit-box box-theloai">
            <h2>Thông tin Thể loại</h2>
            <div class="box-group">
                <label for="CategoryID">Mã Tác giả</label>
                <input id="inCategoryID" runat="server" name="CategoryID" type="text" disabled="disabled"/>
            </div>
            <div class="box-group">
                <label for="CategoryName">Tên Tác giả</label>
                <input id="inCategoryName" runat="server" name="CategoryName" type="text"/>
            </div>
            <div class="box-group">
                <label for="CategoryDesc">Liên lạc</label>
                <input id="inCategoryDesc" runat="server" name="CategoryDesc" type="text"/>
            </div>
            <div class="box-control">
                <asp:Button ID="btnAdd" runat="server" Text="Thêm" OnClick="btnAdd_Click" />
                <asp:Button ID="btnEdit" runat="server" Text="Sửa" OnClick="btnEdit_Click" />
                <asp:Button ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Huỷ" OnClick="btnCancel_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Xoá" OnClick="btnDelete_Click" />
            </div>
        </div>
</asp:Content>

