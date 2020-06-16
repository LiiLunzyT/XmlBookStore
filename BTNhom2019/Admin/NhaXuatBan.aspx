<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NhaXuatBan.aspx.cs" Inherits="BTNhom2019.Admin.NhaXuatBan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý Nhà Xuất Bản</title>
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
            width: 130px;
        }
        .edit-box__group input, .edit-box__control input {
            margin-top: 10px;
            flex: 1;
            padding: 5px;
        }
    </style>
</head>
<body>
    <h1> Quản lý Nhà Xuất Bản</h1>
    <form id="form" runat="server">
        <div style="width: 100%">
            <asp:GridView ID="grdNhaXuatBan" runat="server" CssClass="grid-view"
                OnSelectedIndexChanged="grdNhaXuatBan_SelectedIndexChanged" HorizontalAlign="Center">
                <Columns>
                <asp:CommandField InsertText="Chọn" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="edit-box">
            <h2>Thông tin Nhà Xuất Bản</h2>
            <div class="edit-box__group">
                <lable for="ProducerID">Mã Nhà Xuất Bản</lable>
                <input id="inProducerID" runat="server" name="ProducerID" type="text" disabled="disabled"/>
            </div>
            <div class="edit-box__group">
                <lable for="ProducerName">Tên Nhà Xuất Bản</lable>
                <input id="inProducerName" runat="server" name="ProducerName" type="text"/>
            </div>
            <div class="edit-box__group">
                <lable for="ProducerContact">Liên lạc</lable>
                <input id="inProducerContact" runat="server" name="ProducerContact" type="text"/>
            </div>
             <div class="edit-box__group">
                <lable for="ProducerAddress">Địa Chỉ</lable>
                <input id="inProducerAddress" runat="server" name="ProducerAddress" type="text"/>
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