<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BTNhom2019._Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <style>
        body {
            background-color: palegoldenrod;
        }
        .go-to {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            display: flex;
        }
        .to {
            margin: 40px;
            font-size: 40px;
            text-decoration: none;
            color: black;
            font-weight: bold;
            border: 10px solid black;
            border-radius: 20px;
            background-color: white;
            
            display: flex;
            width: 400px;
            height: 400px;
            align-items: center;
            justify-content: center;
            transition: 200ms ease;
        }
        .to:hover {
            transform: scale(1.2);
        }

    </style>
</head>
<body>
    <form id="form1" class="master_form" runat="server">
        <div class="go-to">
            <a class="to" href="/Admin/DangNhap">NHÂN VIÊN</a>
            <a class="to" href="/KhachHang/TrangChu">KHÁCH HÀNG</a>
        </div>
    </form>
</body>
</html>

    
