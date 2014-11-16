using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Contact_Contact : System.Web.UI.Page
{
    man_genericData gn = new man_genericData();
    public dependences dpm = new dependences();
    man_dependences mdp = new man_dependences();
    private int dependence = Convert.ToInt32(Resources.Base.dependence);


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gn.cbxState(state, 1);
            dpm = mdp.getDependenceInfo(dependence);
        }

    }


    protected void saveData_Click(object sender, EventArgs e)
    {
        man_contact cont = new man_contact();
        List<contact> co = new List<contact>();
        contact c = new contact();
        
         c.Name = name.Value;
         c.Address = address.Value;
         c.Phone = phone.Value;
         c.Id_city = Convert.ToInt32(City.SelectedValue);
         c.Email = email.Value;
         c.Comment = comment.Value;
         c.Type = 1;
         c.Id_dependence = dependence;
         co.Add(c);
         if (cont.saveInfoContact(co.ToArray()))
         {
             if (cont.sendMail(c))
             {
                 label_Message.InnerHtml = "<div class=\"notification success\">" +
                                      "<p><span>Exito!</span> La información se ha enviado Correctamente.</p>" +
                                      "</div>";
             }
             else {
                 label_Message.InnerHtml = "<div class=\"notification error\">" +
                                      "<p><span>Error!</span> La información No se ha enviado. Error:" + cont.getError() +"</p>" +
                                         "</div>";
                 
             }
             clear();
         }
         else {
             Response.Write("Error el enviar la información ");
         }


    }

    protected void Contry_SelectedIndexChanged(object sender, EventArgs e)
    {
        gn.cbxState(state, Convert.ToInt32(Contry.SelectedValue));

    }

    protected void state_SelectedIndexChanged(object sender, EventArgs e)
    {
        gn.cbxCitybyState(City, Convert.ToInt32(state.SelectedValue));
    }

    private void clear()
    {
        name.Value = "";
        phone.Value = "";
        phone.Value = "";
        email.Value = "";
        comment.Value = "";
        address.Value = "";
    }
}