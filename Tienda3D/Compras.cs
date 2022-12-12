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
using MySql.Data.MySqlClient;

namespace Tienda3D
{
    public partial class Compras : Form
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

        MySqlConnection conexion = new MySqlConnection("Server= localhost; Database= Tienda3D; user = root; password= root; ");
        public Compras()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
        }
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

        private void Compras_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            string consulta = "SELECT * FROM compra";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataCompra.DataSource = dt;

            //invoca el ID del usuario
            lblID.Text = string.Format("{0}", nombreusuario);
            ConsultarPuesto(); // Consulta el puesto y pone que puesto tiene el usuario
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                conectar();
                cmd = new MySqlCommand("ADDCompra", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _folio = new MySqlParameter("_folio", MySqlDbType.VarChar, 5);
                _folio.Value = txtFolio.Text;
                cmd.Parameters.Add(_folio);
                MySqlParameter _fecha = new MySqlParameter("_fecha", MySqlDbType.DateTime);
                _fecha.Value = Convert.ToDateTime(maskedFecha.Text);
                cmd.Parameters.Add(_fecha);
                MySqlParameter _monto = new MySqlParameter("_monto", MySqlDbType.Int64);
                _monto.Value = txtMonto.Text;
                cmd.Parameters.Add(_monto);
                MySqlParameter _claveF = new MySqlParameter("_claveF", MySqlDbType.VarChar, 5);
                _claveF.Value = txtClave_socio.Text;
                cmd.Parameters.Add(_claveF);
                MySqlParameter _ID_EmpleadoF = new MySqlParameter("_ID_EmpleadoF", MySqlDbType.VarChar, 5);
                _ID_EmpleadoF.Value = txtID_Empleado.Text;
                cmd.Parameters.Add(_ID_EmpleadoF);
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Datos de la compra guardados correctamente!");
                llenar_grid();
                txtClave_socio.Clear();
                txtFolio.Clear();
                txtID_Empleado.Clear();
                txtMonto.Clear();
                maskedFecha.Clear();
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
                cmd = new MySqlCommand("DeleteCompra", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _folio = new MySqlParameter("_folio", MySqlDbType.VarChar, 5);
                _folio.Value = txtFolio.Text;
                cmd.Parameters.Add(_folio);
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Datos de la compra eliminados correctamente!");
                llenar_grid();
                txtFolio.Clear();
                maskedFecha.Clear();
                txtClave_socio.Clear();
                txtID_Empleado.Clear();
                txtMonto.Clear();
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
                cmd = new MySqlCommand("UpdateCompra", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _folio = new MySqlParameter("_folio", MySqlDbType.VarChar, 5);
                _folio.Value = txtFolio.Text;
                cmd.Parameters.Add(_folio);
                MySqlParameter _fecha = new MySqlParameter("_fecha", MySqlDbType.DateTime);
                _fecha.Value = Convert.ToDateTime(maskedFecha.Text);
                cmd.Parameters.Add(_fecha);
                MySqlParameter _monto = new MySqlParameter("_monto", MySqlDbType.Int64);
                _monto.Value = txtMonto.Text;
                cmd.Parameters.Add(_monto);
                MySqlParameter _claveF = new MySqlParameter("_claveF", MySqlDbType.VarChar, 5);
                _claveF.Value = txtClave_socio.Text;
                cmd.Parameters.Add(_claveF);
                MySqlParameter _ID_EmpleadoF = new MySqlParameter("_ID_EmpleadoF", MySqlDbType.VarChar, 5);
                _ID_EmpleadoF.Value = txtID_Empleado.Text;
                cmd.Parameters.Add(_ID_EmpleadoF);
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Datos de la compra actualizados correctamente!");
                llenar_grid();
                txtClave_socio.Clear();
                txtFolio.Clear();
                txtID_Empleado.Clear();
                txtMonto.Clear();
                maskedFecha.Clear();
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
                cmd = new MySqlCommand("BuscarCompra", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _folio = new MySqlParameter("_folio", MySqlDbType.VarChar, 5);
                _folio.Value = txtFolio.Text;
                cmd.Parameters.Add(_folio);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    maskedFecha.Text = reader[1].ToString();
                    txtMonto.Text = reader[2].ToString();
                    txtClave_socio.Text = reader[3].ToString();
                    txtID_Empleado.Text = reader[4].ToString();
                }
                else
                {
                    MessageBox.Show("¡Esta compra no existe!");
                    txtClave_socio.Clear();
                    txtFolio.Clear();
                    txtID_Empleado.Clear();
                    txtMonto.Clear();
                    maskedFecha.Clear();
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

        private void Compras_MouseDown(object sender, MouseEventArgs e)
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

        private void Compras_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtClave_socio.Clear();
            txtFolio.Clear();
            txtID_Empleado.Clear();
            txtMonto.Clear();
            maskedFecha.Clear();
        }

        private void txtFolio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void maskedFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtClave_socio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtID_Empleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void validarcampo()
        {
            var vr = !string.IsNullOrEmpty(txtClave_socio.Text) && !string.IsNullOrEmpty(txtFolio.Text) && !string.IsNullOrEmpty(txtID_Empleado.Text) && !string.IsNullOrEmpty(txtMonto.Text) && !string.IsNullOrEmpty(maskedFecha.Text);
            btnAgregar.Enabled = vr;
            btnEliminar.Enabled = vr;
            btnEditar.Enabled = vr;
        }

        private void txtFolio_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void maskedFecha_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtClave_socio_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtID_Empleado_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void picMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dataCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtFolio.Text = dataCompra.SelectedCells[0].Value.ToString();
            maskedFecha.Text = dataCompra.SelectedCells[1].Value.ToString();
            txtMonto.Text = dataCompra.SelectedCells[2].Value.ToString();
            txtClave_socio.Text = dataCompra.SelectedCells[3].Value.ToString();
            txtID_Empleado.Text = dataCompra.SelectedCells[4].Value.ToString();
        }

        public void llenar_grid () //Funcion para actualizar el datagrid cada que agreguemos, eliminemos y actualicemos
        {
            string consulta = "SELECT * FROM compra";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataCompra.DataSource = dt;
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
                cmd.CommandText = "SELECT * FROM compra Where (" + comboBusqueda.Text + ") LIKE ('" + txtbusqueda1.Text + "%')";
                cmd.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataCompra.DataSource = dt;

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

        private void comboBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
