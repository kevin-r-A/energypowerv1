using System;
using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using AjaxControlToolkit;

/// <summary>
/// Summary description for ws
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class ws : System.Web.Services.WebService {

    public ws () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetTipoBaja(string contextKey)
    {
        string sql = "select est_nombre, est_id from estado where est_grupo=" + contextKey + " order by est_orden";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue(dr["est_nombre"].ToString(), dr["est_id"].ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetCargos()
    {
        string sql = "select cgo_id, cgo_nombre from cargo order by cgo_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["cgo_nombre"], ((int)dr["cgo_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetGru1()
    {
        string sql = "select gru_id, gru_nombre from grupo where gru_nivel=1 order by gru_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["gru_nombre"], ((int)dr["gru_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetGru2(string knownCategoryValues, string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int makeId;
        if (!kv.ContainsKey("gru1") || !Int32.TryParse(kv["gru1"], out makeId))
        {
            return null;
        }

        string sql = "select gru_id, gru_nombre from grupo where gru_nivel=2 and gru_padre=" + makeId + " order by gru_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["gru_nombre"], ((int)dr["gru_id"]).ToString()));
        }
        return values.ToArray();

    }
    [WebMethod]
    public CascadingDropDownNameValue[] GetGru3(string knownCategoryValues, string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int makeId;
        if (!kv.ContainsKey("gru2") || !Int32.TryParse(kv["gru2"], out makeId))
        {
            return null;
        }

        string sql = "select gru_id, gru_nombre from grupo where gru_nivel=3 and gru_padre=" + makeId + " order by gru_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["gru_nombre"], ((int)dr["gru_id"]).ToString()));
        }
        return values.ToArray();

    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetUni()
    {
        string sql = "select uni_id, uni_simbolo from unidad order by uni_simbolo";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue(dr["uni_simbolo"].ToString(), dr["uni_id"].ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetUge1(string knownCategoryValues, string category)
    {
        string sql = "select uge_id, uge_nombre from ugeografica where uge_nivel=1 order by uge_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["uge_nombre"], ((int)dr["uge_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetUge2(string knownCategoryValues, string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int makeId;
        if (!kv.ContainsKey("uge1") || !Int32.TryParse(kv["uge1"], out makeId))
        {
            return null;
        }

        string sql = "select uge_id, uge_nombre from ugeografica where uge_nivel=2 and uge_padre=" + makeId + " order by uge_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["uge_nombre"], ((int)dr["uge_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetUge3(string knownCategoryValues, string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int makeId;
        if (!kv.ContainsKey("uge2") || !Int32.TryParse(kv["uge2"], out makeId))
        {
            return null;
        }

        string sql = "select uge_id, uge_nombre from ugeografica where uge_nivel=3 and uge_padre=" + makeId + " order by uge_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["uge_nombre"], ((int)dr["uge_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetUge4(string knownCategoryValues, string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int makeId;
        if (!kv.ContainsKey("uge3") || !Int32.TryParse(kv["uge3"], out makeId))
        {
            return null;
        }

        string sql = "select uge_id, uge_nombre from ugeografica where uge_nivel=4 and uge_padre=" + makeId + " order by uge_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["uge_nombre"], ((int)dr["uge_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetCcosto()
    {
        string sql = "select uor_id, uor_nombre from uorganica where uor_nivel=1 order by uor_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["uor_nombre"], (string)dr["uor_id"].ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetCcostoUge1(string knownCategoryValues, string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int makeId;
        if (!kv.ContainsKey("uge1") || !Int32.TryParse(kv["uge1"], out makeId))
        {
            return null;
        }

        string sql = "select uor_id, uor_nombre from uorganica where uor_nivel=1 and uge_id=" + makeId + " order by uor_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["uor_nombre"], (string)dr["uor_id"].ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetCcostoUge2(string knownCategoryValues, string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int makeId;
        if (!kv.ContainsKey("uge2") || !Int32.TryParse(kv["uge2"], out makeId))
        {
            return null;
        }

        string sql = "select uor_id, uor_nombre from uorganica where uor_nivel=1 and uge_id=" + makeId + " order by uor_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["uor_nombre"], (string)dr["uor_id"].ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetCcostoUge3(string knownCategoryValues, string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int makeId;
        if (!kv.ContainsKey("uge3") || !Int32.TryParse(kv["uge3"], out makeId))
        {
            return null;
        }

        string sql = "select uor_id, uor_nombre as uor_nombre from uorganica where uor_nivel=1 and uge_id= " + makeId + " order by uor_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["uor_nombre"], (string)dr["uor_id"].ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetUor1()
    {
        string sql = "select uor_id, uor_nombre from uorganica where uor_nivel=2 order by uor_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["uor_nombre"], ((int)dr["uor_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetUor1Cco(string knownCategoryValues, string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int makeId;
        if (!kv.ContainsKey("cco") || !Int32.TryParse(kv["cco"], out makeId))
        {
            return null;
        }

        string sql = "select uor_id, uor_nombre from uorganica where uor_nivel=2 and uor_padre=" + makeId + " order by uor_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["uor_nombre"], ((int)dr["uor_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetUor2(string knownCategoryValues, string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int makeId;
        if (!kv.ContainsKey("uor1") || !Int32.TryParse(kv["uor1"], out makeId))
        {
            return null;
        }

        string sql = "select uor_id, uor_nombre from uorganica where uor_nivel=3 and uor_padre=" + makeId + " order by uor_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["uor_nombre"], ((int)dr["uor_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetCus()
    {
        string sql = "SELECT CUSTODIO.CUS_ID, CUS_APELLIDOS+' '+CUS_NOMBRES AS NOM FROM CUSTODIO ORDER BY NOM";

        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["nom"], ((int)dr["cus_id"]).ToString()));
        }
        return values.ToArray();
    }


    [WebMethod]
    public CascadingDropDownNameValue[] GetUor2Inv()
    {
        string sql = "select  DISTINCT DENSE_RANK() OVER (ORDER BY UOR_NOMBRE) AS ID , UOR_NOMBRE from UORGANICA where UOR_NIVEL = 3";

        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["UOR_NOMBRE"], (string)dr["ID"].ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetCusUor1(string knownCategoryValues)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int makeId;
        if (!kv.ContainsKey("uor1") || !Int32.TryParse(kv["uor1"], out makeId))
        {
            return null;
        }

        string sql = "SELECT CUSTODIO.CUS_ID, CUS_APELLIDOS+' '+CUS_NOMBRES AS NOM FROM CUSTODIO, XCUOR WHERE XCUOR.CUS_ID=CUSTODIO.CUS_ID AND XCUOR.UOR_ID=" + makeId + " ORDER BY NOM";

        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["nom"], ((int)dr["cus_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetCusUor2(string knownCategoryValues)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int makeId;
        if (!kv.ContainsKey("uor2") || !Int32.TryParse(kv["uor2"], out makeId))
        {
            return null;
        }

        string sql = "SELECT CUSTODIO.CUS_ID, CUS_APELLIDOS+' '+CUS_NOMBRES AS NOM FROM CUSTODIO, XCUOR WHERE XCUOR.CUS_ID=CUSTODIO.CUS_ID AND XCUOR.UOR_ID=" + makeId + " ORDER BY NOM";

        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["nom"], ((int)dr["cus_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetEstado(string contextKey)
    {
        string sql = "select est_nombre, est_id from estado where est_grupo=" + contextKey + " order by est_orden";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue(dr["est_nombre"].ToString(), dr["est_id"].ToString()));
        }
        return values.ToArray();
    }

    //obtengo estados menos dado de baja para traslados independientes y activos nuevos
    [WebMethod]
    public CascadingDropDownNameValue[] GetEstado2(string contextKey)
    {
        string sql = "select est_nombre, est_id from estado where est_grupo=" + contextKey + " and est_nombre not like 'Dado de baja' order by est_orden";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue(dr["est_nombre"].ToString(), dr["est_id"].ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetMarca()
    {
        string sql = "select mar_id, mar_nombre from marca order by mar_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["mar_nombre"], ((int)dr["mar_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetModelo(string knownCategoryValues, string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int makeId;
        if (!kv.ContainsKey("marca") || !Int32.TryParse(kv["marca"], out makeId))
        {
            return null;
        }

        string sql = "select mod_id, mod_nombre from modelo where mar_id=" + makeId + " order by mod_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["mod_nombre"], ((int)dr["mod_id"]).ToString()));
        }
        return values.ToArray();

    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetEstruc1()
    {
        string sql = "select eco_id, eco_nombre from estrucomp order by eco_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["eco_nombre"], ((int)dr["eco_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetEstruc2(string knownCategoryValues, string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int makeId;
        if (!kv.ContainsKey("eco1") || !Int32.TryParse(kv["eco1"], out makeId))
        {
            return null;
        }

        string sql = "select eco_id, eco_nombre from estrucomp where eco_id<>" + makeId + " order by eco_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["eco_nombre"], ((int)dr["eco_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetColor()
    {
        string sql = "select col_id, col_nombre from color order by col_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue(dr["col_nombre"].ToString(), ((int)dr["col_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetPro()
    {
        string sql = "select pro_id, pro_nombre from proveedor order by pro_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["pro_nombre"], ((int)dr["pro_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetTipoSeg()
    {
        string sql = "select SEG_ID, SEG_NOMBRE from TIPO_SEGURO order by SEG_NOMBRE";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["SEG_NOMBRE"], ((int)dr["SEG_ID"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetTipoSeguro()
    {
        string sql = "select tse_id, tse_nombre from tiposeguro order by tse_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["tse_nombre"], ((int)dr["tse_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetAseguradora()
    {
        string sql = "select ase_id, ase_nombre from aseguradora order by ase_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["ase_nombre"], ((int)dr["ase_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public AjaxControlToolkit.Slide[] getSlides(string contextKey)
    {
        string sql = "select act_foto1, act_foto2 from activo where act_id=" + contextKey;
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        AjaxControlToolkit.Slide[] imgSlide = new AjaxControlToolkit.Slide[2];

        if (dt.Rows.Count > 0)
        {
            
            imgSlide[0] = new AjaxControlToolkit.Slide("imgact/" + dt.Rows[0]["act_foto1"], "", "");
            if (dt.Rows[0]["act_foto1"].ToString() != "nofoto.gif" && dt.Rows[0]["act_foto2"].ToString() == "nofoto.gif")
                imgSlide[1] = new AjaxControlToolkit.Slide("imgact/" + dt.Rows[0]["act_foto1"], "", "");
            else
            imgSlide[1] = new AjaxControlToolkit.Slide("imgact/" + dt.Rows[0]["act_foto2"], "", "");
        }
        else
        {
            imgSlide[0] = new AjaxControlToolkit.Slide("imgact/nofoto.gif", "", "");
            imgSlide[1] = new AjaxControlToolkit.Slide("imgact/nofoto.gif", "", "");
        }
        return (imgSlide);
    }

    [WebMethod]
    public AjaxControlToolkit.Slide[] getSlides2(string contextKey)
    {
        string sql = "select act_foto1, act_foto2 from activo where act_id=" + contextKey;
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        AjaxControlToolkit.Slide[] imgSlide = new AjaxControlToolkit.Slide[2];

        if (dt.Rows.Count > 0)
        {

            imgSlide[0] = new AjaxControlToolkit.Slide("/CaymanActivoWeb/Site/Activos/imgact/" + dt.Rows[0]["act_foto1"], "", "");
            if (dt.Rows[0]["act_foto1"].ToString() != "nofoto.gif" && dt.Rows[0]["act_foto2"].ToString() == "nofoto.gif")
                imgSlide[1] = new AjaxControlToolkit.Slide("/CaymanActivoWeb/Site/Activos/imgact/" + dt.Rows[0]["act_foto1"], "", "");
            else
                imgSlide[1] = new AjaxControlToolkit.Slide("/CaymanActivoWeb/Site/Activos/imgact/" + dt.Rows[0]["act_foto2"], "", "");
        }
        else
        {
            imgSlide[0] = new AjaxControlToolkit.Slide("/CaymanActivoWeb/Site/Activos/imgact/nofoto.gif", "", "");
            imgSlide[1] = new AjaxControlToolkit.Slide("/CaymanActivoWeb/Site/Activos/imgact/nofoto.gif", "", "");
        }
        return (imgSlide);
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetPpc()
    {
        string sql = "select convert(varchar(50),ppc_numero)+' > [ '+isnull(ppc_serial,'')+' ]' as pocket, ppc_numero from ppc order by ppc_numero";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["pocket"], ((int)dr["ppc_numero"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetPai1()
    {
        string sql = "select pai_id, pai_nombre from pais where pai_nivel=1 order by pai_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["pai_nombre"], ((int)dr["pai_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetPai2(string knownCategoryValues, string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int makeId;
        if (!kv.ContainsKey("pai1") || !Int32.TryParse(kv["pai1"], out makeId))
        {
            return null;
        }

        string sql = "select pai_id, pai_nombre from pais where pai_nivel=2 and pai_padre=" + makeId + " order by pai_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["pai_nombre"], ((int)dr["pai_id"]).ToString()));
        }
        return values.ToArray();

    }
    [WebMethod]
    public CascadingDropDownNameValue[] GetPai3(string knownCategoryValues, string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int makeId;
        if (!kv.ContainsKey("pai2") || !Int32.TryParse(kv["pai2"], out makeId))
        {
            return null;
        }

        string sql = "select pai_id, pai_nombre from pais where pai_nivel=3 and pai_padre=" + makeId + " order by pai_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["pai_nombre"], ((int)dr["pai_id"]).ToString()));
        }
        return values.ToArray();

    }
    
    [WebMethod]
    public CascadingDropDownNameValue[] GetEmpresas()
    {
        string sql = "select emp_id, emp_nombre from empresa";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["emp_nombre"], ((string)dr["emp_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetAnio()
    {
        string sql = "select ani_id from anio order by ani_id";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["ani_id"].ToString(), dr["ani_id"].ToString()));
        }
        return values.ToArray();
    }

    //2012-02-29 Andrea Para reporte total de activos custodio
    [WebMethod]
    public CascadingDropDownNameValue[] GetCustodio()
    {
        string sql = "SELECT cus_id1, CUSTODIO=stuff((select cus_apellidos +' '+cus_nombres from CUSTODIO where cus_id=Activo.cus_id1 for xml path('')) ,1,0,''),  ('[ '+convert(varchar(5), COUNT(*) , 103)+' ]') as Total from Activo where act_fechabaja is null group by cus_id1 order by CUSTODIO";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {

            values.Add(new CascadingDropDownNameValue((string)dr["Custodio"].ToString() + ' ' + dr["Total"].ToString(), dr["cus_id1"].ToString()));
        }
        return values.ToArray();
    }

    [WebMethod] //ACTIVO FIJO O BIEN DE CONTROL
    public CascadingDropDownNameValue[] GetTipoItem()
    {
        string sql = "SELECT PAR_VALOR FROM PARAMETROS WHERE PAR_NOMBRE='TIPOACTIVO' ORDER BY PAR_VALOR";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {

            values.Add(new CascadingDropDownNameValue((string)dr["PAR_VALOR"].ToString(), dr["PAR_VALOR"].ToString()));
        }
        return values.ToArray();
    }

    [WebMethod] //COMPRA - DONACION
    public CascadingDropDownNameValue[] GetTipoIng()
    {
        string sql = "SELECT PAR_VALOR FROM PARAMETROS WHERE PAR_NOMBRE='TIPOINGRESO' ORDER BY PAR_VALOR";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {

            values.Add(new CascadingDropDownNameValue((string)dr["PAR_VALOR"].ToString(), dr["PAR_VALOR"].ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetCiudadTATA(string knownCategoryValues, string category)
    {
        string sql = "select uge_id, uge_nombre from ugeografica where uge_nivel=2 order by uge_nombre";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue((string)dr["uge_nombre"], ((int)dr["uge_id"]).ToString()));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetUsuarios()
    {
        string sql = "select UserId, UserName FROM aspnet_Users order by UserName";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["base"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in dt.Rows)
        {
            values.Add(new CascadingDropDownNameValue(dr["UserName"].ToString(), dr["UserId"].ToString()));
        }
        return values.ToArray();
    }
}
