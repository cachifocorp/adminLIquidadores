<%@ Page Language="C#" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="mods_profile_profile" %>

<div class="row">
	<div id="breadcrumb" class="col-md-12">
		<ol class="breadcrumb">
			<li><a href="../Default.aspx">Dashboard</a></li>
			<li><a href="#">Perfil</a></li>
		</ol>
	</div>
</div>
<div class="row">
	<div class="col-xs-12 col-sm-12">
		<div class="box">
			<div class="box-header">
				<div class="box-name">
					<i class="fa fa-search"></i>
					<span>Informacion del Perfil</span>
				</div>
				<div class="box-icons">
					<a class="collapse-link">
						<i class="fa fa-chevron-up"></i>
					</a>
					<a class="expand-link">
						<i class="fa fa-expand"></i>
					</a>
					<a class="close-link">
						<i class="fa fa-times"></i>
					</a>
				</div>
				<div class="no-move"></div>
			</div>
			<div class="box-content">
				<h4 class="page-header">Información Perfil</h4><div id="info"></div>
				<form id="defaultForm"   class="form-horizontal" role="form"  >
                    
					<div class="form-group">
						<label class="col-sm-2 control-label">Nombre/s</label>
						<div class="col-sm-4">
							<input type="text" id="name" value="<%=pr.Name %>" class="form-control" placeholder="Nombre/s" data-toggle="tooltip" data-placement="top" title="Ingrese El nombre">
						</div>
						<label class="col-sm-2 control-label">Apellidos</label>
						<div class="col-sm-4">
							<input type="text" id="lastName" value="<%=pr.Last_name %>" class="form-control" placeholder="Apellidos" data-toggle="tooltip" data-placement="top" title="Ingrese el apellido">
						</div>
					</div>
					<div class="form-group">
						<label class="col-sm-2 control-label">Identificación</label>
						<div class="col-sm-4">
							<input type="text" id="identification" value="<%=pr.Identification %>" class="form-control" placeholder="ej xxxxxxx" data-toggle="tooltip" data-placement="top" title="Ingrese C.C/ TI etc.">
						</div>
						
                        <label class="col-sm-2 control-label">Direccion</label>
						<div class="col-sm-4">
							<input type="text" id="address" value="<%=pr.Address %>" class="form-control" placeholder="Dirección" data-toggle="tooltip" data-placement="top" title="Direccion de residencia">
						</div>                       
					</div>
                    <div class="form-group has-feedback">
						<label class="col-sm-2 control-label">Telefono</label>
						<div class="col-sm-4">
							<input type="tel"id="phone" value="<%=pr.Phone %>" class="form-control" placeholder="Telefono" data-toggle="tooltip" data-placement="top" title="Nuemero telefonico ">
						</div>
						<label class="col-sm-2 control-label">Fecha de Nacimiento</label>
						<div class="col-sm-2">
							<input type="text" id="bornDate" value="<%=pr.Born_date.ToString("yyyy/MM/dd") %>" id="input_date" class="form-control" placeholder="Date">
							<span class="fa fa-calendar txt-danger form-control-feedback"></span>
						</div>
					</div>

                    <div class="form-group">
							<label class="col-sm-1 control-label">Pais</label>
							<div class="col-sm-3" id="cContry">
							</div>
                        <label class="col-sm-1 control-label">Departamento</label>
							<div class="col-sm-3"  id="cState">
                               <select id="state" class="populate placeholder col-sm-1">
                                   <option>seleccione</option>
                               </select>
							</div>
                        <label class="col-sm-1 control-label">Ciudad</label>
							<div class="col-sm-3" id="cCities">
                               <select id="city"class="populate placeholder col-sm-1">
                                   <option>seleccione</option>
                               </select>
							</div>
						</div>
                    <div class="clearfix"></div>
					<div class="form-group">
                        <div class="col-sm-2">
							<button type="button" id="saveData" onclick="SaveDataProfile()"class="btn btn-primary btn-label-left">
							<span><i class="fa fa-clock-o"></i></span>
								Guardar
							</button>
						</div>
                        

					</div>
                </form>
                </div>
            </div>
        </div>
</div>

<div class="row">
	<div class="col-xs-12 col-sm-12">
		<div class="box">
			<div class="box-header">
				<div class="box-name">
					<i class="fa fa-search"></i>
					<span>Registration form</span>
				</div>
				<div class="box-icons">
					<a class="collapse-link">
						<i class="fa fa-chevron-up"></i>
					</a>
					<a class="expand-link">
						<i class="fa fa-expand"></i>
					</a>
					<a class="close-link">
						<i class="fa fa-times"></i>
					</a>
				</div>
				<div class="no-move"></div>
			</div>
			<div class="box-content">
				<h4 class="page-header">Cambio de informacion de usuario</h4>
				<form class="form-horizontal" role="form">
					<div class="form-group">
						<label class="col-sm-2 control-label">Username</label>
						<div class="col-sm-4">
							<input type="text" class="form-control"  value="<%=us.Username %>" placeholder="Nombre de usuario" data-toggle="tooltip" data-placement="top" title="Nombre del usuario" disabled>
						</div>
					</div>
                    <h4 class="page-header">Cambio de Contraseña</h4>
                    <div id="mess"></div>
                    <div class="form-group">
						<label class="col-sm-2 control-label">Nueva Contraseña</label>
						<div class="col-sm-4">
							<input id="Pass" type="text" class="form-control" placeholder="Nueva contraseña" data-toggle="tooltip" data-placement="top" title="Ingrese la nueva contraseña" >
						</div>
					</div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Otra vez</label>
						<div class="col-sm-4">
							<input id="chkpass" type="text" class="form-control" placeholder="nueva contraseña" data-toggle="tooltip" data-placement="top" title="Nuevamente Ingrese la nueva contraseña">
						</div>
					</div>
                    <div class="form-group">
						<div class="col-sm-9 col-sm-offset-3">
							<button type="button" class="btn btn-primary" onclick="ChangePass()">Cambiar</button>
						</div>
					</div>
				</form>
			</div>
		</div>
	</div>
</div>

<script type="text/javascript">
    // Run Select2 plugin on elements
    function DemoSelect2() {
        ChargeCountries();
       
        //$('#state').select2();
        //$('#city').select2();
    }

    function ChargeCountries() {        
           $.ajax({
               url: "profile/profile.aspx/chargeContries",
               type: 'post',
               data: '{name: "Hola" }',
               contentType: "application/json; charset=utf-8",
           		success: function (response) {
           		     //alert(response.d);
           		    $("#cContry").html(response.d);
           		    $('#contry').select2();
           		    chargeState();           		   
           		},
           		failure: function (response) {
           		    alert(response.d);
           		}
           	});
    }

    function chargeState() {
        var c = $("#contry").val();
        $.ajax({
            url: "profile/profile.aspx/chargeStates",
            type: 'post',
            data: '{id_contry: "' + c + '" }',
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                //alert(response.d);
                $("#cState").html(response.d);
                $('#state').select2();
                chargeCities();
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }

    function chargeCities() {
        var c = $("#state").val();
        $.ajax({
            url: "profile/profile.aspx/chargeCities",
            type: 'post',
            data: '{id_state: "' + c + '" }',
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                //alert(response.d);
                $("#cCities").html(response.d);
                $('#city').select2();
            },
            failure: function (response) {
                console.log(response.d);
            }
        });
    }

    function ChangePass() {
        if ($("#Pass").val() === $("#chkpass").val()) {

            $.ajax({
                url: "profile/profile.aspx/changePass",
                type: 'post',
                data: '{pass: "' + $("#Pass").val() + '",id:"'+<%=us.Id%>+'" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    console.log(response.d);
                    if (response.d == true) {
                        $("#mess").html("<p class=\"bg-success\">Información Guardada</p>");
                    } else {
                        $("#mess").html("<p class=\"bg-Danger\">Error! Información no guardada</p>");
                    }
                },
                failure: function (response) {
                    console.log(response.d);
                }
            });
        } else {
            alert("las Contraceñas No Coniciden");
        }
    }

    
        function SaveDataProfile() {
            var profile = {};
            profile.Id = "<%=pr.Id%>";
            profile.Name = $("#name").val();
            profile.Last_name = $("#lastName").val();
            profile.Identification = $("#identification").val();
            profile.User_id = "<%=pr.User_id%>";
            profile.Born_date = $("#bornDate").val();
            profile.City_id = $("#city").val();
            profile.Address = $("#address").val();
            profile.phone = $("#phone").val();
        
            $.ajax({
                url: "profile/profile.aspx/SaveDataProfile",
                type: 'post',
                data: '{profile:' + JSON.stringify(profile) + ' }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    console.log(response.d);
                    if (response.d == true) {
                        $("#info").html("<p class=\"bg-success\">Información Guardada</p>");
                    } else {
                        $("#info").html("<p class=\"bg-Danger\">Error! Información no guardada</p>");
                    }
                },
                failure: function (response) {
                    alert(response.d);
                }
            });

       
        }

   
        $(document).ready(function () {
            FormLayoutExampleInputLength($(".slider-style"));
            // Initialize datepicker
        
            $('#input_date').datepicker({ setDate: new Date() });
            // Add tooltip to form-controls
            $('.form-control').tooltip();
            LoadSelect2Script(DemoSelect2);
            // Load example of form validation
            LoadBootstrapValidatorScript(DemoFormValidator);
            // Add drag-n-drop feature to boxes
            WinMove();
        });
</script>


   