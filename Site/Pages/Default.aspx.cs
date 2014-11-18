using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Default : System.Web.UI.Page
{

    private int dep = Convert.ToInt32(Resources.Base.dependence);
    protected void Page_Load(object sender, EventArgs e)
    {
       
        man_Publication man_pub = new man_Publication();
        man_client  man_cli = new man_client();
        man_menu me = new man_menu();
        man_slider sli = new man_slider();
        me.getMenu(dep, "../");
        Sliders.InnerHtml = sli.formatedSlider(dep);
        news_index.InnerHtml = man_pub.publicationShort(1, dep, 2, "pub.aspx");
        services_index.InnerHtml = man_pub.publicationformatLarge(2, dep, 3, Resources.paths.services, "pub.aspx");
        //comments_Clients_index.InnerHtml = man_cli.getCommentsClients(dep, 4,Resources.paths.Clients);
        //client_photo.InnerHtml = man_cli.getClientsFormatPhoto(dep, 8, Resources.paths.Clients);
        

    }


   




   
}