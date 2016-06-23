using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// required for Identity and Security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace Comp2007_S2016_Midterm_200260949 {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void LoginButton_Click(object sender, EventArgs e) {
            // create userStore and userManager objects
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            // create the user object
            var user = userManager.Find(UserNameTextBox.Text, PasswordTextBox.Text);

            // if we have match - both username and password
            if (user != null) {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                // sign in the authenticated user
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                // Redirect the user the Todo List
                Response.Redirect("~/Admin/TodoList.aspx");

            }
            else {
                StatusLabel.Text = "Invalid Username or Password";
                AlertFlash.Visible = true;
            }
        }
    }
}