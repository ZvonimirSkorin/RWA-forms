using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zadatak01.DB;

namespace Zadatak01
{
    public partial class Tagovi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var tagovi = DBConnection.getAllTags();
                var tagTypes = DBConnection.getAllTagTypes();
                selectTagType.DataSource = tagTypes;
                Tags.DataSource = tagovi;
                selectTagType.DataTextField = "Name";
                selectTagType.DataValueField = "Id";
                Tags.DataBind();
                selectTagType.DataBind();
            }
        }

      

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            DBConnection.deleteTag((string)e.CommandArgument);

            Response.Redirect("/tagovi");

        }

        protected void Add_tag(object sender, EventArgs e)
        {
            
            DBConnection.addTag(selectTagType.SelectedValue.ToString(), newTagName.Text);
        }
    }
}