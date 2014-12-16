using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site_Pages_consultas_reporte_certificado : System.Web.UI.Page
{
    public AfiliadosAsignados[] afi;
    protected void Page_Load(object sender, EventArgs e)
    {
         afi = new man_AfiliadosAsignados().getAfiliado(Request.QueryString["id"], "");
    }
}