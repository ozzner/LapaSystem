using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LN_Laboratorio
    {
        ADNT_Laboratorio dataNTx = new ADNT_Laboratorio();
        ADT_Laboratorio dataTx = new ADT_Laboratorio();

        public List<ENT_Laboratorio> ListarLaboratorio(int UsuarioID)
        {
            return dataNTx.ListarLaboratorio(UsuarioID);

        }
        public List<ENT_Laboratorio> ListarLaboratorioXEmpresa(int UsuarioID)
        {
            return dataNTx.ListarLaboratorioXEmpresa(UsuarioID);

        }

        public ENT_Laboratorio ObtenerLab(string ProdLabCod)
        {
            return dataNTx.ObtenerLab(ProdLabCod);
        }
        public bool InsertarLab(string nonLaboratorio, string Ubicacion, string ruc, int userID)
        {
            return dataTx.InsertarLab(nonLaboratorio, Ubicacion, ruc, userID);
        }
        public bool ActualizarLaboratorio(ENT_Laboratorio oEnt_Laboratorio)
        {
            return dataTx.ActualizarLaboratorio(oEnt_Laboratorio);
        }
        public bool EliminarLaboratorio(int laboratorioID)
        {
            return dataTx.EliminarLaboratorio(laboratorioID);
        }
        public string ObtenerSupervisor(int labID)
        {
            return dataNTx.ObtenerSupervisor(labID);
        }
    }

}
