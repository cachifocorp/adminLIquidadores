<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="mods_profile_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <form  runat="server">
        <div class="row">
	<div id="breadcrumb" class="col-md-12">
		<ol class="breadcrumb">
			<li><a href="../Default.aspx">Dashboard</a></li>
			<li><a href="#">Users</a></li>
		</ol>
	</div>
</div>
<div class="row">
	<div class="col-xs-12 col-sm-12">
		<div class="box">
			<div class="box-header">
				<div class="box-name">
					<i class="fa fa-search"></i>
					<span>Registro de usuarios</span>
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
				<h4 class="page-header">Registro</h4>
                <div id="Message" runat="server"></div>
				<div class="form-horizontal" role="form">
                    	<div class="form-group">
						<label class="col-sm-2 control-label">Nombre de usuario</label>
						<div class="col-sm-4">
							<input type="text" id="txtName" runat="server" class="form-control" placeholder="Nombre de usuario" data-toggle="tooltip" data-placement="bottom" title="Ingrese nombre de usuario">
						</div>
					</div>
                </div>
                <div class="form-horizontal" role="form">
                    	<div class="form-group">
						<label class="col-sm-2 control-label">Password</label>
						<div class="col-sm-2">
							<input type="password" id="txtPassword" runat="server" class="form-control" placeholder="Nombre de usuario" data-toggle="tooltip" data-placement="bottom" title="Ingrese nombre de usuario">
						</div>
                        <label class="col-sm-2 control-label">Confirmacion Password</label>
						<div class="col-sm-2">
                            <asp:DropDownList ID="ddlRole" runat="server" DataSourceID="rolesrc" DataTextField="name" DataValueField="id"></asp:DropDownList>
						    <asp:SqlDataSource ID="rolesrc" runat="server" ConnectionString="<%$ ConnectionStrings:AMVConnectionString %>" SelectCommand="SELECT [id], [name] FROM [role]"></asp:SqlDataSource>
						</div>
                        
					</div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">dependencia</label>
						<div class="col-sm-2">
                            <asp:DropDownList ID="ddlDependence" runat="server" DataSourceID="dependenceSrc" DataTextField="name" DataValueField="id"></asp:DropDownList>
						    <asp:SqlDataSource ID="dependenceSrc" runat="server" ConnectionString="<%$ ConnectionStrings:AMVConnectionString %>" SelectCommand="SELECT [name], [id] FROM [dependence]"></asp:SqlDataSource>
						</div>
                    </div>
                    <div class="clearfix"></div>
					<div class="form-group">
						<div class="col-sm-2">
                            <asp:Button ID="SaveUser" runat="server" Text="Guardar" class="btn btn-primary btn-label-left" OnClick="SaveUser_Click" />
						</div>
					</div>
                </div>
            </div>
            </div>
        </div>
    </div>
        
    </form>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="customScripts" Runat="Server">
</asp:Content>

