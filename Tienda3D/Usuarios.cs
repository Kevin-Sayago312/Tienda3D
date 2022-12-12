using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tienda3D
{
    public partial class Usuarios : Form
    {
        private int borderRadius = 30;
        private int borderSize = 2;
        private Color borderColor = Color.Transparent;

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        MySqlConnection conn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;
        public void conectar()
        {
            conn.ConnectionString = "Server= localhost; Database= Tienda3D; user = root; password= root; ";
            conn.Open();
            //MessageBox.Show("Estas conectado ¡YAY!");
        }
        public void desconectar()
        {
            conn.Close();
        }
        public Usuarios()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
        }
        MySqlConnection conexion = new MySqlConnection("Server= localhost; Database= Tienda3D; user = root; password= root; ");

        public string nombreusuario
        {
            get;
            set;
        }
        public void ConsultarPuesto()
        {
            try
            {
                conectar();
                string query = "SELECT tipo FROM usuarios WHERE ID_User= ('" + lblID.Text + "');";
                cmd = new MySqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblRol.Text = reader[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            string consulta = "SELECT * FROM usuarios";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataUsuarios.DataSource = dt;

            //invoca el ID del usuario
            lblID.Text = string.Format("{0}", nombreusuario);
            ConsultarPuesto(); // Consulta el puesto y pone que puesto tiene el usuario
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                conectar();
                cmd = new MySqlCommand("ADDUsuarios", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _ID_User = new MySqlParameter("_ID_User", MySqlDbType.VarChar, 5);
                _ID_User.Value = txtIDUsuario.Text;
                cmd.Parameters.Add(_ID_User);
                MySqlParameter _tipo = new MySqlParameter("_tipo", MySqlDbType.Enum);
                _tipo.Value = comboTipo.Text;
                cmd.Parameters.Add(_tipo);
                MySqlParameter _contraseña = new MySqlParameter("_contraseña", MySqlDbType.VarChar, 16);
                _contraseña.Value = txtContraseña.Text;
                cmd.Parameters.Add(_contraseña);
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Datos del usuario guardados correctamente!");
                llenar_grid();
                txtContraseña.Clear();
                txtIDUsuario.Clear();
                comboTipo.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                conectar();
                cmd = new MySqlCommand("DeleteUsuarios", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _ID_User = new MySqlParameter("_ID_User", MySqlDbType.VarChar, 5);
                _ID_User.Value = txtIDUsuario.Text;
                cmd.Parameters.Add(_ID_User);
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Datos del usuario eliminados correctamente!");
                llenar_grid();
                txtContraseña.Clear();
                txtIDUsuario.Clear();
                comboTipo.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                conectar();
                cmd = new MySqlCommand("UpdateUsuarios", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _ID_User = new MySqlParameter("_ID_User", MySqlDbType.VarChar, 5);
                _ID_User.Value = txtIDUsuario.Text;
                cmd.Parameters.Add(_ID_User);
                MySqlParameter _tipo = new MySqlParameter("_tipo", MySqlDbType.Enum);
                _tipo.Value = comboTipo.Text;
                cmd.Parameters.Add(_tipo);
                MySqlParameter _contraseña = new MySqlParameter("_contraseña", MySqlDbType.VarChar, 16);
                _contraseña.Value = txtContraseña.Text;
                cmd.Parameters.Add(_contraseña);
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Datos del usuario actualizados correctamente!");
                llenar_grid();
                txtContraseña.Clear();
                txtIDUsuario.Clear();
                comboTipo.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                conectar();
                cmd = new MySqlCommand("BuscarUsuarios", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _ID_User = new MySqlParameter("_ID_User", MySqlDbType.VarChar, 5);
                _ID_User.Value = txtIDUsuario.Text;
                cmd.Parameters.Add(_ID_User);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    comboTipo.Text = reader[1].ToString();
                    txtContraseña.Text = reader[2].ToString();
                }
                else
                {
                    MessageBox.Show("¡Este usuario no existe!");
                    txtContraseña.Clear();
                    txtIDUsuario.Clear();
                    comboTipo.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                desconectar();
            }
        }


        private void Usuarios_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //metodos privados
        private GraphicsPath GetRoundedPath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
        private void FormRegionAndBorder(Form form, float radius, Graphics graph, Color borderColor, float borderSize)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundPath = GetRoundedPath(form.ClientRectangle, radius))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                using (Matrix transform = new Matrix())
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    form.Region = new Region(roundPath);
                    if (borderSize >= 1)
                    {
                        Rectangle rect = form.ClientRectangle;
                        float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize + 1) / rect.Height);
                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 1.6F, borderSize / 1.6F);
                        graph.Transform = transform;
                        graph.DrawPath(penBorder, roundPath);
                    }
                }
            }
        }

        private void Usuarios_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void btnRegresarMenu_Click(object sender, EventArgs e)
        {
            try
            {
                conectar();
                //Creo una consulta para saber si existe
                string query = "Select ID_User From Usuarios Where ID_User = ('" + lblID.Text + "'); ";
                cmd = new MySqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();
                if (reader.Read())// Si existe el usuario
                {
                    Form2 x = new Form2();
                    x.nombreusuario = lblID.Text;
                    this.Hide();
                    x.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtContraseña.Clear();
            comboTipo.Text = "";
            txtIDUsuario.Clear();
        }

        private void txtIDUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void comboTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 254))
            {
                MessageBox.Show("Solo letras y números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void validarcampo()
        {
            var vr = !string.IsNullOrEmpty(txtContraseña.Text) && !string.IsNullOrEmpty(txtIDUsuario.Text) && !string.IsNullOrEmpty(comboTipo.Text);
            btnAgregar.Enabled = vr;
            btnEliminar.Enabled = vr;
            btnEditar.Enabled = vr;
        }

        private void txtIDUsuario_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void comboTipo_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void picMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dataUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIDUsuario.Text = dataUsuarios.SelectedCells[0].Value.ToString();
            comboTipo.Text = dataUsuarios.SelectedCells[1].Value.ToString();
            txtContraseña.Text = dataUsuarios.SelectedCells[2].Value.ToString();
        }
        public void llenar_grid()
        {
            string consulta = "SELECT * FROM usuarios";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataUsuarios.DataSource = dt;
        }
        DataTable dt = new DataTable();
        MySqlDataAdapter da = new MySqlDataAdapter();
        private void comboBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtbusqueda1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                conectar();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM usuarios Where (" + comboBusqueda.Text + ") LIKE ('" + txtbusqueda1.Text + "%')";
                cmd.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataUsuarios.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                desconectar();

            }
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 254))
            {
                MessageBox.Show("Solo letras y números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
