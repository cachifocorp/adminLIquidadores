<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chatClient.aspx.cs" Inherits="mods_chat_Client" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Chat Cliente</title>
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
    <script type="text/javascript" language="javascript">
        function onBackClick() {
            window.close();
        }
        function abreventana() {
            alert("");
        }
        var bPreguntar = true;

        window.onbeforeunload = preguntarAntesDeSalir;

        function preguntarAntesDeSalir() {
            if (bPreguntar)
                var boton = document.getElementById('SaveData');
                boton.click();
        }

</script>

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
				    <h4 class="page-header">Chat Cliente </h4>
                    <div id="Messages" runat="server"></div>
				    <div class="form-horizontal" role="form">
                        
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Timer runat="server" id="Timer1" Interval="1000" OnTick="Timer1_Tick"  ></asp:Timer>
                
               

                <br />
                <div style="height:300px; overflow: scroll;" id="ContentChat" runat="server">
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
                        <center>
                        <asp:TextBox ID="txtMensaje" runat="server" style="width:70%"></asp:TextBox>
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" class="btn btn-primary btn-label-left btn-default" OnClick="btnEnviar_Click" />
                        </center>
                        
        

                        
                      <div class="clearfix"></div>
					<div class="form-group">
						<div class="col-sm-2">
                            <asp:Button ID="SaveData" runat="server" Text="Salir Chat" class="btn btn-primary btn-label-left btn-danger" OnClick="SaveData_Click1" />
						</div>
                       
					</div>
                       
                    </div>
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
