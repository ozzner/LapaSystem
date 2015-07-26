using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LN_RegistroTemporal
    {
        ADNT_RegistroTemporal dataNTx = new ADNT_RegistroTemporal();
        ADT_RegistroTemporal dataTx = new ADT_RegistroTemporal();

        public bool InsertarRegistroTemporal(ENT_RegistroTemporal oEnt_Atr, ref string Serial, ref int ExisteDominio)
        {
            return dataTx.InsertarRegistroTemporal(oEnt_Atr, ref Serial, ref ExisteDominio);
        }

        public List<ENT_RegistroTemporal> VerificarSerial(string serial, ref int resultado)
        {
            return dataNTx.VerificarSerial(serial, ref resultado);

        }

        public int VerificarCorreo(string regcorreo, ref int resultado)
        {
            return dataNTx.VerificarCorreo(regcorreo, ref resultado);

        }

    }

}
