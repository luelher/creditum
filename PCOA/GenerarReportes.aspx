<%@ Page CodeBehind="GenerarReportes.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="Creditum.PCOA.GenerarReportes" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<HTML>
	<HEAD>
		<title>Creditum - Generar Reportes</title>
		<meta content="True" name="vs_snapToGrid">
		<meta content="True" name="vs_showGrid">
		<script language="Javascript">
			var RCMensaje = "CREDITUM, su plataforma de información crediticia";
			function DeshabilitarClickDerecho(btnClick)
			{
				if (navigator.appName == "Netscape" && btnClick.which == 3)
				{ 
					alert(RCMensaje);
					return false;
				}
				else if (navigator.appName == "Microsoft Internet Explorer" && event.button == 2)
				{
					alert(RCMensaje);
					return false;
				}
			}
			document.onmousedown = DeshabilitarClickDerecho;
		</script>
		<!-- Information generated and read by Xara Webstyle. Do not edit this line. [Integrate (Theme);CreditumStyle;Theme Color 1;2201395;themecolour1;Theme Color 2;8255934;themecolour2;Background Color;16053492;themecolour3]
-->
		<!-- Template design (c) Xara Ltd 2003 -->
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<style type="text/css">BODY { FONT-SIZE: 9px; COLOR: #000000; FONT-FAMILY: "Trebuchet MS", Arial, Sans-serif; BACKGROUND-COLOR: #f4f4f4 }
	TABLE { FONT: 9pt "trebuchet ms", arial, sans-serif }
	P { MARGIN: 0px 30px 0px 0px }
	BLOCKQUOTE { MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #000000; MARGIN-RIGHT: 0px }
	OL { MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #000000 }
	UL { MARGIN-TOP: 0px; LIST-STYLE-IMAGE: url(Home_files/Home_bullet.gif); MARGIN-BOTTOM: 0px; MARGIN-LEFT: 20px; COLOR: #000000 }
	A:link { COLOR: #277619 }
	A:visited { COLOR: #000000 }
	A:hover { COLOR: #33305b }
	H1 { MARGIN-TOP: 0px; FONT-WEIGHT: bold; FONT-SIZE: 16px; MARGIN-BOTTOM: 0px; PADDING-BOTTOM: 2px; MARGIN-LEFT: 20px; COLOR: #000000 }
	H2 { MARGIN-TOP: 0px; FONT-WEIGHT: bold; FONT-SIZE: 15px; MARGIN-BOTTOM: 0px; COLOR: #339721 }
	.hnavbg { BACKGROUND-IMAGE: url(Home_files/Home_hnavbar_bg.gif); BACKGROUND-REPEAT: repeat-x }
	.leftcolumn { BACKGROUND-IMAGE: url(Home_files/Home_border_left.gif); BACKGROUND-REPEAT: repeat-y }
	.rightcolumn { PADDING-LEFT: 15px; BACKGROUND: url(Home_files/Home_border_right.gif) repeat-y right 50% }
	.footer { BACKGROUND-IMAGE: url(Home_files/Home_footer_bg.gif); BACKGROUND-REPEAT: repeat-x }
	</style>
	</HEAD>
	<body leftMargin="0" topMargin="5">
		<form id="Home" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="98%" align="center">
							<tr>
								<td vAlign="top">
									<table cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td vAlign="top" width="46" height="43"><IMG src="Home_files/Home_top_left.gif" border="0" editor="Webstyle4" moduleid="CreditumStyle (Project)\Home_top_left.xws"></td>
											<td vAlign="top" width="64"><IMG src="Home_files/Home_spacer.gif" border="0" editor="Webstyle4" moduleid="CreditumStyle (Project)\Home_spacer.xws"></td>
											<td class="hnavbg" vAlign="top">
												<script Webstyle4>document.write('<scr'+'ipt src="Home_files/xaramenu.js">'+'</scr'+'ipt>');document.write('<scr'+'ipt src="Home_files/home_hnavbar.js">'+'</scr'+'ipt>');/*img src="Home_files/Home_hnavbar.gif" moduleid="CreditumStyle (Project)\Home_hnavbar_off.xws"*/</script>
											</td>
											<td vAlign="top" width="55"><IMG src="Home_files/Home_top_right.gif" border="0" editor="Webstyle4" moduleid="CreditumStyle (Project)\Home_top_right.xws"></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td vAlign="top">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td vAlign="top" width="160">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="leftcolumn" vAlign="top" align="center" height="75">
															<div align="center"><IMG src="Home_files/Home_logo2.gif" border="0" editor="Webstyle4" moduleid="CreditumStyle (Project)\Home_logo2.xws"></div>
														</td>
													</tr>
													<tr>
														<td>
															<script Webstyle4>document.write('<scr'+'ipt src="Home_files/xaramenu.js">'+'</scr'+'ipt>');document.write('<scr'+'ipt src="Home_files/home_vnavbar.js">'+'</scr'+'ipt>');/*img src="Home_files/Home_vnavbar.gif" moduleid="CreditumStyle (Project)\Home_vnavbar_off.xws"*/</script>
														</td>
													</tr>
												</table>
												<P>&nbsp;</P>
												<P align="justify">Web Site desarrollado con el poder de MYSQL y ASP.NET</P>
												<P><asp:hyperlink id="lnkMySql" runat="server" ImageUrl="Home_files/mysql.png" NavigateUrl="http://www.mysql.com">MySql</asp:hyperlink></P>
												<P><asp:hyperlink id="lnkASP" runat="server" ImageUrl="Home_files/ASPNET.gif" NavigateUrl="http://www.asp.net">ASP.NET</asp:hyperlink></P>
												<P>&nbsp;</P>
											</td>
											<td class="rightcolumn" vAlign="top">
												<P align="right"><asp:label id="lblTime" runat="server">Hoy</asp:label></P>
												<H1>Generar Reportes</H1>
												<P>&nbsp;</P>
												<P><asp:label id="lblUser" runat="server"></asp:label></P>
												<P>&nbsp;</P>
												<P><STRONG><EM>Paso1:</EM></STRONG> Seleccione&nbsp;el tipo de reporte a generar</P>
												<P>&nbsp;</P>
												<P>Tipo Reporte</P>
												<P align="justify"><asp:dropdownlist id="ListaReporte" runat="server" Width="328px" AutoPostBack="True">
														<asp:ListItem Value="Seleccione....">Seleccione....</asp:ListItem>
														<asp:ListItem Value="Clientes">Clientes</asp:ListItem>
														<asp:ListItem Value="Experiencias">Creditos</asp:ListItem>
														<asp:ListItem Value="Consultas">Consultas</asp:ListItem>
														<asp:ListItem Value="Usuarios">Usuarios</asp:ListItem>
													</asp:dropdownlist></P>
												<P align="justify">&nbsp;</P>
												<P>&nbsp;</P>
												<P><asp:image id="Image1" runat="server" ImageUrl="Home_files/H_Separador.gif" Width="480px" Height="8px"></asp:image></P>
												<P>&nbsp;</P>
												<P><STRONG><EM>Paso2:</EM></STRONG> Agregue los criterios de busqueda</P>
												<P>&nbsp;</P>
												<P>
													<TABLE id="Table1" height="221" cellSpacing="1" cellPadding="1" width="664" border="0">
														<TR>
															<TD width="91" height="11">Campo:</TD>
															<TD height="11"><asp:dropdownlist id="LstCampo" runat="server" Width="272px" AutoPostBack="True">
																	<asp:ListItem Value="Seleccione...">Seleccione...</asp:ListItem>
																</asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD width="91">
																<P>Tipo Dato:</P>
															</TD>
															<TD><asp:label id="LabelTipoDato" runat="server" Width="264px" Font-Size="X-Small"></asp:label></TD>
														</TR>
														<TR>
															<TD width="91" height="24">
																<P>Valor:</P>
															</TD>
															<TD height="24"><asp:textbox id="TxtValor" runat="server" Width="120px"></asp:textbox></TD>
														</TR>
														<TR>
															<TD align="center" width="91">
																<P><asp:button id="btnInsertarCriterio" runat="server" Font-Size="XX-Small" Text="Insertar"></asp:button></P>
															</TD>
															<TD><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtValor" ErrorMessage="RequiredFieldValidator">Error: Debe colocar un valor para el criterio.</asp:requiredfieldvalidator></TD>
														</TR>
														<TR>
															<TD align="center" width="91" height="130"><P>&nbsp;</P>
															</TD>
															<TD height="130">
																<P>Criterios de Búsqueda:</P>
																<P>
																	<asp:datagrid id="DataGridCriterios" runat="server" Width="568px" Height="35px" Font-Size="XX-Small"
																		BorderColor="Green" PageSize="1" HorizontalAlign="Left" CellPadding="2" BorderStyle="None">
																		<AlternatingItemStyle BackColor="#C0FFC0"></AlternatingItemStyle>
																		<ItemStyle Font-Size="XX-Small"></ItemStyle>
																		<HeaderStyle Font-Size="XX-Small" Font-Bold="True" HorizontalAlign="Left" BorderWidth="16px"
																			ForeColor="Black" BorderStyle="Double" BorderColor="#404040" VerticalAlign="Middle" BackColor="SeaGreen"></HeaderStyle>
																		<FooterStyle Font-Size="XX-Small"></FooterStyle>
																		<Columns>
																			<asp:ButtonColumn Text="Eliminar" CommandName="Delete"></asp:ButtonColumn>
																		</Columns>
																	</asp:datagrid></P>
															</TD>
														</TR>
														<TR>
															<TD align="center" width="91"></TD>
															<TD>
																<P>&nbsp;</P>
															</TD>
														</TR>
													</TABLE>
												</P>
												<P>&nbsp;</P>
												<P><asp:image id="Image2" runat="server" ImageUrl="Home_files/H_Separador.gif" Width="480px" Height="8px"></asp:image></P>
												<P>&nbsp;</P>
												<P><STRONG><EM>Paso 3:</EM></STRONG>&nbsp; <EM>Ejecutar Consulta</EM></P>
												<P>&nbsp;</P>
												<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:button id="BtnGenerar" runat="server" Font-Size="XX-Small" Text="Ejecutar" CausesValidation="False"
														Enabled="False"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</P>
												<P>&nbsp;</P>
												<P align="left"><asp:datagrid id="DataGridReporte" runat="server" Width="568px" Height="35px" Font-Size="XX-Small"
														BorderStyle="None" CellPadding="2" HorizontalAlign="Left" PageSize="1" Visible="False" BorderColor="Green">
														<AlternatingItemStyle BackColor="#C0FFC0"></AlternatingItemStyle>
														<ItemStyle Font-Size="XX-Small"></ItemStyle>
														<HeaderStyle Font-Size="XX-Small" Font-Bold="True" HorizontalAlign="Left" BorderWidth="16px"
															ForeColor="Black" BorderStyle="Double" BorderColor="#404040" VerticalAlign="Middle" BackColor="SeaGreen"></HeaderStyle>
														<FooterStyle Font-Size="XX-Small"></FooterStyle>
														<Columns>
															<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Actualizar" CancelText="Cancelar" EditText="Edici&#243;n"></asp:EditCommandColumn>
															<asp:ButtonColumn Text="Eliminar" CommandName="Delete"></asp:ButtonColumn>
														</Columns>
													</asp:datagrid></P>
												<P align="left">&nbsp;</P>
												<P align="left">&nbsp;</P>
												<P><asp:button id="BtnReporte" runat="server" Text="Generar Reporte" CausesValidation="False" Visible="False"></asp:button></P>
												<P>&nbsp;</P>
												<P>&nbsp;</P>
												<P>&nbsp;</P>
												<P>&nbsp;</P>
												<P>&nbsp;</P>
												<P>&nbsp;</P>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td vAlign="top">
									<table cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td vAlign="top" width="55"><IMG src="Home_files/Home_bottom_left.gif" border="0" editor="Webstyle4" moduleid="CreditumStyle (Project)\Home_bottom_left.xws"></td>
											<td class="footer">
												<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px"> <BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
														<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px"> <BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
																<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
																	<P align="left">&nbsp;
																		<asp:hyperlink id="lnkHome" runat="server" NavigateUrl="Home.aspx" ForeColor="White">HOME</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkWho" runat="server" NavigateUrl="Info\Quienes_somos.aspx" ForeColor="White">¿QUIENES SOMOS?</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkServ" runat="server" NavigateUrl="http://www.google.com" ForeColor="White">SERVICIOS</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkContactanos" runat="server" NavigateUrl="Info\Contactanos.aspx" ForeColor="White">CONTACTANOS</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkLinks" runat="server" NavigateUrl="Info\Links.aspx" ForeColor="White">LINKS</asp:hyperlink>&nbsp;&nbsp;</P>
																</BLOCKQUOTE></BLOCKQUOTE></BLOCKQUOTE></BLOCKQUOTE></BLOCKQUOTE>
											</td>
											<td vAlign="top" width="55"><IMG src="Home_files/Home_bottom_right.gif" border="0" editor="Webstyle4" moduleid="CreditumStyle (Project)\Home_bottom_right.xws"></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
