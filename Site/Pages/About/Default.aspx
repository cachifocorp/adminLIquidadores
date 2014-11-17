<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Pages/masterPages/baseLine.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pages_About_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Slider" Runat="Server">
    	<div class="main_title_wrapper">		    
		<div class="page_title_wrapper">
	    <div class="container">
		 <div class="row">
		  <div class="span12">
          <div class="page_title_inner">	      			       	
				<span class="main_t_1"> SOBRE NUESTRA EMPRESA</span>
				<span class="main_t_2"> AMV | Energia Y Comunicaciones </span>
				<span class="breadcrumb"> <a href="index-2.html">inicio </a> / Sobre Nosotros </span>
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
   <!-- Start About us block --> 
 <div class="container content_wrapper_section"> 
    <div class="container">
	  <div class="row">        							    
		<ul class="portfolio group" id="pub_about" runat="server"> 
			
		</ul>
	 
    <div class="clear"></div>	

	</div>  <!-- End port wrapper -->
    </div>	
   </div> 
 <!-- End content wrapper section -->  

<!-- Start Client block -->  
   <div class="container">
   <div class="content_wrapper_section">
     <div class="port_wrapper_home">
        <i class="icon_cli"></i>
		  <div class="block_tile_wrapper">	 
	       <span class="block_tile_1"> Nuestros Clientes </span>
	       <span class="block_tile_2"> &nbsp; | &nbsp;  Estos Son algunos de nuestros Clientes  </span>
		  </div>
		<div class="readmore_holder"><a href="Client/Clients.aspx"><i class="icon_plus"></i></a></div>
        <div class="clear"></div>		
     </div>  
    <div class="container">
	  <div class="row">
	        					
     <div class="client_h_inner">   
       <div class="client_h_holder_bottom">	
        <ul class="client_inner_top" id="imageClient" runat="server">       
   			    
        </ul>  <!-- End client inner -->
          <div class="clear"></div>		
        </div>
	 </div><!-- End client h inner -->

	</div>  <!-- End row -->
    </div>	
   </div> <!-- End content wrapper section --> 
	<div class="clear"></div>
   </div>
<!-- End client block -->
<!-- Start testimonials block   
 <div class="container content_wrapper_section">      
    <div class="container">
	  <div class="row">
	  <div class="faq_holder"> 
	        <div class="testi_inner_wrapper_holder_4" id="commet_client" runat="server">

			  <div class="clear"></div>
		  </div>   End testi inner wrapper holder  
			<span class="clear"></span>
        </div>
	
	 
    <div class="clear"></div>	

	</div>    End port wrapper  
    </div>	
   </div>   End content wrapper section  
  End testimonials block --> 
     <script>
         $(function () {
             $(".in").attr("class", "span4");
         });
    </script>
</asp:Content>

