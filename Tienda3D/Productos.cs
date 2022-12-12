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
    public partial class Productos : Form
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
        public Productos()
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

        private void Productos_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            string consulta = "SELECT * FROM producto";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataProductos.DataSource = dt;

            //invoca el ID del usuario
            lblID.Text = string.Format("{0}", nombreusuario);
            ConsultarPuesto(); // Consulta el puesto y pone que puesto tiene el usuario
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                conectar();
                cmd = new MySqlCommand("BuscarProducto", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _codigo = new MySqlParameter("_codigo", MySqlDbType.VarChar, 5);
                _codigo.Value = txtCodigo.Text;
                cmd.Parameters.Add(_codigo);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtNombre.Text = reader[1].ToString();
                    comboMaterial.Text = reader[2].ToString();
                    txtPrecio.Text = reader[3].ToString();
                    comboColor.Text = reader[4].ToString();
                    txtExistencia.Text = reader[5].ToString();
                    txtIDProveedor.Text = reader[6].ToString();
                    txtPrecioVenta.Text = reader[7].ToString();
                }
                else
                {
                    MessageBox.Show("¡Este producto no existe!");
                    txtCodigo.Clear();
                    txtExistencia.Clear();
                    txtIDProveedor.Clear();
                    txtNombre.Clear();
                    txtPrecio.Clear();
                    comboColor.Text = "";
                    comboMaterial.Text = "";
                    txtPrecioVenta.Clear();
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
                cmd = new MySqlCommand("ADDProducto", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _codigo = new MySqlParameter("_codigo", MySqlDbType.VarChar, 5);
                _codigo.Value = txtCodigo.Text;
                cmd.Parameters.Add(_codigo);
                MySqlParameter _nombre = new MySqlParameter("_nombre", MySqlDbType.VarChar, 100);
                _nombre.Value = txtNombre.Text;
                cmd.Parameters.Add(_nombre);
                MySqlParameter _material = new MySqlParameter("_material", MySqlDbType.Enum);
                _material.Value = comboMaterial.Text;
                cmd.Parameters.Add(_material);
                MySqlParameter _precio = new MySqlParameter("_precio", MySqlDbType.Int32);
                _precio.Value = txtPrecio.Text;
                cmd.Parameters.Add(_precio);
                MySqlParameter _color = new MySqlParameter("_color", MySqlDbType.Enum);
                _color.Value = comboColor.Text;
                cmd.Parameters.Add(_color);
                MySqlParameter _existencia = new MySqlParameter("_existencia", MySqlDbType.Int32);
                _existencia.Value = txtExistencia.Text;
                cmd.Parameters.Add(_existencia);
                MySqlParameter _ID_ProveedorF = new MySqlParameter("_ID_ProveedorF", MySqlDbType.VarChar, 5);
                _ID_ProveedorF.Value = txtIDProveedor.Text;
                cmd.Parameters.Add(_ID_ProveedorF);
                MySqlParameter _precio_venta = new MySqlParameter("_precio_venta", MySqlDbType.Int32);
                _precio_venta.Value = txtPrecioVenta.Text;
                cmd.Parameters.Add(_precio_venta);
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Datos del producto guardados correctamente!");
                llenar_grid();
                txtCodigo.Clear();
                txtExistencia.Clear();
                txtIDProveedor.Clear();
                txtNombre.Clear();
                txtPrecio.Clear();
                comboColor.Text = "";
                comboMaterial.Text = "";
                txtPrecioVenta.Clear();
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
                cmd = new MySqlCommand("DeleteProducto", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _codigo = new MySqlParameter("_codigo", MySqlDbType.VarChar, 5);
                _codigo.Value = txtCodigo.Text;
                cmd.Parameters.Add(_codigo);
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Datos del producto eliminados correctamente!");
                llenar_grid();
                txtCodigo.Clear();
                txtExistencia.Clear();
                txtIDProveedor.Clear();
                txtNombre.Clear();
                txtPrecio.Clear();
                comboColor.Text="";
                comboMaterial.Text = "";
                txtPrecioVenta.Clear();
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
                cmd = new MySqlCommand("UpdateProducto", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _codigo = new MySqlParameter("_codigo", MySqlDbType.VarChar, 5);
                _codigo.Value = txtCodigo.Text;
                cmd.Parameters.Add(_codigo);
                MySqlParameter _nombre = new MySqlParameter("_nombre", MySqlDbType.VarChar, 100);
                _nombre.Value = txtNombre.Text;
                cmd.Parameters.Add(_nombre);
                MySqlParameter _material = new MySqlParameter("_material", MySqlDbType.Enum);
                _material.Value = comboMaterial.Text;
                cmd.Parameters.Add(_material);
                MySqlParameter _precio = new MySqlParameter("_precio", MySqlDbType.Int32);
                _precio.Value = txtPrecio.Text;
                cmd.Parameters.Add(_precio);
                MySqlParameter _color = new MySqlParameter("_color", MySqlDbType.Enum);
                _color.Value = comboColor.Text;
                cmd.Parameters.Add(_color);
                MySqlParameter _existencia = new MySqlParameter("_existencia", MySqlDbType.Int32);
                _existencia.Value = txtExistencia.Text;
                cmd.Parameters.Add(_existencia);
                MySqlParameter _ID_ProveedorF = new MySqlParameter("_ID_ProveedorF", MySqlDbType.VarChar, 5);
                _ID_ProveedorF.Value = txtIDProveedor.Text;
                cmd.Parameters.Add(_ID_ProveedorF);
                MySqlParameter _precio_venta = new MySqlParameter("_precio_venta", MySqlDbType.Int32);
                _precio_venta.Value = txtPrecioVenta.Text;
                cmd.Parameters.Add(_precio_venta);
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Datos del producto actualizados correctamente!");
                llenar_grid();
                txtCodigo.Clear();
                txtExistencia.Clear();
                txtIDProveedor.Clear();
                txtNombre.Clear();
                txtPrecio.Clear();
                comboColor.Text = "";
                comboMaterial.Text = "";
                txtPrecioVenta.Clear();
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

        private void Productos_MouseDown(object sender, MouseEventArgs e)
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

        private void Productos_Paint(object sender, PaintEventArgs e)
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
            txtCodigo.Clear();
            txtExistencia.Clear();
            txtIDProveedor.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            comboColor.Text = "";
            comboMaterial.Text = "";
            txtPrecioVenta.Clear();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtExistencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
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

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void comboMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void comboColor_KeyPress(object sender, KeyPressEventArgs e)
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
            var vr = !string.IsNullOrEmpty(txtCodigo.Text) && !string.IsNullOrEmpty(txtExistencia.Text) && !string.IsNullOrEmpty(txtIDProveedor.Text) && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtPrecio.Text) && !string.IsNullOrEmpty(comboColor.Text) && !string.IsNullOrEmpty(comboMaterial.Text) && !string.IsNullOrEmpty(txtPrecioVenta.Text);
            btnAgregar.Enabled = vr;
            btnEliminar.Enabled = vr;
            btnEditar.Enabled = vr;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void comboMaterial_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void comboColor_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtExistencia_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void txtIDProveedor_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void picMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void comboMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dataProductos.SelectedCells[0].Value.ToString();
            txtNombre.Text = dataProductos.SelectedCells[1].Value.ToString();
            comboMaterial.Text = dataProductos.SelectedCells[2].Value.ToString();
            txtPrecio.Text = dataProductos.SelectedCells[3].Value.ToString();
            comboColor.Text = dataProductos.SelectedCells[4].Value.ToString();
            txtExistencia.Text = dataProductos.SelectedCells[5].Value.ToString();
            txtIDProveedor.Text = dataProductos.SelectedCells[6].Value.ToString();
            txtPrecioVenta.Text = dataProductos.SelectedCells[7].Value.ToString();
        }
        public void llenar_grid()
        {
            string consulta = "SELECT * FROM producto";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataProductos.DataSource = dt;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtbusqueda1_KeyUp(object sender, KeyEventArgs e)
        {
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
                cmd.CommandText = "SELECT * FROM producto Where (" + comboBusqueda.Text + ") LIKE ('" + txtbusqueda1.Text + "%')";
                cmd.ExecuteNonQuery();
                 dt = new DataTable();
                 da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataProductos.DataSource = dt;

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

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
