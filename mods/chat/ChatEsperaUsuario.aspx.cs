using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_chat_RegistroUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SaveData_Click(object sender, EventArgs e)
    {

    }

    man_chat objchat = new man_chat();
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        if (!Session["idchat"].Equals(""))
        {

            if (objchat.getEstadoInicio(Session["idchat"].ToString()))
            {
                Response.Redirect("chatClient.aspx");
            }
        }
        else
        {
            Response.Redirect("RegistroUsuario.aspx");
        }
        
    }
    protected void SaveData_Click1(object sender, EventArgs e)
    {
        objchat.setCancelarChat(Session["idchat"].ToString());
        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:onBackClick();</script>");
    }
}