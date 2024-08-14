using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CapaDatos
{
    public class Conexion
    {
        //Esta clase de conexion sera la encargada de mandarle a la demas clases la cadena de conexion que tenemos alamecada en nuetro archivo app.conf
        //Agregamos la referencia System.Configuration
        public static string cadena = ConfigurationManager.ConnectionStrings["cadena_conexion"].ToString();
    }
}
