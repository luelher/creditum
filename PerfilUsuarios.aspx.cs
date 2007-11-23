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
using GrupoEmporium.Datos;

namespace Creditum
{
	/// <summary>
	/// Descripción breve de PerfilUsuarios.
	/// </summary>
	public class PerfilUsuarios : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblSolicitante;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.DataGrid DataGridUsuarios;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.ImageButton imgbtnImprimir;
		protected System.Web.UI.WebControls.HyperLink lnkPC;
		protected System.Web.UI.WebControls.Label lblCliente;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página
			lblTime.Text = System.DateTime.Now.ToLongDateString();
			//lnkbtnVolver.Attributes.Add("OnClick", @"history.go(-1); return false;");
			imgbtnImprimir.Attributes.Add("OnClick", @"window.print();");
			MetodosComunes mc = new MetodosComunes();
			#region Autorización
			Usuario usr = mc.LeerCookie(@"c:\Config.xml", User.Identity.Name);
			if (usr != null)
			{
				if (usr.IDNivel == Convert.ToByte(Usuario.Nivel_Usuario.OPERADOR))
					Response.Redirect(@"home.aspx");
				else if (usr.IDNivel == Convert.ToByte(Usuario.Nivel_Usuario.CONSULTOR))
					Response.Redirect(@"home.aspx");				
			}
			else
				Response.Redirect(@"Home.aspx");
			#endregion
			Solicitante(usr);
			CargarUsuarios(usr);
		}

		private void Solicitante(Usuario usr)
		{
			lblSolicitante.Text = usr.Nombre + " " + usr.Apellido;
			if (usr.NombreCasa != "")
				lblCliente.Text = usr.NombreCasa + "-" + usr.NombreCliente;
			else
				lblCliente.Text = usr.NombreCliente;
		}

		private void CargarUsuarios(Usuario usr)
		{
			DataSet ds = new DataSet();
			DataGridUsuarios.Visible = false;
			try
			{
				#region CargarConfig
				clsBDConexion conn = MetodosComunes.Conectar(out ds);
				#endregion
				string strSQLQuery =
					@"SELECT CEDULA, CONCAT(usuarios.NOMBRE,' ',usuarios.APELLIDO) AS NOMBRE,"
					+ @"usuarios.TELEFONO, usuarios.CELULAR, NACIONALIDAD,"
					+ @"nivel.DESCRIPCION AS NIVEL_ACCESO "
					+ @"FROM usuarios "
					+ @"INNER JOIN clientes ON (usuarios.ID_CLIENTE=clientes.ID_CLIENTE) "
					+ @"LEFT JOIN casas_comerciales ON (clientes.ID_CASA_COMERCIAL=casas_comerciales.ID_CASA_COMERCIAL) "
					+ @"INNER JOIN nivel ON (usuarios.ID_NIVEL=nivel.ID_NIVEL) "
					+ @"WHERE usuarios.ID_CLIENTE=" + usr.IDCliente.ToString() + ";";
				if (clsBD.EjecutarQuery(conn,strSQLQuery, out ds, "Usuario"))
				{
					if (ds.Tables["Usuario"].Rows.Count > 0)
					{
						DataGridUsuarios.DataSource = ds;
						DataGridUsuarios.DataBind();
						DataGridUsuarios.Visible = true;						
					}
					else
					{
						//lblInfo.Text = "El usuario solicitado no esta registrado en el sistema";
						//MensajeWeb.Info("El usuario solicitado no esta registrado en el sistema", Page, "InfoNoExiste");
					}
				}
				else
				{
					lblError.Text = "Disculpe, el servicio no está disponible en estos momentos";
					//MensajeWeb.Info("Disculpe, el servicio no está disponible en estos momentos", Page, "InfoNoExiste1");
				}

			}
			catch
			{
				lblError.Text = "Disculpe, el servicio no está disponible en estos momentos";
				//MensajeWeb.Info("Disculpe, el servicio no está disponible en estos momentos", Page, "InfoNoExiste2");
			}
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}

}
