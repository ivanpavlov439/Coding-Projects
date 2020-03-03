/*
 * Name: Ivan Pavlov 991540069
 * Assignment 3: UserRegistration Code
 * December 5, 2019
*/

using System;
using System.Data;
using System.Web.UI.WebControls;
using FlexiLearn___ClassLibrary.DAL;

namespace FlexiLearn___Ivan_Pavlov.User
{
    public partial class UserDashboard : System.Web.UI.Page
    {
        //Declaring all objects needed
        readonly RegistrationDao _registrationDao = new RegistrationDao(Properties.Settings.Default.conString);
        private DataTable _registerTable = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Getting the current users data from registration table
            _registerTable = _registrationDao.PullUserData(Context.User.Identity.Name);
            if (!IsPostBack)
            {
                //Populating the GridView element based on the data table
                LblUser.Text =
                    $"Course Registration Details For {Context.User.Identity.Name}";
                GrdRegister.DataSource = _registerTable;
                GrdRegister.DataBind();
            }
        }

        protected void GrdRegister_OnSorting(object sender, GridViewSortEventArgs e)
        {
            //Sorting the GridView based on the column the user selects
            _registerTable.DefaultView.Sort = e.SortExpression;
            GrdRegister.DataSource = _registerTable;
            GrdRegister.DataBind();
        }
    }
}