<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistroUsuario.aspx.cs" Inherits="mods_chat_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Solicitud de Chat</title>
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
				    <h4 class="page-header">Registrar Chat </h4>
                    <div id="Messages" runat="server"></div>
				    <div class="form-horizontal" role="form">
                        <div class="form-group">
                              <label  class="col-sm-2 control-label">Nombre Usuario
                              </label>
						    <div class="col-sm-4">
							    <input type="text" id="txtNombre" runat="server" class="form-control" 
                                    placeholder="Nombre Completo" data-toggle="tooltip" data-placement="bottom" required="required" title="Nombre Completo">
						    </div>
						    <label  class="col-sm-2 control-label">Correo</label>
						    <div class="col-sm-4">
							    <input type="text" id="txtCorreo" runat="server" class="form-control" 
                                    placeholder="Email" data-toggle="tooltip" data-placement="bottom" 
                                    title="Email" required="required">
						    </div>
                            
					    </div>
					    
                         
                      <div class="clearfix"></div>
					<div class="form-group">
						<div class="col-sm-2">
                            <asp:Button ID="SaveData" runat="server" Text="Ingresar" class="btn btn-primary btn-label-left" OnClick="SaveData_Click" />
						</div>
                        <div class="col-sm-2">
                            <a href="javascript:onBackClick()" class="btn btn-primary btn-label-left btn-danger">Cancelar</a>
                            
						</div>
					</div>
                       
                    </div>
                </div>
            </div>
         </div>
    </div>
    </form>
</body>
</html>
