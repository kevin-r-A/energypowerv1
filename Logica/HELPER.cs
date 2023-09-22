using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Logica
{
    public static class HELPER
    {
        public static bool comprobarCbIngresado(string cb)
        {
            Datos.SqlService sql = new Datos.SqlService();
            string nuevo = "select act_id from activo where act_codbarras='" + cb + "'";
            Object obj = sql.ExecuteSqlObject("select act_id from activo where act_codbarras='" + cb + "'");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool comprobarCodSecundarioIngresado(string cs)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where act_codigo1= '" + cs + "'");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool comprobarCodLogikard(string cb)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_codigo1 from activo where act_codigo1 = '" + cb + "'");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool VerificaTipoBienSerie(string cb)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_tipo from activo where ACT_SERIE1='" + cb + "'");

            if (obj != null)
            {
                if (obj.ToString().Trim() == "Activo Fijo" || obj.ToString().Trim() == "ACTIVO FIJO")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool comprobarIdIngresado(string ide)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where act_codigo1='" + ide + "'");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool VerificaTipoBienCodSec(string cb)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_tipo from activo where act_codigo1='" + cb + "'");

            if (obj != null)
            {
                if (obj.ToString().Trim() == "Activo Fijo" || obj.ToString().Trim() == "ACTIVO FIJO")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool comprobarIdIngresadoSerie(string ide)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where act_serie1='" + ide + "'");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool itemDadoDeBajaBNF(string ide)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where act_codigo1='" + ide + "' and act_fechabaja is not null");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool itemDadoDeBajaSR(string ide)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where ACT_SERIE1='" + ide + "' and act_fechabaja is not null");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool comprobarIdIngresadoLogikard(string ide)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where act_id='" + ide + "'");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool comprobarCodigoRFIDIngresado(string cod)
        {

            Datos.SqlService sql = new Datos.SqlService();

            Object obj = sql.ExecuteSqlObject("select act_id from activo where act_codbarras = '" + cod.Trim() + "'");

            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public static bool itemDadoDeBaja(string ide)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where act_id='" + ide + "' and act_fechabaja is not null");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool itemDadoDeBajaLogikard(string ide)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where act_codigo1='" + ide + "' and act_fechabaja is not null");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool itemDadoDeBajaCb(string cb)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where act_codbarras='" + cb + "' and act_fechabaja is not null");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string FltraRFID(string codbarras, int estado)
        {
            string error = "";

            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@codbarras", SqlDbType.VarChar, codbarras);
            sql.AddParameter("@estado", SqlDbType.Int, estado);
            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);

            sql.ExecuteSPDataTable("usp_CambiaEstadoAutFiltro");
            error = sql.Parameters["@err"].Value.ToString();
            return error;
        }


        public static DataTable getReporteAutorizadosRFID(string where)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@where", SqlDbType.VarChar, where);
            return sql.ExecuteSPDataTable("usp_ReporteAutorizadosRFID");
        }


        public static DataTable getReporteFiltradoRFID(string where)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@where", SqlDbType.VarChar, where);
            return sql.ExecuteSPDataTable("usp_ReporteFiltradoRFID");
        }

        public static string ActualizaAutorizacionRFID(string codbarras, int estado)
        {
            string error = "";

            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@codbarras", SqlDbType.VarChar, codbarras);
            sql.AddParameter("@estado", SqlDbType.Int, estado);
            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);

            sql.ExecuteSPDataTable("usp_CambiaEstadoAutActivo");
            error = sql.Parameters["@err"].Value.ToString();
            return error;
        }

        public static Boolean codigoRFIDValido(string cb)
        {
            Boolean valido = true;

            if (cb == "0" || cb == "00" || cb == "000" || cb == "0000" || cb == "00000")
            {
                valido = false;
            }
            else
            {
                valido = true;
            }

            return valido;
        }

        public static string getSecuencia(string cb)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select max(CONVERT(int,substring(act_codbarras,16,5))) from ACTIVO where substring(act_codbarras,0,15)='" + cb + "'");
            if (obj == null)
                return cb + ".1";
            else
                return cb + "." + (int.Parse(obj.ToString()) + 1).ToString();
        }
        // incrementamos un nivel mas al codigo de barras padre

        public static string getUltCodimpr()
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select max (cod_secuencial) from codigo");
            if (obj == null || obj.ToString() == "")
                return "0";
            else
                return obj.ToString();
        }

        public static int getNextActid(string user)
        {
            Datos.SqlService sql = new Datos.SqlService();
            int x = sql.ExecuteSqlIdentity("insert into ACRESERVA (username) values ('" + user + "') SET @identity = SCOPE_IDENTITY()");
            return x;
        }

        public static int getNextActid()
        {
            Datos.SqlService sql = new Datos.SqlService();
            int x = sql.ExecuteSqlInt("select max(act_id) + 1 as maximo from  ACTIVO");
            return x;
        }



        public static int getLastCb(int td)
        {
            int last = -1;
            Datos.SqlService sql = new Datos.SqlService();
            Object obj;

            if (td == 14)
                obj = sql.ExecuteSqlObject("select max(CONVERT(int, substring(act_codbarras,8,6))) from ACTIVO");
            else
                obj = sql.ExecuteSqlObject("select max(CONVERT(int, substring(act_codbarras,14,6))) from ACTIVO");


            if (obj.ToString() == "")
                last = 0;
            else
                last = int.Parse(obj.ToString());

            return last;
        }

        public static string IncrementaCB(string cb)
        {
            Datos.SqlService sql = new Datos.SqlService();
            int obj = (int)sql.ExecuteSqlObject("select MAX(SUBSTRING(ac.ACT_CODBARRAS,15,1))from ACTIVO where act_id='" + cb + "'");
            if (obj == 0)
            {
                obj = 1;
                return cb + "." + obj;
            }
            else
            {
                obj++;
                return cb + "." + obj;
            }
        }


        public static Boolean codigoValido(string cb)
        {
            Boolean valido = true;

            if (cb.Length == 14)
            {
                decimal pares = 0;
                decimal impares = 0;
                decimal digito = 0;
                string[] astr = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                //NO TOMA EN CUENTA EL 8004        
                for (int j = 4; j < cb.Length; j++)
                {
                    astr[j] = cb.Substring(j, 1);
                    if (j % 2 == 0)
                    {
                        if (astr[j] != "")
                        {
                            pares = pares + System.Convert.ToDecimal(astr[j]);
                        }
                    }
                    else
                        if (j < cb.Length - 1)
                    {
                        impares = impares + System.Convert.ToDecimal(astr[j]);
                    }
                }
                pares = pares * 3;
                digito = 1000 - (pares + impares);
                if (digito.ToString().Substring(2, 1) == astr[13])
                    valido = true;
                else
                    valido = false;

            }
            else if (cb.Length == 20)
            {
                valido = codigoValido20(cb);
            }

            return valido;
        }


        public static Boolean codigoValido20(string cb)
        {
            Boolean valido = true;
            decimal pares = 0;
            decimal impares = 0;
            decimal digito = 0;

            char[] cbarr = cb.ToCharArray(4, 16);

            Array.Reverse(cbarr);

            for (int j = 1; j < cbarr.Length; j++)
            {
                if (j % 2 == 0)
                {
                    impares = impares + System.Convert.ToDecimal(cbarr[j].ToString());
                }
                else
                {
                    pares = pares + System.Convert.ToDecimal(cbarr[j].ToString());
                }
            }
            pares = pares * 3;
            digito = 1000 - (pares + impares);
            if (digito.ToString().Substring(2, 1) == cbarr[0].ToString())
                valido = true;
            else
                valido = false;

            return valido;
        }

        public static int existePadreIngresado(string cb)
        {
            int x = 0;
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where act_codbarras='" + cb + "'");
            if (obj != null)
            {
                x = 1;
            }
            return x;

        }

        public static int getEstado(int ide, string campoestado)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select " + campoestado + " from activo where act_id=" + ide);
            return int.Parse(obj.ToString());
        }

        public static int getDigitadores()
        {
            int x = 0;
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select COUNT(distinct(username)) from ACTIVO");
            if (obj != null)
            {
                x = int.Parse(obj.ToString());
            }
            return x;
        }

        public static int getNumHijos(string actid)
        {
            int x = 0;
            Datos.SqlService sql = new Datos.SqlService();
            //Object obj = sql.ExecuteSqlObject("select COUNT(act_id) from ACTIVO where act_codbarraspadre in (select act_codbarras from activo where act_id = " + actid + ")");
            Object obj = sql.ExecuteSqlObject("select COUNT(act_id) from ACTIVO where act_codbarraspadre in (select act_codbarras from activo where act_id=" + actid + ") and ACT_TIPOBAJA is null");
            if (obj != null)
            {
                x = int.Parse(obj.ToString());
            }
            return x;
        }
        public static DataTable getReporteTotal(string fecha1, string fecha2)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@fecha1", SqlDbType.SmallDateTime, fecha1);
            sql.AddParameter("@fecha2", SqlDbType.SmallDateTime, fecha2);
            return sql.ExecuteSPDataTable("usp_getIngresadosXFechaGlob");

        }
        public static DataTable getReporteTotalAva(DateTime fecha1, DateTime fecha2, string user)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@f1", SqlDbType.SmallDateTime, fecha1);
            sql.AddParameter("@f2", SqlDbType.SmallDateTime, fecha2);
            sql.AddParameter("@user", SqlDbType.SmallDateTime, user);
            return sql.ExecuteSPDataTable("usp_ReporteGlobalACTIVO2");

        }

        public static DataTable getReporteTotal2(string fecha1, string fecha2)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@fecha1", SqlDbType.SmallDateTime, fecha1);
            sql.AddParameter("@fecha2", SqlDbType.SmallDateTime, fecha2);
            return sql.ExecuteSPDataTable("usp_getIngresadosXFechaGlob2");

        }

        public static DataTable getNomDigi()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("SELECT DISTINCT USERNAME FROM MACTIVO ORDER BY USERNAME");
        }

        public static DataTable getRolesPpc()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select rpp_id, rpp_nombre from rolppc order by rpp_nombre");
        }

        public static void insRolesPpc(string usu, string rol)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("insert into usurolppc (upp_usuario,rpp_id) values ('" + usu + "'," + rol + ")");
        }
        public static void delRolesPpc(string usu, string rol)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("delete from usurolppc where upp_usuario='" + usu + "' and rpp_id=" + rol);
        }

        public static DataTable getCar(string family)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select cfa_nombre, cfa_id, cfa_unidades from CFAMILIA where GRU_ID=" + family + " order by CFA_ORDEN");
        }

        public static DataTable getConcil(string codigo)
        {
            Datos.SqlService sql = new Datos.SqlService();
            if (codigo != "")
            {
                return sql.ExecuteSqlDataTable("select cli_id, cli_codigo, cli_descripcion, cli_conciliado from BASECLI where CLI_CODIGO='" + codigo + "' order by CLI_DESCRIPCION");
            }
            else
            {
                return null;
            }
        }

        public static int getConcilTablaInt(string actid, string clid)
        {
            if (actid != "")
            {
                int x = 0;
                Datos.SqlService sql = new Datos.SqlService();
                Object obj = sql.ExecuteSqlObject("select con_id from CONCILIA where ACT_ID=" + actid + " and cli_id=" + clid);
                if (obj != null)
                {
                    x = 1;

                }
                return x;
            }
            else
            {
                return 0;
            }
        }

        public static void updBaseCliConcil(string codigo)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("update basecli set cli_conciliado='SI' where cli_id=" + codigo);
        }

        public static bool existeMarcaIng(string marca)
        {
            Datos.SqlService sql = new Datos.SqlService();

            Object obj = sql.ExecuteSqlObject("select mar_id from marca where mar_nombre='" + marca + "'");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool existeModeloIng(string nombre, int marid)
        {
            Datos.SqlService sql = new Datos.SqlService();

            Object obj = sql.ExecuteSqlObject("select mod_id from modelo where mod_nombre='" + nombre + "' and mar_id=" + marid);
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool existeColorIng(string color)
        {
            Datos.SqlService sql = new Datos.SqlService();

            Object obj = sql.ExecuteSqlObject("select col_id from color where col_nombre='" + color + "'");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool existeUsuPpcIng(string usu)
        {
            Datos.SqlService sql = new Datos.SqlService();

            Object obj = sql.ExecuteSqlObject("select upp_usuario from usuppc where upp_usuario='" + usu + "'");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool existePpcIng(string ppcid)
        {
            Datos.SqlService sql = new Datos.SqlService();

            Object obj = sql.ExecuteSqlObject("select ppc_numero from ppc where ppc_numero=" + ppcid);
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool existeProveedorIng(string proveedor)
        {
            Datos.SqlService sql = new Datos.SqlService();

            Object obj = sql.ExecuteSqlObject("select pro_id from proveedor where pro_nombre='" + proveedor + "'");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool existeCustodioIng(string nombre, string apellido)
        {
            Datos.SqlService sql = new Datos.SqlService();

            Object obj = sql.ExecuteSqlObject("select cus_id from custodio where cus_nombres='" + nombre + "' and cus_apellidos='" + apellido + "'");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool existeCargoIng(string cargo)
        {
            Datos.SqlService sql = new Datos.SqlService();

            Object obj = sql.ExecuteSqlObject("select cgo_id from cargo where cgo_nombre='" + cargo + "'");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool existeEstrucIng(string estruc)
        {
            Datos.SqlService sql = new Datos.SqlService();

            Object obj = sql.ExecuteSqlObject("select eco_id from estrucomp where eco_nombre='" + estruc + "'");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int existeModeloIng(string marca, string modelo)
        {
            int x = 0;
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select mod_id from MODELO, MARCA where marca.MAR_ID=modelo.MAR_ID and MOD_NOMBRE='" + modelo + "' and MAR_NOMBRE='" + marca + "' and mod_habilitado=1");
            if (obj != null)
            {
                x = 1;
            }
            return x;
        }

        public static string getNombre(string tabla, string retcampo, string ide, string campoide)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select " + retcampo + " from " + tabla + " where " + campoide + " = " + ide);
            return obj.ToString();
        }

        public static string getRazonBaja(int tipobaja)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select est_nombre from estado where est_id=" + tipobaja);
            return obj.ToString();
        }

        public static string getCustodio(string ide)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select cus_apellidos+ ' '+cus_nombres from custodio where cus_id=" + ide);
            return obj.ToString();
        }

        public static DataTable getReporteXUsu(DateTime desde, DateTime hasta, string usuario)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@DESDE", SqlDbType.SmallDateTime, desde);
            sql.AddParameter("@HASTA", SqlDbType.SmallDateTime, hasta);
            sql.AddParameter("@USER", SqlDbType.VarChar, usuario);
            return sql.ExecuteSPDataTable("usp_GetReporteXUsu");
        }

        public static DataTable getReporteGlobal()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSPDataTable("usp_ReporteGlobalACTIVO");
        }

        //2012-02-29 Andrea.- Reporte de activos custodio para exportar a Pdf
        public static DataTable getReporteActivosPdf(string where)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@where", SqlDbType.VarChar, where);
            return sql.ExecuteSPDataTable("usp_ReporteACTIVOPdf");
            //return sql.ExecuteSPDataTable("usp_getDatosPDF_ItemXCustodios");

        }


        //Reporte de Inclusion de seguros para exportar a Pdf
        public static DataTable getReporteINCLUSIONPdf(string where, int tipo)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@op", SqlDbType.VarChar, tipo);
            sql.AddParameter("@where", SqlDbType.VarChar, where);
            return sql.ExecuteSPDataTable("usp_ReporteINCLUSIONPdf");

        }


        public static DataTable getAsignadosPpc(string query, string tipo)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@tipo", SqlDbType.VarChar, tipo);
            sql.AddParameter("@where", SqlDbType.VarChar, query);
            return sql.ExecuteSPDataTable("usp_getFiltroActivoPpc");
        }

        public static DataTable getReporteEnviadosMantenimiento(string where)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@where", SqlDbType.VarChar, where);
            return sql.ExecuteSPDataTable("usp_IngresaDeMantenimiento");
        }

        public static DataTable getReporteGlobalPpc()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSPDataTable("usp_GetReporteGlobal2");
        }

        public static DataTable getReporteBusCb(string cb, string sp)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@cb", SqlDbType.VarChar, cb);
            return sql.ExecuteSPDataTable(sp);
        }
        public static DataTable getReporteBusCbp(string cb, string sp)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@cbp", SqlDbType.VarChar, cb);
            return sql.ExecuteSPDataTable(sp);
        }
        public static DataTable getReporteBusSec(string sec, string sp)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@sec", SqlDbType.VarChar, sec);
            return sql.ExecuteSPDataTable(sp);
        }
        public static DataTable getReporteBusSecp(string secp, string sp)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@secp", SqlDbType.VarChar, secp);
            return sql.ExecuteSPDataTable(sp);
        }
        public static DataTable getReporteBusCa(string ca, string sp)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@ca", SqlDbType.VarChar, ca);
            return sql.ExecuteSPDataTable(sp);
        }
        public static DataTable getReporteBusDes(string des, string sp)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@des", SqlDbType.VarChar, des);
            return sql.ExecuteSPDataTable(sp);
        }

        public static DataTable getReporteBusCar(string car, string val, string sp)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@car", SqlDbType.VarChar, car);
            sql.AddParameter("@val", SqlDbType.VarChar, val);
            return sql.ExecuteSPDataTable(sp);
        }

        public static int getIdEstr(string estrucomp)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select eco_id from estrucomp where eco_nombre='" + estrucomp + "'");
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
        }

        public static int getIngresXDigi(string user, string date)//OK
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select COUNT(act_id) from MACTIVO where username='" + user + "' and convert(varchar(10),MAC_FECHA,103)='" + date + "' AND MAC_ACCION='I'");
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
        }

        public static int getUpdatesXDigi(string user, string date)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select COUNT(act_id) from MACTIVO where username='" + user + "' and convert(varchar(10),MAC_FECHA,103)='" + date + "' AND MAC_ACCION='M'");
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
        }

        public static int getIngresosXDigi(string user, string date1, string date2)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("SELECT COUNT(ACT_ID) FROM MACTIVO WHERE MAC_FECHA between convert(datetime,'" + date1 + "',103) and dateadd(day, 1,convert(datetime,'" + date2 + "',103)) and USERNAME='" + user + "' and mac_accion='I'");
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
        }

        public static int getModificadosXDigi(string user, string date1, string date2)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("SELECT COUNT(ACT_ID) FROM MACTIVO WHERE MAC_FECHA between convert(datetime,'" + date1 + "',103) and dateadd(day, 1,convert(datetime,'" + date2 + "',103)) and USERNAME='" + user + "' and mac_accion='M'");
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
        }

        public static int getGruIdXActId(string actid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select gru_id1 from activo where act_id=" + actid);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
        }

        public static int getOrden(int cfaid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select cfa_orden from cfamilia where cfa_id=" + cfaid);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
        }

        public static DataTable getEmpresas(string empid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select emp_nombre, emp_prefijo, emp_totaldigitos from empresa where emp_id='" + empid + "'");
        }

        public static string getEmpresa()
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select emp_nombre from empresa");
            if (obj == null || obj.ToString() == "")
                return "0";
            else
                return obj.ToString();
        }

        public static DataTable getHistorialCod()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select hco_fecha as Fecha, hco_usuario as Usuario, hco_tipo as Tipo, hco_cod1 as Desde, hco_cod2 as Hasta, hco_numero as Impresos from hcodigo ");
        }

        public static DataTable getActivosFiltro()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select hco_fecha as Fecha, hco_usuario as Usuario, hco_tipo as Tipo, hco_cod1 as Desde, hco_cod2 as Hasta, hco_numero as Impresos from hcodigo ");
        }

        public static DataTable getPreDepre(string sp)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSPDataTable(sp);
        }

        public static DataTable getCaractereisticas()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select CCA_ID, CCA_NOMBRE FROM CCAR ORDER BY CCA_NOMBRE");
        }

        public static DataTable getUsuRolPPc(string usu)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select rpp_id from usurolppc where upp_usuario='" + usu + "'");
        }

        public static DataTable getCaracteristicasNa(int gruid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select CCA_ID, CCA_NOMBRE FROM CCAR where cca_nombre not in (select cfa_nombre from cfamilia where gru_id=" + gruid + ") ORDER BY CCA_NOMBRE");
        }
        public static DataTable getCaracteristicasA(int gruid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            //return sql.ExecuteSqlDataTable("select CCA_ID, CCA_NOMBRE FROM CCAR where cca_nombre in (select cfa_nombre from cfamilia where gru_id=" + gruid + ") ORDER BY CCA_NOMBRE");
            return sql.ExecuteSqlDataTable("select cfa_nombre+'  [ '+convert(varchar(10),COUNT(car_id))+' registros ]' as cfa_nombre, cfamilia.cfa_id, cfa_unidades, cfa_orden from cfamilia left join CARACTERISTICA on CARACTERISTICA.CFA_ID=cfamilia.cfa_id where gru_id=" + gruid + " GROUP BY cfa_nombre, cfamilia.cfa_id, cfa_unidades, cfa_orden order by cfa_orden");
        }


        public static DataTable getPpc()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select ppc_numero, ppc_serial from ppc order by ppc_numero");
        }

        public static DataTable getPreDepreNiif(string sp)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSPDataTable(sp);
        }

        public static DataTable getReval(string actid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select convert(varchar(10),act_fechainventario,103) as [FECHA INVENTARIO], convert(decimal(18,2),val_actual) as [VALOR ACTUAL], convert(decimal(18,2),val_reposicion)  as [VALOR DE REPOSICION], convert(decimal(18,2),val_residual)  as [VALOR RESIDUAL], convert(decimal(18,2),val_vidautilres)  as [VIDA UTIL RESIDUAL] from activo, valor where valor.act_id=" + actid + " and activo.act_id=valor.act_id");
        }

        public static DataTable getSeguros(string actid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("SELECT TOP 1 SEG_ID, TSE_ID, ASE_ID, SEG_VALORPOLIZA, SEG_FECHAINI, SEG_FECHAFIN, SEG_FECHACREA FROM SEGURO WHERE ACT_ID=" + actid + " ORDER BY SEG_FECHACREA DESC");
        }

        public static void insDepre(string fecha, string valactual, string valresid, int vidautilres, int periodost, int perres, string deper, string deptot, string saldo, string idd)
        {
            valactual = valactual.Replace(',', '.');
            valresid = valresid.Replace(',', '.');
            deper = deper.Replace(',', '.');
            deptot = deptot.Replace(',', '.');
            saldo = saldo.Replace(',', '.');

            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("insert into logdepre (DEP_FECHAINV,DEP_VALACTUAL,DEP_VALRESID,DEP_VIDAUTILRES,DEP_PERIODOST,DEP_PERREST,DEP_DEPPER,DEP_DEPTOT,DEP_SALDO, act_id) values ('" + fecha + "'," + valactual + "," + valresid + "," + vidautilres + "," + periodost + "," + perres + "," + deper + "," + deptot + "," + saldo + "," + idd + ")");
        }

        public static DataTable getDepreNiff(string actid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select act_id as [ID],convert(varchar(10),dep_fechainv,103) as [FECHA CORTE], dep_valactual as [REVALORACION], DEP_VALRESID as [VALOR RESIDUAL], DEP_VIDAUTILRES as [VIDA UTIL RESIDUAL], DEP_PERIODOST as [PERIODOS TRANS.], DEP_PERREST as [PREIODOS REST.], DEP_DEPPER as [DEP. PERIODO], DEP_DEPTOT as [DEP. TOTAL], DEP_SALDO as [DEP. SALDO] from logdepre where act_id=" + actid + " order by dep_id");
        }

        public static DataTable getBasecli()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select * from basecli");
        }
        public static int getIdMarca(string mar_nombre)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select mar_id from marca where mar_nombre='" + mar_nombre + "' and mar_habilitado=1");
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
        }

        public static string getVuSriGrupo(string gruid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select GRU_VUSRI from gruposri where gru_id=" + gruid);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "0";
            }
        }

        public static DataTable getCarSet(string family)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select cfa_id, cfa_nombre, cfa_orden, cfa_habilitada, gru_id1, cfa_unidades from CFAMILIA where GRU_ID1=" + family + " order by CFA_ORDEN");
        }

        public static void saveDocs(string foto1, string foto2, string factura, string manual, string actid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSqlDataTable("update activo set act_foto1='" + foto1 + "' , act_foto2='" + foto2 + "' , act_doc1='" + factura + "', act_doc2='" + manual + "' where act_id=" + actid);
        }

        public static void delAdjunto(string tipo, string actid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("update activo set " + tipo + "= null where act_id=" + actid);
        }

        public static void saveDoc(string campo, string valor, string actid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSqlDataTable("update activo set " + campo + "='" + valor + "' where act_id=" + actid);
        }

        public static bool VerificaTipoBien(string cb)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_tipo from activo where act_codbarras='" + cb + "'");

            if (obj != null)
            {
                if (obj.ToString().Trim() == "Activo Fijo" || obj.ToString().Trim() == "ACTIVO FIJO")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static DataTable getMantenimiento(string idcod, int tipo)
        {
            Datos.SqlService sql = new Datos.SqlService();
            //sql.AddParameter("@idcod", SqlDbType.VarChar, idcod);
            //sql.AddParameter("@tipo", SqlDbType.VarChar, tipo);
            //return sql.ExecuteSPDataTable("usp_getReporteMantenimiento");

            sql.AddParameter("@codbarras", SqlDbType.VarChar, idcod);
            sql.AddParameter("@op", SqlDbType.Int, tipo);
            return sql.ExecuteSPDataTable("usp_ReporteHistoricoMantenimiento");
        }
        //DICE 2014-10-14 CONSULTA DATOS DE ACTIVO EN MODULO MANTENIMIENTO
        public static DataTable getDescripItemMant(string codigo, string serie, int op)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@CODIGO", SqlDbType.VarChar, codigo);
            sql.AddParameter("@SERIE", SqlDbType.VarChar, serie);
            sql.AddParameter("@OP", SqlDbType.Int, op);
            return sql.ExecuteSPDataTable("MANTENIMIENTOPC01");

        }

        public static DataTable getArranqueMantenimientos(string codigo)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@codigo", SqlDbType.Int, codigo);
            return sql.ExecuteSPDataTable("usp_ArranqueMantenimientos");

        }

        public static DataTable getVerificaExisteArranqueMant(string codigo)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@act_codbarras", SqlDbType.VarChar, codigo);
            return sql.ExecuteSPDataTable("MANTENIMIENTOPC02");

        }

        public static DataTable getVerificaExisteMantRegistrado(string codigo, string serie, int op)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@act_codbarras", SqlDbType.VarChar, codigo);
            sql.AddParameter("@act_serie1", SqlDbType.VarChar, serie);
            sql.AddParameter("@OP", SqlDbType.Int, op);

            return sql.ExecuteSPDataTable("MANTENIMIENTOPC03");

        }

        public static void insMantenimiento(string MAN_DESCRIPCION, int TIP_ID_CORRECTIVO, int TIP_ID_PREVENTIVO, string USERNAME, DateTime MAN_FECHA,
            int ACT_ID, int MAN_REALIZADO, DateTime MAN_FECHAPROXINI, double MAN_VALOR, string MAN_NUMDOC, string MAN_FORMA, int MAN_COBERTURA,
            string MAN_MODALIDAD, string MAN_PORMESES, string MAN_ESTADO, DateTime MAN_FECHAPROXFIN, DateTime MAN_FECHAREALMANT, string ACT_ESTADOMANT,
             DateTime ACT_FECHAENVIOMANT, DateTime ACT_FECHAREGRESOMANT, DateTime MAN_FECHAINICIA
            )
        {

            Datos.SqlService sql = new Datos.SqlService();


            sql.AddParameter("@TIP_ID_PREVENTIVO", SqlDbType.Int, TIP_ID_PREVENTIVO);


            //if (MAN_FECHAPROXINI == Convert.ToDateTime("1900-01-01"))
            //{
            //    sql.AddParameter("@MAN_FECHAPROXINI", SqlDbType.SmallDateTime, System.Data.SqlTypes.SqlDateTime.Null);
            //}
            //else
            //{
            sql.AddParameter("@MAN_FECHAPROXINI", SqlDbType.SmallDateTime, MAN_FECHAPROXINI);
            //}

            //if (MAN_FECHAPROXFIN == Convert.ToDateTime("1900-01-01"))
            //{
            //    sql.AddParameter("@MAN_FECHAPROXFIN", SqlDbType.SmallDateTime, System.Data.SqlTypes.SqlDateTime.Null);
            //}
            //else
            //{
            sql.AddParameter("@MAN_FECHAPROXFIN", SqlDbType.SmallDateTime, MAN_FECHAPROXFIN);
            //}

            //if (MAN_FECHAREALMANT == Convert.ToDateTime("1900-01-01"))
            //{
            //    sql.AddParameter("@MAN_FECHAREALMANT", SqlDbType.SmallDateTime, System.Data.SqlTypes.SqlDateTime.Null);
            //}
            //else
            //{
            sql.AddParameter("@MAN_FECHAREALMANT", SqlDbType.SmallDateTime, MAN_FECHAREALMANT);
            //}

            sql.AddParameter("@MAN_DESCRIPCION", SqlDbType.VarChar, MAN_DESCRIPCION);
            sql.AddParameter("@TIP_ID_CORRECTIVO", SqlDbType.Int, TIP_ID_CORRECTIVO);
            sql.AddParameter("@USERNAME", SqlDbType.VarChar, USERNAME);
            sql.AddParameter("@MAN_FECHA", SqlDbType.SmallDateTime, MAN_FECHA);
            sql.AddParameter("@ACT_ID", SqlDbType.Int, ACT_ID);
            sql.AddParameter("@MAN_REALIZADO", SqlDbType.Int, MAN_REALIZADO);
            sql.AddParameter("@MAN_VALOR", SqlDbType.VarChar, MAN_VALOR);
            sql.AddParameter("@MAN_NUMDOC", SqlDbType.Decimal, MAN_NUMDOC);
            //if (MAN_FORMA == "")
            //{
            //    sql.AddParameter("@MAN_FORMA", SqlDbType.VarChar, System.Data.SqlTypes.SqlDateTime.Null);
            //}
            //else
            //{
            sql.AddParameter("@MAN_FORMA", SqlDbType.VarChar, MAN_FORMA);
            //}

            //if (MAN_COBERTURA == 0)
            //{
            //    sql.AddParameter("@MAN_COBERTURA", SqlDbType.VarChar, System.Data.SqlTypes.SqlDateTime.Null);
            //}
            //else
            //{

            sql.AddParameter("@MAN_COBERTURA", SqlDbType.Int, MAN_COBERTURA);
            //}

            //if (MAN_MODALIDAD == "")
            //{
            //    sql.AddParameter("@MAN_MODALIDAD", SqlDbType.VarChar, System.Data.SqlTypes.SqlDateTime.Null);
            //}
            //else
            //{
            sql.AddParameter("@MAN_MODALIDAD", SqlDbType.VarChar, MAN_MODALIDAD);
            //}

            //if (MAN_PORMESES == "")
            //{
            //    sql.AddParameter("@MAN_PORMESES", SqlDbType.VarChar, System.Data.SqlTypes.SqlDateTime.Null);
            //}
            //else
            //{
            sql.AddParameter("@MAN_PORMESES", SqlDbType.VarChar, MAN_PORMESES);
            //}
            sql.AddParameter("@MAN_ESTADO", SqlDbType.VarChar, MAN_ESTADO);
            sql.AddParameter("@ACT_ESTADOMANT", SqlDbType.VarChar, MAN_FECHAREALMANT);

            //if (ACT_FECHAENVIOMANT == null)
            //{
            //    sql.AddParameter("@ACT_FECHAENVIOMANT", SqlDbType.SmallDateTime, System.Data.SqlTypes.SqlDateTime.Null);
            //}
            //else
            //{
            sql.AddParameter("@ACT_FECHAENVIOMANT", SqlDbType.SmallDateTime, ACT_FECHAENVIOMANT);
            //}

            //if (ACT_FECHAREGRESOMANT == null)
            //{
            //    sql.AddParameter("@ACT_FECHAREGRESOMANT", SqlDbType.SmallDateTime, System.Data.SqlTypes.SqlDateTime.Null);
            //}
            //else
            //{
            sql.AddParameter("@ACT_FECHAREGRESOMANT", SqlDbType.SmallDateTime, ACT_FECHAREGRESOMANT);
            //}
            sql.AddParameter("@MAN_FECHAINICIA", SqlDbType.SmallDateTime, MAN_FECHAINICIA);


            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
            sql.ExecuteSP("MANTENIMIENTOPI01");
        }


        public static void insMantenimientoIniPrevent(string MAN_DESCRIPCION, int TIP_ID_CORRECTIVO, int TIP_ID_PREVENTIVO, string USERNAME, DateTime MAN_FECHA,
           int ACT_ID, int MAN_REALIZADO, DateTime MAN_FECHAPROXINI, double MAN_VALOR, string MAN_NUMDOC, string MAN_FORMA, int MAN_COBERTURA,
           string MAN_MODALIDAD, string MAN_PORMESES, string MAN_ESTADO, DateTime MAN_FECHAPROXFIN, DateTime MAN_FECHAREALMANT, int ACT_DIASAVISOMANTPREVENTIVO, DateTime MAN_FECHAINICIA
           )
        {

            Datos.SqlService sql = new Datos.SqlService();


            sql.AddParameter("@TIP_ID_PREVENTIVO", SqlDbType.Int, TIP_ID_PREVENTIVO);



            sql.AddParameter("@MAN_FECHAPROXINI", SqlDbType.SmallDateTime, MAN_FECHAPROXINI);

            sql.AddParameter("@MAN_FECHAPROXFIN", SqlDbType.SmallDateTime, MAN_FECHAPROXFIN);

            sql.AddParameter("@MAN_FECHAREALMANT", SqlDbType.SmallDateTime, MAN_FECHAREALMANT);
            //}

            sql.AddParameter("@MAN_DESCRIPCION", SqlDbType.VarChar, MAN_DESCRIPCION);
            sql.AddParameter("@TIP_ID_CORRECTIVO", SqlDbType.Int, TIP_ID_CORRECTIVO);
            sql.AddParameter("@USERNAME", SqlDbType.VarChar, USERNAME);
            sql.AddParameter("@MAN_FECHA", SqlDbType.SmallDateTime, MAN_FECHA);
            sql.AddParameter("@ACT_ID", SqlDbType.Int, ACT_ID);
            sql.AddParameter("@MAN_REALIZADO", SqlDbType.Int, MAN_REALIZADO);
            sql.AddParameter("@MAN_VALOR", SqlDbType.VarChar, MAN_VALOR);
            sql.AddParameter("@MAN_NUMDOC", SqlDbType.Decimal, MAN_NUMDOC);

            sql.AddParameter("@MAN_FORMA", SqlDbType.VarChar, MAN_FORMA);


            sql.AddParameter("@MAN_COBERTURA", SqlDbType.Int, MAN_COBERTURA);

            sql.AddParameter("@MAN_MODALIDAD", SqlDbType.VarChar, MAN_MODALIDAD);

            sql.AddParameter("@MAN_PORMESES", SqlDbType.VarChar, MAN_PORMESES);
            //}
            sql.AddParameter("@MAN_ESTADO", SqlDbType.VarChar, MAN_ESTADO);
            sql.AddParameter("@ACT_DIASAVISOMANTPREVENTIVO", SqlDbType.Int, ACT_DIASAVISOMANTPREVENTIVO);
            sql.AddParameter("@MAN_FECHAINICIA", SqlDbType.SmallDateTime, MAN_FECHAINICIA);


            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
            sql.ExecuteSP("MANTENIMIENTOPI02");
        }
        public static string VerificaDepreciaciones(int cod, string msg)
        {
            Datos.SqlService sql = new Datos.SqlService();
            DataTable dt = new DataTable();

            sql.AddParameter("@ACT_ID", SqlDbType.Int, cod);
            dt = sql.ExecuteSPDataTable("ACTIVOPC05");

            if (dt.Rows.Count > 0)
            {
                msg = "iok";
            }
            else
            {
                msg = "0";
            }

            return msg;

        }

        public static string getVerificador(string cb6, int td)
        {
            if (td == 14)
            {
                decimal pares = 0;
                decimal impares = 0;
                decimal digito = 0;
                string[] astr = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };

                //NO TOMA EN CUENTA EL 8004        
                for (int j = 4; j < cb6.Length; j++)
                {
                    astr[j] = cb6.Substring(j, 1);
                    if (j % 2 == 0)
                    {
                        if (astr[j] != "")
                        {
                            pares = pares + System.Convert.ToDecimal(astr[j]);
                        }
                    }
                    else
                        if (j < cb6.Length - 1)
                    {
                        impares = impares + System.Convert.ToDecimal(astr[j]);
                    }
                }
                pares = pares * 3;
                digito = 1000 - (pares + impares);

                return cb6 + digito.ToString().Substring(2, 1);
            }
            else
            {
                decimal pares = 0;
                decimal impares = 0;
                decimal digito = 0;

                char[] cbarr = cb6.ToCharArray(4, 15);

                // Array.Reverse(cbarr);

                for (int j = 0; j < cbarr.Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        pares = pares + System.Convert.ToInt32(cbarr[j].ToString());
                    }
                    else
                    {
                        impares = impares + System.Convert.ToInt32(cbarr[j].ToString());
                    }
                }
                pares = pares * 3;
                digito = 1000 - (pares + impares);
                return cb6 + digito.ToString().Substring(2, 1);
            }
        }

        public static void insCodImpreso(string secuencial, string verificador, string prefijo, string sufijo, string empresa)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSqlDataTable("insert into codigo (emp_id, cod_prefijo, cod_sufijo, cod_secuencial, cod_verificador) values ('" + empresa + "','" + prefijo + "','" + sufijo + "'," + secuencial + "," + verificador + ")");
        }

        public static void insCaracteristicas(string nombre)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSqlDataTable("insert into ccar (cca_nombre) values ('" + nombre + "')");
        }

        public static void updOrdenCar(int cfaid, int orden)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSqlDataTable("update cfamilia set cfa_orden=" + orden + " where cfa_id=" + cfaid);
        }

        public static void insCaracteristicasCfa(string nombre, int gruid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSqlDataTable("insert into cfamilia (cfa_nombre,gru_id, cfa_orden) values ('" + nombre + "', " + gruid + "," + getNextCfaOrden(gruid) + ")");
        }

        public static void delCaracteristicasCfa(int cfaid, int gruid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSqlDataTable("delete from cfamilia where cfa_id='" + cfaid + "' and gru_id=" + gruid);
        }

        public static int getNextCfaOrden(int gruid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select max(cfa_orden)+1 from cfamilia where gru_id=" + gruid);

            if (obj.ToString() == "")
                return 1;
            else
                return int.Parse(obj.ToString());
        }

        public static bool comprobarCarCfa(int cfaid, int gruid)
        {
            Datos.SqlService sql = new Datos.SqlService();

            Object obj = sql.ExecuteSqlObject("select cfa_id from caracteristica where cfa_id=" + cfaid);
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void checkUnidades(string nombre, int gruid, int check)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("update cfamilia set cfa_unidades=" + check + " where cfa_nombre='" + nombre + "' and gru_id=" + gruid);
        }

        public static void checkCustodios(int cusid, int uorid, int check)
        {
            Datos.SqlService sql = new Datos.SqlService();
            if (check == 0)
            {
                sql.ExecuteSql("delete from xcuor where uor_id=" + uorid + " and cus_id=" + cusid);
            }
            else
            {
                sql.ExecuteSql("insert into xcuor (cus_id, uor_id) values (" + cusid + "," + uorid + ")");
            }
        }

        public static void insHCodImpreso(string usuario, string tipo, string cod1, string cod2, string numcod)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSqlDataTable("insert into hcodigo (hco_usuario, hco_tipo, hco_cod1, hco_cod2, hco_numero) values ('" + usuario + "','" + tipo + "','" + cod1 + "','" + cod2 + "'," + numcod + ")");
        }

        public static string iniTransfer(int actid, string username, int geo1, int geo2, int geo3, int geo4, int uor1, int uor2, int uor3, int cus, int estado1, int estado2, int estado3, string estadoMant)
        {
            string error = "";

            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@actid", SqlDbType.Int, actid);
            sql.AddParameter("@user", SqlDbType.VarChar, username);
            sql.AddParameter("@geo1", SqlDbType.Int, geo1);
            sql.AddParameter("@geo2", SqlDbType.Int, geo2);
            sql.AddParameter("@geo3", SqlDbType.Int, geo3);
            sql.AddParameter("@geo4", SqlDbType.Int, geo4);
            sql.AddParameter("@uor1", SqlDbType.Int, uor1);
            sql.AddParameter("@uor2", SqlDbType.Int, uor2);
            sql.AddParameter("@uor3", SqlDbType.Int, uor3);
            sql.AddParameter("@cus1", SqlDbType.Int, cus);
            sql.AddParameter("@cus2", SqlDbType.Int, 0);
            sql.AddParameter("@est1", SqlDbType.Int, estado1);
            sql.AddParameter("@est2", SqlDbType.Int, estado2);
            sql.AddParameter("@est3", SqlDbType.Int, estado3);
            sql.AddParameter("@estman", SqlDbType.VarChar, estadoMant);
            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);

            sql.ExecuteSPDataTable("usp_IniTransferACTIVO");
            error = sql.Parameters["@err"].Value.ToString();
            return error;
        }

        public static void asignarPpc(string actid, string ppc)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSqlDataTable("update activo set act_ppc=" + ppc + " where act_id=" + actid);
        }

        public static void borrarAsignacionPpc(string actid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSqlDataTable("update activo set act_ppc=null where act_id=" + actid);
        }

        public static void backbdd(string ruta)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@ruta", SqlDbType.VarChar, ruta);
            sql.AddParameter("@base", SqlDbType.VarChar, ConfigurationManager.AppSettings["nbase"]);
            sql.ExecuteSP("usp_BackupBddALL");
        }

        public static bool comprobarCarIng(string car)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select cca_nombre from ccar where cca_nombre='" + car + "'");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void updCar(string nombre, int id, string oldname)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("update ccar set cca_nombre='" + nombre + "' where cca_id=" + id);
            sql.ExecuteSql("update cfamilia set cfa_nombre='" + nombre + "' where cfa_nombre='" + oldname + "'");
        }

        public static void delCar(int id)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("delete from ccar where cca_id=" + id);
        }

        public static bool comprobarCarCfamilia(string car)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select cfa_nombre from cfamilia where cfa_nombre='" + car + "'");
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string capitalize(string car)
        {
            car = car.Trim();
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"[ ]{2,}", options);
            car = regex.Replace(car, @" ");

            string[] cadena = car.Split(' ');

            for (int i = 0; i < cadena.Length; i++)
            {
                if ((cadena[i].ToLower() == "de" ||
                    cadena[i].ToLower() == "y" ||
                    cadena[i].ToLower() == "la" ||
                    cadena[i].ToLower() == "con" ||
                    cadena[i].ToLower() == "para" ||
                    cadena[i].ToLower() == "a" ||
                    cadena[i].ToLower() == "el" ||
                    cadena[i].ToLower() == "los" ||
                    cadena[i].ToLower() == "lo" ||
                    cadena[i].ToLower() == "por" ||
                    cadena[i].ToLower() == "las" ||
                    cadena[i].ToLower() == "son" ||
                    cadena[i].ToLower() == "que" ||
                    cadena[i].ToLower() == "es" ||
                    cadena[i].ToLower() == "del" ||
                    cadena[i].ToLower() == "sin") && i > 0
                    )
                {
                    cadena[i] = cadena[i].ToLower();
                }
                else
                {
                    cadena[i] = cadena[i].Substring(0, 1).ToUpper() + cadena[i].Substring(1, cadena[i].Length - 1).ToLower();
                }
            }
            return String.Join(" ", cadena).Trim();
        }

        public static Boolean valRelCustodio(int cusid, int uorid)
        {
            Boolean hayrel = false;

            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where cus_id1=" + cusid + " and uor_id2=" + uorid);
            if (obj != null)
                hayrel = true;
            return hayrel;
        }

        public static Boolean valRelCustodioH(int cusid, int uorid)
        {
            Boolean hayrel = false;

            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select huc_id from hucustodio where cus_id1=" + cusid + " and uor_id2=" + uorid);
            if (obj != null)
                hayrel = true;
            return hayrel;
        }

        public static Boolean valRelCustodio(int cusid)
        {
            Boolean hayrel = false;

            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where cus_id1=" + cusid);
            if (obj != null)
                hayrel = true;
            return hayrel;
        }

        public static Boolean valRelCustodioH(int cusid)
        {
            Boolean hayrel = false;

            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select huc_id from hucustodio where cus_id1=" + cusid);
            if (obj != null)
                hayrel = true;
            return hayrel;
        }

        public static DataTable getTraslados(string actid, string tipo)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@cb", SqlDbType.VarChar, actid);
            sql.AddParameter("@tipo", SqlDbType.VarChar, tipo);
            return sql.ExecuteSPDataTable("usp_getReporteTransfer");
        }

        public static DataTable getMantenimiento(string idcod, string tipo)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@idcod", SqlDbType.VarChar, idcod);
            sql.AddParameter("@tipo", SqlDbType.VarChar, tipo);
            return sql.ExecuteSPDataTable("usp_getReporteMantenimiento");
        }

        public static string getNextPeriodoDepre()
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select convert(varchar(10),max(dge_siguiente),103) from dgenerada");
            return obj.ToString();
        }

        public static DataTable getPreDepreNiif()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSPDataTable("usp_getPreDepreNiif");
        }

        public static DataTable getPreDepre(string actid, string tipodepre)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("SELECT TOP 1 DEP_VIDAUTIL,DEP_VALORRESIDUAL,DEP_SALDOXDEPRE,DEP_DEPREACUM,DEP_PERTRANS,DEP_PERREMA,DEP_DEPREPERIODO, DEP_FECHAPROX FROM DEPRECIACION where DEP_TIPO='" + tipodepre + "' and ACT_ID=" + actid + " ORDER BY DEP_PERTRANS DESC");
        }

        public static DateTime getMesDepre(string tipo)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj;
            if (tipo == "NIIF")
                obj = sql.ExecuteSqlString("select TOP 1 CONVERT(VARCHAR(10),DGE_SIGUIENTE,103) from DGENERADA where dGE_tipo='" + tipo + "' ORDER BY DGE_SIGUIENTE DESC");
            else
                obj = sql.ExecuteSqlString("select TOP 1 CONVERT(VARCHAR(10),DGE_SIGUIENTE,103) from DGENERADASRI where dGE_tipo='" + tipo + "' ORDER BY DGE_SIGUIENTE DESC");

            return DateTime.ParseExact(obj.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture); //Convert.ToDateTime(obj.ToString());
        }

        public static DataTable getMesDepre2(string tipo)
        {
            Datos.SqlService sql = new Datos.SqlService();
            if (tipo == "NIIF")
                return sql.ExecuteSqlDataTable("select distinCt CONVERT(VARCHAR(10),DGE_GENERADA,103), dge_id from DGENERADA where dGE_tipo='" + tipo + "' ORDER BY dge_id");
            else
                return sql.ExecuteSqlDataTable("select distinCt CONVERT(VARCHAR(10),DGE_GENERADA,103), dge_id from DGENERADASRI where dGE_tipo='" + tipo + "' ORDER BY dge_id");

        }

        public static DataTable getDepreIndiv(string tipo, string ide)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("rom DGENERADA where dGE_tipo='" + tipo + "' ORDER BY CONVERT(VARCHAR(10),DGE_GENERADA,103) ASC");
        }

        public static void insNextDepre(DateTime d1, DateTime d2, string tipo)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("insert into dgenerada (dge_generada, dge_siguiente, dge_tipo) values ('" + d1 + "','" + d2 + "','" + tipo + "')");
        }

        public static void insDepreciacion(DateTime d1, string tipo, string usuario)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@fecha", SqlDbType.SmallDateTime, d1);
            sql.AddParameter("@user", SqlDbType.VarChar, usuario);
            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
            if (tipo == "NIIF")
                sql.ExecuteSP("usp_insDepreGeneradaNiif");
            else
                sql.ExecuteSP("usp_insDepreGeneradaTribu");
        }

        public static void insErrorLogin(string apli, string user, string pass, string ip)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@ApplicationName", SqlDbType.VarChar, apli);
            sql.AddParameter("@UserName", SqlDbType.VarChar, user);
            sql.AddParameter("@Password", SqlDbType.VarChar, pass);
            sql.AddParameter("@IPAddress", SqlDbType.VarChar, ip);
            sql.ExecuteSP("usp_ErrorLogin");
        }

        public static DataTable getReporteTotalX(string where)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@where", SqlDbType.VarChar, where);
            return sql.ExecuteSPDataTable("usp_ReporteGlobalACTIVO");
        }

        public static DataTable getReporteGlobalTras(string where)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@where", SqlDbType.VarChar, where);
            return sql.ExecuteSPDataTable("usp_ReporteGlobalTrasACTIVO");
        }

        public static DataTable getReporteGlobal(DateTime desde, DateTime hasta)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@DESDE", SqlDbType.SmallDateTime, desde);
            sql.AddParameter("@HASTA", SqlDbType.SmallDateTime, hasta);
            return sql.ExecuteSPDataTable("usp_GetReporteGlobalAval");
        }

        //2012-02-29 Andrea.- Reporte de activos custodio para exportar a Pdf
        public static DataTable getReporteActivosPdf(string where, int op)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@op", SqlDbType.Int, op);
            sql.AddParameter("@where", SqlDbType.VarChar, where);
            return sql.ExecuteSPDataTable("usp_ReporteACTIVOPdf");
        }

        public static DataTable getReporteInventarioMovilWeb(int op)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@OP", SqlDbType.Int, op);
            //return sql.ExecuteSPDataTable("usp_ReporteACTIVOPdf");
            return sql.ExecuteSPDataTable("REPORTEMOVILPC01");

        }

        //dice
        public static string getNombreCustodio(string ultimatix)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select isnull(cus_apellidos,'') + ' ' + isnull(cus_nombres, '') from custodio where cus_ultimatix = '" + ultimatix + "'");

            if (obj == null || obj == "")
            {
                return "";

            }
            else
            {
                return obj.ToString();
            }

        }

        //dice
        public static string getCodigoCustodio(string ultimatix)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select cus_id from custodio where cus_id = '" + ultimatix + "'");

            if (obj == null || obj == "")
            {
                return "";

            }
            else
            {
                return obj.ToString();
            }


        }

        public static int getTotalActivosBase()
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select count(act_id) from activo");
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
        }

        public static int getDifDepreBaja(string actid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select max (dep_fechaprox) from depreciacion where act_id=" + actid);

            if (obj != null)
            {
                DateTime oldDate = Convert.ToDateTime(obj);
                DateTime newDate = DateTime.Now;
                TimeSpan ts = newDate - oldDate;
                int meses = (newDate.Month - oldDate.Month);
                int años = (newDate.Year - oldDate.Year);
                return meses + (años * 12);
            }
            else
            {
                return 0;
            }
        }

        public static int getDifDepreBajaTribu(string actid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select max (dep_fechaprox) from depreciacionsri where act_id=" + actid);

            if (obj != null)
            {
                DateTime oldDate = Convert.ToDateTime(obj);
                DateTime newDate = DateTime.Now;
                TimeSpan ts = newDate - oldDate;
                int meses = (newDate.Month - oldDate.Month);
                return meses;
            }
            else
            {
                return 0;
            }
        }

        //SABER SI HAY UNA DEPRECIACION EN PROCEDIMIENTO O COLGADA
        public static string getEstadoDepreciacion(string tipo)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj;
            if (tipo == "NIIF")
                obj = sql.ExecuteSqlObject("select par_valor from parametros where par_nombre='PROCESODEPRE'");
            else
                obj = sql.ExecuteSqlObject("select par_valor from parametros where par_nombre='PROCESODEPRESRI'");

            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "ERROR";
            }
        }

        public static DataTable getAñoDepre2(string tipo)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select distinCt CONVERT(VARCHAR(10),DGE_GENERADA,103), dge_id from DGENERADA where dGE_tipo='" + tipo + "' and month(DGE_GENERADA)=12 ORDER BY dge_id");
        }

        public static string getEstadoDepreciacion()
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select par_valor from parametros where par_nombre='PROCESODEPRE'");
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "ERROR";
            }
        }
        public static DataTable getIdDescripcion(string cb)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select act_id as id, gru_nombre as grupo from ACTIVO inner join GRUPO on grupo.GRU_ID=activo.GRU_ID3 where ACT_CODBARRAS='" + cb + "'");
        }

        public static void insBaja(int id, string tipo, string user, int tipobaja, string obsbaja)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@ACT_ID", SqlDbType.Int, id);
            sql.AddParameter("@ACT_TIPO", SqlDbType.VarChar, tipo);
            sql.AddParameter("@USERNAME", SqlDbType.VarChar, user);
            sql.AddParameter("@ACT_FECHABAJA", SqlDbType.SmallDateTime, DateTime.Now);
            sql.AddParameter("@ACT_TIPOBAJA", SqlDbType.Int, tipobaja);
            sql.AddParameter("@ACT_OBSBAJA", SqlDbType.VarChar, obsbaja);
            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
            sql.ExecuteSP("usp_BajaACTIVO");
        }
        //Andrea.- 2012-04-03 Reporte Estructura-Componente
        public static DataTable getActivosPadre()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select act_id as id,act_codbarras, g1.gru_nombre, act_valorcompra, act_codbarraspadre from (activo LEFT JOIN grupo as g1 ON activo.gru_id3=g1.gru_id )");

        }

        //ANDREA.- 2012-04-04 ENVÍO DE MAIL POR CUSTODIO
        public static string getMailCustodio(string Cus_ID)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select cus_email from custodio where cus_id='" + Cus_ID + "'");
            if (obj == null)
                return Cus_ID + ".1";
            else
                return obj.ToString();
        }

        //APROBADORES
        public static bool compruebaAprobadorGrupo(string uuid, int tipo, int gruId)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select USER_ID from APROBADORES_X_GRUPO where USER_ID='" + uuid + "' and APRGRU_TIPO=" + tipo + " and GRU_ID=" +
                                              gruId + "");
            if (obj != null)
            {
                return true;
            }

            return false;
        }
        public static void insAprobadorGrupo(string uuid, int tipo, int gruId)
        {
            int orden = compruebaOrdenGrupo(tipo, gruId);
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("Insert into APROBADORES_X_GRUPO values(" + orden + ", '" + uuid + "'," + tipo + ", " + gruId + ")");
        }
        public static DataTable getAprobadoresGrupos(int tipo, int gruId)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable(
                "select APR_ID, UserName FROM APROBADORES_X_GRUPO inner join aspnet_Users aU on aU.UserId = APROBADORES_X_GRUPO.USER_ID WHERE " +
                " APRGRU_TIPO=" + tipo + "  and GRU_ID=" + gruId + " ORDER BY APRGRU_ORDEN, UserName");
        }
        public static int compruebaOrdenGrupo(int tipo, int gruId)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select max(APRGRU_ORDEN) + 1 from APROBADORES_X_GRUPO where APRGRU_TIPO=" + tipo + " and GRU_ID = " + gruId);
            if (obj != null && obj.ToString() != "")
            {
                return Int32.Parse(obj.ToString());
            }

            return 0;
        }
        public static void updAprobadorGrupo(string uuid, int aprid, int orden)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("update APROBADORES_X_GRUPO set USER_ID='" + uuid + "', APRGRU_ORDEN=" + orden + " where APR_ID=" + aprid);
        }
        public static DataTable getAprobadorGrupo(int id)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("Select * from APROBADORES_X_GRUPO where APR_ID=" + id);
        }
        public static string getUsuario(string userName)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select UserId from aspnet_Users where UserName='" + userName + "'");
            if (obj != null)
            {
                return obj.ToString();
            }

            return null;
        }
        public static void delAprobadorGrupo(int aprid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("delete from APROBADORES_X_GRUPO where APR_ID=" + aprid);
        }
        public static string getCodigoGrupo(string gruid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select GRU_CODIGO from GRUPO where gru_id=" + gruid);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }

        public static bool creaTransfer(int actid, string username, int geo1, int geo2, int geo3, int geo4, int uor1, int uor2, int uor3, int cus, int estado1,
          int estado2, int estado3, string estadoMant, Guid guid, int multiple)
        {
            string error = "";
            bool procesado = false;
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@actid", SqlDbType.Int, actid);
            sql.AddParameter("@user", SqlDbType.VarChar, username);
            sql.AddParameter("@geo1", SqlDbType.Int, geo1);
            sql.AddParameter("@geo2", SqlDbType.Int, geo2);
            sql.AddParameter("@geo3", SqlDbType.Int, geo3);
            sql.AddParameter("@geo4", SqlDbType.Int, geo4);
            sql.AddParameter("@uor1", SqlDbType.Int, uor1);
            sql.AddParameter("@uor2", SqlDbType.Int, uor2);
            sql.AddParameter("@uor3", SqlDbType.Int, uor3);
            sql.AddParameter("@cus1", SqlDbType.Int, cus);
            sql.AddParameter("@cus2", SqlDbType.Int, 0);
            sql.AddParameter("@est1", SqlDbType.Int, estado1);
            sql.AddParameter("@est2", SqlDbType.Int, estado2);
            sql.AddParameter("@est3", SqlDbType.Int, estado3);
            sql.AddParameter("@estman", SqlDbType.VarChar, estadoMant);
            sql.AddParameter("@ACT_FECHABAJA", SqlDbType.DateTime, DateTime.Now);
            sql.AddParameter("@ACT_UUID", SqlDbType.UniqueIdentifier, guid);
            sql.AddParameter("@MULTIPLE", SqlDbType.Int, multiple);
            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
            sql.AddParameter("@procesado", SqlDbType.Bit, "", 1, ParameterDirection.Output);

            sql.ExecuteSPDataTable("usp_CreateTransferACTIVO");
            error = sql.Parameters["@err"].Value.ToString();
            procesado = bool.Parse(sql.Parameters["@procesado"].Value.ToString());
            return procesado;
        }
        public static DataTable GetPendientesTraslado(string user_id)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable(
                "SELECT APB.ACTTRA_ID, APB.ACT_ID AS 'ACT ID', A.ACT_CODBARRAS AS 'COD. BARRAS', U.UGE_NOMBRE AS 'UGE 1' , U2.UGE_NOMBRE AS 'UGE 2', U3.UGE_NOMBRE AS 'UGE 3', U4.UGE_NOMBRE AS 'UGE 4'," +
                " U5.UOR_NOMBRE AS 'UOR 1', U6.UOR_NOMBRE AS 'UOR 2', U7.UOR_NOMBRE AS 'UOR 3', CONCAT(C.CUS_APELLIDOS, ' ', C.CUS_NOMBRES) AS 'CUSTODIO', E1.EST_NOMBRE AS 'ESTADO', E2.EST_NOMBRE AS 'FASE'," +
                " E3.EST_NOMBRE AS 'TRASNFERENCIA', APB.USERNAME AS 'CREADO POR', APB.ACT_FECHABAJA AS 'FECHA CREACION', APB.ACTTRA_UUID, ACTTRA_PROCESADO, AAB.APRACT_PROCESADO AS 'PROCESADO', AAB.APRACT_APROBADO AS 'APROBADO', AAB.APRACT_SIGUIENTE, AAB.APRACT_ID " +
                " FROM ACTIVOS_PARA_TRASLADO APB INNER JOIN ACTIVO A on A.ACT_ID = APB.ACT_ID INNER JOIN APROBACION_ACTIVOS_TRASLADO AAB on APB.ACTTRA_ID = AAB.ACTTRA_ID " +
                " INNER JOIN ESTADO E1 on APB.EST_ID1 = E1.EST_ID INNER JOIN UGEOGRAFICA U on APB.UBI_GEO1 = U.UGE_ID INNER JOIN UGEOGRAFICA U2" +
                " ON APB.UBI_GEO2=U2.UGE_ID INNER JOIN UGEOGRAFICA U3 on U3.UGE_ID = APB.UBI_GEO3 INNER JOIN UGEOGRAFICA U4 on U4.UGE_ID = APB.UBI_GEO4" +
                " INNER JOIN UORGANICA U5 on U5.UOR_ID = APB.UBI_ORG1 INNER JOIN UORGANICA U6 on U6.UOR_ID = APB.UBI_ORG2 INNER JOIN UORGANICA U7 on U7.UOR_ID = APB.UBI_ORG3" +
                " INNER JOIN ESTADO E2 on APB.EST_ID2 = E2.EST_ID INNER JOIN ESTADO E3 on APB.EST_ID3 = E3.EST_ID INNER JOIN CUSTODIO C on APB.CUS_ID1 = C.CUS_ID WHERE AAB.APRACT_SIGUIENTE = 1 AND AAB.USER_ID='" +
                user_id + "'  AND A.ACT_TIPOBAJA IS  NULL");
            //APB.ACTTRA_PROCESADO=0
            //AAB.APRACT_SIGUIENTE = 1
        }
        public static bool AprobarRechazarTraslados(int apractId, int aprobado, int acttraId)
        {
            bool procesado = false;
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@APRACT_ID", SqlDbType.Int, apractId);
            sql.AddParameter("@APROBADO", SqlDbType.Int, aprobado);
            sql.AddParameter("@ACTTRA_ID", SqlDbType.Int, acttraId);
            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
            sql.AddParameter("@procesado", SqlDbType.Bit, 0, 1, ParameterDirection.Output);

            sql.ExecuteSP("usp_AprobarRechazarTrasladoACTIVO");

            procesado = bool.Parse(sql.Parameters["@procesado"].Value.ToString());
            return procesado;
        }
        public static bool CompletaTraslados(Guid uuid)
        {
            bool procesado = false;
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@UUID", SqlDbType.UniqueIdentifier, uuid);
            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
            sql.AddParameter("@procesado", SqlDbType.Bit, 0, 1, ParameterDirection.Output);

            sql.ExecuteSP("usp_CompletaTansferencia");

            procesado = bool.Parse(sql.Parameters["@procesado"].Value.ToString());
            var err = sql.Parameters["@err"].Value.ToString();
            return procesado;
        }
        public static DataTable GetPendientesBaja(string user_id)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable(
                "SELECT APB.ACTBAJ_ID, APB.ACT_ID AS 'ACT ID', APB.ACT_TIPO AS 'TIPO', APB.USERNAME AS 'CREADO POR', APB.ACT_FECHABAJA AS 'FECHA BAJA', E.EST_NOMBRE AS 'TIPO BAJA', APB.ACT_OBSBAJA AS 'OBSERVACION', APB.ACTBAJ_UUID, ACTBAJ_PROCESADO,A.ACT_CODBARRAS AS 'COD. BARRAS', AAB.APRACT_PROCESADO AS 'PROCESADO', AAB.APRACT_APROBADO AS 'APROBADO', AAB.APRACT_SIGUIENTE, AAB.APRACT_ID " +
                " FROM ACTIVOS_PARA_BAJA APB INNER JOIN ACTIVO A on A.ACT_ID = APB.ACT_ID INNER JOIN APROBACION_ACTIVOS_BAJA AAB on APB.ACTBAJ_ID = AAB.ACTBAJ_ID " +
                " INNER JOIN ESTADO E on APB.ACT_TIPOBAJA = E.EST_ID" +
                " WHERE APB.ACTBAJ_PROCESADO=0 AND AAB.USER_ID='" + user_id + "'");
        }
        public static bool AprobarRechazarBajas(int apractId, int aprobado, int actbajId, string archivo)
        {
            bool procesado = false;
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@APRACT_ID", SqlDbType.Int, apractId);
            sql.AddParameter("@APROBADO", SqlDbType.Int, aprobado);
            sql.AddParameter("@ACTBAJ_ID", SqlDbType.Int, actbajId);
            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
            sql.AddParameter("@procesado", SqlDbType.Bit, 0, 1, ParameterDirection.Output);
            sql.AddParameter("@APRACT_ARCHIVO", SqlDbType.NVarChar, archivo);

            sql.ExecuteSP("usp_AprobarRechazarBajaACTIVO");

            procesado = bool.Parse(sql.Parameters["@procesado"].Value.ToString());
            return procesado;
        }
    }
}

    

