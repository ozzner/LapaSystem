using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LN_Cliente
    {
        ADNT_Cliente dataNTx = new ADNT_Cliente();
        ADT_Cliente dataTx = new ADT_Cliente();


        public bool ActualizarContacto(string cadenaXML, int ClienteID){
            return dataTx.ActualizarContacto(cadenaXML, ClienteID);
        
        }
        public bool EliminarCliente(int ClienteID)
        {
            return dataTx.EliminarCliente(ClienteID);
        
        }
        public ENT_Cliente ObtenerCliente(string ProdLabCod)
        {
            return dataTx.ObtenerCliente(ProdLabCod);
        }
        public List<ENT_Cliente> ListarClientesXLab(string LaboratorioCod)
        {

            return dataNTx.ListarClientesXLab(LaboratorioCod);

        }
        public List<ENT_Cliente> ListarClientesXEmpresa(int UsuarioID)
        {
            return dataNTx.ListarClientesXEmpresa(UsuarioID);
        }

        public List<ENT_Cliente> listarDatosCliente(int ClienteID)
        {
            return dataNTx.ListarDatosCliente(ClienteID);
        }
        public bool InsertarCliente(string NomCliente, int UsuarioID)
        {

            return dataTx.InsertarCliente(NomCliente, UsuarioID);
        }

        public bool ActualizarDatos(ENT_Cliente oEnt_Cliente){
            return dataTx.ActualizarDatos(oEnt_Cliente);
        }

    }

}
