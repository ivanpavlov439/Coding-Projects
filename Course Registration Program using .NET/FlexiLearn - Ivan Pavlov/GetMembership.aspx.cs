/*
 * Name: Ivan Pavlov 991540069
 * Assignment 3: GetMembership Code
 * December 5, 2019
*/

using System;
using System.Web.UI.WebControls;
using FlexiLearn___ClassLibrary;
using FlexiLearn___ClassLibrary.DAL;

namespace FlexiLearn___Ivan_Pavlov
{
    public partial class GetMembership : System.Web.UI.Page
    {
        //Creating a userDao object to insert users to database
        private UserDao _userDao;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Connecting dao to the local database
            _userDao = new UserDao(Properties.Settings.Default.conString);

            //Populating listbox based on an Enum
            LstEducation.DataSource = Enum.GetValues(typeof(Education));
            LstEducation.DataBind();
            LstEducation.SelectedIndex = 0;
        }

        protected void BtnSubmit_OnClick(object sender, EventArgs e)
        {
            //Declaring variables needed
            LblStatus.Visible = false;
            FlexiLearn___ClassLibrary.User user;
            var education = (Education) Enum.Parse(typeof(Education), LstEducation.SelectedItem.ToString());

            //Checking to see if all web controls are valid
            if (Page.IsValid)
            {
                //Checking to see if number is empty because the User object differs based on it
                if (TxtNumber.Text != "")
                {
                    LblStatus.Visible = true;
                    try
                    {
                        //Creating the user and inserting the user to database
                        user = new FlexiLearn___ClassLibrary.User(
                            TxtUserName.Text, TxtEmail.Text, education,
                            DateTime.Parse(TxtDate.Text), TxtPassword.Text,
                            TxtNumber.Text);
                        _userDao.AddRecord(user, DateTime.Today);

                        //Displaying success message
                        LblStatus.Text =
                            "User " + user.Name + " has been created!";
                    }
                    catch (Exception ex)
                    {
                        //Displaying the exception message
                        LblStatus.Text = ex.Message;
                    }
                }
                else
                {
                    LblStatus.Visible = true;
                    try
                    {
                        //Creating the user and inserting the user to database
                        user = new FlexiLearn___ClassLibrary.User(
                            TxtUserName.Text, TxtEmail.Text, education,
                            DateTime.Parse(TxtDate.Text), TxtPassword.Text);
                        _userDao.AddRecord(user, DateTime.Today);
                        //Displaying success message
                        LblStatus.Text =
                            "User " + user.Name + " has been created!";
                    }
                    catch (Exception ex)
                    {
                        //Displaying the exception message
                        LblStatus.Text = ex.Message;
                    }
                }
            }
        }

        protected void ValDateOfBirth_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            //Validating that the date of birth of user is at least 18+
            if (TxtDate.Text != "")
            {
                args.IsValid = DateTime.Parse(TxtDate.Text).Year < (DateTime.Now.Year - 18);
            }
        }

        protected void ValPassCustom_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            //Validating that the password is between 10 and 15 characters long
            if (TxtPassword.Text.Length < 10 || TxtPassword.Text.Length > 15)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}