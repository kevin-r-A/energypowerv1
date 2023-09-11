using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Asientos
/// </summary>
public class Asientos
{
    public Asientos()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public static bool InsertActivo(Logica.ACTIVO aCTIVO)
    {
        try
        {
            Cabecera cab = new Cabecera();
            DetalleModulo det = new DetalleModulo();

            cab.IdCabeceraModulo = aCTIVO.Id;
            cab.FechaContable = DateTime.Now.Date;
            cab.SucursalOrigen = 99;
            cab.TotalDebitoMn = aCTIVO.ACT_VALORCOMPRA;
            cab.TotalDebitoMe = 0;
            cab.TotalCreditoMn = aCTIVO.ACT_VALORCOMPRA;
            cab.TotalCreditoMe = 0;
            cab.Registros = 2;
            cab.Digitador = aCTIVO.USERNAME.Trim();
            cab.Autorizador = aCTIVO.Id.ToString();
            cab.EstadoProceso = "I";
            cab.LocalidadOrigen = 99;
            cab.ResponsableOrigen = 22;
            cab.ModuloCobis = 48;

            using (C5ALIANZAVALLE23102015Entities ent = new C5ALIANZAVALLE23102015Entities())
            {
                ent.Cabecera.Add(cab);

                if (ent.SaveChanges() > 0)
                {
                    cab.IdCabeceraModulo = cab.id;
                    det = new DetalleModulo();
                    det.IdCabeceraModulo = cab.id;
                    det.Registro = 1;
                    det.Cuenta = aCTIVO.CuentaOrigen;
                    det.IdMoneda = 1;
                    det.SucursalDestino = short.Parse(aCTIVO.Oficina1);
                    det.Detalle = aCTIVO.Id.ToString();
                    det.DebitoMn = 0;
                    det.DebitoMe = 0;
                    det.CreditoMn = aCTIVO.ACT_VALORCOMPRA;
                    det.CreditoMe = 0;
                    det.TipoTransaccion = "C";
                    det.TipoNegociacion = "N";
                    det.Operacion = aCTIVO.Id.ToString();
                    det.Referencia = "I";
                    det.LocalidadDestino = short.Parse(aCTIVO.Oficina1);
                    det.ResponsableDestino = short.Parse(aCTIVO.CentroCosto1);

                    ent.DetalleModulo.Add(det);

                    det = new DetalleModulo();
                    det.IdCabeceraModulo = cab.id;
                    det.Registro = 2;
                    det.Cuenta = aCTIVO.CuentaDestino;
                    det.IdMoneda = 1;
                    det.SucursalDestino = short.Parse(aCTIVO.Oficina2);
                    det.Detalle = aCTIVO.Id.ToString();
                    det.DebitoMn = aCTIVO.ACT_VALORCOMPRA;
                    det.DebitoMe = 0;
                    det.CreditoMn = 0;
                    det.CreditoMe = 0;
                    det.TipoTransaccion = "D";
                    det.TipoNegociacion = "N";
                    det.Operacion = aCTIVO.Id.ToString();
                    det.Referencia = "I";
                    det.LocalidadDestino = short.Parse(aCTIVO.Oficina2);
                    det.ResponsableDestino = short.Parse(aCTIVO.CentroCosto2);
                    ent.DetalleModulo.Add(det);

                    ent.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static bool TransferenciaActivo(Logica.ACTIVO aCTIVO)
    {
        try
        {
            Cabecera cab = new Cabecera();
            DetalleModulo det = new DetalleModulo();

            cab.IdCabeceraModulo = aCTIVO.Id;
            cab.FechaContable = DateTime.Now.Date;
            cab.SucursalOrigen = 99;
            cab.TotalDebitoMn = aCTIVO.ACT_VALORCOMPRA + decimal.Parse(aCTIVO.DebitoDepre1) + +decimal.Parse(aCTIVO.DebitoDepre2);
            cab.TotalDebitoMe = 0;
            cab.TotalCreditoMn = aCTIVO.ACT_VALORCOMPRA + decimal.Parse(aCTIVO.CreditoDepre1) + +decimal.Parse(aCTIVO.CreditoDepre2);
            cab.TotalCreditoMe = 0;
            cab.Registros = (short)(aCTIVO.CreditoDepre1 != "" && aCTIVO.CreditoDepre1 != "0.00" ?4: 2);
            cab.Digitador = aCTIVO.USERNAME.Trim();
            cab.Autorizador = aCTIVO.Id.ToString();
            cab.EstadoProceso = "T";
            cab.LocalidadOrigen = 99;
            cab.ResponsableOrigen = 22;
            cab.ModuloCobis = 48;

            using (C5ALIANZAVALLE23102015Entities ent = new C5ALIANZAVALLE23102015Entities())
            {
                ent.Cabecera.Add(cab);
                if (ent.SaveChanges() > 0)
                {
                    cab.IdCabeceraModulo = cab.id;
                    det = new DetalleModulo();
                    det.IdCabeceraModulo = cab.id;
                    det.Registro = 1;
                    det.Cuenta = aCTIVO.CuentaOrigen;
                    det.IdMoneda = 1;
                    det.SucursalDestino = short.Parse(aCTIVO.Oficina1);
                    det.Detalle = aCTIVO.Id.ToString();
                    det.DebitoMn = 0;
                    det.DebitoMe = 0;
                    det.CreditoMn = aCTIVO.ACT_VALORCOMPRA;
                    det.CreditoMe = 0;
                    det.TipoTransaccion = "C";
                    det.TipoNegociacion = "N";
                    det.Operacion = aCTIVO.Id.ToString();
                    det.Referencia = "T";
                    det.LocalidadDestino = int.Parse(aCTIVO.Oficina1);
                    det.ResponsableDestino = int.Parse(aCTIVO.CentroCosto1);

                    ent.DetalleModulo.Add(det);

                    det = new DetalleModulo();
                    det.IdCabeceraModulo = cab.id;
                    det.Registro = 2;
                    det.Cuenta = aCTIVO.CuentaDestino;
                    det.IdMoneda = 1;
                    det.SucursalDestino = short.Parse(aCTIVO.Oficina2);
                    det.Detalle = aCTIVO.Id.ToString();
                    det.DebitoMn = aCTIVO.ACT_VALORCOMPRA;
                    det.DebitoMe = 0;
                    det.CreditoMn = 0;
                    det.CreditoMe = 0;
                    det.TipoTransaccion = "D";
                    det.TipoNegociacion = "N";
                    det.Operacion = aCTIVO.Id.ToString();
                    det.Referencia = "T";
                    det.LocalidadDestino = int.Parse(aCTIVO.Oficina2);
                    det.ResponsableDestino = int.Parse(aCTIVO.CentroCosto2);

                    ent.DetalleModulo.Add(det);

                    if (aCTIVO.CreditoDepre1 != "" && aCTIVO.CreditoDepre1 != "0.00" )
                    {
                        det = new DetalleModulo();
                        det.IdCabeceraModulo = cab.id;
                        det.Registro = 3;
                        det.Cuenta = aCTIVO.CuentaDepreOrigen;
                        det.IdMoneda = 1;
                        det.SucursalDestino = short.Parse(aCTIVO.OficinaDepre1);
                        det.Detalle = aCTIVO.Id.ToString();
                        det.DebitoMn = decimal.Parse(aCTIVO.DebitoDepre1);
                        det.DebitoMe = 0;
                        det.CreditoMn = 0;
                        det.CreditoMe = 0;
                        det.TipoTransaccion = "D";
                        det.TipoNegociacion = "N";
                        det.Operacion = aCTIVO.Id.ToString();
                        det.Referencia = "T";
                        det.LocalidadDestino = int.Parse(aCTIVO.OficinaDepre1);
                        det.ResponsableDestino = int.Parse(aCTIVO.CentroCostoDepre1);

                        ent.DetalleModulo.Add(det);

                        det = new DetalleModulo();
                        det.IdCabeceraModulo = cab.id;
                        det.Registro = 4;
                        det.Cuenta = aCTIVO.CuentaDepreDestino;
                        det.IdMoneda = 1;
                        det.SucursalDestino = short.Parse(aCTIVO.OficinaDepre2);
                        det.Detalle = aCTIVO.Id.ToString();
                        det.DebitoMn = 0;
                        det.DebitoMe = 0;
                        det.CreditoMn = decimal.Parse(aCTIVO.CreditoDepre2);
                        det.CreditoMe = 0;
                        det.TipoTransaccion = "C";
                        det.TipoNegociacion = "N";
                        det.Operacion = aCTIVO.Id.ToString();
                        det.Referencia = "T";
                        det.LocalidadDestino = int.Parse(aCTIVO.OficinaDepre2);
                        det.ResponsableDestino = int.Parse(aCTIVO.CentroCostoDepre2);

                        ent.DetalleModulo.Add(det);
                    }
                    

                    ent.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static bool BajaActivo(Logica.ACTIVO aCTIVO)
    {
        try
        {
            Cabecera cab = new Cabecera();
            DetalleModulo det = new DetalleModulo();

            cab.IdCabeceraModulo = aCTIVO.Id;
            cab.FechaContable = DateTime.Now.Date;
            cab.SucursalOrigen = 99;
            cab.TotalDebitoMn = aCTIVO.ACT_VALORCOMPRA;
            cab.TotalDebitoMe = 0;
            cab.TotalCreditoMn = aCTIVO.ACT_VALORCOMPRA;
            cab.TotalCreditoMe = 0;
            cab.Registros = (short)(aCTIVO.ACT_DEPREACUMULADA > 0 ? 3 : 2);
            cab.Digitador = aCTIVO.USERNAME.Trim();
            cab.Autorizador = aCTIVO.Id.ToString();
            cab.EstadoProceso = "B";
            cab.LocalidadOrigen = 99;
            cab.ResponsableOrigen = 22;
            cab.ModuloCobis = 48;

            using (C5ALIANZAVALLE23102015Entities ent = new C5ALIANZAVALLE23102015Entities())
            {
                ent.Cabecera.Add(cab);

                if (ent.SaveChanges() > 0)
                {
                    cab.IdCabeceraModulo = cab.id;
                    det = new DetalleModulo();
                    det.IdCabeceraModulo = cab.id;
                    det.Registro = 1;
                    det.Cuenta = aCTIVO.CuentaOrigen;
                    det.IdMoneda = 1;
                    det.SucursalDestino = short.Parse(aCTIVO.Oficina1);
                    det.Detalle = aCTIVO.Id.ToString();
                    det.DebitoMn = aCTIVO.ACT_VALORCOMPRA - aCTIVO.ACT_DEPREACUMULADA;
                    det.DebitoMe = 0;
                    det.CreditoMn = 0;
                    det.CreditoMe = 0;
                    det.TipoTransaccion = "D";
                    det.TipoNegociacion = "N";
                    det.Operacion = aCTIVO.Id.ToString();
                    det.Referencia = "B";
                    det.LocalidadDestino = int.Parse(aCTIVO.Oficina1);
                    det.ResponsableDestino = int.Parse(aCTIVO.CentroCosto1);

                    ent.DetalleModulo.Add(det);

                    det = new DetalleModulo();
                    det.IdCabeceraModulo = cab.id;
                    det.Registro = 2;
                    det.Cuenta = aCTIVO.CuentaDestino;
                    det.IdMoneda = 1;
                    det.SucursalDestino = short.Parse(aCTIVO.Oficina2);
                    det.Detalle = aCTIVO.Id.ToString();
                    det.DebitoMn = 0;
                    det.DebitoMe = 0;
                    det.CreditoMn = aCTIVO.ACT_VALORCOMPRA;
                    det.CreditoMe = 0;
                    det.TipoTransaccion = "C";
                    det.TipoNegociacion = "N";
                    det.Operacion = aCTIVO.Id.ToString();
                    det.Referencia = "B";
                    det.LocalidadDestino = int.Parse(aCTIVO.Oficina2);
                    det.ResponsableDestino = int.Parse(aCTIVO.CentroCosto2);

                    ent.DetalleModulo.Add(det);

                    if (aCTIVO.ACT_DEPREACUMULADA > 0)
                    {
                        det = new DetalleModulo();
                        det.IdCabeceraModulo = cab.id;
                        det.Registro = 3;
                        det.Cuenta = aCTIVO.CuentaDepreOrigen;
                        det.IdMoneda = 1;
                        det.SucursalDestino = short.Parse(aCTIVO.OficinaDepre1);
                        det.Detalle = aCTIVO.Id.ToString();
                        det.DebitoMn = aCTIVO.ACT_DEPREACUMULADA;
                        det.DebitoMe = 0;
                        det.CreditoMn = 0;
                        det.CreditoMe = 0;
                        det.TipoTransaccion = "D";
                        det.TipoNegociacion = "N";
                        det.Operacion = aCTIVO.Id.ToString();
                        det.Referencia = "B";
                        det.LocalidadDestino = int.Parse(aCTIVO.OficinaDepre1);
                        det.ResponsableDestino = int.Parse(aCTIVO.CentroCostoDepre1);

                        ent.DetalleModulo.Add(det);    
                    }
                    

                    ent.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}