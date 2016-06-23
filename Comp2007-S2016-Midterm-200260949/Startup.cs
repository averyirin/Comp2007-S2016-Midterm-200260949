using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

// required for authentication and authorization
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
[assembly: OwinStartup(typeof(Comp2007_S2016_Midterm_200260949.Startup))]

namespace Comp2007_S2016_Midterm_200260949 {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login.aspx")
            });
        }
    }
    
}
