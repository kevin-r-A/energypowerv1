using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;
using System.Data;

/// <summary>
/// Summary description for Combos
/// </summary>
public class Combos
{
	
    //Datos.SqlService objDatos = new Datos.SqlService();

    Logica.AccesoDatosBD objDatos = new Logica.AccesoDatosBD();

    
    public Combos()
	{
    }    
        
    public void F_CargarComboTblParametros(RadComboBox combo, string sp)
    {
        string msg = "";
        string sp1 = sp;

        DataTable dtcombo = new DataTable();
        dtcombo = objDatos.RetornaDT_SinParametros(sp1, ref msg);
        
        if (msg == "iok" && dtcombo.Rows.Count > 0)
        {
            combo.DataSource = dtcombo;
            foreach (DataRow dataRow in dtcombo.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();
                item.Text = (string)dataRow["par_valor"];
                item.Value = dataRow["par_id"].ToString();

                combo.Items.Add(item);
                item.DataBind();
            }

            combo.SelectedIndex = 0;

        }
    
    }

    public void F_CargarComboSP_SinParam(RadComboBox combo, string sp, int pos_cod, int pos_texto, ref string msgcombo)
    {
        string msg = "";
        string sp1 = sp;
        combo.Items.Clear(); //limpiar combo para carga de items

        DataTable dtcombo = new DataTable();
        dtcombo = objDatos.RetornaDT_SinParametros(sp1, ref msg);

        if (msg == "iok" && dtcombo.Rows.Count > 0)
        {
            combo.DataSource = dtcombo;
            foreach (DataRow dataRow in dtcombo.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();
                item.Text = (string)dataRow[pos_texto];
                item.Value = dataRow[pos_cod].ToString();

                combo.Items.Add(item);
                item.DataBind();
            }

            //combo.SelectedIndex = 0;
            msgcombo = msg;
        }
        else
        {

            msgcombo = msg;
        }
    }

    public void F_CargarComboSP_ConParam(RadComboBox combo, string sp, int pos_cod, int pos_texto, string[] lparametros, ref string msgcombo)
    {
        string msg = "";
        string sp1 = sp;
        combo.Items.Clear(); //limpiar combo para carga de items

        string[] ArrayParam = new string[lparametros.Length];

        DataTable dtcombo = new DataTable();
        ArrayParam = lparametros;
        dtcombo = objDatos.RetornaDT_ConParametros(sp1, ArrayParam, ref msg);

        if (msg == "iok" && dtcombo.Rows.Count > 0)
        {
            combo.DataSource = dtcombo;
            foreach (DataRow dataRow in dtcombo.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();
                item.Text = (string)dataRow[pos_texto];
                item.Value = dataRow[pos_cod].ToString();

                combo.Items.Add(item);
                item.DataBind();
            }

            msgcombo = msg;
            combo.SelectedIndex = 0;
        }
        else
        {
            if (dtcombo.Rows.Count == 0)
            {
                RadComboBoxItem item = new RadComboBoxItem();
                item.Text = "";
                item.Value = "0";
                combo.Items.Add(item);
            }
        }
    }

    }



	