﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AfiliacionEPS.aspx.cs" Inherits="Site_Pages_consultas_reporte_AfiliacionEPS" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>REPORTE</title>
<style>
    body {
      
        font-family:Arial;
    }
    #contenedor {
         width:600px;
        margin: 0 auto;
    }
    table {
       
    }
    tbody {
        border:2px solid black;
    }
      
	h2{		
		text-align:center;
        font-size:14px;
	}
	
	
	p{ text-align:left; }
</style>
    <script>
        window.print();
    </script>
</head>

<body>
    <div id="contenedor">
        <div style="text-align:center">
            <img src="../../uploads/dependences/logoEmpresa.png"   width="50%"/>
         </div>
        <table >
          <tbody>
            <tr>
              <td><h2>FORMATO REPORTE DE AFILIACIÓN POR ASIGNACION EXCEPCIONAL</h2></td>
            </tr>
            <tr>
              <td id="titulo" runat="server"></td>
            </tr>
            <tr>
              <td id="resolucion" runat="server"></td>
            </tr>
            <tr>
              <td>
     	        <h2>Afiliado</h2>
		        <p><strong> Nombre:</strong> <%=afiliado[0].AtdApePri+" "+afiliado[0].AtdApeSeg+" "+afiliado[0].AtdNomPri+" "+afiliado[0].AtdNomSeg %></p>
                <p><strong>Documento de Identidad: </strong> <%=afiliado[0].AtdAfiIde %></p>
              </td>
            </tr>
            <tr>
              <td>
              <h2>EPS a la cual es asignado</h2>
                         <p><strong> Nombre:</strong><%=afiliado[0].EpsNom %>
				        <p><strong>Página web: </strong><%=afiliado[0].EpsPagWeb %></p>
				        <p><strong>Linea 1-8000:</strong><%=afiliado[0].EpsLinNac+" | "+afiliado[0].EpsTel %></p>
				        <p><strong>Direccion regional:</strong><%=afiliado[0].EpsDir %></p>
                          <%if (afiliado[0].EPSCES != afiliado[0].EpsAsig)
                            { %>
                          <p><strong>Este afiliado fue cesionado a la EPS:</strong><br>
				          <p>Conforme acta de cesion suscrita entre <%=afiliado[0].EpsNom %> y <%=afiliado[0].EPSCES %> el dia  21 de febrero de 2014</p>
                        <%} %>
              </td>
            </tr>
            <tr>
              <td id="footer" runat="server"></td>
            </tr>
            <tr>
                <% DateTime fecha = DateTime.Today; %>
              <td style="text-align:center;"><strong><%=fecha.Date.ToString("MMMM") %></strong> <%=fecha.Date.ToString("dd") %>, <%=fecha.Date.ToString("yyyy") %></td>
            </tr>
          </tbody>
        </table>
        </div>
</body>
</html>
