using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de TipoSeguro
/// </summary>
public class TipoSeguro
{
    C5ALIANZAVALLE23102015Entities ent = new C5ALIANZAVALLE23102015Entities();
	public TipoSeguro()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public string Guardar(string nombre)
    {
        TIPO_SEGURO tip = new TIPO_SEGURO();
        string msg = "";

        
            tip.SEG_NOMBRE = nombre.Trim();
            ent.TIPO_SEGURO.Add(tip);

            try
            {
                ent.SaveChanges();
                msg = "ok";
            }
            catch (System.Exception ex)
            {
                msg = ex.Message;
            }
       
        return msg;
    }

    public string Modificar(int cod, string nombre)
    {
        TIPO_SEGURO tip = ent.TIPO_SEGURO.Where(x=>x.SEG_ID == cod).FirstOrDefault();
        string msg = "";

        if (tip != null)
        {
            tip.SEG_NOMBRE = nombre.Trim();
           
            try
            {
                ent.SaveChanges();
                msg = "ok";
            }
            catch (System.Exception ex)
            {
                msg = ex.Message;
            }
        }

        return msg;
    }

    public string Eliminar(int cod)
    {
        TIPO_SEGURO tip = ent.TIPO_SEGURO.Where(x => x.SEG_ID == cod).FirstOrDefault();
        string msg = "";

        if (tip != null)
        {
            ent.TIPO_SEGURO.Remove(tip);
            try
            {
                ent.SaveChanges();
                msg = "ok";
            }
            catch (System.Exception ex)
            {
                msg = ex.Message;
            }
        }

        return msg;
    }
    public List<TIPO_SEGURO> CargarTipoSeguro()
    {
        return ent.TIPO_SEGURO.ToList();
    }

    public bool existeSeguroIng(string seguro)
    {
        TIPO_SEGURO tipseg = ent.TIPO_SEGURO.Where(x => x.SEG_NOMBRE.Trim() == seguro.Trim()).FirstOrDefault();

            if (tipseg!= null)
            {
                return true;
            }
            else
            {
            return false;
            }
    }

    public Boolean valRelActivo(int ide)
    {
        Boolean hayrel = false;

        Datos.SqlService sql = new Datos.SqlService();
        ACTIVO act = ent.ACTIVO.Where(x => x.ACT_TIPOSEGURO == ide).FirstOrDefault();

        if (act != null)
        {
            hayrel = true;
            return hayrel;
        }

        return hayrel;
    }
}