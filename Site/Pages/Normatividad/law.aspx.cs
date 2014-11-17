using System;
using System.Collections.Generic;
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

    }
}