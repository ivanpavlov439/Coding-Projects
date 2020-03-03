/*
 * Name: Ivan Pavlov 991540069
 * Assignment 3: Login Code
 * December 5, 2019
*/

using System;
using System.Web.Security;
using FlexiLearn___ClassLibrary.Logic;

namespace FlexiLearn___Ivan_Pavlov
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnLogin_OnClick(object sender, EventArgs e)
        {
            //Gathers login info from the page
            LblError.Visible = false;
            var userName = TxtUserName.Text;
            var password = TxtPassword.Text;

            //Checks to see if the user exists in the database
            if (LoginHelper.IsUserAuthentic(userName, password))
            {
                //Creating a forms authentication ticket for the user
                var roles = LoginHelper.GetUserRole(userName, password);
                var ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now,
                    DateTime.Now.AddMinutes(10), false, roles);
                var strTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, strTicket));

                //Adding the users role in the session for master page to access
                Session["role"] = roles;

                //Redirects user to the default web page
                Response.Redirect(FormsAuthentication.GetRedirectUrl(userName, false));
            }
            else
            {
                //Displays error to user on login failure
                LblError.Visible = true;
                LblError.Text = "Incorrect user and/or password!";
            }
        }
    }
}