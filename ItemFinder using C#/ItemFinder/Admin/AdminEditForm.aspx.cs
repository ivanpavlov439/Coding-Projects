/*
 * Author: Ivan Pavlov
 * Group Project: Admin Edit Form Code
 * December 9, 2019
*/

using System;
using System.Collections.Generic;
using System.Web.UI;
using ItemFinder.DAL;
using ItemFinderClassLibrary;

namespace ItemFinder.Admin
{
    public partial class AdminEditForm : Page
    {
        //Declaring any objects/variables needed
        readonly DepartmentDao _departmentDao =
            new DepartmentDao(Properties.Settings.Default.conString);

        List<Department> _departments = new List<Department>();
        private int _itemId;


        protected void Page_Load(object sender, EventArgs e)
        {
            //Getting the item id from session from the admin form page
            _itemId = Convert.ToInt32(Session["ItemId"]);

            if (!IsPostBack)
            {
                //Getting the item id from session from the admin form page
                _itemId = Convert.ToInt32(Session["ItemId"]);

                //Setting the dropdown to all the departments from the Departments table
                _departments = _departmentDao.GetDepartments();
                DrpDepartment.DataSource = _departments;
                DrpDepartment.DataTextField = "Name";
                DrpDepartment.DataValueField = "Id";
                DrpDepartment.DataBind();
                DrpDepartment.SelectedIndex = 0;

                if (Session["Item"] is Item item)
                {
                    //If it isn't null, display item properties to user
                    TxtDescription.Text = item.Description;
                    TxtName.Text = item.Name;
                    TxtPrice.Text = item.Price.ToString();

                    //Setting pin location on map
                    SetPin(item.Location);
                    hidFinalCoords.Value = item.Location;
                }
            }
        }

        protected void ImgMap_OnClick(object sender, ImageClickEventArgs e)
        {
            //Setting the pin location to where the user clicked
            SetPin(hidCoords.Value);
        }

        protected void BtnUpdateItem_OnClick(object sender, EventArgs e)
        {
            //Creating a new item dao to update an existing item  in the database
            var dao = new ItemDao(Properties.Settings.Default.conString);

            if (!float.TryParse(TxtPrice.Text, out float price))
                price = -1;

            var item = new Item(int.Parse(DrpDepartment.SelectedValue),
                TxtName.Text, hidFinalCoords.Value, TxtDescription.Text,
                price);

            //Updating item table as well as redirecting back to the admin form
            dao.UpdateItem(item, _itemId);
            Response.Redirect("/Admin/AdminForm.aspx");
        }

        /// <summary>
        /// Method that will set the pin image to wherever the user clicked on the store map
        /// </summary>
        /// <param name="cordString">String representation of the position the user clicked
        /// on the screen</param>
        void SetPin(string cordString)
        {
            hidFinalCoords.Value = hidCoords.Value;

            //Get the image coords
            var coords = cordString.Split(',');

            //Offset for the image
            var x = float.Parse(coords[0]) - 13;
            var y = float.Parse(coords[1]) - 117;

            //Sets the pin based on offset coords
            ImgPin.Style.Add("Left", x + "px");
            ImgPin.Style.Add("Top", y + "px");

            //Show the pin to user
            ImgPin.Visible = true;
        }
    }
}