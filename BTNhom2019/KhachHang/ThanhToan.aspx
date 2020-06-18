<%@ Page Title="" Language="C#" MasterPageFile="~/KhachHang/CustomerLayout.Master" AutoEventWireup="true" CodeBehind="ThanhToan.aspx.cs" Inherits="BTNhom2019.KhachHang.ThanhToan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:Xml ID="Xml1" runat="server" DocumentSource="~/App_Data/BookStore.xml" OnDataBinding="Xml1_DataBinding" TransformSource="~/XSLT/ThanhToan.xslt"></asp:Xml>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
