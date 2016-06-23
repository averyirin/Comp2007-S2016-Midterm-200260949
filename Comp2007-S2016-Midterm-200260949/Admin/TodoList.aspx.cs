using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// using statements that are required to connect to EF DB
using Comp2007_S2016_Midterm_200260949.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace Comp2007_S2016_Midterm_200260949 {
    public partial class TodoList : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            // if loading the page for the first time, populate the todo list
            if (!IsPostBack) {
                Session["SortColumn"] = "TodoName"; // default sort column
                Session["SortDirection"] = "ASC";
                // Get the todo data
                this.GetTodoList();
            }
        }
       protected void GetTodoList() {
            using (TodoConnection db = new TodoConnection()) {
                string SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                // query the Students Table using EF and LINQ
                var Todos = (from allTodos in db.Todos
                                select allTodos);

                // bind the result to the GridView
                TodoGridView.DataSource = Todos.AsQueryable().OrderBy(SortString).ToList();
                TodoGridView.DataBind();
                //display the total count of the list
                TodoCount.Text = Todos.AsQueryable().OrderBy(SortString).ToList().Count.ToString();
            }
        }
        protected void TodoGridView_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get the selected StudentID using the Grid's DataKey collection
            int TodoID = Convert.ToInt32(TodoGridView.DataKeys[selectedRow].Values["TodoID"]);

            // use EF to find the selected student in the DB and remove it
            using (TodoConnection db = new TodoConnection()) {
                // create object of the Student class and store the query string inside of it
                Todo deletedTodo = (from todoRecords in db.Todos
                                          where todoRecords.TodoID == TodoID
                                          select todoRecords).FirstOrDefault();

                // remove the selected student from the db
                db.Todos.Remove(deletedTodo);

                // save my changes back to the database
                db.SaveChanges();

                // refresh the grid
                this.GetTodoList();
            }
        }

        protected void TodoGridView_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            // Set the new page number
            TodoGridView.PageIndex = e.NewPageIndex;

            // refresh the grid
            this.GetTodoList();
        }

        protected void TodoGridView_Sorting(object sender, GridViewSortEventArgs e) {
            // get the column to sorty by
            Session["SortColumn"] = e.SortExpression;

            // Refresh the Grid
            this.GetTodoList();

            // toggle the direction
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }

        protected void TodoGridView_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (IsPostBack) {
                if (e.Row.RowType == DataControlRowType.Header) // if header row has been clicked
                {
                    LinkButton linkbutton = new LinkButton();

                    for (int index = 0; index < TodoGridView.Columns.Count - 1; index++) {
                        if (TodoGridView.Columns[index].SortExpression == Session["SortColumn"].ToString()) {
                            if (Session["SortDirection"].ToString() == "ASC") {
                                linkbutton.Text = " <i class='fa fa-caret-up fa-lg'></i>";
                            }
                            else {
                                linkbutton.Text = " <i class='fa fa-caret-down fa-lg'></i>";
                            }

                            e.Row.Cells[index].Controls.Add(linkbutton);
                        }
                    }
                }
            }
        }

        protected void TodoSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e) {
            // Set the new Page size
            TodoGridView.PageSize = Convert.ToInt32(TodoSizeDropDownList.SelectedValue);

            // refresh the grid
            this.GetTodoList();
        }
    }
}