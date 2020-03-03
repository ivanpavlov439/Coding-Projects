<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../ItemFinder.Master" CodeBehind="UserForm.aspx.cs" Inherits="ItemFinder.User.UserForm" %>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    
    <style>
        .parent {
            position: relative;
            top: 0;
            left: 0;
        }
        .image1 {
            position: relative;
            top: 0;
            left: 0;
        }
        .image2 {
            position: absolute;
            top: 30px;
            left: 70px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>User Dashboard</h1>

    <asp:HiddenField ID="hidCoords" runat="server" />
    <asp:HiddenField ID="hidFinalCoords" runat="server" />

    <div class="parent">
        <asp:ImageButton ID="ImageButton1" CssClass="image1" runat="server" 
                         Width="600px" ImageUrl="~/Images/supermarket.jpg" 
                         />

        <asp:Image ID="imgPin" CssClass="image2" runat="server"   
                   Width="10px" ImageUrl="~/Images/mappin.png"
                   Visible="False"/>
    </div>

    <div>
        <label>Search</label>
        <asp:TextBox ID="TxtSearch" runat="server" OnTextChanged="TxtSearch_OnTextChanged" AutoPostBack="True"></asp:TextBox>
        <asp:DropDownList ID="DrpSearch" runat="server"></asp:DropDownList>
    </div>

    <div>
        <asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_OnClick"/>
    </div>

    <div>
        <label>Item Name:</label>
        <asp:Label ID="LblName" runat="server" Text="Label" Visible="False"></asp:Label>
    </div>

    <div>
        <label>Item Department:</label>
        <asp:Label ID="LblDept" runat="server" Text="Label" Visible="False"></asp:Label>
    </div>

    <div>
        <label>Item Description:</label>
        <asp:Label ID="LblDesc" runat="server" Text="Label" Visible="False"></asp:Label>
    </div>

    <div>
        <label>Item Price:</label>
        <asp:Label ID="LblPrice" runat="server" Text="Label" Visible="False"></asp:Label>
    </div>

</asp:Content>