<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/AdminLayout.Master" CodeBehind="TheLoai.aspx.cs" Inherits="BTNhom2019.Admin.TheLoai" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Quản lý Thể loại</title>
    <style>
        #form {
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .grid-view {
            width: 80%;
            font-size: 1.3rem;
        }

        .edit-box {
            margin-top: 30px;
            width: 500px;
            display: flex;
            flex-direction: column;
            align-items: center;
            border: 1px solid black;
            padding: 20px 50px;
        }
        .edit-box__group, .edit-box__control {
            width: 100%;
            display: flex;
            align-items: center;
        }
        .edit-box__group label {
            width: 100px;
        }
        .edit-box__group input, .edit-box__control input {
            margin-top: 10px;
            flex: 1;
            padding: 5px;
        }
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <h1 class="page-title"> Quản lý Thể loại</h1>
    <div id="form">
        <div style="width: 100%">
            <asp:GridView ID="grdTheLoai" runat="server" CssClass="grid-view"
                OnSelectedIndexChanged="grdTheLoai_SelectedIndexChanged" HorizontalAlign="Center">
                <Columns>
                <asp:CommandField InsertText="Chọn" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="edit-box">
            <h2>Thông tin Thể loại</h2>
            <div class="edit-box__group">
                <label for="CategoryID">Mã Tác giả</label>
                <input id="inCategoryID" runat="server" name="CategoryID" type="text" disabled="disabled"/>
            </div>
            <div class="edit-box__group">
                <label for="CategoryName">Tên Tác giả</label>
                <input id="inCategoryName" runat="server" name="CategoryName" type="text"/>
            </div>
            <div class="edit-box__group">
                <label for="CategoryDesc">Liên lạc</label>
                <input id="inCategoryDesc" runat="server" name="CategoryDesc" type="text"/>
            </div>
            <div class="edit-box__control">
                <asp:Button ID="btnAdd" runat="server" Text="Thêm" OnClick="btnAdd_Click" />
                <asp:Button ID="btnEdit" runat="server" Text="Sửa" OnClick="btnEdit_Click" />
                <asp:Button ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Huỷ" OnClick="btnCancel_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Xoá" OnClick="btnDelete_Click" />
            </div>
        </div>
    </div>
</asp:Content>

