using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Products_Services : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int dependence = Convert.ToInt32(Resources.Base.dependence);
        int cat = Convert.ToInt32(Resources.category.servicios);
        man_Publication pub = new man_Publication();
        man_client cli = new man_client();
        pub_products.InnerHtml = pub.publicationformatLarge(cat, dependence, 8, "../"+Resources.paths.publications, "pub.aspx");
        imageClient.InnerHtml = cli.getClientsFormatPhoto(dependence, 8, "../" + Resources.paths.Clients);
        //commet_client.InnerHtml = cli.getCommentsClients(dependence, 4, "../" + Resources.paths.Clients);
    }
}