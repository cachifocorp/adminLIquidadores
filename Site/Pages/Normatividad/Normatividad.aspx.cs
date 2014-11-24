using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_About_policies : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int dependence = Convert.ToInt32(Resources.Base.dependence);
        int tag = Convert.ToInt32(Resources.category.politicas);
        man_Publication pub = new man_Publication();
        man_client cli = new man_client();
        //post_policies.InnerHtml = pub.publicationformatLarge(tag, dependence, 3, "../"+Resources.paths.publications, "pub.aspx");
       
       // commet_client.InnerHtml = cli.getCommentsClients(dependence, 4, "../" + Resources.paths.Clients);
        if (!IsPostBack)
        {
            String where = "";
            try
            {
                where = "where tipo=" + Request.Params["Codigo"];
                if(Request.Params["Codigo"].Equals("2"))
                {
                    GridView1.Columns.RemoveAt(3);
                }
            }
            catch
            {
            }
           

            String sql = "SELECT [id], [date], [Issuingauthority], [postDate], '../../../normatividad/'+[file] as [file], [subject] FROM [regulations] "+where;
            sqlNormarividad.SelectCommand = sql;
            GridView1.DataBind();
        }


    }
    protected void saveData_Click(object sender, EventArgs e)
    {
        String where = "";
        try
        {
            where = "where tipo=" + Request.Params["Codigo"];
        }
        catch
        {
        }
        String texto=txtTexto.Value;
        if (!texto.Equals(""))
        {
            where += " and (Issuingauthority like '%" + texto + "%' or [subject] like '%"+texto+"%' or [date] like '%"+texto+"%')";
        }


        String sql = "SELECT [id], [date], [Issuingauthority], [postDate], '../../../normatividad/'+[file] as [file], [subject] FROM [regulations] " + where;
        sqlNormarividad.SelectCommand = sql;
        GridView1.DataBind();
    }
}