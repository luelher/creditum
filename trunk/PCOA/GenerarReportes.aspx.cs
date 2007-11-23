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
using GrupoEmporium.Mensajes;

namespace Creditum.PCOA
{
	/// <summary>
	/// Descripción breve de GenerarReportes.
	/// </summary>
	public class GenerarReportes : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink lnkMySql;
		protected System.Web.UI.WebControls.HyperLink lnkASP;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.Label lblUser;
		protected System.Web.UI.WebControls.HyperLink lnkNuevoCliente;
		protected System.Web.UI.WebControls.HyperLink lnkModificarCliente;
		protected System.Web.UI.WebControls.HyperLink lnkEliminarCliente;
		protected System.Web.UI.WebControls.HyperLink lnkNuevoUsuario;
		protected System.Web.UI.WebControls.HyperLink lnkModificarUsuario;
		protected System.Web.UI.WebControls.HyperLink lnkEliminarUsuario;
		protected System.Web.UI.WebControls.HyperLink lnkInfoCredito;
		protected System.Web.UI.WebControls.HyperLink lnkConsultasTelefonicas;
		protected System.Web.UI.WebControls.HyperLink lnkHome;
		protected System.Web.UI.WebControls.HyperLink lnkWho;
		protected System.Web.UI.WebControls.HyperLink lnkServ;
		protected System.Web.UI.WebControls.HyperLink lnkContactanos;
		protected System.Web.UI.WebControls.HyperLink lnkLinks;
		protected System.Web.UI.WebControls.DropDownList ListaReporte;
		protected System.Web.UI.WebControls.Button btnInsertarCriterio;
		protected System.Web.UI.WebControls.DropDownList LstCampo;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label LabelTipoDato;
		protected System.Web.UI.WebControls.TextBox TxtValor;

		private DataTable dt;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Button BtnGenerar;
		protected System.Web.UI.WebControls.DataGrid DataGridReporte;
		protected System.Web.UI.WebControls.Button BtnReporte;
		private DataView dv;
		protected System.Web.UI.WebControls.DataGrid DataGridCriterios;
		private DataSet ds;

	
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
				Session.RemoveAll();
				dt=new DataTable("Criterios");
				DataColumn dc = new DataColumn("Campo");
				dt.Columns.Add(dc);
				dc = new DataColumn("Tipo");
				dt.Columns.Add(dc);
				dc = new DataColumn("Valor");
				dt.Columns.Add(dc);
				
				dv = new DataView(dt);
				dv.AllowDelete=true;

				DataGridCriterios.DataSource = dv;
				DataGridCriterios.DataBind();

				Page.Session.Add("dv",dv);
				Page.Session.Add("tabla","");

			}
			else
			{

				dv = (DataView)Page.Session["dv"];

				if(dv.Table.Rows.Count>0) BtnGenerar.Enabled = true;
										else BtnGenerar.Enabled = false;
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
			this.ListaReporte.SelectedIndexChanged += new System.EventHandler(this.ListaReporte_SelectedIndexChanged);
			this.LstCampo.SelectedIndexChanged += new System.EventHandler(this.LstCampo_SelectedIndexChanged);
			this.btnInsertarCriterio.Click += new System.EventHandler(this.btnInsertarCriterio_Click);
			this.BtnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);
			this.DataGridReporte.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridReporte_CancelCommand);
			this.DataGridReporte.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridReporte_EditCommand);
			this.DataGridReporte.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridReporte_UpdateCommand);
			this.BtnReporte.Click += new System.EventHandler(this.BtnReporte_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ListaReporte_SelectedIndexChanged(object sender, EventArgs e)
		{

			if (ListaReporte.SelectedIndex > 0)
			{
				string sql;
				DataSet ds = new DataSet();
				string tabla = ListaReporte.SelectedItem.Text;
				// show columns FROM creditum.clientes;
				sql = "show columns FROM " + tabla.ToLower() + ";";

				#region CargarConfig
				clsBDConexion conn = MetodosComunes.Conectar(out ds);
				#endregion

				bool resp = clsBD.EjecutarQuery(conn,sql,out ds,"Campos");
				if (resp)
				{
					LstCampo.Items.Clear();
					ListItem lstitem;

					dv = (DataView)Session[0];
					dt = dv.Table;

					dt.Rows.Clear();
					dv = new DataView(dt);
					dv.AllowEdit = true;

					DataGridReporte.DataSource = dv;
					DataGridReporte.DataBind();

					DataGridCriterios.DataSource = dv;
					DataGridCriterios.DataBind();

					Session[0] = dv;
					Session["tabla"] = tabla;
					

					lstitem = new ListItem("Seleccione...","Seleccione...");
					LstCampo.Items.Add(lstitem);
					
					for (int i=0;i<ds.Tables[0].Rows.Count;i++)
					{
						lstitem = new ListItem(ds.Tables[0].Rows[i][0].ToString(),Convert.ToChar(65+i).ToString() + ds.Tables[0].Rows[i][1].ToString());
						LstCampo.Items.Add(lstitem);
					}

					switch (ListaReporte.SelectedItem.Text)
					{
						case "Creditos":
							lstitem = new ListItem("ID_PERSONA",Convert.ToChar(65+ds.Tables[0].Rows.Count).ToString() + "int(11)");
							LstCampo.Items.Add(lstitem);
							lstitem = new ListItem("ID_CLIENTE",Convert.ToChar(65+ds.Tables[0].Rows.Count+1).ToString() + "int(11)");
							LstCampo.Items.Add(lstitem);
							break;
					}

				}
			}
		}

		private void btnInsertarCriterio_Click(object sender, EventArgs e)
		{
			if (LstCampo.SelectedIndex>0)
			{
				dv = (DataView)Page.Session[0];

				DataRow dr = dv.Table.NewRow();

				dr[0] = LstCampo.SelectedItem.Text;
				dr[1] = LstCampo.SelectedItem.Value;
				dr[2] = TxtValor.Text;

				dv.Table.Rows.Add(dr);


				
				//dv.BeginInit();
				DataGridCriterios.DataSource = dv;
				DataGridCriterios.DataBind();
				Page.Session[0]=dv;

				TxtValor.Text = "";

				if(dv.Table.Rows.Count>0) BtnGenerar.Enabled = true;
				else BtnGenerar.Enabled = false;

			}

		}

		private void LstCampo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LabelTipoDato.Text = LstCampo.SelectedItem.Value.Substring(1);
		}

		private void BtnGenerar_Click(object sender, System.EventArgs e)
		{
			// Crear el SQL de forma dinamica
			dv = (DataView)Session[0];
			dt = dv.Table;

			string sql;

			switch (ListaReporte.SelectedItem.Text)
			{
				case "Clientes":
					#region SQL_Clientes					
					sql = "SELECT casas_comerciales.nombre as nombre_casa_comercial, clientes.*  FROM " +
						" (clientes inner join casas_comerciales on clientes.id_casa_comercial=casas_comerciales.id_casa_comercial) " +
						" inner join clientes_conf on clientes.id_cliente=clientes_conf.id_cliente " +
						" WHERE 1=1 ";
					#endregion
					break;
				case "Creditos":
					#region SQL_Creditum
					sql = " SELECT casas_comerciales.NOMBRE AS CASA_COMERCIAL, " +
						" clientes.NOMBRE AS SUCURSAL, " +
						" clientes_personas.ID_PERSONA, " +
						" personas_naturales.APELLIDO, " +
						" personas_naturales.NOMBRE, " +
						" creditos.FECHA_COMPRA, " +
						" creditos.FECHA_OPERACION, " +
						" creditos.MONTO, " +
						" creditos.PAGO_MES, " +
						" creditos.NUM_GIROS AS GIROS, " +
						" creditos.EXPERIENCIA AS EXP, " +
						" creditos.ESTADO " +
						" FROM creditos " +
						" INNER JOIN clientes_personas ON (creditos.ID_CLIENTE_PERSONA = clientes_personas.ID_CLIENTE_PERSONA) " +
						" INNER JOIN personas_naturales ON (clientes_personas.ID_PERSONA = personas_naturales.CEDULA) " +
						" INNER JOIN clientes ON (clientes_personas.ID_CLIENTE = clientes.ID_CLIENTE) " +
						" LEFT OUTER JOIN casas_comerciales ON (clientes.ID_CASA_COMERCIAL = casas_comerciales.ID_CASA_COMERCIAL) " +
						" WHERE 1=1 ";
					#endregion
					break;
				case "Consultas":
					#region SQL_Consultas
					sql = "SELECT " +
						" consultas.cedula_usuario, " +
						" usuarios.nombre, " +
						" usuarios.apellido, " +
						" consultas.id_cliente, " +
						" casas_comerciales.nombre as nombrecasacomercial, " +
						" clientes.nombre as nombreclientes, " +
						" consultas.id_persona, " +
						" consultas.fecha_hora " +
						" FROM " +
						" (consultas inner join usuarios on consultas.cedula_usuario=usuarios.cedula) " +
						" inner join " +
						" (clientes inner join casas_comerciales on clientes.id_casa_comercial=casas_comerciales.id_casa_comercial) " +
						" on consultas.id_cliente=clientes.id_cliente " +
						" WHERE 1=1 ";
					#endregion
					break;
//				case "Usuarios":
//					break;
				default:
					sql = "Select " + ListaReporte.SelectedItem.Text.ToLower() + ".* from " + ListaReporte.SelectedItem.Text.ToLower() +
						" where 1=1 ";
					break;
			}


			for (int i=0;i<dt.Rows.Count;i++)
			{
				sql += " and ";

				if(dt.Rows[i][1].ToString().IndexOf("varchar",1) == 1 || dt.Rows[i][1].ToString().IndexOf("datetime",1) == 1 || dt.Rows[i][1].ToString().IndexOf("date",1) == 1)
				{
					if (ListaReporte.SelectedItem.Text=="Consultas" || ListaReporte.SelectedItem.Text=="Clientes" || ListaReporte.SelectedItem.Text=="Creditos") sql += ListaReporte.SelectedItem.Text.ToLower() + ".";
					sql += dt.Rows[i][0].ToString();
					sql += " like '%";
					sql += dt.Rows[i][2].ToString();
					sql += "%'";
				} 
				else if (dt.Rows[i][1].ToString().IndexOf("date",1) ==1 )
				{
					if(ListaReporte.SelectedItem.Text=="Creditos")
					{
						if (dt.Rows[i][0].ToString()=="ID_PERSONA" || dt.Rows[i][0].ToString()=="ID_CLIENTE") sql += "clientes_personas.";
						else sql += ListaReporte.SelectedItem.Text.ToLower() + ".";
					}
					else if (ListaReporte.SelectedItem.Text=="Clientes" || ListaReporte.SelectedItem.Text=="Consultas") 
					{
						sql += ListaReporte.SelectedItem.Text.ToLower() + ".";
					}

					sql += dt.Rows[i][0].ToString();
					sql += " = '";
					sql += dt.Rows[i][2].ToString();
					sql += "' ";
				}
				else
				{
					if(ListaReporte.SelectedItem.Text=="Creditos")
					{
						if (dt.Rows[i][0].ToString()=="ID_PERSONA" || dt.Rows[i][0].ToString()=="ID_CLIENTE") sql += "clientes_personas.";
						else sql += ListaReporte.SelectedItem.Text.ToLower() + ".";
					}
					else if (ListaReporte.SelectedItem.Text=="Clientes" || ListaReporte.SelectedItem.Text=="Consultas") 
					{
						sql += ListaReporte.SelectedItem.Text.ToLower() + ".";
					}

					sql += dt.Rows[i][0].ToString();
					sql += " = ";
					sql += dt.Rows[i][2].ToString();
					sql += " ";
				}
			}

			#region CargarConfig
			clsBDConexion conn = MetodosComunes.Conectar(out ds);
			#endregion

			bool resp = clsBD.EjecutarQuery(conn,sql,out dt);

			dv = new DataView(dt);
			dv.AllowEdit = true;
			dv.AllowDelete  = true;

			DataGridReporte.Visible = true;

			DataGridReporte.DataSource = dv;
			DataGridReporte.DataBind();
			BtnReporte.Visible = true;


			Page.Session.Add("dvreporte",dv);

		}
/*
		private void BtnEliminar_Click(object sender, System.EventArgs e)
		{

			dv = (DataView)Session[0];
			dt = dv.Table;

			if (dt.Rows.Count >0)
			{
				dt.Rows[dt.Rows.Count-1].Delete();
				dt.AcceptChanges();
				dv = new DataView(dt);

				DataGridReporte.DataSource = dv;
				DataGridReporte.DataBind();

			}

		}
*/
		private void BtnReporte_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(@"ReporteGenerico.aspx");
		}

		private void DataGridCriterios_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dv = (DataView)Session[0];
			dt = dv.Table;

			if (dt.Rows.Count >0)
			{
				dt.Rows[e.Item.ItemIndex].Delete();
				dt.AcceptChanges();
				dv = new DataView(dt);

				DataGridCriterios.DataSource = dv;
				DataGridCriterios.DataBind();

			}		
		}

		private void BtnLimpiar_Click(object sender, System.EventArgs e)
		{
			DataGridReporte.DataSource = null;
			DataGridCriterios.DataBind();
			BtnGenerar.Enabled=false;
		}

		private void DataGridReporte_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dv = (DataView)Session["dvreporte"];

			DataGridReporte.EditItemIndex = e.Item.ItemIndex;

			DataGridReporte.DataSource = dv;
			DataGridReporte.DataBind();

		}

		private void DataGridReporte_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dv = (DataView)Session["dvreporte"];

			DataGridReporte.EditItemIndex = -1;
			DataGridReporte.DataSource = dv;
			DataGridReporte.DataBind();

		}

		private void DataGridReporte_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dv = (DataView)Session["dvreporte"];
			dt = dv.Table;
			

			switch (ListaReporte.SelectedItem.Text)
			{//Actualizamos el DataTable antes de insertar los datos a la BD
				case "Clientes":
					//dt.Rows[e.Item.ItemIndex][0];
					break;
				case "Creditos":

					break;
			}


			DataGridReporte.EditItemIndex = -1;
			DataGridReporte.DataSource = dv;
			DataGridReporte.DataBind();


		}

	}
}

