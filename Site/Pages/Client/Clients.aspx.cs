using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Client_Clients : System.Web.UI.Page
{
    private int dependence = Convert.ToInt32(Resources.Base.dependence);
    protected void Page_Load(object sender, EventArgs e)
    {
        man_client cli = new man_client();
        String clie = "<li class=\"b_wrapper span6\" style=\"text-align:center; width: 460px;\"><div class=\"home_b_holder_wrapper\"><div class=\"home_b_holder\"><img src=\"../uploads/Clients/20140604022831Logo Marval.jpg\" height=\"81\" width=\"128\" alt=\"\" class=\"hoverZoomLink\"><span class=\"clear\"></span></div><div class=\"clear\"></div></div></li>";
        clie+=cli.getClientsFormatMedium(dependence, 21, "../"+Resources.paths.Clients);
        clients_pub.InnerHtml = clie;
    }
}