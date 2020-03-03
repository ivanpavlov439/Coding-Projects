/*
 * Name: Ivan Pavlov 991540069
 * Assignment 3: AdminDashboard Code
 * December 5, 2019
*/

using System;
using System.Data;
using System.Web.UI.WebControls;
using FlexiLearn___ClassLibrary;
using FlexiLearn___ClassLibrary.DAL;

namespace FlexiLearn___Ivan_Pavlov.Admin
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        //Declaring objects needed
        readonly RegistrationDao _registrationDao = new RegistrationDao(Properties.Settings.Default.conString);
        private DataTable _registerTable = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Loading data into GridView based on the PostBack status
            if (!IsPostBack)
            {
                LoadData();
            }     
        }

        protected void GrdAdmin_OnSorting(object sender, GridViewSortEventArgs e)
        {
            //Sorting the GridView based on the column the user selected
            LoadData();
            _registerTable.DefaultView.Sort = e.SortExpression;
            GrdAdmin.DataSource = _registerTable;
            GrdAdmin.DataBind();
        }

        protected void BtnFilter_OnClick(object sender, EventArgs e)
        {
            //Filtering GridView based on UserName from the text given inside the TextBox
            LoadData();
            _registerTable.DefaultView.RowFilter = $"[UserName] like '%{TxtFilter.Text}%'";
            GrdAdmin.DataSource = _registerTable;
            GrdAdmin.DataBind();
        }

        protected void BtnUpdateAll_OnClick(object sender, EventArgs e)
        {
            //Looping through all the rows of the GridView
            for (var i = 0; i < GrdAdmin.Rows.Count; i++)
            {
                //Getting the id and status of registration from the GridView
                var dropDownStatus = (DropDownList)GrdAdmin.Rows[i].FindControl("DrpStatus");
                var id = int.Parse(((HiddenField) GrdAdmin.Rows[i].FindControl("RegisterId")).Value);
                var status = dropDownStatus.SelectedValue;

                //Updating database if there is a change needing to be made
                if (!status.Equals("NoChangeNeeded"))
                {
                    _registrationDao.UpdateRegistration(id, status);
                }
            }

            //Refresh the data inside the GridView
            LoadData();
        }
        /// <summary>
        /// Method that will read from the registration table and populate the GridView
        /// with all its information.
        /// </summary>
        private void LoadData()
        {
            //Setting up the GridView based on the DataTable
            _registerTable = _registrationDao.PullAllData();
            GrdAdmin.DataSource = _registerTable;
            GrdAdmin.DataBind();

            //Looping through each row to setup the dropdown of each request
            for (var i = 0; i < GrdAdmin.Rows.Count; i++)
            {
                var dropDownStatus = (DropDownList) GrdAdmin.Rows[i].FindControl("DrpStatus");
                dropDownStatus.DataSource = Enum.GetValues(typeof(Status)); 
                dropDownStatus.DataBind();
                dropDownStatus.SelectedIndex = 0;
            }
            
        }

        protected void BtnResetFilter_OnClick(object sender, EventArgs e)
        {
            //Setting GridView to the default view without any filters
            LoadData();
        }
    }
}