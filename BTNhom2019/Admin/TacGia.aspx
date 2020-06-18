<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/AdminLayout.Master" CodeBehind="TacGia.aspx.cs" Inherits="BTNhom2019.Admin.TacGia" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Tác giả</title>
    <style>
        .box-tacgia {
            width: 500px;
        }
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="Content" runat="server">
        <h1 class="page-title">Quản lý Tác giả</h1>
        <div class="grid-view-container">
            <asp:GridView ID="grdTacGia" runat="server" CssClass="grid-view"
                OnSelectedIndexChanged="grdTacGia_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField InsertText="Chọn" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="edit-box box-tacgia">
            <h2>Thông tin Tác giả</h2>
            <div class="box-group">
                <label for="AuthorID">Mã Tác giả</label>
                <input id="inAuthorID" runat="server" name="AuthorID" type="text" disabled="disabled"/>
            </div>
            <div class="box-group">
                <label for="AuthorName">Tên Tác giả</label>
                <input id="inAuthorName" runat="server" name="AuthorName" type="text"/>
            </div>
            <div class="box-group">
                <label for="AuthorContact">Liên lạc</label>
                <input id="inAuthorContact" runat="server" name="AuthorID" type="text"/>
            </div>
            <div class="box-control">
                <asp:Button ID="btnAdd" runat="server" Text="Thêm" OnClick="btnAdd_Click" />
                <asp:Button ID="btnEdit" runat="server" Text="Sửa" OnClick="btnEdit_Click" />
                <asp:Button ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Huỷ" OnClick="btnCancel_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Xoá" OnClick="btnDelete_Click" />
            </div>
        </div>
    </div>
</asp:Content>