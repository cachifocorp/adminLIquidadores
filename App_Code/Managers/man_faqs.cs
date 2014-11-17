using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for man_faqs
/// </summary>
public class man_faqs
{
    clsDb db = new clsDb();
	public man_faqs()
	{	}

    private faqs[] getFaqs( int tipo) {
        String SQL = "Select * from faqs where tipo = "+ tipo;
        List<faqs> faq = new List<faqs>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                faqs f = new faqs();
                f.Id = Convert.ToInt32(reader["id"]);
                f.Titulo = reader["titulo"].ToString();
                f.Descripcion = reader["descripcion"].ToString();
                f.Tipo = Convert.ToInt32(reader["tipo"]);
               //f.Timestamp = Convert.ToDateTime(reader["timestamp"]);
                faq.Add(f);
            }
            con.Close();
            return faq.ToArray(); ;
        }
        catch (Exception ex) {
            return faq.ToArray();
        }

    }

    public String faqsFormat(int tipo)
    {
        faqs[] faq = getFaqs(tipo);
        String faqFormat = "";
        for (int i = 0; i < faq.Length; i++){
            faqFormat+="<div class=\"accordion-item\">"+
								"<div class=\"accordion-item-header\"><a href=\"#\">"+faq[i].Titulo+"</a></div>"+
								"<div class=\"accordion-item-body\">"+
									 "<p>"+faq[i].Descripcion+"</p>"+
								"</div>"+
							"</div>";
        }

        return faqFormat;
    }

}