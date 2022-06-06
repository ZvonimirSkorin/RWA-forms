using Autentifikacija;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zadatak01.DB;
using Zadatak01.Model;

namespace Zadatak01
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        void Selection_Change(Object sender, EventArgs e)
        {

            // Set the background color for days in the Calendar control
            // based on the value selected by the user from the 
            // DropDownList control.

        }

        protected void loadCities()
        {
            var cities = DBConnection.getCities();
            DataRow workRow = cities.NewRow();
            workRow["City"] = "Svi";
            cities.Rows.InsertAt(workRow, 0);
            selectCty.DataSource = cities;

            selectCty.DataTextField = "City";
            selectCty.DataValueField = "City";

            selectStatus.Items.Add(new System.Web.UI.WebControls.ListItem("Nebitno", "-1"));
            selectStatus.Items.Add(new System.Web.UI.WebControls.ListItem("Zauzeto", "0"));
            selectStatus.Items.Add(new System.Web.UI.WebControls.ListItem("Rezervirano", "1"));
            selectStatus.Items.Add(new System.Web.UI.WebControls.ListItem("Slobodno", "2"));
           
            
            


        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["Token"] != null)
                try {
                    if (!IsPostBack)
                    {
                        loadCities();
                    }
                    string sortBy = "Price A";
                    string selectedCity = selectCty.SelectedValue.ToString();
                    string selectedParam = selectStatus.SelectedValue.ToString();
                    string city = IsPostBack && selectedCity !="Svi"? selectedCity : null;
                    IList<Apartment> apartmants = DBConnection.getAparments(sortBy, city).AsEnumerable().Select(row=>new Apartment {
                        Name = row.Field<string>("Name"), Address = row.Field<string>("Address"), BeachDistance = row.Field<int>("BeachDistance"),
                        Price= row.Field<decimal>("Price"), City= row.Field<string>("City"), Id= row.Field<int>("id"), MaxAdults= row.Field<int>("MaxAdults"),
                         MaxChildren= row.Field<int>("MaxChildren"), NameEng = row.Field<string>("NameEng"), Owner = row.Field<int>("OwnerId"),
                          Status = row.Field<int>("StatusId"), TotalRooms = row.Field<int>("TotalRooms")
                    }).ToList();
                    
                    
                    Repeater1.DataSource = selectedParam=="-1"? apartmants:
                        apartmants.Select(v => v)
                        .Where(v => v.Status == int.Parse(selectedParam)).ToList();
                    

                    // Data binding podataka na kontrolu
                    selectCty.DataBind();
                    Repeater1.DataBind();

                    selectStatus.SelectedValue = selectedParam;
                }
                catch(Exception ex)
                {
                    Response.Write(ex.Message);
                }
            else Response.Redirect("/");
           
        }
        
    }
}