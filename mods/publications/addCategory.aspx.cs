using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_publications_projects : System.Web.UI.Page
{
    private static Users usr;
    private static profile pf;
    man_projects proj = new man_projects();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        assign();
      

    }
    public void assign()
    {
        usr = (Users)Session["User"];
        pf = (profile)Session["Profile"];
    }




   
}