using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site_Activos_ActivarItemDepre : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Activar Depreciación Activo";
        try
        {
            if ((string)(Session["emid"]) == null)
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
        catch
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
        if (!IsPostBack)
        {

        }
    }

    [WebMethod]
    public static object VerificaCodigo(string codigo)
    {
        object[] datos = new object[3];
        if (codigoCorrecto(codigo))
        {
            if (Logica.HELPER.comprobarCbIngresado(_codbar))
            {
                using (C5ALIANZAVALLE23102015Entities ent = new C5ALIANZAVALLE23102015Entities())
                {
                    var item = ent.ACTIVO.Where(x => x.ACT_CODBARRAS.Trim() == _codbar.Trim()).FirstOrDefault();

                    if (item.DEPRECIACIONSRI.ToList().Count == 0)
                    {

                        if (item != null)
                        {
                            datos[0] = "ok";
                            datos[1] = item.GRUPO.GRU_NOMBRE;
                            datos[2] = _codbar.Trim();
                        }
                        else
                        {
                            datos[0] = "no existe Item";
                        }
                    }
                    else
                    {
                        datos[0] = "Item ya fue Activado tiene:" + item.DEPRECIACIONSRI.ToList().Count.ToString() + " Periodos Generados";
                    }
                }
            }
            else
            {
                datos[0] = "No se puede encontrar Item, aún no ha sido ingresado!";
            }
        }
        else
        {
            datos[0] = "Codigo de Barras no válido, por favor corrijalo!";
        }

        return datos;
    }


    public static string _codbar = "";
    public static bool codigoCorrecto(string codigo)
    {
        try
        {
            if (codigo.Trim().Length < int.Parse(HttpContext.Current.Session["emtd"].ToString()))
            {
                _codbar = HttpContext.Current.Session["empr"].ToString() + completarCodigo(codigo);
            }
            else if (codigo.Trim().Length == int.Parse(HttpContext.Current.Session["emtd"].ToString()))
            {
                _codbar = codigo;
            }
            else
            {
                return false;
            }

            if (Logica.HELPER.codigoValido(_codbar))
            {
                //txtbuscb.Text = codbar;
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static string completarCodigo(string codbar)
    {
        try
        {
            //ceros es el numero de digitos disponibles para activos
            int ceros = 0;
            ceros = int.Parse(HttpContext.Current.Session["emtd"].ToString()) - HttpContext.Current.Session["empr"].ToString().Length;
            for (int i = codbar.Length; i < ceros; i++)
                codbar = "0" + codbar;
            return codbar;
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    [WebMethod]
    public static string InsertDepreciacion(string codigo, string fechainidepre)
    {

        using (C5ALIANZAVALLE23102015Entities ent = new C5ALIANZAVALLE23102015Entities())
        {
            try
            {
                var item = ent.ACTIVO.Where(x => x.ACT_CODBARRAS.Trim() == codigo.Trim()).FirstOrDefault();
                if (item != null)
                {
                    if (item.ACT_VALORCOMPRA > 0 && item.ACT_VALORCOMPRA != null)
                    {
                        DEPRECIACIONSRI dep = new DEPRECIACIONSRI();

                        dep.DEP_VIDAUTIL = item.ACT_VIDAUTIL ?? 0;
                        dep.DEP_VALORRESIDUAL = 0;
                        dep.DEP_SALDOXDEPRE = item.ACT_VALORCOMPRA - (item.ACT_VALORCOMPRA / item.ACT_VIDAUTIL) ?? 0;
                        dep.DEP_DEPREACUM = item.ACT_VALORCOMPRA / item.ACT_VIDAUTIL ?? 0;
                        dep.DEP_PERTRANS = 1;
                        dep.DEP_PERREMA = item.ACT_VIDAUTIL - 1 ?? 0;
                        dep.DEP_DEPREPERIODO = item.ACT_VALORCOMPRA / item.ACT_VIDAUTIL ?? 0;
                        dep.DEP_FECHAPROX = calcularFechaIniDepre(DateTime.Parse(fechainidepre));
                        dep.DEP_TIPO = "TRIBUTARIA";
                        dep.ACT_ID = item.ACT_ID;
                        dep.DEP_CCOSTO = item.UORGANICA.UOR_NOMBRE;
                        dep.DEP_GRUPO = item.GRUPO.GRU_NOMBRE;

                        ent.DEPRECIACIONSRI.Add(dep);

                        var depgenerada = ent.DGENERADASRI.Max(x => x.DGE_SIGUIENTE);

                        if (dep.DEP_FECHAPROX < depgenerada)
                        {
                            return "FECHA de Inicio de DEPRECIACION no puede ser MENOR a la FECHA de DEPRECIACION YA GENERADA";
                        }
                        else
                        {
                            ent.SaveChanges();

                            return "ok";
                        }
                    }
                    else {
                        return "El valor de la COMPRA es 0 (cero) o no fue Ingresado, por favor correjir";
                    }
                }
                else
                {
                    return "item no existe";
                }
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }

        }

    }

    public static DateTime calcularFechaIniDepre(DateTime fechaCompra)
    {
        DateTime fechaComienzoDepre = fechaCompra.Date;

        if (fechaComienzoDepre.Day != 1)
        {
            if (fechaComienzoDepre.Day < 16)
            {
                while (fechaComienzoDepre.Day != 1)
                {
                    fechaComienzoDepre = fechaComienzoDepre.AddDays(-1);
                }
            }
            else
            {
                while (fechaComienzoDepre.Day != 1)
                {
                    fechaComienzoDepre = fechaComienzoDepre.AddDays(1);
                }
            }
        }
        return fechaComienzoDepre;
    }
}
