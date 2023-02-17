<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShopStore.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <asp:Label runat="server" ID="lblMessage"/>
        <thead>
            <tr>
                <th></th>
                <th>Login</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>Username:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtUsername" />
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtPassword" /></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button runat="server" ID="btnLogin" Text="Log In" /></td>
                <td></td>
                <td><a href="Registration.aspx">Create Account</a></td>
            </tr>
        </tbody>
    </table>
</asp:Content>
