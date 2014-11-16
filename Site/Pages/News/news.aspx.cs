using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_News_new : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        man_Publication pub = new man_Publication();
        int dependence = Convert.ToInt32(Resources.Base.dependence);
        int cat = Convert.ToInt32(Resources.category.Noticia);
        if (!IsPostBack)
        {
            if (Request.QueryString["page"] == null || Request.QueryString["page"] == "1")
            {
                nextPage.InnerHtml = "<li><a href=\"news.aspx?page=2\" class=\"selected\">></a></li>";
                news_Pub.InnerHtml = pub.getNews(cat, dependence, 10, 1, "../"+Resources.paths.publications, "pub.aspx", 0);
                news_slider.InnerHtml = pub.getSliderNews(cat, dependence, 5, "../"+Resources.paths.publications, "pub.aspx", 0);
            }
            else
            {
                int page = Convert.ToInt32(Request.QueryString["page"]);
                if (pub.getNews(cat, dependence, 10, page, "../" + Resources.paths.publications, "pub.aspx", 0).Length <= 0)
                {
                    nextPage.InnerHtml = "<li><a href=\"news.aspx?page=" + (page - 1) + "\" class=\"selected\"><</a></li>";
                    news_Pub.InnerHtml = pub.getNews(cat, dependence, 10, page, "../" + Resources.paths.publications, "pub.aspx", 0);
                    news_slider.InnerHtml = pub.getSliderNews(cat, dependence, 5, "../" + Resources.paths.publications, "pub.aspx", 0);

                }
                else
                {

                    nextPage.InnerHtml = "<li><a href=\"news.aspx?page=" + (page - 1) + "\" class=\"selected\"><</a></li>" +
                                         "<li><a href=\"news.aspx?page=" + (page + 1) + "\" class=\"selected\">></a></li>";
                    news_Pub.InnerHtml = pub.getNews(1, dependence, 10, page, "../" + Resources.paths.publications, "pub.aspx", 0);
                    news_slider.InnerHtml = pub.getSliderNews(cat, dependence, 5, "../" + Resources.paths.publications, "pub.aspx", 0);

                }
            }
        }
        
    }
}