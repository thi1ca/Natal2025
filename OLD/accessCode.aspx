<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/semMenu.Master" CodeBehind="accessCode.aspx.vb" Inherits="Torra.accessCode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row no-gutters">
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-4">
                        <h3 class="text-white text-center">
                            <strong>Código de Acesso</strong> </h3>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
                        <div class="form-group stap select-cpf">
                            <div class="icon mb-1 d-flex align-items-center">
                                <i class="d-flex align-items-center justify-content-center orange-bg"><img src="assets/image/stap-01-start.svg" alt=""></i>
                                <div class="pl-2">
                                    <strong>Documentos de Identificação</strong>
                                </div>
                            </div>
                            <span class="has-float-label mb-2 inser-cpf">
                                <label for="cpf" class="floatlabel color2">Seu CPF Informado</label>
                                <asp:TextBox ID="tbCPF" class="form-control form-control-lg cpf" inputmode="numeric" name="cpf"  runat="server" Enabled="False" Text=" 000.000.000-00"></asp:TextBox>
                            </span>
                        </div>

                        <div class="form-group stap select-opt stap-next">
                            <div class="icon mb-2 d-flex align-items-center">
                                <i class="d-flex align-items-center justify-content-center"><img src="assets/image/stap-02.svg" alt=""></i>
                                <div class="pl-2">
                                    <h5 class="mb-0">Passo 1</h5>
                                    <strong>Selecione uma opção e receba o código:</strong>
                                </div>
                            </div>
                            <span class="warp-label">
                                <div class="custom-control custom-radio custom-control-inline form-check input-group-lg my-0">
                                     <asp:RadioButton ID="rbOpcao1" class="form-check-input " runat="server" GroupName="CodAcesso"  />
                                    
                                    <label class="custom-control-label mask-phone form-check-label ml-1" for="ContentPlaceHolder1_rbOpcao1">
                                      Whatsapp: <asp:Label ID="labCelular" runat="server" Text="15981744017"></asp:Label><span></span>
                                    </label>
                                </div>
                                <div class="custom-control custom-radio custom-control-inline form-check input-group-lg my-0">
                                     <asp:RadioButton ID="rbOpcao2" class="form-check-input" runat="server" GroupName="CodAcesso"  />
                                    
                                    <label class="custom-control-label mask-email form-check-label ml-1" for="ContentPlaceHolder1_rbOpcao2">
                                      E-mail: <asp:Label ID="labEmail" runat="server" Text="marcelo.costa@lojastorra.com.br"></asp:Label><span></span><i>lojastorra.com.br</i><i></i>
                                    </label>
                                </div>
                            </span>
                        </div>
                        <div class="form-group stap stap-next" style="color:white" id="divCodigo" runat="server" visible="false">
                            <div class="icon mb-2 d-flex align-items-center">
                                <i class="d-flex align-items-center justify-content-center"><img src="assets/image/stap-03.svg" alt=""></i>
                                <div class="pl-2">
                                    <h5 class="mb-0">Passo 2</h5>
                                    <strong>Insira o código para validação</strong>
                                </div>
                            </div>
                            <span class="has-float-label remove">
                                <div class="container-fluid no-gutters position-relative z-index-10">
                                    <div class="row">
                                        <div class="col-3 px-1 px-sm-2 px-md-2 px-lx-2 box-number">
                                            <div class="input-number input-group input-group-lg mb-3">
                                                <asp:TextBox ID="tbNumAcesso1" class="form-control py-2 number" inputmode="numeric" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" maxlength="1" name="numbervalid1" required="True" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-3 px-1 px-sm-2 px-md-2 px-lx-2 box-number">
                                            <div class="input-number input-group input-group-lg mb-3">
                                                <asp:TextBox ID="tbNumAcesso2" class="form-control py-2 number" inputmode="numeric" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" maxlength="1" name="numbervalid2" required="True" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-3 px-1 px-sm-2 px-md-2 px-lx-2 box-number">
                                            <div class="input-number input-group input-group-lg mb-3">
                                                <asp:TextBox ID="tbNumAcesso3" class="form-control py-2 number" inputmode="numeric" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" maxlength="1" name="numbervalid3" required="True" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-3 px-1 px-sm-2 px-md-2 px-lx-2 box-number">
                                            <div class="input-number input-group input-group-lg mb-3">
                                                <asp:TextBox ID="tbNumAcesso4" class="form-control py-2 number" inputmode="numeric" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" maxlength="1" name="numbervalid4" required="True" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </span>
                        </div>
                        <asp:Button ID="butProximo" class="btn btn-primary bt-step btn-lg btn-block mt-4" runat="server" Text="AVANÇAR" /><asp:TextBox ID="tbControle" Visible="false" runat="server"></asp:TextBox><asp:TextBox ID="tbContador" Visible="false" runat="server"></asp:TextBox>
                        
                    </div>

                    <a class="btn-lg btn-block voltar-login text-white text-center mt-4 mb-4" href="index.aspx" role="button"><img src="assets/image/arrow-left.svg" alt=""> VOLTAR AO LOGIN</a>
                </div>
</asp:Content>
