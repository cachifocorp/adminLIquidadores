<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="slider.aspx.cs" Inherits="mods_general_slider"  ValidateRequest="false" %>

<%@ Register src="../Controls/ucMultiFileUpload.ascx" tagname="ucMultiFileUpload" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
        <form id="Form1" runat="server">
                <div class="row">
	    <div id="breadcrumb" class="col-md-12">
		    <ol class="breadcrumb">
			    <li><a href="../Default.aspx">Dashboard</a></li>
			    <li><a href="#">Slider</a></li>
		    </ol>
	    </div>
    </div>
    <div class="row">
	    <div class="col-xs-12 col-sm-12">
		    <div class="box">
			    <div class="box-header">
				    <div class="box-name">
					    <i class="fa fa-search"></i>
					    <span>Configuracion del Slider(Usuario depenendencia)</span>
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
				    <h4 class="page-header">Slider Configuration</h4>
                    <div id="Messages" runat="server"></div>
				    <div class="form-horizontal" role="form">
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="form-styles">Nombre</label>
						        <div class="col-sm-4">
                                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
						        </div>
                        </div>
                        	<!--<div class="form-group">
						        <label class="col-sm-2 control-label" for="form-styles">Slider</label>
						        <div class="col-sm-10">
								        <textarea class="form-control" rows="5" id="taSlider" runat="server"></textarea>
						        </div>
					        </div>-->
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="form-styles">Nombre</label>
						        <div class="col-sm-4">
                        <asp:FileUpload ID="FilePublication" runat="server" />
                                    </div>
                            </div>

                       
                         <div class="clearfix"></div>
					    <div class="form-group">
						    <div class="col-sm-2">
                                <asp:Button ID="btnCreateSlider" runat="server" Text="Guardar" CssClass="btn btn-primary btn-label-left" OnClick="btnCreateSlider_Click"    />
						    </div>
                            <div class="col-sm-2">
                                <asp:Button ID="btnUpdate" runat="server" Text="Actualizar Slider" CssClass="btn btn-primary btn-label-left" Enabled="False" OnClick="btnUpdate_Click"     />
						    </div>
					    </div>
                    </div>

                </div>
            </div>
          </div>
        </div>


         <div class="row">
	        <div class="col-xs-12">
		        <div class="box">
			        <div class="box-header">
				        <div class="box-name">
					        <i class="fa fa-usd"></i>
					        <span>ListSlider</span>
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
			        <div class="box-content no-padding">
                       <table class="table table-bordered table-striped table-hover table-heading table-datatable" id="datatable-1">
					        <thead>
						        <tr>
                                    <th>Acciones</th>
                                    <th>Nombre Slider</th>
                                    <th>Fecha Registro</th>
						        </tr>
					        </thead>
					        <tbody id="List_sliders" runat="server">
					        <!-- Start: list_row -->
                            </tbody>
                        </table>
                         <div id="actions" runat="server"></div>
                    </div>
                    </div>
                </div>
            </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="customScripts" Runat="Server">
</asp:Content>

