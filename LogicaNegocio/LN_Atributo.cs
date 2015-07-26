using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{   
    public class LN_Atributo
    {
        ADNT_Atributo dataNTx = new ADNT_Atributo();
        ADT_Atributo dataTx = new ADT_Atributo();

        public bool AsociarAtributo(int AtributoID, string ProdLabID, int Tipo, ref int resultado)
        {
            return dataTx.AsociarAtributo(AtributoID, ProdLabID, Tipo, ref resultado);
        }

        public bool GuardarCambios(List<ENT_ProductoAtributo> oEnt_ProdAttr, int ProdAttrID)
        {
            return dataTx.GuardarCambios(oEnt_ProdAttr, ProdAttrID);
        }

        public bool QuitarAtributo(int ProdAtriID)
        {
            return dataTx.QuitarAtributo(ProdAtriID);
        }

        public List<ENT_Atributo> ListarAtributo(int UsuarioID)
        {
            return dataNTx.ListarAtributo(UsuarioID);
        }

        public List<ENT_Atributo> ListarAtributosLab(string LaboratorioCod)
        {
            return dataNTx.ListarAtributosLab(LaboratorioCod);
        }

        public List<ENT_Atributo> ListarAtributoXLab(string ProdLabCod)
        {
            return dataNTx.ListarAtributoXLab(ProdLabCod);
        }

        public List<ENT_ProductoAtributo> ListarProdAttr(int AtributoID)
        {
            return dataNTx.ListarProdAttr(AtributoID);
        }

        public bool InsertarAtributo(ENT_Atributo oEnt_Atributo)
        {
            return dataTx.InsertarAtributo(oEnt_Atributo);
        }


        public bool ActualizarAtributo(ENT_Atributo oEnt_Atributo) {
            return dataTx.ActualizarAtributo(oEnt_Atributo);
        }

        public bool EliminarAtributo(int AtributoID)
        {
            return dataTx.EliminarAtributo(AtributoID);
        }


        //public List<ENT_Atributo> ListarAtributoXLabServicio(string ClienteID)
        //{
        //    return dataNTx.ListarAtributoXLabServicio(ClienteID);
        //}






    }

}
