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
        String [] p = pub.getArticle(dependence,idp,"../src/images/large/");
        image_pub.InnerHtml = p[0];
        languages.InnerHtml = p[1];
        description_pub.InnerHtml = p[2];
        client_comment.InnerHtml = cli.getCommentsClients(dependence, 3, "../src/images/team/");
        client_photo.InnerHtml = cli.getClientsFormatPhoto(dependence, 3, "../src/images/clients/");
    }
}