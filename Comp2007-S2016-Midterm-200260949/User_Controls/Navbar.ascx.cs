using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// required for Identity and OWIN Security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
/**
 * @author: Irin Avery
 * @date: June 23, 2016
 * @version: 0.0.3 - updated SetActivePage Method to include Todo List
 */

namespace Comp2007_S2016_Midterm_200260949 {
    public partial class Navbar : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                // check if a user is logged in
                if (HttpContext.Current.User.Identity.IsAuthenticated) {

                    // show the Todo List area
                    AdminPlaceHolder.Visible = true;
                    PublicPlaceHolder.Visible = false;

                }
                else {
                    // only show login and register
                    AdminPlaceHolder.Visible = false;
                    PublicPlaceHolder.Visible = true;
                }
                SetActivePage();
            }
        }

        /**
         * This method adds a css class of "active" to list items
         * relating to the current page
         * 
         * @private
         * @method SetActivePage
         * @return {void}
         */
        private void SetActivePage() {
            switch (Page.Title) {
                case "Home Page":
                    home.Attributes.Add("class", "active");
                    break;
                case "Todo List":
                    todo.Attributes.Add("class", "active");
                    break;
                case "Login":
                    login.Attributes.Add("class", "active");
                    break;
                case "Register":
                    register.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}