/*
 * Author: Ivan Pavlov
 * Group Project: User Form Code
 * December 9, 2019
*/

using System;
using System.Collections.Generic;
using ItemFinder.DAL;
using ItemFinderClassLibrary;

namespace ItemFinder.User
{
    public partial class UserForm : System.Web.UI.Page
    {
        //Declaring any objects needed
        readonly ItemDao _itemDao = new ItemDao(Properties.Settings.Default.conString);
        readonly DepartmentDao _departmentDao = new DepartmentDao(Properties.Settings.Default.conString);
        List<Item> _items = new List<Item>();
        List<Department> _departments = new List<Department>();


        protected void Page_Load(object sender, EventArgs e)
        {
            //Getting a list of all departments and items in the database
            _departments = _departmentDao.GetDepartments();
            _items = _itemDao.GetItems();

            if (!IsPostBack)
            {
                //Setting the DropDown to only the items that fit the search criteria
                DrpSearch.DataTextField = "Name";
                DrpSearch.DataValueField = "Name";
                DrpSearch.DataSource = _items;
                DrpSearch.DataBind();
                DrpSearch.SelectedIndex = 0;
            }
        }

        protected void TxtSearch_OnTextChanged(object sender, EventArgs e)
        {
            //Setting all the labels visibility to false until data is gathered
            LblName.Visible = false;
            LblDept.Visible = false;
            LblDesc.Visible = false;
            LblPrice.Visible = false;

            //Filtering the list of items based on what the user searches for
            List<Item> filteredItems = _items.FindAll(item => item.Name.ToUpper().Contains(TxtSearch.Text.ToUpper()));

            if (filteredItems.Count == 0)
            {
                //Setting the DropDown to only the items that fit the search criteria
                DrpSearch.DataTextField = "Name";
                DrpSearch.DataValueField = "Name";
                DrpSearch.DataSource = _items;
                DrpSearch.DataBind();
                DrpSearch.SelectedIndex = 0;
            }
            else
            {
                //Setting the DropDown to only the items that fit the search criteria
                DrpSearch.DataTextField = "Name";
                DrpSearch.DataValueField = "Name";
                DrpSearch.DataSource = filteredItems;
                DrpSearch.DataBind();
                DrpSearch.SelectedIndex = 0;
            }
        }

        protected void BtnSearch_OnClick(object sender, EventArgs e)
        {
            //Setting all labels visibility to true
            LblName.Visible = true;
            LblDept.Visible = true;
            LblDesc.Visible = true;
            LblPrice.Visible = true;

            //Finding both the selected item and department for the item the user chose
            Item selectedItem = _items.Find(item =>
                item.Name.ToUpper().Contains(DrpSearch.SelectedValue.ToUpper()));
            Department selectedDepartment =
                _departments.Find(d => d.Id == selectedItem.DepartmentId);

            //Showing the items info to the user
            LblName.Text = selectedItem.Name;
            LblDept.Text = selectedDepartment.Name;

            if (!string.IsNullOrEmpty(selectedItem.Description))
                LblDesc.Text = selectedItem.Description;
            else
                LblDesc.Text = "-";
            
            if (selectedItem.Price != -1)
                LblPrice.Text = selectedItem.Price.ToString();
            else
                LblPrice.Text = "-";

            SetPin(selectedItem.Location);
        }

        /// <summary>
        /// Method that takes in a coordinate string and puts a pin to
        /// where that item is located on the map
        /// </summary>
        /// <param name="cordString">X and Y coordinates</param>
        private void SetPin(string cordString)
        {

            //Get the image coords
            var coords = cordString.Split(',');
            hidFinalCoords.Value = hidCoords.Value;
           
            //Offset for the image
            var x = float.Parse(coords[0]) - 13;
            var y = float.Parse(coords[1]) - 117;

            //Set the pin based on offset coords
            imgPin.Style.Add("Left", x + "px");
            imgPin.Style.Add("Top", y + "px");

            //Show the pin
            imgPin.Visible = true;
        }
    }
}