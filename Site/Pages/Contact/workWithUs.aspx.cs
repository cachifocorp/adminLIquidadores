using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Contact_workWithUs : System.Web.UI.Page
{
    man_genericData gn = new man_genericData();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            gn.cbxState(state, 1);
        }
    
    }

    
    protected void saveData_Click(object sender, EventArgs e)
    {
        man_contact cont = new man_contact();
        List<contact> co = new List<contact>();
        contact c = new contact();
        if (fileDoc.HasFile)
        {
            try
            {
                String fileName = Path.GetFileName(fileDoc.FileName);
                if (fileName.Contains(".zip"))
                {
                   
                    c.Name = name.Value;
                    c.Address = address.Value;
                    c.Phone = phone.Value;
                    c.Id_city = Convert.ToInt32(City.SelectedValue);
                    c.Email = email.Value;
                    c.Id_dependence = Convert.ToInt32(Resources.Base.dependence);
                    //c.File_name = file.Value;
                    c.Comment = comment.Value;
                    c.Type = 3;
                    
                    //actions upload File
                    String newName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileName;                    
                    c.File_name = newName;
                                     
                    co.Add(c);
                    if (cont.saveInfoContact(co.ToArray())) {
                     fileDoc.SaveAs(Server.MapPath("~/Pages/uploads/jobs/") + newName);

                     if (cont.sendMail(c))
                     {
                         cont.saveInfoContact(co.ToArray());
                         label_Message.InnerHtml = "<div class=\"notification success\">" +
                                              "<p><span>Exito!</span> La información se ha enviado Correctamente.</p>" +
                                              "</div>";
                     }
                     else
                     {
                         label_Message.InnerHtml = "<div class=\"notification error\">" +
                                              "<p><span>Error!</span> La información No se ha enviado.</p>" +
                                              "</div>";
                     }
                        clear();
                    }
                    
                }
                else {                   
                    label_Message.InnerHtml = "<div class=\"notification error\">" +
                                               "<p><span>Error!</span> El formato del Archivo debe ser .zip</p>" +
                                              "</div>";
                }
            }
            catch (Exception ex)
            {
                label_Message.InnerHtml = "<div class=\"notification error\">" +
                                               "<p><span>Error!</span> Ha ocurrido un error, descripcion: " + ex.Message+"</p>" +
                                              "</div>";
            }

           
        }
        else {
            

            label_Message.InnerHtml = "<div class=\"notification error\">" +
                                               "<p><span>Error!</span> No ha seleccionado Ningun archivo para enviar</p>" +
                                              "</div>";
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

    private void clear(){
        name.Value = "";
        phone.Value = "";
        phone.Value = "";
        email.Value = "";
        comment.Value = "";
        address.Value = "";
    }

}