using rwaLib.Dal;
using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak01
{
    public partial class Default : DefaultPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PanelForma.Visible = true;
                PanelIspis.Visible = false;
            }
            var token = Request.Cookies["token"];
            if ( token != null)
            {
                try
                {
                    if (Autentifikacija.JwtAuthenticationManager.validateToken(token.Value))
                    {
                        Session["user"] = token.Value;
                        Response.Redirect("Apartmani.aspx");
                    }
                }
                catch(Exception ex)
                {

                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var username = txtUsername.Text;
                var password = txtPassword.Text;

                IList<User> users = ((IRepo)Application["database"]).LoadUsers();

                // LINQ
                var user = Autentifikacija.JwtAuthenticationManager.Authenticate(username, password);

                if (user == null)
                {
                    PanelIspis.Visible = true;
                    PanelForma.Visible = true;
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    
                    
                }
                else
                {
                    Session["user"] = user;
                    HttpCookie cookie = new HttpCookie("Token")
                    {
                        Value = user, // Upload is an asp:FileUpload control name for uploading image
                        Expires = DateTime.Now.AddMinutes(10)
                    };
                    Response.SetCookie(cookie);
                    Response.Redirect("Apartmani.aspx");
                }
            }
        }
    }
}