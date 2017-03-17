﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BiblioTechProject.UI.Registros
{
    public partial class FrmRegistroUsuarios : Form
    {
        private static FrmRegistroUsuarios formulario = null;
        private Entidades.Usuario usuario = null;

        private FrmRegistroUsuarios()
        {
            InitializeComponent();
        }

        public static FrmRegistroUsuarios GetInstance()
        {
            if (formulario == null)
            {
                formulario = new FrmRegistroUsuarios();
            }
            return formulario;
        }

        private void FrmRegistroUsuarios_Load(object sender, EventArgs e)
        {
            cargoComboBox.Text = "Bibliotecario";
            DeshabilidarCamposMenosId();
        }

        private void Limpiar()
        {
            usuario = null;
            usuarioIdTextBox.Clear();
            nombreTextBox.Clear();
            nombreUsuarioTextBox.Clear();
            contrasenaTextBox.Clear();
            confirmarContrasenaTextBox.Clear();
            DeshabilitarModificarBorrar();
        }

        private bool Validar()
        {
            bool flag = true;
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text))
            {
                nombreErrorProvider.SetError(nombreTextBox, "Digite el nombre");
                flag = false;
            }
            if (string.IsNullOrWhiteSpace(nombreUsuarioTextBox.Text))
            {
                usuarioErrorProvider.SetError(nombreUsuarioTextBox, "Digite el nombre de usuario");
                flag = false;
            }
            if (string.IsNullOrWhiteSpace(contrasenaTextBox.Text))
            {
                contrasenaErrorProvider.SetError(contrasenaTextBox, "Digite la contraseña");
                flag = false;
            }
            if (string.IsNullOrWhiteSpace(confirmarContrasenaTextBox.Text))
            {
                confirmarContrasenaErrorProvider.SetError(confirmarContrasenaTextBox, "Confirme la contraseña");
                flag = false;
            }
            else if(confirmarContrasenaTextBox.Text != contrasenaTextBox.Text)
            {
                confirmarContrasenaErrorProvider.SetError(confirmarContrasenaTextBox, "Las contraseñas no coinciden");
                flag = false;
            }
            return flag;
        }

        private void LlenarCamposInstancia()
        {
            usuario = new Entidades.Usuario(Utilidad.ToInt(usuarioIdTextBox.Text), nombreTextBox.Text, nombreUsuarioTextBox.Text, contrasenaTextBox.Text, cargoComboBox.Text);
        }

        private void PonerEstadosInvisibles()
        {
            guardadoToolStripStatusLabel.Visible = false;
            ErrorToolStripStatusLabel.Visible = false;
            noEncontradoToolStripStatusLabel.Visible = false;
            eliminadoToolStripStatusLabel.Visible = false;
        }

        private void HabilitarModificarBorrar()
        {
            eliminarButton.Enabled = true;
            modificarButton.Enabled = true;
        }

        private void DeshabilitarModificarBorrar()
        {
            eliminarButton.Enabled = false;
            modificarButton.Enabled = false;
        }

        private void HabDeshabBuscar()
        {
            if (string.IsNullOrWhiteSpace(usuarioIdTextBox.Text))
            {
                buscarButton.Enabled = false;
            }
            else
            {
                buscarButton.Enabled = true;
            }
        }

        private void DeshabilidarCamposMenosId()
        {
            nombreTextBox.ReadOnly = true;
            nombreUsuarioTextBox.ReadOnly = true;
            contrasenaTextBox.ReadOnly = true;
            confirmarContrasenaTextBox.ReadOnly = true;
            cargoComboBox.Enabled = false;
        }

        private void HabilidarCamposMenosId()
        {
            nombreTextBox.ReadOnly = false;
            nombreUsuarioTextBox.ReadOnly = false;
            contrasenaTextBox.ReadOnly = false;
            confirmarContrasenaTextBox.ReadOnly = false;
            cargoComboBox.Enabled = true;
        }

        /*private void LimpiarErrorProviders()
        {
            nombreErrorProvider.Clear();
            usuarioErrorProvider.Clear();
            contrasenaErrorProvider.Clear();
            confirmarContrasenaErrorProvider.Clear();
        }*/
        
        private void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
            HabilidarCamposMenosId();
            nombreTextBox.Focus();
            PonerEstadosInvisibles();
            //DeshabilitarModificarBorrar();
        }
        
        private void guardarButton_Click(object sender, EventArgs e)
        {
            PonerEstadosInvisibles();
            if (!nombreTextBox.ReadOnly)
            {
                if (Validar())
                {
                    LlenarCamposInstancia();
                    usuario = BLL.UsuarioBLL.Guardar(usuario); //lo igualo por si retorna null, aunque la instancia cuando vuelve de guardarse viene con su id incluido
                    if (usuario != null)
                    {
                        usuarioIdTextBox.Text = usuario.UsuarioId.ToString();
                        /*string contrasena = "";
                        foreach (char item in usuario.Contrasena)
                        {
                            contrasena += "☻";
                        }
                        contrasenaTextBox.Text = contrasena;
                        confirmarContrasenaTextBox.Text = contrasena;*/
                        guardadoToolStripStatusLabel.Visible = true;
                        DeshabilidarCamposMenosId();
                        HabilitarModificarBorrar();
                    }
                    else
                    {
                        ErrorToolStripStatusLabel.Visible = true;
                    }
                }
            }
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            PonerEstadosInvisibles();
            //if (!string.IsNullOrWhiteSpace(usuarioIdTextBox.Text))
            //{
            //usuario = BLL.UsuarioBLL.Buscar(U => U.UsuarioId == Utilidad.ToInt(usuarioIdTextBox.Text));
            if (usuario != null)
            {
                DialogResult opcionEliminar = MessageBox.Show("¿Seguro que desea eliminar el registro seleccionado?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (opcionEliminar == DialogResult.Yes)
                {
                    //Poner a que no se borre el usuario logueado, ni el ultimo usuario admin
                    if (BLL.UsuarioBLL.Eliminar(usuario))
                    {
                        Limpiar();
                        //DeshabilitarModificarBorrar();
                        eliminadoToolStripStatusLabel.Visible = true;
                    }
                    else
                    {
                        ErrorToolStripStatusLabel.Visible = true;
                    }
                }                
            }
            /*else
            {
                noEncontradoToolStripStatusLabel.Visible = true;
            }*/
            //}
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            PonerEstadosInvisibles();
            int id = Utilidad.ToInt(usuarioIdTextBox.Text);
            DeshabilidarCamposMenosId();
            Limpiar();
            usuario = BLL.UsuarioBLL.Buscar(U => U.UsuarioId == id);
            if (usuario != null)
            {
                usuarioIdTextBox.Text = usuario.UsuarioId.ToString();
                nombreTextBox.Text = usuario.Nombre;
                nombreUsuarioTextBox.Text = usuario.NombreUsuario;
                /*string contrasena = "";
                foreach (char item in usuario.Contrasena)
                {
                    contrasena += "☻";
                }
                contrasenaTextBox.Text = contrasena;
                confirmarContrasenaTextBox.Text = contrasena;*/
                cargoComboBox.Text = usuario.Cargo;
                HabilitarModificarBorrar();
            }
            else
            {
                noEncontradoToolStripStatusLabel.Visible = true;
            }            
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            PonerEstadosInvisibles();
            HabilidarCamposMenosId();
        }

        private void usuarioIdTextBox_TextChanged(object sender, EventArgs e)
        {
            PonerEstadosInvisibles();
            HabDeshabBuscar();
        }

        private void nombreTextBox_TextChanged(object sender, EventArgs e)
        {
            nombreErrorProvider.Clear();
            //PonerEstadosInvisibles();
        }

        private void nombreUsuarioTextBox_TextChanged(object sender, EventArgs e)
        {
            usuarioErrorProvider.Clear();
            //PonerEstadosInvisibles();
        }

        private void contrasenaTextBox_TextChanged(object sender, EventArgs e)
        {
            contrasenaErrorProvider.Clear();
            //PonerEstadosInvisibles();
        }

        private void confirmarContrasenaTextBox_TextChanged(object sender, EventArgs e)
        {
            confirmarContrasenaErrorProvider.Clear();
            //PonerEstadosInvisibles();
        }

        private void cargoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PonerEstadosInvisibles();
        }
                
        private void RegistroUsuariosStatusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmRegistroUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            formulario = null;
        }
        
    }
}
