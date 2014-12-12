<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="PageColor.aspx.cs" Inherits="mods_general_PageColor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">

    <link href="../src/plugins/Color/colpick/css/colpick.css" rel="stylesheet" />
    <script src="../src/plugins/Color/colpick/js/colpick.js"></script>
    <script src="../src/plugins/Color/js/jquery.min.js"></script>
    <script src="../src/plugins/Color/js/plugin.js"></script>
    <style type="text/css">
#picker3 {
	margin:0;
	padding:0;
	border:0;
	width:70px;
	height:30px;
	border-right:30px solid green;
	line-height:30px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <div class="example-ex">
			# <input type="text" id="picker3">
		</div>
    <form id="Form1" runat="server"> 
    <div class="row">
	    <div id="breadcrumb" class="col-md-12">
		    <ol class="breadcrumb">
			    <li><a href="../Default.aspx">Dashboard</a></li>
			    <li><a href="#">Color Pagina</a></li>
		    </ol>
	    </div>
    </div>

    <div class="row">
	    <div class="col-xs-12 col-sm-12">
		    <div class="box">
			    <div class="box-header">
				    <div class="box-name">
					    <i class="fa fa-search"></i>
					    <span>Registro</span>
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
				    <h4 class="page-header">Color </h4>
                    <div id="Messages" runat="server"></div>
				    <div class="form-horizontal" role="form">
                        <div class="form-group">
                              <label  class="col-sm-2 control-label">Header-Footer
                              </label>
						    <div class="col-sm-4">
							    <input type="text" id="txtHeaderFooter" runat="server" class="picker3" 
                                    >
                                
						    </div>
						    <label  class="col-sm-2 control-label">Menu</label>
						    <div class="col-sm-4">
							    <input type="text" id="TxtMenu" runat="server" class="form-control" 
                                    placeholder="Color Menu" data-toggle="tooltip" data-placement="bottom" 
                                    title="Color Menu">
						    </div>
                            
					    </div>
					    <div class="form-group">
						    
                             <label class="col-sm-2 control-label" for="form-styles">Imagen Fondo</label>
						    <div class="col-sm-2">
                                <asp:FileUpload ID="flIcon" runat="server" />
						    </div>
					    </div>
                         
                      <div class="clearfix"></div>
					<div class="form-group">
						<div class="col-sm-2">
                            <asp:Button ID="SaveData" runat="server" Text="Guardar" class="btn btn-primary btn-label-left" OnClick="SaveData_Click" />
						</div>
                        <div class="col-sm-2">
                            <asp:Button ID="UpdateData" runat="server" Text="Cancelar" class="btn btn-primary btn-label-left btn-danger" Enabled="True" />
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

