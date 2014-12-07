using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de userChat
/// </summary>
public class userChat
{
	public userChat()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    int idUserChat;
    String nombre;
    String correo;
    String fecha;

    public String Fecha
    {
        get { return fecha; }
        set { fecha = value; }
    }

    public String Correo
    {
        get { return correo; }
        set { correo = value; }
    }

    public String Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public int IdUserChat
    {
        get { return idUserChat; }
        set { idUserChat = value; }
    }
}