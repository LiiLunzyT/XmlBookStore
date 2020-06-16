<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="BTNhom2019.Admin.DangNhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
        }
        .form__login {
            padding: 10px 20px;
            width: 400px;
            display: flex;
            flex-direction: column;
            align-items: center;
            border: 2px solid gray;
            border-radius: 10px;
        }
        .form__login h1{
            margin: 5px 0;
        }
        .form__group {
            width: 100%;
            display: flex;
            flex-direction: column;
            margin-top: 10px;
        }
        .form__group label {
            color: gray;
        }
        .form__group input {
            padding: 10px;
            font-size: 15px;
        }
        .btnLogin {
            margin-top: 20px;
            padding: 10px;
        }
    </style>
</head>
<body>
    <form id="form__login" class="form__login" runat="server">
        <h1>ĐĂNG NHẬP</h1>
        <div class="form__group">
            <label for="username">Tài khoản</label>
            <input id="username" type="text" runat="server" />
        </div>
        <div class="form__group">
            <label for="password">Mật khẩu: </label>
            <input id="password" type="password" runat="server" />
        </div>
        <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" CssClass="btnLogin" OnClick="btnLogin_Click" />
    </form>
</body>
</html>
