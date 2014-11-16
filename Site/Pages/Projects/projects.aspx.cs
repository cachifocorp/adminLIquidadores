using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Projects_projects : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        man_Project pr = new man_Project();
        int dependence = Convert.ToInt32(Resources.Base.dependence);
        pub_featured.InnerHtml = pr.getprojectFormatbig(dependence,3,1,"../"+Resources.paths.Projects);
        prjs_p.InnerHtml = pr.getProjectFormatSmall(dependence, 4, 0, "../" + Resources.paths.Projects);
        
    }
}