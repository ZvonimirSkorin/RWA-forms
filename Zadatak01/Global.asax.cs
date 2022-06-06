using Autentifikacija;
using rwaLib.Dal;
using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Zadatak01
{
    public class Global : System.Web.HttpApplication
    {
        private readonly IRepo _repo;

        public Global()
        {
            _repo = RepoFactory.GetRepo();
        }

        void ClearTokens()
        {
            var keys = Request.Cookies.AllKeys;
            foreach (var key in keys)
            {
                HttpCookie cookie = new HttpCookie(key)
                {
                    Expires = DateTime.Now.AddDays(-1) // or any other time in the past
                };
                Response.Cookies.Add(cookie);
            }
            Response.Redirect("Default.aspx");
        }

        void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "Apartman",
                "Apartman/{id}",
                "~/Apartman.aspx"
            );
           
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["database"] = _repo;
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
            if (Request.Cookies["lang"] != null)
            {
                if (Request.Cookies["lang"]["lang"] != null)
                {
                    string culture = Request.Cookies["lang"]["lang"];
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
                }
            }
           

            if(Request.Url.LocalPath != "/Default")
            {
                if (Request.Cookies["Token"] == null)
                {
                    Response.Redirect("/Default");
                }else
                {
                    try
                    {
                        if (!JwtAuthenticationManager.validateToken(Request.Cookies["Token"].Value))
                        {
                            ClearTokens();
                        }
                    }
                    catch(Exception ex)
                    {
                        ClearTokens();
                    }
                }
            }
            
        }


    }
}