using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site_Pages_faqs_faqs : System.Web.UI.Page
{
    man_faqs mfaq = new man_faqs();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack){
            int faqs = Convert.ToInt32(Request.QueryString["tipo"]);
            itemsFaqs.InnerHtml = mfaq.faqsFormat(faqs);
        }
        

    }
}