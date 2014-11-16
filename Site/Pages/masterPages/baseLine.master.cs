using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class baseLine : System.Web.UI.MasterPage
{
    private int dependence = Convert.ToInt32(Resources.Base.dependence);
    protected void Page_Load(object sender, EventArgs e)
    {
        man_menu me = new man_menu();
        man_dependences dep = new man_dependences();
        dependences depInfo = dep.getDependenceInfo(dependence);
        MasterMenu.InnerHtml = me.getMenu(dependence, " ");

        logoDependence.InnerHtml = dep.getDependenceLogo(dependence, "../" + Resources.paths.dependences);
       // icons_dependences.InnerHtml = dep.getDependenceLogo("../"+Resources.paths.dependences);
        dep_contact.InnerHtml = dep.getContactDependences("../" + Resources.paths.dependences);

        contact_Info.InnerHtml = "AMV SA | " + depInfo.Name_city + " - " + depInfo.Address + "  |  Telefono: " + depInfo.Phone + "   |   Email: " + depInfo.Email;

    }
}
