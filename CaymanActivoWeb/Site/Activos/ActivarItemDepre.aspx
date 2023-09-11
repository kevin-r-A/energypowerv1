<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ActivarItemDepre.aspx.cs" Inherits="Site_Activos_ActivarItemDepre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="../../Bootstrap/js/jquery.js"></script>
    <script type="text/javascript" src="msg/lib/alertify.js"></script>
    <link href="msg/themes/alertify.core.css" rel="stylesheet" />
    <link href="msg/themes/alertify.default.css" rel="stylesheet" />
    <script type="text/jscript">
        $(document).ready(function () {

            $(".input-group-btn .dropdown-menu li a").click(function () {
                var selText = $(this).html();
                var id = $(this).id;
                //working version - for single button //
                //$('.btn:first-child').html(selText+'<span class="caret"></span>');  
                //working version - for multiple buttons //
                $(this).parents('.input-group-btn').find('.btn-search').html(selText);

                if ($(this)[0].id == "CB")
                    op = 1;//codigo barras
                else if ($(this)[0].id == "NS")
                    op = 2;//serie
                else if ($(this)[0].id == "CS")
                    op = 3;//codigo secundario
            });
        });

        function VerificaCodigo() {
            var codigo = $('#txtBusCodBarras').val();
            $.ajax({
                type: "POST",
                url: "ActivarItemDepre.aspx/VerificaCodigo",
                data: "{'codigo':'" + codigo + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (response, status, p3, p4) {
                    debugger;
                    var r = response.d;
                    if (r[0] == "ok") {
                        $('#desc_item').html(r[1]);
                        $('#div_Datos').css('display', '');
                        $('#txtBusCodBarras').val(r[2])
                        alertify.success("<strong>OK!</strong>"+" Item Encontrado");
                    }
                    else {
                        alertify.error("<strong>Error!</strong>" + " " + r[0]);
                        $('#desc_item').html('');
                        $('#div_Datos').css('display', 'none');
                    }

                },
                failure: function (response, status, p3, p4) {
                    $('#desc_item').html('');
                    $('#div_Datos').css('display', 'none');
                    alertify.error("<strong>Error!</strong>" + " " +response.responseText);
                },
                error: function (response, status, p3, p4) {
                    $('#desc_item').html('');
                    $('#div_Datos').css('display', 'none');
                    alertify.error("<strong>Error!</strong>" +" "+ response.responseText);
                },

            });
        }

        function IngresaDepre() {
            debugger;
            var datepicker = $find("<%= datefechacompra.ClientID %>");
            var fecha = datepicker.get_selectedDate();
            if (fecha != null) {
                var f = fecha.toLocaleDateString();
                $.ajax({
                    type: "POST",
                    url: "ActivarItemDepre.aspx/InsertDepreciacion",
                    data: "{'codigo':'" + $('#txtBusCodBarras').val() + "','fechainidepre':'" + f + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',
                    success: function (response, status, p3, p4) {
                        debugger;
                        var r = response.d;
                        if (r == "ok") {
                            $('#desc_item').html('');
                            $('#div_Datos').css('display', 'none');
                            $('#txtBusCodBarras').val('')
                            alertify.success("<strong>OK!</strong>" + " Item ACTIVADO para GENERAR DEPRECIACIONES!");
                        }
                        else {
                            alertify.error("<strong>Error!</strong>" + " " + r);
                            $('#desc_item').html('');
                            $('#div_Datos').css('display', 'none');
                        }

                    },
                    failure: function (response, status, p3, p4) {
                        $('#desc_item').html('');
                        $('#div_Datos').css('display', 'none');
                        alertify.error("<strong>Error!</strong>" + " " + response.responseText);
                    },
                    error: function (response, status, p3, p4) {
                        $('#desc_item').html('');
                        $('#div_Datos').css('display', 'none');
                        alertify.error("<strong>Error!</strong>" + " " +response.responseText);
                    },

                });
            }
            else {
                alertify.error("<strong>Error!</strong>" + " " + "Ingrese Fecha de Inicio de Depreciación");
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <br />
    <br />
    <div id="divBuscar" class="container">
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-12">
            </div>
            <div class="col-lg-6 col-md-6 col-sm-12">
                <div class="input-group">
                    <input id="txtBusCodBarras" type="text" name="txtBusCodBarras" class="form-control textoCtrl" />
                    <div class="input-group-btn">
                        <button type="button" class="btn btn-search btn-primary" onclick="VerificaCodigo()">
                            <span class="glyphicon glyphicon-search"></span>
                            <span class="label-icon">Codigo de Barras</span>
                        </button>
                        <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" style="height: 34px">
                            <span class="caret"></span>
                        </button>
                        <ul class="dropdown-menu pull-right" role="menu">
                            <li>
                                <a href="#" id="CB">
                                    <span class="glyphicon glyphicon-search"></span>
                                    <span class="label-icon">Codigo de Barras</span>
                                </a>
                            </li>
                            <li>
                                <a href="#" id="NS">
                                    <span class="glyphicon glyphicon-search"></span>
                                    <span class="label-icon">Número de Serie</span>
                                </a>
                            </li>
                            <li>
                                <a href="#" id="CS">
                                    <span class="glyphicon glyphicon-search"></span>
                                    <span class="label-icon">Codigo Secundario</span>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
            </div>
        </div>
        <br />
        <div class="row">
            <div id="div_Activo">
                <div class="col-lg-3 col-md-3 col-sm-12">
                </div>
                <div class="col-lg-6 col-md-6 col-sm-12">
                    <div id="div_Datos" style="display: none">
                        <h4>DESCRIPCIÓN: </h4>
                        <h5><span id="desc_item"></span></h5>
                        <br />
                        <h4>FECHA INICIO DEPRECIACION: </h4>
                        <telerik:RadDatePicker
                            ID="datefechacompra" runat="server" EnableTyping="False" MaxDate="2099-01-01"
                            MinDate="" Width="215px">
                            <Calendar
                                UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                ViewSelectorText="x">
                            </Calendar>
                            <DateInput DateFormat="dd/MM/yyyy"
                                DisplayDateFormat="dd/MM/yyyy" ReadOnly="True">
                            </DateInput>
                            <DatePopupButton
                                HoverImageUrl="" ImageUrl="" />
                        </telerik:RadDatePicker>
                        <br />
                        <br />
                        <button id="btnGuardar" type="button" class="btn btn-danger btn-md" onclick="IngresaDepre()">
                            <i class="glyphicon glyphicon-usd"></i>
                            ACTIVAR DEPRECIACION
                        </button>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-12">
                </div>
            </div>
        </div>
    </div>
</asp:Content>

