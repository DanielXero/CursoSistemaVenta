using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Permiso
    {
        //Hacemos una instancia a nuestra clase Cd_Usuario de la capa datos 
        private CD_Permiso objcd_permiso = new CD_Permiso();


        //retonamos la misma lista que tiene nuestra clase CD_USUARIO QUE SE ENCUENTRA en la capa de dato
        public List<Permiso> Listar(int IdUsuario)
        {

            return objcd_permiso.Listar(IdUsuario); 
        }
    }
}
