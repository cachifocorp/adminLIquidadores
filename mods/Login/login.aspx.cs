using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_Login_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btn_Login_Click(object sender, EventArgs e)
    {
        if (txt_username.Value != "" || txt_password.Value != "")
        {
            if (man_Login.login(txt_username.Value, txt_password.Value))
            {
                Users u = (Users) Session["User"];               
                profile pro = man_Login.getInfoprofile(u);
                Session["Profile"] = pro;
                Response.Redirect("../Default.aspx");
            }
            else
            {
                messages.InnerHtml = "<p class=\"bg-danger\"><span>Error!</span> El usuario y/o contraseña  que ingresaste no coinciden</p></p>";
                
            }
        }
        else
        {
            messages.InnerHtml = "<p class=\"bg-warning\"><span>Error!</span> Hay Campos Vacios en el formulario</p>";
        }
    }
}