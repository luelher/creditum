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
	/// Descripción breve de DetalleFactura.
	/// </summary>
	public class DetalleFactura : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblSolicitante;
		protected System.Web.UI.WebControls.Label lblCliente;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.HyperLink lnkPC;
		protected System.Web.UI.WebControls.ImageButton imgbtnImprimir;
		protected System.Web.UI.WebControls.Label lblFactura;
		protected System.Web.UI.WebControls.DataGrid DataGridV;
		protected System.Web.UI.WebControls.DataGrid DatagridF;
		protected System.Web.UI.WebControls.Label lblError;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página
			string id = "0";
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
				id = Request.Params["IDFACTURA"].ToString();
			}
			else
				Response.Redirect(@"Home.aspx");
			#endregion
			Solicitante(usr);
			Detalles(id);
		}

		private void Solicitante(Usuario usr)
		{
			lblSolicitante.Text = usr.Nombre + " " + usr.Apellido;
			if (usr.NombreCasa != "")
				lblCliente.Text = usr.NombreCasa + "-" + usr.NombreCliente;
			else
				lblCliente.Text = usr.NombreCliente;
		}

		private void Detalles(string id)
		{
			DataSet ds = new DataSet();
			DataGridV.Visible = false;
			DatagridF.Visible = false;
			try
			{
				lblFactura.Text = id;
				#region CargarConfig
				clsBDConexion conn = MetodosComunes.Conectar(out ds);
				#endregion
				#region Cargar Validas
				string strSQLQuery =
					@"SELECT CEDULA_USUARIO, ID_PERSONA AS CEDULA_CONSULTADA, FECHA_HORA "
					+ @"FROM detalle_facturas "
					+ @"WHERE detalle_facturas.STATUS=1 AND ID_FACTURA = " + id;
				clsBD.EjecutarQuery(conn,strSQLQuery, ds, "Validas");
				DataGridV.DataSource = ds.Tables["Validas"];
				DataGridV.DataBind();
				DataGridV.Visible = true;
				#endregion
				#region Cargar Inválidas
				strSQLQuery =
					@"SELECT CEDULA_USUARIO, ID_PERSONA AS CEDULA_CONSULTADA, FECHA_HORA "
					+ @"FROM detalle_facturas "
					+ @"WHERE detalle_facturas.STATUS=0 AND ID_FACTURA = " + id;
				clsBD.EjecutarQuery(conn,strSQLQuery, ds, "Fallidas");
				DatagridF.DataSource = ds.Tables["Fallidas"];
				DatagridF.DataBind();
				DatagridF.Visible = true;
				#endregion

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
