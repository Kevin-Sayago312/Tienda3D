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
    public partial class Incluye : Form
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
        public Incluye()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigoProducto.Clear();
            txtFolioCompra.Clear();
            maskedFecha.Clear();
            txtPrecioVenta.Clear();
            txtSubtotal.Clear();
            txtCantidad.Clear();
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                conectar();
                cmd = new MySqlCommand("ADDIncluye", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _codigoF = new MySqlParameter("_codigoF", MySqlDbType.VarChar, 5);
                _codigoF.Value = txtCodigoProducto.Text;
                cmd.Parameters.Add(_codigoF);
                MySqlParameter _folioF = new MySqlParameter("_folioF", MySqlDbType.VarChar, 5);
                _folioF.Value = txtFolioCompra.Text;
                cmd.Parameters.Add(_folioF);
                MySqlParameter _fecha = new MySqlParameter("_fecha", MySqlDbType.DateTime);
                _fecha.Value = Convert.ToDateTime(maskedFecha.Text);
                cmd.Parameters.Add(_fecha);
                MySqlParameter _precio_ventaF = new MySqlParameter("_precio_ventaF", MySqlDbType.Int32);
                _precio_ventaF.Value = txtPrecioVenta.Text;
                cmd.Parameters.Add(_precio_ventaF);
                MySqlParameter _subtotal = new MySqlParameter("_subtotal", MySqlDbType.Int32);
                _subtotal.Value = txtSubtotal.Text;
                cmd.Parameters.Add(_subtotal);
                MySqlParameter _cantidad = new MySqlParameter("_cantidad", MySqlDbType.Int32);
                _cantidad.Value = txtCantidad.Text;
                cmd.Parameters.Add(_cantidad);
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Datos de incluye guardados correctamente!");
                llenar_grid();
                txtCodigoProducto.Clear();
                maskedFecha.Clear();
                txtFolioCompra.Clear();
                txtPrecioVenta.Clear();
                txtSubtotal.Clear();
                txtCantidad.Clear();
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
                cmd = new MySqlCommand("DeleteIncluye", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _codigoF = new MySqlParameter("_codigoF", MySqlDbType.VarChar, 5);
                _codigoF.Value = txtCodigoProducto.Text;
                cmd.Parameters.Add(_codigoF);
                MySqlParameter _folioF = new MySqlParameter("_folioF", MySqlDbType.VarChar, 5);
                _folioF.Value = txtFolioCompra.Text;
                cmd.Parameters.Add(_folioF);
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Datos de incluye eliminados correctamente!");
                llenar_grid();
                txtCodigoProducto.Clear();
                maskedFecha.Clear();
                txtFolioCompra.Clear();
                txtPrecioVenta.Clear();
                txtSubtotal.Clear();
                txtCantidad.Clear();
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
                cmd = new MySqlCommand("UpdateIncluye", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _codigoF = new MySqlParameter("_codigoF", MySqlDbType.VarChar, 5);
                _codigoF.Value = txtCodigoProducto.Text;
                cmd.Parameters.Add(_codigoF);
                MySqlParameter _folioF = new MySqlParameter("_folioF", MySqlDbType.VarChar, 5);
                _folioF.Value = txtFolioCompra.Text;
                cmd.Parameters.Add(_folioF);
                MySqlParameter _fecha = new MySqlParameter("_fecha", MySqlDbType.DateTime);
                _fecha.Value = Convert.ToDateTime(maskedFecha.Text);
                cmd.Parameters.Add(_fecha);
                MySqlParameter _precio_ventaF = new MySqlParameter("_precio_ventaF", MySqlDbType.Int32);
                _precio_ventaF.Value = txtPrecioVenta.Text;
                cmd.Parameters.Add(_precio_ventaF);
                MySqlParameter _subtotal = new MySqlParameter("_subtotal", MySqlDbType.Int32);
                _subtotal.Value = txtSubtotal.Text;
                cmd.Parameters.Add(_subtotal);
                MySqlParameter _cantidad = new MySqlParameter("_cantidad", MySqlDbType.Int32);
                _cantidad.Value = txtCantidad.Text;
                cmd.Parameters.Add(_cantidad);
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Datos de incluye actualizados correctamente!");
                llenar_grid();
                txtCodigoProducto.Clear();
                maskedFecha.Clear();
                txtFolioCompra.Clear();
                txtPrecioVenta.Clear();
                txtSubtotal.Clear();
                txtCantidad.Clear();
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
                cmd = new MySqlCommand("BuscarIncluye", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _codigoF = new MySqlParameter("_codigoF", MySqlDbType.VarChar, 5);
                _codigoF.Value = txtCodigoProducto.Text;
                cmd.Parameters.Add(_codigoF);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtFolioCompra.Text = reader[1].ToString();
                    maskedFecha.Text = reader[2].ToString();
                    txtPrecioVenta.Text = reader[3].ToString();
                    txtSubtotal.Text = reader[4].ToString();
                }
                else
                {
                    MessageBox.Show("¡Estos datos no existen!");
                    txtCodigoProducto.Clear();
                    maskedFecha.Clear();
                    txtFolioCompra.Clear();
                    txtSubtotal.Clear();
                    txtPrecioVenta.Clear();
                    txtCantidad.Clear();
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

        private void Incluye_MouseDown(object sender, MouseEventArgs e)
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

        private void Incluye_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void txtCodigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtFolioCompra_KeyPress(object sender, KeyPressEventArgs e)
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
        private void validarcampo()
        {
            var vr = !string.IsNullOrEmpty(txtCodigoProducto.Text) && !string.IsNullOrEmpty(txtFolioCompra.Text) && !string.IsNullOrEmpty(maskedFecha.Text) && !string.IsNullOrEmpty(txtSubtotal.Text) && !string.IsNullOrEmpty(txtPrecioVenta.Text) && !string.IsNullOrEmpty(txtCantidad.Text);
            btnAgregar.Enabled = vr;
            btnEliminar.Enabled = vr;
            btnEditar.Enabled = vr;
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

        private void Incluye_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            string consulta = "SELECT * FROM incluye";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataIncluye.DataSource = dt;

            //invoca el ID del usuario
            lblID.Text = string.Format("{0}", nombreusuario);
            ConsultarPuesto(); // Consulta el puesto y pone que puesto tiene el usuario
        }

        private void txtCodigoProducto_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtFolioCompra_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void maskedFecha_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void picMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dataIncluye_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoProducto.Text = dataIncluye.SelectedCells[0].Value.ToString();
            txtFolioCompra.Text = dataIncluye.SelectedCells[1].Value.ToString();
            maskedFecha.Text = dataIncluye.SelectedCells[2].Value.ToString();
            txtPrecioVenta.Text = dataIncluye.SelectedCells[3].Value.ToString();
            txtSubtotal.Text = dataIncluye.SelectedCells[4].Value.ToString();
            txtCantidad.Text = dataIncluye.SelectedCells[5].Value.ToString();
        }
        public void llenar_grid()
        {
            string consulta = "SELECT * FROM incluye";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataIncluye.DataSource = dt;
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

        private void txtbusqueda1_KeyPress(object sender, KeyPressEventArgs e) // BUSQUEDA PREDICTIVA
        {
            try
            {
                conectar();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM incluye Where (" + comboBusqueda.Text + ") LIKE ('" + txtbusqueda1.Text + "%')";
                cmd.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataIncluye.DataSource = dt;

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

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtSubtotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPrecioVenta_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtSubtotal_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }
    }
}
