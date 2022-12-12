namespace Tienda3D
{
    partial class Consultas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consultas));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.picMini = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.comboConsultasBasicas = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnRegresarMenu = new System.Windows.Forms.Button();
            this.btnBasicas = new System.Windows.Forms.Button();
            this.dataConsultas = new System.Windows.Forms.DataGridView();
            this.comboConsultasFunciones = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboConsultasMultitabla = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboSubconsultas = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboJoin = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFunciones = new System.Windows.Forms.Button();
            this.btnMultitabla = new System.Windows.Forms.Button();
            this.btnSubconsulta = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.lblRol = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataConsultas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.picMini);
            this.panel2.Controls.Add(this.pictureBox9);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1025, 37);
            this.panel2.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(81, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "CONSULTAS";
            // 
            // picMini
            // 
            this.picMini.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMini.Image = ((System.Drawing.Image)(resources.GetObject("picMini.Image")));
            this.picMini.Location = new System.Drawing.Point(945, 3);
            this.picMini.Name = "picMini";
            this.picMini.Size = new System.Drawing.Size(42, 31);
            this.picMini.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMini.TabIndex = 3;
            this.picMini.TabStop = false;
            this.picMini.Click += new System.EventHandler(this.picMini_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(22, 0);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(53, 37);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 2;
            this.pictureBox9.TabStop = false;
            // 
            // comboConsultasBasicas
            // 
            this.comboConsultasBasicas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboConsultasBasicas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboConsultasBasicas.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboConsultasBasicas.FormattingEnabled = true;
            this.comboConsultasBasicas.Items.AddRange(new object[] {
            "1.- Mostrar el nombre y email del Empleado que su ID de empleado sea de \'00005\'",
            "2.- Mostrar el nombre y telefono del Proveedor que su ID de proveedor sea de \'000" +
                "10\'",
            "3.- Mostrar el nombre y precio de los Productos que sus codigos esten dentro de \'" +
                "00005\' y \'00010\'",
            "4.- Mostrar la clave del socio llamado \'Mirkha\'",
            "5.- Mostrar el folio de las Compras que haya tenido 900 de monto",
            "6.- Mostrar el todos los campos de la tabla Telefono-Socio"});
            this.comboConsultasBasicas.Location = new System.Drawing.Point(282, 84);
            this.comboConsultasBasicas.Name = "comboConsultasBasicas";
            this.comboConsultasBasicas.Size = new System.Drawing.Size(507, 30);
            this.comboConsultasBasicas.TabIndex = 67;
            this.comboConsultasBasicas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboConsultasBasicas_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(76, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(200, 25);
            this.label10.TabIndex = 65;
            this.label10.Text = "Consultas basicas:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(900, 70);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(112, 74);
            this.btnLimpiar.TabIndex = 64;
            this.btnLimpiar.Text = "Limpiar texto";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnRegresarMenu
            // 
            this.btnRegresarMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.btnRegresarMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresarMenu.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresarMenu.Location = new System.Drawing.Point(900, 198);
            this.btnRegresarMenu.Name = "btnRegresarMenu";
            this.btnRegresarMenu.Size = new System.Drawing.Size(112, 61);
            this.btnRegresarMenu.TabIndex = 63;
            this.btnRegresarMenu.Text = "Regresar al menú";
            this.btnRegresarMenu.UseVisualStyleBackColor = false;
            this.btnRegresarMenu.Click += new System.EventHandler(this.btnRegresarMenu_Click);
            // 
            // btnBasicas
            // 
            this.btnBasicas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.btnBasicas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBasicas.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBasicas.Location = new System.Drawing.Point(795, 70);
            this.btnBasicas.Name = "btnBasicas";
            this.btnBasicas.Size = new System.Drawing.Size(89, 44);
            this.btnBasicas.TabIndex = 58;
            this.btnBasicas.Text = "Consultar";
            this.btnBasicas.UseVisualStyleBackColor = false;
            this.btnBasicas.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dataConsultas
            // 
            this.dataConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataConsultas.Location = new System.Drawing.Point(0, 358);
            this.dataConsultas.Name = "dataConsultas";
            this.dataConsultas.ReadOnly = true;
            this.dataConsultas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataConsultas.Size = new System.Drawing.Size(1025, 343);
            this.dataConsultas.TabIndex = 53;
            // 
            // comboConsultasFunciones
            // 
            this.comboConsultasFunciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboConsultasFunciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboConsultasFunciones.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboConsultasFunciones.FormattingEnabled = true;
            this.comboConsultasFunciones.Items.AddRange(new object[] {
            "1.- Mostrar la cantidad de Empleados",
            "2.- Mostrar la cantidad de productos agrupados por el proveedor",
            "3.- Mostrar el precio maximo y minimo de los productos agrupados por el proveedor" +
                "",
            "4.- Mostrar el promedio de los precios de los productos agrupados por proveedor",
            "5.- Mostrar la cantidad de productos agrupados por material",
            "6.- Mostrar la suma de los precios de los productos cuyo nombre sea \'Diorama Anya" +
                " y Yor\'"});
            this.comboConsultasFunciones.Location = new System.Drawing.Point(282, 145);
            this.comboConsultasFunciones.Name = "comboConsultasFunciones";
            this.comboConsultasFunciones.Size = new System.Drawing.Size(507, 30);
            this.comboConsultasFunciones.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 50);
            this.label1.TabIndex = 68;
            this.label1.Text = "Consultas con funciones \r\nde agregación:";
            // 
            // comboConsultasMultitabla
            // 
            this.comboConsultasMultitabla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboConsultasMultitabla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboConsultasMultitabla.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboConsultasMultitabla.FormattingEnabled = true;
            this.comboConsultasMultitabla.Items.AddRange(new object[] {
            "1.- Mostrar el nombre y la existencia de los productos que se encuentran en el pr" +
                "oveedor \'00004\'",
            "2.- Mostrar el nombre y precio de los productos que abastecio el proveedor \'Voxel" +
                "ab\' y tambien que muestre el telefono y correo electronico del proveedor",
            "3.- Mostrar la fecha de compra que realizo el socio \'Rogelio\' y el precio de la c" +
                "ompra",
            "4.- Mostrar el monto y nombre del socio que se le hizo una compra en la fecha \'20" +
                "22-10-05\'",
            "5.- Mostrar el nombre, telefono del socio que se realizo una compra en la fecha \'" +
                "2022-10-09\' y el monto  haya sido de \'900\'",
            "6.- Mostrar el nombre y el precio de los productos que abastecio el proveedor \'An" +
                "ycubic\' y que muestre la direccion del proveedor"});
            this.comboConsultasMultitabla.Location = new System.Drawing.Point(282, 206);
            this.comboConsultasMultitabla.Name = "comboConsultasMultitabla";
            this.comboConsultasMultitabla.Size = new System.Drawing.Size(507, 30);
            this.comboConsultasMultitabla.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 25);
            this.label2.TabIndex = 70;
            this.label2.Text = "Consultas multitabla:";
            // 
            // comboSubconsultas
            // 
            this.comboSubconsultas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboSubconsultas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSubconsultas.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSubconsultas.FormattingEnabled = true;
            this.comboSubconsultas.Items.AddRange(new object[] {
            "1.- Mostrar los nombres de los productos que no hayan sido distribuidos por el pr" +
                "oveedor \'Creality\'",
            "2.- Mostrar todos los campos de los productos que pertenecen al proveedor \'Resin " +
                "3D\'",
            "3.- Mostrar el folio y la fecha de compra donde el codigo de Empleado haya sido d" +
                "e \'00010\'",
            "4.- Mostrar el codigo y nombre del producto que NO pertenezcan al proveedor \'SUNL" +
                "U\'",
            "5.- Mostrar el codigo y el nombre del producto que pertenezcan al proveedor \'Elee" +
                "go\' y \'Creality\'",
            "6.- Mostrar el monto de compra donde el codigo de Socio haya sido de \'00002\'"});
            this.comboSubconsultas.Location = new System.Drawing.Point(282, 258);
            this.comboSubconsultas.Name = "comboSubconsultas";
            this.comboSubconsultas.Size = new System.Drawing.Size(507, 30);
            this.comboSubconsultas.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(125, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 25);
            this.label3.TabIndex = 72;
            this.label3.Text = "Subconsultas:";
            // 
            // comboJoin
            // 
            this.comboJoin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboJoin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboJoin.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboJoin.FormattingEnabled = true;
            this.comboJoin.Items.AddRange(new object[] {
            "1.- Mostrar el nombre y el precio de los productos y el nombre del proveedor al q" +
                "ue pertenecen en una vista general",
            "2.- Mostrar la llave primaria y el nombre de los productos, tambien debe mostrar " +
                "la llave primaria, nombre y telefono del proveedor que lo abastecio en una vista" +
                " general",
            "3.- Mostrar los nombres de los socios y sus numeros en una vista general",
            "4.- Mostrar el telefono y el nombre del socio que tiene el correo \'Rogelio_Lopez@" +
                "gmail.com\' en una vista general",
            "5.- Mostrar el folio de compra y la llave primaria del cliente y el monto que se " +
                "adjuntaron en una vista general",
            "6.- Mostrar todos los datos de la compra donde la llave primaria del socio haya s" +
                "ido \'00001\'"});
            this.comboJoin.Location = new System.Drawing.Point(282, 322);
            this.comboJoin.Name = "comboJoin";
            this.comboJoin.Size = new System.Drawing.Size(507, 30);
            this.comboJoin.TabIndex = 75;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(199, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 25);
            this.label4.TabIndex = 74;
            this.label4.Text = "Join´s:";
            // 
            // btnFunciones
            // 
            this.btnFunciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.btnFunciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFunciones.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFunciones.Location = new System.Drawing.Point(795, 137);
            this.btnFunciones.Name = "btnFunciones";
            this.btnFunciones.Size = new System.Drawing.Size(89, 44);
            this.btnFunciones.TabIndex = 76;
            this.btnFunciones.Text = "Consultar";
            this.btnFunciones.UseVisualStyleBackColor = false;
            this.btnFunciones.Click += new System.EventHandler(this.btnFunciones_Click);
            // 
            // btnMultitabla
            // 
            this.btnMultitabla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.btnMultitabla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMultitabla.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMultitabla.Location = new System.Drawing.Point(795, 198);
            this.btnMultitabla.Name = "btnMultitabla";
            this.btnMultitabla.Size = new System.Drawing.Size(89, 44);
            this.btnMultitabla.TabIndex = 77;
            this.btnMultitabla.Text = "Consultar";
            this.btnMultitabla.UseVisualStyleBackColor = false;
            this.btnMultitabla.Click += new System.EventHandler(this.btnMultitabla_Click);
            // 
            // btnSubconsulta
            // 
            this.btnSubconsulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.btnSubconsulta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubconsulta.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubconsulta.Location = new System.Drawing.Point(795, 250);
            this.btnSubconsulta.Name = "btnSubconsulta";
            this.btnSubconsulta.Size = new System.Drawing.Size(89, 44);
            this.btnSubconsulta.TabIndex = 78;
            this.btnSubconsulta.Text = "Consultar";
            this.btnSubconsulta.UseVisualStyleBackColor = false;
            this.btnSubconsulta.Click += new System.EventHandler(this.btnSubconsulta_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.btnJoin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJoin.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJoin.Location = new System.Drawing.Point(795, 314);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(89, 44);
            this.btnJoin.TabIndex = 79;
            this.btnJoin.Text = "Consultar";
            this.btnJoin.UseVisualStyleBackColor = false;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRol.Location = new System.Drawing.Point(190, 47);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(75, 25);
            this.lblRol.TabIndex = 83;
            this.lblRol.Text = "label5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(133, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 32);
            this.label5.TabIndex = 82;
            this.label5.Text = "Rol:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(52, 47);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(75, 25);
            this.lblID.TabIndex = 81;
            this.lblID.Text = "label3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 32);
            this.label7.TabIndex = 80;
            this.label7.Text = "ID:";
            // 
            // Consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(1020, 702);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.btnSubconsulta);
            this.Controls.Add(this.btnMultitabla);
            this.Controls.Add(this.btnFunciones);
            this.Controls.Add(this.comboJoin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboSubconsultas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboConsultasMultitabla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboConsultasFunciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboConsultasBasicas);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnRegresarMenu);
            this.Controls.Add(this.btnBasicas);
            this.Controls.Add(this.dataConsultas);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Consultas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultas";
            this.Load += new System.EventHandler(this.Consultas_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Consultas_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Consultas_MouseDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataConsultas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picMini;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.ComboBox comboConsultasBasicas;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnRegresarMenu;
        private System.Windows.Forms.Button btnBasicas;
        private System.Windows.Forms.DataGridView dataConsultas;
        private System.Windows.Forms.ComboBox comboConsultasFunciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboConsultasMultitabla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboSubconsultas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboJoin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFunciones;
        private System.Windows.Forms.Button btnMultitabla;
        private System.Windows.Forms.Button btnSubconsulta;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label7;
    }
}