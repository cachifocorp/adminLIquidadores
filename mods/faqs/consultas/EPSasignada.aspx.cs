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
        if (txt_nit.Value.Length > 5)
        {
            tbl_consulta.InnerHtml = masignados.Afiliadostabla(txt_nit.Value,"","","","");

        }
        else
        {
            Response.Write("<script>alert('Revise la información Ingresada');</script>");
        }
    }

    protected void btnByName_Click(Object sender, EventArgs e) {
        man_AfiliadosAsignados masignados = new man_AfiliadosAsignados();
        
            tbl_consulta.InnerHtml = masignados.Afiliadostabla(txt_nit.Value, txtnom1.Value, txtnom2.Value, txtnom3.Value, txtnom4.Value);
            //tablaInfo.AutoGenerateColumns = false;
            //masignados.AfiliacionEmpleadorGrid(txt_nit.Value, tablaInfo, txtnom1.Value, txtnom2.Value, txtnom3.Value, txtnom4.Value);
            

    }
}