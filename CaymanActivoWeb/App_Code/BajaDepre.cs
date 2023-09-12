using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Security;

/// <summary>
/// Descripción breve de Baja
/// </summary>
public class BajaDepre
{
    public BajaDepre()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public DateTime calcularFechaIniDepre(DateTime fechaCompra)
    {
        DateTime fechaComienzoDepre = fechaCompra.Date;

        if (fechaComienzoDepre.Day != 1)
        {   
                while (fechaComienzoDepre.Day != 1)
                {
                    fechaComienzoDepre = fechaComienzoDepre.AddDays(-1);
                }
        }
        
        return fechaComienzoDepre;
    }

    public void ActualizaFechaBajaTblDepre(DateTime fecha, Int64 id)
    {
        Datos.SqlService sql = new Datos.SqlService();

        Int64 ultId = IdUltimaDepreciacion(id);

        sql.ExecuteSql("update DEPRECIACIONSRI set  DEP_FECHABAJA = '" + fecha + "' where DEP_ID = " + ultId);
    }
    public bool insBaja(int id, string tipo, string user, int tipobaja, string obsbaja, Guid act_uuid)
    {
        bool procesado = false;
        Datos.SqlService sql = new Datos.SqlService();
        sql.AddParameter("@ACT_ID", SqlDbType.Int, id);
        sql.AddParameter("@ACT_TIPO", SqlDbType.VarChar, tipo);
        sql.AddParameter("@USERNAME", SqlDbType.VarChar, user);
        sql.AddParameter("@ACT_FECHABAJA", SqlDbType.SmallDateTime, DateTime.Now);

        DateTime FechaTblDepre = calcularFechaIniDepre(DateTime.Now);

        sql.AddParameter("@ACT_TIPOBAJA", SqlDbType.Int, tipobaja);
        sql.AddParameter("@ACT_OBSBAJA", SqlDbType.VarChar, obsbaja);
        sql.AddParameter("@ACT_UUID", SqlDbType.UniqueIdentifier, act_uuid);
        sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
        sql.AddParameter("@procesado", SqlDbType.Bit, 0, 1, ParameterDirection.Output);

        sql.ExecuteSP("usp_CrearBajaACTIVO");

        procesado = bool.Parse(sql.Parameters["@procesado"].Value.ToString());

        if (procesado)
        {
            ActualizaFechaBajaTblDepre(FechaTblDepre, id);
        }

        return procesado;
    }

    public Int64 IdUltimaDepreciacion(Int64 id)
    {

        Datos.SqlService sql = new Datos.SqlService();
        Object obj = sql.ExecuteSqlObject("select top (1) DEP_ID from DEPRECIACIONSRI where ACT_ID = " + id + " order by DEP_ID desc");
        if (obj != null)
        {
            return Int64.Parse(obj.ToString());
        }
        else
        {
            return 0;
        }
    }
    public DataTable GetBajasPendientes()
    {
        return Logica.HELPER.GetPendientesBaja(Membership.GetUser().ProviderUserKey.ToString());
    }
    public bool AprobarRechazar(int APRACT_ID, int APROBADO, int ACTBAJ_ID, int act_Id, string motivoBaja, string motivoBajaDesc, string archivo)
    {
        var procesado = Logica.HELPER.AprobarRechazarBajas(APRACT_ID, APROBADO, ACTBAJ_ID, archivo);
        if (procesado)
        {
            DateTime FechaTblDepre = calcularFechaIniDepre(DateTime.Now);
            ActualizaFechaBajaTblDepre(FechaTblDepre, act_Id);
        }
        return procesado;
    }
}