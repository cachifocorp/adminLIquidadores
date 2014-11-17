<%@ Page Title="" Language="C#" MasterPageFile="~/site/Pages/masterPages/baseLine.master" AutoEventWireup="true" CodeFile="law.aspx.cs" Inherits="Pages_About_policies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content_page" Runat="Server"> 
    <h2 class="title_1 center bold_brown_text">Resoluciones Supersalud</h2>
    <hr />
    <form runat="server">
        <asp:GridView ID="tblNormatividad" runat="server">
            <Columns>
                <asp:BoundField HeaderText="N&#176;"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="scripts_down" Runat="Server">
    <script>
        $(function () {
            $(".in").attr("class", "span4");
        });
    </script>
</asp:Content>

