<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="menu.ascx.vb" Inherits="Torra.menu" %>
<div data-scrollbar="true" data-height="100%">
				<!-- begin sidebar user -->
				<ul class="nav">
					<li class="nav-profile">
						<a href="javascript:;" data-toggle="nav-profile" class="lateral-object">
							<div class="cover with-shadow"></div>
							<div class="image">
								<img src="assets/img/user/usuario.gif" alt="" />
							</div>
							<div class="info lateral-object">
								<asp:Label ID="labNome" runat="server" Visible="true"></asp:Label>
								<a href="logoff.aspx"><small>Sair</small></a>
							</div>
							<div style="clear: both;"></div>
						</a>
					</li>
					<li>
						<ul class="nav nav-profile">
							<li><a href="javascript:;"><i class="fa fa-cog"></i> Configurações</a></li>
							<li><a href="javascript:;"><i class="fa fa-pencil-alt"></i> Avalie</a></li>
							<li><a href="javascript:;"><i class="fa fa-question-circle"></i> Ajuda</a></li>
						</ul>
					</li>
				</ul>
				<!-- end sidebar user -->
				<!-- begin sidebar nav -->
				<ul class="nav"><li class="nav-header">MENU DE OPÇÕES</li>
					<li class="has-sub active">
						<a href="javascript:;">
							<b class="caret"></b>
							<i class="fa fa-star"></i>
							<span>Menu Principal</span>
						</a>
						<ul class="sub-menu">
							<li class="active"><a href="home.aspx">Home</a></li>
							<li id="linkCampanhas" runat="server"><a href="retry.aspx">Re-Try</a></li>
							<li><a href="pedidos.aspx">Pedidos Completos</a></li>
							<li><a href="incompletos.aspx">Pedidos incompletos</a></li>							
							<li><a href="estatisticas.aspx">Estatísticas</a></li>
						</ul>
					</li><!--
					 <li class="has-sub">
                        <a href="javascript:;">
                            <b class="caret pull-right"></b>
                            <i class="fa fa-map"></i>
                            <span>Orçamento</span>
                        </a>
                        <ul class="sub-menu">
                            <li><a href="ui_general.html">Orçamento</a></li>
                            <li><a href="ui_typography.html">Orçado vs Real</a></li>
                        </ul>
                    </li>
					<li class="has-sub">
	                    <a href="javascript:;">
	                        <b class="caret pull-right"></b>
	                        <i class="fa fa-chart-pie"></i>
	                        <span>Relatórios</span>
	                    </a>
	                    <ul class="sub-menu">
	                        <li><a href="ui_general.html">Entrada X Saída</a></li>
	                        <li><a href="ui_typography.html">Gastos por Categoria</a></li>
	                        <li><a href="ui_tabs_accordions.html">Gastos por Subcategoria</a></li>
	                        <li><a href="ui_unlimited_tabs.html">Evolução de Gastos Mensais</a></li>
	                        <li><a href="ui_modal_notification.html">Controle Orçamentário</a></li>
	                    </ul>
	                </li>
	                <li class="has-sub">
                        <a href="javascript:;">
                            <b class="caret pull-right"></b>
                            <i class="fa fa-list-ol"></i>
                            <span>Institucional</span>
                        </a>
                        <ul class="sub-menu">
                            <li><a href="form_elements.html">Ajuda</a></li>
                            <li><a href="form_plugins.html">Contato</a></li>
                            <li><a href="form_slider_switcher.html">lista de Bancos</a></li>
                            <li><a href="form_validation.html">Indique esse Site</a></li>
                            <li><a href="form_wizards.html">Regulamentos</a></li>
                            <li><a href="form_wizards_validation.html">Política de Privacidade</a></li>
                        </ul>
                    </li>
                    <li class="has-sub">
						<a href="javascript:;">
							<span class="badge pull-right">10</span>
							<i class="fa fa-key"></i>
							<span>Cadastro</span>
						</a>
						<ul class="sub-menu">
							<li><a href="index.html">Meus dados</a></li>
                            <li><a href="index_v2.html">Alterar foto</a></li>
                            <li><a href="index_v2.html">Alterar senha</a></li>
						</ul>
					</li>-->
                    <li class="has-sub" id="menuAdm" runat="server" visible="false">
                        <a href="javascript:;">
                            <b class="caret pull-right"></b>
                            <i class="fa fa-cogs"></i>
                            <span>Admin <span class="label label-theme m-l-5">NEW</span></span>
                        </a>
                        <ul class="sub-menu">
                           <li id="linkUsuarios" runat="server"><a href="Usuarios.aspx">Cadastro de usuários</a></li>
							<li id="linkEmpresas" runat="server"><a href="Empresas.aspx">Cadastro de empresas</a></li>
                            <li><a href="table_basic.html">Logs de Acesso</a></li>
                            <li><a href="table_basic.html">Quem está Online</a></li>
                        </ul>
                    </li>

					<!-- begin sidebar minify button -->
					<li><a href="javascript:;" class="sidebar-minify-btn" data-click="sidebar-minify"><i class="fa fa-angle-double-left"></i></a></li>
					<!-- end sidebar minify button -->
				</ul>
				<!-- end sidebar nav -->
			</div><asp:Label ID="labScript" runat="server" Visible="false"></asp:Label>