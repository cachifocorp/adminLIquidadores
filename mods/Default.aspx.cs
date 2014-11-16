using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_Default : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        man_menu menu = new man_menu();
       

        if (!IsPostBack)
        {
            if (Session["User"] != null)
            {
                Users u = (Users)Session["User"];
                profile pr = (profile)Session["Profile"];
                menuAdmin.InnerHtml = menu.getMenuAdmin(pr.Id, " ");
                adminName.InnerHtml = pr.Name;
                //admin_avatar.InnerHtml = "<img src=\""+Resources.Resource.PathAvatar+pr.Avatar+"\" class=\"img-rounded\" alt=\"avatar\" />";
            }
            else
            {
                Response.Redirect("Login/Login.aspx");
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
}