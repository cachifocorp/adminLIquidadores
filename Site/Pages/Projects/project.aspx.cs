using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Projects_project_All : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int dependence = Convert.ToInt32(Resources.Base.dependence);
        if (Request.QueryString["pj"] == "")
        {
            pj_post.InnerHtml = "<h2>no se encuentran datos</h2>";
        }
        else
        {
            Int32 id_project = Convert.ToInt32(Request.QueryString["pj"]);
            man_Project cli = new man_Project();
            pj_post.InnerHtml = cli.getPostProject(dependence, id_project, "../" + Resources.paths.Projects);
            post_smalpro.InnerHtml = cli.getProjectFormatSmall(dependence, 3, 1, "../" + Resources.paths.Projects);

           
        }
    }
}