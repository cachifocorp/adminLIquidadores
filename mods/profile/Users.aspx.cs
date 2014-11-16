using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_profile_Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SaveUser_Click(object sender, EventArgs e)
    {
        Users u = new Users();
        man_User mu = new man_User();
        man_Login log = new man_Login();

        u.Username = txtName.Value;
        u.Password = man_Login.EncodePassword(txtPassword.Value);
        u.Id_role = Convert.ToInt32(ddlRole.SelectedValue);
        u.Date_register = DateTime.Now;
        u.Id_dependence = Convert.ToInt32(ddlDependence.SelectedValue);
        u.State = 1;
         if (mu.saveUser(u)){
              Message.InnerHtml = "<p class=\"bg-success\">Información Guardada</p>";
                       // clear();
          } else {
               Message.InnerHtml = "<p class=\"bg-danger\">Error!! No se Guardo La entrada</p>";
            }
    }
}