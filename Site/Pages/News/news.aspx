<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Pages/masterPages/baseLine.master" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="Pages_News_new" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Slider" Runat="Server">
    <!-- Start Main title wrapper  -->	   
		   
	<div class="main_title_wrapper">
		    
		<div class="page_title_wrapper">
	    <div class="container">
		 <div class="row">
		  <div class="span12">
          <div class="page_title_inner">	      			       	
				<span class="main_t_1"> Noticias </span>
				<span class="main_t_2"> La Ultima Información Sobre Avances tecnologicos en Nuestro Sector </span>
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
          <div class="container content_wrapper_section">  
		 		
       <div class="row">
      
      	    <!-- Start content -->
			
			
		<div class="span8 left">
		   <div class="page_right" id="news_Pub" runat="server">	
            </div>
            <!-- Pagination -->
                    
            <div class="pagi">
                <ul id="nextPage" runat="server">                   
                </ul>
                <div class="clear"></div>
            </div>
	    </div>
			<!-- End span9 -->

			<!-- Sidebar -->
           	
		<aside class="span4 float_right sidebar">

			<div class="home-slider flexslider loading">
			     <ul class="slides" id="news_slider" runat="server">	                                            
			      </ul>
	         </div>
            <div class="clear"></div>	
           
		</aside> <!-- End sidebar -->

           <!-- indicadores -->
           	
           
		<aside class="span4 float_right">
            <hr />
            <h2>Indicadores Economicos</h2>
			<div id="bgBody">
                <script type="text/javascript">
                    // <![CDATA[
                    var bgHost = "http://www.applab.in/";
                    var bgType = "CO-19284-1";
                    var bgIndi = "1|2|3|4|5|6|7|8|9|10";
                    (function (d) { var f = bgHost + "apps/indicators/" + bgType + "/" + bgIndi + "/functions.js"; d.write(unescape("%3Cscript src='" + f + "' type='text/javascript'%3E%3C/script%3E")); })(document);
                    // ]]>
                </script>
                </div>
            <div class="clear"></div>	
           
		</aside> <!-- End indicadores -->   

         <div class="clear"></div>	
           <aside class="span4 float_right sidebar">           
            <div class="addthis_horizontal_follow_toolbox"></div>
            <div class="clear"></div>	           
		</aside> <!-- End sidebar -->
            
         <div class="clear"></div>			
        </div> <!-- End row -->
				
     </div>  <!-- End content wrapper section -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content_down" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="scripts_down" Runat="Server">
   
</asp:Content>

