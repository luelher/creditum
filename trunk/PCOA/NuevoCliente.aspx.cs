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
	/// Descripción breve de NuevoCliente.
	/// </summary>
	public class NuevoCliente : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink lnkMySql;
		protected System.Web.UI.WebControls.HyperLink lnkASP;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.Label lblUser;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblInfo;
		protected System.Web.UI.WebControls.Label lblCasa;
		protected System.Web.UI.WebControls.DropDownList DropDownListCasa;
		protected System.Web.UI.WebControls.Label lblSucursal;
		protected System.Web.UI.WebControls.DropDownList DropDownListSucursal;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummaryHome;
		protected System.Web.UI.WebControls.Label lblCedula;
		protected System.Web.UI.WebControls.TextBox txtCedula;
		protected System.Web.UI.WebControls.RangeValidator RangeValidatorCI;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorCI;
		protected System.Web.UI.WebControls.Label lblNac;
		protected System.Web.UI.WebControls.DropDownList DropDownNacionalidad;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredfieldvalidatorNombre;
		protected System.Web.UI.WebControls.Label lblApellido;
		protected System.Web.UI.WebControls.TextBox txtApellido;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredfieldvalidatorApellido;
		protected System.Web.UI.WebControls.Label lblTelf;
		protected System.Web.UI.WebControls.TextBox txtTelef;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidatorTelf;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCelular;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidatorCel;
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
		protected System.Web.UI.WebControls.LinkButton lnkbtnNuevaCasa;
		protected System.Web.UI.WebControls.Button btnRefrescarCC;
		protected System.Web.UI.WebControls.Button btnRefrescarSuc;
		protected System.Web.UI.WebControls.LinkButton lnkbtnNuevaSucursal;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.DropDownList DropDownListDesc;
		protected System.Web.UI.WebControls.Label Label4;
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
				CargarCasas();
				CargarDescuentos();
				DropDownListCasa_SelectedIndexChanged(sender, e);
			}
			lnkbtnNuevaCasa.Attributes.Add("OnClick", @"popup_windowCC();");
			lnkbtnNuevaSucursal.Attributes.Add("OnClick", @"popup_windowSuc();");
			string scriptConfirmar = @"return confirm('Está seguro que desea agregar al cliente y al usuario ' + txtNombre.value + ' como responsable?');";
			btnInsertar.Attributes.Add("OnClick", scriptConfirmar);
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
			this.btnRefrescarCC.Click += new System.EventHandler(this.btnRefrescarCC_Click);
			this.btnRefrescarSuc.Click += new System.EventHandler(this.btnRefrescarSuc_Click);
			this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
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

		private void CargarDescuentos()
		{
			for (int i=0;i<101;i++)
			{
				ListItem lstItm = new ListItem(i.ToString() + @"%", i.ToString()); 
				DropDownListDesc.Items.Add(lstItm);						
			}
		}

		private void DropDownListCasa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DataSet ds = new DataSet();
			DropDownListSucursal.Items.Clear();
			try
			{
				#region CargarConfig
				ds.ReadXml(@"c:\Config.xml", XmlReadMode.ReadSchema);
				clsBDConexion conn = MetodosComunes.Conectar(out ds);
				#endregion
				
				string strSQLQuery;
				if (DropDownListCasa.SelectedValue == "0")
					strSQLQuery = @"SELECT ID_CLIENTE, NOMBRE FROM clientes WHERE ID_CASA_COMERCIAL IS NULL;";
				else
					strSQLQuery = @"SELECT ID_CLIENTE, NOMBRE FROM clientes WHERE ID_CASA_COMERCIAL = '"
						+ DropDownListCasa.SelectedValue + @"';";
				if (clsBD.EjecutarQuery(conn,strSQLQuery, out ds, "Clientes"))
					for (int i=0;i<ds.Tables["Clientes"].Rows.Count;i++)
					{
						ListItem lstItm = new ListItem(ds.Tables["Clientes"].Rows[i].ItemArray[1].ToString(), ds.Tables["Clientes"].Rows[i].ItemArray[0].ToString()); 
						DropDownListSucursal.Items.Add(lstItm);					
					}
				else
					lblError.Text = "Disculpe, el servicio no está disponible en este momento";
				//MensajeWeb.Info("Disculpe, el servicio no está disponible en estos momentos", Page, "Error3");
			}
			catch
			{
				lblError.Text = "Disculpe, el servicio no está disponible en este momento";
				//MensajeWeb.Info("Disculpe, el servicio no está disponible en estos momentos", Page, "Error4");
			}
		}

		private void btnRefrescarCC_Click(object sender, System.EventArgs e)
		{
			CargarCasas();
		}

		private void btnRefrescarSuc_Click(object sender, System.EventArgs e)
		{
			DropDownListCasa_SelectedIndexChanged(sender, e);
		}

		private void btnInsertar_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid)
			{	
				lblInfo.Text = "";
				lblError.Text = "";
				DataSet ds = new DataSet();
				try
				{
					#region CargarConfig
					ds.ReadXml(@"c:\Config.xml", XmlReadMode.ReadSchema);
					clsBDConexion conn = MetodosComunes.Conectar(out ds);
					#endregion
					#region Insertar Cliente y usuario
					string strInsert =
						@"INSERT INTO clientes_conf(ID_CLIENTE,DESCUENTO,FECHA_INI)"
							+ @"VALUES("
							+ DropDownListSucursal.SelectedValue + ","
							+ DropDownListDesc.SelectedValue + ","
							+ "'" + DateTime.Now.ToString("yyyy-MM-dd") + @"');";
					if (clsBD.EjecutarNonQuery(conn, strInsert) == -1)
						lblError.Text = "No se pudo agregar el nuevo cliente, verifique si éste ya existe";
						//MensajeWeb.Info("No se pudo agregar el nuevo usuario, verifique si éste ya existe", Page, "InfoYaExiste1");
					else
					{
						strInsert = 
							@"INSERT INTO usuarios(CEDULA,ID_CLIENTE,PWD,NOMBRE,APELLIDO,TELEFONO,CELULAR,NACIONALIDAD,ID_NIVEL) "
							+ @"VALUES("
							+ txtCedula.Text + ","
							+ DropDownListSucursal.SelectedValue + ","
							+ @"PASSWORD('" + txtPWD.Text + @"'),"
							+ "'" + txtNombre.Text + "',"
							+ "'" + txtApellido.Text + "',"
							+ "'" + txtTelef.Text + "',"
							+ "'" + txtCelular.Text + "',"
							+ "'" + DropDownNacionalidad.SelectedValue + "',"
							+ DropDownListNivel.SelectedValue
							+ @");";
						#endregion
						if (clsBD.EjecutarNonQuery(conn, strInsert) == -1)
						{
							lblError.Text = "No se pudo agregar el nuevo usuario, verifique si éste ya existe";
							string strDelete =
								@"DELETE FROM clientes_conf "
								+ @"WHERE ID_CLIENTE="
								+ DropDownListSucursal.SelectedValue + @";";
							clsBD.EjecutarNonQuery(conn, strDelete);
							//MensajeWeb.Info("No se pudo agregar el nuevo usuario, verifique si éste ya existe", Page, "InfoYaExiste1");
						}
						else
						{
							lblError.Text = "";
							lblInfo.Text = "El usuario ha sido registrado satisfactoriamente";
							txtCedula.Text = "";
							txtNombre.Text = "";
							txtApellido.Text = "";
							txtTelef.Text = "";
							txtCelular.Text = "";
							//MensajeWeb.Info("El usuario ha sido registrado satisfactoriamente, gracias por utilizar CREDITUM", Page, "InfoOK1");

						}
					}
				}
				catch
				{
					//MensajeWeb.Info("No se pudo agregar el nuevo usuario, el sistema no esta disponible en estos momentos", Page, "InfoError5");
					lblError.Text = "No se pudo agregar el nuevo usuario, el sistema no esta disponible en estos momentos";
					lblInfo.Text = "";
				}
			}
		}
	}
}
