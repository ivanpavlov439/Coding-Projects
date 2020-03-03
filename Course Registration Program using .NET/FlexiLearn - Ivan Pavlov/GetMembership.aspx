<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Assignment3WebPage.Master" CodeBehind="GetMembership.aspx.cs" Inherits="FlexiLearn___Ivan_Pavlov.GetMembership" %>
<asp:Content id="Content2" ContentPlaceHolderID="head" runat="server">
    <title>Get Membership</title>
    
    <!--Setting up the javascript for the custom validators-->
    <script type="text/javascript">
        function checkDob(sender, args) {
            if (window.TxtDate.Text != "") {
                args.IsValid = window.DateTime.Parse(window.TxtDate.Text).Year < (window.DateTime.Now.Year - 18);
            }
        }

        function checkPass(sender, args) {
            if (window.TxtPassword.Text.Length < 10 || window.TxtPassword.Text.Length > 15) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }
    </script>
    <style>
        .Status {
            color: red;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content id="Content1" ContentPlaceHolderID="content" runat="server">
    <div>
        <h1>Create Account</h1>
    </div>
    
    <!--Setting up the web controls for registering with validators-->
    <div>
        <asp:Label runat="server" ID="LblStatus" CssClass="Status"></asp:Label>
    </div>
    <div>
        <label>User Name: </label>
        <asp:TextBox runat="server" ID="TxtUserName"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValNameReq" runat="server"
                                        ControlToValidate="TxtUserName" Display="Dynamic"
                                        ErrorMessage="Name Required"></asp:RequiredFieldValidator>
    </div>
    <div>
        <label>Email: </label>
        <asp:TextBox runat="server" ID="TxtEmail"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValEmailReq" runat="server"
                                        ControlToValidate="TxtEmail" Display="Dynamic"
                                        ErrorMessage="Email Required"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="ValEmailRegEx" runat="server"
                                            ControlToValidate="TxtEmail" Display="Dynamic"
                                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ErrorMessage="Email format is incorrect"></asp:RegularExpressionValidator>
    </div>
    <div>
        <label>Phone Number (Optional): </label>
        <asp:TextBox runat="server" ID="TxtNumber"></asp:TextBox>
    </div>
    <div>
        <label>Education Level: </label>
        <asp:ListBox ID="LstEducation" runat="server"></asp:ListBox>
    </div>
    <div>
        <label>Date of Birth: </label>
        <asp:TextBox runat="server" ID="TxtDate" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValDateReq" runat="server"
                                        ControlToValidate="TxtDate" Display="Dynamic"
                                        ErrorMessage="Date of Birth Required"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="ValDateOfBirth" runat="server" 
                                 ErrorMessage="Must be 18 years old"
                                 ClientValidationFunction="checkDob"
                                 OnServerValidate="ValDateOfBirth_OnServerValidate"></asp:CustomValidator>
    </div>
    <div>
        <label>Password: </label>
        <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValPasswordReq" runat="server" 
                                        ControlToValidate="TxtPassword" Display="Dynamic"
                                        ErrorMessage="Password Required"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="ValPassCustom" runat="server" 
                                 ErrorMessage="Password length should be 10-15 characters"
                                 ClientValidationFunction="checkPass"
                                 OnServerValidate="ValPassCustom_OnServerValidate"></asp:CustomValidator>
    </div>
    <div>
        <label>Confirm Password: </label>
        <asp:TextBox ID="TxtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:CompareValidator ID="ValComparePassword" runat="server" 
                                  ErrorMessage="Confirm Passwords Match" 
                                  ControlToValidate="TxtConfirmPassword" 
                                  ControlToCompare="TxtPassword"></asp:CompareValidator>
    </div>
    <div>
        <asp:Button runat="server" ID="BtnSubmit" OnClick="BtnSubmit_OnClick" Text="Register"/>
    </div>
</asp:Content>