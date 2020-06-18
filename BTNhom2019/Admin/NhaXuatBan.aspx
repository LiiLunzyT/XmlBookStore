<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/AdminLayout.Master" CodeBehind="NhaXuatBan.aspx.cs" Inherits="BTNhom2019.Admin.NhaXuatBan" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Quản lý Nhà Xuất Bản</title>
    <style>
        .box-nhaxuatban {
            width: 500px;
        }
        label {
            width: 200px !important;
        }
        .box-control input {
            width: 150px !important;
        }
    </style>
</asp:Content>
<asp:Content ContentPlaceHolderID="Content" runat="server">
        <h1 class="page-title"> Quản lý Nhà Xuất Bản</h1>
        <div class="grid-view-container">
            <asp:GridView ID="grdNhaXuatBan" runat="server" CssClass="grid-view"
                OnSelectedIndexChanged="grdNhaXuatBan_SelectedIndexChanged" CellPadding="5">
                <Columns>
                    <asp:CommandField InsertText="Chọn" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        
        <div class="edit-box box-nhaxuatban">
            <h2>Thông tin Nhà Xuất Bản</h2>
            <div class="box-group">
                <label for="ProducerID">Mã Nhà Xuất Bản</label>
                <input id="inProducerID" runat="server" name="ProducerID" type="text" disabled="disabled" />
            </div>
            <div class="box-group">
                <label for="ProducerName">Tên Nhà Xuất Bản</label>
                <input id="inProducerName" runat="server" name="ProducerName" type="text" />
            </div>
            <div class="box-group">
                <label for="ProducerContact">Liên lạc</label>
                <input id="inProducerContact" runat="server" name="ProducerContact" type="text" />
            </div>
            <div class="box-group">
                <label for="ProducerAddress">Địa Chỉ</label>
                <input id="inProducerAddress" runat="server" name="ProducerAddress" type="text" />
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