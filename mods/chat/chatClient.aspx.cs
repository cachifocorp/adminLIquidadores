using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_chat_Client : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["idchat"].ToString().Equals(""))
        {
            Response.Redirect("RegistroUsuario.aspx");
        }
    }
    man_chat objchat = new man_chat();

    protected void SaveData_Click1(object sender, EventArgs e)
    {
        objchat.setSalirChat(Session["idchat"].ToString());
        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:onBackClick();</script>");
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        String[] vr=objchat.getMensajeschat(Session["idchat"].ToString());
        if (vr[1].Equals("3") || vr[1].Equals("4"))
        {
            Session["idchat"] = "";
            Response.Redirect("MensajeCliente.aspx");
            
            
        }
        ContentChat.InnerHtml = vr[0];
    }
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        objchat.setChat(txtMensaje.Text, Session["iduserchat"].ToString(), "", Session["idchat"].ToString());
        txtMensaje.Text = "";
        Timer1_Tick(sender, e);
    }
}