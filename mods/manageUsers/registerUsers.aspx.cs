using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_mangeUsers_registerUsers : System.Web.UI.Page
{
    private static Users usr;
    private static profile pf;
    man_User mUs = new man_User();
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

                        loadDataFields(mUs.getInfoUser(Convert.ToInt32(Request.QueryString["idItem"])));
                        break;
                    case "3":
                        mUs.DeleteUser(Convert.ToInt32(Request.QueryString["idItem"]));
                        break;
                }
            }
        }
        assign();
        int defaultSatate = 1;
        list_Users.InnerHtml =  mUs.TableDataOptions(defaultSatate, usr, pf, "registerUsers.aspx");
    }

    public void assign()
    {
        usr = (Users)Session["User"];
        pf = (profile)Session["Profile"];
    }
    
    protected void SaveData_Click(object sender, EventArgs e)
    {
        if (txtPassword.Value == txtRepeatPassword.Value)
        {
            if (txtUsername.Value.Length > 4)
            {
                Users us = new Users();
                us.Username = txtUsername.Value;
                us.Password = man_Login.EncodePassword(txtPassword.Value);
                us.Id_dependence = Convert.ToInt32(ddlDependence.SelectedValue);
                us.Id_role = Convert.ToInt32(ddlRole.SelectedValue);
                us.State = Convert.ToInt32(chkState.Checked);
                if (mUs.saveUser(us))
                {
                    Messages.InnerHtml = "<p class=\"bg-warning\">UsuarioRegistrado Correctamente <br> El usuario Tendra que logearse para  registrar los datos de su perfil </p>";
                }
                else {
                    Messages.InnerHtml = "<p class=\"bg-susses\">Ups! ha ocurrido un error  al guardar la informacion  el usuario NO se ha creado </p>"; 
                }
            }
            else {
                Messages.InnerHtml = "<p class=\"bg-warning\">Nombre de usuario muy corto</p>"; 
            }
        }
        else {
            Messages.InnerHtml = "<p class=\"bg-warning\">Las Contraceñas no coninciden</p>"; 
        }
    }
    protected void UpdateData_Click(object sender, EventArgs e)
    {
        if (txtPassword.Value.Length > 4)
        {
            if (txtPassword.Value == txtRepeatPassword.Value)
            {
                if (txtUsername.Value.Length > 4)
                {
                    Users us = new Users();
                    us.Username = txtUsername.Value;
                    us.Password = man_Login.EncodePassword(txtPassword.Value);
                    us.Id_dependence = Convert.ToInt32(ddlDependence.SelectedValue);
                    us.Id_role = Convert.ToInt32(ddlRole.SelectedValue);
                    us.State = Convert.ToInt32(chkState.Checked);
                    us.Id = Convert.ToInt32(Request.QueryString["idItem"]);
                    if (mUs.updateUser(us))
                    {
                        Messages.InnerHtml = "<p class=\"bg-warning\">El Usuario se ha actualizado </p>";
                        SaveData.Enabled = true;
                        UpdateData.Enabled = false;
                    }
                    else
                    {
                        Messages.InnerHtml = "<p class=\"bg-susses\">Ups! ha ocurrido un error  al guardar la informacion  el usuario NO se ha creado </p>";
                    }
                }
                else
                {
                    Messages.InnerHtml = "<p class=\"bg-warning\">Nombre de usuario muy corto</p>";
                }
            }
            else
            {
                Messages.InnerHtml = "<p class=\"bg-warning\">Las Contraceñas no coninciden</p>";
            }
        }
        else {
            if (txtUsername.Value.Length > 4)
            {
                Users us = new Users();
                us.Username = txtUsername.Value;
                us.Id_dependence = Convert.ToInt32(ddlDependence.SelectedValue);
                us.Id_role = Convert.ToInt32(ddlRole.SelectedValue);
                us.State = Convert.ToInt32(chkState.Checked);
                us.Id = Convert.ToInt32(Request.QueryString["idItem"]);
                if (mUs.updateUserwhidoutPass(us))
                {
                    Messages.InnerHtml = "<p class=\"bg-warning\">El Usuario se ha actualizado d </p>";
                    SaveData.Enabled = true;
                    UpdateData.Enabled = false;
                }
                else
                {
                    Messages.InnerHtml = "<p class=\"bg-susses\">Ups! ha ocurrido un error  al guardar la informacion  el usuario NO se ha creado </p>";
                }
            }
            else
            {
                Messages.InnerHtml = "<p class=\"bg-warning\">Nombre de usuario muy corto</p>";
            }
            
        }
    }
    protected void showActive_CheckedChanged(object sender, EventArgs e)
    {
        int defaultSatate = Convert.ToInt32(showActive.Checked);
        list_Users.InnerHtml = mUs.TableDataOptions(defaultSatate, usr, pf, "registerUsers.aspx");
    }


    private void loadDataFields( Users user ) {
        txtUsername.Value = user.Username;
        ddlDependence.DataBind();
        SetDDLsValue(ddlDependence, user.Id_dependence.ToString());
        ddlRole.DataBind();
        SetDDLsValue(ddlRole,  user.Id_role.ToString());
        chkState.Checked = Convert.ToBoolean(user.State);
        txtPassword.Value = "";
        txtRepeatPassword.Value = "";
        SaveData.Enabled = false;
        UpdateData.Enabled = true;
       // profile prf = man_Login.getInfoprofile(user);
        //permissions.InnerHtml = "<a href=\"permissionsUser.aspx?id="+prf.Id+"\" class=\"btn btn-primary btn-label-left\">Assignar Permisos</a>";
    }


    public static void SetDDLsValue(DropDownList d, String val)
    {
        try
        {
            ListItem li;
            for (int i = 0; i < d.Items.Count; i++)
            {
                li = d.Items[i];
                if (li.Value == val)
                {
                    d.SelectedIndex = i;
                    i = d.Items.Count;
                    break;
                }
            }
        }
        catch (Exception ext)
        {
            String error = ext.Message;
        }
    }
}