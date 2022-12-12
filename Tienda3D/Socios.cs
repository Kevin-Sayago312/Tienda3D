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
    public partial class Socios : Form
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
        public Socios()
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
        private void Socios_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            string consulta = "SELECT * FROM socio";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataSocios.DataSource = dt;

            //invoca el ID del usuario
            lblID.Text = string.Format("{0}", nombreusuario);
            ConsultarPuesto(); // Consulta el puesto y pone que puesto tiene el usuario
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                conectar();
                cmd = new MySqlCommand("ADDSocio", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _clave = new MySqlParameter("_clave", MySqlDbType.VarChar, 5);
                _clave.Value = txtClave.Text;
                cmd.Parameters.Add(_clave);
                MySqlParameter _nombre = new MySqlParameter("_nombre", MySqlDbType.VarChar, 100);
                _nombre.Value = txtNombre.Text;
                cmd.Parameters.Add(_nombre);
                MySqlParameter _paterno = new MySqlParameter("_paterno", MySqlDbType.VarChar, 100);
                _paterno.Value = txtPaterno.Text;
                cmd.Parameters.Add(_paterno);
                MySqlParameter _materno = new MySqlParameter("_materno", MySqlDbType.VarChar, 100);
                _materno.Value = txtMaterno.Text;
                cmd.Parameters.Add(_materno);
                MySqlParameter _domicilio = new MySqlParameter("_domicilio", MySqlDbType.VarChar, 200);
                _domicilio.Value = txtDomicilio.Text;
                cmd.Parameters.Add(_domicilio);
                MySqlParameter _email = new MySqlParameter("_email", MySqlDbType.VarChar, 100);
                _email.Value = txtEmail.Text;
                cmd.Parameters.Add(_email);
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Datos del socio guardados correctamente!");
                llenar_grid();
                txtClave.Clear();
                txtEmail.Clear();
                txtMaterno.Clear();
                txtNombre.Clear();
                txtPaterno.Clear();
                txtDomicilio.Clear();
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
                cmd = new MySqlCommand("DeleteSocio", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _clave = new MySqlParameter("_clave", MySqlDbType.VarChar, 5);
                _clave.Value = txtClave.Text;
                cmd.Parameters.Add(_clave);
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Datos del socio eliminados correctamente!");
                llenar_grid();
                txtClave.Clear();
                txtEmail.Clear();
                txtMaterno.Clear();
                txtNombre.Clear();
                txtPaterno.Clear();
                txtDomicilio.Clear();
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
                cmd = new MySqlCommand("UpdateSocio", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _clave = new MySqlParameter("_clave", MySqlDbType.VarChar, 5);
                _clave.Value = txtClave.Text;
                cmd.Parameters.Add(_clave);
                MySqlParameter _nombre = new MySqlParameter("_nombre", MySqlDbType.VarChar, 100);
                _nombre.Value = txtNombre.Text;
                cmd.Parameters.Add(_nombre);
                MySqlParameter _paterno = new MySqlParameter("_paterno", MySqlDbType.VarChar, 100);
                _paterno.Value = txtPaterno.Text;
                cmd.Parameters.Add(_paterno);
                MySqlParameter _materno = new MySqlParameter("_materno", MySqlDbType.VarChar, 100);
                _materno.Value = txtMaterno.Text;
                cmd.Parameters.Add(_materno);
                MySqlParameter _domicilio = new MySqlParameter("_domicilio", MySqlDbType.VarChar, 200);
                _domicilio.Value = txtDomicilio.Text;
                cmd.Parameters.Add(_domicilio);
                MySqlParameter _email = new MySqlParameter("_email", MySqlDbType.VarChar, 100);
                _email.Value = txtEmail.Text;
                cmd.Parameters.Add(_email);
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Datos del socio actualizados correctamente!");
                llenar_grid();
                txtClave.Clear();
                txtEmail.Clear();
                txtMaterno.Clear();
                txtNombre.Clear();
                txtPaterno.Clear();
                txtDomicilio.Clear();
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
                cmd = new MySqlCommand("BuscarSocio", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _clave = new MySqlParameter("_clave", MySqlDbType.VarChar, 5);
                _clave.Value = txtClave.Text;
                cmd.Parameters.Add(_clave);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtNombre.Text = reader[1].ToString();
                    txtPaterno.Text = reader[2].ToString();
                    txtMaterno.Text = reader[3].ToString();
                    txtDomicilio.Text = reader[4].ToString();
                    txtEmail.Text = reader[5].ToString();
                }
                else
                {
                    MessageBox.Show("¡Este socio no existe!");
                    txtClave.Clear();
                    txtEmail.Clear();
                    txtMaterno.Clear();
                    txtNombre.Clear();
                    txtPaterno.Clear();
                    txtDomicilio.Clear();
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form2 x = new Form2();
            x.Show();
            this.Hide();
        }

        private void Socios_MouseDown(object sender, MouseEventArgs e)
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

        private void Socios_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
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
            txtClave.Clear();
            txtDomicilio.Clear();
            txtEmail.Clear();
            txtMaterno.Clear();
            txtNombre.Clear();
            txtPaterno.Clear();
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtMaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtDomicilio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void validarcampo()
        {
            var vr = !string.IsNullOrEmpty(txtClave.Text) && !string.IsNullOrEmpty(txtDomicilio.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtMaterno.Text) && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtPaterno.Text);
            btnAgregar.Enabled = vr;
            btnEliminar.Enabled = vr;
            btnEditar.Enabled = vr;
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtPaterno_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtMaterno_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtDomicilio_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void picMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dataSocios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtClave.Text = dataSocios.SelectedCells[0].Value.ToString();
            txtNombre.Text = dataSocios.SelectedCells[1].Value.ToString();
            txtPaterno.Text = dataSocios.SelectedCells[2].Value.ToString();
            txtMaterno.Text = dataSocios.SelectedCells[3].Value.ToString();
            txtDomicilio.Text = dataSocios.SelectedCells[4].Value.ToString();
            txtEmail.Text = dataSocios.SelectedCells[5].Value.ToString();
        }
        public void llenar_grid()
        {
            string consulta = "SELECT * FROM socio";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataSocios.DataSource = dt;
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
                cmd.CommandText = "SELECT * FROM socio Where (" + comboBusqueda.Text + ") LIKE ('" + txtbusqueda1.Text + "%')";
                cmd.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataSocios.DataSource = dt;

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
