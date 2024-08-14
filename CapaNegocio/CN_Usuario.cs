using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class CN_Usuario
    {
        //Hacemos una instancia a nuestra clase Cd_Usuario de la capa datos 
        private CD_Usuario objcd_usuario = new CD_Usuario();


        //retonamos la misma lista que tiene nuestra clase CD_USUARIO QUE SE ENCUENTRA en la capa de dato
        public List<Usuario> Listar()
        {
    
            return objcd_usuario.Listar();
        }
    }
}
