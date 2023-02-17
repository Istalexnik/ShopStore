<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="ShopStore.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ValidationSummary runat="server" ForeColor="Red"/>
    <table>
        <asp:Label runat="server" ID="lblMessage" />
        <thead>
            <tr>
                <th></th>
                <th>Registration</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>Username:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtUsername" /></td>
                <td><asp:RequiredFieldValidator runat="server" ControlToValidate="txtUsername" ForeColor="Red" Text="*"
                    ErrorMessage="Username is required"/>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtUsername" ForeColor="Red" Text="*"
                        ErrorMessage="Username should be from 3 to 20 characters long starting with a letter. Allowable characters are letters, digits and undescore"
                        ValidationExpression="^(?=[a-zA-Z])[a-zA-Z0-9]{3,20}$"/>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" /></td>
                <td><asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" Text="*" ForeColor="Red"
                    ErrorMessage="Password is required"/>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPassword" Text="*" ForeColor="Red"
                        ErrorMessage="Password should be from 6 to 20 characters and include at least 1 letter and 1 digit"
                        ValidationExpression="^(?=.*[a-z])(?=.*\d)[a-zA-Z\d@#$%&^!?*]{6,20}$"/>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>Email:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" /></td>
                <td><asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" Text="*" ForeColor="Red"
                    ErrorMessage=""/>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail" Text="*" ForeColor="Red"
                        ErrorMessage="Please enter a valid email"
                        ValidationExpression="^[a-zA-Z0-9._+-]+@[a-zA-Z0-9._+-]+\.[a-zA-Z]{2,}$" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button runat="server" ID="btnCreateAccount" Text="Create Account" OnClick="btnCreateAccount_Click" /></td>
                <td></td>
                <td><a href="Login.aspx">Log In</a></td>
            </tr>
        </tbody>
    </table>



</asp:Content>
