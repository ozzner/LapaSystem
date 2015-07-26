using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LN_Empresa
    {
        ADNT_Empresa dataNTx = new ADNT_Empresa();
        ADT_Empresa dataTx = new ADT_Empresa();

        public bool InsertarNuevaEmpresa(ENT_Empresa oEnt_Empresa, ENT_Usuario oEnt_Usuario, ref int resultado)
        {
            return dataTx.InsertarNuevaEmpresa(oEnt_Empresa, oEnt_Usuario, ref resultado);
        }

        public List<ENT_Empresa> ListarEmpresa(string ruc)
        {
            return dataNTx.ListarEmpresa(ruc);
        }

        public ENT_Empresa ListarInfoEmpresa(string ruc)
        {
            return dataNTx.ListarInfoEmpresa(ruc);
        }

        public ENT_Empresa ListarPubRaiz(string ruc)
        {
            return dataNTx.ListarPublicidadRaíz(ruc);
        }

        public ENT_Empresa ListarPubInicio1(string ruc)
        {
            return dataNTx.ListarPubInicio1(ruc);
        }

        public ENT_Empresa ListarPubInicio2(string ruc)
        {
            return dataNTx.ListarPubInicio2(ruc);
        }

        public ENT_Empresa ListarPubRepParamEst(string ruc)
        {
            return dataNTx.ListarPubRepParamEst(ruc);
        }

        public ENT_Empresa ListarPubRepAtribEst(string ruc)
        {
            return dataNTx.ListarPubRepAtribEst(ruc);
        }

        public ENT_Empresa ListarPubRepParamStat(string ruc)
        {
            return dataNTx.ListarPubRepParamStat(ruc);
        }

        public ENT_Empresa ListarPubRepAtribStat(string ruc)
        {
            return dataNTx.ListarPubRepAtribStat(ruc);
        }

        public int VerificarRestriccion(int usuarioId, string tipo, int valor)
        {
            return dataNTx.VerificarRestriccion(usuarioId, tipo, valor);
        }

        public bool ActualizarLogoEmpresa(ENT_Empresa oEnt_Empresa)
        {
            return dataTx.ActualizarLogoEmpresa(oEnt_Empresa);
        }

        public bool ActualizarIPEmpresa(string nuevaip, string ruc)
        {
            return dataTx.ActualizarIPEmpresa(nuevaip,ruc);
        }

    }

}
