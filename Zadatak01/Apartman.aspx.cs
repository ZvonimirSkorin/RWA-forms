using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zadatak01.DB;

namespace Zadatak01
{
    public partial class Apartman : System.Web.UI.Page
    {
        string host = HttpContext.Current.Request.Url.Query;

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = System.Web.HttpUtility.ParseQueryString(host).Get("id");
            if(id == null)
            {
                Response.Redirect("/");
            }
            if (!IsPostBack)
            {
                var apartman = DBConnection.getAparment(id);
                var slike = DBConnection.getImages(id);
                var tags = DBConnection.getTags(id);
                RepeaterImages.DataSource = slike;
                Repeater.DataSource = apartman;
                RepeaterTags.DataSource = tags;
                RepeaterImages.DataBind();
                Repeater.DataBind();
                RepeaterTags.DataBind();
            }
        }

        protected void Update_Apartment(object sender, EventArgs e)
        {

            var id = System.Web.HttpUtility.ParseQueryString(host).Get("id");
            foreach (RepeaterItem RI in Repeater.Items)
            {
                TextBox BeachDistance = RI.FindControl("BeachDistance") as TextBox;
                TextBox Status = RI.FindControl("Status") as TextBox;
                TextBox NumberOfAdults = RI.FindControl("NumberOfAdults") as TextBox;
                TextBox NumberOfChildren= RI.FindControl("NumberOfChildren") as TextBox;
                TextBox NumberOfRooms= RI.FindControl("NumberOfRooms") as TextBox;
                TextBox Address = RI.FindControl("Address") as TextBox;
                TextBox Price= RI.FindControl("Price") as TextBox;
                DBConnection.updateAparment(BeachDistance.Text, Status.Text, NumberOfAdults.Text, NumberOfChildren.Text, NumberOfRooms.Text, Address.Text, Price.Text,
                    Int16.Parse(id));
            }
            Response.Redirect("/");
        }
        protected void deleteApartment(object sender, EventArgs e)
        {
            var id = System.Web.HttpUtility.ParseQueryString(host).Get("id");
            DBConnection.deleteApartment(Int16.Parse(id));
            Response.Redirect("/");
        }
        protected void addTag(object sender, EventArgs e)
        {
            var id = System.Web.HttpUtility.ParseQueryString(host).Get("id");
            DBConnection.deleteApartment(Int16.Parse(id));
            Response.Redirect("/");
        }

        protected void deleteTag(object sender, EventArgs e)
        {
            string status = HiddenField1.Value.ToString();
            var id = System.Web.HttpUtility.ParseQueryString(host).Get("id");
            DBConnection.deleteApartmantTag(Int16.Parse(id), status);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}