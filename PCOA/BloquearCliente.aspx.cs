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
	/// Descripción breve de BloquearCliente.
	/// </summary>
	public class BloquearCliente : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink lnkMySql;
		protected System.Web.UI.WebControls.HyperLink lnkASP;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.Label lblUser;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblInfo;
		protected System.Web.UI.WebControls.DropDownList DropDownListCasa;
		protected System.Web.UI.WebControls.DataGrid DataGridCC;
		protected System.Web.UI.WebControls.DataGrid DataGridSuc;
		protected System.Web.UI.WebControls.Label lblPorcDesc;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Button btnAceptar;
		protected System.Web.UI.WebControls.HyperLink lnkHome;
		protected System.Web.UI.WebControls.HyperLink lnkWho;
		protected System.Web.UI.WebControls.HyperLink lnkServ;
		protected System.Web.UI.WebControls.HyperLink lnkContactanos;
		protected System.Web.UI.WebControls.HyperLink lnkLinks;
		protected System.Web.UI.WebControls.Button btnDesblq;
		protected System.Web.UI.WebControls.Label lblEstatus;
		protected System.Web.UI.WebControls.HyperLink lnkHelp;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página
			lblTime.Text = System.DateTime.Now.ToLongDateString();
			MetodosComunes mc = new MetodosComunes();
			Usuario usr = mc.LeerCookie(@"c:\Config.xml", User.Identity.Name);
			if (usr != null)
			{
				if (usr.PermitirAcceso(Convert.ToByte(Usuario.Nivel_Usuario.OPERADOR_ADMINISTRADOR)))
					lblUser.Text = "Usuario: " + usr.Nombre + " " + usr.Apellido;
				else
					Response.Redirect(@"../Home.aspx");
			}
			else
				Response.Redirect(@"../Home.aspx");

			if (!Page.IsPostBack) 
			{
				CargarClientes();
				DropDownListCasa_SelectedIndexChanged(sender, e);
			}
		}

		private bool CargarClientes()
		{
			DataSet ds = new DataSet();
			try
			{
				#region CargarConfig
				clsBDConexion conn = MetodosComunes.Conectar(out ds);
				#endregion
				#region Consulta
				string strSQLQuery =
					@"SELECT clientes_conf.ID_CLIENTE,"
					+ @"CONCAT_WS('-',casas_comerciales.NOMBRE,clientes.NOMBRE) AS CLIENTE "
					+ "FROM casas_comerciales "
					+ @"RIGHT OUTER JOIN clientes ON (casas_comerciales.ID_CASA_COMERCIAL = clientes.ID_CASA_COMERCIAL) "
					+ @"INNER JOIN clientes_conf ON (clientes.ID_CLIENTE = clientes_conf.ID_CLIENTE) "
					+ @"LEFT JOIN empresa_conf ON (clientes_conf.ID_CLIENTE = empresa_conf.ID_CLIENTE) "
					+ @"WHERE empresa_conf.ID_CLIENTE IS NULL";
				#endregion
				if (clsBD.EjecutarQuery(conn,strSQLQuery, out ds, "Clientes"))
				{
					for (int i=0;i<ds.Tables["Clientes"].Rows.Count;i++)
					{
						ListItem lstItm = new ListItem(ds.Tables["Clientes"].Rows[i].ItemArray[1].ToString(), ds.Tables["Clientes"].Rows[i].ItemArray[0].ToString()); 
						DropDownListCasa.Items.Add(lstItm);						
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
			this.DropDownListCasa.SelectedIndexChanged += new System.EventHandler(this.DropDownListCasa_SelectedIndexChanged);
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			this.btnDesblq.Click += new System.EventHandler(this.btnDesblq_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DropDownListCasa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DataSet ds = new DataSet();
			string indexCC = "0";
			try
			{
				#region CargarConfig
				ds.ReadXml(@"c:\Config.xml", XmlReadMode.ReadSchema);
				clsBDConexion conn = MetodosComunes.Conectar(out ds);
				#endregion
				
				string strSQLQuery;
				strSQLQuery = @"SELECT DESCUENTO, STATUS FROM clientes_conf WHERE ID_CLIENTE=" + DropDownListCasa.SelectedValue + ";";
				if (clsBD.EjecutarQuery(conn,strSQLQuery, out ds, "Descuento"))
				{	
					lblPorcDesc.Text = ds.Tables["Descuento"].Rows[0].ItemArray[0].ToString() + @"%";
					if (ds.Tables["Descuento"].Rows[0].ItemArray[1].ToString() == "1")
					{
						lblEstatus.Text = "Activo";
						btnDesblq.Enabled = false;
						btnAceptar.Enabled = true;
					}
					else
					{
						lblEstatus.Text = "Bloqueado";
						btnDesblq.Enabled = true;
						btnAceptar.Enabled = false;
					}

				}
				else
					lblError.Text = "Disculpe, el servicio no está disponible en este momento";
				//MensajeWeb.Info("Disculpe, el servicio no está disponible en estos momentos", Page, "Error3");
												
				#region Cargar Detalles Cliente
				strSQLQuery = @"SELECT NOMBRE,RIF,NIT,DIRECCION,TELEFONO,FAX,CELULAR,EMAIL FROM clientes WHERE ID_CLIENTE=" + DropDownListCasa.SelectedValue + ";";
				if (clsBD.EjecutarQuery(conn,strSQLQuery, out ds, "SucInfo"))
				{	
					if (ds.Tables["SucInfo"].Rows.Count == 1)
					{
						DataGridSuc.DataSource = ds;
						DataGridSuc.DataBind();
						DataGridSuc.Visible = true;
						
						
						strSQLQuery = @"SELECT ID_CASA_COMERCIAL FROM clientes WHERE ID_CLIENTE=" + DropDownListCasa.SelectedValue + ";";
						if (clsBD.EjecutarQuery(conn,strSQLQuery, out ds, "SucCC"))
						{	
							if (ds.Tables["SucCC"].Rows.Count == 1)
								indexCC = ds.Tables["SucCC"].Rows[0].ItemArray[0].ToString();
							else
								indexCC = "0";
						}
						else
						{
							//lblInfo.Text = "El usuario solicitado no esta registrado en el sistema";
							lblError.Text = "Disculpe, el servicio no está disponible en este momento";
						}
						
					}
					else
					{
						//lblInfo.Text = "El usuario solicitado no esta registrado en el sistema";
						lblError.Text = "Disculpe, el servicio no está disponible en este momento";
					}
				}
				else
					lblError.Text = "Disculpe, el servicio no está disponible en este momento";
				#endregion

				#region Cargar Info CC
				if (indexCC!="0" && indexCC.ToUpper()!="NULL" && indexCC!="")
				{
					strSQLQuery = @"SELECT NOMBRE,RIF,NIT,UBICACION FROM casas_comerciales WHERE ID_CASA_COMERCIAL=" + indexCC + ";";
					if (clsBD.EjecutarQuery(conn,strSQLQuery, out ds, "CCInfo"))
					{	
						if (ds.Tables["CCInfo"].Rows.Count == 1)
						{
							DataGridCC.DataSource = ds;
							DataGridCC.DataBind();
							DataGridCC.Visible = true;			
						}
						else
						{
							//lblInfo.Text = "El usuario solicitado no esta registrado en el sistema";
							lblError.Text = "Disculpe, el servicio no está disponible en este momento";
						}
						
					}
					else
						lblError.Text = "Disculpe, el servicio no está disponible en este momento";
				}
				else
				{
					DataGridCC.Visible = false;
				}
				#endregion
			}
			catch
			{
				lblError.Text = "Disculpe, el servicio no está disponible en este momento";
				//MensajeWeb.Info("Disculpe, el servicio no está disponible en estos momentos", Page, "Error4");
			}
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			DataSet ds;
			#region CargarConfig
			clsBDConexion conn = MetodosComunes.Conectar(out ds);
			#endregion
			string strSQLUPDATE =
				@"UPDATE clientes_conf SET STATUS=0 "
				+ @"WHERE ID_CLIENTE=" + DropDownListCasa.SelectedValue + ";";
			if (clsBD.EjecutarNonQuery(conn, strSQLUPDATE) > 0)
			{
				MensajeWeb.Info("El cliente ha sido bloqueado", Page, "Ok_1");
				DropDownListCasa_SelectedIndexChanged(sender, e);
			}
			else
				MensajeWeb.Info("Error al intentar bloquear el cliente. El sistema puede que no esté disponible en este momento", Page, "Fail_1");
		}

		private void btnDesblq_Click(object sender, System.EventArgs e)
		{
			DataSet ds;
			#region CargarConfig
			clsBDConexion conn = MetodosComunes.Conectar(out ds);
			#endregion
			string strSQLUPDATE =
				@"UPDATE clientes_conf SET STATUS=1 "
				+ @"WHERE ID_CLIENTE=" + DropDownListCasa.SelectedValue + ";";
			if (clsBD.EjecutarNonQuery(conn, strSQLUPDATE) > 0)
			{
				MensajeWeb.Info("El cliente ha sido desbloqueado", Page, "Ok_2");
				DropDownListCasa_SelectedIndexChanged(sender, e);
			}
			else
				MensajeWeb.Info("Error al intentar desbloquear el cliente. El sistema puede que no esté disponible en este momento", Page, "Fail_2");
		}
	}
}
