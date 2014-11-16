using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_About_certifications : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        man_Publication pub = new man_Publication();
        pub_certification.InnerHtml = pub.publicationformatLarge(Convert.ToInt32(Resources.category.certificaciones), Convert.ToInt32(Resources.Base.dependence), 5, "../"+Resources.paths.publications,"pub.aspx");
    }
}