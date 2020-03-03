<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="../Assignment3WebPage.Master" CodeBehind="CourseRegistration.aspx.cs" Inherits="FlexiLearn___Ivan_Pavlov.User.CourseRegistration" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="content" runat="server">
    <div>
        <h1>Course Registration</h1>
    </div>
    
    <!--Setting up the Filtering for course registrations-->
    <div>
        <label>Filter by Subject: </label>
        <asp:TextBox ID="TxtFilterSubject" runat="server"></asp:TextBox><br/>
        <label>Filter by Start Date: </label>
        <asp:TextBox ID="TxtFilterDate" runat="server"></asp:TextBox><br/>
        <label>Filter by Fee: </label>
        <asp:TextBox ID="TxtFilterFee" runat="server"></asp:TextBox><br/>
        <asp:Button ID="BtnFilterAll" runat="server" Text="Filter" OnClick="BtnFilter_OnClick" />
        <asp:Button runat="server" ID="BtnResetFilter" Text="Reset Filter" OnClick="BtnResetFilter_OnClick"/>
    </div>
    <div>
        
        <!--Setting up the GridView with sorting and manually entering columns-->
        <asp:GridView ID="GrdCourse" runat="server" 
                          AutoGenerateColumns="false" 
                          AllowSorting="true" OnSorting="GrdCourse_OnSorting"
                          CellPadding="4" ForeColor="#333333" GridLines="Both">
            
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
                <asp:BoundField DataField="Title" HeaderText="Course Title" SortExpression="Title" />
                <asp:BoundField DataField="Subject" HeaderText="Subject Description" SortExpression="Subject" />
                <asp:BoundField DataField="StartDate" HeaderText="Course Start Date" SortExpression="StartDate" />
                <asp:BoundField DataField="DurationInWeeks" HeaderText="Duration (In Weeks)" SortExpression="DurationInWeeks" />
                <asp:BoundField DataField="Fee" HeaderText="Course Fee" SortExpression="Fee" />
                <asp:TemplateField HeaderText="Register for Course">
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkCourse" runat="server"/>

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
    <div>
        <asp:Button runat="server" ID="BtnSubmit" Text="Submit Registrations" OnClick="BtnSubmit_OnClick" />
    </div>
    <div>
        <asp:Label runat="server" ID="LblStatus"></asp:Label>
    </div>
</asp:Content>