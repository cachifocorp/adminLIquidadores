using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_chat_chatClient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    man_chat objchat = new man_chat();

    protected void SaveData_Click1(object sender, EventArgs e)
    {
        objchat.setSalirChat(Session["idchat"].ToString());
        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:onBackClick();</script>");
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {

       ContentChat.InnerHtml= objchat.getMensajeschat(Session["idchat"].ToString());
    }
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        objchat.setChat(txtMensaje.Text, Session["iduserchat"].ToString(), "", Session["idchat"].ToString());
        txtMensaje.Text = "";
        Timer1_Tick(sender, e);
    }
}