<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/AdminLayout.Master" CodeBehind="Sach.aspx.cs" MaintainScrollPositionOnPostback="true"
    Inherits="BTNhom2019.Admin.Sach" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Quản lý Sách</title>
    <style>
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <h1 class="page-title">Quản lý Sách</h1>
    <div class="grid-view-container">
        <asp:GridView ID="grdSach" runat="server" CssClass="grid-view"
            OnSelectedIndexChanged="grdSach_SelectedIndexChanged"
            HorizontalAlign="Center">
            <Columns>
                <asp:CommandField InsertText="Chọn" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="edit-box box-sach">
        <h2>Thông tin Sách</h2>
        <div class="box">
            <div class="small-box small-box-1">
                <div class="box-group">
                    <label for="BookID">Mã Sách</label>
                    <input id="inBookID" runat="server" name="BookID" type="text" disabled="disabled" />
                </div>
                <div class="box-group">
                    <label for="BookName">Tên Sách</label>
                    <input id="inBookName" runat="server" name="BookName" type="text" />
                </div>
                <div class="box-group">
                    <label for="BookPrice">Giá</label>
                    <input id="inBookPrice" runat="server" name="BookPrice" type="number" min="0" />
                </div>
                <div class="box-inline-group">
                    <div class="box-group">
                        <label for="BookQuantity">Số lượng</label>
                        <input id="inBookQuantity" runat="server" name="BookQuantity" type="number" min="0" />
                    </div>
                    <div class="box-group">
                        <label for="BookDiscount">Giảm giá</label>
                        <input id="inBookDiscount" runat="server" name="BookDiscount" type="number" min="0" />
                    </div>
                </div>
                <div class="box-inline-group">
                    <div class="box-group">
                        <label>Tác giả:</label>
                        <asp:DropDownList ID="inAuthor" runat="server" AutoPostBack="True" />
                    </div>
                    <div class="box-group">
                        <label>Thể loại:</label>
                        <asp:DropDownList ID="inCategory" runat="server" AutoPostBack="True" />
                    </div>
                </div>
            </div>

            <div class="small-box small-box-2">
                <div class="box-inline-group">
                    <div class="box-group">
                        <label>Nhà xuất bản:</label>
                        <asp:DropDownList ID="inProducer" runat="server" AutoPostBack="True"/>
                    </div>
                    <div class="box-group">
                        <label for="Year">Năm</label>
                        <input id="inYear" runat="server" name="Year" type="number" min="0" />
                    </div>
                </div>
                <div class="box-inline-group">
                    <div class="box-group">
                        <label for="Pages">Số trang</label>
                        <input id="inPages" runat="server" name="Pages" type="number" min="0" />
                    </div>
                    <div class="box-group">
                        <label for="Size">Kích thước</label>
                        <input id="inSize" runat="server" name="Size" type="text" />
                    </div>
                </div>

                <div class="box-group" wd>
                    <label>Mô tả:</label>
                    <textarea id="inDescription" runat="server" rows="4"></textarea>
                </div>
            </div>

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