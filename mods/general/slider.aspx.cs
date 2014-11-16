using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_general_slider : System.Web.UI.Page
{
    public static profile pf;
    public static Users usr;
    man_slider mSlider = new man_slider();
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
                        loadDataFileds(mSlider.getSlider(Convert.ToInt32(Request.QueryString["idItem"])));
                        break;
                    case "3":
                        mSlider.deleteSlide(Convert.ToInt32(Request.QueryString["idItem"]));
                        break;
                }
            }
        }
        assign();
        List_sliders.InnerHtml = mSlider.TableDataOptions(Convert.ToInt32(Session["dependence"]), usr, pf, "slider.aspx");
        
        ucMultiFileUpload.Titulo = "Subir imágenes";
        ucMultiFileUpload.Comment = "Hasta 5 archivos .png, .gif ó .jpg (máx. 4 MB en total).";
        ucMultiFileUpload.MaxFilesLimit = 5;
        //ucMultiFileUpload.DestinationFolder = "C:\\Inetpub\\vhosts\\estigioportal.com\\amv.estigioportal.com\\Pages\\src\\img\\sliderImages\\"; // única propiedad obligatoria. R
        ucMultiFileUpload.DestinationFolder = genericFunctions.paths(usr.Id_dependence, 9);
        ucMultiFileUpload.FileExtensionsEnabled = ".png|.jpg|.gif";
    }

    public void assign()
    {
        usr = (Users)Session["User"];
        pf = (profile)Session["Profile"];
    }



    protected void btnCreateSlider_Click(object sender, EventArgs e)
    {
        slider sl = new slider();
        sl.Slide = taSlider.Value;
        sl.Id_dependence = Convert.ToInt32(Session["dependence"]);
        sl.Name = txtName.Text;
        if (mSlider.SaveSlide(sl)) {
            List_sliders.InnerHtml = mSlider.TableDataOptions(Convert.ToInt32(Session["dependence"]), usr, pf, "slider.aspx");
        }
    }

    private void loadDataFileds(slider sli) {
        txtName.Text = sli.Name;
        taSlider.Value = WebUtility.HtmlDecode(sli.Slide);
        btnCreateSlider.Enabled = false;
        btnUpdate.Enabled = true;
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        slider sld = new slider();
        sld.Id = Convert.ToInt32(Request.QueryString["idItem"]);
        sld.Name = txtName.Text;
        sld.Slide = taSlider.Value;
        if (mSlider.updateSlide(sld)) {
            List_sliders.InnerHtml = mSlider.TableDataOptions(Convert.ToInt32(Session["dependence"]), usr, pf, "slider.aspx");
            btnCreateSlider.Enabled = true;
            btnUpdate.Enabled = false;
            txtName.Text = "";
            taSlider.Value = "";
        }
    }
    protected void btnUploadImage_Click(object sender, EventArgs e)
    {
         ucMultiFileUpload.amountF();
         if (ucMultiFileUpload.AmountFiles > 0)
         {
             if (ucMultiFileUpload.UploadFiles(true))
             {

             }
         }
    }



    private void showImages()
    {
        System.IO.DirectoryInfo _dirInfo = new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath(ucMultiFileUpload.DestinationFolder));

        if (_dirInfo.Exists)
        {
            System.IO.FileInfo[] _filesInfo = _dirInfo.GetFiles();
            foreach (System.IO.FileInfo _f in _filesInfo)
            {
                Image _img = new Image();
                _img.ImageUrl = string.Format("{0}/{1}", ucMultiFileUpload.DestinationFolder, _f);
                _img.Height = new Unit(50);
                pnlImagenes.Controls.Add(_img);
            }
        }
        else
        {
            pnlImagenes.Controls.Add(new Label { Text = "Aún no se han subido archivos." });
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        showImages();
    }
}