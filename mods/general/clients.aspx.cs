using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_general_clients : System.Web.UI.Page
{
    public static profile pf;
    public static Users usr;
    man_client clien = new man_client();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request.QueryString["action"] != null && Request.QueryString["idItem"] != null)
            {

                switch (Request.QueryString["action"])
                {
                    case "1":

                        break;

                    case "2":
                        loadDataClient(clien.getinfoCLient(Convert.ToInt32(Request.QueryString["idItem"])));
                        break;
                    case "3":
                        clien.deleteClient(Convert.ToInt32(Request.QueryString["idItem"]));
                        break;
                }
            }
        }
        assign();
       list_offices.InnerHtml = clien.TableDataOptions(Convert.ToInt32(usr.Id_dependence), usr, pf, "clients.aspx");
    }

    public void assign()
    {
        usr = (Users)Session["User"];
        pf = (profile)Session["Profile"];
    }
    protected void SaveData_Click(object sender, EventArgs e)
    {
        man_client mcli = new man_client();
        client cli = new client();

        if (flPicClient.HasFile )
        {
            try
            {
                String picClient = Path.GetFileName(flPicClient.FileName);
                //String avatar = Path.GetFileName(flavatar.FileName);
                if ((picClient.Contains(".jpg") || picClient.Contains(".JPG") || picClient.Contains(".png") || picClient.Contains(".PNG") ||
                    picClient.Contains(".gif")) )
                {
        cli.Name = txtName.Value;
        cli.Description = taDescription.Value;
        cli.Comment = "";
        cli.Id_dependence = usr.Id_dependence;
        cli.Team_name = "";
        cli.Position_company = "";

        //actions upload File
        String newNameClient = DateTime.Now.ToString("yyyyMMddHHmmss") + picClient;
        //String newNameAvatar = "avatar"+DateTime.Now.ToString("yyyyMMddHHmmss") + avatar;
        cli.Logo_client = newNameClient;
        //cli.Team_photo = newNameAvatar;
        if (mcli.saveClient(cli))
        {
           // flPicClient.SaveAs(Resources.patchDependence.uploadClients + newNameClient);
            flPicClient.SaveAs(genericFunctions.paths(usr.Id_dependence,2) + newNameClient);
           // flavatar.SaveAs(Server.MapPath(Resources.patchDependence.uploadClients) + newNameAvatar);
            Messages.InnerHtml = "<p class=\"bg-success\">Información Guardada</p>";
            Response.Redirect("clients.aspx");
            //clear();
        }
        else
        {
            Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Guardo el cliente</p>";
        }

                }
                else
                {
                    Messages.InnerHtml = "<p class=\"bg-warning\">Tipo de dato No Aceptado</p>";
                }
            }
            catch (Exception ex)
            {
                Messages.InnerHtml = "<p class=\"bg-danger\">Error! Información no guardada  error:(" + ex.Message + ")</p>";
            }
        }
                else
                {
                    Messages.InnerHtml = "<p class=\"bg-warning\">No ha seleccionado ningun archivo para enviar</p>";
                }

    }


    protected void UpdateData_Click(object sender, EventArgs e)
    {
        man_client mcli = new man_client();
        client cli = new client();

        if (flPicClient.HasFile )
        {
            try
            {
                String picClient = Path.GetFileName(flPicClient.FileName);
                //String avatar = Path.GetFileName(flavatar.FileName);
                if ((picClient.Contains(".jpg") || picClient.Contains(".JPG") || picClient.Contains(".png") || picClient.Contains(".PNG") ||
                    picClient.Contains(".gif")))
                {
                    cli.Name = txtName.Value;
                    cli.Description = taDescription.Value;
                    cli.Comment = "";
                    cli.Id_dependence = usr.Id_dependence;
                    cli.Team_name = "";
                    cli.Position_company ="";
                    cli.Id = Convert.ToInt32(Request.QueryString["idItem"]);
                    cli.State = Convert.ToInt32(chkstate.Checked);

                    String newNameClient = "";
                    String newNameAvatar = "";
                    //actions upload File
                    if (flPicClient.HasFile)
                    {
                         newNameClient = DateTime.Now.ToString("yyyyMMddHHmmss") + picClient;
                    }
                   
                  
                  
                    cli.Logo_client = newNameClient;
                    cli.Team_photo = newNameAvatar;
                    if (clien.UdateClient(cli,1))
                    {
                        if (flPicClient.HasFile)
                        {
                            flPicClient.SaveAs(Resources.patchDependence.uploadClients + newNameClient);
                        }
                        
                        Messages.InnerHtml = "<p class=\"bg-success\">Información Actualizada</p>";
                        Response.Redirect("clients.aspx");
                        //clear();
                    }
                    else
                    {
                        Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Guardo el cliente</p>";
                    }

                }
                else
                {
                    Messages.InnerHtml = "<p class=\"bg-warning\">Tipo de dato No Aceptado</p>";
                }
            }
            catch (Exception ex)
            {
                Messages.InnerHtml = "<p class=\"bg-danger\">Error! Información no guardada  error:(" + ex.Message + ")</p>";
            }
        }
        else
        {
            cli.Name = txtName.Value;
            cli.Description = taDescription.Value;
            cli.Comment = "";
            cli.Id_dependence = usr.Id_dependence;
            cli.Team_name = "";
            cli.Position_company = "";
            cli.Id = Convert.ToInt32(Request.QueryString["idItem"]);
            cli.Logo_client = "";
            cli.Team_photo = "";
            cli.State = Convert.ToInt32(chkstate.Checked);
            if (clien.UdateClient(cli,2))
            {
                Messages.InnerHtml = "<p class=\"bg-success\">Información Actualizada</p>";
                Response.Redirect("clients.aspx");
                //clear();
            }
            else
            {
                Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Actualizo el cliente</p>";
            }
        }

    }

    public void loadDataClient(client cli) {
        txtName.Value = cli.Name;
        taDescription.Value = cli.Description;
        //comment.Value = cli.Comment;
        //employerName.Value = cli.Team_name;
        //txtPosition.Value = cli.Position_company;
        updateData.Enabled = true;
        chkstate.Checked = Convert.ToBoolean(cli.State);
    }
}