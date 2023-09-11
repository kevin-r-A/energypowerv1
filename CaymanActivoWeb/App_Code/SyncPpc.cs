using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using Datos;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[Serializable()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Diagnostics.DebuggerStepThrough()]
[System.ComponentModel.ToolboxItem(true)]

public class SyncPpc : System.Web.Services.WebService
{
    string constr = ConfigurationManager.ConnectionStrings["base"].ToString();

    public SyncPpc()
    {

        //InitializeComponent(); 
    }

    //***Enviar Items Pc => PocketPC
    [WebMethod]
    public DataSet Tipos(string select)
    {
        //Generar Resumen
        Datos.SqlService sql = new SqlService();
        sql.ExecuteSql("update ACTIVO set act_resumen=null; "
        + "update activo set act_resumen='['+grupo.GRU_NOMBRE+']' from GRUPO where grupo.GRU_ID=activo.GRU_ID3; "
        + "update activo set act_resumen=act_resumen+' - Marca: '+mar_nombre from MARCA where MARCA.MAR_ID=activo.MAR_ID; "
        + "update activo set act_resumen=act_resumen+' - Modelo: '+mod_nombre from MODELO where MODELO.Mod_ID=activo.Mod_ID; "
        + "update activo set act_resumen=act_resumen + ISNULL(' - Serie: '+ act_serie1,''); "
        + "update activo set act_resumen=act_resumen + ISNULL(' - Color: '+ COL_NOMBRE,'') from COLOR where COLOR.COL_ID=activo.COL_ID;");

        SqlConnection cnn;
        SqlDataAdapter da;
        SqlCommand sqlSelectCommand;

        System.ServiceModel.BasicHttpBinding binding = new System.ServiceModel.BasicHttpBinding();
        // if you are getting a LOT of data back, you will need to up Message Size
        binding.MaxReceivedMessageSize = int.MaxValue;

        cnn = new SqlConnection();
        da = new SqlDataAdapter();
        cnn.ConnectionString = constr;
        sqlSelectCommand = new SqlCommand();
        sqlSelectCommand.CommandText = select;

        DataSet ds = new DataSet();
        try
        {
            sqlSelectCommand.Connection = cnn;
            da.SelectCommand = sqlSelectCommand;
            da.Fill(ds);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    //consulta on line
    [WebMethod]
    public DataSet TiposLine(string select)
    {
        //Generar Resumen
        Datos.SqlService sql = new SqlService();
        sql.ExecuteSql("update ACTIVO set act_resumen=null; "
        + "update activo set act_resumen='['+grupo.GRU_NOMBRE+']' from GRUPO where grupo.GRU_ID=activo.GRU_ID3; "
        + "update activo set act_resumen=act_resumen+' - Marca: '+mar_nombre from MARCA where MARCA.MAR_ID=activo.MAR_ID; "
        + "update activo set act_resumen=act_resumen+' - Modelo: '+mod_nombre from MODELO where MODELO.Mod_ID=activo.Mod_ID; "
        + "update activo set act_resumen=act_resumen + ISNULL(' - Serie: '+ act_serie1,''); "
        + "update activo set act_resumen=act_resumen + ISNULL(' - Color: '+ COL_NOMBRE,'') from COLOR where COLOR.COL_ID=activo.COL_ID;");

        SqlConnection cnn;
        SqlDataAdapter da;
        SqlCommand sqlSelectCommand;

        System.ServiceModel.BasicHttpBinding binding = new System.ServiceModel.BasicHttpBinding();
        // if you are getting a LOT of data back, you will need to up Message Size
        binding.MaxReceivedMessageSize = int.MaxValue;

        cnn = new SqlConnection();
        da = new SqlDataAdapter();
        cnn.ConnectionString = constr;
        sqlSelectCommand = new SqlCommand();
        sqlSelectCommand.CommandText = select;

        DataSet ds = new DataSet();
        try
        {
            sqlSelectCommand.Connection = cnn;
            da.SelectCommand = sqlSelectCommand;
            da.Fill(ds);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public void TiposLine2(string query, string key)
    {
        if (key == "1010")
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSqlObject(query);
        }
    }

    [WebMethod]
    public void TimeTrashStrReporteDelete()
    {
        SqlConnection cnn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        cnn.ConnectionString = constr;
        SqlCommand sqlSelectCommand = new SqlCommand();
        sqlSelectCommand.Connection = cnn;

        cnn.Open();

        string sqldel = "DELETE FROM REPORTE";
        sqlSelectCommand.CommandText = sqldel;
        sqlSelectCommand.ExecuteNonQuery();
        cnn.Close();
    }


    [WebMethod]
    public void TimeTrashStrReporteReset()
    {

        SqlConnection cnn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        cnn.ConnectionString = constr;
        SqlCommand sqlSelectCommand = new SqlCommand();
        sqlSelectCommand.Connection = cnn;

        cnn.Open();
        string sqliden = "DBCC CHECKIDENT ('REPORTE', RESEED,0)";
        sqlSelectCommand.CommandText = sqliden;
        sqlSelectCommand.ExecuteNonQuery();
        cnn.Close();

    }


    [WebMethod]
    public int TimeTrashStrReporte(string reporte)
    {
        int resultado = 0;
        SqlConnection cnn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        cnn.ConnectionString = constr;
        SqlCommand sqlSelectCommand = new SqlCommand();
        sqlSelectCommand.Connection = cnn;

        try
        {
            System.ServiceModel.BasicHttpBinding binding = new System.ServiceModel.BasicHttpBinding();
            // if you are getting a LOT of data back, you will need to up Message Size
            binding.MaxReceivedMessageSize = int.MaxValue;

            string[] repvrray = reporte.Split('|');

            cnn.Open();

            if (repvrray.Length > 0 )
            {
                string sql = "insert into REPORTE (rep_codbarras, cus_id, rep_fecha, rep_estado, act_id) values ('" + repvrray[1] + "','" + repvrray[2] + "','" + repvrray[3] + "','" + repvrray[4] + "','" + repvrray[5] + "')";
                sqlSelectCommand.CommandText = sql;
                sqlSelectCommand.ExecuteNonQuery();
                resultado = 1;
            }
        }
        catch(Exception ex)
        {
            resultado = 0;
            throw ex;
        }
        finally
        {
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
        }

        return resultado;
    }

    //***Recibir Items PocketPC => Pc
    [WebMethod]
    public string TimeTrashStr3(string activo)
    {
        //int[] resultado = new int[3];
        string resultado = "";
        SqlConnection cnn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        cnn.ConnectionString = constr;
        SqlCommand sqlSelectCommand = new SqlCommand();
        sqlSelectCommand.Connection = cnn;

        try
        {

            System.ServiceModel.BasicHttpBinding binding = new System.ServiceModel.BasicHttpBinding();
            // if you are getting a LOT of data back, you will need to up Message Size
            binding.MaxReceivedMessageSize = int.MaxValue;

            //**variables para id's de catalogos
            int ec1 = 0;
            int ec2 = 0;
            int g1 = 0;
            int g2 = 0;
            int g3 = 0;
            int ug1 = 0;
            int ug2 = 0;
            int ug3 = 0;
            int ug4 = 0;
            int uo1 = 0;
            int uo2 = 0;
            int uo3 = 0;
            int cu = 0;
            int mar = 0;
            int mod = 0;
            int co = 0;


            string[] activrray = activo.Split('|');

            if (activrray[10] == "1") //ec1x //si es nuevo
                ec1 = buscarCrearCatalogo(activrray[9], "ESTRUCOMP", "ECO_ID", "ECO_NOMBRE");
            else if (activrray[10] == "0")
                ec1 = int.Parse(activrray[8]);
            else if (activrray[10] == "")
                ec1 = -1;

            if (activrray[13] == "1")
                ec2 = buscarCrearCatalogo(activrray[12], "ESTRUCOMP", "ECO_ID", "ECO_NOMBRE");
            else if (activrray[13] == "0")
                ec2 = int.Parse(activrray[11]);
            else if (activrray[13] == "")
                ec2 = -1;

            if (activrray[24] == "1")
                g1 = buscarCrearCatalogoNiv("GRU_ID", "GRUPO", "GRU_NOMBRE", "GRU_PADRE", "GRU_NIVEL", activrray[23], 0, 1);
            else
                g1 = int.Parse(activrray[22]);

            if (activrray[27] == "1")
                g2 = buscarCrearCatalogoNiv("GRU_ID", "GRUPO", "GRU_NOMBRE", "GRU_PADRE", "GRU_NIVEL", activrray[26], g1, 2);
            else
                g2 = int.Parse(activrray[25]);

            if (activrray[30] == "1")
                g3 = buscarCrearCatalogoNiv("GRU_ID", "GRUPO", "GRU_NOMBRE", "GRU_PADRE", "GRU_NIVEL", activrray[29], g2, 3);
            else
                g3 = int.Parse(activrray[28]);

            if (activrray[33] == "1")
                ug1 = buscarCrearCatalogoNiv("UGE_ID", "UGEOGRAFICA", "UGE_NOMBRE", "UGE_PADRE", "UGE_NIVEL", activrray[32], 0, 1);
            else
                ug1 = int.Parse(activrray[31]);

            if (activrray[36] == "1")
                ug2 = buscarCrearCatalogoNiv("UGE_ID", "UGEOGRAFICA", "UGE_NOMBRE", "UGE_PADRE", "UGE_NIVEL", activrray[35], ug1, 2);
            else
                ug2 = int.Parse(activrray[34]);

            if (activrray[39] == "1")
                ug3 = buscarCrearCatalogoNiv("UGE_ID", "UGEOGRAFICA", "UGE_NOMBRE", "UGE_PADRE", "UGE_NIVEL", activrray[38], ug2, 3);
            else
                ug3 = int.Parse(activrray[37]);

            if (activrray[42] == "1")
                ug4 = buscarCrearCatalogoNiv("UGE_ID", "UGEOGRAFICA", "UGE_NOMBRE", "UGE_PADRE", "UGE_NIVEL", activrray[41], ug3, 4);
            else
                ug4 = int.Parse(activrray[40]);

            if (activrray[45] == "1") //UGE3 => UOR1
                uo1 = buscarCrearCatalogoNiv2("UOR_ID", "UORGANICA", "UOR_NOMBRE", "UOR_PADRE", "UGE_ID", "UOR_NIVEL", activrray[44], 0, ug3, 1);
            else
                uo1 = int.Parse(activrray[43]);

            if (activrray[48] == "1")
                uo2 = buscarCrearCatalogoNiv("UOR_ID", "UORGANICA", "UOR_NOMBRE", "UOR_PADRE", "UOR_NIVEL", activrray[47], uo1, 2);
            else
                uo2 = int.Parse(activrray[46]);

            if (activrray[51] == "1")
                uo3 = buscarCrearCatalogoNiv("UOR_ID", "UORGANICA", "UOR_NOMBRE", "UOR_PADRE", "UOR_NIVEL", activrray[50], uo2, 3);
            else
                uo3 = int.Parse(activrray[49]);

            if (activrray[55] == "1")//UOR2 => CUSID
                cu = buscarCrearCustodio(activrray[54], activrray[53], uo2);
            else
                cu = int.Parse(activrray[52]);

            if (activrray[58] == "1")
                mar = buscarCrearCatalogo(activrray[57], "MARCA", "MAR_ID", "MAR_NOMBRE");
            else
                mar = int.Parse(activrray[56]);

            if (activrray[61] == "1") //MARCA => MODELO
                mod = buscarCrearCatalogoModelo("MOD_ID", "MODELO", "MOD_NOMBRE", "MAR_ID", "1", activrray[60], mar, 1);
            else
                mod = int.Parse(activrray[59]);

            if (activrray[64] == "1")
                co = buscarCrearCatalogo(activrray[63], "COLOR", "COL_ID", "COL_NOMBRE");
            else if (activrray[64] == "0")
                co = int.Parse(activrray[62]);
            else if (activrray[64] == "")
                co = -1;


            string _ec1 = "";
            string _ec2 = "";
            string _co = "";

            if (ec1 == -1)
                _ec1 = "null";
            else
                _ec1 = ec1.ToString();

            if (ec2 == -1)
                _ec2 = "null";
            else
                _ec2 = ec2.ToString();

            if (co == -1)
                _co = "null";
            else
                _co = co.ToString();


            cnn.Open();

            if (activrray[66] == "M")
            {
                //update

                string sql = "UPDATE ACTIVO SET "
                + "ACT_CODBARRASPADRE='" + activrray[2] + "',"
                + "ACT_FECHAINVENTARIO='" + activrray[4] + "',"
                + "ACT_CODIGO1='" + activrray[5] + "',"
                + "ACT_ANIO=" + activrray[6] + ","
                + "ACT_SERIE1='" + activrray[7] + "',"
                + "ECO_ID1=" + _ec1 + ","
                + "ECO_ID2=" + _ec2 + ","
                + "ACT_OBSERVACIONES='" + activrray[14] + "',"
                + "USERNAME='" + activrray[15] + " - PPC',"
                + "ACT_FOTO1='" + activrray[16] + "',"
                + "ACT_FOTO2='" + activrray[17] + "',"
                + "EST_ID1=" + activrray[18] + ","
                + "EST_ID2=" + activrray[20] + ","
                + "EST_ID3=" + activrray[67] + ","
                + "GRU_ID1=" + g1 + ","
                + "GRU_ID2=" + g2 + ","
                + "GRU_ID3=" + g3 + ","
                + "UGE_ID1=" + ug1 + ","
                + "UGE_ID2=" + ug2 + ","
                + "UGE_ID3=" + ug3 + ","
                + "UGE_ID4=" + ug4 + ","
                + "UOR_ID1=" + uo1 + ","
                + "UOR_ID2=" + uo2 + ","
                + "UOR_ID3=" + uo3 + ","
                + "CUS_ID1=" + cu + ","
                + "MAR_ID=" + mar + ","
                + "MOD_ID=" + mod + ","
                + "COL_ID=" + _co
                + " WHERE ACT_ID=" + activrray[0];

                sql = sql.Replace(",,,", ",NULL,NULL,");
                sql = sql.Replace(",,", ",NULL,");
                sql = sql.Replace(",,", ",NULL,");
                sql = sql.Replace("''", "NULL");
                sql = sql.Replace("''", "NULL");

                sqlSelectCommand.CommandText = sql;
                sqlSelectCommand.ExecuteNonQuery();

                //2012-05-15-Andrea.- Cambio de id a nombres para insert de hucustodio

                Datos.SqlService sql_huc = new Datos.SqlService();
                int uge1 = sql_huc.ExecuteSqlInt("select uge_id from ugeografica where uge_id=" + ug1);
                int uge2 = sql_huc.ExecuteSqlInt("select uge_id from ugeografica where uge_id=" + ug2);
                int uge3 = sql_huc.ExecuteSqlInt("select uge_id from ugeografica where uge_id=" + ug3);
                int uge4 =  sql_huc.ExecuteSqlInt("select uge_id from ugeografica where uge_id=" + ug4);
                int uor1 = sql_huc.ExecuteSqlInt("select uor_id from uorganica where uor_id=" + uo1);
                int uor2 = sql_huc.ExecuteSqlInt("select uor_id from uorganica where uor_id=" + uo2);
                int uor3 = sql_huc.ExecuteSqlInt("select uor_id from uorganica where uor_id=" + uo3);
                int cus1 = sql_huc.ExecuteSqlInt("select cus_id from custodio where cus_id=" + cu);
                int est1 = sql_huc.ExecuteSqlInt("select est_id from estado where est_id=" + activrray[18]);
                int est2 = sql_huc.ExecuteSqlInt("select est_id from estado where est_id=" + activrray[20]);
                int est3 = sql_huc.ExecuteSqlInt("select est_id from estado where est_id=" + activrray[67]);

                //insertamos hucustodio
                Datos.SqlService sql2 = new SqlService();
                sql2.ExecuteSql("INSERT INTO HUCUSTODIO (ACT_ID, USERNAME, HUC_FECHA, UGE_ID1, UGE_ID2,"
                + " UGE_ID3,UGE_ID4, UOR_ID1, UOR_ID2, UOR_ID3, CUS_ID1, CUS_ID2,"
                + " EST_ID1, EST_ID2, EST_ID3) VALUES ("
                + "" + activrray[0] + ","
                + "'" + activrray[15] + " - PPC',"
                + "'" + activrray[4] + "',"
                + "'" + uge1 + "',"
                + "'" + uge2 + "',"
                + "'" + uge3 + "',"
                + "'" + uge4 + "',"
                + "'" + uor1 + "',"
                + "'" + uor2 + "',"
                + "'" + uor3 + "',"
                + "'" + cus1 + "',"
                + "NULL,"
                + "'" + est1 + "',"
                + "'" + est2 + "',"
                + "'" + est3 + "')");

                //insertamos mactivo
                sql2.ExecuteSql("INSERT INTO MACTIVO (ACT_ID, USERNAME, MAC_ACCION) "
                + " VALUES (" + activrray[0] + ", '" + activrray[15] + " - PPC','M')");

                //insertamos hfoto
                if (activrray[16] != "nofoto.gif" || activrray[17] != "nofoto.gif")
                {
                    sql2.ExecuteSql("INSERT INTO HFOTO (ACT_ID, HFO_FOTO1, HFO_FOTO2, USERNAME, CUS_ID1, CUS_ID2) "
                    + "VALUES  (" + activrray[0] + ",'" + activrray[16] + "','" + activrray[17] + "','" + activrray[15] + " - PPC'," + cus1 + ",NULL)");
                }

               // resultado[0] = 1;
            }
            else
            {
                if (activrray[66] == "N")
                {

                    //INSERT
                    int actid = Logica.HELPER.getNextActid(activrray[15] + " - PPC");

                    string empid = Logica.HELPER.getEmpresa();
                    string sql1 = "INSERT INTO ACTIVO (ACT_ID ,EMP_ID ,ACT_FECHACREACION, USERNAME  ,ACT_CODBARRAS"
                    + ",ACT_CODBARRASPADRE ,ACT_CODIGO1 ,GRU_ID1 ,GRU_ID2 ,GRU_ID3 ,ACT_FOTO1 ,ACT_FOTO2 ,UGE_ID1"
                    + ",UGE_ID2 ,UGE_ID3 ,UGE_ID4 ,UOR_ID1 ,UOR_ID2 ,UOR_ID3 ,CUS_ID1 ,EST_ID1 ,EST_ID2, EST_ID3"
                    + ",MAR_ID ,MOD_ID ,ACT_SERIE1 ,COL_ID ,ECO_ID1 ,ECO_ID2 ,ACT_ANIO ,ACT_OBSERVACIONES"
                    + ",ACT_TRANSFEROK ,ACT_FECHAINVENTARIO, ACT_RETIQUETAR, ACT_FECHACOMPRA) "
                    + "VALUES ("
                    + "" + actid + ","
                    + "'" + empid + "',"
                    + "'" + activrray[3] + "',"
                    + "'" + activrray[15] + " - PPC',"
                    + "'" + activrray[1] + "',"
                    + "'" + activrray[2] + "',"
                    + "'" + activrray[5] + "',"
                    + "" + g1 + ","
                    + "" + g2 + ","
                    + "" + g3 + ","
                    + "'" + activrray[16] + "',"
                    + "'" + activrray[17] + "',"
                    + "" + ug1 + ","
                    + "" + ug2 + ","
                    + "" + ug3 + ","
                    + "" + ug4 + ","
                    + "" + uo1 + ","
                    + "" + uo2 + ","
                    + "" + uo3 + ","
                    + "" + cu + ","
                    + "" + activrray[18] + ","
                    + "" + activrray[20] + ","
                    + "" + activrray[67] + ","
                    + "" + mar + ","
                    + "" + mod + ","
                    + "'" + activrray[7] + "',"
                    + "" + _co + ","
                    + "" + _ec1 + ","
                    + "" + _ec2 + ","
                    + "" + activrray[6] + ","
                    + "'" + activrray[14] + "',"
                    + "" + 1 + ","
                    + "'" + activrray[4] + "',"
                    + "" + activrray[65] + ","
                    + "'" + activrray[4] + "')";

                    sql1 = sql1.Replace(",,,", ",NULL,NULL,");
                    sql1 = sql1.Replace(",,", ",NULL,");
                    sql1 = sql1.Replace(",,", ",NULL,");
                    sql1 = sql1.Replace("''", "NULL");
                    sql1 = sql1.Replace("''", "NULL");

                    sqlSelectCommand.CommandText = sql1;
                    sqlSelectCommand.ExecuteNonQuery();

                    //2012-05-15-Andrea.- Cambio de id a nombres para insert de hucustodio

                    Datos.SqlService sql_huc = new Datos.SqlService();
                    string uge1 = sql_huc.ExecuteSqlString("select uge_nombre from ugeografica where uge_id=" + ug1);
                    string uge2 = sql_huc.ExecuteSqlString("select uge_nombre from ugeografica where uge_id=" + ug2);
                    string uge3 = sql_huc.ExecuteSqlString("select uge_nombre from ugeografica where uge_id=" + ug3);
                    string uge4 = "Piso " + sql_huc.ExecuteSqlString("select uge_nombre from ugeografica where uge_id=" + ug4);
                    string uor1 = sql_huc.ExecuteSqlString("select uor_nombre from uorganica where uor_id=" + uo1);
                    string uor2 = sql_huc.ExecuteSqlString("select uor_nombre from uorganica where uor_id=" + uo2);
                    string uor3 = sql_huc.ExecuteSqlString("select uor_nombre from uorganica where uor_id=" + uo3);
                    string cus1 = sql_huc.ExecuteSqlString("select (cus_apellidos +' '+cus_nombres) from custodio where cus_id=" + cu);
                    string est1 = sql_huc.ExecuteSqlString("select est_nombre from estado where est_id=" + activrray[18]);
                    string est2 = sql_huc.ExecuteSqlString("select est_nombre from estado where est_id=" + activrray[20]);
                    string est3 = sql_huc.ExecuteSqlString("select est_nombre from estado where est_id=" + activrray[67]);

                    //insertamos hucustodio
                    Datos.SqlService sql2 = new SqlService();
                    sql2.ExecuteSql("INSERT INTO HUCUSTODIO (ACT_ID, USERNAME, UGE_ID1, UGE_ID2,"
                    + " UGE_ID3,UGE_ID4, UOR_ID1, UOR_ID2, UOR_ID3, CUS_ID1, CUS_ID2,"
                    + " EST_ID1, EST_ID2, EST_ID3) VALUES ("
                    + "" + actid + ","
                    + "'" + activrray[15] + " - PPC',"
                    + "" + uge1 + ","
                    + "" + uge2 + ","
                    + "" + uge3 + ","
                    + "" + uge4 + ","
                    + "" + uor1 + ","
                    + "" + uor2 + ","
                    + "" + uor3 + ","
                    + "" + cus1 + ","
                    + "NULL,"
                    + "" + est1 + ","
                    + "" + est2 + ","
                    + "" + est3 + ")"); //ID DEL ESTADO 3

                    //insertamos mactivo
                    sql2.ExecuteSql("INSERT INTO MACTIVO (ACT_ID, USERNAME, MAC_ACCION) "
                    + " VALUES (" + actid + ", '" + activrray[15] + " - PPC','I')");

                    //insertamos hfoto
                    if (activrray[16] != "nofoto.gif" || activrray[17] != "nofoto.gif")
                    {
                        sql2.ExecuteSql("INSERT INTO HFOTO (ACT_ID, HFO_FOTO1, HFO_FOTO2, USERNAME, CUS_ID1, CUS_ID2) "
                        + "VALUES  (" + actid + ",'" + activrray[16] + "','" + activrray[17] + "','" + activrray[15] + " - PPC'," + cus1 + ",NULL)");
                    }

                    //devolvemos el nuevo id
                   // resultado[0] = 1;
                    //resultado[1] = actid;
                }
            }
        }
        catch (Exception ex)
        {

            resultado = ex.Message;
            //resultado[0] = 0;
            //throw ex;
        }
        finally
        {
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
        }
        return resultado;
    }

    //***Recibir Items PocketPC => Pc
    [WebMethod]
    public int[] TimeTrashStr(string activo)
    {
        int[] resultado = new int[3];
        SqlConnection cnn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        cnn.ConnectionString = constr;
        SqlCommand sqlSelectCommand = new SqlCommand();
        sqlSelectCommand.Connection = cnn;

        try
        {

            System.ServiceModel.BasicHttpBinding binding = new System.ServiceModel.BasicHttpBinding();
            // if you are getting a LOT of data back, you will need to up Message Size
            binding.MaxReceivedMessageSize = int.MaxValue;

            //**variables para id's de catalogos
            int ec1 = 0;
            int ec2 = 0;
            int g1 = 0;
            int g2 = 0;
            int g3 = 0;
            int ug1 = 0;
            int ug2 = 0;
            int ug3 = 0;
            int ug4 = 0;
            int uo1 = 0;
            int uo2 = 0;
            int uo3 = 0;
            int cu = 0;
            int mar = 0;
            int mod = 0;
            int co = 0;


            string[] activrray = activo.Split('|');

            if (activrray[10] == "1") //ec1x //si es nuevo
                ec1 = buscarCrearCatalogo(activrray[9], "ESTRUCOMP", "ECO_ID", "ECO_NOMBRE");
            else if (activrray[10] == "0")
                ec1 = int.Parse(activrray[8]);
            else if (activrray[10] == "")
                ec1 = -1;

            if (activrray[13] == "1")
                ec2 = buscarCrearCatalogo(activrray[12], "ESTRUCOMP", "ECO_ID", "ECO_NOMBRE");
            else if (activrray[13] == "0")
                ec2 = int.Parse(activrray[11]);
            else if (activrray[13] == "")
                ec2 = -1;

            if (activrray[24] == "1")
                g1 = buscarCrearCatalogoNiv("GRU_ID", "GRUPO", "GRU_NOMBRE", "GRU_PADRE", "GRU_NIVEL", activrray[23], 0, 1);
            else
                g1 = int.Parse(activrray[22]);

            if (activrray[27] == "1")
                g2 = buscarCrearCatalogoNiv("GRU_ID", "GRUPO", "GRU_NOMBRE", "GRU_PADRE", "GRU_NIVEL", activrray[26], g1, 2);
            else
                g2 = int.Parse(activrray[25]);

            if (activrray[30] == "1")
                g3 = buscarCrearCatalogoNiv("GRU_ID", "GRUPO", "GRU_NOMBRE", "GRU_PADRE", "GRU_NIVEL", activrray[29], g2, 3);
            else
                g3 = int.Parse(activrray[28]);

            if (activrray[33] == "1")
                ug1 = buscarCrearCatalogoNiv("UGE_ID", "UGEOGRAFICA", "UGE_NOMBRE", "UGE_PADRE", "UGE_NIVEL", activrray[32], 0, 1);
            else
                ug1 = int.Parse(activrray[31]);

            if (activrray[36] == "1")
                ug2 = buscarCrearCatalogoNiv("UGE_ID", "UGEOGRAFICA", "UGE_NOMBRE", "UGE_PADRE", "UGE_NIVEL", activrray[35], ug1, 2);
            else
                ug2 = int.Parse(activrray[34]);

            if (activrray[39] == "1")
                ug3 = buscarCrearCatalogoNiv("UGE_ID", "UGEOGRAFICA", "UGE_NOMBRE", "UGE_PADRE", "UGE_NIVEL", activrray[38], ug2, 3);
            else
                ug3 = int.Parse(activrray[37]);

            if (activrray[42] == "1")
                ug4 = buscarCrearCatalogoNiv("UGE_ID", "UGEOGRAFICA", "UGE_NOMBRE", "UGE_PADRE", "UGE_NIVEL", activrray[41], ug3, 4);
            else
                ug4 = int.Parse(activrray[40]);

            if (activrray[45] == "1") //UGE3 => UOR1
                uo1 = buscarCrearCatalogoNiv2("UOR_ID", "UORGANICA", "UOR_NOMBRE", "UOR_PADRE", "UGE_ID", "UOR_NIVEL", activrray[44], 0, ug3, 1);
            else
                uo1 = int.Parse(activrray[43]);

            if (activrray[48] == "1")
                uo2 = buscarCrearCatalogoNiv("UOR_ID", "UORGANICA", "UOR_NOMBRE", "UOR_PADRE", "UOR_NIVEL", activrray[47], uo1, 2);
            else
                uo2 = int.Parse(activrray[46]);

            if (activrray[51] == "1")
                uo3 = buscarCrearCatalogoNiv("UOR_ID", "UORGANICA", "UOR_NOMBRE", "UOR_PADRE", "UOR_NIVEL", activrray[50], uo2, 3);
            else
                uo3 = int.Parse(activrray[49]);

            if (activrray[55] == "1")//UOR2 => CUSID
                cu = buscarCrearCustodio(activrray[54], activrray[53], uo2);
            else
                cu = int.Parse(activrray[52]);

            if (activrray[58] == "1")
                mar = buscarCrearCatalogo(activrray[57], "MARCA", "MAR_ID", "MAR_NOMBRE");
            else
                mar = int.Parse(activrray[56]);

            if (activrray[61] == "1") //MARCA => MODELO
                mod = buscarCrearCatalogoModelo("MOD_ID", "MODELO", "MOD_NOMBRE", "MAR_ID", "1", activrray[60], mar, 1);
            else
                mod = int.Parse(activrray[59]);

            if (activrray[64] == "1")
                co = buscarCrearCatalogo(activrray[63], "COLOR", "COL_ID", "COL_NOMBRE");
            else if (activrray[64] == "0")
                co = int.Parse(activrray[62]);
            else if (activrray[64] == "")
                co = -1;


            string _ec1 = "";
            string _ec2 = "";
            string _co = "";

            if (ec1 == -1)
                _ec1 = "null";
            else
                _ec1 = ec1.ToString();

            if (ec2 == -1)
                _ec2 = "null";
            else
                _ec2 = ec2.ToString();

            if (co == -1)
                _co = "null";
            else
                _co = co.ToString();


            cnn.Open();

            if (activrray[66] == "M")
            {
                //update

                string sql = "UPDATE ACTIVO SET "
                + "ACT_CODBARRASPADRE='" + activrray[2] + "',"
                + "ACT_FECHAINVENTARIO='" + activrray[4] + "',"
                + "ACT_CODIGO1='" + activrray[5] + "',"
                + "ACT_ANIO=" + activrray[6] + ","
                + "ACT_SERIE1='" + activrray[7] + "',"
                + "ECO_ID1=" + _ec1 + ","
                + "ECO_ID2=" + _ec2 + ","
                + "ACT_OBSERVACIONES='" + activrray[14] + "',"
                + "USERNAME='" + activrray[15] + " - PPC',"
                + "ACT_FOTO1='" + activrray[16] + "',"
                + "ACT_FOTO2='" + activrray[17] + "',"
                + "EST_ID1=" + activrray[18] + ","
                + "EST_ID2=" + activrray[20] + ","
                + "EST_ID3=" + activrray[67] + ","
                + "GRU_ID1=" + g1 + ","
                + "GRU_ID2=" + g2 + ","
                + "GRU_ID3=" + g3 + ","
                + "UGE_ID1=" + ug1 + ","
                + "UGE_ID2=" + ug2 + ","
                + "UGE_ID3=" + ug3 + ","
                + "UGE_ID4=" + ug4 + ","
                + "UOR_ID1=" + uo1 + ","
                + "UOR_ID2=" + uo2 + ","
                + "UOR_ID3=" + uo3 + ","
                + "CUS_ID1=" + cu + ","
                + "MAR_ID=" + mar + ","
                + "MOD_ID=" + mod + ","
                + "COL_ID=" + _co
                + " WHERE ACT_ID=" + activrray[0];

                sql = sql.Replace(",,,", ",NULL,NULL,");
                sql = sql.Replace(",,", ",NULL,");
                sql = sql.Replace(",,", ",NULL,");
                sql = sql.Replace("''", "NULL");
                sql = sql.Replace("''", "NULL");

                sqlSelectCommand.CommandText = sql;
                sqlSelectCommand.ExecuteNonQuery();

                //2012-05-15-Andrea.- Cambio de id a nombres para insert de hucustodio

                Datos.SqlService sql_huc = new Datos.SqlService();
                int uge1 = sql_huc.ExecuteSqlInt("select uge_id from ugeografica where uge_id=" + ug1);
                int uge2 = sql_huc.ExecuteSqlInt("select uge_id from ugeografica where uge_id=" + ug2);
                int uge3 = sql_huc.ExecuteSqlInt("select uge_id from ugeografica where uge_id=" + ug3);
                int uge4 = sql_huc.ExecuteSqlInt("select uge_id from ugeografica where uge_id=" + ug4);
                int uor1 = sql_huc.ExecuteSqlInt("select uor_id from uorganica where uor_id=" + uo1);
                int uor2 = sql_huc.ExecuteSqlInt("select uor_id from uorganica where uor_id=" + uo2);
                int uor3 = sql_huc.ExecuteSqlInt("select uor_id from uorganica where uor_id=" + uo3);
                int cus1 = sql_huc.ExecuteSqlInt("select cus_id from custodio where cus_id=" + cu);
                int est1 = sql_huc.ExecuteSqlInt("select est_id from estado where est_id=" + activrray[18]);
                int est2 = sql_huc.ExecuteSqlInt("select est_id from estado where est_id=" + activrray[20]);
                int est3 = sql_huc.ExecuteSqlInt("select est_id from estado where est_id=" + activrray[67]);

                //insertamos hucustodio
                Datos.SqlService sql2 = new SqlService();
                sql2.ExecuteSql("INSERT INTO HUCUSTODIO (ACT_ID, USERNAME, HUC_FECHA, UGE_ID1, UGE_ID2,"
                + " UGE_ID3,UGE_ID4, UOR_ID1, UOR_ID2, UOR_ID3, CUS_ID1, CUS_ID2,"
                + " EST_ID1, EST_ID2, EST_ID3) VALUES ("
                + "" + activrray[0] + ","
                + "'" + activrray[15] + " - PPC',"
                + "'" + activrray[4] + "',"
                + "'" + uge1 + "',"
                + "'" + uge2 + "',"
                + "'" + uge3 + "',"
                + "'" + uge4 + "',"
                + "'" + uor1 + "',"
                + "'" + uor2 + "',"
                + "'" + uor3 + "',"
                + "'" + cus1 + "',"
                + "NULL,"
                + "'" + est1 + "',"
                + "'" + est2 + "',"
                + "'" + est3 + "')");

                //insertamos mactivo
                sql2.ExecuteSql("INSERT INTO MACTIVO (ACT_ID, USERNAME, MAC_ACCION) "
                + " VALUES (" + activrray[0] + ", '" + activrray[15] + " - PPC','M')");

                //insertamos hfoto
                if (activrray[16] != "nofoto.gif" || activrray[17] != "nofoto.gif")
                {
                    sql2.ExecuteSql("INSERT INTO HFOTO (ACT_ID, HFO_FOTO1, HFO_FOTO2, USERNAME, CUS_ID1, CUS_ID2) "
                    + "VALUES  (" + activrray[0] + ",'" + activrray[16] + "','" + activrray[17] + "','" + activrray[15] + " - PPC'," + cus1 + ",NULL)");
                }

                resultado[0] = 1;
            }
            else
            {
                if (activrray[66] == "N")
                {

                    //INSERT
                    int actid = Logica.HELPER.getNextActid(activrray[15] + " - PPC");

                    string empid = Logica.HELPER.getEmpresa();
                    string sql1 = "INSERT INTO ACTIVO (ACT_ID ,EMP_ID ,ACT_FECHACREACION, USERNAME  ,ACT_CODBARRAS"
                    + ",ACT_CODBARRASPADRE ,ACT_CODIGO1 ,GRU_ID1 ,GRU_ID2 ,GRU_ID3 ,ACT_FOTO1 ,ACT_FOTO2 ,UGE_ID1"
                    + ",UGE_ID2 ,UGE_ID3 ,UGE_ID4 ,UOR_ID1 ,UOR_ID2 ,UOR_ID3 ,CUS_ID1 ,EST_ID1 ,EST_ID2, EST_ID3"
                    + ",MAR_ID ,MOD_ID ,ACT_SERIE1 ,COL_ID ,ECO_ID1 ,ECO_ID2 ,ACT_ANIO ,ACT_OBSERVACIONES"
                    + ",ACT_TRANSFEROK ,ACT_FECHAINVENTARIO, ACT_RETIQUETAR, ACT_FECHACOMPRA) "
                    + "VALUES ("
                    + "" + actid + ","
                    + "'" + empid + "',"
                    + "'" + activrray[3] + "',"
                    + "'" + activrray[15] + " - PPC',"
                    + "'" + activrray[1] + "',"
                    + "'" + activrray[2] + "',"
                    + "'" + activrray[5] + "',"
                    + "" + g1 + ","
                    + "" + g2 + ","
                    + "" + g3 + ","
                    + "'" + activrray[16] + "',"
                    + "'" + activrray[17] + "',"
                    + "" + ug1 + ","
                    + "" + ug2 + ","
                    + "" + ug3 + ","
                    + "" + ug4 + ","
                    + "" + uo1 + ","
                    + "" + uo2 + ","
                    + "" + uo3 + ","
                    + "" + cu + ","
                    + "" + activrray[18] + ","
                    + "" + activrray[20] + ","
                    + "" + activrray[67] + ","
                    + "" + mar + ","
                    + "" + mod + ","
                    + "'" + activrray[7] + "',"
                    + "" + _co + ","
                    + "" + _ec1 + ","
                    + "" + _ec2 + ","
                    + "" + activrray[6] + ","
                    + "'" + activrray[14] + "',"
                    + "" + 1 + ","
                    + "'" + activrray[4] + "',"
                    + "" + activrray[65] + ","
                    + "'" + activrray[4] + "')";

                    sql1 = sql1.Replace(",,,", ",NULL,NULL,");
                    sql1 = sql1.Replace(",,", ",NULL,");
                    sql1 = sql1.Replace(",,", ",NULL,");
                    sql1 = sql1.Replace("''", "NULL");
                    sql1 = sql1.Replace("''", "NULL");

                    sqlSelectCommand.CommandText = sql1;
                    sqlSelectCommand.ExecuteNonQuery();

                    //2012-05-15-Andrea.- Cambio de id a nombres para insert de hucustodio

                    Datos.SqlService sql_huc = new Datos.SqlService();
                    string uge1 = sql_huc.ExecuteSqlString("select uge_nombre from ugeografica where uge_id=" + ug1);
                    string uge2 = sql_huc.ExecuteSqlString("select uge_nombre from ugeografica where uge_id=" + ug2);
                    string uge3 = sql_huc.ExecuteSqlString("select uge_nombre from ugeografica where uge_id=" + ug3);
                    string uge4 = "Piso " + sql_huc.ExecuteSqlString("select uge_nombre from ugeografica where uge_id=" + ug4);
                    string uor1 = sql_huc.ExecuteSqlString("select uor_nombre from uorganica where uor_id=" + uo1);
                    string uor2 = sql_huc.ExecuteSqlString("select uor_nombre from uorganica where uor_id=" + uo2);
                    string uor3 = sql_huc.ExecuteSqlString("select uor_nombre from uorganica where uor_id=" + uo3);
                    string cus1 = sql_huc.ExecuteSqlString("select (cus_apellidos +' '+cus_nombres) from custodio where cus_id=" + cu);
                    string est1 = sql_huc.ExecuteSqlString("select est_nombre from estado where est_id=" + activrray[18]);
                    string est2 = sql_huc.ExecuteSqlString("select est_nombre from estado where est_id=" + activrray[20]);
                    string est3 = sql_huc.ExecuteSqlString("select est_nombre from estado where est_id=" + activrray[67]);

                    //insertamos hucustodio
                    Datos.SqlService sql2 = new SqlService();
                    sql2.ExecuteSql("INSERT INTO HUCUSTODIO (ACT_ID, USERNAME, UGE_ID1, UGE_ID2,"
                    + " UGE_ID3,UGE_ID4, UOR_ID1, UOR_ID2, UOR_ID3, CUS_ID1, CUS_ID2,"
                    + " EST_ID1, EST_ID2, EST_ID3) VALUES ("
                    + "" + actid + ","
                    + "'" + activrray[15] + " - PPC',"
                    + "" + uge1 + ","
                    + "" + uge2 + ","
                    + "" + uge3 + ","
                    + "" + uge4 + ","
                    + "" + uor1 + ","
                    + "" + uor2 + ","
                    + "" + uor3 + ","
                    + "" + cus1 + ","
                    + "NULL,"
                    + "" + est1 + ","
                    + "" + est2 + ","
                    + "" + est3 + ")"); //ID DEL ESTADO 3

                    //insertamos mactivo
                    sql2.ExecuteSql("INSERT INTO MACTIVO (ACT_ID, USERNAME, MAC_ACCION) "
                    + " VALUES (" + actid + ", '" + activrray[15] + " - PPC','I')");

                    //insertamos hfoto
                    if (activrray[16] != "nofoto.gif" || activrray[17] != "nofoto.gif")
                    {
                        sql2.ExecuteSql("INSERT INTO HFOTO (ACT_ID, HFO_FOTO1, HFO_FOTO2, USERNAME, CUS_ID1, CUS_ID2) "
                        + "VALUES  (" + actid + ",'" + activrray[16] + "','" + activrray[17] + "','" + activrray[15] + " - PPC'," + cus1 + ",NULL)");
                    }

                    //devolvemos el nuevo id
                    resultado[0] = 1;
                    resultado[1] = actid;
                }
            }
        }
        catch (Exception ex)
        {
            resultado[0] = 0;
            throw ex;
        }
        finally
        {
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
        }
        return resultado;
    }

    private string getEstado3(string actid)
    {

        Datos.SqlService sql = new Datos.SqlService();
        Object obj = sql.ExecuteSqlObject("select est_id3 from activo where act_id=" + actid);
        if (obj == null || obj.ToString() == "")
            return "NULL";
        else
            return obj.ToString();
    }

    [WebMethod]
    public int buscarCrearCatalogo(string nom, string tbl, string campoid, string camponom)
    {
        int ide = 0;
        Datos.SqlService sql = new SqlService();
        object obj = sql.ExecuteSqlObject("select " + campoid + " from " + tbl + " where " + camponom + " = '" + nom + "'");

        if (obj == null || obj.ToString() == "") //si no encontró
        {

            object obj2 = sql.ExecuteSqlObject("insert into " + tbl + " (" + camponom + ") values ('" + nom + "'); select scope_identity()");
            ide = int.Parse(obj2.ToString());
        }
        else
            ide = int.Parse(obj.ToString());

        return ide;
    }

    private int buscarCrearCatalogoNiv(string campoid, string tabla, string camponom, string campopad, string camponiv, string nombre, int padre, int nivel)
    {
        int ide = 0;
        Datos.SqlService sql = new SqlService();
        object obj = sql.ExecuteSqlObject("select " + campoid + " from " + tabla + " where " + camponom + " = '" + nombre + "' and " + campopad + "=" + padre + " and " + camponiv + "=" + nivel);

        if (obj == null || obj.ToString() == "") //si no encontró
        {

            object obj2 = sql.ExecuteSqlObject("insert into " + tabla + " (" + camponom + "," + campopad + "," + camponiv + ") values ('" + nombre + "'," + padre + "," + nivel + "); select scope_identity()");
            ide = int.Parse(obj2.ToString());
        }
        else
            ide = int.Parse(obj.ToString());

        return ide;
    }

    private int buscarCrearCatalogoModelo(string campoid, string tabla, string camponom, string campopad, string camponiv, string nombre, int padre, int nivel)
    {
        int ide = 0;
        Datos.SqlService sql = new SqlService();
        object obj = sql.ExecuteSqlObject("select " + campoid + " from " + tabla + " where " + camponom + " = '" + nombre + "' and " + campopad + "=" + padre + " and " + camponiv + "=" + nivel);

        if (obj == null || obj.ToString() == "") //si no encontró
        {

            object obj2 = sql.ExecuteSqlObject("insert into " + tabla + " (" + camponom + "," + campopad + ") values ('" + nombre + "'," + padre + "); select scope_identity()");
            ide = int.Parse(obj2.ToString());
        }
        else
            ide = int.Parse(obj.ToString());

        return ide;
    }

    private int buscarCrearCatalogoNiv2(string campoid, string tabla, string camponom, string campopad, string camposuperpadre, string camponiv, string nombre, int padre, int superpadre, int nivel)
    {
        int ide = 0;
        Datos.SqlService sql = new SqlService();
        object obj = sql.ExecuteSqlObject("select " + campoid + " from " + tabla + " where " + camponom + " = '" + nombre + "' and " + campopad + "=" + padre + " and " + camposuperpadre + "=" + superpadre + " and " + camponiv + "=" + nivel);

        if (obj == null || obj.ToString() == "") //si no encontró
        {

            object obj2 = sql.ExecuteSqlObject("insert into " + tabla + " (" + camponom + "," + campopad + "," + camponiv + "," + camposuperpadre + ") values ('" + nombre + "'," + padre + "," + nivel + "," + superpadre + "); select scope_identity()");
            ide = int.Parse(obj2.ToString());
        }
        else
            ide = int.Parse(obj.ToString());

        return ide;
    }

    private int buscarCrearCustodio(string nombres, string apellidos, int uorid2)
    {
        int idSinCargo = 1;
        //int idSinCargo = Logica.HELPER.getSinCargo();

        int ide = 0;
        Datos.SqlService sql = new SqlService();
        object obj = sql.ExecuteSqlObject("select cus_id from CUSTODIO where CUS_NOMBRES='" + nombres + "' and CUS_APELLIDOS='" + apellidos + "'");

        if (obj == null || obj.ToString() == "") //si no encontró
        {

            object obj2 = sql.ExecuteSqlObject("insert into custodio (cus_nombres, cus_apellidos,cgo_id) values ('" + nombres + "','" + apellidos + "'," + idSinCargo + "); select scope_identity()");
            ide = int.Parse(obj2.ToString());
            sql.ExecuteSql("insert into xcuor (cus_id, uor_id) values (" + ide + "," + uorid2 + ")");
        }
        else
        {
            ide = int.Parse(obj.ToString());

            object obj3 = sql.ExecuteSqlObject("select xcu_id from xcuor where cus_id=" + ide + " and uor_id=" + uorid2);
            if (obj3 == null || obj3.ToString() == "") //si no encontró
            {
                sql.ExecuteSql("insert into xcuor (cus_id, uor_id) values (" + ide + "," + uorid2 + ")");
            }
        }
        return ide;
    }


    [WebMethod]
    public bool buscarCb(string cb)
    {
        if (Logica.HELPER.comprobarCbIngresado(cb))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    [WebMethod]
    public bool TimeTrashStrCar(string activo)
    {
        string[] activrray = activo.Split('|');

        bool transfer = true;
        //
        System.ServiceModel.BasicHttpBinding binding = new System.ServiceModel.BasicHttpBinding();
        // if you are getting a LOT of data back, you will need to up Message Size
        binding.MaxReceivedMessageSize = int.MaxValue;

        SqlConnection cnn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        cnn.ConnectionString = constr;
        SqlCommand sqlSelectCommand = new SqlCommand();
        sqlSelectCommand.CommandText = "";
        sqlSelectCommand.Connection = cnn;
        try
        {
            cnn.Open();

            string sql = "INSERT INTO CARACTERISTICA (ACT_ID, CFA_ID, CAR_VALOR, UNI_ID)  VALUES ("
            + activrray[0] + ","
            + activrray[1] + ","
            + "'" + activrray[2] + "',"
            + activrray[3] + ")";

            sql = sql.Replace(",)", ",NULL)");
            sql = sql.Replace(",,", ",NULL,");
            sql = sql.Replace(",,", ",NULL,");
            sql = sql.Replace("''", "NULL");
            sql = sql.Replace("''", "NULL");

            sqlSelectCommand.CommandText = sql;
            sqlSelectCommand.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            transfer = false;
            throw ex;
        }
        finally
        {
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
        }
        return transfer;
    }

    [WebMethod]
    public void TimeTrashStrPrevia(string actid)
    {
        Datos.SqlService sql = new SqlService();
        sql.ExecuteSql("update caracteristica set car_del=1 where act_id=" + actid);
    }

    [WebMethod]
    public void TimeTrashStrPost()
    {
        Datos.SqlService sql = new SqlService();
        sql.ExecuteSql("delete from caracteristica where car_del=1");
    }

    [WebMethod]
    public bool TimeTrashMantIn(DataSet dsPocketMan)
    {
        string sql = "";
        bool transfer = true;
        //
        System.ServiceModel.BasicHttpBinding binding = new System.ServiceModel.BasicHttpBinding();
        // if you are getting a LOT of data back, you will need to up Message Size
        binding.MaxReceivedMessageSize = int.MaxValue;

        SqlConnection cnn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        cnn.ConnectionString = constr;
        SqlCommand sqlSelectCommand = new SqlCommand();
        sqlSelectCommand.CommandText = "sede";
        sqlSelectCommand.Connection = cnn;

        try
        {
            cnn.Open();

            foreach (DataRow row in dsPocketMan.Tables[0].Rows)
            {
                sql = "insert into mantenimiento (man_fecha, username, tip_id, man_descripcion, act_id) values ('" + Convert.ToDateTime(row["man_fecha"]).ToString("yyyyMMdd hh:mm:ss") + "','" + row["username"].ToString() + "'," + row["tip_id"].ToString() + ",'" + row["man_descripcion"].ToString() + "'," + row["act_id"].ToString() + ")";
                sqlSelectCommand.CommandText = sql;
                sqlSelectCommand.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            return transfer;
        }
        finally
        {
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
        }
        return transfer;
    }

    [WebMethod]
    public int getNextActid(string user)
    {
        Datos.SqlService sql = new Datos.SqlService();
        int x = sql.ExecuteSqlIdentity("insert into ACRESERVA (username) values ('" + user + "') SET @identity = SCOPE_IDENTITY()");
        return x;
    }

    [WebMethod]
    public object GetObject(string query)
    {
        Datos.SqlService sql = new Datos.SqlService();
        return sql.ExecuteSqlObject(query);
    }
}

