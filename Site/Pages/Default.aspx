    <%@ Page Title="" Language="C#" MasterPageFile="baseLine.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Slider" runat="server">
    <!-- Start slider  -->	   		   
		<div class="slider_wrapper">
			    
		           <div class="fullwidthbanner-container">
						<div class="fullwidthbanner">
							<ul id="Sliders" runat="server"> 
							</ul>
						</div>
					</div>
		</div> 
	<!-- Start slider  -->	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content_page" Runat="Server">
    <div class="container content_wrapper_section">
     <div class="port_wrapper_home">
        
		  <div class="block_tile_wrapper">	 
	       <span class="block_tile_1"> Ultimas Noticias </span>
	       <span class="block_tile_2"> &nbsp; | &nbsp;  Mas Noticias Por <a href="News/news.aspx">Aqui</a> </span>
		  </div>
		<div class="readmore_holder"><a href="News/news.aspx"><i class="icon_plus"></i></a></div>
        <div class="clear"></div>		
     </div>
   


    <div class="container">
        <div class="row">	        					
            <div class="port_inner_h4">
		        <ul class="blog_homepage" runat="server" id="news_index"> 	
		        </ul>
                <div class="clear"></div>	 
			  </div><!-- Fin Noticias -->
	    </div>  <!-- End port wrapper -->
    </div>	
</div> <!-- End content wrapper section --> 

<hr>
<!-- Contenido Administrable --> 
 <div class="container content_wrapper_section">
     <div class="port_wrapper_home">
        <i class="icon_flag"></i>
		  <div class="block_tile_wrapper">	 
	       <span class="block_tile_1">Sobre Nuestra Empresa </span>
	       <span class="block_tile_2"> &nbsp; |  </span>
		  </div>
		<div class="readmore_holder"><a href="About/Default.aspx"><i class="icon_plus"></i></a></div>
        <div class="clear"></div>		
     </div>       
    <div class="row">
	  <ul class="portfolio group" id="services_index" runat="server">  
	</ul>
    </div>
   </div> <!-- End content wrapper section --> 

    <div class="container content_wrapper_section">
     <div class="port_wrapper_home">
        <i class="icon_flag"></i>
		  <div class="block_tile_wrapper">	 
	       <span class="block_tile_1">Asignación Afiliados </span>
	       <span class="block_tile_2"> &nbsp; |  </span>
		  </div>
		<div class="readmore_holder"><a href="About/Default.aspx"><i class="icon_plus"></i></a></div>
        <div class="clear"></div>		
     </div>       
    <div class="row">
        <br />
        <br />
	  <div class="span2">
          <a href="consultas/empleadores.aspx" class="btn_smallblue left">Consulta Asignación empleadores </a>
	  </div>
        <div class="span2">
          <a href="consultas/EPSasignada.aspx" class="btn_smallblue left">Consulte aquí su EPS asignada</a>
	  </div>
        <%--<div class="span2">
          <a href="#" class="btn_smallblue left">Consulta Asignación EPS</a>
	  </div>--%>
        <div class="span2">
          <a href="consultas/FondosPensiones.aspx" class="btn_smallblue left">Consulta asignación fondo de Pensiones</a>
	  </div>
        <div class="span2">
          <a href="consultas/OrganosDeControl.aspx" class="btn_smallblue left">Órganos de Control</a>
	  </div>
        <div class="span2">
          <a href="consultas/Certificados.aspx" class="btn_smallblue left">Certificado de Afiliación EPS  y PAC</a>
	  </div>
    </div>
   </div> <!-- End content wrapper section --> 

<!-- End client block -->
    <script>
        $(function () {
            $(".in").attr("class", "span4");
        });
    </script>
</asp:Content>

