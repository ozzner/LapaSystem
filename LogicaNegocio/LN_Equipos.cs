using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LN_Equipos
    {
        ADNT_Equipos dataNTx = new ADNT_Equipos();
        ADT_Equipos dataTx = new ADT_Equipos();

        public List<ENT_Equipos> ListarEquiposLab(string LaboratorioCod)
        {

            return dataNTx.ListarEquiposLab(LaboratorioCod);
        }
        public ENT_Equipos ObtenerDetalle(int EquipoID)
        {

            return dataNTx.ObtenerDetalle(EquipoID);
        }

        public List<ENT_Equipos> ListarEquiposParametro(int MuestraDetalleID)
        {
            return dataNTx.ListarEquiposParametro(MuestraDetalleID);
        }

        public bool InsertarEquipo(ENT_Equipos oENT_Equipo)
        {
            return dataTx.InsertarEquipo(oENT_Equipo);
        }


        public bool ActualizarEquipo(ENT_Equipos oENT_Equipo)
        {
            return dataTx.ActualizarEquipo(oENT_Equipo);
        }

        public bool QuitarEquipo(int EquipoID, ref int existe)
        {
            return dataTx.QuitarEquipo(EquipoID, ref existe);
        }

    }

}
