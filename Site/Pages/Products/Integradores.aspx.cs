using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Products_Integradores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        man_integrators inte = new man_integrators();


        int dependence = Convert.ToInt32(Resources.Base.dependence);
        int cat = Convert.ToInt32(Resources.category.Noticia);

        if (!IsPostBack) {
            if (Request.QueryString["page"] == null || Request.QueryString["page"] == "1")
            {
                nextPage.InnerHtml = "<li><a href=\"integradores.aspx?page=2\" class=\"selected\">></a></li>";
                pub_integrators.InnerHtml = inte.getIntegrators(dependence, 1, 6);
            }
            else {
                int page = Convert.ToInt32(Request.QueryString["page"]);
                if (inte.getIntegrators(dependence, page + 1, 6).Length <= 0)
                {
                    nextPage.InnerHtml = "<li><a href=\"integradores.aspx?page=" + (page-1) + "\" class=\"selected\"><</a></li>";
                    pub_integrators.InnerHtml = inte.getIntegrators(dependence, page, 6);

                }
                else
                {
                    
                    nextPage.InnerHtml = "<li><a href=\"integradores.aspx?page=" + (page -1) + "\" class=\"selected\"><</a></li>" +
                                         "<li><a href=\"integradores.aspx?page=" + (page + 1) + "\" class=\"selected\">></a></li>";
                    pub_integrators.InnerHtml = inte.getIntegrators(dependence, page, 6);
                }
            }
        }
    }
}