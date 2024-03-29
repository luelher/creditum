using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using Creditum.Usuarios;
using CREDITUM.Importar;
using GrupoEmporium.Datos;
using GrupoEmporium.Mensajes;

namespace Creditum.PCOA
{
	/// <summary>
	/// Descripci�n breve de PanelControlOA.
	/// </summary>
	public class PanelControlOA : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink lnkMySql;
		protected System.Web.UI.WebControls.HyperLink lnkASP;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.HyperLink lnkEmail;
		protected System.Web.UI.WebControls.HyperLink lnkRegistro;
		protected System.Web.UI.WebControls.Label lblLogin;
		protected System.Web.UI.WebControls.TextBox txtCedula;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorCI;
		protected System.Web.UI.WebControls.RangeValidator RangeValidatorCI;
		protected System.Web.UI.WebControls.Label lblPassword;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredfieldvalidatorPass;
		protected System.Web.UI.WebControls.Button btnIngresar;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummaryHome;
		protected System.Web.UI.WebControls.HyperLink lnkHome;
		protected System.Web.UI.WebControls.HyperLink lnkWho;
		protected System.Web.UI.WebControls.HyperLink lnkServ;
		protected System.Web.UI.WebControls.HyperLink lnkContactanos;
		protected System.Web.UI.WebControls.HyperLink lnkLinks;
		protected System.Web.UI.WebControls.HyperLink lnkModificarCliente;
		protected System.Web.UI.WebControls.HyperLink lnkNuevoCliente;
		protected System.Web.UI.WebControls.HyperLink lnkEliminarCliente;
		protected System.Web.UI.WebControls.HyperLink Hyperlink1;
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		protected System.Web.UI.WebControls.HyperLink Hyperlink3;
		protected System.Web.UI.WebControls.HyperLink lnkNuevoUsuario;
		protected System.Web.UI.WebControls.HyperLink lnkModificarUsuario;
		protected System.Web.UI.WebControls.HyperLink lnkEliminarUsuario;
		protected System.Web.UI.WebControls.HyperLink lnkInfoCredito;
		protected System.Web.UI.WebControls.HyperLink lnkConsultasTelefonicas;
		protected System.Web.UI.WebControls.HyperLink hlnkcambiopwd;
		protected System.Web.UI.WebControls.HyperLink hlinkPerfil;
		protected System.Web.UI.WebControls.HyperLink hlnkEstadoCuenta;
		protected System.Web.UI.WebControls.HyperLink lnkFacturaDia;
		protected System.Web.UI.WebControls.HyperLink Hyperlink4;
		protected System.Web.UI.WebControls.HyperLink Hyperlink5;
		protected System.Web.UI.WebControls.HyperLink Hyperlink6;
		protected System.Web.UI.WebControls.LinkButton lnkbtnLicencia;
		protected System.Web.UI.WebControls.LinkButton lnkBtnDemo;
		protected System.Web.UI.WebControls.HyperLink HyperlinkBloquear;
		protected System.Web.UI.WebControls.Button BtnCerrarSesion;
		protected System.Web.UI.WebControls.Label lblUser;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.HyperLink HyperLink7;
		protected System.Web.UI.WebControls.LinkButton lnkCreditumCliente;
		protected System.Web.UI.WebControls.HyperLink lnkHelp;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aqu� el c�digo de usuario para inicializar la p�gina
			lblTime.Text = System.DateTime.Now.ToLongDateString();
			MetodosComunes mc = new MetodosComunes();
			Usuario usr = mc.LeerCookie(@"c:\Config.xml", User.Identity.Name);
			if (usr != null)
			{
				if (usr.PermitirAcceso(Convert.ToByte(Usuario.Nivel_Usuario.OPERADOR_ADMINISTRADOR)))
					lblUser.Text = "Bienvenido " + usr.Nombre + " " + usr.Apellido;
				else if (usr.IDNivel == Convert.ToByte(Usuario.Nivel_Usuario.OPERADOR))
					Response.Redirect(@"../pco/panelcontrolo.aspx");
				else if (usr.IDNivel == Convert.ToByte(Usuario.Nivel_Usuario.CONSULTOR))
					Response.Redirect(@"../pcc/panelcontrolc.aspx");
				else if (usr.IDNivel == Convert.ToByte(Usuario.Nivel_Usuario.CONSULTOR_ADMINISTRADOR))
					Response.Redirect(@"../pcca/panelcontrolca.aspx");
				else//por si las moscas! pero nunca va a entrar aqui
					Response.Redirect(@"../Home.aspx");
			}
			else
				Response.Redirect(@"../Home.aspx");			
		}

		#region C�digo generado por el Dise�ador de Web Forms
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: llamada requerida por el Dise�ador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// M�todo necesario para admitir el Dise�ador. No se puede modificar
		/// el contenido del m�todo con el editor de c�digo.
		/// </summary>
		private void InitializeComponent()
		{    
			this.BtnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesion_Click);
			this.lnkbtnLicencia.Click += new System.EventHandler(this.lnkbtnLicencia_Click);
			this.lnkBtnDemo.Click += new System.EventHandler(this.lnkBtnDemo_Click);
			this.lnkCreditumCliente.Click += new System.EventHandler(this.lnkCreditumCliente_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lnkbtnLicencia_Click(object sender, System.EventArgs e)
		{
			DataSet ds1;
			MetodosComunes mc = new MetodosComunes();
			Usuario usr = mc.LeerCookie(@"c:\Config.xml", User.Identity.Name);
			#region CargarConfig
			clsBDConexion conn = MetodosComunes.Conectar(out ds1);
			#endregion
			Config cfg = new Config(usr.IDCliente, conn);
			Importar imp = new Importar();
			imp.Crear_Licencia(cfg, "Licencia" + cfg.Codigo + ".cre", @"C:\Inetpub\wwwroot\creditum\PCOA\Licencias");
			Page.RegisterStartupScript("cerrar",@"<script language='javascript'>document.location.href=""Licencias/Licencia" + usr.IDCliente.ToString() + @".cre""" + "</script>");
//			Page.RegisterStartupScript("cerrar",@"<script language='javascript'>downloadlink('\Licencias\Licencia" + usr.IDCliente.ToString() + @".cre')" + "</script>");

		}

		private void lnkBtnDemo_Click(object sender, System.EventArgs e)
		{
			DataSet ds1;
			#region CargarConfig
			clsBDConexion conn = MetodosComunes.Conectar(out ds1);
			#endregion
			string strSQLDELETEU =
				@"DELETE FROM usuarios "
				+ @"WHERE ID_CLIENTE= 1 AND (TO_DAYS(CURRENT_DATE()) - TO_DAYS(FECHA)) > 2;";
			int a = clsBD.EjecutarNonQuery(conn, strSQLDELETEU);
			MensajeWeb.Info(a.ToString() + " Usuarios Temporales eliminados.", Page, "Ok_1");
		}

		private void BtnCerrarSesion_Click(object sender, System.EventArgs e)
		{
			FormsAuthentication.SignOut();
			Response.Redirect(@"../Home.aspx");
		}

		private void lnkCreditumCliente_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(@"../CREDITUM_Cliente_1_0.exe");
			//Response.Redirect(@"../Upgrade.exe");
		}
	}
}
