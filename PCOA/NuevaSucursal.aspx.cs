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
	/// Descripción breve de NuevaSucursal.
	/// </summary>
	public class NuevaSucursal : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.DropDownList DropDownListCasa;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCel;
		protected System.Web.UI.WebControls.Label LabelTelf;
		protected System.Web.UI.WebControls.TextBox txtTelf;
		protected System.Web.UI.WebControls.Label lblCelular;
		protected System.Web.UI.WebControls.TextBox txtFax;
		protected System.Web.UI.WebControls.Label lblFax;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidatorTelf;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidatorCel;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidatorEmail;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummaryCC;
	
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
			string scriptConfirmar = @"return confirm('Desea agregar la sucursal ' + txtNombre.value + '?');";
			btnAceptar.Attributes.Add("OnClick", scriptConfirmar);
			if (!Page.IsPostBack) 
			{
				CargarCasas();
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


		private bool CargarCasas()
		{
			DataSet ds = new DataSet();
			try
			{
				#region CargarConfig
				clsBDConexion conn = MetodosComunes.Conectar(out ds);
				#endregion
				string strSQLQuery =
					@"SELECT ID_CASA_COMERCIAL, NOMBRE FROM casas_comerciales;";
				if (clsBD.EjecutarQuery(conn,strSQLQuery, out ds, "Casas"))
				{
					for (int i=0;i<ds.Tables["Casas"].Rows.Count;i++)
					{
						ListItem lstItm = new ListItem(ds.Tables["Casas"].Rows[i].ItemArray[1].ToString(), ds.Tables["Casas"].Rows[i].ItemArray[0].ToString()); 
						DropDownListCasa.Items.Add(lstItm);						
					}
					return true;
				}
				else
				{
					//lblError.Text = "Disculpe, el servicio no está disponible en este momento";
					MensajeWeb.Info("Disculpe, el servicio no está disponible en estos momentos", Page, "Error1");
					return false;
				}
			}
			catch
			{				
				//lblError.Text = "Disculpe, el servicio no está disponible en este momento";
				MensajeWeb.Info("Disculpe, el servicio no está disponible en estos momentos", Page, "Error2");
				return false;
			}
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid)
			{
				DataSet ds = new DataSet();
				try
				{
					#region CargarConfig
					ds.ReadXml(@"c:\Config.xml", XmlReadMode.ReadSchema);
					clsBDConexion conn = MetodosComunes.Conectar(out ds);
					#endregion
					#region SqlInsert
					string strInsert;
					if (DropDownListCasa.SelectedValue != "0")
					#region SQL
						strInsert = 
						@"INSERT INTO clientes(ID_CASA_COMERCIAL,NOMBRE,RIF,NIT,DIRECCION,TELEFONO,FAX,CELULAR,EMAIL) "
						+ @"VALUES("
						+ DropDownListCasa.SelectedValue + ","
						+ "'" + txtNombre.Text + "',"
						+ "'" + txtRif.Text + "',"
						+ "'" + txtNit.Text + "',"
						+ "'" + txtUbicacion.Text + "',"
						+ "'" + txtTelf.Text + "',"
						+ "'" + txtCel.Text + "',"
						+ "'" + txtFax.Text + "',"
						+ "'" + txtEmail.Text + @"');";
					#endregion
					else
					#region SQL Null
						strInsert = 
							@"INSERT INTO clientes(ID_CASA_COMERCIAL,NOMBRE,RIF,NIT,DIRECCION,TELEFONO,FAX,CELULAR,EMAIL) "
							+ @"VALUES("
							+ "NULL" + ","
							+ "'" + txtNombre.Text + "',"
							+ "'" + txtRif.Text + "',"
							+ "'" + txtNit.Text + "',"
							+ "'" + txtUbicacion.Text + "',"
							+ "'" + txtTelf.Text + "',"
							+ "'" + txtCel.Text + "',"
							+ "'" + txtFax.Text + "',"
							+ "'" + txtEmail.Text + @"');";
					#endregion
					#endregion
					if (clsBD.EjecutarNonQuery(conn, strInsert) == -1)
						//lblError.Text = "No se pudo agregar el nuevo usuario, verifique si éste ya existe";
						MensajeWeb.Info("No se pudo agregar la nueva Sucursal, el sistema no está disponible", Page, "InfoError1");
					else
					{
						txtNombre.Text = "";
						txtRif.Text = "";
						txtNit.Text = "";
						txtUbicacion.Text = "";
						txtTelf.Text = "";
						txtCel.Text = "";
						txtFax.Text = "";
						txtEmail.Text = "";
						MensajeWeb.Info("El usuario ha sido registrado satisfactoriamente, gracias por utilizar CREDITUM", Page, "InfoOK1");
						Page.RegisterStartupScript("cerrar","<script language='javascript'>window.close();</script>");
					}
				}
				catch
				{
					MensajeWeb.Info("No se pudo agregar la nueva Casa Comercial, el sistema no está disponible en estos momentos", Page, "InfoError5");
					//lblError.Text = "No se pudo agregar el nuevo usuario, el sistema no esta disponible en estos momentos";
					//lblInfo.Text = "";
				}
			}
		}
	}
}
