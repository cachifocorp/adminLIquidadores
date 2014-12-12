using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_chat_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SaveData_Click(object sender, EventArgs e)
    {
        man_chat obj = new man_chat();
        String[] vr = obj.setClienteChat(txtNombre.Value, txtCorreo.Value);
        Session["idchat"] = vr[0];
        Session["iduserchat"] = vr[1];
        Response.Redirect("ChatEsperaUsuario.aspx");

    }
}