using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak01
{
    public partial class AdminPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            var keys = Request.Cookies.AllKeys;
            foreach(var key in keys)
            {
                HttpCookie cookie = new HttpCookie(key)
                {
                    Expires = DateTime.Now.AddDays(-1) // or any other time in the past
                };
                Response.Cookies.Add(cookie);
            }
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
}