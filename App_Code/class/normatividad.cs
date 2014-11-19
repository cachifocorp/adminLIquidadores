using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de normatividad
/// </summary>
public class normatividad
{
	public normatividad()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    
    String fecha;
    String numero;
    String entidadEmite;
    String fechaPublicacion;
    String archivo;
    String tipo;
    String asunto;
    String id;

    public String Id
    {
        get { return id; }
        set { id = value; }
    }


    public String Asunto
    {
        get { return asunto; }
        set { asunto = value; }
    }


    public String Tipo
    {
        get { return tipo; }
        set { tipo = value; }
    }

    public String Archivo
    {
        get { return archivo; }
        set { archivo = value; }
    }

    public String FechaPublicacion
    {
        get { return fechaPublicacion; }
        set { fechaPublicacion = value; }
    }
    

    public String EntidadEmite
    {
        get { return entidadEmite; }
        set { entidadEmite = value; }
    }
  

    public String Numero
    {
        get { return numero; }
        set { numero = value; }
    }
    

    public String Fecha
    {
        get { return fecha; }
        set { fecha = value; }
    }
    




}