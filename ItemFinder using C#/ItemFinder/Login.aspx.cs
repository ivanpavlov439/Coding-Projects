/*
 * Author: Travis Tower
 * Group Project: Login Code
 * December 9, 2019
*/

using System;
using System.Web;
using System.Web.Security;
using ItemFinder.DAL;

namespace ItemFinder
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
                var roles = LoginHelper.GetUserRole(userName);
                var ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now,
                    DateTime.Now.AddMinutes(10), false, roles);
                var strTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, strTicket));

                //Adding the users role in the session for master page to access
                Session["role"] = roles;

                //Redirects user to the different web page based on their role
                Response.Redirect(roles.Equals("Admin")
                    ? "Admin/AdminForm.aspx"
                    : "User/UserForm.aspx");
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