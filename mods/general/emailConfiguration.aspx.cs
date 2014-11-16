using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_general_emailConfiguration : System.Web.UI.Page
{
    public static profile pf;
    public static Users usr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) {
            assign();
        }

    }

    public void assign()
    {
        usr = (Users)Session["User"];
        pf = (profile)Session["Profile"];
    }
    protected void SaveData_Click(object sender, EventArgs e)
    {
        clsDb db = new clsDb();

        if (db.ejecutar("INSERT INTO [dbo].[emailcontact]([id_dependence],[email],[type]) VALUES(" + usr.Id_dependence + ",'" + txtName.Value + "'," + ddltipo.SelectedValue + ")"))
        {
            Response.Write("<script>alert('correo registrado'); document.location.href='emailConfiguration.aspx'</script>");
        }
        else {
            Response.Write("<script>alert('Ha ocurrodo in erro al registrar el correo');</script>");
        }
    }
}