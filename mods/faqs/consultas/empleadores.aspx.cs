﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site_Pages_consultas_empleadores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        man_AfiliadosAsignados masignados = new man_AfiliadosAsignados();
        if (txt_nit.Value.Length > 5)
        {
            tbl_consulta.InnerHtml = masignados.AfiliadosEmpleador(txt_nit.Value,"","","","");

        }
        else {
            Response.Write("<script>alert('Revise la información Ingresada');</script>");
        }
    }
}