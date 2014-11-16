<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="mods_Default" %>

<!DOCTYPE html>
<html lang="es">
	<head>
		<meta charset="utf-8">
		<title>AMV Administrador</title>
		<meta name="description" content="description">
		<meta name="author" content="DevOOPS">
		<meta name="viewport" content="width=device-width, initial-scale=1">
		<link href="src/plugins/bootstrap/bootstrap.css" rel="stylesheet">
		<link href="src/plugins/jquery-ui/jquery-ui.min.css" rel="stylesheet">
		<link href="http://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" rel="stylesheet">
		<link href='http://fonts.googleapis.com/css?family=Righteous' rel='stylesheet' type='text/css'>
		<link href="src/plugins/fancybox/jquery.fancybox.css" rel="stylesheet">
        <link href="src/plugins/fineuploader/fineuploader-4.3.1.css" rel="stylesheet" />
		<link href="src/plugins/fullcalendar/fullcalendar.css" rel="stylesheet">
		<link href="src/plugins/xcharts/xcharts.min.css" rel="stylesheet">
		<link href="src/plugins/select2/select2.css" rel="stylesheet">
		<link href="src/css/style.css" rel="stylesheet">
		<!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
		<!--[if lt IE 9]>
				<script src="http://getbootstrap.com/docs-assets/js/html5shiv.js"></script>
				<script src="http://getbootstrap.com/docs-assets/js/respond.min.js"></script>
		<![endif]-->
	</head>
<body>
<!--Start Header-->
<div id="screensaver">
	<canvas id="canvas"></canvas>
	<i class="fa fa-lock" id="screen_unlock"></i>
</div>
<div id="modalbox">
	<div class="devoops-modal">
		<div class="devoops-modal-header">
			<div class="modal-header-name">
				<span>Basic table</span>
			</div>
			<div class="box-icons">
				<a class="close-link">
					<i class="fa fa-times"></i>
				</a>
			</div>
		</div>
		<div class="devoops-modal-inner">
		</div>
		<div class="devoops-modal-bottom">
		</div>
	</div>
</div>
<header class="navbar">
	<div class="container-fluid expanded-panel">
		<div class="row">
			<div id="logo" class="col-xs-12 col-sm-2">
				<a href="Default.aspx">AMV <small>(Administrador)</small></a>
			</div>
			<div id="top-panel" class="col-xs-12 col-sm-10">
				<div class="row">
					<div class="col-xs-8 col-sm-4">
						<a href="#" class="show-sidebar">
						  <i class="fa fa-bars"></i>
						</a>
						<%--<div id="search">
							<input type="text" placeholder="Buscar"/>
							<i class="fa fa-search"></i>
						</div>--%>
					</div>
					<div class="col-xs-4 col-sm-8 top-panel-right">
						<ul class="nav navbar-nav pull-right panel-menu"  >
							<li class="dropdown">
								<a href="#" class="dropdown-toggle account" data-toggle="dropdown">
									<div class="avatar" id="admin_avatar" runat="server">
										
									</div>
									<i class="fa fa-angle-down pull-right"></i>
									<div class="user-mini pull-right">
										<span class="welcome">Bienvenido/a,</span>
										<span id="adminName" runat="server"></span>
									</div>
								</a>
								<ul class="dropdown-menu">
									<li>
										<a href="profile/profile.aspx" class="ajax-link">
											<i class="fa fa-user"></i>
											<span class="hidden-sm text">Profile</span>
										</a>
									</li>
									<li>
                                        <form runat="server">
                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                                                 <i class="fa fa-power-off"></i>
											    <span class="hidden-sm text">Cerrar sesion</span>
                                            </asp:LinkButton>  
                                        </form>                                      									 
									</li>
								</ul>
							</li>
						</ul>
					</div>
				</div>
			</div>
		</div>
	</div>
</header>
<!--End Header-->
<!--Start Container-->
<div id="main" class="container-fluid">
	<div class="row">
		<div id="sidebar-left" class="col-xs-2 col-sm-2">
			<ul class="nav main-menu" id="menuAdmin" runat="server">
			</ul>
		</div>
		<!--Start Content-->
		<div id="content" class="col-xs-12 col-sm-10">
			<div class="preloader">
				<img src="src/img/devoops_getdata.gif" class="devoops-getdata" alt="preloader"/>
			</div>
			<div id="ajax-content">
			</div>
            <div id="iframe_content" style="margin-left:-15px; margin-right:-15px"></div>
		</div>
		<!--End Content-->
	</div>
</div>
<!--End Container-->
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<!--<script src="http://code.jquery.com/jquery.js"></script>-->
<script src="src/plugins/jquery/jquery-2.1.0.min.js"></script>
<script src="src/plugins/jquery-ui/jquery-ui.min.js"></script>
<!-- Include all compiled plugins (below), or include individual files as needed -->
<script src="src/plugins/bootstrap/bootstrap.min.js"></script>
<script src="src/plugins/justified-gallery/jquery.justifiedgallery.min.js"></script>
<script src="src/plugins/tinymce/tinymce.min.js"></script>
<script src="src/plugins/tinymce/jquery.tinymce.min.js"></script>
<!-- All functions for this theme + document.ready processing -->
<script src="src/js/devoops.js"></script>

    <script>
        function getPage(page) {
            $("#ajax-content").html("");
            $("#iframe_content").html('<iframe src="' + page + '" style="width:100%; height:1200px; overflow-y: scroll;" frameborder="0" scrolling="auto" >');
        }
    </script>


</body>
</html>

