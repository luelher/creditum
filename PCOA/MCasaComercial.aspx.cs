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
using GrupoEmporium.Datos;
using GrupoEmporium.Mensajes;
using Creditum.Usuarios;

namespace Creditum.PCOA
{
	/// <summary>
	/// Descripción breve de MCasaComercial.
	/// </summary>
	public class MCasaComercial : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblUbicacion;
		protected System.Web.UI.WebControls.TextBox txtUbicacion;
		protected System.Web.UI.WebControls.Label lblNit;
		protected System.Web.UI.WebControls.TextBox txtNit;
		protected System.Web.UI.WebControls.Label lblRif;
		protected System.Web.UI.WebControls.TextBox txtRif;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.Button btnAceptar;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorNombre;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummaryCC;
		protected string CCIndice;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página
			MetodosComunes mc = new MetodosComunes();
			Usuario usr = mc.LeerCookie(@"c:\Config.xml", User.Identity.Name);
			if (usr != null)
			{
				if (usr.PermitirAcceso(Convert.ToByte(Usuario.Nivel_Usuario.OPERADOR_ADMINISTRADOR)))
				{
				}
				else
					Response.Redirect(@"../Home.aspx");
			}
			else
				Response.Redirect(@"../Home.aspx");
			string scriptConfirmar = @"return confirm('Desea guardar los cambios?');";
			btnAceptar.Attributes.Add("OnClick", scriptConfirmar);
			//Leer el índice de la casa comercial pasado como parámetro a la pagina
			CCIndice = Request.Params["Index"].ToString();
			if (!Page.IsPostBack)
			{
				#region Cargar Info
				CargarInfo(CCIndice);
				#endregion
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
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid)
			{
				DataSet ds;
				try
				{
					#region CargarConfig
					clsBDConexion conn = MetodosComunes.Conectar(out ds);
					#endregion
					string strSQLUPDATE =
						@"UPDATE casas_comerciales SET NOMBRE='" + txtNombre.Text + "',"
						+ "RIF='" + txtRif.Text + "',"
						+ "NIT='" + txtNit.Text + "',"
						+ "UBICACION='" + txtUbicacion.Text + "' "
						+ @"WHERE ID_CASA_COMERCIAL=" + CCIndice + ";";
					if (clsBD.EjecutarNonQuery(conn, strSQLUPDATE) >= 0)
					{
						#region Limpiar y cerrar
						btnAceptar.Enabled = false;
						txtNombre.Text = "";
						txtRif.Text = "";
						txtNit.Text = "";
						txtUbicacion.Text = "";
						MensajeWeb.Info("La Casa Comercial ha sido actualizada satisfactoriamente, gracias por utilizar CREDITUM", Page, "InfoOK1");
						Page.RegisterStartupScript("cerrar","<script language='javascript'>window.close();</script>");
						#endregion
					}
					else
					{
						MensajeWeb.Info("Error actualizando los datos, el sistema no está disponible en este momento", Page, "InfoError5");
						//MensajeWeb.Info(@"Error actualizando los datos. Causas posibles:\n\rEl sistema puede que no esté disponible o\n\rel Nivel de usuario actual es el mismo", Page, "Update2");
					}

				}
				catch
				{
					MensajeWeb.Info("Error actualizando los datos, el sistema no está disponible en este momento", Page, "InfoError2");
					//MensajeWeb.Info(@"Error actualizando los datos. Causas posibles:\n\rEl sistema puede que no esté disponible", Page, "Update3");
				}
			}
		}

		private void CargarInfo(string Indice)
		{
			DataSet ds;
			try
			{
				#region CargarConfig
				clsBDConexion conn = MetodosComunes.Conectar(out ds);
				#endregion
				string strSQLQuery = @"SELECT NOMBRE,RIF,NIT,UBICACION FROM casas_comerciales "
					+ "WHERE ID_CASA_COMERCIAL=" + Indice;
				#region Ejecutar Query
				if (clsBD.EjecutarQuery(conn,strSQLQuery, out ds, "CC"))
				{
					if (ds.Tables["CC"].Rows.Count == 1)
					{
						txtNombre.Text = ds.Tables["CC"].Rows[0].ItemArray[0].ToString();
						txtRif.Text = ds.Tables["CC"].Rows[0].ItemArray[1].ToString();
						txtNit.Text = ds.Tables["CC"].Rows[0].ItemArray[2].ToString();
						txtUbicacion.Text = ds.Tables["CC"].Rows[0].ItemArray[3].ToString();
					}
					else
						Response.Redirect(@"Error.aspx?msg=Error: Consulta incorrecta");
				}
				else
					Response.Redirect(@"Error.aspx?msg=Error: Sistema no disponible");
				#endregion
			}
			catch
			{
				Response.Redirect(@"Error.aspx?msg=Error: Sistema no disponible");
			}
		}
	}
}
