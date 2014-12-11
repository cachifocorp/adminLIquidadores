<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Pages/masterPages/baseLine.master" AutoEventWireup="true" CodeFile="AsignacionEPS.aspx.cs" Inherits="Site_Pages_consultas_EPSasignada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        thead {
            color:black;
            font-weight:bold;
        }
        tbody{
            color:black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Slider" Runat="Server">
      <!-- Start Main title wrapper  -->	 
	<div class="main_title_wrapper">
		<div class="page_title_wrapper">
	    <div class="container">
		 <div class="row">
		  <div class="span12">
          <div class="page_title_inner">	      			       	
				<span class="main_t_1">CONSUlTA </span>
				<span class="main_t_2">Asignacion EPS
				</span>				
              			
		  </div>
		  </div>
		 </div>
        </div>			
      </div> <!-- End page title wrapper -->
	  <div class="clear"></div>
    </div> 	
<!-- End Main title wrapper --> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content_page" Runat="Server">
    <form runat="server">
	<div class="container content_wrapper_section">  
	  	  		
      <div class="row">
           
             
          <span class="right"> <<asp:Button ID="btnCloseSS" runat="server" Text="Cerrar Sesión"  OnClick="btnCloseSS_Click"/>
				</span>	
                
				<div class="clear"></div>
        		    
                <div class="span2">
                    <asp:Label Text="Departamento" runat="server" Style="color:black;" />
                    <asp:DropDownList ID="cbxDep" runat="server" OnSelectedIndexChanged ="cbxDep_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div> 
                <div class="span2">
                    <asp:Label Text="Municipio Prestación" runat="server"   Style="color:black;"/>
                    <asp:DropDownList ID="cbxMun" runat="server"></asp:DropDownList>
                </div>
                <div class="span3">
                    <asp:Label Text="Tipo Documento" runat="server"   Style="color:black;"/>
                    <asp:DropDownList ID="cbxtipo" runat="server">
                        <asp:ListItem Value ="">Seleccione uno</asp:ListItem>
                        <asp:ListItem Value="CC">Cedula de Ciudadania</asp:ListItem>
                        <asp:ListItem Value="TI">Tarjeta de Identidad</asp:ListItem>
                        <asp:ListItem Value="RC">Registro CIvil</asp:ListItem>
                        <asp:ListItem Value="NU">NUIP</asp:ListItem>
                        <asp:ListItem Value="CE">Cedula extranjera</asp:ListItem>
                    </asp:DropDownList>
                </div> 
                <div class="span3">
                    <asp:Label Text="Identificación" runat="server" Style="color:black;"/>
                    <input type="text" name="iden" placeholder="Identificación" id="txtIden" runat="server"/>
                </div> 
                <div class="span2">
                    <br />
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar"  CssClass="button" OnClick="btnBuscar_Click"/>
                </div>  
                <div class="clear"></div>         
                <hr />
           <div class="span12">
             
                      <asp:GridView ID="gridData" runat="server" CssClass="table table-bordered"  
                          emptydatatext="<h2>No hay datos Disponibles</h2>"  >                        
                          <Columns>
                         <%-- <asp:TemplateField HeaderText="Certificado de Afiliación">
                            <ItemTemplate>
                              <%# "<a href=reporte/certificado.aspx?id="+Eval ("AtdAfiIde")+" class=\"button\">Descargar</a>" %>
                            </ItemTemplate>
                          </asp:TemplateField>--%>
                        </Columns>
                      </asp:GridView>
               </div>
	          </div>  
            </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content_down" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="scripts_down" Runat="Server">
</asp:Content>

