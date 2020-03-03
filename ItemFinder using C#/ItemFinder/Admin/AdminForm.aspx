<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../ItemFinder.Master" CodeBehind="AdminForm.aspx.cs" Inherits="ItemFinder.Admin.AdminForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Admin Dashboard</h1>
    <div>
        <label>Filter by Name: </label>
        <asp:TextBox ID="TxtFilter" runat="server"></asp:TextBox>
        <asp:Button ID="BtnFilter" runat="server" Text="Filter" OnClick="BtnFilter_OnClick" />
        <asp:Button runat="server" ID="BtnResetFilter" Text="Reset Filter" OnClick="BtnResetFilter_OnClick"/>
        <br/>
    </div>

    <!--Setting up the GridView with sorting and manually entering columns-->
    <asp:GridView ID="GrdAdmin" runat="server"
                  AutoGenerateColumns="False"
                  AllowSorting="True" OnSorting="GrdCourse_OnSorting"
                  CellPadding="4" ForeColor="#333333" GridLines="Both">

        <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
        <EditRowStyle BackColor="#999999"/>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"/>
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"/>
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"/>
        <SortedAscendingCellStyle BackColor="#E9E7E2"/>
        <SortedAscendingHeaderStyle BackColor="#506C8C"/>
        <SortedDescendingCellStyle BackColor="#FFFDF8"/>
        <SortedDescendingHeaderStyle BackColor="#6F8DAE"/>
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="ItemId" runat="server" Value='<%# Eval("ItemId")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ItemName" HeaderText="Item Name" SortExpression="ItemName"/>
            <asp:BoundField DataField="DepartmentId" HeaderText="Department ID" SortExpression="DepartmentId"/>
            <asp:BoundField DataField="ItemLocation" HeaderText="Item Location" SortExpression="ItemLocation"/>
            <asp:BoundField DataField="ItemDesc" HeaderText="Item Description" SortExpression="ItemDesc"/>
            <asp:BoundField DataField="ItemPrice" HeaderText="Item Price" SortExpression="ItemPrice"/>
            <asp:TemplateField HeaderText="Update Item">
                <ItemTemplate>
                    <asp:Button runat="server" ID="BtnUpdate" Text="Update Item" OnClick="BtnUpdate_OnClick"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>