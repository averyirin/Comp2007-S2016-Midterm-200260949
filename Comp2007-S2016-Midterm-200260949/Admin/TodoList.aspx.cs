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
                
        }
        protected void TodoSizeDropDownList_SelectedIndexChanged1(object sender, EventArgs e) {

        }

        protected void TodoGridView_RowDeleting(object sender, GridViewDeleteEventArgs e) {

        }

        protected void TodoGridView_PageIndexChanging(object sender, GridViewPageEventArgs e) {

        }

        protected void TodoGridView_Sorting(object sender, GridViewSortEventArgs e) {

        }

        protected void TodoGridView_RowDataBound(object sender, GridViewRowEventArgs e) {

        }
    }
}