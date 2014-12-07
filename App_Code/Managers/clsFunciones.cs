using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Descripción breve de clsFunciones
/// </summary>
public class clsFunciones
{
	public clsFunciones()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public Object[] redimencionar(FileUpload img, int newWidth, int newHeight)
    {

        Bitmap originalBMP = new Bitmap(img.FileContent);
        Object[] datos = new Object[2];
        // Calculate the new image dimensions
        int origWidth = originalBMP.Width;
        int origHeight = originalBMP.Height;
        int sngRatio = origWidth / origHeight;
        // Create a new bitmap which will hold the previous resized bitmap
        Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);
        // Create a graphic based on the new bitmap
        Graphics oGraphics = Graphics.FromImage(newBMP);

        // Set the properties for the new graphic file
        oGraphics.SmoothingMode = SmoothingMode.AntiAlias; oGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        // Draw the new graphic based on the resized bitmap
        oGraphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);

        // Save the new graphic file to the server
       // newBMP.Save(directory + "tn_" + filename);
        string Grande = Path.GetFileName(img.FileName);
        Grande = getnombreArchivo() + "" + Grande.Substring(Grande.Length - 6, 6);
        
        // Once finished with the bitmap objects, we deallocate them.
        datos[1] = Grande;
        datos[0] = newBMP;
        originalBMP.Dispose();
       
        oGraphics.Dispose();

        return datos;
    }

    public static String getnombreArchivo()
    {
        string path = Path.GetRandomFileName();
        path = path.Replace(".", "");
        return path;
    }

    public static void SetDDLs(DropDownList d, String val)
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