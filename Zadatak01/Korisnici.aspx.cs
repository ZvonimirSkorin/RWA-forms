using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zadatak01.DB;

namespace Zadatak01
{
    public partial class Korisnici : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Token"] != null)
            {
                var users = DBConnection.GetUsers();
                Repeater1.DataSource = users;
                Repeater1.DataBind();
            }
            else Response.Redirect("/");

        }
    }
}