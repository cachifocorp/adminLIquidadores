using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_About_pub : System.Web.UI.Page
{
    private int dependence = Convert.ToInt32(Resources.Base.dependence);
    protected void Page_Load(object sender, EventArgs e)
    {
        man_Publication pub = new man_Publication();
        man_client cli = new man_client();

        int idp = Convert.ToInt32(Request.QueryString["idp"]);
        String [] p = pub.getArticle(dependence,idp,Resources.paths.services);
        image_pub.InnerHtml = p[0];
        languages.InnerHtml = p[1];
        description_pub.InnerHtml = p[2];
        //client_comment.InnerHtml = cli.getCommentsClients(Convert.ToInt32(Resources.Base.dependence), 4, Resources.paths.Clients);
        //client_photo.InnerHtml = cli.getClientsFormatPhoto(dependence, 8, Resources.paths.Clients);
    }
}