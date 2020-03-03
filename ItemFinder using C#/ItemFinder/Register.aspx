<%@ Page Title="" Language="C#" MasterPageFile="~/ItemFinder.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ItemFinder.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Register</h1>
    <div>
        <label>Username:</label>
        <asp:TextBox runat="server" Id="TxtUser"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="TxtUser" Display="Dynamic"
                                    ErrorMessage="Name Required"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="ValUserFormat" runat="server"
                                        ControlToValidate="TxtUser" Display="Dynamic"
                                        ValidationExpression="[A-Za-z0-9]{5,10}"
                                        ErrorMessage="Invalid Username Format. Must Be At Least 5-10 Characters"></asp:RegularExpressionValidator>
    </div>

    <div>
        <label>Password:</label>
        <asp:TextBox runat="server" Id="TxtPassword" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="TxtPassword" Display="Dynamic"
                                    ErrorMessage="Password Required"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator runat="server"
                                        ID="ValPasswordReg" 
                                        Display="Dynamic" 
                                        ControlToValidate="TxtPassword"
                                        ValidationExpression="^[\s\S]{6,15}$"
                                        ErrorMessage="Password must be between 6 and 15 characters"></asp:RegularExpressionValidator>
    </div>

    <div>
        <label>Confirm Password:</label>
        <asp:TextBox runat="server" Id="TxtPasswordConfirm" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ControlToValidate="TxtPasswordConfirm" Display="Dynamic"
                                    ErrorMessage="Password Required"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="ValConfirmPassword" runat="server" 
                              ErrorMessage="Passwords do not match." 
                              ControlToValidate="TxtPasswordConfirm" 
                              ControlToCompare="TxtPassword"></asp:CompareValidator>
    </div>
    

    <div>
        <asp:Button runat="server" Id="BtnRegister" Text="Register" OnClick="BtnRegister_OnClick"></asp:Button>
    </div>
</asp:Content>
