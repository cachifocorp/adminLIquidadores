using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_chat_detallehistorial : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public String getConversacion()
    {
        try
        {
            String iduser = Request.Params["iduser"];
            man_chat obj = new man_chat();
            return obj.getConversacion(iduser);
        }
        catch
        {
            return "";
        }
    }
}