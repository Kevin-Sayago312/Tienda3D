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
    public partial class Consultas : Form
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
        public Consultas()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
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

        private void Consultas_Load(object sender, EventArgs e)
        {
            string consulta = "SHOW FULL TABLES FROM Tienda3D";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataConsultas.DataSource = dt;

            //invoca el ID del usuario
            lblID.Text = string.Format("{0}", nombreusuario);
            ConsultarPuesto(); // Consulta el puesto y pone que puesto tiene el usuario
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

        private void Consultas_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Consultas_Paint(object sender, PaintEventArgs e)
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
        DataTable dt = new DataTable();
        MySqlDataAdapter da = new MySqlDataAdapter();
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                conectar();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;

                if (comboConsultasBasicas.Text== "1.- Mostrar el nombre y email del Empleado que su ID de empleado sea de '00005'")
                {
                    cmd.CommandText = "SELECT nombre, email FROM empleado WHERE ID_Empleado='00005'";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboConsultasBasicas.Text == "2.- Mostrar el nombre y telefono del Proveedor que su ID de proveedor sea de '00010'")
                {
                    cmd.CommandText = "SELECT nombre, telefono FROM proveedor WHERE ID_Proveedor='00010'";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboConsultasBasicas.Text == "3.- Mostrar el nombre y precio de los Productos que sus codigos esten dentro de '00005' y '00010'")
                {
                    cmd.CommandText = "SELECT nombre, precio FROM producto WHERE codigo BETWEEN '00005' AND '00010'";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboConsultasBasicas.Text == "4.- Mostrar la clave del socio llamado 'Mirkha'")
                {
                    cmd.CommandText = "SELECT clave FROM socio WHERE nombre='Mirkha'";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboConsultasBasicas.Text == "5.- Mostrar el folio de las Compras que haya tenido 900 de monto")
                {
                    cmd.CommandText = "SELECT folio FROM compra WHERE monto=900";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboConsultasBasicas.Text == "6.- Mostrar el todos los campos de la tabla Telefono-Socio")
                {
                    cmd.CommandText = "SELECT *FROM telefono_socio";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
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
        
        private void comboConsultasBasicas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 254))
            {
                MessageBox.Show("Solo letras y números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnFunciones_Click(object sender, EventArgs e)
        {
            try
            {
                conectar();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;

                if (comboConsultasFunciones.Text == "1.- Mostrar la cantidad de Empleados")
                {
                    cmd.CommandText = "SELECT COUNT(ID_Empleado) AS Total FROM empleado";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboConsultasFunciones.Text == "2.- Mostrar la cantidad de productos agrupados por el proveedor")
                {
                    cmd.CommandText = "SELECT ID_ProveedorF, COUNT(codigo) AS Total FROM producto GROUP BY ID_ProveedorF";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboConsultasFunciones.Text == "3.- Mostrar el precio maximo y minimo de los productos agrupados por el proveedor")
                {
                    cmd.CommandText = "SELECT ID_ProveedorF, MAX(precio) AS Precio_Maximo, MIN(precio) AS Precio_Minimo FROM producto GROUP BY ID_ProveedorF";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboConsultasFunciones.Text == "4.- Mostrar el promedio de los precios de los productos agrupados por proveedor")
                {
                    cmd.CommandText = "SELECT ID_ProveedorF, AVG(precio) AS Promedio FROM producto GROUP BY ID_ProveedorF";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboConsultasFunciones.Text == "5.- Mostrar la cantidad de productos agrupados por material")
                {
                    cmd.CommandText = "SELECT material, COUNT(codigo) AS Total FROM producto GROUP BY material";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboConsultasFunciones.Text == "6.- Mostrar la suma de los precios de los productos cuyo nombre sea 'Diorama Anya y Yor'")
                {
                    cmd.CommandText = "SELECT SUM(precio) AS Suma_Total FROM producto WHERE nombre='Diorama Anya y Yor'";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
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

        private void btnMultitabla_Click(object sender, EventArgs e)
        {
            try
            {
                conectar();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;

                if (comboConsultasMultitabla.Text == "1.- Mostrar el nombre y la existencia de los productos que se encuentran en el proveedor '00004'")
                {
                    cmd.CommandText = "SELECT producto.nombre, producto.existencia FROM producto, proveedor WHERE producto.ID_ProveedorF = proveedor.ID_Proveedor AND proveedor.ID_Proveedor = '00004'";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboConsultasMultitabla.Text == "2.- Mostrar el nombre y precio de los productos que abastecio el proveedor 'Voxelab' y tambien que muestre el telefono y correo electronico del proveedor")
                {
                    cmd.CommandText = "SELECT producto.nombre, producto.precio, proveedor.telefono, proveedor.email FROM producto, proveedor WHERE producto.ID_ProveedorF = proveedor.ID_Proveedor AND proveedor.nombre = 'Voxelab'";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboConsultasMultitabla.Text == "3.- Mostrar la fecha de compra que realizo el socio 'Rogelio' y el precio de la compra")
                {
                    cmd.CommandText = "SELECT compra.fecha, compra.monto FROM compra, socio WHERE compra.claveF = socio.clave AND socio.nombre = 'Rogelio'";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboConsultasMultitabla.Text == "4.- Mostrar el monto y nombre del socio que se le hizo una compra en la fecha '2022-10-05'")
                {
                    cmd.CommandText = "SELECT compra.monto, socio.nombre FROM compra, socio WHERE compra.claveF = socio.clave AND compra.fecha = '2022-10-05'";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboConsultasMultitabla.Text == "5.- Mostrar el nombre, telefono del socio que se realizo una compra en la fecha '2022-10-09' y el monto  haya sido de '900'")
                {
                    cmd.CommandText = "SELECT socio.nombre, telefono_socio.telefono, compra.monto FROM telefono_socio, compra, socio WHERE telefono_socio.claveF = socio.clave AND compra.claveF = socio.clave AND compra.fecha = '2022-10-09' AND compra.monto = '900'";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboConsultasMultitabla.Text == "6.- Mostrar el nombre y el precio de los productos que abastecio el proveedor 'Anycubic' y que muestre la direccion del proveedor")
                {
                    cmd.CommandText = "SELECT producto.nombre, producto.precio, proveedor.direccion FROM producto, proveedor WHERE producto.ID_ProveedorF = proveedor.ID_Proveedor AND proveedor.nombre = 'Anycubic'";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
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

        private void btnSubconsulta_Click(object sender, EventArgs e)
        {
            try
            {
                conectar();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;

                if (comboSubconsultas.Text == "1.- Mostrar los nombres de los productos que no hayan sido distribuidos por el proveedor 'Creality'")
                {
                    cmd.CommandText = "SELECT producto.nombre FROM producto WHERE producto.ID_ProveedorF NOT IN(SELECT ID_Proveedor FROM proveedor WHERE nombre = 'Creality')";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboSubconsultas.Text == "2.- Mostrar todos los campos de los productos que pertenecen al proveedor 'Resin 3D'")
                {
                    cmd.CommandText = "SELECT producto.* FROM producto WHERE producto.ID_ProveedorF IN(SELECT ID_Proveedor FROM proveedor WHERE nombre = 'Resin 3D')";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboSubconsultas.Text == "3.- Mostrar el folio y la fecha de compra donde el codigo de Empleado haya sido de '00010'")
                {
                    cmd.CommandText = "SELECT compra.folio, compra.fecha FROM compra WHERE compra.ID_EmpleadoF IN(SELECT ID_Empleado FROM empleado WHERE ID_Empleado = '00010')";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboSubconsultas.Text == "4.- Mostrar el codigo y nombre del producto que NO pertenezcan al proveedor 'SUNLU'")
                {
                    cmd.CommandText = "SELECT producto.codigo, producto.nombre FROM producto WHERE producto.ID_ProveedorF NOT IN(SELECT ID_Proveedor FROM proveedor WHERE nombre = 'SUNLU')";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboSubconsultas.Text == "5.- Mostrar el codigo y el nombre del producto que pertenezcan al proveedor 'Eleego' y 'Creality'")
                {
                    cmd.CommandText = "SELECT producto.codigo, producto.nombre FROM producto WHERE producto.ID_ProveedorF IN(SELECT ID_Proveedor FROM proveedor WHERE nombre IN('Elegoo', 'Creality'))";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboSubconsultas.Text == "6.- Mostrar el monto de compra donde el codigo de Socio haya sido de '00002'")
                {
                    cmd.CommandText = "SELECT compra.monto FROM compra WHERE compra.claveF IN(SELECT clave FROM socio WHERE clave = '00002')";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
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

        private void btnJoin_Click(object sender, EventArgs e)
        {
            try
            {
                conectar();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;

                if (comboJoin.Text == "1.- Mostrar el nombre y el precio de los productos y el nombre del proveedor al que pertenecen en una vista general")
                {
                    cmd.CommandText = "SELECT producto.nombre, producto.precio, proveedor.ID_Proveedor, proveedor.nombre FROM producto INNER JOIN proveedor WHERE producto.ID_ProveedorF = proveedor.ID_Proveedor";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboJoin.Text == "2.- Mostrar la llave primaria y el nombre de los productos, tambien debe mostrar la llave primaria, nombre y telefono del proveedor que lo abastecio en una vista general")
                {
                    cmd.CommandText = "SELECT producto.codigo, producto.nombre, proveedor.ID_Proveedor, proveedor.nombre, proveedor.telefono FROM  producto INNER JOIN proveedor WHERE producto.ID_ProveedorF = proveedor.ID_Proveedor";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboJoin.Text == "3.- Mostrar los nombres de los socios y sus numeros en una vista general")
                {
                    cmd.CommandText = "SELECT socio.nombre, telefono_socio.telefono FROM socio INNER JOIN telefono_socio WHERE telefono_socio.claveF = socio.clave";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboJoin.Text == "4.- Mostrar el telefono y el nombre del socio que tiene el correo 'Rogelio_Lopez@gmail.com' en una vista general")
                {
                    cmd.CommandText = "SELECT socio.nombre, telefono_socio.telefono FROM socio INNER JOIN telefono_socio WHERE telefono_socio.claveF = socio.clave AND socio.email = 'rogelio_lopez@gmail.com'";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboJoin.Text == "5.- Mostrar el folio de compra y la llave primaria del cliente y el monto que se adjuntaron en una vista general")
                {
                    cmd.CommandText = "SELECT compra.folio, compra.monto, compra.claveF FROM compra INNER JOIN socio WHERE compra.claveF = socio.clave";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
                }
                if (comboJoin.Text == "6.- Mostrar todos los datos de la compra donde la llave primaria del socio haya sido '00001'")
                {
                    cmd.CommandText = "SELECT compra.* FROM compra INNER JOIN socio WHERE compra.claveF=socio.clave AND socio.clave='00001'";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataConsultas.DataSource = dt;
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
            comboConsultasBasicas.Text = "";
            comboSubconsultas.Text = "";
            comboJoin.Text = "";
            comboConsultasMultitabla.Text = "";
            comboConsultasFunciones.Text = "";
            dataConsultas.ClearSelection();
        }
    }
}
