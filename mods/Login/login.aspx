<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="mods_Login_login" %>

<!DOCTYPE html>
<html lang="es">
	<head>
		<meta charset="utf-8">
		<title>AMV - Ingreso al sistema</title>
		<meta name="description" content="description">
		<meta name="author" content="Walther Smith">
		<meta name="keyword" content="keywords">
         
		<meta name="viewport" content="width=device-width, initial-scale=1">
		<link href="../src/plugins/bootstrap/bootstrap.css" rel="stylesheet">
		<link href="http://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" rel="stylesheet">
		<link href='http://fonts.googleapis.com/css?family=Righteous' rel='stylesheet' type='text/css'>
		<link href="../src/css/style.css" rel="stylesheet">
		<!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
		<!--[if lt IE 9]>
				<script src="http://getbootstrap.com/docs-assets/js/html5shiv.js"></script>
				<script src="http://getbootstrap.com/docs-assets/js/respond.min.js"></script>
		<![endif]-->
	</head>
<body>
<div class="container-fluid">
	<div id="page-login" class="row">
		<div class="col-xs-12 col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3">
			<div class="box">
				<div class="box-content" >
                    <div class="text-center">
                    </div>
					<div class="text-center">
						<h3 class="page-header"><small>(Administracion)</small></h3>
					</div>
                    <form  method="post" runat="server">
                         <div class="form-group" id="messages" runat="server">
                          </div>
					    <div class="form-group">
						    <label class="control-label">Nombre de usuario</label>
						    <input type="text" id="txt_username" runat="server" class="form-control" name="username"  placeholder="ej: usuario"/>
					    </div>
					    <div class="form-group">
						    <label class="control-label">Contraseña</label>
						    <input type="password" id="txt_password" runat="server" class="form-control" name="password" placeholder="Contraseña" />
					    </div>
					    <div class="text-center">
                            <asp:Button ID="btn_Login" runat="server" class="btn btn-primary" Text="Ingresar" OnClick="btn_Login_Click" />
					    </div>
                    </form>
				</div>
			</div>
		</div>
	</div>
</div>
</body>
</html>
