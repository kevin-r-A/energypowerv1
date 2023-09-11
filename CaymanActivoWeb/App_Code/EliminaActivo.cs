using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EliminaActivo
/// </summary>
public class EliminaActivo
{
    C5ALIANZAVALLE23102015Entities ent = new C5ALIANZAVALLE23102015Entities();
	public EliminaActivo()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}


    public bool EliminaActivoId(int id)
    {

        bool tran = false;

        //caracteristica
        var car = ent.CARACTERISTICA.Where(y => y.ACT_ID == id).ToList();
        //depreciacion
        var dep = ent.DEPRECIACION.Where(y => y.ACT_ID == id).ToList();
        //depreciacionsri
        var depsri = ent.DEPRECIACIONSRI.Where(y => y.ACT_ID == id).ToList();
       //mactivo 
        var mactivo = ent.MACTIVO.Where(y => y.ACT_ID == id).ToList();
        //hucustodio
        var hucustodio = ent.HUCUSTODIO.Where(y => y.ACT_ID == id).ToList();
        //movimientorfi
        var movimientorfi = ent.MOVIMIENTO_RFID.Where(y => y.act_id == id).ToList();
        //actreserva
        var actreserva = ent.ACRESERVA.FirstOrDefault(y => y.ACT_ID == id);
        //activo
        var activo = ent.ACTIVO.FirstOrDefault(y => y.ACT_ID == id);

        if (car.Count == 0 && dep.Count == 0 && depsri.Count == 0)
        {
            foreach (MACTIVO item in mactivo)
            {
                ent.MACTIVO.Remove(item);
            }
            foreach (HUCUSTODIO item in hucustodio)
            {
                ent.HUCUSTODIO.Remove(item);
            }
            foreach (MOVIMIENTO_RFID item in movimientorfi)
            {
                ent.MOVIMIENTO_RFID.Remove(item);
            }

            ent.ACRESERVA.Remove(actreserva);
            ent.ACTIVO.Remove(activo);

            try
            {
                ent.SaveChanges();
                tran = true;
            }
            catch (Exception ex)
            {
                tran = false;
            }
        }
        else if (car.Count > 0 && dep.Count == 0 && depsri.Count == 0)
        {

            foreach (CARACTERISTICA item in car)
            { 
            ent.CARACTERISTICA.Remove(item);
            }
            foreach (MACTIVO item in mactivo)
            {
                ent.MACTIVO.Remove(item);
            }
            foreach (HUCUSTODIO item in hucustodio)
            {
                ent.HUCUSTODIO.Remove(item);
            }
            foreach (MOVIMIENTO_RFID item in movimientorfi)
            {
                ent.MOVIMIENTO_RFID.Remove(item);
            }

            ent.ACRESERVA.Remove(actreserva);
            ent.ACTIVO.Remove(activo);

            try
            {
                ent.SaveChanges();
                tran = true;
            }
            catch (System.Exception ex)
            {
                tran = false;
            }
        }

       else if (car.Count == 0 && dep.Count > 0 && depsri.Count == 0)
        {

            foreach (DEPRECIACION item in dep)
            {
                ent.DEPRECIACION.Remove(item);
            }
            foreach (MACTIVO item in mactivo)
            {
                ent.MACTIVO.Remove(item);
            }
            foreach (HUCUSTODIO item in hucustodio)
            {
                ent.HUCUSTODIO.Remove(item);
            }
            foreach (MOVIMIENTO_RFID item in movimientorfi)
            {
                ent.MOVIMIENTO_RFID.Remove(item);
            }

            ent.ACRESERVA.Remove(actreserva);
            ent.ACTIVO.Remove(activo);

            try
            {
                ent.SaveChanges();
                tran = true;
            }
            catch (System.Exception ex)
            {
                tran = false;
            }
        }
        else if (car.Count == 0 && dep.Count == 0 && depsri.Count > 0)
        {
            foreach (DEPRECIACIONSRI item in depsri)
            {
                ent.DEPRECIACIONSRI.Remove(item);
            }
            foreach (MACTIVO item in mactivo)
            {
                ent.MACTIVO.Remove(item);
            }
            foreach (HUCUSTODIO item in hucustodio)
            {
                ent.HUCUSTODIO.Remove(item);
            }
            foreach (MOVIMIENTO_RFID item in movimientorfi)
            {
                ent.MOVIMIENTO_RFID.Remove(item);
            }

            ent.ACRESERVA.Remove(actreserva);
            ent.ACTIVO.Remove(activo);

            try
            {
                ent.SaveChanges();
                tran = true;
            }
            catch (System.Exception ex)
            {
                tran = false;
            }
        }
        else if (car.Count > 0 && dep.Count > 0 && depsri.Count > 0)
        {
            
            foreach (CARACTERISTICA item in car)
            {
                ent.CARACTERISTICA.Remove(item);
            }

            foreach (DEPRECIACION item in dep)
            {
                ent.DEPRECIACION.Remove(item);
            }
           
            foreach (DEPRECIACIONSRI item in depsri)
            { 
                ent.DEPRECIACIONSRI.Remove(item);
            }
            foreach (MACTIVO item in mactivo)
            {
                ent.MACTIVO.Remove(item);
            }
            foreach (HUCUSTODIO item in hucustodio)
            {
                ent.HUCUSTODIO.Remove(item);
            }
            foreach (MOVIMIENTO_RFID item in movimientorfi)
            {
                ent.MOVIMIENTO_RFID.Remove(item);
            }

            ent.ACRESERVA.Remove(actreserva);
           
            ent.ACTIVO.Remove(activo);
           

            try
            {
                ent.SaveChanges();
                tran = true;
            }
            catch (System.Exception ex)
            {
                tran = false;
            }
        }
        else if (car.Count == 0 && dep.Count > 0 && depsri.Count > 0)
        {
            foreach (DEPRECIACION item in dep)
            {
                ent.DEPRECIACION.Remove(item);
            }
           
            foreach (DEPRECIACIONSRI item in depsri)
            { 
            ent.DEPRECIACIONSRI.Remove(item);
            }
            foreach (MACTIVO item in mactivo)
            {
                ent.MACTIVO.Remove(item);
            }
            foreach (HUCUSTODIO item in hucustodio)
            {
                ent.HUCUSTODIO.Remove(item);
            }
            foreach (MOVIMIENTO_RFID item in movimientorfi)
            {
                ent.MOVIMIENTO_RFID.Remove(item);
            }

            ent.ACRESERVA.Remove(actreserva);
           
            ent.ACTIVO.Remove(activo);
           

            try
            {
                ent.SaveChanges();
                tran = true;
            }
            catch (System.Exception ex)
            {
                tran = false;
            }
        }
       
        return tran;
    }
}