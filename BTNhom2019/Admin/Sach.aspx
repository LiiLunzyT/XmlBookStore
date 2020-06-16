<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/AdminLayout.Master" CodeBehind="Sach.aspx.cs" MaintainScrollPositionOnPostback="true"
    Inherits="BTNhom2019.Admin.Sach" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Quản lý Sách</title>
    <style>
        #form {
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .error {
            border-color: red;
        }

        .grid-view {
            width: 100%;
            font-size: 1.3rem;
        }

        .edit-box {
            margin-top: 10px;
            width: 1000px;
            display: flex;
            flex-direction: column;
            align-items: center;
            border: 1px solid black;
            padding: 10px 30px;
        }
        .edit-box__page, edit-box__control {
            width: 100%;
            display: flex;
        }

        .page--1 {
            width: 40%;
        }
        box__group, .edit-box__control {
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
        .small-box {
            width: 100%;
            display: flex;
            justify-content: center;
        }
        
        .page--2 {
            margin-left: 10px;
            padding: 10px;
            width: 60%;
            display: flex;
            flex-wrap: wrap;
            align-items: flex-start;
        }
        .small-box .small-box__group {
            flex: 1;
            margin-right: 10px;
        }
        .small-box .small-box__group input {
            width: 100%;
            padding: 5px;
        }
        select {
            width: 100%;
            padding: 5px;
        }
        textarea {
            width: 100%;
        }
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <h1 style="margin: 10px 0; text-align: center">Quản lý Sách</h1>
    <div id="form">
        <div style="width: 80%; height: 250px; overflow-y: scroll; border: 1px solid black;">
            <asp:GridView ID="grdSach" runat="server" CssClass="grid-view"
                OnSelectedIndexChanged="grdSach_SelectedIndexChanged"
                HorizontalAlign="Center">
                <Columns>
                    <asp:CommandField InsertText="Chọn" ShowSelectButton="True" />
                </Columns>
                <HeaderStyle/>
            </asp:GridView>
        </div>
        <div class="edit-box">
            <h2 style="margin: 5px 0">Thông tin Sách</h2>
            <div class="edit-box__page">
                <div class="page--1">
                    <div class="edit-box__group">
                        <label for="BookID">Mã Sách</label>
                        <input id="inBookID" runat="server" name="BookID" type="text" disabled="disabled"/>
                    </div>
                    <div class="edit-box__group">
                        <label for="BookName">Tên Sách</label>
                        <input id="inBookName" runat="server" name="BookName" type="text"/>
                    </div>
                    <div class="edit-box__group">
                        <label for="BookPrice">Giá</label>
                        <input id="inBookPrice" runat="server" name="BookPrice" type="number" min="0"/>
                    </div>
                    <div class="edit-box__group">
                        <label for="BookQuantity">Số lượng</label>
                        <input id="inBookQuantity" runat="server" name="BookQuantity" type="number" min="0"/>
                    </div>
                    <div class="edit-box__group">
                        <label for="BookDiscount">Giảm giá</label>
                        <input id="inBookDiscount" runat="server" name="BookDiscount" type="number" min="0"/>
                    </div>
                </div>
                
                <div class="page--2">
                    <div class="small-box">
                        <div class="small-box__group" style="width: 50%;">
                            <label>Tác giả:</label>
                            <asp:DropDownList ID="inAuthor" runat="server" AutoPostBack="True"/>
                        </div>
                        <div class="small-box__group" style="width: 50%;">
                            <label>Thể loại:</label>
                            <asp:DropDownList ID="inCategory" runat="server" AutoPostBack="True" />
                        </div>
                        <div class="small-box__group" style="width: 50%;">
                            <label>Nhà xuất bản:</label>
                            <asp:DropDownList ID="inProducer" runat="server" AutoPostBack="True" />
                        </div>
                    </div>
                    <div class="small-box">
                        <div class="small-box__group">
                            <label for="Pages">Số trang</label>
                            <input id="inPages" runat="server" name="Pages" type="number" min="0"/>
                        </div>
                        <div class="small-box__group">
                            <label for="Size">Kích thước</label>
                            <input id="inSize" runat="server" name="Size" type="text"/>
                        </div>
                        <div class="small-box__group">
                            <label for="Year">Năm</label>
                            <input id="inYear" runat="server" name="Year" type="number" min="0"/>
                        </div>
                    </div>
                    
                    <div class="edit-box__group" wd>
                        <label>Mô tả:</label>
                        <textarea id="inDescription" runat="server" rows="4"></textarea>
                    </div>
                </div>
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