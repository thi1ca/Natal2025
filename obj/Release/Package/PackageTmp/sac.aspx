<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/semMenu.Master" CodeBehind="sac.aspx.vb" Inherits="Natal_torra.sac" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row no-gutters sac">
        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 content-filter pb-3">
            <div class="erro-busca text-center">
                <img src="assets/image/sac.svg" alt="SAC" class="">
                <h4><strong class="text-red">SAC</strong></h4>
            </div> 
        </div>
        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 d-flex flex-column ganhadores">
                <div class="card mb-2 text-blue">
                    <a href="mailto:lojavirtual@lojastorra.com.br" target="_blank">
                        <div class="row no-gutters">
                            <div class="col-3 d-flex justify-content-center align-items-center">
                                <img src="assets/image/email.svg" alt="Ganhador" class="w-25">
                            </div>
                            <div class="col-9 text-left">
                                <div class="card-body">
                                    <h2 class="m-0 text-orange">Enviar e-mail</h2>
                                    <p class="m-0">lojavirtual@lojastorra.com.br</p>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="card mb-2 text-blue">
                    <a href="https://wa.me/551140209766" target="_blank">
                        <div class="row no-gutters">
                            <div class="col-3 d-flex justify-content-center align-items-center">
                                <img src="assets/image/whatsapp.svg" alt="Ganhador" class="w-25">
                            </div>
                            <div class="col-9 text-left">
                                <div class="card-body">
                                    <h2 class="m-0 text-orange">(11) 4020-9766</h2>
                                    <p class="m-0">Seg a Sexta das 8h às 17h<br>
                                        <small>Exceto feriados</small>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="card mb-2 text-blue">
                    <a href="tel:+551140209766" target="_blank">
                        <div class="row no-gutters">
                            <div class="col-3 d-flex justify-content-center align-items-center">
                                <img src="assets/image/phone.svg" alt="Ganhador" class="w-25">
                            </div>
                            <div class="col-9 text-left">
                                <div class="card-body">
                                    <h2 class="m-0 text-orange">(11) 4020-9766 - Opção 3</h2>
                                    <p class="m-0">Seg a Sexta das 8h às 17h<br>
                                        <small>Exceto feriados</small>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
                
                <a class="btn btn-primary bt-inline btn-lg btn-block mt-4" href="index.aspx" role="button">VOLTAR PARA A TELA INICIAL</a>

        </div>
    </div>
</asp:Content>
