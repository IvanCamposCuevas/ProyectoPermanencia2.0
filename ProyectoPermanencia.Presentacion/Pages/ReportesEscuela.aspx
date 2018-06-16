﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ReportesEscuela.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.ReportesEscuela" %>
<asp:Content ID="ContentHeadReportesEs" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="ContentReportesEs"  runat="server" ContentPlaceHolderID="ContentPlaceHolderReportesEs" >
    <div class="conteiner">
        <div class="row">
            <div class="col-md-2 jumbotron modal-content" style="margin: 10px; margin-left: 45px; border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
                <h4>Seleccione una opción para generar reporte</h4>
                <br />                
            </div>
            <div class="Tabs col-md-6" style="float: left;">
                <ul class="nav nav-tabs">
                    <li><a href="Reportes.aspx">Global</a></li>
                    <li><a href="ReportesSede.aspx">Sede</a></li>
                    <li class="active"><a href="#">Escuela</a></li>
                    <li><a href="ReportesCarrera.aspx">Carrera</a></li>
                    <li><a href="ReportesJornada.aspx">Jornada</a></li>


                </ul>
                <br>
            </div>
            <div class="col-md-8 jumbotron modal-content" style="border: solid; margin: 10px; padding-right: 0px" />

        </div>

    </div>
</asp:Content>
