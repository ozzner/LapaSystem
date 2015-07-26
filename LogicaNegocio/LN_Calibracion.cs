using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LN_Calibracion
    {
        ADNT_Calibracion dataNTx = new ADNT_Calibracion();
        ADT_Calibracion dataTx = new ADT_Calibracion();

        //ListarCalibraciones

        //public List<ENT_Calibracion> ListarMantenimientosXEquipo(int EquipoID)
        //{
        //    return dataNTx.ListarMantenimientosXEquipo(EquipoID);
        //}

        public List<ENT_Calibracion> ListarCalibraciones(int Tipo, string LaboratorioCod)
        {
            return dataNTx.ListarCalibraciones(Tipo, LaboratorioCod);
        }

        public bool AgregarCalibraciones(int EquipoID
                                            , string FecProgramada
                                            , string Operador
                                            , string ISO)
        {
            return dataTx.AgregarCalibracion(EquipoID
                                                , FecProgramada
                                                , Operador
                                                ,ISO);
        }


        public bool FinalizarCalibraciones(int CalibracionID
                                            , string FechaRealizaco
                                            , string Observaciones)
        {
            return dataTx.FinalizarCalibracion(CalibracionID
                                                , FechaRealizaco
                                                , Observaciones);
        }

        public bool EliminarCalibraciones(string CalibracionID)
        {
            return dataTx.EliminarCalibracion(CalibracionID);
        }

    }

}
