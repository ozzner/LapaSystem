using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LN_Mantenimiento
    {
        ADNT_Mantenimiento dataNTx = new ADNT_Mantenimiento();
        ADT_Mantenimiento dataTx = new ADT_Mantenimiento();


        public List<ENT_Mantenimiento> ListarMantenimientosXEquipo(int EquipoID)
        {
            return dataNTx.ListarMantenimientosXEquipo(EquipoID);
        }

        public List<ENT_Mantenimiento> ListarMantenimientos(int Tipo,string LaboratorioCod)
        {
            return dataNTx.ListarMantenimientos(Tipo,LaboratorioCod);
        }

        public bool AgregarMantenimiento(int EquipoID
                                            ,string FecProgramada
                                            ,string Operador)
        {
            return dataTx.AgregarMantenimiento(EquipoID
                                                ,FecProgramada
                                                ,Operador);
        }
        

        public bool FinalizarMantenimento(int MantenimientoID
                                            ,string FechaRealizaco
                                            ,string Observaciones)
        {
            return dataTx.FinalizarMantenimento(MantenimientoID
                                                , FechaRealizaco
                                                , Observaciones);
        }

        public bool EliminarMantenimiento(string MantenimientoID) {
            return dataTx.EliminarMantenimiento(MantenimientoID);
        }
        
    }

}

