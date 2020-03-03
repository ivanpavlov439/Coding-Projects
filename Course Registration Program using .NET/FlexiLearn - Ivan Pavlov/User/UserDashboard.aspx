<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Assignment3WebPage.Master" CodeBehind="UserDashboard.aspx.cs" Inherits="FlexiLearn___Ivan_Pavlov.User.UserDashboard" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <style>
        .DashboardHeader {
            font-weight: bold;
            font-size: 2em;
        }
    </style>
</asp:Content>
<asp:Content id="Content1" ContentPlaceHolderID="content" runat="server">
    <div>
        <asp:Label runat="server" ID="LblUser" CssClass="DashboardHeader"></asp:Label>
    </div>
    <div>
        
        <!--Setting up the GridView with sorting and manually entering columns-->
        <asp:GridView ID="GrdRegister" runat="server" CellPadding="4" ForeColor="#333333" 
                      AutoGenerateColumns="False" 
                      AllowSorting="true" OnSorting="GrdRegister_OnSorting"
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
                <asp:BoundField DataField="CourseTitle" HeaderText="Course Code" SortExpression="CourseTitle" />
                <asp:BoundField DataField="CourseSubject" HeaderText="Subject Description" SortExpression="CourseSubject" />
                <asp:BoundField DataField="RegisteredDate" HeaderText="Date Registered for Course" SortExpression="RegisteredDate" />
                <asp:BoundField DataField="Status" HeaderText="Status of Registration" SortExpression="Status" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>