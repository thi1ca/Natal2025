<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Adm/admLogado.Master" CodeBehind="regularizaNumeroDaSorte.aspx.vb" Inherits="Natal2025.regularizaNumeroDaSorte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <main role="main" class="container mb-5">
        <section  class="mb-3 mb-md-5">
            <div class="row mt-3 mt-md-5 align-items-center">
                <div class="col-8 col-sm-8 col-md-6 col-lg-6 col-xl-6 text-left text-sm-left text-md-left text-lg-left text-xl-left">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb p-0 ">
                            <li class="breadcrumb-item"><a href="dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Regulariza Números da Sorte</li>
                        </ol>
                    </nav>
                </div>
                <div class="col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6 text-right text-sm-right text-md-right text-lg-right text-xl-right fixed-mobile">
                    
                </div>
                
            </div>
        </section>

            <section class="filter">
            <div class="formSetup">
                <div class="row">
                    <div class="bt-filter col-12 col-sm-6 col-md-6 col-lg-12 col-lx-12 text-left link-underline-primary">
						<asp:LinkButton ID="butSemNumeros" runat="server" class="btn text-uppercase ml-3 btn-md  d-md-block">Clientes cadastrados com aceite, mas sem números da sorte</asp:LinkButton>
                    </div>
                </div>

				  <div class="row">
                    <div class="bt-filter col-12 col-sm-6 col-md-6 col-lg-12 col-lx-12 text-left link-underline-primary">
						<asp:LinkButton ID="butDeduplicar" runat="server" class="btn text-uppercase ml-3 btn-md  d-md-block">Números da sorte duplicados, irá deduplicar 5</asp:LinkButton>
                    </div>
                </div>
 
            </div>
                <p></p>
                <p></p>
                 <div class="panel-body">
				
					<div class="table-responsive" id="tabelaSemPaginacao">
								<table id="data-table-buttons" class="table table-striped m-b-0">
									<thead>
										<tr>
											<th class="width-50">Data</th>
											<th>Nome</th>
											<th class=" width-120 text-left" nowrap>CPF</th>
											<th class="coluna-fantasma-xs width-50 text-center">Email</th>
											<th class="coluna-fantasma width-50 text-right">Valor</th>
											<th class="width-60 text-center">cli_id</th>
											<th class="width-20 text-center">Cup_id</th>
                                            <th class="width-20 text-center"></th>
										</tr>
									</thead>
									<tbody>
											<asp:repeater id="Repeater1" runat="server" >
												<ItemTemplate>
												<tr>
											<td><label title="<%# Container.DataItem("cup_cupom_data") %>" data-toggle="tooltip"><%# FuncCalendario(Container.DataItem("cup_cupom_data")) %></label></td>
											<td><label><%#Container.DataItem("cli_nome")%></label></td>
											<td class="text-right text-primary text-sm-left" style="font-size: 0.9em;" nowrap><%# FuncCPF(Container.DataItem("cli_cpf"))%></td>
											<td class="coluna-fantasma-xs text-right text-danger"><%# Container.DataItem("cli_email")%></td>
											<td class="coluna-fantasma text-right"><%#Container.DataItem("cup_valor") %><%#funcTACC(Container.DataItem("TACC")) %></td>
											<td class="f-w-700 text-right"><%# Container.DataItem("cli_id") %></td>
                                                    <td class="f-w-700 text-right"><%# Container.DataItem("cup_id") %></td>
											
											<td class="with-btn text-right" nowrap>												
												<asp:Button ID="butGerarNumeros" runat="server" CssClass="btn bt-save btn-sm " Text="Gerar Num"></asp:Button>
											</td>
										</tr>
												</ItemTemplate>
											</asp:repeater>
									</tbody>
									 
								</table>
							</div>
							<!-- end table-responsive -->
				</div>
        </section>


         </main>
</asp:Content>
