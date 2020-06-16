<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TacGia.aspx.cs" Inherits="BTNhom2019.Admin.TacGia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        * {
            box-sizing: border-box;
        }

        h1 {
            text-align: center;
        }

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
        .edit-box__group lable {
            width: 100px;
        }
        .edit-box__group input, .edit-box__control input {
            margin-top: 10px;
            flex: 1;
            padding: 5px;
        }
    </style>
</head>
<body>
    <form id="form" runat="server">
        <div style="width: 100%">
            <asp:GridView ID="grdTacGia" runat="server" CssClass="grid-view"
                OnSelectedIndexChanged="grdTacGia_SelectedIndexChanged" HorizontalAlign="Center">
                <Columns>
                <asp:CommandField InsertText="Chọn" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <div style="width: 100%">
            <asp:GridView ID="GridView1" runat="server" CssClass="grid-view"
                OnSelectedIndexChanged="grdTacGia_SelectedIndexChanged" HorizontalAlign="Center">
                <Columns>
                <asp:CommandField InsertText="Chọn" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="edit-box">
            <h2>Thông tin Tác giả</h2>
            <div class="edit-box__group">
                <lable for="AuthorID">Mã Tác giả</lable>
                <input id="inAuthorID" runat="server" name="AuthorID" type="text" disabled="disabled"/>
            </div>
            <div class="edit-box__group">
                <lable for="AuthorName">Tên Tác giả</lable>
                <input id="inAuthorName" runat="server" name="AuthorName" type="text"/>
            </div>
            <div class="edit-box__group">
                <lable for="AuthorContact">Liên lạc</lable>
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
    </form>
</body>
</html>
