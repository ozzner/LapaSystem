using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LN_Muestra
    {
        ADNT_Muestra dataNTx = new ADNT_Muestra();
        ADT_Muestra dataTx = new ADT_Muestra();

        public bool PasarAEnProceso(int MuestraDetalleID, int UsuarioID)
        {
            return dataTx.PasarAEnProceso(MuestraDetalleID, UsuarioID);
        }
        public bool VolverAEnCola(int MuestraDetalleID)
        {
            return dataTx.VolverAEnCola(MuestraDetalleID);
        }
        public bool RegistrarUsoEquipo(int EquipoID, int MuestraDetalleID)
        {
            return dataTx.RegistrarUsoEquipo(EquipoID, MuestraDetalleID);
        }
   public bool RegistrarEquiposUsados(string listaEquipos,int MuestraDetalleID)
        {
            return dataTx.RegistrarEquiposUsados(listaEquipos, MuestraDetalleID);
        }
        //public bool InsertarResultado(decimal result, int MuestraDetalleID)
        public bool InsertarResultado(string result, int MuestraDetalleID)
        {
            return dataTx.InsertarResultado(result, MuestraDetalleID);
        }
        public bool InsertarResultadoAttr(string result, int MuestraDetalleID)
        {
            return dataTx.InsertarResultadoAttr(result, MuestraDetalleID);
        }
        public List<ENT_Muestra> ListarMuestrasPendientes(int UsuarioID)
        {
            return dataNTx.ListarMuestrasPendientes(UsuarioID);
        }

        public ENT_Atributo ListarOpciones(int MuestraDetalleID)
        {
            return dataNTx.ListarOpciones(MuestraDetalleID);
        }
        public List<ENT_Muestra> ListarMuestrasPendientesAttr(int UsuarioID)
        {
            return dataNTx.ListarMuestrasPendientesAttr(UsuarioID);
        }

        public List<ENT_Muestra> ListarEnProceso(int UsuarioID)
        {
            return dataNTx.ListarEnProceso(UsuarioID);
        }

        public List<ENT_Muestra> ListarEnProcesoAttr(int UsuarioID)
        {
            return dataNTx.ListarEnProcesoAttr(UsuarioID);
        }

        public List<ENT_Muestra> ListarTerminado(int UsuarioID)
        {
            return dataNTx.ListarTerminado(UsuarioID);
        }
        public List<ENT_Muestra> ListarTerminadoAttr(int UsuarioID)
        {
            return dataNTx.ListarTerminadoAttr(UsuarioID);
        }

        public List<ENT_Muestra> ObtenerMuestras(int MuestraID)
        {
            return dataNTx.ObtenerMuestras(MuestraID);
        }

        public List<ENT_Muestra> ObtenerMuestrasAttr(int MuestraID)
        {
            return dataNTx.ObtenerMuestrasAttr(MuestraID);
        }

        public List<ENT_Muestra> ListarMuestras(string ProdParaCod)
        {
            return dataNTx.ListarMuestras(ProdParaCod);
        }


        public bool InsertarMuestra(int UsuarioID, string CodigoMuestra, string ProdLabCod, List<ENT_Muestra> oEnt_Muestra, List<ENT_Muestra> oEnt_MuestraAttr)
        {
            return dataTx.InsertarMuestra(UsuarioID, CodigoMuestra, ProdLabCod, oEnt_Muestra, oEnt_MuestraAttr);
        }

        public bool EliminarMuestraDetalle(int MuestraDetalleID)
        {
            return dataTx.EliminarMuestraDetalle(MuestraDetalleID);
        }

        public bool EliminarMuestraCabecera(int MuestraID)
        {
            return dataTx.EliminarMuestraCabecera(MuestraID);
        }


    }

}
