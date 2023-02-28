// SistemaEdificios.Act_Aporte
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Microsoft.Office.Interop.Excel;
using SistemaEdificios;
using SistemaEdificios.Reportes;

public class Act_Aporte : Form
{
	private DataTable dtGen = new DataTable();

	private double Valor_UF = 0.0;

	private string[] Mes_Procesar = new string[13];

	private IContainer components = null;

	private GroupControl groupControl3;

	private GroupControl groupControl5;

	private CheckBox Activar_ModTraspaso;

	private TextBox text_total;

	private SimpleButton simpleButton15;

	private GroupControl groupControl2;

	private CheckBox chec_IMPRIMIR;

	private GroupControl groupControl1;

	private SimpleButton simpleButton5;

	private SimpleButton simpleButton2;

	private TextBox text_CentroCosto;

	private Label label3;

	private Label label7;

	private TextBox text_Area;

	private DataGridView dataGridView2;

	private TextBox textBox1;

	private SimpleButton simpleButton3;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton4;

	private SimpleButton simpleButton6;

	private SimpleButton simpleButton8;

	private SimpleButton btnCancelar;

	private SimpleButton btnAceptar;

	private SimpleButton simpleButton7;

	private SimpleButton simpleButton9;

	private System.Windows.Forms.ComboBox comboBox1;

	private Label label4;

	private System.Windows.Forms.ComboBox comboBox2;

	private Label label5;

	private ImageList imageList1;

	private DataGridViewButtonColumn CodCC;

	private DataGridViewTextBoxColumn CentroDeCosto;

	private DataGridViewTextBoxColumn Suministro;

	private DataGridViewTextBoxColumn Ingreso;

	private DataGridViewTextBoxColumn UF;

	private DataGridViewTextBoxColumn ValorUF;

	private DataGridViewTextBoxColumn Consumo;

	private DataGridViewTextBoxColumn Total;

	private DataGridViewTextBoxColumn Imprime;

	private DataGridViewTextBoxColumn Pagado;

	private DataGridViewTextBoxColumn Nulo;

	private DataGridViewImageColumn INet;

	private DataGridViewTextBoxColumn INET_Fecha;

	private DataGridViewTextBoxColumn Imagen;

	private DataGridViewTextBoxColumn Registro;

	private DataGridViewTextBoxColumn Secuencia;

	private DataGridViewTextBoxColumn C1;

	private DataGridViewTextBoxColumn C2;

	private DataGridViewTextBoxColumn C3;

	public Act_Aporte()
	{
		InitializeComponent();
	}

	private void Act_Aporte_Load(object sender, EventArgs e)
	{
		DateTime date = DateTime.Now;
		DateTime oUltimoDiaDelMes = new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1.0);
		int AnoEnCurso = date.Year;
		int MesEnCurso = date.Month;
		int ciclo_Ano = AnoEnCurso + 3;
		List<Orden_de_Entrega> dataSource2 = new List<Orden_de_Entrega>();
		dataSource2.Add(new Orden_de_Entrega
		{
			Name = "Enero",
			Value = "Enero"
		});
		dataSource2.Add(new Orden_de_Entrega
		{
			Name = "Febrero",
			Value = "Febrero"
		});
		dataSource2.Add(new Orden_de_Entrega
		{
			Name = "Marzo",
			Value = "Marzo"
		});
		dataSource2.Add(new Orden_de_Entrega
		{
			Name = "Abril",
			Value = "Abril"
		});
		dataSource2.Add(new Orden_de_Entrega
		{
			Name = "Mayo",
			Value = "Mayo"
		});
		dataSource2.Add(new Orden_de_Entrega
		{
			Name = "Junio",
			Value = "Junio"
		});
		dataSource2.Add(new Orden_de_Entrega
		{
			Name = "Julio",
			Value = "Julio"
		});
		dataSource2.Add(new Orden_de_Entrega
		{
			Name = "Agosto",
			Value = "Agosto"
		});
		dataSource2.Add(new Orden_de_Entrega
		{
			Name = "Septiembre",
			Value = "Septiembre"
		});
		dataSource2.Add(new Orden_de_Entrega
		{
			Name = "Octubre",
			Value = "Octubre"
		});
		dataSource2.Add(new Orden_de_Entrega
		{
			Name = "Noviembre",
			Value = "Noviembre"
		});
		dataSource2.Add(new Orden_de_Entrega
		{
			Name = "Diciembre",
			Value = "Diciembre"
		});
		comboBox1.DataSource = dataSource2;
		comboBox1.DisplayMember = "Name";
		comboBox1.ValueMember = "Value";
		for (int ctr2 = 1; ctr2 <= 11; ctr2++)
		{
			if (ctr2 == MesEnCurso)
			{
				comboBox1.SelectedIndex = ctr2 - 1;
			}
		}
		List<Orden_de_Entrega> dataSource1 = new List<Orden_de_Entrega>();
		for (int i = AnoEnCurso - 4; i <= AnoEnCurso + 4; i++)
		{
			dataSource1.Add(new Orden_de_Entrega
			{
				Name = i.ToString(),
				Value = i.ToString()
			});
		}
		comboBox2.DataSource = dataSource1;
		comboBox2.DisplayMember = "Name";
		comboBox2.ValueMember = "Value";
		comboBox2.SelectedIndex = 0;
		int index = 0;
		for (int ctr = 0; ctr <= comboBox2.Items.Count; ctr++)
		{
			comboBox2.SelectedIndex = ctr;
			if (AnoEnCurso == Convert.ToInt32(comboBox2.Text.ToString().Trim()))
			{
				break;
			}
		}
		Mes_Procesar[1] = "Enero";
		Mes_Procesar[2] = "Febrero";
		Mes_Procesar[3] = "Marzo";
		Mes_Procesar[4] = "Abril";
		Mes_Procesar[5] = "Mayo";
		Mes_Procesar[6] = "Junio";
		Mes_Procesar[7] = "Julio";
		Mes_Procesar[8] = "Agosto";
		Mes_Procesar[9] = "Septiembre";
		Mes_Procesar[10] = "Octubre";
		Mes_Procesar[11] = "Noviembre";
		Mes_Procesar[12] = "Diciembre";
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		string FechaI = "";
		string FechaF = "";
		int MMes = 0;
		for (int ctr = 0; ctr <= 11; ctr++)
		{
			if (ctr == comboBox1.SelectedIndex)
			{
				MMes = ctr + 1;
				break;
			}
		}
		if (comboBox1.SelectedIndex != -1)
		{
			if (comboBox2.Text.ToString().Trim() != "")
			{
				int AAno = Convert.ToInt32(comboBox2.Text.ToString().Trim());
				string Mes = MMes.ToString().Trim();
				string Ano = AAno.ToString().Trim();
				DateTime oPrimerDiaDelMes = new DateTime(Convert.ToInt32(Ano), Convert.ToInt32(Mes), 1);
				DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1.0);
				FechaI = oPrimerDiaDelMes.ToString("dd/MM/yyyy");
				FechaF = oUltimoDiaDelMes.ToString("dd/MM/yyyy");
				dataGridView2.Rows.Clear();
				Funciones Func = new Funciones();
				ConnBdd cs = ConnBdd.getDbInstance();
				cs.GetDBConnection();
				string Sql_Server = "";
				try
				{
					Cursor.Current = Cursors.WaitCursor;
					DataTable dt1 = new DataTable();
					DataSet ds1 = new DataSet();
					string Impreso = "";
					string Pagado = "";
					string Nulo = "";
					double Total = 0.0;
					Sql_Server = "Exec sp_Mostrar_Pago_Aporte '','','" + FechaI + "','" + FechaF + "','Fijo%','Venta%'";
					ds1 = cs.ConsultaQry(Sql_Server);
					dt1 = ds1.Tables[0];
					foreach (DataRow dr1 in dt1.Rows)
					{
						DateTime Fecha_ingreso = ((!Func.EsFecha(dr1["Fecha"].ToString().Trim())) ? DateTime.Parse("01/01/1900") : DateTime.Parse(dr1["Fecha"].ToString().Trim()));
						DateTime Fecha_INET = ((!Func.EsFecha(dr1["INet_Fecha"].ToString().Trim())) ? DateTime.Parse("01/01/1900") : DateTime.Parse(dr1["INet_Fecha"].ToString().Trim()));
						Impreso = ((!(dr1["Impreso"].ToString().Trim() == "True")) ? "-----" : "Si");
						Pagado = ((!(dr1["Pagado"].ToString().Trim() == "True")) ? "-----" : "Si");
						Nulo = ((!(dr1["Nulo"].ToString().Trim() == "True")) ? "-----" : "Si");
						if (dr1["INet"].ToString().Trim() == "True")
						{
							dataGridView2.Rows.Add(dr1["Codigo"].ToString().Trim(), dr1["Nombre"].ToString().Trim(), dr1["Suministros"].ToString().Trim(), Fecha_ingreso.ToString("dd/MM/yyyy").Trim(), dr1["UF"].ToString().Trim(), dr1["Valor_UF"].ToString().Trim(), dr1["Consumo"].ToString().Trim(), dr1["A_Pagar"].ToString().Trim(), Impreso, Pagado, Nulo, imageList1.Images[0], Fecha_INET.ToString("dd/MM/yyyy").Trim(), 0, dr1["Registro"].ToString().Trim(), dr1["Secuencia"].ToString().Trim(), dr1["Cargo_1"].ToString().Trim(), dr1["Cargo_2"].ToString().Trim(), dr1["Cargo_3"].ToString().Trim());
						}
						else
						{
							dataGridView2.Rows.Add(dr1["Codigo"].ToString().Trim(), dr1["Nombre"].ToString().Trim(), dr1["Suministros"].ToString().Trim(), Fecha_ingreso.ToString("dd/MM/yyyy").Trim(), dr1["UF"].ToString().Trim(), dr1["Valor_UF"].ToString().Trim(), dr1["Consumo"].ToString().Trim(), dr1["A_Pagar"].ToString().Trim(), Impreso, Pagado, Nulo, imageList1.Images[1], Fecha_INET.ToString("dd/MM/yyyy").Trim(), 1, dr1["Registro"].ToString().Trim(), dr1["Secuencia"].ToString().Trim(), dr1["Cargo_1"].ToString().Trim(), dr1["Cargo_2"].ToString().Trim(), dr1["Cargo_3"].ToString().Trim());
						}
						dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
						dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						Total += Convert.ToDouble(dr1["A_Pagar"].ToString().Trim());
					}
					text_total.Text = Func.ordenNumero(Total.ToString().Trim());
					return;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Ha ocurrido un error -> " + ex.ToString());
					Cursor.Current = Cursors.Default;
					return;
				}
				finally
				{
					cs.closeconn();
					MessageBox.Show("<< Proceso de carga terminado >>", "Mensaje");
					Cursor.Current = Cursors.Default;
				}
			}
			MessageBox.Show("<< Debe seleccionar año >>");
		}
		else
		{
			MessageBox.Show("<< Debe seleccionar Mes >>");
		}
	}

	private void btnCancelar_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void simpleButton7_Click(object sender, EventArgs e)
	{
		string FechaI = "";
		string FechaF = "";
		int MMes = 0;
		for (int ctr = 0; ctr <= 11; ctr++)
		{
			if (ctr == comboBox1.SelectedIndex)
			{
				MMes = ctr + 1;
				break;
			}
		}
		if (comboBox1.SelectedIndex != -1)
		{
			if (comboBox2.Text.ToString().Trim() != "")
			{
				int AAno = Convert.ToInt32(comboBox2.Text.ToString().Trim());
				string Mes3 = MMes.ToString().Trim();
				string Ano11 = AAno.ToString().Trim();
				DateTime oPrimerDiaDelMes = new DateTime(Convert.ToInt32(Ano11), Convert.ToInt32(Mes3), 1);
				DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1.0);
				FechaI = oPrimerDiaDelMes.ToString("dd/MM/yyyy");
				FechaF = oUltimoDiaDelMes.ToString("dd/MM/yyyy");
				dataGridView2.Rows.Clear();
				Funciones Func = new Funciones();
				ConnBdd cs = ConnBdd.getDbInstance();
				cs.GetDBConnection();
				string Sql_Server = "";
				DataTable dt1 = new DataTable();
				DataSet ds1 = new DataSet();
				string Impreso = "";
				string Pagado = "";
				string Nulo = "";
				double Total = 0.0;
				string Cabecera = "Pago Aportes por Valor";
				string SQL = "";
				string Secuencia = "";
				int Mes = 0;
				string Mes2 = "";
				string Mes4 = "";
				string Mes5 = "";
				string Respuesta_SQL = "";
				string SQLInsert = "";
				int Existe_Informacion = 0;
				try
				{
					Sql_Server = string.Concat("Exec sp_Mostrar_Pago_Aporte '','','" + FechaI + "','" + FechaF + "','Fijo%','", "'");
					ds1 = cs.ConsultaQry(Sql_Server);
					dt1 = ds1.Tables[0];
					foreach (DataRow dr2 in dt1.Rows)
					{
						DateTime Fecha_ingreso = ((!Func.EsFecha(dr2["Fecha"].ToString().Trim())) ? DateTime.Parse("01/01/1900") : DateTime.Parse(dr2["Fecha"].ToString().Trim()));
						DateTime Fecha_INET = ((!Func.EsFecha(dr2["INet_Fecha"].ToString().Trim())) ? DateTime.Parse("01/01/1900") : DateTime.Parse(dr2["INet_Fecha"].ToString().Trim()));
						Impreso = ((!(dr2["Impreso"].ToString().Trim() == "True")) ? "-----" : "Si");
						Pagado = ((!(dr2["Pagado"].ToString().Trim() == "True")) ? "-----" : "Si");
						Nulo = ((!(dr2["Nulo"].ToString().Trim() == "True")) ? "-----" : "Si");
						if (dr2["INet"].ToString().Trim() == "True")
						{
							dataGridView2.Rows.Add(dr2["Codigo"].ToString().Trim(), dr2["Nombre"].ToString().Trim(), dr2["Suministros"].ToString().Trim(), Fecha_ingreso.ToString("dd/MM/yyyy").Trim(), dr2["UF"].ToString().Trim(), dr2["Valor_UF"].ToString().Trim(), dr2["Consumo"].ToString().Trim(), dr2["A_Pagar"].ToString().Trim(), Impreso, Pagado, Nulo, imageList1.Images[0], Fecha_INET.ToString("dd/MM/yyyy").Trim(), 0, dr2["Registro"].ToString().Trim(), dr2["Secuencia"].ToString().Trim(), dr2["Cargo_1"].ToString().Trim(), dr2["Cargo_2"].ToString().Trim(), dr2["Cargo_3"].ToString().Trim());
						}
						else
						{
							dataGridView2.Rows.Add(dr2["Codigo"].ToString().Trim(), dr2["Nombre"].ToString().Trim(), dr2["Suministros"].ToString().Trim(), Fecha_ingreso.ToString("dd/MM/yyyy").Trim(), dr2["UF"].ToString().Trim(), dr2["Valor_UF"].ToString().Trim(), dr2["Consumo"].ToString().Trim(), dr2["A_Pagar"].ToString().Trim(), Impreso, Pagado, Nulo, imageList1.Images[1], Fecha_INET.ToString("dd/MM/yyyy").Trim(), 1, dr2["Registro"].ToString().Trim(), dr2["Secuencia"].ToString().Trim(), dr2["Cargo_1"].ToString().Trim(), dr2["Cargo_2"].ToString().Trim(), dr2["Cargo_3"].ToString().Trim());
						}
						dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
						dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						Total += Convert.ToDouble(dr2["A_Pagar"].ToString().Trim());
					}
					text_total.Text = Func.ordenNumero(Total.ToString().Trim());
					string box_msg = "Desea imprimir copia de APORTES ¿ Confirmar ?";
					string box_title = "Confirmación";
					if (!(MessageBox.Show(box_msg, box_title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation).ToString() == "Yes"))
					{
						return;
					}
					string[] Grilla = new string[11];
					int X = 0;
					for (X = 0; X < 11; X++)
					{
						Grilla[X] = "*";
					}
					SQL = "DELETE FROM  " + ConnBdd.nombreBaseDatos + ".[Emision_Aportes]  ";
					Respuesta_SQL = cs.EjecutaQry(SQL);
					if (Respuesta_SQL.Trim() != "O.K")
					{
						MessageBox.Show("Error Entregado: " + Respuesta_SQL.Trim());
						return;
					}
					for (X = 0; X < dataGridView2.Rows.Count; X++)
					{
						Existe_Informacion = 0;
						SQL = "SELECT * FROM " + ConnBdd.nombreBaseDatos + ".Reg_Medicion WHERE Registro = " + dataGridView2.Rows[X].Cells["Registro"].Value.ToString() + " AND Secuencia  = " + dataGridView2.Rows[X].Cells["Secuencia"].Value.ToString();
						ds1 = cs.ConsultaQry(SQL);
						dt1 = ds1.Tables[0];
						{
							IEnumerator enumerator2 = dt1.Rows.GetEnumerator();
							try
							{
								if (enumerator2.MoveNext())
								{
									DataRow dr1 = (DataRow)enumerator2.Current;
									Mes = DateTime.Parse(dr1["Fecha_Hasta"].ToString().Trim()).Month + 1;
									Existe_Informacion = 1;
								}
							}
							finally
							{
								IDisposable disposable = enumerator2 as IDisposable;
								if (disposable != null)
								{
									disposable.Dispose();
								}
							}
						}
						ds1.Clear();
						dt1.Clear();
						if (Existe_Informacion == 1)
						{
							Mes2 = "";
							Mes4 = "";
							Mes5 = "";
							Respuesta_SQL = "";
							SQLInsert = "";
							Existe_Informacion = 0;
							switch (Mes)
							{
							case 1:
								Mes2 = "Octubre";
								Mes4 = "Noviembre";
								Mes5 = "Diciembre";
								break;
							case 2:
								Mes2 = "Noviembre";
								Mes4 = "Diciembre";
								Mes5 = "Enero";
								break;
							case 3:
								Mes2 = "Diciembre";
								Mes4 = "Enero";
								Mes5 = "Febrero";
								break;
							default:
								Mes2 = Mes_Procesar[Mes - 3];
								Mes4 = Mes_Procesar[Mes - 2];
								Mes5 = Mes_Procesar[Mes - 1];
								break;
							}
							Grilla[1] = dataGridView2.Rows[X].Cells["CodCC"].Value.ToString();
							Grilla[2] = dataGridView2.Rows[X].Cells["CentroDeCosto"].Value.ToString();
							Grilla[3] = dataGridView2.Rows[X].Cells["Suministro"].Value.ToString();
							Grilla[4] = "";
							Grilla[5] = "0";
							Grilla[6] = "0";
							Grilla[7] = dataGridView2.Rows[X].Cells["Total"].Value.ToString().Replace(".", "");
							Grilla[8] = dataGridView2.Rows[X].Cells["Total"].Value.ToString().Replace(".", "");
							Grilla[9] = "";
							Grilla[10] = "0";
							SQLInsert = "INSERT INTO  " + ConnBdd.nombreBaseDatos + ".[Emision_Aportes]  ";
							SQLInsert += "([CC], [Direccion] , [Descripcion], [ValoraPagar], [Monto1], [Mes1] , [Monto2], [Mes2] , [Monto3], [Mes3], [Total], [Cabecera], [Mes_de_proceso]) ";
							SQLInsert = SQLInsert + "VALUES ('" + Grilla[1] + "','" + Grilla[2] + "','" + Grilla[3] + "'," + Grilla[10] + "," + Grilla[5] + ",'" + Mes2 + "'," + Grilla[6] + ",'" + Mes4 + "'," + Grilla[7] + ",'" + Mes5 + "'," + Grilla[8] + ",'" + Cabecera + "','" + Mes_Procesar[Mes] + "')";
							Respuesta_SQL = cs.EjecutaQry(SQLInsert);
							if (Respuesta_SQL != "O.K")
							{
								MessageBox.Show("Error Entregado al ingresar respaldo en Log_Web_Lectura : " + Respuesta_SQL);
								return;
							}
						}
					}
					DocAportes doc = new DocAportes();
					doc.Visible = true;
					Imprimir imp = new Imprimir();
					imp.documentViewer1.DocumentSource = doc;
					imp.WindowState = FormWindowState.Maximized;
					imp.Show();
					return;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Ha ocurrido un error -> " + ex.ToString());
					return;
				}
				finally
				{
					cs.closeconn();
					MessageBox.Show("<< Proceso de carga terminado >>", "Mensaje");
				}
			}
			MessageBox.Show("<< Debe seleccionar año >>");
		}
		else
		{
			MessageBox.Show("<< Debe seleccionar Mes >>");
		}
	}

	private void simpleButton9_Click(object sender, EventArgs e)
	{
		string FechaI = "";
		string FechaF = "";
		int MMes = 0;
		for (int ctr = 0; ctr <= 11; ctr++)
		{
			if (ctr == comboBox1.SelectedIndex)
			{
				MMes = ctr + 1;
				break;
			}
		}
		if (comboBox1.SelectedIndex != -1)
		{
			if (comboBox2.Text.ToString().Trim() != "")
			{
				int AAno = Convert.ToInt32(comboBox2.Text.ToString().Trim());
				string Mes3 = MMes.ToString().Trim();
				string Ano11 = AAno.ToString().Trim();
				DateTime oPrimerDiaDelMes = new DateTime(Convert.ToInt32(Ano11), Convert.ToInt32(Mes3), 1);
				DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1.0);
				FechaI = oPrimerDiaDelMes.ToString("dd/MM/yyyy");
				FechaF = oUltimoDiaDelMes.ToString("dd/MM/yyyy");
				dataGridView2.Rows.Clear();
				Funciones Func = new Funciones();
				ConnBdd cs = ConnBdd.getDbInstance();
				cs.GetDBConnection();
				string Sql_Server = "";
				DataTable dt1 = new DataTable();
				DataSet ds1 = new DataSet();
				string Impreso = "";
				string Pagado = "";
				string Nulo = "";
				double Total = 0.0;
				string Cabecera = "Pago Aportes por Valor";
				string SQL = "";
				string Secuencia = "";
				int Mes = 0;
				string Mes2 = "";
				string Mes4 = "";
				string Mes5 = "";
				string Respuesta_SQL = "";
				string SQLInsert = "";
				int Existe_Informacion = 0;
				try
				{
					Sql_Server = string.Concat("Exec sp_Mostrar_Pago_Aporte '','','" + FechaI + "','" + FechaF + "','Venta%','", "'");
					ds1 = cs.ConsultaQry(Sql_Server);
					dt1 = ds1.Tables[0];
					foreach (DataRow dr2 in dt1.Rows)
					{
						DateTime Fecha_ingreso = ((!Func.EsFecha(dr2["Fecha"].ToString().Trim())) ? DateTime.Parse("01/01/1900") : DateTime.Parse(dr2["Fecha"].ToString().Trim()));
						DateTime Fecha_INET = ((!Func.EsFecha(dr2["INet_Fecha"].ToString().Trim())) ? DateTime.Parse("01/01/1900") : DateTime.Parse(dr2["INet_Fecha"].ToString().Trim()));
						Impreso = ((!(dr2["Impreso"].ToString().Trim() == "True")) ? "-----" : "Si");
						Pagado = ((!(dr2["Pagado"].ToString().Trim() == "True")) ? "-----" : "Si");
						Nulo = ((!(dr2["Nulo"].ToString().Trim() == "True")) ? "-----" : "Si");
						if (dr2["INet"].ToString().Trim() == "True")
						{
							dataGridView2.Rows.Add(dr2["Codigo"].ToString().Trim(), dr2["Nombre"].ToString().Trim(), dr2["Suministros"].ToString().Trim(), Fecha_ingreso.ToString("dd/MM/yyyy").Trim(), dr2["UF"].ToString().Trim(), dr2["Valor_UF"].ToString().Trim(), dr2["Consumo"].ToString().Trim(), dr2["A_Pagar"].ToString().Trim(), Impreso, Pagado, Nulo, imageList1.Images[0], Fecha_INET.ToString("dd/MM/yyyy").Trim(), 0, dr2["Registro"].ToString().Trim(), dr2["Secuencia"].ToString().Trim(), dr2["Cargo_1"].ToString().Trim(), dr2["Cargo_2"].ToString().Trim(), dr2["Cargo_3"].ToString().Trim());
						}
						else
						{
							dataGridView2.Rows.Add(dr2["Codigo"].ToString().Trim(), dr2["Nombre"].ToString().Trim(), dr2["Suministros"].ToString().Trim(), Fecha_ingreso.ToString("dd/MM/yyyy").Trim(), dr2["UF"].ToString().Trim(), dr2["Valor_UF"].ToString().Trim(), dr2["Consumo"].ToString().Trim(), dr2["A_Pagar"].ToString().Trim(), Impreso, Pagado, Nulo, imageList1.Images[1], Fecha_INET.ToString("dd/MM/yyyy").Trim(), 1, dr2["Registro"].ToString().Trim(), dr2["Secuencia"].ToString().Trim(), dr2["Cargo_1"].ToString().Trim(), dr2["Cargo_2"].ToString().Trim(), dr2["Cargo_3"].ToString().Trim());
						}
						dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
						dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						dataGridView2.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						Total += Convert.ToDouble(dr2["A_Pagar"].ToString().Trim());
					}
					text_total.Text = Func.ordenNumero(Total.ToString().Trim());
					string box_msg = "Desea imprimir copia de APORTES ¿ Confirmar ?";
					string box_title = "Confirmación";
					if (!(MessageBox.Show(box_msg, box_title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation).ToString() == "Yes"))
					{
						return;
					}
					string[] Grilla = new string[11];
					int X = 0;
					for (X = 0; X < 11; X++)
					{
						Grilla[X] = "*";
					}
					SQL = "DELETE FROM  " + ConnBdd.nombreBaseDatos + ".[Emision_Aportes]  ";
					Respuesta_SQL = cs.EjecutaQry(SQL);
					if (Respuesta_SQL.Trim() != "O.K")
					{
						MessageBox.Show("Error Entregado: " + Respuesta_SQL.Trim());
						return;
					}
					for (X = 0; X < dataGridView2.Rows.Count; X++)
					{
						Existe_Informacion = 0;
						SQL = "SELECT * FROM " + ConnBdd.nombreBaseDatos + ".Reg_Medicion WHERE Registro = " + dataGridView2.Rows[X].Cells["Registro"].Value.ToString() + " AND Secuencia  = " + dataGridView2.Rows[X].Cells["Secuencia"].Value.ToString();
						ds1 = cs.ConsultaQry(SQL);
						dt1 = ds1.Tables[0];
						{
							IEnumerator enumerator2 = dt1.Rows.GetEnumerator();
							try
							{
								if (enumerator2.MoveNext())
								{
									DataRow dr1 = (DataRow)enumerator2.Current;
									Mes = DateTime.Parse(dr1["Fecha_Hasta"].ToString().Trim()).Month + 1;
									Existe_Informacion = 1;
								}
							}
							finally
							{
								IDisposable disposable = enumerator2 as IDisposable;
								if (disposable != null)
								{
									disposable.Dispose();
								}
							}
						}
						ds1.Clear();
						dt1.Clear();
						if (Existe_Informacion == 1)
						{
							Mes2 = "";
							Mes4 = "";
							Mes5 = "";
							Respuesta_SQL = "";
							SQLInsert = "";
							Existe_Informacion = 0;
							switch (Mes)
							{
							case 1:
								Mes2 = "Octubre";
								Mes4 = "Noviembre";
								Mes5 = "Diciembre";
								break;
							case 2:
								Mes2 = "Noviembre";
								Mes4 = "Diciembre";
								Mes5 = "Enero";
								break;
							case 3:
								Mes2 = "Diciembre";
								Mes4 = "Enero";
								Mes5 = "Febrero";
								break;
							default:
								Mes2 = Mes_Procesar[Mes - 3];
								Mes4 = Mes_Procesar[Mes - 2];
								Mes5 = Mes_Procesar[Mes - 1];
								break;
							}
							Grilla[1] = dataGridView2.Rows[X].Cells["CodCC"].Value.ToString();
							Grilla[2] = dataGridView2.Rows[X].Cells["CentroDeCosto"].Value.ToString();
							Grilla[3] = dataGridView2.Rows[X].Cells["Suministro"].Value.ToString();
							Grilla[4] = "";
							Grilla[5] = "0";
							Grilla[6] = "0";
							Grilla[7] = dataGridView2.Rows[X].Cells["Total"].Value.ToString().Replace(".", "");
							Grilla[8] = dataGridView2.Rows[X].Cells["Total"].Value.ToString().Replace(".", "");
							Grilla[9] = "";
							Grilla[10] = "0";
							SQLInsert = "INSERT INTO  " + ConnBdd.nombreBaseDatos + ".[Emision_Aportes]  ";
							SQLInsert += "([CC], [Direccion] , [Descripcion], [ValoraPagar], [Monto1], [Mes1] , [Monto2], [Mes2] , [Monto3], [Mes3], [Total], [Cabecera], [Mes_de_proceso]) ";
							SQLInsert = SQLInsert + "VALUES ('" + Grilla[1] + "','" + Grilla[2] + "','" + Grilla[3] + "'," + Grilla[10] + "," + Grilla[5] + ",'" + Mes2 + "'," + Grilla[6] + ",'" + Mes4 + "'," + Grilla[7] + ",'" + Mes5 + "'," + Grilla[8] + ",'" + Cabecera + "','" + Mes_Procesar[Mes] + "')";
							Respuesta_SQL = cs.EjecutaQry(SQLInsert);
							if (Respuesta_SQL != "O.K")
							{
								MessageBox.Show("Error Entregado al ingresar respaldo en Log_Web_Lectura : " + Respuesta_SQL);
								return;
							}
						}
					}
					DocAportes doc = new DocAportes();
					doc.Visible = true;
					Imprimir imp = new Imprimir();
					imp.documentViewer1.DocumentSource = doc;
					imp.WindowState = FormWindowState.Maximized;
					imp.Show();
					return;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Ha ocurrido un error -> " + ex.ToString());
					return;
				}
				finally
				{
					cs.closeconn();
					MessageBox.Show("<< Proceso de carga terminado >>", "Mensaje");
				}
			}
			MessageBox.Show("<< Debe seleccionar año >>");
		}
		else
		{
			MessageBox.Show("<< Debe seleccionar Mes >>");
		}
	}

	private void chec_IMPRIMIR_CheckedChanged(object sender, EventArgs e)
	{
		string box_msg = "¿ Desea generar Impresión de documentos cargados en el sistema ?";
		string box_title = "Confirmación";
		if (!(MessageBox.Show(box_msg, box_title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation).ToString() != "Yes"))
		{
			return;
		}
		string[] Grilla = new string[11];
		string SQL = "";
		string Respuesta_SQL = "";
		int Existe_Informacion = 0;
		int X = 0;
		string Mes1 = "";
		string Mes2 = "";
		string Mes3 = "";
		for (X = 0; X < 11; X++)
		{
			Grilla[X] = "*";
		}
		string Cabecera = "Pago Aportes por Valor";
		ConnBdd cs = ConnBdd.getDbInstance();
		cs.GetDBConnection();
		SQL = "DELETE FROM  " + ConnBdd.nombreBaseDatos + ".[Emision_Aportes]  ";
		Respuesta_SQL = cs.EjecutaQry(SQL);
		if (Respuesta_SQL.Trim() != "O.K")
		{
			MessageBox.Show("Error Entregado: " + Respuesta_SQL.Trim());
			return;
		}
		for (X = 0; X < dataGridView2.Rows.Count; X++)
		{
			Existe_Informacion = 1;
			Grilla[1] = dataGridView2.Rows[X].Cells["CodCC"].Value.ToString();
			Grilla[2] = dataGridView2.Rows[X].Cells["CentroDeCosto"].Value.ToString();
			Grilla[3] = dataGridView2.Rows[X].Cells["UF"].Value.ToString();
			Grilla[4] = dataGridView2.Rows[X].Cells["ValoraPagar"].Value.ToString().Replace(".", "");
			Grilla[5] = dataGridView2.Rows[X].Cells["C1"].Value.ToString().Replace(".", "");
			Grilla[6] = dataGridView2.Rows[X].Cells["C2"].Value.ToString().Replace(".", "");
			Grilla[7] = dataGridView2.Rows[X].Cells["C3"].Value.ToString().Replace(".", "");
			Grilla[8] = dataGridView2.Rows[X].Cells["Total"].Value.ToString().Replace(".", "");
			Grilla[9] = dataGridView2.Rows[X].Cells["Direccion"].Value.ToString();
			Grilla[10] = dataGridView2.Rows[X].Cells["Venta"].Value.ToString();
			SQL = "INSERT INTO  " + ConnBdd.nombreBaseDatos + ".[Emision_Aportes]  ";
			SQL += "([CC], [Direccion] , [Descripcion], [ValoraPagar], [Monto1], [Mes1] , [Monto2], [Mes2] , [Monto3], [Mes3], [Total], [Cabecera], [Mes_de_proceso]) ";
			Respuesta_SQL = cs.EjecutaQry(SQL);
			if (Respuesta_SQL != "O.K")
			{
				MessageBox.Show("Error Entregado al ingresar respaldo en Log_Web_Lectura : " + Respuesta_SQL);
				return;
			}
		}
		if (Existe_Informacion == 1)
		{
			DocAportes doc = new DocAportes();
			doc.Visible = true;
			Imprimir imp = new Imprimir();
			imp.documentViewer1.DocumentSource = doc;
			imp.WindowState = FormWindowState.Maximized;
			imp.Show();
		}
	}

	private void simpleButton6_Click(object sender, EventArgs e)
	{
		Exportar_Excel(dataGridView2);
	}

	public void Exportar_Excel(DataGridView tabla)
	{
		Microsoft.Office.Interop.Excel.Application excel = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
		excel.Application.Workbooks.Add(true);
		int IndiceColumna = 0;
		foreach (DataGridViewColumn col2 in tabla.Columns)
		{
			IndiceColumna++;
			if (col2.Name != "Imagen" && col2.Name != "Registro" && col2.Name != "Secuencia" && col2.Name != "C1" && col2.Name != "C2" && col2.Name != "C3")
			{
				excel.Cells[1, IndiceColumna] = col2.Name;
			}
		}
		int IndeceFila = 0;
		foreach (DataGridViewRow row in (IEnumerable)tabla.Rows)
		{
			IndeceFila++;
			IndiceColumna = 0;
			foreach (DataGridViewColumn col in tabla.Columns)
			{
				IndiceColumna++;
				if (col.Name == "INet")
				{
					if (row.Cells["Imagen"].Value.ToString() == "1")
					{
						excel.Cells[IndeceFila + 1, IndiceColumna] = "No";
					}
					else
					{
						excel.Cells[IndeceFila + 1, IndiceColumna] = "Si";
					}
				}
				else if (col.Name != "Imagen" && col.Name != "Registro" && col.Name != "Secuencia" && col.Name != "C1" && col.Name != "C2" && col.Name != "C3")
				{
					excel.Cells[IndeceFila + 1, IndiceColumna] = row.Cells[col.Name].Value.ToString().Replace(".", "");
				}
			}
		}
		excel.Visible = true;
	}

	private void simpleButton8_Click(object sender, EventArgs e)
	{
		int contador = 0;
		int Existe_traspaso = 0;
		string box_msg = "";
		string box_title = "Confirmación";
		for (int X3 = 0; X3 < dataGridView2.Rows.Count; X3++)
		{
			if (dataGridView2.Rows[X3].Cells[11].Value.ToString() != "0")
			{
				contador++;
			}
			if (dataGridView2.Rows[X3].Cells["Imagen"].Value.ToString().Trim() == "1")
			{
				Existe_traspaso = 1;
				break;
			}
		}
		if (contador == 0)
		{
			MessageBox.Show("<< No se registra información a procesar >>");
			return;
		}
		if (Existe_traspaso == 1)
		{
			box_msg = "<< Se registran traspaso realizados anteriormente >>";
			box_title = "Confirmación";
			if (MessageBox.Show(box_msg, box_title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation).ToString() != "Yes")
			{
				return;
			}
		}
		box_msg = "Se procesara información para ser traspasada a I-NET,este traspaso esta de acuerdo a lo filtrado ¿Esta seguro de continuar?";
		box_title = "Confirmación";
		if (MessageBox.Show(box_msg, box_title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation).ToString() != "Yes")
		{
			return;
		}
		string a0 = "";
		string a1 = "";
		string a12 = "";
		string a17 = "";
		string a18 = "";
		string a19 = "";
		string a20 = "";
		string a21 = "";
		string a22 = "";
		string a23 = "";
		string a2 = "";
		string a3 = "";
		string a4 = "";
		string a5 = "";
		string a6 = "";
		string a7 = "";
		string a8 = "";
		string a9 = "";
		string a10 = "";
		string a11 = "";
		string a13 = "";
		string a14 = "";
		string a15 = "";
		string a16 = "";
		string Num_Legal = "";
		Random Valor = new Random();
		int Num_comp = Valor.Next(1, 10000);
		string path1 = "c:\\ERP\\Compro_Provision_CuentaComunidades_" + Num_comp + ".txt";
		string Centro_costo = "";
		string vfechaComp = "";
		int AreaDeNegocioInet = 0;
		string CentroCostoINet = "";
		string Texto = "";
		string Nombre_Edificio = "";
		string Glosa = "";
		string Fecha_Ingreso = "";
		int Linea = 1;
		string Fecha = "";
		string Suministro = "";
		string CtaDebe = "";
		string CtaHaber = "";
		string vSubglosa = "";
		string Mes = "";
		string Ano = "";
		string A_Pagar = "";
		string SQL_Update = ";";
		string Respuesta = "";
		string Local = "";
		CtaDebe = "5115006";
		CtaHaber = "2110007";
		Matriz Mes_Proceso = new Matriz();
		Ingresar_Fecha_ERP obj_fecha = new Ingresar_Fecha_ERP();
		obj_fecha.ShowDialog();
		if (obj_fecha.Fecha_Seleccionada != "")
		{
			vfechaComp = obj_fecha.Fecha_Seleccionada;
			vSubglosa = obj_fecha.Glosa_ERP.ToString().Trim();
			Mes = obj_fecha.Fecha_mes;
			Ano = obj_fecha.Fecha_Ano;
			Funciones Func = new Funciones();
			StreamWriter file1 = new StreamWriter(path1, append: true);
			ConnBdd cs = ConnBdd.getDbInstance();
			cs.GetDBConnection();
			a0 = "1";
			a1 = "01";
			a12 = Func.Largo_Campo_ERP(Num_comp.ToString().Trim(), 7);
			a17 = "3";
			a18 = Func.Formato_Fecha_ERP(vfechaComp);
			a19 = Func.Largo_Campo_ERP("Aporte Comunidades Edificios", 10);
			a20 = "00";
			a21 = "0";
			a22 = "0";
			Texto = a0 + a1 + a12 + a17 + a18 + a19 + a20 + a21 + a22;
			file1.WriteLine(Texto);
			DataTable dt2 = new DataTable();
			DataSet ds2 = new DataSet();
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				for (int X2 = 0; X2 < dataGridView2.Rows.Count; X2++)
				{
					Centro_costo = dataGridView2.Rows[X2].Cells["CodCC"].Value.ToString();
					Fecha_Ingreso = dataGridView2.Rows[X2].Cells["Ingreso"].Value.ToString();
					Suministro = dataGridView2.Rows[X2].Cells["Suministro"].Value.ToString();
					A_Pagar = dataGridView2.Rows[X2].Cells["Total"].Value.ToString();
					AreaDeNegocioInet = Convert.ToInt32(cs.ObtenerCampo(("SELECT [Area] FROM " + ConnBdd.nombreBaseDatos + ".CentroCostos WHERE  Codigo = " + Centro_costo) ?? "", "Area"));
					Nombre_Edificio = cs.ObtenerCampo(("SELECT [Nombre] FROM " + ConnBdd.nombreBaseDatos + ".CentroCostos WHERE  Codigo = " + Centro_costo) ?? "", "Nombre");
					Nombre_Edificio = Regex.Replace(Nombre_Edificio.Normalize(NormalizationForm.FormD), "[^a-zA-z0-9 ]+", "");
					Mes = Func.Escribe_Mes_ERP(vfechaComp);
					DataTable dt = new DataTable();
					DataSet ds = cs.ConsultaQry("SELECT  * FROM " + ConnBdd.nombreBaseDatos + ".CentroCostos WHERE Codigo='" + Centro_costo.Trim() + "'");
					dt = ds.Tables[0];
					Local = "True";
					{
						IEnumerator enumerator = dt.Rows.GetEnumerator();
						try
						{
							if (enumerator.MoveNext())
							{
								DataRow dr = (DataRow)enumerator.Current;
								if (dr["Edificios"].ToString().Trim() == "True")
								{
									Local = "False";
								}
							}
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
					CentroCostoINet = ((!(Local == "True")) ? ((Centro_costo.Length != 3) ? Centro_costo : (AreaDeNegocioInet switch
					{
						3 => "40" + Centro_costo, 
						16 => "47" + Centro_costo, 
						17 => "49" + Centro_costo, 
						18 => "46" + Centro_costo, 
						19 => "51" + Centro_costo, 
						_ => Centro_costo, 
					})) : ((Centro_costo.Length != 3) ? Centro_costo : (AreaDeNegocioInet switch
					{
						2 => "20" + Centro_costo, 
						3 => "40" + Centro_costo, 
						15 => "20" + Centro_costo, 
						16 => "47" + Centro_costo, 
						17 => "49" + Centro_costo, 
						18 => "46" + Centro_costo, 
						19 => "51" + Centro_costo, 
						_ => Centro_costo, 
					})));
					a0 = "2";
					a1 = "01";
					a12 = "3";
					a17 = Func.Largo_Campo_ERP(Num_comp.ToString().Trim(), 7);
					a18 = Func.Formato_Fecha_ERP(vfechaComp);
					a19 = Func.Largo_Campo_ERP(Linea.ToString().Trim(), 5);
					a20 = Func.Largo_Cuenta_ERP(CtaDebe, 9);
					a21 = Func.Largo_Campo_ERP(AreaDeNegocioInet.ToString(), 2);
					a22 = Func.Largo_Campo_ERP(CentroCostoINet, 5);
					a23 = Func.Largo_Campo_ERP("", 4);
					a2 = Func.Largo_Campo_ERP("1", 1);
					a3 = Func.Largo_Campo_ERP("", 12);
					a4 = Func.Largo_Campo_ERP("0", 2);
					Glosa = Func.Extraer_MES_Resumido(vfechaComp) + " Aporte " + Nombre_Edificio;
					a5 = Func.Largo_Campo_ERP(Glosa.Trim(), 25);
					a6 = Func.Largo_Campo_ERP("0", 1);
					a7 = Func.Largo_Campo_ERP("0", 3);
					a8 = Func.Largo_Campo_ERP(A_Pagar.Trim(), 14);
					a9 = Func.Largo_Campo_ERP("0", 14);
					a10 = Func.Largo_Campo_ERP("0", 14);
					a11 = Func.Largo_Campo_ERP("0", 14);
					a13 = Func.Largo_Campo_ERP("0", 9);
					a14 = Func.Largo_Campo_ERP("", 8);
					a15 = Func.Largo_Campo_ERP("", 8);
					a16 = Func.Largo_Campo_ERP("0", 10);
					Texto = a0 + a1 + a12 + a17 + a18 + a19 + a20 + a21 + a22 + a23 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10 + a11 + a13 + a14 + a15 + a16;
					file1.WriteLine(Texto);
					Linea++;
					a0 = "2";
					a1 = "01";
					a12 = "3";
					a17 = Func.Largo_Campo_ERP(Num_comp.ToString().Trim(), 7);
					a18 = Func.Formato_Fecha_ERP(vfechaComp);
					a19 = Func.Largo_Campo_ERP(Linea.ToString().Trim(), 5);
					a20 = Func.Largo_Cuenta_ERP(CtaHaber, 9);
					a21 = Func.Largo_Campo_ERP("", 2);
					a22 = Func.Largo_Campo_ERP("", 5);
					a23 = Func.Largo_Campo_ERP("", 4);
					a2 = "1";
					a3 = Func.Largo_Campo_ERP("", 12);
					a4 = Func.Largo_Campo_ERP("0", 2);
					a5 = Func.Largo_Campo_ERP(Glosa.Trim(), 25);
					a6 = Func.Largo_Campo_ERP("0", 1);
					a7 = Func.Largo_Campo_ERP("0", 3);
					a8 = Func.Largo_Campo_ERP("0", 14);
					a9 = Func.Largo_Campo_ERP(A_Pagar.Trim(), 14);
					a10 = Func.Largo_Campo_ERP("0", 14);
					a11 = Func.Largo_Campo_ERP("0", 14);
					a13 = Func.Largo_Cuenta_ERP("0", 9);
					a14 = Func.Largo_Campo_ERP("", 8);
					a15 = Func.Largo_Campo_ERP("", 8);
					a16 = Func.Largo_Campo_ERP("0", 10);
					Texto = a0 + a1 + a12 + a17 + a18 + a19 + a20 + a21 + a22 + a23 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10 + a11 + a13 + a14 + a15 + a16;
					file1.WriteLine(Texto);
					Linea++;
				}
				file1.Close();
				DateTime Fecha_Dia = DateTime.Now;
				string Secuencia = "";
				for (int X = 0; X < dataGridView2.Rows.Count; X++)
				{
					if (dataGridView2.Rows[X].Cells[7].Value.ToString() != "0")
					{
						Centro_costo = dataGridView2.Rows[X].Cells[0].Value.ToString();
						Fecha_Ingreso = dataGridView2.Rows[X].Cells[3].Value.ToString();
						Secuencia = dataGridView2.Rows[X].Cells["Secuencia"].Value.ToString();
						SQL_Update = "UPDATE " + ConnBdd.nombreBaseDatos + ".[Reg_Medicion]  SET ";
						SQL_Update = SQL_Update + "INet = 'True', INet_Fecha = CONVERT(smalldatetime, '" + Fecha_Dia.ToString("dd/MM/yyyy") + "', 103)";
						SQL_Update = SQL_Update + "  WHERE Cod_CC = " + Centro_costo + " and Fecha = CONVERT(smalldatetime,'" + Fecha_Ingreso.Trim() + "',103) AND Secuencia = " + Secuencia;
						Respuesta = cs.EjecutaQry(SQL_Update);
						if (Respuesta != "O.K")
						{
							MessageBox.Show("Error Entregado: " + Respuesta);
							return;
						}
						dataGridView2.Rows[X].Cells[11].Value = imageList1.Images[0];
						dataGridView2.Rows[X].Cells[12].Value = Fecha_Dia.ToString("dd/MM/yyyy");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ha ocurrido un error -> " + ex.ToString());
				Cursor.Current = Cursors.Default;
			}
			finally
			{
				cs.closeconn();
				Cursor.Current = Cursors.Default;
			}
			MessageBox.Show("<< Proceso de generación de archivo Exitoso >>");
		}
		else
		{
			MessageBox.Show("<< No se registran fecha ingresada para generar comprobante >>");
		}
	}

	private void simpleButton4_Click(object sender, EventArgs e)
	{
		Funciones Func = new Funciones();
		int i = 0;
		double Total = 0.0;
		int selectedRowCount = dataGridView2.Rows.GetRowCount(DataGridViewElementStates.Selected);
		int indice = 0;
		for (int X4 = 0; X4 < dataGridView2.Rows.Count; X4++)
		{
			indice++;
		}
		string[,] Grilla = new string[indice, 20];
		for (int X3 = 0; X3 < indice; X3++)
		{
			Grilla[X3, 0] = "*";
		}
		i = 0;
		for (int X2 = 0; X2 < dataGridView2.Rows.Count; X2++)
		{
			Grilla[i, 0] = dataGridView2.Rows[X2].Cells[0].Value.ToString();
			Grilla[i, 1] = dataGridView2.Rows[X2].Cells[1].Value.ToString();
			Grilla[i, 2] = dataGridView2.Rows[X2].Cells[2].Value.ToString();
			Grilla[i, 3] = dataGridView2.Rows[X2].Cells[3].Value.ToString();
			Grilla[i, 4] = dataGridView2.Rows[X2].Cells[4].Value.ToString();
			Grilla[i, 5] = dataGridView2.Rows[X2].Cells[5].Value.ToString();
			Grilla[i, 6] = dataGridView2.Rows[X2].Cells[6].Value.ToString();
			Grilla[i, 7] = dataGridView2.Rows[X2].Cells[7].Value.ToString();
			Grilla[i, 8] = dataGridView2.Rows[X2].Cells[8].Value.ToString();
			Grilla[i, 9] = dataGridView2.Rows[X2].Cells[9].Value.ToString();
			Grilla[i, 10] = dataGridView2.Rows[X2].Cells[10].Value.ToString();
			Grilla[i, 11] = "";
			Grilla[i, 12] = dataGridView2.Rows[X2].Cells[12].Value.ToString();
			Grilla[i, 13] = dataGridView2.Rows[X2].Cells[13].Value.ToString();
			Grilla[i, 14] = dataGridView2.Rows[X2].Cells[14].Value.ToString();
			Grilla[i, 15] = dataGridView2.Rows[X2].Cells[15].Value.ToString();
			Grilla[i, 16] = dataGridView2.Rows[X2].Cells[16].Value.ToString();
			Grilla[i, 17] = dataGridView2.Rows[X2].Cells[16].Value.ToString();
			Grilla[i, 18] = dataGridView2.Rows[X2].Cells[16].Value.ToString();
			Grilla[i, 19] = "0";
			i++;
		}
		if (selectedRowCount <= 0)
		{
			return;
		}
		for (i = 0; i < selectedRowCount; i++)
		{
			Grilla[Convert.ToInt32(dataGridView2.SelectedRows[i].Index.ToString()), 19] = "1";
		}
		dataGridView2.Rows.Clear();
		for (int X = 0; X < indice; X++)
		{
			if (Grilla[X, 19].ToString() == "1")
			{
				if (Grilla[X, 13].ToString() == "0")
				{
					dataGridView2.Rows.Add(Grilla[X, 0].ToString().Trim(), Grilla[X, 1].ToString().Trim(), Grilla[X, 2].ToString().Trim(), Grilla[X, 3].ToString().Trim(), Grilla[X, 4].ToString().Trim(), Grilla[X, 5].ToString().Trim(), Grilla[X, 6].ToString().Trim(), Grilla[X, 7].ToString().Trim(), Grilla[X, 8].ToString().Trim(), Grilla[X, 9].ToString().Trim(), Grilla[X, 10].ToString().Trim(), imageList1.Images[0], Grilla[X, 12].ToString().Trim(), Grilla[X, 13].ToString().Trim(), Grilla[X, 14].ToString().Trim(), Grilla[X, 15].ToString().Trim(), Grilla[X, 16].ToString().Trim(), Grilla[X, 17].ToString().Trim(), Grilla[X, 18].ToString().Trim());
				}
				else
				{
					dataGridView2.Rows.Add(Grilla[X, 0].ToString().Trim(), Grilla[X, 1].ToString().Trim(), Grilla[X, 2].ToString().Trim(), Grilla[X, 3].ToString().Trim(), Grilla[X, 4].ToString().Trim(), Grilla[X, 5].ToString().Trim(), Grilla[X, 6].ToString().Trim(), Grilla[X, 7].ToString().Trim(), Grilla[X, 8].ToString().Trim(), Grilla[X, 9].ToString().Trim(), Grilla[X, 10].ToString().Trim(), imageList1.Images[1], Grilla[X, 12].ToString().Trim(), Grilla[X, 13].ToString().Trim(), Grilla[X, 14].ToString().Trim(), Grilla[X, 15].ToString().Trim(), Grilla[X, 16].ToString().Trim(), Grilla[X, 17].ToString().Trim(), Grilla[X, 18].ToString().Trim());
				}
				Total += Convert.ToDouble(Grilla[X, 7].ToString().Trim());
			}
		}
		text_total.Text = Func.ordenNumero(Total.ToString().Trim());
	}

	private void simpleButton3_Click(object sender, EventArgs e)
	{
		string box_msg = "";
		string box_title = "Confirmación";
		box_msg = "<< Se eliminara rl estado de traspaso, a los datos seleccionados en pantalla>>";
		box_title = "Confirmación";
		if (MessageBox.Show(box_msg, box_title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation).ToString() != "Yes")
		{
			return;
		}
		string Centro_costo = "";
		string Fecha_Ingreso = "";
		string SQL_Update = "";
		string Respuesta = "";
		string Secuencia = "";
		ConnBdd cs = ConnBdd.getDbInstance();
		cs.GetDBConnection();
		try
		{
			for (int X = 0; X < dataGridView2.Rows.Count; X++)
			{
				Centro_costo = dataGridView2.Rows[X].Cells["CodCC"].Value.ToString();
				Fecha_Ingreso = dataGridView2.Rows[X].Cells["Ingreso"].Value.ToString();
				Secuencia = dataGridView2.Rows[X].Cells["Secuencia"].Value.ToString();
				SQL_Update = "UPDATE " + ConnBdd.nombreBaseDatos + ".[Reg_Medicion]  SET ";
				SQL_Update += "INet = 'False', INet_Fecha = CONVERT(smalldatetime, '01/01/1900', 103)";
				SQL_Update = SQL_Update + "  WHERE Cod_CC = " + Centro_costo + " and Fecha = CONVERT(smalldatetime,'" + Fecha_Ingreso.Trim() + "',103) AND Secuencia = " + Secuencia;
				Respuesta = cs.EjecutaQry(SQL_Update);
				if (Respuesta != "O.K")
				{
					MessageBox.Show("Error Entregado: " + Respuesta);
					break;
				}
				dataGridView2.Rows[X].Cells[12].Value = imageList1.Images[1];
				dataGridView2.Rows[X].Cells[13].Value = "01/01/1900";
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("Ha ocurrido un error -> " + ex.ToString());
		}
		finally
		{
			cs.closeconn();
		}
	}

	private void btnAceptar_Click(object sender, EventArgs e)
	{
		dataGridView2.Rows.Clear();
		comboBox1.SelectedIndex = -1;
		comboBox2.SelectedIndex = -1;
		text_CentroCosto.Text = "";
		text_Area.Text = "";
		Activar_ModTraspaso.Checked = false;
		text_total.Text = "";
	}

	private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex < 0)
		{
			return;
		}
		if (e.ColumnIndex == 0)
		{
			Funciones Func = new Funciones();
			string Impreso = "";
			string Pagado = "";
			string Nulo = "";
			double Total = 0.0;
			int Encontrado = 0;
			int pos = dataGridView2.CurrentRow.Index;
			string Centro_Costo = dataGridView2.Rows[e.RowIndex].Cells["CodCC"].Value.ToString();
			string Secuencia3 = dataGridView2.Rows[e.RowIndex].Cells["Secuencia"].Value.ToString();
			string Concepto = dataGridView2.Rows[e.RowIndex].Cells["Suministro"].Value.ToString();
			if (Centro_Costo != "" && Secuencia3 != "")
			{
				Mostrar_Detalle_Aporte frm = new Mostrar_Detalle_Aporte(Centro_Costo, Secuencia3, Concepto);
				frm.ShowDialog();
				ConnBdd cs3 = ConnBdd.getDbInstance();
				cs3.GetDBConnection();
				try
				{
					DataTable dt1 = new DataTable();
					DataSet ds1 = new DataSet();
					DataTable dt2 = new DataTable();
					DataSet ds2 = new DataSet();
					ds1 = cs3.ConsultaQry("SELECT * FROM " + ConnBdd.nombreBaseDatos + ".Reg_Medicion WHERE Cod_CC = " + Centro_Costo + " AND Secuencia = " + Secuencia3);
					dt1 = ds1.Tables[0];
					IEnumerator enumerator = dt1.Rows.GetEnumerator();
					try
					{
						if (enumerator.MoveNext())
						{
							DataRow dr1 = (DataRow)enumerator.Current;
							Encontrado = 1;
							if (Func.EsFecha(dr1["Fecha"].ToString().Trim()))
							{
								DateTime Fecha_ingreso = DateTime.Parse(dr1["Fecha"].ToString().Trim());
							}
							else
							{
								DateTime Fecha_ingreso = DateTime.Parse("01/01/1900");
							}
							DateTime Fecha_INET = ((!Func.EsFecha(dr1["INet_Fecha"].ToString().Trim())) ? DateTime.Parse("01/01/1900") : DateTime.Parse(dr1["INet_Fecha"].ToString().Trim()));
							Impreso = ((!(dr1["Impreso"].ToString().Trim() == "True")) ? "-----" : "Si");
							Pagado = ((!(dr1["Pagado"].ToString().Trim() == "True")) ? "-----" : "Si");
							Nulo = ((!(dr1["Nulo"].ToString().Trim() == "True")) ? "-----" : "Si");
							if (dr1["INet"].ToString().Trim() == "True")
							{
								dataGridView2.Rows[e.RowIndex].Cells["INet"].Value = imageList1.Images[0];
								dataGridView2.Rows[e.RowIndex].Cells["INET_Fecha"].Value = Fecha_INET.ToString("dd/MM/yyyy").Trim();
								dataGridView2.Rows[e.RowIndex].Cells["Imagen"].Value = "0";
							}
							else
							{
								dataGridView2.Rows[e.RowIndex].Cells["INet"].Value = imageList1.Images[1];
								dataGridView2.Rows[e.RowIndex].Cells["INET_Fecha"].Value = DateTime.Parse("01/01/1900");
								dataGridView2.Rows[e.RowIndex].Cells["Imagen"].Value = "1";
							}
							dataGridView2.Rows[e.RowIndex].Cells["UF"].Value = dr1["UF"].ToString().Trim();
							dataGridView2.Rows[e.RowIndex].Cells["ValorUF"].Value = dr1["Valor_UF"].ToString().Trim();
							dataGridView2.Rows[e.RowIndex].Cells["Consumo"].Value = dr1["Consumo"].ToString().Trim();
							dataGridView2.Rows[e.RowIndex].Cells["Total"].Value = Func.ordenNumero(dr1["A_Pagar"].ToString().Trim());
							dataGridView2.Rows[e.RowIndex].Cells["Imprime"].Value = Impreso;
							dataGridView2.Rows[e.RowIndex].Cells["Pagado"].Value = Pagado;
							dataGridView2.Rows[e.RowIndex].Cells["Nulo"].Value = Nulo;
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
					ds1.Clear();
					dt1.Clear();
				}
				catch (Exception ex3)
				{
					MessageBox.Show("Ha ocurrido un error -> " + ex3.ToString());
				}
				finally
				{
					cs3.closeconn();
				}
				if (Encontrado == 0)
				{
					dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
				}
			}
		}
		if (e.ColumnIndex == 11)
		{
			if (!Activar_ModTraspaso.Checked)
			{
				MessageBox.Show("<< Debe activar el estado, de modificación de TRASPASO  >>", "Mensaje");
			}
			else
			{
				ConnBdd cs2 = ConnBdd.getDbInstance();
				cs2.GetDBConnection();
				try
				{
					string Centro_costo2 = "";
					string Fecha_Ingreso2 = "";
					string SQL_Update2 = "";
					string Respuesta2 = "";
					string Secuencia2 = "";
					Centro_costo2 = dataGridView2.Rows[e.RowIndex].Cells["CodCC"].Value.ToString();
					Fecha_Ingreso2 = dataGridView2.Rows[e.RowIndex].Cells["Ingreso"].Value.ToString();
					Secuencia2 = dataGridView2.Rows[e.RowIndex].Cells["Secuencia"].Value.ToString();
					if (dataGridView2.Rows[e.RowIndex].Cells["Imagen"].Value.ToString().Trim() == "1")
					{
						SQL_Update2 = "UPDATE " + ConnBdd.nombreBaseDatos + ".[Reg_Medicion]  SET ";
						SQL_Update2 = SQL_Update2 + "INet = 'True', INet_Fecha = CONVERT(smalldatetime,'" + DateTime.Now.ToString("dd / MM / yyyy") + "', 103)";
						SQL_Update2 = SQL_Update2 + "  WHERE Cod_CC = " + Centro_costo2 + " and Fecha = CONVERT(smalldatetime,'" + Fecha_Ingreso2.Trim() + "',103) AND Secuencia = " + Secuencia2;
					}
					else
					{
						SQL_Update2 = "UPDATE " + ConnBdd.nombreBaseDatos + ".[Reg_Medicion]  SET ";
						SQL_Update2 += "INet = 'False', INet_Fecha = CONVERT(smalldatetime, '01/01/1900', 103)";
						SQL_Update2 = SQL_Update2 + "  WHERE Cod_CC = " + Centro_costo2 + " and Fecha = CONVERT(smalldatetime,'" + Fecha_Ingreso2.Trim() + "',103) AND Secuencia = " + Secuencia2;
					}
					Respuesta2 = cs2.EjecutaQry(SQL_Update2);
					if (Respuesta2 != "O.K")
					{
						MessageBox.Show("Error Entregado: " + Respuesta2);
						return;
					}
					if (dataGridView2.Rows[e.RowIndex].Cells["Imagen"].Value.ToString().Trim() == "0")
					{
						dataGridView2.Rows[e.RowIndex].Cells[11].Value = imageList1.Images[1];
						dataGridView2.Rows[e.RowIndex].Cells[12].Value = "01/01/1900";
						dataGridView2.Rows[e.RowIndex].Cells["Imagen"].Value = 1;
					}
					else
					{
						dataGridView2.Rows[e.RowIndex].Cells[11].Value = imageList1.Images[0];
						dataGridView2.Rows[e.RowIndex].Cells[12].Value = DateTime.Now.ToString("dd/MM/yyyy");
						dataGridView2.Rows[e.RowIndex].Cells["Imagen"].Value = 0;
					}
				}
				catch (Exception ex2)
				{
					MessageBox.Show("Ha ocurrido un error -> " + ex2.ToString());
				}
				finally
				{
					cs2.closeconn();
				}
			}
		}
		if (e.ColumnIndex != 12)
		{
			return;
		}
		if (!Activar_ModTraspaso.Checked)
		{
			MessageBox.Show("<< Debe activar el estado, de modificación de TRASPASO  >>", "Mensaje");
		}
		Ingresar_Fecha obj_fecha = new Ingresar_Fecha();
		obj_fecha.ShowDialog();
		if (!(obj_fecha.Fecha_Seleccionada != ""))
		{
			return;
		}
		DateTime Fecha_Inet = DateTime.Parse(obj_fecha.Fecha_Seleccionada);
		ConnBdd cs = ConnBdd.getDbInstance();
		cs.GetDBConnection();
		try
		{
			string Centro_costo = "";
			string Fecha_Ingreso = "";
			string SQL_Update = "";
			string Respuesta = "";
			string Secuencia = "";
			Centro_costo = dataGridView2.Rows[e.RowIndex].Cells["CodCC"].Value.ToString();
			Fecha_Ingreso = dataGridView2.Rows[e.RowIndex].Cells["Ingreso"].Value.ToString();
			Secuencia = dataGridView2.Rows[e.RowIndex].Cells["Secuencia"].Value.ToString();
			SQL_Update = "UPDATE " + ConnBdd.nombreBaseDatos + ".[Reg_Medicion]  SET ";
			SQL_Update = SQL_Update + "INet_Fecha = CONVERT(smalldatetime,'" + Fecha_Inet.ToString("dd/MM/yyyy") + "', 103)";
			SQL_Update = SQL_Update + "  WHERE Cod_CC = " + Centro_costo + " and Fecha = CONVERT(smalldatetime,'" + Fecha_Ingreso.Trim() + "',103) AND Secuencia = " + Secuencia;
			Respuesta = cs.EjecutaQry(SQL_Update);
			if (Respuesta != "O.K")
			{
				MessageBox.Show("Error Entregado: " + Respuesta);
			}
			else
			{
				dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Fecha_Inet.ToString("dd/MM/yyyy");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("Ha ocurrido un error -> " + ex.ToString());
		}
		finally
		{
			cs.closeconn();
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		Mostrar_Edificios obj_Edificio = new Mostrar_Edificios();
		obj_Edificio.ShowDialog();
		if (obj_Edificio.CC_Seleccionado != "")
		{
			text_CentroCosto.Text = obj_Edificio.CC_Seleccionado;
		}
		obj_Edificio.Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SistemaEdificios.Act_Aporte));
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
		this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
		this.Activar_ModTraspaso = new System.Windows.Forms.CheckBox();
		this.text_total = new System.Windows.Forms.TextBox();
		this.simpleButton15 = new DevExpress.XtraEditors.SimpleButton();
		this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.label4 = new System.Windows.Forms.Label();
		this.comboBox2 = new System.Windows.Forms.ComboBox();
		this.label5 = new System.Windows.Forms.Label();
		this.chec_IMPRIMIR = new System.Windows.Forms.CheckBox();
		this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
		this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.text_CentroCosto = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.text_Area = new System.Windows.Forms.TextBox();
		this.dataGridView2 = new System.Windows.Forms.DataGridView();
		this.CodCC = new System.Windows.Forms.DataGridViewButtonColumn();
		this.CentroDeCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Suministro = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Ingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.UF = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.ValorUF = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Consumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Imprime = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Pagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Nulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.INet = new System.Windows.Forms.DataGridViewImageColumn();
		this.INET_Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Imagen = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Registro = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Secuencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.C1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.C2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.C3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton8 = new DevExpress.XtraEditors.SimpleButton();
		this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
		this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton9 = new DevExpress.XtraEditors.SimpleButton();
		this.imageList1 = new System.Windows.Forms.ImageList(this.components);
		((System.ComponentModel.ISupportInitialize)this.groupControl3).BeginInit();
		this.groupControl3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.groupControl5).BeginInit();
		this.groupControl5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.groupControl2).BeginInit();
		this.groupControl2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.groupControl1).BeginInit();
		this.groupControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dataGridView2).BeginInit();
		base.SuspendLayout();
		this.groupControl3.CaptionImageOptions.Image = (System.Drawing.Image)resources.GetObject("groupControl3.CaptionImageOptions.Image");
		this.groupControl3.Controls.Add(this.groupControl5);
		this.groupControl3.Controls.Add(this.text_total);
		this.groupControl3.Controls.Add(this.simpleButton15);
		this.groupControl3.Controls.Add(this.groupControl2);
		this.groupControl3.Controls.Add(this.groupControl1);
		this.groupControl3.Controls.Add(this.dataGridView2);
		this.groupControl3.Controls.Add(this.textBox1);
		this.groupControl3.Location = new System.Drawing.Point(5, 5);
		this.groupControl3.Name = "groupControl3";
		this.groupControl3.Size = new System.Drawing.Size(1276, 607);
		this.groupControl3.TabIndex = 550;
		this.groupControl3.Text = "Detalle de Pagos por Aportes";
		this.groupControl5.CaptionImageOptions.Image = (System.Drawing.Image)resources.GetObject("groupControl5.CaptionImageOptions.Image");
		this.groupControl5.Controls.Add(this.Activar_ModTraspaso);
		this.groupControl5.Location = new System.Drawing.Point(903, 41);
		this.groupControl5.Name = "groupControl5";
		this.groupControl5.Size = new System.Drawing.Size(181, 52);
		this.groupControl5.TabIndex = 629;
		this.groupControl5.Text = "Modifica estado de Traspaso";
		this.Activar_ModTraspaso.AutoSize = true;
		this.Activar_ModTraspaso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Activar_ModTraspaso.Location = new System.Drawing.Point(12, 27);
		this.Activar_ModTraspaso.Name = "Activar_ModTraspaso";
		this.Activar_ModTraspaso.Size = new System.Drawing.Size(75, 20);
		this.Activar_ModTraspaso.TabIndex = 625;
		this.Activar_ModTraspaso.Text = "Activar";
		this.Activar_ModTraspaso.UseVisualStyleBackColor = true;
		this.text_total.Enabled = false;
		this.text_total.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.text_total.Location = new System.Drawing.Point(1138, 71);
		this.text_total.Name = "text_total";
		this.text_total.Size = new System.Drawing.Size(122, 23);
		this.text_total.TabIndex = 612;
		this.text_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.simpleButton15.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("simpleButton15.ImageOptions.Image");
		this.simpleButton15.Location = new System.Drawing.Point(1094, 69);
		this.simpleButton15.Name = "simpleButton15";
		this.simpleButton15.Size = new System.Drawing.Size(38, 26);
		this.simpleButton15.TabIndex = 611;
		this.groupControl2.CaptionImageOptions.Image = (System.Drawing.Image)resources.GetObject("groupControl2.CaptionImageOptions.Image");
		this.groupControl2.Controls.Add(this.comboBox1);
		this.groupControl2.Controls.Add(this.label4);
		this.groupControl2.Controls.Add(this.comboBox2);
		this.groupControl2.Controls.Add(this.label5);
		this.groupControl2.Controls.Add(this.chec_IMPRIMIR);
		this.groupControl2.Location = new System.Drawing.Point(11, 41);
		this.groupControl2.Name = "groupControl2";
		this.groupControl2.Size = new System.Drawing.Size(536, 52);
		this.groupControl2.TabIndex = 579;
		this.groupControl2.Text = "Aplicar Filtro";
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Location = new System.Drawing.Point(92, 27);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(133, 21);
		this.comboBox1.TabIndex = 580;
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Modern No. 20", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(14, 24);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(77, 21);
		this.label4.TabIndex = 579;
		this.label4.Text = "Período";
		this.comboBox2.FormattingEnabled = true;
		this.comboBox2.Location = new System.Drawing.Point(288, 27);
		this.comboBox2.Name = "comboBox2";
		this.comboBox2.Size = new System.Drawing.Size(108, 21);
		this.comboBox2.TabIndex = 581;
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.Location = new System.Drawing.Point(234, 23);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(48, 24);
		this.label5.TabIndex = 582;
		this.label5.Text = "Año";
		this.chec_IMPRIMIR.AutoSize = true;
		this.chec_IMPRIMIR.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.chec_IMPRIMIR.Location = new System.Drawing.Point(418, 27);
		this.chec_IMPRIMIR.Name = "chec_IMPRIMIR";
		this.chec_IMPRIMIR.Size = new System.Drawing.Size(99, 23);
		this.chec_IMPRIMIR.TabIndex = 577;
		this.chec_IMPRIMIR.Text = "Imprimir";
		this.chec_IMPRIMIR.UseVisualStyleBackColor = true;
		this.chec_IMPRIMIR.CheckedChanged += new System.EventHandler(chec_IMPRIMIR_CheckedChanged);
		this.groupControl1.CaptionImageOptions.Image = (System.Drawing.Image)resources.GetObject("groupControl1.CaptionImageOptions.Image");
		this.groupControl1.Controls.Add(this.simpleButton5);
		this.groupControl1.Controls.Add(this.simpleButton2);
		this.groupControl1.Controls.Add(this.text_CentroCosto);
		this.groupControl1.Controls.Add(this.label3);
		this.groupControl1.Controls.Add(this.label7);
		this.groupControl1.Controls.Add(this.text_Area);
		this.groupControl1.Location = new System.Drawing.Point(553, 41);
		this.groupControl1.Name = "groupControl1";
		this.groupControl1.Size = new System.Drawing.Size(345, 52);
		this.groupControl1.TabIndex = 578;
		this.groupControl1.Text = "Aplicar Filtro";
		this.simpleButton5.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("simpleButton5.ImageOptions.Image");
		this.simpleButton5.Location = new System.Drawing.Point(265, 2);
		this.simpleButton5.Name = "simpleButton5";
		this.simpleButton5.Size = new System.Drawing.Size(71, 19);
		this.simpleButton5.TabIndex = 616;
		this.simpleButton5.Text = "Borra";
		this.simpleButton2.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("simpleButton2.ImageOptions.Image");
		this.simpleButton2.Location = new System.Drawing.Point(151, 25);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(71, 22);
		this.simpleButton2.TabIndex = 612;
		this.simpleButton2.Text = "Buscar";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.text_CentroCosto.Location = new System.Drawing.Point(70, 25);
		this.text_CentroCosto.Name = "text_CentroCosto";
		this.text_CentroCosto.Size = new System.Drawing.Size(73, 21);
		this.text_CentroCosto.TabIndex = 611;
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.Location = new System.Drawing.Point(7, 29);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(56, 15);
		this.label3.TabIndex = 610;
		this.label3.Text = "C.Costo";
		this.label7.AutoSize = true;
		this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label7.Location = new System.Drawing.Point(228, 28);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(36, 15);
		this.label7.TabIndex = 609;
		this.label7.Text = "Area";
		this.text_Area.Location = new System.Drawing.Point(268, 26);
		this.text_Area.Name = "text_Area";
		this.text_Area.Size = new System.Drawing.Size(68, 21);
		this.text_Area.TabIndex = 571;
		this.dataGridView2.AllowUserToAddRows = false;
		this.dataGridView2.AllowUserToDeleteRows = false;
		this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
		dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25f);
		dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
		dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
		this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView2.Columns.AddRange(this.CodCC, this.CentroDeCosto, this.Suministro, this.Ingreso, this.UF, this.ValorUF, this.Consumo, this.Total, this.Imprime, this.Pagado, this.Nulo, this.INet, this.INET_Fecha, this.Imagen, this.Registro, this.Secuencia, this.C1, this.C2, this.C3);
		this.dataGridView2.EnableHeadersVisualStyles = false;
		this.dataGridView2.Location = new System.Drawing.Point(11, 99);
		this.dataGridView2.Name = "dataGridView2";
		this.dataGridView2.ReadOnly = true;
		this.dataGridView2.Size = new System.Drawing.Size(1249, 503);
		this.dataGridView2.TabIndex = 23;
		this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView2_CellContentClick);
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		this.CodCC.DefaultCellStyle = dataGridViewCellStyle2;
		this.CodCC.HeaderText = "Codigo";
		this.CodCC.Name = "CodCC";
		this.CodCC.ReadOnly = true;
		this.CodCC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		this.CodCC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
		this.CodCC.Width = 60;
		this.CentroDeCosto.HeaderText = "Centro de Costo";
		this.CentroDeCosto.Name = "CentroDeCosto";
		this.CentroDeCosto.ReadOnly = true;
		this.CentroDeCosto.Width = 250;
		this.Suministro.HeaderText = "Suministro";
		this.Suministro.Name = "Suministro";
		this.Suministro.ReadOnly = true;
		this.Suministro.Width = 150;
		this.Ingreso.HeaderText = "Ingreso";
		this.Ingreso.Name = "Ingreso";
		this.Ingreso.ReadOnly = true;
		this.Ingreso.Width = 80;
		this.UF.HeaderText = "UF/Valor";
		this.UF.Name = "UF";
		this.UF.ReadOnly = true;
		this.UF.Width = 80;
		this.ValorUF.HeaderText = "Valor";
		this.ValorUF.Name = "ValorUF";
		this.ValorUF.ReadOnly = true;
		this.ValorUF.Width = 80;
		this.Consumo.HeaderText = "Consumo";
		this.Consumo.Name = "Consumo";
		this.Consumo.ReadOnly = true;
		this.Consumo.Width = 70;
		this.Total.HeaderText = "Total";
		this.Total.Name = "Total";
		this.Total.ReadOnly = true;
		this.Total.Width = 80;
		this.Imprime.HeaderText = "Imprime";
		this.Imprime.MinimumWidth = 70;
		this.Imprime.Name = "Imprime";
		this.Imprime.ReadOnly = true;
		this.Imprime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		this.Imprime.Width = 70;
		this.Pagado.HeaderText = "Pagado";
		this.Pagado.Name = "Pagado";
		this.Pagado.ReadOnly = true;
		this.Pagado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		this.Pagado.Width = 70;
		this.Nulo.HeaderText = "Nulo";
		this.Nulo.Name = "Nulo";
		this.Nulo.ReadOnly = true;
		this.Nulo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		this.Nulo.Width = 70;
		this.INet.HeaderText = "I-Net";
		this.INet.Name = "INet";
		this.INet.ReadOnly = true;
		this.INet.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		this.INet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
		this.INet.Width = 70;
		this.INET_Fecha.HeaderText = "I-NET Fecha";
		this.INET_Fecha.Name = "INET_Fecha";
		this.INET_Fecha.ReadOnly = true;
		this.INET_Fecha.Width = 70;
		this.Imagen.HeaderText = "Imagen";
		this.Imagen.Name = "Imagen";
		this.Imagen.ReadOnly = true;
		this.Imagen.Visible = false;
		this.Registro.HeaderText = "Registro";
		this.Registro.Name = "Registro";
		this.Registro.ReadOnly = true;
		this.Registro.Visible = false;
		this.Secuencia.HeaderText = "Secuencia";
		this.Secuencia.Name = "Secuencia";
		this.Secuencia.ReadOnly = true;
		this.Secuencia.Visible = false;
		this.C1.HeaderText = "C1";
		this.C1.Name = "C1";
		this.C1.ReadOnly = true;
		this.C1.Visible = false;
		this.C2.HeaderText = "C2";
		this.C2.Name = "C2";
		this.C2.ReadOnly = true;
		this.C2.Visible = false;
		this.C3.HeaderText = "C3";
		this.C3.Name = "C3";
		this.C3.ReadOnly = true;
		this.C3.Visible = false;
		this.textBox1.Location = new System.Drawing.Point(204, -311);
		this.textBox1.Multiline = true;
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(316, 103);
		this.textBox1.TabIndex = 352;
		this.simpleButton3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
		this.simpleButton3.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("simpleButton3.ImageOptions.Image");
		this.simpleButton3.Location = new System.Drawing.Point(344, 625);
		this.simpleButton3.Name = "simpleButton3";
		this.simpleButton3.Size = new System.Drawing.Size(111, 31);
		this.simpleButton3.TabIndex = 636;
		this.simpleButton3.Text = "Eliminar \nTraspaso";
		this.simpleButton3.Click += new System.EventHandler(simpleButton3_Click);
		this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
		this.simpleButton1.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("simpleButton1.ImageOptions.Image");
		this.simpleButton1.Location = new System.Drawing.Point(11, 623);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(105, 31);
		this.simpleButton1.TabIndex = 635;
		this.simpleButton1.Text = "Procesar";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton4.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
		this.simpleButton4.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("simpleButton4.ImageOptions.Image");
		this.simpleButton4.Location = new System.Drawing.Point(122, 623);
		this.simpleButton4.Name = "simpleButton4";
		this.simpleButton4.Size = new System.Drawing.Size(105, 31);
		this.simpleButton4.TabIndex = 634;
		this.simpleButton4.Text = "Seleccionar";
		this.simpleButton4.Click += new System.EventHandler(simpleButton4_Click);
		this.simpleButton6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton6.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
		this.simpleButton6.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("simpleButton6.ImageOptions.Image");
		this.simpleButton6.Location = new System.Drawing.Point(233, 624);
		this.simpleButton6.Name = "simpleButton6";
		this.simpleButton6.Size = new System.Drawing.Size(105, 31);
		this.simpleButton6.TabIndex = 633;
		this.simpleButton6.Text = "Excel";
		this.simpleButton6.Click += new System.EventHandler(simpleButton6_Click);
		this.simpleButton8.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton8.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
		this.simpleButton8.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("simpleButton8.ImageOptions.Image");
		this.simpleButton8.Location = new System.Drawing.Point(692, 624);
		this.simpleButton8.Name = "simpleButton8";
		this.simpleButton8.Size = new System.Drawing.Size(111, 31);
		this.simpleButton8.TabIndex = 632;
		this.simpleButton8.Text = "Generar Comp.\r\nProvisión";
		this.simpleButton8.Click += new System.EventHandler(simpleButton8_Click);
		this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
		this.btnCancelar.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnCancelar.ImageOptions.Image");
		this.btnCancelar.Location = new System.Drawing.Point(1155, 625);
		this.btnCancelar.Name = "btnCancelar";
		this.btnCancelar.Size = new System.Drawing.Size(105, 31);
		this.btnCancelar.TabIndex = 631;
		this.btnCancelar.Text = "Salir";
		this.btnCancelar.Click += new System.EventHandler(btnCancelar_Click);
		this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
		this.btnAceptar.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnAceptar.ImageOptions.Image");
		this.btnAceptar.Location = new System.Drawing.Point(1045, 624);
		this.btnAceptar.Name = "btnAceptar";
		this.btnAceptar.Size = new System.Drawing.Size(105, 31);
		this.btnAceptar.TabIndex = 630;
		this.btnAceptar.Text = "Borrar";
		this.btnAceptar.Click += new System.EventHandler(btnAceptar_Click);
		this.simpleButton7.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton7.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
		this.simpleButton7.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("simpleButton7.ImageOptions.Image");
		this.simpleButton7.Location = new System.Drawing.Point(461, 625);
		this.simpleButton7.Name = "simpleButton7";
		this.simpleButton7.Size = new System.Drawing.Size(111, 31);
		this.simpleButton7.TabIndex = 637;
		this.simpleButton7.Text = "Aporte x\r\nValor";
		this.simpleButton7.Click += new System.EventHandler(simpleButton7_Click);
		this.simpleButton9.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton9.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
		this.simpleButton9.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("simpleButton9.ImageOptions.Image");
		this.simpleButton9.Location = new System.Drawing.Point(576, 624);
		this.simpleButton9.Name = "simpleButton9";
		this.simpleButton9.Size = new System.Drawing.Size(111, 31);
		this.simpleButton9.TabIndex = 638;
		this.simpleButton9.Text = "Aporte x\r\nVenta";
		this.simpleButton9.Click += new System.EventHandler(simpleButton9_Click);
		this.imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
		this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
		this.imageList1.Images.SetKeyName(0, "CHECKMRK.ICO");
		this.imageList1.Images.SetKeyName(1, "MISC19.ICO");
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.SystemColors.ActiveCaption;
		base.ClientSize = new System.Drawing.Size(1270, 672);
		base.Controls.Add(this.simpleButton9);
		base.Controls.Add(this.simpleButton7);
		base.Controls.Add(this.simpleButton3);
		base.Controls.Add(this.groupControl3);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.simpleButton4);
		base.Controls.Add(this.btnAceptar);
		base.Controls.Add(this.simpleButton6);
		base.Controls.Add(this.btnCancelar);
		base.Controls.Add(this.simpleButton8);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Name = "Act_Aporte";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		base.Load += new System.EventHandler(Act_Aporte_Load);
		((System.ComponentModel.ISupportInitialize)this.groupControl3).EndInit();
		this.groupControl3.ResumeLayout(false);
		this.groupControl3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.groupControl5).EndInit();
		this.groupControl5.ResumeLayout(false);
		this.groupControl5.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.groupControl2).EndInit();
		this.groupControl2.ResumeLayout(false);
		this.groupControl2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.groupControl1).EndInit();
		this.groupControl1.ResumeLayout(false);
		this.groupControl1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.dataGridView2).EndInit();
		base.ResumeLayout(false);
	}
}
