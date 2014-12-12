using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_chat_chat : System.Web.UI.Page
{
    man_chat objchat = new man_chat();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                Session["idchatadmin"] = Request.Params["idchat"];

                if (Request.Params["accion"].ToString().Equals("1"))
                {
                    objchat.setIniciarChat(Session["idchatadmin"].ToString());
                }
                
            }
            catch
            {

            }
        }
    }
    protected void SaveData_Click1(object sender, EventArgs e)
    {
        objchat.setSalirChat(Session["idchatadmin"].ToString());
        Response.Redirect("detallehistorial.aspx");
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        String[] vr = objchat.getMensajeschat(Session["idchatadmin"].ToString());
        if (vr[1].Equals("3") || vr[1].Equals("4"))
        {
            Session["idchatadmin"] = "";
            Response.Redirect("MensajeAdmin.aspx");
        }
        ContentChat.InnerHtml = vr[0];

       
    }
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        objchat.setChat(txtMensaje.Text, "", "1", Session["idchatadmin"].ToString());
        Timer1_Tick(sender, e);
        txtMensaje.Text = "";
    }


}