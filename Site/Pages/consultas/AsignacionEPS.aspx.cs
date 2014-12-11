using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site_Pages_consultas_EPSasignada : System.Web.UI.Page
{
    man_AfiliadosAsignados masignados = new man_AfiliadosAsignados();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
         String SQL = "SELECT[DepCod],[DepNom]  FROM [DEPARTAM]";
        masignados.ddlData(cbxDep, SQL, "DepCod", "DepNom");

        }
        //  masignados.certificadoList(txt_nit.Value, gridData);

       
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if (Session["epscode"] != null)
        {
            //hell.Text = Session["epscode"].ToString();//+ " 1-2 " + cbxtipo.SelectedValue + " -3 " + txtIden.Value + " -4 " + cbxDep.SelectedValue + " -5 " + cbxMun.SelectedValue;
            masignados.gridDataAsignacionEps(gridData, Session["epscode"].ToString(), cbxtipo.SelectedValue, txtIden.Value, cbxDep.SelectedValue, cbxMun.SelectedValue);
           
        }
        else {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }

    protected void cbxDep_SelectedIndexChanged(object sender, EventArgs e)
    {
        String SQL = "SELECT  [MunCod],[MunNom] "+
                     " FROM [MUNICIPI]  where depCod = '"+cbxDep.SelectedValue+"'";
        masignados.ddlData(cbxMun, SQL, "MunCod", "MunNom");
    }
    protected void btnCloseSS_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }
}