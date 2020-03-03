/*
 * Name: Ivan Pavlov 991540069
 * Assignment 3: Master Web Page Code
 * December 5, 2019
*/

using System;
using System.Web.Security;

namespace FlexiLearn___Ivan_Pavlov
{
    public partial class Assignment3WebPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Checking to see what the users role is, and if it isn't admin, than
            //the user wont have access to the admin dashboard hyperlink
            if (Session["role"] == null)
            {
                HypAdmin.Visible = false;
            }
            else if (Session["role"].ToString().Equals("admin"))
            {
                HypAdmin.Visible = true;
            }
            else
            {
                HypAdmin.Visible = false;
            }
        }

        protected void LnkLogout_OnClick(object sender, EventArgs e)
        {
            //Resetting the session variable as well as logging out the current user
            Session["role"] = "";
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}