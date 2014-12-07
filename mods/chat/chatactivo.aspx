<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="chatactivo.aspx.cs" Inherits="mods_chat_chatespera" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <form id="form1" runat="server">
    <div class="row">
        <div class="box-header">
            <div class="box-name">
                <i class="fa fa-usd"></i>
                <span>Chats en Espera de atención</span>
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
        <div class="col-xs-12 col-sm-12">
            <div class="box">
                <div class="box-content no-padding">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                          
                            <asp:Timer ID="Timer1"  Interval="1000"  runat="server" OnTick="Timer1_Tick"></asp:Timer>
                             <table class="table table-bordered table-striped table-hover table-heading table-datatable" id="datatable-1">
					        <thead>
						        <tr>
                                    <th>Opción</th>
                                    <th>Sala</th>
                                    <th>Fecha Hora</th>
                                    <th>Cliente</th>
                                    <th>Correo</th>
                                    
						        </tr>
					        </thead>
					        <tbody id="List_menus" runat="server">
					       <div id="divcontenTabla"></div>
                            </tbody>
                        </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>



                    
                </div>
            </div>
        </div>
    </div>

        </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="customScripts" runat="Server">
</asp:Content>

