using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_general_ManageMenu : System.Web.UI.Page
{
    public static profile pf;
    public static Users usr;
    man_menuPages menus = new man_menuPages();
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
                        LoadDataFields(menus.getInfoMenuDep(Convert.ToInt32(Request.QueryString["idItem"])));
                         btnUpdate.Enabled = true;
                         btnCreateMenu.Enabled = false;
                        break;
                    case "3":
                       menus.deleteMenuItem(Convert.ToInt32(Request.QueryString["idItem"]));
                        break;
                }
            }
        }
        assign();
        List_menus.InnerHtml = menus.TableDataOptions(Convert.ToInt32(Session["dependence"]), usr, pf, "ManageMenu.aspx");
    }

    public void assign()
    {
        usr = (Users)Session["User"];
        pf = (profile)Session["Profile"];
    }



    private void LoadDataFields(menu me){
        txtName.Text =me.Name;
        txtUrl.Text = me.Url;
        ddlParent.Items.Clear();
        ddlParent.Items.Add(new ListItem("Es el padre", "0"));
        ddlParent.DataBind();         
        SetDDLsValue(ddlParent,me.Id_parent.ToString());
       
    }


    public  void SetDDLsValue(DropDownList d, String val)
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
    protected void btnCreateMenu_Click(object sender, EventArgs e)
    {
        menu m = new menu();
        m.Name = txtName.Text;
        m.Id_parent = Convert.ToInt32(ddlParent.SelectedValue);
        m.Url = txtUrl.Text;
        m.Activated = 1;
        m.Id_dependence = Convert.ToInt32(Session["dependence"]);
        if (menus.saveMenu(m))
        {
            Messages.InnerHtml = "<p>Menu Agregado</p>";
            LoadDataFields(menus.getInfoMenuDep(Convert.ToInt32(Request.QueryString["idItem"])));
            List_menus.InnerHtml = menus.TableDataOptions(Convert.ToInt32(Session["dependence"]), usr, pf, "ManageMenu.aspx");
        }
        else {
            Messages.InnerHtml = "<p>Error el Agregar  el menu</p>";
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        menu m = new menu();
        m.Name = txtName.Text;
        m.Id_parent = Convert.ToInt32(ddlParent.SelectedValue);
        m.Url = txtUrl.Text;
        m.Activated = 1;
        m.Id_dependence = Convert.ToInt32(Session["dependence"]);
        m.Id = Convert.ToInt32(Request.QueryString["idItem"]);
        if (menus.UpdateMenuItem(m))
        {
            Messages.InnerHtml = "<p>Menu Actualizado</p>";
            List_menus.InnerHtml = menus.TableDataOptions(Convert.ToInt32(Session["dependence"]), usr, pf, "ManageMenu.aspx");
            btnUpdate.Enabled = false;
            btnCreateMenu.Enabled = true;
        }
        else
        {
            Messages.InnerHtml = "<p>Error al Actualizar  el menu</p>";
        }
    }
}