using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_About_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int dependence = Convert.ToInt32(Resources.Base.dependence);
        man_Publication pub = new man_Publication();
        man_client cli = new man_client();
        pub_about.InnerHtml = pub.publicationformatLarge(Convert.ToInt32(Resources.category.SobreNuestraEmpresa), dependence, 3, "../"+Resources.paths.publications, "pub.aspx");
        imageClient.InnerHtml = cli.getClientsFormatPhoto(dependence,8, "../" + Resources.paths.Clients);
        //commet_client.InnerHtml = cli.getCommentsClients(dependence, 4, "../" + Resources.paths.Clients);

    }
}