using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_normatividad_Detalle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public String getTitulo()
    {
        try
        {
            return Request.Params["tipo"];
        }
        catch
        {
            return "";
        }
    }
    protected void SaveData_Click(object sender, EventArgs e)
    {

    }
}