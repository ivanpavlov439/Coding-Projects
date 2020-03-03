<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Assignment3WebPage.Master" CodeBehind="AdminDashboard.aspx.cs" Inherits="FlexiLearn___Ivan_Pavlov.Admin.AdminDashboard" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content id="Content1" ContentPlaceHolderID="content" runat="server">    
    <div>
        <h1>Admin Dashboard</h1>
    </div>
    <div>
        <label>Filter by Name: </label>
        <asp:TextBox ID="TxtFilter" runat="server"></asp:TextBox><br/>
        <asp:Button ID="BtnFilter" runat="server" Text="Filter" OnClick="BtnFilter_OnClick" />
        <asp:Button runat="server" ID="BtnResetFilter" Text="Reset Filter" OnClick="BtnResetFilter_OnClick"/>
    </div>
    <div>
        
        <!--Setting up the GridView with sorting and manually entering columns-->
        <asp:GridView ID="GrdAdmin" runat="server" CellPadding="4" ForeColor="#333333" 
                      AutoGenerateColumns="False" 
                      AllowSorting="true" OnSorting="GrdAdmin_OnSorting"
                      GridLines="Both">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="RegisterId" runat="server" Value='<%# Eval("RegistrationId")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="UserName" HeaderText="User" SortExpression="UserName" />
                <asp:BoundField DataField="CourseTitle" HeaderText="Course Code" SortExpression="CourseTitle" />
                <asp:BoundField DataField="CourseSubject" HeaderText="Subject Description" SortExpression="CourseSubject" />
                <asp:BoundField DataField="RegisteredDate" HeaderText="Date Registered for Course" SortExpression="RegisteredDate" />
                <asp:BoundField DataField="Status" HeaderText="Current Status" SortExpression="Status" />
                <asp:TemplateField HeaderText="Modify Status">
                    <ItemTemplate>
                        <asp:DropDownList ID="DrpStatus" runat="server"></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <asp:Button runat="server" ID="BtnUpdateAll" Text="Update All" OnClick="BtnUpdateAll_OnClick"/>
    </div>
</asp:Content>