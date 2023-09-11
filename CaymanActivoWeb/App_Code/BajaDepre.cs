using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

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
    public void insBaja(int id, string tipo, string user, int tipobaja, string obsbaja, ref int ok)
    {
        try
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@ACT_ID", SqlDbType.Int, id);
            sql.AddParameter("@ACT_TIPO", SqlDbType.VarChar, tipo);
            sql.AddParameter("@USERNAME", SqlDbType.VarChar, user);
            sql.AddParameter("@ACT_FECHABAJA", SqlDbType.SmallDateTime, DateTime.Now);

            DateTime FechaTblDepre = calcularFechaIniDepre(DateTime.Now);

            sql.AddParameter("@ACT_TIPOBAJA", SqlDbType.Int, tipobaja);
            sql.AddParameter("@ACT_OBSBAJA", SqlDbType.VarChar, obsbaja);
            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);

            sql.ExecuteSP("usp_BajaACTIVO");

            ActualizaFechaBajaTblDepre(FechaTblDepre, id);

            ok = 1;
        }
        catch (Exception ex)
        {
            ok = 0;
        }
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
  
}