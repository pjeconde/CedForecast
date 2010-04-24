using System;
using System.Collections.Generic;
using System.Text;

namespace CedEntidades
{
    [Serializable]
    public class EsqSegEvenPos
    {
        #region Atributos
        Evento evento;
        int cantInterv;
        Grupo grupo;
        string debeSerSP;
        int supervisorNivelDsd;
        int supervisorNivelHst;
        #endregion
        #region Propiedades
        public EsqSegEvenPos()
        {
            evento = new Evento();
            grupo = new Grupo();
        }
        public Evento Evento
        {
            get
            {
                return evento;
            }
            set
            {
                evento = value;
            }
        }
        public int CantInterv
        {
            get
            {
                return cantInterv;
            }
            set
            {
                cantInterv = value;
            }
        }
        public Grupo Grupo
        {
            get
            {
                return grupo;
            }
            set
            {
                grupo = value;
            }
        }
        public string DebeSerSP
        {
            get
            {
                return debeSerSP;
            }
            set
            {
                debeSerSP = value;
            }
        }
        public int SupervisorNivelDsd
        {
            get
            {
                return supervisorNivelDsd;
            }
            set
            {
                supervisorNivelDsd = value;
            }
        }
        public int SupervisorNivelHst
        {
            get
            {
                return supervisorNivelHst;
            }
            set
            {
                supervisorNivelHst = value;
            }
        }
        #endregion
    }
}
