using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Logica
{
    public class Mantenimiento
    {
        public bool verificaSiMantPreventivo(string ide)
        {
            bool siPrevent = false;

            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select * from mantenimiento  where act_id = " + ide + " and TIP_ID_PREVENTIVO = 2");

            if (obj != null)
                siPrevent = true;

            return siPrevent;
        }


        public static string ActualizaEstadoMant(string codbarras, string estado, string user, int op, int act_id)
        {
            string error = "";

            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@codbarras", SqlDbType.VarChar, codbarras);
            sql.AddParameter("@username", SqlDbType.VarChar, user);
            sql.AddParameter("@estado", SqlDbType.Char, estado);
            sql.AddParameter("@op", SqlDbType.Int, op);
            sql.AddParameter("@act_cod", SqlDbType.Int, act_id);
            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);

            sql.ExecuteSPDataTable("usp_CambiaEstadoMantActivo");
            error = sql.Parameters["@err"].Value.ToString();
            return error;
        }

        public static string ActualizaEstadoMantMasivo(string codbarras, string estado, string user, string empresa, int op)
        {
            string error = "";

            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@codbarras", SqlDbType.VarChar, codbarras);
            sql.AddParameter("@username", SqlDbType.VarChar, user);
            sql.AddParameter("@estado", SqlDbType.Char, estado);
            sql.AddParameter("@empresa", SqlDbType.Int, empresa);
            sql.AddParameter("@op", SqlDbType.Int, op);
            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);

            sql.ExecuteSPDataTable("usp_CambiaEstadoMantActivo");
            error = sql.Parameters["@err"].Value.ToString();
            return error;
        }

        public static bool verificaMantenimiento(string codigo)
        {
            bool siMant = false;

            Datos.SqlService sql = new Datos.SqlService();
            string obj = sql.ExecuteSqlString("select ACT_CODBARRAS from activo where ACT_CODBARRAS = '" + codigo + "' AND ACT_ESTADOMANT = 'M'");

            if (obj != null)
                siMant = true;

            return siMant;
        }

        public static bool verificaMantenimientoMasivo(string codigo)
        {
            bool siMant = false;

            Datos.SqlService sql = new Datos.SqlService();
            string obj = sql.ExecuteSqlString("select ACT_CODBARRAS from activo where ACT_CODBARRAS = '" + codigo + "' AND ACT_ESTADOMANT = 'M'");

            if (obj != null)
                siMant = true;

            return siMant;
        }

        public static bool verificaMantenimientoporID(string codigo)
        {
            bool siMant = false;

            Datos.SqlService sql = new Datos.SqlService();
            string obj = sql.ExecuteSqlString("select ACT_CODBARRAS from activo where ACT_ID = '" + codigo + "' AND ACT_ESTADOMANT = 'M'");

            if (obj != null)
                siMant = true;

            return siMant;
        }

        public static bool verificaMantenimientoSerie(string codigo)
        {
            bool siMant = false;

            Datos.SqlService sql = new Datos.SqlService();
            string obj = sql.ExecuteSqlString("select ACT_CODBARRAS from activo where ACT_SERIE1 = '" + codigo + "' AND ACT_ESTADOMANT = 'M'");

            if (obj != null)
                siMant = true;

            return siMant;
        }
        public static bool verificaMantenimientoCodigoBNF(string codigo)
        {
            bool siMant = false;

            Datos.SqlService sql = new Datos.SqlService();
            string obj = sql.ExecuteSqlString("select ACT_CODBARRAS from activo where ACT_CODIGO1 = '" + codigo + "' AND ACT_ESTADOMANT = 'M'");

            if (obj != null)
                siMant = true;

            return siMant;
        }
      
    }
}
