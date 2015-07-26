using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LN_Parametro
    {
        ADNT_Parametro dataNTx = new ADNT_Parametro();
        ADT_Parametro dataTx = new ADT_Parametro();


        public bool CompletarDatosParametro(ENT_ProductoParametro oEntidad)
        {
            return dataTx.CompletarDatosParametro(oEntidad);
        }

        public ENT_ProductoParametro ObtenerDatosParametro(string ProdParaCod)
        {
            return dataNTx.ObtenerDatosParametro(ProdParaCod);
        }

        public ENT_ProductoParametro ObtenerDatosParam(int ProdParaID)
        {
            return dataNTx.ObtenerDatosParam(ProdParaID);
        }

        public List<ENT_Parametro> ObtenerDatosMuestraParametro(string ProdParaCod)
        {
            return dataNTx.ObtenerDatosMuestraParametro(ProdParaCod);
        }


        public ENT_Parametro ObtenerLab(string ProdParaCod)
        {
            return dataNTx.ObtenerLab(ProdParaCod);
        }

        public List<ENT_Parametro> ListarParametro(int UsuarioID)
        {
            return dataNTx.ListarParametro(UsuarioID);
        }

        public bool DeshabilitaFlProdParam(string ProdLabCod)
        {
            return dataTx.DeshabilitaFlProdParam(ProdLabCod);
        }
        public bool ActualizarProdParam(string ProdLabCod, string param)
        {
            return dataTx.ActualizarProdParam(ProdLabCod, param);
        }

        public List<ENT_Parametro> ListarParametroXEquipo(int EquipoID)
        {
            return dataNTx.ListarParametroXEquipo(EquipoID);
        }

        //oLN_Parametro.AsociarParametro(Int32.Parse(li.Value), Int32.Parse(Session["ProdParaID"].ToString()), 1, ref resultado);
        public bool AsociarParametro(int ParametroID, string ProdLabID, int Tipo, ref int resultado)
        {
            return dataTx.AsociarParametro(ParametroID, ProdLabID, Tipo, ref resultado);
        }

        public List<ENT_ProductoParametro> ListarParametroXLab(string ProdLabCod)
        {
            return dataNTx.ListarParametroXLab(ProdLabCod);
        }


        public List<ENT_ProductoAtributo> ListarAtributoXLab(string ProdLabCod)
        {
            return dataNTx.ListarAtributoXLab(ProdLabCod);
        }


        public List<ENT_ProductoParametro> ListarParametrosLab(string LaboratorioCod)
        {
            return dataNTx.ListarParametrosLab(LaboratorioCod);
        }

        public List<ENT_Cliente> ListarClientesLab(string LaboratorioCod)
        {
            return dataNTx.ListarClientesLab(LaboratorioCod);
        }

        public bool QuitarProdPara(int ProdParaID)
        {
            return dataTx.QuitarProdPara(ProdParaID);
        }


        public bool QuitarParametroEquipo(int ParEqpID)
        {
            return dataTx.QuitarParametroEquipo(ParEqpID);
        }

        public bool InsertarParametroEquipo(int ParametroID, int EquipoID)
        {
            return dataTx.InsertarParametroEquipo(ParametroID, EquipoID);
        }


        public bool InsertarParametro(ENT_Parametro oEnt_Parametro)
        {
            return dataTx.InsertarParametro(oEnt_Parametro);
        }



        public bool ActualizarParametro(ENT_Parametro oEnt_Parametro)
        {
            return dataTx.ActualizarParametro(oEnt_Parametro);
        }


        public bool EliminarParametro(string ParametroID)
        {
            return dataTx.EliminarParametro(ParametroID);
        }


    }

}
