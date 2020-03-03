/*
 * Name: Ivan Pavlov 991540069
 * Assignment 3: Global.asax Code
 * December 5, 2019
*/

using System;
using System.Security.Principal;
using System.Web.Security;
using System.Web.UI;

namespace FlexiLearn___Ivan_Pavlov
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            //Adding the use of scripts for my application
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/jquery-3.4.1.min.js",
                    DebugPath = "~/Scripts/jquery-3.4.1.js",
                    CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-3.4.1.min.js",
                    CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-3.4.1.js"
                });
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //Checking to see if the current user is authenticated and not null
            if (Context.User != null && Context.User.Identity.IsAuthenticated)
            {
                //Setting the role for the user while user is logged in
                var id = (FormsIdentity)Context.User.Identity;
                var ticket = id.Ticket;
                var userData = ticket.UserData;
                string[] roles = userData.Split(','); //assuming multiple roles played by the user are separated by a comma
                Context.User = new GenericPrincipal(id, roles);
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}