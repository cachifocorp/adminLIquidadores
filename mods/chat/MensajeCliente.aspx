<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MensajeCliente.aspx.cs" Inherits="mods_chat_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../src/plugins/bootstrap/bootstrap.css" rel="stylesheet">
		<link href="../src/plugins/jquery-ui/jquery-ui.min.css" rel="stylesheet">
		<link href="http://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" rel="stylesheet">
		<link href='http://fonts.googleapis.com/css?family=Righteous' rel='stylesheet' type='text/css'>
		<link href="../src/plugins/fancybox/jquery.fancybox.css" rel="stylesheet">
        <link href="../src/plugins/fineuploader/fineuploader-4.3.1.css" rel="stylesheet" />
		<link href="../src/plugins/fullcalendar/fullcalendar.css" rel="stylesheet">
		<link href="../src/plugins/xcharts/xcharts.min.css" rel="stylesheet">
		<link href="../src/plugins/select2/select2.css" rel="stylesheet">
		<link href="../src/css/style.css" rel="stylesheet">
        <link href="../src/css/Styles/MultipleFileUpload.css" rel="stylesheet" />
      
		<!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
		<!--[if lt IE 9]>
				<script src="http://getbootstrap.com/docs-assets/js/html5shiv.js"></script>
				<script src="http://getbootstrap.com/docs-assets/js/respond.min.js"></script>
		<![endif]-->
   <meta http-equiv="Refresh" content="5;url=RegistroUsuario.aspx">
</head>
<body>
    <form id="form1" runat="server">
     <div class="row">
	    <div class="col-xs-12 col-sm-12">
		    <div class="box">
			    <div class="box-header">
				    <div class="box-name">
					    <i class="fa fa-search"></i>
					    <span>Solicitar Chat</span>
				    </div>
				    
			    </div>
			    <div class="box-content">
				    <h4 class="page-header">Solicitud enviada de nuestros agentes </h4>
                    <br />
                    &nbsp;
                    <br />
                    <h4>Su Sesión de Chat a finalizado.</h4>
                    <br />
                    <h4>Gracias por utilizar nuestros servicios</h4>
                    <div id="Messages" runat="server"></div>
				   
                </div>
            </div>
         </div>
    </div>
    </form>
    
        <!--End Container-->
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<!--<script src="http://code.jquery.com/jquery.js"></script>-->
<script src="../src/plugins/jquery/jquery-2.1.0.min.js"></script>
<script src="../src/plugins/jquery-ui/jquery-ui.min.js"></script>
<!-- Include all compiled plugins (below), or include individual files as needed -->
<script src="../src/plugins/bootstrap/bootstrap.min.js"></script>
<script src="../src/plugins/justified-gallery/jquery.justifiedgallery.min.js"></script>
<script src="../src/plugins/tinymce/tinymce.min.js"></script>
<script src="../src/plugins/tinymce/jquery.tinymce.min.js"></script>
    <script src="../src/js/insideDevoops.js"></script>
<!-- All functions for this theme + document.ready processing -->

</body>
</html>
