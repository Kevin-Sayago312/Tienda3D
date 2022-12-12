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
    public partial class Proveedores : Form
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
        public Proveedores()
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

        private void Proveedores_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            string consulta = "SELECT * FROM proveedor";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataProveedores.DataSource = dt;

            //invoca el ID del usuario
            lblID.Text = string.Format("{0}", nombreusuario);
            ConsultarPuesto(); // Consulta el puesto y pone que puesto tiene el usuario
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                conectar();
                cmd = new MySqlCommand("ADDProveedor", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _ID_Proveedor = new MySqlParameter("_ID_Proveedor", MySqlDbType.VarChar, 5);
                _ID_Proveedor.Value = txtIDProveedor.Text;
                cmd.Parameters.Add(_ID_Proveedor);
                MySqlParameter _nombre = new MySqlParameter("_nombre", MySqlDbType.VarChar, 100);
                _nombre.Value = txtNombre.Text;
                cmd.Parameters.Add(_nombre);
                MySqlParameter _telefono = new MySqlParameter("_telefono", MySqlDbType.VarChar, 10);
                _telefono.Value = txtTelefono.Text;
                cmd.Parameters.Add(_telefono);
                MySqlParameter _email = new MySqlParameter("_email", MySqlDbType.VarChar, 100);
                _email.Value = txtEmail.Text;
                cmd.Parameters.Add(_email);
                MySqlParameter _direccion = new MySqlParameter("_direccion", MySqlDbType.VarChar, 200);
                _direccion.Value = txtDireccion.Text;
                cmd.Parameters.Add(_direccion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Datos del proveedor guardados correctamente!");
                llenar_grid();
                txtIDProveedor.Clear();
                txtEmail.Clear();
                txtDireccion.Clear();
                txtNombre.Clear();
                txtDireccion.Clear();
                txtTelefono.Clear();
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
                cmd = new MySqlCommand("DeleteProveedor", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _ID_Proveedor = new MySqlParameter("_ID_Proveedor", MySqlDbType.VarChar, 5);
                _ID_Proveedor.Value = txtIDProveedor.Text;
                cmd.Parameters.Add(_ID_Proveedor);
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Datos del proveedor eliminados correctamente!");
                llenar_grid();
                txtIDProveedor.Clear();
                txtEmail.Clear();
                txtDireccion.Clear();
                txtNombre.Clear();
                txtDireccion.Clear();
                txtTelefono.Clear();
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
                cmd = new MySqlCommand("UpdateProveedor", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _ID_Proveedor = new MySqlParameter("_ID_Proveedor", MySqlDbType.VarChar, 5);
                _ID_Proveedor.Value = txtIDProveedor.Text;
                cmd.Parameters.Add(_ID_Proveedor);
                MySqlParameter _nombre = new MySqlParameter("_nombre", MySqlDbType.VarChar, 100);
                _nombre.Value = txtNombre.Text;
                cmd.Parameters.Add(_nombre);
                MySqlParameter _telefono = new MySqlParameter("_telefono", MySqlDbType.VarChar, 10);
                _telefono.Value = txtTelefono.Text;
                cmd.Parameters.Add(_telefono);
                MySqlParameter _email = new MySqlParameter("_email", MySqlDbType.VarChar, 100);
                _email.Value = txtEmail.Text;
                cmd.Parameters.Add(_email);
                MySqlParameter _direccion = new MySqlParameter("_direccion", MySqlDbType.VarChar, 200);
                _direccion.Value = txtDireccion.Text;
                cmd.Parameters.Add(_direccion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Datos del proveedor actualizados correctamente!");
                llenar_grid();
                txtIDProveedor.Clear();
                txtEmail.Clear();
                txtDireccion.Clear();
                txtNombre.Clear();
                txtDireccion.Clear();
                txtTelefono.Clear();
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
                cmd = new MySqlCommand("BuscarProveedor", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _ID_Proveedor = new MySqlParameter("_ID_Proveedor", MySqlDbType.VarChar, 5);
                _ID_Proveedor.Value = txtIDProveedor.Text;
                cmd.Parameters.Add(_ID_Proveedor);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtNombre.Text = reader[1].ToString();
                    txtTelefono.Text = reader[2].ToString();
                    txtEmail.Text = reader[3].ToString();
                    txtDireccion.Text = reader[4].ToString();
                }
                else
                {
                    MessageBox.Show("¡Este proveedor no existe!");
                    txtIDProveedor.Clear();
                    txtEmail.Clear();
                    txtDireccion.Clear();
                    txtNombre.Clear();
                    txtDireccion.Clear();
                    txtTelefono.Clear();
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

        private void Proveedores_MouseDown(object sender, MouseEventArgs e)
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

        private void Proveedores_Paint(object sender, PaintEventArgs e)
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
            txtDireccion.Clear();
            txtEmail.Clear();
            txtIDProveedor.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
        }

        private void txtIDProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
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
            var vr = !string.IsNullOrEmpty(txtDireccion.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtIDProveedor.Text) && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtTelefono.Text);
            btnAgregar.Enabled = vr;
            btnEliminar.Enabled = vr;
            btnEditar.Enabled = vr;
        }

        private void txtIDProveedor_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void picMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dataProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIDProveedor.Text = dataProveedores.SelectedCells[0].Value.ToString();
            txtNombre.Text = dataProveedores.SelectedCells[1].Value.ToString();
            txtTelefono.Text = dataProveedores.SelectedCells[2].Value.ToString();
            txtEmail.Text = dataProveedores.SelectedCells[3].Value.ToString();
            txtDireccion.Text = dataProveedores.SelectedCells[4].Value.ToString();
        }
        public void llenar_grid()
        {
            string consulta = "SELECT * FROM proveedor";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataProveedores.DataSource = dt;
        }

        private void comboBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        DataTable dt = new DataTable();
        MySqlDataAdapter da = new MySqlDataAdapter();
        private void txtbusqueda1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                conectar();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM proveedor Where (" + comboBusqueda.Text + ") LIKE ('" + txtbusqueda1.Text + "%')";
                cmd.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataProveedores.DataSource = dt;

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
