/*
 * Author: Ivan Pavlov
 * Group Project: Admin Form Code
 * December 9, 2019
*/

using System;
using System.Data;
using System.Web.UI.WebControls;
using ItemFinder.DAL;

namespace ItemFinder.Admin
{
    public partial class AdminForm : System.Web.UI.Page
    {
        //Declaring any objects needed
        private readonly ItemDao _itemDao = new ItemDao(Properties.Settings.Default.conString);
        private DataTable _itemDataTable = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            //If it isn't PostBack, load data into the GridView
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void GrdCourse_OnSorting(object sender, GridViewSortEventArgs e)
        {
            //Load data into the GridView
            LoadData();

            //Sorting the GridView based on the column the user selected
            _itemDataTable.DefaultView.Sort = e.SortExpression;
            GrdAdmin.DataSource = _itemDataTable;
            GrdAdmin.DataBind();
        }

        protected void BtnUpdate_OnClick(object sender, EventArgs e)
        {
            //Getting the current row and from that row getting the item object based
            //on its item id
            var currentRow = (GridViewRow)(((Button)sender)).NamingContainer;
            var id = int.Parse(((HiddenField)GrdAdmin.Rows[currentRow.RowIndex].FindControl("ItemId")).Value);
            var item = _itemDao.GetItem(id);

            //Setting session variables for both the item object as well as its corresponding item id
            Session["Item"] = item;
            Session["ItemId"] = id;

            //Redirecting admin to the edit form
            Response.Redirect("AdminEditForm.aspx");
        }

        /// <summary>
        /// Method that loads data into the GridView based on the DataTable of all
        /// the items that are in the Database
        /// </summary>
        protected void LoadData()
        {
            //Setting up the GridView based on the DataTable
            _itemDataTable = _itemDao.PullAllData();
            GrdAdmin.DataSource = _itemDataTable;
            GrdAdmin.DataBind();
        }

        protected void BtnFilter_OnClick(object sender, EventArgs e)
        {
            //Filtering GridView based on UserName from the text given inside the TextBox
            LoadData();
            _itemDataTable.DefaultView.RowFilter = $"[ItemName] like '%{TxtFilter.Text}%'";
            GrdAdmin.DataSource = _itemDataTable;
            GrdAdmin.DataBind();
        }

        protected void BtnResetFilter_OnClick(object sender, EventArgs e)
        {
            //Resetting the GridView to its original state before more filters
            //are used
            LoadData();
            TxtFilter.Text = "";
        }
    }
}