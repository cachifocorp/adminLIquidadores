using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site_Pages_consultas_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        man_usersEPS userEps =  new man_usersEPS();

        if (userEps.login(txtnit.Value, txtPass.Value))
        {
            Response.Redirect("AsignacionEPS.aspx");
        }
        else {
            mess.Text = "La Información Ingresada es Incorrecta";
            mess.CssClass = "notification error";
        }
    }
}