using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de man_chat
/// </summary>
public class man_chat
{
	public man_chat()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    clsDb db = new clsDb();

    public String getHistorial()
    {
        try
        {
            String sql = "Select * from UserChat order by idUserchat desc";
            String[,] resul = db.RetornarMatriz(sql);
            String resultString = "";
            for (int i = 0; i < resul.GetLength(0); i++)
            {

                resultString += "<tr>" +
                            "<td><a  href=\"detallehistorial.aspx?accion=ver&iduser=" + resul[i, 0] + "\" class=\"btn btn-warning\">Ver Chat</a>"
                           + " </td>" +
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

    public String getConversacion(String iduser)
    {
        try
        {
            String sql = "Select * from vwMensajesChat where idUserChat="+iduser;
            String[,] resul = db.RetornarMatriz(sql);
            String resultString = "";
            for (int i = 0; i < resul.GetLength(0); i++)
            {

                resultString += "<b>" + resul[i, 0] + ":</b>" + resul[i, 1] + "<br />";

            }


            return resultString;
        }
        catch
        {
            return "";
        }
    }


    public String[] setClienteChat(String usuario, String correo)
    {
        String[] vr=new String[2];
        vr[0] = "";
        vr[1] = "";
        try
        {
            String sql = "insert into UserChat(Nombre,Correo,Fecha) values('"+usuario+"','"+correo+"',''+getdate())";
            String sql2 = "insert into chat (Sala,FechaHora,Estado,idUserChat) values ((select 'Sala '+convert(varchar,(max(idchat)+1)) from chat),''+getdate(),1,(select max(idUserChat) from UserChat))";
            if (db.ejecutar(sql))
            {
                db.ejecutar(sql2);
                String sql3 = "select idchat,iduserchat from chat where idchat=(select max(idchat) from chat)";
                vr= db.returnVector(sql3);
                return vr;
            }
            else
            {
                return vr;
            }
            
        }
        catch
        {
            return vr;
        }


    }

    public bool getEstadoInicio(String idchat)
    {
        try
        {
            String sql = "select Estado from chat where idchat="+idchat;
            String[] vr = db.returnVector(sql);
            if (vr[0].Equals("1"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch
        {
            return false;
        }

    }

    public bool setCancelarChat(String idchat)
    {
        try
        {
            String sql = "update chat set estado=4 where idchat="+idchat;
            db.ejecutar(sql);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool setSalirChat(String idchat)
    {
        try
        {
            String sql = "update chat set estado=3 where idchat=" + idchat;
            db.ejecutar(sql);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool setIniciarChat(String idchat)
    {
        try
        {
            String sql = "update chat set estado=2,iduser=1 where idchat=" + idchat;
            db.ejecutar(sql);
            return true;
        }
        catch
        {
            return false;
        }
    }




    public bool setChat(String mensaje,String idUserchat,String iduser,String idchat)
    {
        try
        {
            String sql = "";
            if (!idUserchat.Equals(""))
            {

                sql = "insert into MensajesChat(Mensaje,iduserchat,idchat)" +
            "values('" + mensaje + "'," + idUserchat + "," + idchat + ")";
            }
            else
            {
                sql = "insert into MensajesChat(Mensaje,iduser,idchat)" +
           "values('" + mensaje + "'," + iduser + "," + idchat + ")";
            }
            db.ejecutar(sql);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public String[] getMensajeschat(String idchat)
    {
        String[] vr = new String[2];
        vr[0] = "";
        vr[1] = "";
        try
        {
            String sql = "select * from [liquidadoresweb].[vwMensajesChat] where idchat="+idchat+" order by idmensaje asc";
            String result = "";
            String[,] resul = db.RetornarMatriz(sql);
           
            
            for (int i = 0; i < resul.GetLength(0); i++)
            {
                result += resul[i, 0] + ": " + resul[i, 1]+" <br />";
                vr[1] = resul[i, 6];

            }
            vr[0] = result;

            return vr;
        }
        catch
        {
            return vr;
        }
    }


    public String GetEnEsperaAdmin(int tipo)
    {
        try
        {
            String where = "";
            if (tipo == 1)
            {
                where = " and c.idUser is null ";
            }
            String sql = "select Sala, c.FechaHora,uc.Nombre,uc.Correo,c.idchat,uc.iduserchat from dbo.chat c inner join "+
                          " dbo.UserChat uc on c.idUserChat=uc.idUserChat "+
                        " where c.Estado="+tipo+" "+where;
            String[,] resul = db.RetornarMatriz(sql);
            String resultString = "";
            for (int i = 0; i < resul.GetLength(0); i++)
            {

                resultString += "<tr>" +
                            "<td><a  href=\"chatAdmin.aspx?accion="+tipo+"&idchat=" + resul[i, 4] + "&iduserchat=" + resul[i, 5] + " \" class=\"btn btn-warning\">Ingresar a Sala</a></td>" +
                            "<td>" + resul[i, 0] + "</td>" +
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





}