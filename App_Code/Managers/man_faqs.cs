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

   


    public bool AddFaqs(String titulo, String descripcion, String tipo, String id,String opcion)
    {
        try
        {
            String sql = "";
            if (tipo.Equals("insert"))
            {
                sql = "insert into faqs(titulo,descripcion,tipo) values " +
                               "('" + titulo + "'," +
                               "'" + descripcion + "'," +
                               "'" + opcion + "'" +
                                " )";

            }
            else if (tipo.Equals("update"))
            {
                sql = "update faqs set " +
                        "titulo='" + titulo + "'" +
                        ", descripcion='" + descripcion + "'" +
                        ",tipo='" + opcion + "'" +

                        "  where id=" + id
                        ;
            }
            else
            {
                sql = "delete from faqs where id=" + id;
            }
            db.ejecutar(sql);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public String GetFaqs(String page)
    {
        try
        {
            String sql = "Select id,titulo,descripcion,case when tipo=1 then 'Preguntas Frecuentes' when tipo=2 then 'Liquidacion de Acreencias' else 'Acreencias extratemporales' end as tipo from faqs ";
            String[,] resul = db.RetornarMatriz(sql);
            String resultString = "";
            for (int i = 0; i < resul.GetLength(0); i++)
            {

                resultString += "<tr>" +
                            "<td><a  href=\"" + page + "&accion=modificar&idfaqs=" + resul[i, 0] + "\" class=\"btn btn-warning\">Editar</a>"
                + "  </td>" +
                            "<td>" + resul[i, 1] + "</td>" +
                            "<td>" + resul[i, 2] + "</td>" +
                            "<td>" + resul[i, 3] + "</td>" +


                        "</tr>";

            }


            return resultString;

        }
        catch
        {
            return "";
        }

    }

    public String[] getFaq(String id)
    {
        String sql = "Select id,titulo,descripcion,tipo from faqs where id=" + id;
        return db.returnVector(sql);


    }

}