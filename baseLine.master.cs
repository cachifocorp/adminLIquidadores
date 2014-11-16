using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class baseLine : System.Web.UI.MasterPage
{
     
    protected void Page_Load(object sender, EventArgs e)
    {
        man_menu me = new man_menu();
        man_dependences dep = new man_dependences();
        
        MasterMenu.InnerHtml = me.getMenuAdmin(1, " ");

        //logoDependence.InnerHtml = dep.getDependenceLogo(3, "Modules/src/images/");
        //icons_dependences.InnerHtml = dep.getDependenceLogo("Modules/src/img/LogosAMV/InvertedLogos/");
       
        if (!IsPostBack)
        {
            if (Session["User"] != null)
            {
                Users u = (Users)Session["User"];
                config_holder.InnerHtml = "<div id=\"menu_config\">" +
                    "<div class=\"config_style_text\">" + u.Username + "</div>" +
                    "<div class=\"config_slider\"><img src=\"Modules/src/images/comment/1.jpg\" height=\"60\" width=\"60\" alt=\"\"></div>" +
                    "<ul>" +
                        "<li class=\"config\">Ver Perfil</li>" +
                        "<li class=\"switch_style\"  ><a href=\"#\">Editar Perfil</a></li>" +
                        "<li class=\"switch_style\" ><a href=\"#\">Cerrar Sesión</a></li>" +
                    "</ul>" +
                "</div>";
            }
            else {
                Response.Redirect("mods/Login/Login.aspx");
            }
        }
    }
}
