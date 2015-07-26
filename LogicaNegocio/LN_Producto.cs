using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LN_Producto
    {
        ADNT_Producto dataNTx = new ADNT_Producto();
        ADT_Producto dataTx = new ADT_Producto();

        public List<ENT_Producto> ListarProducto(int UsuarioID)
        {
            return dataNTx.ListarProducto(UsuarioID);
        }

        public List<ENT_Producto> ListarProductoXLab(string LaboratorioCod)
        {
            return dataNTx.ListarProductoXLab(LaboratorioCod);
        }

        public List<ENT_Producto> ListarProductoXLabID(string LaboratorioID)
        {
            return dataNTx.ListarProductoXLabID(LaboratorioID);
        }

        public List<ENT_Producto> ListarProductoXLabServicio(string ClienteID)
        {
            return dataNTx.ListarProductoXLabServicio(ClienteID);
        }

        public bool AsociarProducto(int ProductoID, string LaboratorioCod, int Tipo, ref int Resultado)
        {
            return dataTx.AsociarProducto(ProductoID, LaboratorioCod, Tipo, ref Resultado);
        }
        
        public bool AsociarProductoCliente(int ProductoID,int ClienteID, string LaboratorioCod)
        {
            return dataTx.AsociarProductoCliente(ProductoID, ClienteID, LaboratorioCod);
        }

        public bool QuitarProdLab(int ProdLabID)
        {
            return dataTx.QuitarProdLab(ProdLabID);
        }


        public bool InsertarProducto(ENT_Producto oEnt_Producto)
        {
            return dataTx.InsertarProducto(oEnt_Producto);
        }
        public bool ActualizarProducto(ENT_Producto oEnt_Producto)
        {
            return dataTx.ActualizarProducto(oEnt_Producto);
        }


        public bool EliminarProducto(string ProductoID)
        {
            return dataTx.EliminarProducto(ProductoID);
        }

        //AGREGADO
        public List<ENT_Producto> ListarProductoLab(string LaboratorioCod)
        {
            return dataNTx.ListarProductoLab(LaboratorioCod);
        }

    }

}
