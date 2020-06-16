<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/AdminLayout.Master" CodeBehind="NhaXuatBan.aspx.cs" Inherits="BTNhom2019.Admin.NhaXuatBan" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Quản lý Nhà Xuất Bản</title>
    <style>
        .page-nxb {
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .grid-view {
            width: 100%;
            height: 250px;
            margin: 0 auto;
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
</asp:Content>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="page-nxb">
        <h1> Quản lý Nhà Xuất Bản</h1>
        <div style="width:80%; height:250px; overflow-y: scroll;">
            <asp:GridView ID="grdNhaXuatBan" runat="server" CssClass="grid-view"
                OnSelectedIndexChanged="grdNhaXuatBan_SelectedIndexChanged" CellPadding="5">
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
    </div>
</asp:Content>