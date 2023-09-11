using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de HPassword
/// </summary>
public class HPassword
{
    C5ALIANZAVALLE23102015Entities ent = new C5ALIANZAVALLE23102015Entities();
	public HPassword()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public string Guardar(string usu, string pwd, DateTime fechacreacion, int cont)
    {
        HISTORIAL_PASSWORD hp = new HISTORIAL_PASSWORD();
        string msg = "";

        hp.usuario = usu.Trim();
        hp.password = pwd.Trim();
        hp.fechacreacion = fechacreacion;
        hp.cont = cont;
        ent.HISTORIAL_PASSWORD.Add(hp);

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
    public bool PwdUsada(string pwd, string usuario)
    {
        List<HISTORIAL_PASSWORD> hp = new List<HISTORIAL_PASSWORD>();
        bool exist = true;

        hp = ent.HISTORIAL_PASSWORD.Where(x => x.usuario.Trim() == usuario.Trim()).OrderByDescending(f => f.fechacreacion).Take(10).ToList();

        if (hp != null)
        {
            foreach (HISTORIAL_PASSWORD passw in hp)
            {
                if (passw.password == pwd)
                {
                    exist = false;
                    break;
                }
                else
                {
                    exist = true;
                }
            }
        }
        return exist;
    }

    public bool EliminaUsu(string usuario)
    {
        List<HISTORIAL_PASSWORD> hp = new List<HISTORIAL_PASSWORD>();

        hp = ent.HISTORIAL_PASSWORD.Where(x => x.usuario.Trim() == usuario.Trim()).ToList();

        if (hp.Count > 0)
        { 
            foreach (HISTORIAL_PASSWORD item in hp)
            
            ent.HISTORIAL_PASSWORD.Remove(item);
        }
        try
        {
            ent.SaveChanges();
            return true;

        }
        catch (System.Exception ex)
        {
            return false;
        }
    }

    public int TipoBloqueoMembership(string usuario)
    {
        aspnet_Users u = new aspnet_Users();
        int tipo_block = 0;
        u = ent.aspnet_Users.Where(x => x.UserName.Trim() == usuario.Trim()).FirstOrDefault();

        if (u != null)
        {
            aspnet_Membership m = new aspnet_Membership();

            m = ent.aspnet_Membership.Where(x => x.UserId == u.UserId).FirstOrDefault();

            if (m != null)
            {
                tipo_block = m.FailedPasswordAttemptCount;
            }
        }

        return tipo_block;
    }

    public int TipoBloqueo(string usuario)
    {
        aspnet_Users u = new aspnet_Users();
        int tipo_block = 0;
        u = ent.aspnet_Users.Where(x => x.UserName.Trim() == usuario.Trim()).FirstOrDefault();

        if (u != null)
        {
            BLOQUEO_PASSWORD bp = new BLOQUEO_PASSWORD();

            bp = ent.BLOQUEO_PASSWORD.Where(x => x.usuario.Trim() == u.UserName.Trim()).FirstOrDefault();

            if (bp != null)
            {
                tipo_block = bp.tipo_bloqueo;
            }
            else
            {
                tipo_block = 0;
            }
        }

        return tipo_block;
    }

    public bool GuardarBloqueo(string usuario, string hblock, string hdesblock, int tipoblock)
    {
        BLOQUEO_PASSWORD bpwd = new BLOQUEO_PASSWORD();

        bpwd.usuario = usuario.Trim();
        bpwd.hora_bloqueo = hblock;
        bpwd.hora_desbloqueo = hdesblock;
        bpwd.tipo_bloqueo = tipoblock;

        ent.BLOQUEO_PASSWORD.Add(bpwd);

        try
        {
            ent.SaveChanges();
            return true;
        }
        catch (System.Exception ex)
        {
            return false;
        }
        
    }

    public bool ActualizaBloqueo(string usuario,string  hblock, string hdesblock, int tipoblock, int nuevotipoblock)
    {
        BLOQUEO_PASSWORD bpwd = new BLOQUEO_PASSWORD();


        bpwd = ent.BLOQUEO_PASSWORD.Where(x => x.usuario.Trim() == usuario.Trim() && x.tipo_bloqueo == tipoblock).FirstOrDefault();

        if (bpwd != null)
        {
            bpwd.hora_bloqueo = hblock;
            bpwd.hora_desbloqueo = hdesblock;
            bpwd.tipo_bloqueo = nuevotipoblock;
        }
        

        try
        {
            ent.SaveChanges();
            return true;
        }
        catch (System.Exception ex)
        {
            return false;
        }
    }

    public bool ActualizaBloqueoFinal(string usuario, int hdesblock, int tipoblock, int nuevotipoblock)
    {
        BLOQUEO_PASSWORD bpwd = new BLOQUEO_PASSWORD();


        bpwd = ent.BLOQUEO_PASSWORD.Where(x => x.usuario.Trim() == usuario.Trim() && x.tipo_bloqueo == tipoblock).FirstOrDefault();

        if (bpwd != null)
        {
            bpwd.tipo_bloqueo = nuevotipoblock;
        }


        try
        {
            ent.SaveChanges();
            return true;
        }
        catch (System.Exception ex)
        {
            return false;
        }
    }

    public bool EliminaBloqueo(string usuario)
    {
        BLOQUEO_PASSWORD bpwd = new BLOQUEO_PASSWORD();
        bool eli = false;
        bpwd = ent.BLOQUEO_PASSWORD.Where(x => x.usuario.Trim() == x.usuario.Trim() && x.tipo_bloqueo == 3).FirstOrDefault();

        if (bpwd != null)
        {
            ent.BLOQUEO_PASSWORD.Remove(bpwd);
            try
            {
                ent.SaveChanges();
                eli = true;
            }
            catch (Exception ex)
            {
                eli = false;
            }
        }

        return eli;
    }
}