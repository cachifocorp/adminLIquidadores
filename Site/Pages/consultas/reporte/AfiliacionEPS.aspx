<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AfiliacionEPS.aspx.cs" Inherits="Site_Pages_consultas_reporte_AfiliacionEPS" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>REPORTE</title>
<style>
    body {
        
    }
    table {
        position:absolute;
    }
	h2{
		font-size:12px;
		text-align:center;
		}
	tr{border:1px solid black;}
	td{font-size:12px; text-align:center; font-weight:bold;}
	p{ text-align:left; font-size:12px}
</style>
</head>

<body>
<table width="800px" >
  <tbody>
    <tr>
      <td>FORMATO REPORTE DE AFILIACIÓN POR ASIGNACION EXCEPCIONAL</td>
    </tr>
    <tr>
      <td>PROGRAMA DE ENTIDAD PROMOTORA DE SALUD DEL RÉGIMEN CONTRIBUTIVO <br> CAJA DE COMPENSACIÓN FAMILIAR ANTIOQUIA EN LIQUIDACIÓN</td>
    </tr>
    <tr>
      <td>ASIGNACIÓN DE AFILIADOS A ENTIDADES PROMOTORAS DE SALUD<br>Resolución 361 de Febrero 12 de 2014 Superintendencia Nacional Salud Reunion de asignación Excepcional de Afiliados de febrero 21 de 2014</td>
    </tr>
    <tr>
      <td>
     	<h2>Afiliado</h2>
		<p>Nombre: </p>
		<p>Documento de Identidad</p>
      </td>
    </tr>
    <tr>
      <td>
      <h2>EPS a la cual es asignado</h2>
				<p><strong>Nombre:</strong><%=afiliado[0].AtdApePri+" "+afiliado[0].AtdApeSeg+" "+afiliado[0].AtdNomPri+" "+afiliado[0].AtdNomSeg %></p>
				<p><strong>Página web: </strong><%=afiliado[0].EpsPagWeb %></p>
				<p><strong>Linea 1-8000:</strong><%=afiliado[0].EpsLinNac+" "+afiliado[0].EpsTel %></p>
				<p><strong>Direccion regional:</strong><%=afiliado[0].AtdDirRes %></p>
                  <%if (afiliado[0].EPSCES != afiliado[0].EpsNom){ %>
                  <p><strong>Este afiliado fue cesionado a la EPS:</strong><br>
				  <p>Conforme acta de cesion suscrita entre <%=afiliado[0].EpsNom %> y <%=afiliado[0].EPSCES %> el dia  21 de febrero de 2014</p>
                <%} %>
      </td>
    </tr>
    <tr>
      <td>
      	<h2>Prestacion de servicios</h2><p>This is the content for Layout P Tag</p>
					<p>EL PROGRAMA DE ENRIDAD PROMORA DE SALUD DEL RÉGIMEN  CONTRIBUTIVO CAJA DE COMPENSACIÓN FAMILIAR COMFENALCO ANTIOQUIA EN LIQUIDACION,brindará atención de servicios al afiliado hasta el dia 28 de febrero de 2014</p>
					<p>La EPS a la cual ha sido asignado el afiliado, asumira la prestación de servicios a partir de marzo 01 de 2014</p>
					<p>al fin de garantizar la continuidad en la prestacion del servicio de salud, le fue entregada a  {{}}  un CD que contiene las historias clinicas de los afiliados asignados</p>
					<p>Se deja constancia que cada EPS ASIGNADA recibio la documentacion relacionada con el proceso de salud, la cual  es necesaria para continuar con la prestacon efectiva del servicio a todos  los usuarios traslados a partir del primero (1) de Marzo de 2014</p>
      </td>
    </tr>
    <tr>
      <td style="text-align:center;"><strong>Marzo,</strong>21 de actubre 2012</td>
    </tr>
  </tbody>
</table>

</body>
</html>
