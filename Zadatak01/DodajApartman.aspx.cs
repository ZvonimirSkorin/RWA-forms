using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zadatak01.DB;

namespace Zadatak01
{
    public partial class DodajApartman : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void addApartment(object sender, EventArgs e)
        {
           DBConnection.addApartment(City.Text, Address.Text, Name.Text, NameEng.Text, Price.Text, Adults.Text, RoomsCount.Text, BeachDistance.Text, Children.Text);
            Response.Redirect("/");
           
        }

    }
}