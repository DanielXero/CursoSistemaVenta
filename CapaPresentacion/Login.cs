using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            List<Usuario> TEST = new CN_Usuario().Listar();
            //Llamamos el meetodo de listar pero desde nuetra capa de negocio
            //Para que pueda listar debe registrarse infomracion en nuestra base datos
            //Recuperamos un usuario de esta lista para ello utilizamos expresiones lambda
            Usuario ousuario = new CN_Usuario().Listar().Where(u => u.Documento == txtdocumento.Text && u.Clave == txtclave.Text).FirstOrDefault();
            //Esta expresion lambda es para que no devuelva aquel usuario que tenga un documento y clave similar a lo que estamos escribiendo en nuestra caja de texto
            // y con el método FirstOrDefault que retorne siempre el primero o sino un default 

            //Validamos en caso de que se encuentre un ususario le va a permitir loguearse caso contrario le va a mostrar un exception
            if(ousuario != null)
            {
                Inicio form = new Inicio(ousuario);
                form.Show();// Mostramos el formulario de inicio
                this.Hide();// ocultamos el login


                form.FormClosing += frm_clossing;
            } else
            {
                MessageBox.Show("No se econtro el usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            
        }

        //Este método lo utilizo para mostrar el formulario de login una vez que se cierra el formulario de inicio
        private void frm_clossing(object sender, EventArgs e)
        {
            txtdocumento.Text = "";
            txtclave.Text = "";
            this.Show();
        }
    }
}
