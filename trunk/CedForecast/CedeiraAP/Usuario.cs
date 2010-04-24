using System;
using System.Data;
using System.Security.Principal;
using System.DirectoryServices;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Cedeira.SV {
    public static class Usuario
    {
        public static List<CedEntidades.Usuario> Lista(CedEntidades.Sesion Sesion)
        {
            Cedeira.SV.db db = new Cedeira.SV.db(Sesion);
            DataView dv = db.US_Usuario_qry();
            return (List<CedEntidades.Usuario>)ArmarLista(dv, Sesion);
        }
        public static List<CedEntidades.Usuario> Lista(List<CedEntidades.Grupo> ExcluirGrupos, CedEntidades.Sesion Sesion)
        {
            Cedeira.SV.db db = new Cedeira.SV.db(Sesion);
            DataView dv = db.US_Usuario_qry(ExcluirGrupos);
            return (List<CedEntidades.Usuario>) ArmarLista(dv, Sesion);
        }
        private static List<CedEntidades.Usuario> ArmarLista(DataView DV, CedEntidades.Sesion Sesion)
        {
            List<CedEntidades.Usuario> usuarioLista = new List<CedEntidades.Usuario>();
            for (int i = 0; i < DV.Table.Rows.Count; i++)
            {
                CedEntidades.Usuario u = new CedEntidades.Usuario();
                u.IdUsuario = Convert.ToString(DV.Table.Rows[i]["IdUsuario"]);
                u.Nombre = Convert.ToString(DV.Table.Rows[i]["Nombre"]);
                u.Activo = Convert.ToBoolean(DV.Table.Rows[i]["Activo"]);
                if (DV.Table.Rows[i]["Alias"] != System.DBNull.Value)
                {
                    u.Alias = Convert.ToString(DV.Table.Rows[i]["Alias"]);
                }
                else
                {
                    u.Alias = String.Empty;
                }
                u.FecAlta = Convert.ToDateTime(DV.Table.Rows[i]["FecAlta"]);
                u.FecBaja = Convert.ToDateTime(DV.Table.Rows[i]["FecBaja"]);
                if (DV.Table.Rows[i]["Email"] != System.DBNull.Value)
                {
                    u.Email = Convert.ToString(DV.Table.Rows[0]["Email"]);
                }
                else
                {
                    u.Email = String.Empty;
                }
                usuarioLista.Add(u);
            }
            return usuarioLista;
        }
        public static void Leer(CedEntidades.Usuario Usuario, CedEntidades.Sesion Sesion)
        {
            Cedeira.SV.db db = new Cedeira.SV.db(Sesion);
            DataView dv = db.US_Usuario_get(Usuario.IdUsuario);
            if (dv.Table.Rows.Count != 0)
            {
                Usuario.IdUsuario = Convert.ToString(dv.Table.Rows[0]["IdUsuario"]);
                Usuario.Nombre = Convert.ToString(dv.Table.Rows[0]["Nombre"]);
                Usuario.Activo = Convert.ToBoolean(dv.Table.Rows[0]["Activo"]);
                if (dv.Table.Rows[0]["Alias"] != System.DBNull.Value)
                {
                    Usuario.Alias = Convert.ToString(dv.Table.Rows[0]["Alias"]);
                }
                else
                {
                    Usuario.Alias = String.Empty;
                }
                Usuario.FecAlta = Convert.ToDateTime(dv.Table.Rows[0]["FecAlta"]);
                Usuario.FecBaja = Convert.ToDateTime(dv.Table.Rows[0]["FecBaja"]);
                if (dv.Table.Rows[0]["Email"] != System.DBNull.Value)
                {
                    Usuario.Email = Convert.ToString(dv.Table.Rows[0]["Email"]);
                }
                else
                {
                    Usuario.Email = String.Empty;
                }
                dv = null;
                Usuario.PerteneceA = db.US_PerteneceA(Usuario.IdUsuario);
                Usuario.NoPerteneceA = db.US_NoPerteneceA(Usuario.IdUsuario);
            }
            else
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.Inexistente();
            }
        }
    }
}