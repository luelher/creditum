using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Creditum.Usuarios;
using CREDITUM.Importar;
using GrupoEmporium.Datos;
using GrupoEmporium.Mensajes;

namespace Creditum.PCCA
{
	/// <summary>
	/// Descripción breve de PanelControlCA.
	/// </summary>
	public class PanelControlCA : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink lnkMySql;
		protected System.Web.UI.WebControls.HyperLink lnkASP;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.Label lblUser;
		protected System.Web.UI.WebControls.HyperLink lnkNuevoUsuario;
		protected System.Web.UI.WebControls.HyperLink lnkModificarUsuario;
		protected System.Web.UI.WebControls.HyperLink lnkEliminarUsuario;
		protected System.Web.UI.WebControls.HyperLink hlnkcambiopwd;
		protected System.Web.UI.WebControls.HyperLink lnkInfoCredito;
		protected System.Web.UI.WebControls.HyperLink hlnkEstadoCuenta;
		protected System.Web.UI.WebControls.HyperLink hlinkPerfil;
		protected System.Web.UI.WebControls.HyperLink lnkHome;
		protected System.Web.UI.WebControls.HyperLink lnkWho;
		protected System.Web.UI.WebControls.HyperLink lnkServ;
		protected System.Web.UI.WebControls.HyperLink lnkContactanos;
		protected System.Web.UI.WebControls.HyperLink lnkLinks;
		protected System.Web.UI.WebControls.HyperLink Hyperlink5;
		protected System.Web.UI.WebControls.Button BtnCerrarSesion;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.LinkButton lnkbtnLicencia;
		protected System.Web.UI.WebControls.LinkButton lnkCreditumCliente;
		protected System.Web.UI.WebControls.HyperLink lnkHelp;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página
			lblTime.Text = System.DateTime.Now.ToLongDateString();
			MetodosComunes mc = new MetodosComunes();
			Usuario usr = mc.LeerCookie(@"c:\Config.xml", User.Identity.Name);
			if (usr != null)
			{
				if (usr.PermitirAcceso(Convert.ToByte(Usuario.Nivel_Usuario.CONSULTOR_ADMINISTRADOR)))
					lblUser.Text = "Bienvenido " + usr.Nombre + " " + usr.Apellido;
				else
					Response.Redirect(@"../Home.aspx");
			}
			else
				Response.Redirect(@"../Home.aspx");	
		}

		#region Código generado por el Diseñador de Web Forms
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: llamada requerida por el Diseñador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{    
			this.BtnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesion_Click);
			this.lnkbtnLicencia.Click += new System.EventHandler(this.lnkbtnLicencia_Click);
			this.lnkCreditumCliente.Click += new System.EventHandler(this.lnkCreditumCliente_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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
			Page.RegisterStartupScript("cerrar",@"<script language='javascript'>document.location.href=""../PCOA/Licencias/Licencia" + usr.IDCliente.ToString() + @".cre""" + "</script>");
			//			Page.RegisterStartupScript("cerrar",@"<script language='javascript'>downloadlink('\Licencias\Licencia" + usr.IDCliente.ToString() + @".cre')" + "</script>");

		}
	}
}
