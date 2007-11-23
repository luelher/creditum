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
using Creditum.Usuarios;
using GrupoEmporium.Datos;
using GrupoEmporium.Mensajes;

namespace Creditum.PCOA
{
	/// <summary>
	/// Descripción breve de ModifcarUsuario.
	/// </summary>
	public class ModifcarUsuarioC : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink lnkMySql;
		protected System.Web.UI.WebControls.HyperLink lnkASP;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.Label lblUser;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblInfo;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList DropDownListNivel;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtPWD;
		protected System.Web.UI.WebControls.Button btnInsertar;
		protected System.Web.UI.WebControls.HyperLink lnkHome;
		protected System.Web.UI.WebControls.HyperLink lnkWho;
		protected System.Web.UI.WebControls.HyperLink lnkServ;
		protected System.Web.UI.WebControls.HyperLink lnkContactanos;
		protected System.Web.UI.WebControls.HyperLink lnkLinks;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DataGrid DataGridDatosPersonales;
		protected System.Web.UI.WebControls.Button btnAceptar;
		protected System.Web.UI.WebControls.Button btnPwd;
		protected System.Web.UI.WebControls.HyperLink lnkHelp;
		protected System.Web.UI.WebControls.DropDownList DropDownListUsuario;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página
			lblTime.Text = System.DateTime.Now.ToLongDateString();
			MetodosComunes mc = new MetodosComunes();
			Usuario usr = mc.LeerCookie(@"c:\Config.xml", User.Identity.Name);
			if (usr != null)
			{
				if (usr.PermitirAcceso(Convert.ToByte(Usuario.Nivel_Usuario.CONSULTOR_ADMINISTRADOR)))
					lblUser.Text = "Usuario: " + usr.Nombre + " " + usr.Apellido;
				else
					Response.Redirect(@"../Home.aspx");
			}
			else
				Response.Redirect(@"../Home.aspx");

			if (!Page.IsPostBack) 
			{
				CargarUsuarios(usr);
				DropDownListUsuario_SelectedIndexChanged(sender, e);
			}
			#region Confirmaciones
			MensajeWeb.Confirmacion(
				new string[]{
						"Está seguro que desea modificar el nivel de accesibilidad de éste usuario?", 
						"Está seguro que desea reestablecer la contraseña de éste usuario?"
							},
				Page,
				new string[]{"miBoton", "miBoton2"},
				new string[]{"Aceptar", "ReestablecerPassword"},
				"ConfirmarNivel");
			btnAceptar.Attributes.Add("OnClick", "miBoton=this.value; miBoton2=this.value;");
			btnPwd.Attributes.Add("OnClick", "miBoton2=this.value; miBoton=this.value;");
			#endregion
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
			this.DropDownListUsuario.SelectedIndexChanged += new System.EventHandler(this.DropDownListUsuario_SelectedIndexChanged);
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			this.btnPwd.Click += new System.EventHandler(this.btnPwd_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private bool CargarUsuarios(Usuario usr)
		{
			DataSet ds = new DataSet();
			try
			{
				#region CargarConfig
				clsBDConexion conn = MetodosComunes.Conectar(out ds);
				#endregion
				#region Consulta
				string strSQLQuery =
					@"SELECT usuarios.CEDULA,"
					+ @"CONCAT_WS(' ',usuarios.NOMBRE,usuarios.APELLIDO) AS USUARIO "
					+ "FROM usuarios "
					+ @"WHERE ID_CLIENTE=" + usr.IDCliente.ToString();
				#endregion
				if (clsBD.EjecutarQuery(conn,strSQLQuery, out ds, "Clientes"))
				{
					for (int i=0;i<ds.Tables["Clientes"].Rows.Count;i++)
					{
						ListItem lstItm = new ListItem(ds.Tables["Clientes"].Rows[i].ItemArray[1].ToString(), ds.Tables["Clientes"].Rows[i].ItemArray[0].ToString()); 
						DropDownListUsuario.Items.Add(lstItm);						
					}
					return true;
				}
				else
				{
					lblError.Text = "Disculpe, el servicio no está disponible en este momento";
					//MensajeWeb.Info("Disculpe, el servicio no está disponible en estos momentos", Page, "Error1");
					return false;
				}
			}
			catch
			{				
				lblError.Text = "Disculpe, el servicio no está disponible en este momento";
				//MensajeWeb.Info("Disculpe, el servicio no está disponible en estos momentos", Page, "Error2");
				return false;
			}
		}
		
		private void Detalles()
		{			
			DataSet ds = new DataSet();
			lblError.Text = "";
			lblInfo.Text = "";
			btnAceptar.Enabled = false;
			btnPwd.Enabled = false;
			DataGridDatosPersonales.Visible = false;
			try
			{
				#region CargarConfig
				clsBDConexion conn = MetodosComunes.Conectar(out ds);
				#endregion
				#region Consulta
				string strSQLQuery =
					@"SELECT CONCAT(usuarios.NOMBRE,' ',usuarios.APELLIDO) AS NOMBRE,"
					+ @"CONCAT_WS('-',casas_comerciales.NOMBRE,clientes.NOMBRE) AS CLIENTE,"
					+ @"nivel.DESCRIPCION AS NIVEL_ACCESO "
					+ @"FROM usuarios "
					+ @"INNER JOIN clientes ON (usuarios.ID_CLIENTE=clientes.ID_CLIENTE) "
					+ @"LEFT JOIN casas_comerciales ON (clientes.ID_CASA_COMERCIAL=casas_comerciales.ID_CASA_COMERCIAL) "
					+ @"INNER JOIN nivel ON (usuarios.ID_NIVEL=nivel.ID_NIVEL) "
					+ @"WHERE usuarios.CEDULA=" + DropDownListUsuario.SelectedValue + ";";
				#endregion
				if (clsBD.EjecutarQuery(conn,strSQLQuery, out ds, "Usuario"))
				{
					if (ds.Tables["Usuario"].Rows.Count == 1)
					{
						#region MostarDetalles
						DataGridDatosPersonales.DataSource = ds;
						DataGridDatosPersonales.DataBind();
						DataGridDatosPersonales.Visible = true;
						btnAceptar.Enabled = true;
						btnPwd.Enabled = true;
						#endregion
					}
					else
					{
						//lblInfo.Text = "El usuario solicitado no esta registrado en el sistema";
						MensajeWeb.Info("El usuario solicitado no esta registrado en el sistema", Page, "InfoNoExiste");
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

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid)
			{
				DataSet ds;
				lblError.Text = "";
				lblInfo.Text = "";
				try
				{
					#region CargarConfig
					clsBDConexion conn = MetodosComunes.Conectar(out ds);
					#endregion
					string strSQLUPDATE =
						@"UPDATE usuarios SET ID_NIVEL=" + DropDownListNivel.SelectedValue + " "
						+ @"WHERE cedula=" + DropDownListUsuario.SelectedValue + ";";
					if (clsBD.EjecutarNonQuery(conn, strSQLUPDATE) > 0)
					{
						btnAceptar.Enabled = false;
						btnPwd.Enabled = false;
						DataGridDatosPersonales.Visible = false;
						lblInfo.Text = "Datos del usuario actualizados satisfactoriamente";
						//MensajeWeb.Info("Datos del usuario actualizados satisfactoriamente", Page, "Update1");
					}
					else
					{
						lblError.Text = @"Error actualizando los datos. Causas posibles: 1)El sistema puede que no esté disponible, 2)El Nivel de usuario actual es el mismo";
						//MensajeWeb.Info(@"Error actualizando los datos. Causas posibles:\n\rEl sistema puede que no esté disponible o\n\rel Nivel de usuario actual es el mismo", Page, "Update2");
					}

				}
				catch
				{
					lblError.Text = @"Error actualizando los datos. Causas posibles: 1)El sistema puede que no esté disponible";
					//MensajeWeb.Info(@"Error actualizando los datos. Causas posibles:\n\rEl sistema puede que no esté disponible", Page, "Update3");
				}
			}		
		}

		private void btnPwd_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid)
			{
				DataSet ds;
				lblError.Text = "";
				lblInfo.Text = "";
				try
				{
					#region CargarConfig
					clsBDConexion conn = MetodosComunes.Conectar(out ds);
					#endregion
					string strSQLUPDATE =
						@"UPDATE usuarios SET PWD=PASSWORD('creditum123') "
						+ @"WHERE cedula=" + DropDownListUsuario.SelectedValue + ";";					
					if (clsBD.EjecutarNonQuery(conn, strSQLUPDATE) > 0)
					{
						btnAceptar.Enabled = false;
						btnPwd.Enabled = false;
						DataGridDatosPersonales.Visible = false;
						lblInfo.Text = "Datos del usuario actualizados satisfactoriamente";
						//MensajeWeb.Info("Datos del usuario actualizados satisfactoriamente", Page, "UpdatePWD1");
					}
					else
					{
						lblError.Text = @"Error actualizando los datos. Causas posibles: 1)El sistema puede que no esté disponible, 2)El password actual del usuario es el predeterminado";
						//MensajeWeb.Info(@"Error actualizando los datos. Causas posibles:\n\rEl sistema puede que no esté disponible o\n\rel password actual del usuario es el predeterminado", Page, "UpdatePWD2");
					}

				}
				catch
				{
					lblError.Text = @"Error actualizando los datos. Causas posibles: 1)El sistema puede que no esté disponible";
					//MensajeWeb.Info(@"Error actualizando los datos. Causas posibles:\n\rEl sistema puede que no esté disponible", Page, "UpdatePWD3");
				}
			}
		}

		private void DropDownListUsuario_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Detalles();
		}
	}
}
