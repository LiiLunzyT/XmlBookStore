<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/AdminLayout.Master" CodeBehind="TacGia.aspx.cs" Inherits="BTNhom2019.Admin.TacGia" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Tác giả</title>
    <style>
        #form {
            display: flex;
            flex-direction: column;
            align-items: center;
        }
        .page-tg {
            display: flex;
            flex-direction: column;
            align-content: center;
        }
        .grid-view {
            width: 80%;
            font-size: 1.3rem;
            margin: 0 auto;
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
    <div class="page-tg" runat="server">
        <h1 style="text-align:center; margin: 20px 0">Quản lý Tác giả</h1>
        <div style="width: 100%; height:250px; overflow-y: scroll;">
            <asp:GridView ID="grdTacGia" runat="server" CssClass="grid-view"
                OnSelectedIndexChanged="grdTacGia_SelectedIndexChanged" HorizontalAlign="Center">
                <Columns>
                <asp:CommandField InsertText="Chọn" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="edit-box">
            <h2>Thông tin Tác giả</h2>
            <div class="edit-box__group">
                <label for="AuthorID">Mã Tác giả</label>
                <input id="inAuthorID" runat="server" name="AuthorID" type="text" disabled="disabled"/>
            </div>
            <div class="edit-box__group">
                <label for="AuthorName">Tên Tác giả</label>
                <input id="inAuthorName" runat="server" name="AuthorName" type="text"/>
            </div>
            <div class="edit-box__group">
                <label for="AuthorContact">Liên lạc</label>
                <input id="inAuthorContact" runat="server" name="AuthorID" type="text"/>
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