<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Pages/masterPages/baseLine.master" AutoEventWireup="true" CodeFile="Certificados.aspx.cs" Inherits="Site_Pages_consultas_EPSasignada" %>

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
				<span class="main_t_2">Certificado de Afiliación EPS  y PAC </span>				
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
               <div class="span12 text-center">  
                   <p>Digite el Nit del empleador y consulte la lista de las EPS a la que sus afiliados fueron asignados.</p>
               </div>
				<div class="clear"></div>
                <div class="span6">
                       <div   class="contact_form contact_form_h"   style="margin-bottom: 10px;" runat="server">
                            <div class="span9 ">  	
				               <div class="input_holder">
                                <h5>Tipo de Documento*</h5>
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                       <asp:ListItem>Seleccione uno</asp:ListItem>
                                       <asp:ListItem Value="1">Cedula de Ciudadania</asp:ListItem>
                                       <asp:ListItem Value="2">Tarjeta de Identidad</asp:ListItem>
                                       <asp:ListItem Value="3">Registro CIvil</asp:ListItem>
                                       <asp:ListItem Value="4">NUIP</asp:ListItem>
                                       <asp:ListItem Value="5">Cedula extranjera</asp:ListItem>
                                   </asp:DropDownList>
                                     <h5>Identificación*</h5>
						            <input class="field-name" type="text" placeholder="NIT(requerido)" id="txt_nit" runat="server"/>
                                   <asp:Button ID="btnBuscar" runat="server" Text="Buscar"  CssClass="button search-button" OnClick="btnBuscar_Click" />
					            </div>
                            </div>
                        </div>
          <div class="span12 text-left">  
                   <p>A partir del 01 de marzo de 2014 sus empleados serán atendidos en la EPS asignada.</p>
               </div>
           
        </div>		
        <div class="clear"></div>         
        <hr />
          <asp:GridView ID="gridData" runat="server" CssClass="table table-bordered">
              <Columns>
              <asp:TemplateField HeaderText="Certificado de Afiliación">
                <ItemTemplate>
                  <%# "<a href=reporte/certificado.aspx?id="+Eval ("AtdAfiIde")+" class=\"button\">Descargar</a>" %>
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
	  </div>  
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content_down" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="scripts_down" Runat="Server">
</asp:Content>

