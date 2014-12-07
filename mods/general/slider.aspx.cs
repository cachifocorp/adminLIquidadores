using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_general_slider : System.Web.UI.Page
{

    public static profile pf;
    public static Users usr;

    clsMenu objMenu = new clsMenu();
    clsFunciones objFun = new clsFunciones();

    man_slider mSlider = new man_slider();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["action"] != null && Request.QueryString["idItem"] != null)
            {

                switch (Request.QueryString["action"])
                {
                    case "3":
                        mSlider.deleteSlide(Convert.ToInt32(Request.QueryString["idItem"]));
                        break;
                }
            }
        }
        catch
        {
        }
        


        assign();
        List_sliders.InnerHtml = mSlider.TableDataOptions(Convert.ToInt32(Session["dependence"]), usr, pf, "slider.aspx");
    }

    public void assign()
    {
        usr = (Users)Session["User"];
        pf = (profile)Session["Profile"];
    }





    protected void btnCreateSlider_Click(object sender, EventArgs e)
    {
        enviar("insert");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        
    }

    protected void enviar(String op)
    {
        
        String icono = "";
        String item = "";
        if (fuImg.HasFile)
        {

            icono = Path.GetFileName(fuImg.FileName);
            if (icono.Length > 6)
            {
                icono = clsFunciones.getnombreArchivo() + icono.Substring(icono.Length - 6, 6);
            }
            else
            {
                icono = clsFunciones.getnombreArchivo() + icono;
            }
            icono = icono.Replace(")", "").Replace("(", "");
            fuImg.SaveAs(Server.MapPath("~/Site/Pages/src/img/sliderImages/" + icono));

            String text="<li data-transition=\"fade\">"+
				                "	<img src=\"src/img/sliderImages/"+icono+"\" height=\"500\" width=\"1360\" alt=\"\" >"+
				                 "   <div class=\"caption general_caption lfb tp-caption\" data-x=\"-432\" data-y=\"190\" data-speed=\"2000\" data-endspeed=\"1000\" data-start=\"300\" data-end=\"7700\" data-easing=\"easeOutExpo\" data-endeasing=\"easeInExpo\">"+
								"	</div>"+
								"	<div class=\"caption general_caption pst_media12 lft tp-caption\" data-x=\"58\" data-y=\"119\" data-speed=\"2200\" data-endspeed=\"900\" data-start=\"800\" data-end=\"7900\" data-easing=\"easeOutExpo\" data-endeasing=\"easeInBack\">"+
								"					                    	<h1 class=\"warning\" style=\"color:white; background:#00689A;\"> "+txtName.Text+" </h1>"+
				                 "   </div>"+
                                  				                    
				    			"</li>";

            if (objMenu.banner(txtName.Text, text, "", op))
            {
                Messages.InnerHtml = "<p class=\"bg-success\">Información Guardada</p>";
            }
            else
            {
                Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Guardo La entrada</p>";
            }

        }
        else
        {
            Messages.InnerHtml = "<p class=\"bg-danger\">Error!! Debe Seleccionar una Imagen</p>";
        }
        

        
        
    }



}