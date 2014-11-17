using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for man_integrators
/// </summary>
public class man_integrators
{
    clsDb db = new clsDb();
	public man_integrators(){}

    private integrators[] getDataIntegrators(int id_dependence,int page, int rowsByPage){
        string SQL = "Exec integratorsList @page = "+page+", @RowsByPage = "+rowsByPage+",	@id_dependence =  "+id_dependence;
        List<integrators> inte = new List<integrators>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                integrators integrator = new integrators();
                integrator.Id = Convert.ToInt32(reader["id"]);
                integrator.Name = reader["name"].ToString();
                integrator.Description = reader["description"].ToString();
                integrator.DateRegister = Convert.ToDateTime(reader["dateRegister"]);
                integrator.Photo = reader["photo"].ToString();

                inte.Add(integrator);
            }
    }catch{}
        return inte.ToArray();
    }


    public String getIntegrators(int id_dependence, int page, int rowsByPage)
    {

        integrators[] inte = getDataIntegrators(id_dependence, page, rowsByPage);
        String inteInfo = "";
        for (int i = 0; i < inte.Length; i++)
        {
            inteInfo += "<li class=\"b_wrapper span6\" style=\"text-align:center; width: 460px;\">" +
                         " <div class=\"home_b_holder_wrapper\">" +
                            "<div class=\"home_b_holder\">" +
                               "<img src=\"../"+Resources.paths.integrators+inte[i].Photo+"\" height=\"81\" width=\"128\" />" +
                            "<span class=\"clear\"></span>" +
                            
                          "</div>" +
                           "<div class=\"clear\"></div>" +
                    "</li>"; 
        }

        return inteInfo;
    }
}