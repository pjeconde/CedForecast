using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebDB
{
    public class ForecastReasignar : db
    {
        public ForecastReasignar(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Modificar(List<CedForecastWebEntidades.RFoPA> ForecastLista, string TipoDatoAReasignar, string ValorAReasignar, string Periodo)
        { 
            System.Text.StringBuilder a = new StringBuilder();
            if (TipoDatoAReasignar == "CuentaCompleta") 
            {
                a.Append("delete Forecast where IdCuenta = '" + ForecastLista[0].IdCuenta + "' and IdTipoPlanilla = '" + ForecastLista[0].IdTipoPlanilla + "' ");
            }
            else
            {
                a.Append("delete Forecast where IdCuenta = '" + ForecastLista[0].IdCuenta + "' and IdCliente = '" + ForecastLista[0].Cliente.Id + "' and IdTipoPlanilla = '" + ForecastLista[0].IdTipoPlanilla + "' ");
            }
            string periodo = "";
            periodo = CedForecastWebDB.RFoPA.UltimoMesForecast(Periodo);
            if (ForecastLista[0].IdTipoPlanilla == "Proyectado" && Periodo.Substring(0, 4) == periodo.Substring(0, 4))
            {
                periodo = Periodo.Substring(0, 4) + "99";
            }
            a.Append("and IdPeriodo >= '" + Periodo + "' and IdPeriodo <= '" + periodo + "' ");
            foreach (CedForecastWebEntidades.RFoPA Forecast in ForecastLista)
            {
                if (Forecast.Articulo.Id != null)
                {
                    string cuentaAReasignar = Forecast.IdCuenta;
                    string clienteAReasignar = Forecast.IdCliente;
                    if (TipoDatoAReasignar == "Cuenta" || TipoDatoAReasignar == "CuentaCompleta")
                    {
                        cuentaAReasignar = ValorAReasignar;
                    }
                    if (TipoDatoAReasignar == "Cliente")
                    {
                        clienteAReasignar = ValorAReasignar;
                    }
                    for (int i = 1; i <= 12; i++)
                    {
                        decimal cantidad = 0;
                        switch (i)
                        {
                            case 1:
                                cantidad = Forecast.Cantidad1;
                                break;
                            case 2:
                                cantidad = Forecast.Cantidad2;
                                break;
                            case 3:
                                cantidad = Forecast.Cantidad3;
                                break;
                            case 4:
                                cantidad = Forecast.Cantidad4;
                                break;
                            case 5:
                                cantidad = Forecast.Cantidad5;
                                break;
                            case 6:
                                cantidad = Forecast.Cantidad6;
                                break;
                            case 7:
                                cantidad = Forecast.Cantidad7;
                                break;
                            case 8:
                                cantidad = Forecast.Cantidad8;
                                break;
                            case 9:
                                cantidad = Forecast.Cantidad9;
                                break;
                            case 10:
                                cantidad = Forecast.Cantidad10;
                                break;
                            case 11:
                                cantidad = Forecast.Cantidad11;
                                break;
                            case 12:
                                cantidad = Forecast.Cantidad12;
                                break;
                        }
                        if (cantidad > 0)
                        {
                            a.Append("Insert Forecast values ('" + Forecast.IdTipoPlanilla + "', '" + cuentaAReasignar + "', '" + clienteAReasignar + "', '");
                            if (Forecast.IdTipoPlanilla == "Proyectado")
                            {
                                a.Append(Forecast.Articulo.Id + "', '" + CedForecastWebDB.RFoPA.PeriodoAProcesar(i - 1, Forecast.IdPeriodo) + "', " + cantidad + ") ");
                            }
                            else 
                            {
                                a.Append(Forecast.Articulo.Id + "', '" + CedForecastWebDB.RFoPA.PeriodoAProcesar(i - 1, Forecast.IdPeriodo) + "', " + cantidad + ") ");
                            }
                        }
                    }
                    if (Forecast.IdTipoPlanilla == "Proyectado")
                    {
                        if (Forecast.Cantidad13 > 0)
                        {
                            a.Append("Insert Forecast values ('" + Forecast.IdTipoPlanilla + "', '" + cuentaAReasignar + "', '" + clienteAReasignar + "', '");
                            a.Append(Forecast.Articulo.Id + "', '" + Forecast.IdPeriodo + "13', " + Forecast.Cantidad13 + ") ");
                        }
                        if (Forecast.Cantidad14 > 0)
                        {
                            a.Append("Insert Forecast values ('" + Forecast.IdTipoPlanilla + "', '" + cuentaAReasignar + "', '" + clienteAReasignar + "', '");
                            a.Append(Forecast.Articulo.Id + "', '" + Forecast.IdPeriodo + "14', " + Forecast.Cantidad14 + ") ");
                        }
                    }
                }
            }
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
    }
}
