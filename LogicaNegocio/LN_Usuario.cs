using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LN_Usuario
    {
        ADNT_Usuario dataNTx = new ADNT_Usuario();
        ADT_Usuario dataTx = new ADT_Usuario();

        public bool ValidarUsuario(ENT_Usuario oEnt_Usuario
            , ref int resultado
            , ref int perfil
            , ref string nombrecompleto
            , ref int usuarioid
            , ref int PerfilUsuarioID
            , ref int habilitado
            , ref bool servicio
            , ref string ruc
            , ref int paquete
            , ref int downgrade
            , ref int restriccionip
            , ref string ip
            , ref string idioma
            )
        {
            return dataNTx.ValidarUsuario(oEnt_Usuario
                , ref resultado
                , ref perfil
                , ref nombrecompleto
                , ref usuarioid
                , ref PerfilUsuarioID
                , ref habilitado
                , ref servicio
                , ref ruc
                , ref paquete
                , ref downgrade
                , ref restriccionip
                , ref ip
                , ref idioma
                );

        }

        public List<ENT_Usuario> ListarUsuario(int UsuarioID, int PerfilUsuario)
        {
            return dataNTx.ListarUsuario(UsuarioID, PerfilUsuario);
        }



        public ENT_Usuario obtenerCredenciales(string email)
        {
            return dataNTx.obtenerCredenciales(email);
        }



        public bool EliminarUsuario(int UsuarioID)
        {
            return dataTx.EliminarUsuario(UsuarioID);
        }
        public bool InsertarUsuario(ENT_Usuario oEnt_Usuario, ref int resultado, int UsuarioLogeado,ref int existeSupervisor)
        {
            return dataTx.InsertarUsuario(oEnt_Usuario, ref resultado, UsuarioLogeado, ref existeSupervisor);
        }
        public bool ActualizarUsuario(ENT_Usuario oEnt_Usuario, int Tipo)
        {
            return dataTx.ActualizarUsuario(oEnt_Usuario, Tipo);
        }

    }

}
