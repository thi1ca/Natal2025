<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="top.ascx.vb" Inherits="Torra.top" %>
<div class="navbar-header">
					<a href="contas.aspx" class="logo-padding"><img src="assets/img/logo/logoPequeno.gif"></a>
					<!-- end navbar-header --><!-- begin header-nav -->
					<ul class="navbar-nav navbar-right">
						<li class="dropdown">
							<a href="#" data-toggle="dropdown" class="dropdown-toggle f-s-14 no-caret">
								<i class="fa fa-bell"></i>
								<span class="label">5</span>
							</a>
							<div class="dropdown-menu media-list dropdown-menu-right" id="notifications">
								<div class="dropdown-header">NOTIFICAÇÕES (5)</div>
								<a href="javascript:;" class="dropdown-item media">
									<div class="media-left">
										<i class="fa fa-bug media-object bg-silver-darker"></i>
									</div>
									<div class="media-body">
										<h6 class="media-heading">Correções de Bugs <i class="fa fa-exclamation-circle text-danger"></i></h6>
										<div class="text-muted f-s-10">3 minutes ago</div>
									</div>
								</a>
								<a href="javascript:;" class="dropdown-item media">
									<div class="media-left">
										<img src="assets/img/user/user-1.jpg" class="media-object" alt="" />
										<i class="fab fa-facebook-messenger text-blue media-object-icon"></i>
									</div>
									<div class="media-body">
										<h6 class="media-heading">John Smith</h6>
										<p>Conseguiu gerar relatório.</p>
										<div class="text-muted f-s-10">25 minutes ago</div>
									</div>
								</a>
								<a href="javascript:;" class="dropdown-item media">
									<div class="media-left">
										<img src="assets/img/user/user-2.jpg" class="media-object" alt="" />
										<i class="fab fa-facebook-messenger text-blue media-object-icon"></i>
									</div>
									<div class="media-body">
										<h6 class="media-heading">Bruno Chagas</h6>
										<p>Quisque pulvinar tellus sit amet sem scelerisque tincidunt.</p>
										<div class="text-muted f-s-10">35 minutes ago</div>
									</div>
								</a>
								<a href="javascript:;" class="dropdown-item media">
									<div class="media-left">
										<i class="fa fa-plus media-object bg-silver-darker"></i>
									</div>
									<div class="media-body">
										<h6 class="media-heading"> Novo Usuário</h6>
										<div class="text-muted f-s-10">1 hour ago</div>
									</div>
								</a>
								<a href="javascript:;" class="dropdown-item media">
									<div class="media-left">
										<i class="fa fa-envelope media-object bg-silver-darker"></i>
										<i class="fab fa-google text-warning media-object-icon f-s-14"></i>
									</div>
									<div class="media-body">
										<h6 class="media-heading"> Nova Mensagem de John</h6>
										<div class="text-muted f-s-10">2 hour ago</div>
									</div>
								</a>
								<div class="dropdown-footer text-center">
									<a href="javascript:;">Veja mais</a>
								</div>
							</div>
						</li>
						<li class="dropdown navbar-user">
							<a href="#" class="dropdown-toggle no-caret" data-toggle="dropdown">
								<img src="assets/img/user/usuario.gif" alt="" /> <asp:Label ID="labNome" runat="server" class="d-none d-md-inline"></asp:Label>
								<b class="caret"></b>
							</a>
							<div class="dropdown-menu dropdown-menu-right">
								<a href="javascript:;" class="dropdown-item">Editar Cadastro</a>
								<a href="javascript:;" class="dropdown-item">Configurações</a>
								<a href="javascript:;" class="dropdown-item">Ajuda</a>
								<a href="javascript:;" class="dropdown-item"><span class="badge badge-danger pull-right">2</span> Avalie</a>
								<div class="dropdown-divider"></div>
								<a href="logoff.aspx" class="dropdown-item">Sair</a>
							</div>
						</li>
					</ul>
					<!-- end header-nav -->
					<button type="button" class="navbar-toggle" data-click="sidebar-toggled">
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
					</button>
				</div>