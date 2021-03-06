﻿/*
 * Author: Travis Tower
 * Group Project: Register Code
 * December 9, 2019
*/

using System;
using ItemFinder.DAL;

namespace ItemFinder
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegister_OnClick(object sender, EventArgs e)
        {
            //Declaring the dao that is needed to access Users
            var userDao = new UserDao();

            //Adding the user record to the users table within the database
            (int, int) result = userDao.AddRecord(TxtUser.Text, TxtPassword.Text);

            //If successful, redirect newly registered user to the login page
            if (result.Item2 > 0)
                Response.Redirect("/Login.aspx");
        }
    }
}