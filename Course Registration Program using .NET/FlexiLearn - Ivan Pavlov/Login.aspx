<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Assignment3WebPage.Master" CodeBehind="Login.aspx.cs" Inherits="FlexiLearn___Ivan_Pavlov.Login" %>
<asp:Content id="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content id="Content1" ContentPlaceHolderID="content" runat="server">
    <div>
        <h1>Login Page</h1>
    </div>
    <div>
        <label>User Name: </label>
        <asp:TextBox runat="server" ID="TxtUserName"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValUserNameReq" runat="server"
                                    ControlToValidate="TxtUserName" Display="Dynamic"
                                    ErrorMessage="Name Required"></asp:RequiredFieldValidator>
    </div>
    <div>
        <label>Password: </label>
        <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValPasswordReq" runat="server" 
                                    ControlToValidate="TxtPassword" Display="Dynamic"
                                    ErrorMessage="Password Required"></asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Button runat="server" ID="BtnLogin" OnClick="BtnLogin_OnClick" Text="Login"/>
    </div>
    <div>
        <asp:Label runat="server" ID="LblError" Visible="False"></asp:Label>
    </div>
</asp:Content>
