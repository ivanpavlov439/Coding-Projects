/*
 * Name: Ivan Pavlov 991540069
 * Assignment 3: CourseRegistration Code
 * December 5, 2019
*/

using System;
using System.Data;
using System.Web.UI.WebControls;
using FlexiLearn___ClassLibrary;
using FlexiLearn___ClassLibrary.DAL;

namespace FlexiLearn___Ivan_Pavlov.User
{
    public partial class CourseRegistration : System.Web.UI.Page
    {
        //Declaring all objects needed
        readonly RegistrationDao _registrationDao = new RegistrationDao(Properties.Settings.Default.conString);
        readonly CourseDao _courseDao = new CourseDao(Properties.Settings.Default.conString);
        private DataTable _courseTable = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Pulling all data from course table and putting it in a DataTable
            _courseTable = _courseDao.PullData();
            if (!IsPostBack)
            {
                //Setting GridView data based off of DataTable
                GrdCourse.DataSource = _courseTable;
                GrdCourse.DataBind();
                ValidateRegistrations();
            }
        }

        protected void GrdCourse_OnSorting(object sender, GridViewSortEventArgs e)
        {
            //Sorting GridView based on column user selects
            _courseTable.DefaultView.Sort = e.SortExpression;
            GrdCourse.DataSource = _courseTable;
            GrdCourse.DataBind();
        }

        protected void BtnSubmit_OnClick(object sender, EventArgs e)
        {
            //Looping through every row in the GridView
            for (var i = 0; i < GrdCourse.Rows.Count; i++)
            {
                //Finding the template column that was manually created
                var chkCourse = (CheckBox)GrdCourse.Rows[i].FindControl("ChkCourse");

                //Checking to see if the checkbox has been checked
                if (chkCourse.Checked)
                {
                    //Creating a new Registration Request object and inserting it into the database
                    var userName = Context.User.Identity.Name;
                    var courseTitle = GrdCourse.Rows[i].Cells[0].Text;
                    var courseSubject = GrdCourse.Rows[i].Cells[1].Text;
                    var dateRegistered = DateTime.Now;
                    var request = new RegistrationRequest(userName, courseTitle, courseSubject, dateRegistered);
                    _registrationDao.AddRecord(request);
                    ValidateRegistrations();
                    LblStatus.Text = "Registrations have been saved!";
                }

            }
        }

        protected void BtnFilter_OnClick(object sender, EventArgs e)
        {
            //Declaring variables needed
            var subject = TxtFilterSubject.Text;
            var date = TxtFilterDate.Text;
            var fee = TxtFilterFee.Text;
            
            //Filtering the GridView based on the combination of TextBoxes that were typed into
            if (!subject.Equals("") && date.Equals("") && fee.Equals(""))
            {
                _courseTable.DefaultView.RowFilter = $"Subject like '%{subject}%'";
                GrdCourse.DataSource = _courseTable;
                GrdCourse.DataBind();
                ValidateRegistrations();
            }
            else if (subject.Equals("") && !date.Equals("") && fee.Equals(""))
            {
                _courseTable.DefaultView.RowFilter = $"CONVERT([StartDate], System.String) like '%{date}%'";
                GrdCourse.DataSource = _courseTable;
                GrdCourse.DataBind();
                ValidateRegistrations();
            }
            else if (subject.Equals("") && date.Equals("") && !fee.Equals(""))
            {
                _courseTable.DefaultView.RowFilter = $"CONVERT([Fee], System.String) like '%{fee}%'";
                GrdCourse.DataSource = _courseTable;
                GrdCourse.DataBind();
                ValidateRegistrations();
            }
            else if (!subject.Equals("") && !date.Equals("") && fee.Equals(""))
            {
                _courseTable.DefaultView.RowFilter = $"CONVERT([StartDate], System.String) like '%{date}%' and Subject like '%{subject}%'";
                GrdCourse.DataSource = _courseTable;
                GrdCourse.DataBind();
                ValidateRegistrations();
            }
            else if (!subject.Equals("") && date.Equals("") && !fee.Equals(""))
            {
                _courseTable.DefaultView.RowFilter = $"CONVERT([Fee], System.String) like '%{fee}%' and Subject like '%{subject}%'";
                GrdCourse.DataSource = _courseTable;
                GrdCourse.DataBind();
                ValidateRegistrations();
            }
            else if (subject.Equals("") && !date.Equals("") && !fee.Equals(""))
            {
                _courseTable.DefaultView.RowFilter = $"CONVERT([StartDate], System.String) like '%{date}%' and CONVERT([Fee], System.String) like '%{fee}%'";
                GrdCourse.DataSource = _courseTable;
                GrdCourse.DataBind(); 
                ValidateRegistrations();
            }
            else if (!subject.Equals("") && !date.Equals("") && !fee.Equals(""))
            {
                _courseTable.DefaultView.RowFilter = $"CONVERT([StartDate], System.String) like '%{date}%' and CONVERT([Fee], System.String) like '%{fee}%' and  Subject like '%{subject}%'";
                GrdCourse.DataSource = _courseTable;
                GrdCourse.DataBind();
                ValidateRegistrations();
            }
            else
            {
                GrdCourse.DataSource = _courseTable;
                GrdCourse.DataBind();
                ValidateRegistrations();
            }


        }

        protected void BtnResetFilter_OnClick(object sender, EventArgs e)
        {
            //Resetting the GridView to its default view 
            _courseTable = _courseDao.PullData();
            GrdCourse.DataSource = _courseTable;
            GrdCourse.DataBind();

            //Resetting filter boxes
            TxtFilterDate.Text = "";
            TxtFilterFee.Text = "";
            TxtFilterSubject.Text = "";

            //Calling method so user cannot register twice for the same course
            ValidateRegistrations();
        }

        /// <summary>
        /// Method that prevents user from registering for the same course twice
        /// </summary>
        protected void ValidateRegistrations()
        {
            //Creating DataTable from the registrations table within the database
            var registerTable =
                _registrationDao.PullUserData(Context.User.Identity.Name);

            //Looping through all rows in the GridView
            for (var i = 0; i < GrdCourse.Rows.Count; i++)
            {
                //Looping through all rows in the DataTable
                for (var j = 0; j < registerTable.Rows.Count; j++)
                {
                    //Getting course title from both GridView and DataTable
                    var courseTitle = registerTable.Rows[j]
                        .Field<string>("CourseTitle");
                    var gridTitle = GrdCourse.Rows[i].Cells[0].Text;

                    //Checks to see if the titles match, and if they do, prevent the user from
                    //checking the checkbox for the second time
                    if (gridTitle.Equals(courseTitle))
                    {
                        var chkCourse = (CheckBox)GrdCourse.Rows[i].FindControl("ChkCourse");
                        chkCourse.Checked = true;
                        chkCourse.Enabled = false;
                    }
                }
            }
        }
    }
}