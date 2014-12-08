using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site_Pages_consultas_EPSasignada : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        man_AfiliadosAsignados masignados = new man_AfiliadosAsignados();
        try
        {
            if (txt_nit.Value.Length > 5)
            {
                masignados.fondospensiones(txt_nit.Value, GridView1);
                GridView1.AllowPaging = true;
                if (GridView1.Rows.Count <= 0) {
                    Response.Write("<script>alert('NO Hay Información');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Revise la información Ingresada');</script>");
            }
        }catch(Exception ex){
            Response.Write("<script>alert('Ha ocurrido un error');</script>");
        }
    }
}