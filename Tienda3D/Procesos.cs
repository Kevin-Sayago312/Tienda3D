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
    public partial class Procesos : Form
    {
        private int borderRadius = 30;
        private int borderSize = 2;
        private Color borderColor = Color.Transparent;

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
        public Procesos()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);

            //Mostrar tabla para ingresar los datos de la compra
            dt = new DataTable();
            dt.Columns.Add("Folio de compra");
            dt.Columns.Add("Fecha de compra");
            dt.Columns.Add("Clave de cliente");
            dt.Columns.Add("Nombre del cliente");
            dt.Columns.Add("Codigo del producto");
            dt.Columns.Add("Nombre del producto");
            dt.Columns.Add("Existencia del producto");
            dt.Columns.Add("Precio en venta");
            dt.Columns.Add("Cantidad a llevar");
            dt.Columns.Add("Monto");
            dataTerminar.DataSource = dt; // Invocamos el datagrid donde vamos a mostrar esos datos que queremos
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private static Procesos _instancia;

        public void setCliente(string clave, string nombre)
        {
            this.txtClaveCliente.Text = clave;
            this.txtNombreCliente.Text = nombre;
        }

        public static Procesos GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new Procesos();
            }
            return _instancia;
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

        DataTable dt = new DataTable();
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlConnection conexion = new MySqlConnection("Server= localhost; Database= Tienda3D; user = root; password= root; ");

        private void Procesos_Load(object sender, EventArgs e)
        {
            //invoca el ID del usuario
            lblID.Text = string.Format("{0}", nombreusuario);
            ConsultarPuesto(); // Consulta el puesto y pone que puesto tiene el usuario
            calculamonto();
            btnComprarAhora.Enabled = false;
            btnAgregarCarrito.Enabled = false;
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

        private void Procesos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Procesos_Paint(object sender, PaintEventArgs e)
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

        private void picMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picBuscarFolioCompra_Click(object sender, EventArgs e)
        {
            string consulta2 = "SELECT * FROM compra";
            MySqlDataAdapter adaptador2 = new MySqlDataAdapter(consulta2, conexion);
            DataTable dt2 = new DataTable();
            adaptador2.Fill(dt2);
            dataCompra.DataSource = dt2;
            dataCompra.Visible = true;
            dataCliente.Visible = false;
            dataProductos.Visible = false;
            dataTerminar.Visible = false;
        }

        private void picBuscarCodigoProducto_Click(object sender, EventArgs e)
        {
            string consulta = "SELECT * FROM producto";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataProductos.DataSource = dt;
            dataProductos.Visible = true;
            dataCliente.Visible = false;
            dataCompra.Visible = false;
            dataTerminar.Visible = false;
        }

        private void picBuscarClaveCliente_Click(object sender, EventArgs e)
        {
            dataCliente.Visible = true;
            string consulta3 = "SELECT * FROM socio";
            MySqlDataAdapter adaptador3 = new MySqlDataAdapter(consulta3, conexion);
            DataTable dt3 = new DataTable();
            adaptador3.Fill(dt3);
            dataCliente.DataSource = dt3;
            dataCliente.Visible = true;
            dataCompra.Visible = false;
            dataProductos.Visible = false;
            dataTerminar.Visible = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtbusqueda.Clear();
            txtClaveCliente.Clear();
            txtCodigoProducto.Clear();
            txtExistenciaProducto.Clear();
            maskedFecha.Clear();
            txtFolioCompra.Clear();
            txtMonto.Clear();
            txtNombreCliente.Clear();
            txtNombreProducto.Clear();
            txtPrecioVentaProducto.Clear();
            NumericCantidadLlevar.Value = 0;
            comboBusqueda.Text = "";
        }
        private void dataProcesoCompraVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataCompra.SelectedRows.Count > 0)
            {
                txtFolioCompra.Text = dataCompra.SelectedCells[0].Value.ToString();
                maskedFecha.Text = dataCompra.SelectedCells[1].Value.ToString();
            }
        }

        private void dataprocesos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataProductos.SelectedRows.Count > 0)
            {
                txtCodigoProducto.Text = dataProductos.SelectedCells[0].Value.ToString();
                txtNombreProducto.Text = dataProductos.SelectedCells[1].Value.ToString();
                txtExistenciaProducto.Text = dataProductos.SelectedCells[5].Value.ToString();
                txtPrecioVentaProducto.Text = dataProductos.SelectedCells[7].Value.ToString();
            }
        }


        private void dataCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataCliente.SelectedRows.Count > 0)
            {
                txtClaveCliente.Text = dataCliente.SelectedCells[0].Value.ToString();
                txtNombreCliente.Text = dataCliente.SelectedCells[1].Value.ToString();
            }
        }

        private void btnCerrarPanel_Click(object sender, EventArgs e)
        {
            dataCliente.Visible = false;
            dataCompra.Visible = false;
            dataProductos.Visible = false;
            dataTerminar.Visible = false;
        }

        private void NumericCantidadLlevar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dataTerminar.Visible = true;
            dataCliente.Visible = false;
            dataCompra.Visible = false;
            dataProductos.Visible = false;
        }

        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            //Agregamos los datos que pusimos en los textbox en el datagrid
            DataRow row = dt.NewRow();
            row["Folio de compra"] = txtFolioCompra.Text;
            row["Fecha de compra"] = maskedFecha.Text;
            row["Clave de cliente"] = txtClaveCliente.Text;
            row["Nombre del cliente"] = txtNombreCliente.Text;
            row["Codigo del producto"] = txtCodigoProducto.Text;
            row["Nombre del producto"] = txtNombreProducto.Text;
            row["Existencia del producto"] = txtExistenciaProducto.Text;
            row["Precio en venta"] = txtPrecioVentaProducto.Text;
            row["Cantidad a llevar"] = NumericCantidadLlevar.Text;
            row["Monto"] = Int32.Parse(NumericCantidadLlevar.Value.ToString()) * double.Parse(txtPrecioVentaProducto.Text); //txtMonto.Text;
            dt.Rows.Add(row);
            dataTerminar.Visible = true;
            calculamonto();
        }

        private void btnEliminarCarrito_Click(object sender, EventArgs e)
        {
            if (dataTerminar.CurrentRow == null)
            {
                MessageBox.Show("No hay nada que eliminar");
            }
            else
            {
                dataTerminar.Rows.RemoveAt(dataTerminar.CurrentRow.Index);
            }
        }

        private void btnComprarAhora_Click(object sender, EventArgs e)
        {
            if (dataTerminar.CurrentRow == null)
            {
                MessageBox.Show("Debe agregar productos al carrito para poder comprar");
            }
            else
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
                    _fecha.Value = Convert.ToDateTime(maskedFechaVenta.Text);
                    cmd.Parameters.Add(_fecha);
                    MySqlParameter _precio_ventaF = new MySqlParameter("_precio_ventaF", MySqlDbType.Int32);
                    _precio_ventaF.Value = txtPrecioVentaProducto.Text;
                    cmd.Parameters.Add(_precio_ventaF);
                    MySqlParameter _subtotal = new MySqlParameter("_subtotal", MySqlDbType.Int32);
                    _subtotal.Value = txtMonto.Text;
                    cmd.Parameters.Add(_subtotal);
                    MySqlParameter _cantidad = new MySqlParameter("_cantidad", MySqlDbType.Int32);
                    _cantidad.Value = NumericCantidadLlevar.Text;
                    cmd.Parameters.Add(_cantidad);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("¡Datos de incluye guardados correctamente!");
                    txtbusqueda.Clear();
                    txtClaveCliente.Clear();
                    txtCodigoProducto.Clear();
                    txtExistenciaProducto.Clear();
                    maskedFecha.Clear();
                    txtFolioCompra.Clear();
                    txtMonto.Clear();
                    txtNombreCliente.Clear();
                    txtNombreProducto.Clear();
                    txtPrecioVentaProducto.Clear();
                    NumericCantidadLlevar.Value = 0;
                    maskedFechaVenta.Clear();
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
        }

        private void calculamonto()
        {
            double monto = 0;
            try
            {
                if (dataTerminar.Rows.Count > 0)
                {
                    foreach(DataGridViewRow row in dataTerminar.Rows)
                    {
                        monto += Convert.ToDouble(row.Cells["Monto"].Value);
                        //txtMonto.Text = dataTerminar.SelectedCells[9].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtMonto.Text = monto.ToString("0");
        }

        private void validarcampo()
        {
            var vr = !string.IsNullOrEmpty(txtCodigoProducto.Text) && !string.IsNullOrEmpty(txtFolioCompra.Text) && !string.IsNullOrEmpty(maskedFecha.Text) && !string.IsNullOrEmpty(txtMonto.Text) && !string.IsNullOrEmpty(txtPrecioVentaProducto.Text) && !string.IsNullOrEmpty(NumericCantidadLlevar.Text) && !string.IsNullOrEmpty(maskedFechaVenta.Text) && !string.IsNullOrEmpty(txtClaveCliente.Text) && !string.IsNullOrEmpty(txtNombreCliente.Text) && !string.IsNullOrEmpty(txtExistenciaProducto.Text) && !string.IsNullOrEmpty(txtNombreProducto.Text) && !string.IsNullOrEmpty(txtMonto.Text);
            btnComprarAhora.Enabled = vr;
            btnAgregarCarrito.Enabled = vr;
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void maskedFechaVenta_TextChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void NumericCantidadLlevar_ValueChanged(object sender, EventArgs e)
        {
            validarcampo();
        }

        private void maskedFechaVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtbusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                conectar();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM socio Where (" + comboBusqueda.Text + ") LIKE ('" + txtbusqueda.Text + "%')";
                cmd.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataCliente.DataSource = dt;

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
