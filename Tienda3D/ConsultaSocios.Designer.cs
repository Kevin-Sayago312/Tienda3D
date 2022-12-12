
namespace Tienda3D
{
    partial class ConsultaSocios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaSocios));
            this.comboBusqueda = new System.Windows.Forms.ComboBox();
            this.txtbusqueda = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.picMini = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.dataSocio = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSocio)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBusqueda
            // 
            this.comboBusqueda.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBusqueda.FormattingEnabled = true;
            this.comboBusqueda.Items.AddRange(new object[] {
            "Folio",
            "Fecha",
            "Monto",
            "ClaveF",
            "ID_empleadoF"});
            this.comboBusqueda.Location = new System.Drawing.Point(200, 49);
            this.comboBusqueda.Name = "comboBusqueda";
            this.comboBusqueda.Size = new System.Drawing.Size(196, 30);
            this.comboBusqueda.TabIndex = 77;
            this.comboBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBusqueda_KeyPress);
            // 
            // txtbusqueda
            // 
            this.txtbusqueda.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbusqueda.Location = new System.Drawing.Point(402, 48);
            this.txtbusqueda.MaxLength = 30;
            this.txtbusqueda.Name = "txtbusqueda";
            this.txtbusqueda.Size = new System.Drawing.Size(310, 31);
            this.txtbusqueda.TabIndex = 76;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(100, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 25);
            this.label10.TabIndex = 75;
            this.label10.Text = "Buscar";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.picMini);
            this.panel2.Controls.Add(this.pictureBox9);
            this.panel2.Location = new System.Drawing.Point(-10, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(863, 37);
            this.panel2.TabIndex = 74;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(81, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(249, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "CONSULTA DE SOCIOS";
            // 
            // picMini
            // 
            this.picMini.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMini.Image = ((System.Drawing.Image)(resources.GetObject("picMini.Image")));
            this.picMini.Location = new System.Drawing.Point(796, 3);
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
            // dataSocio
            // 
            this.dataSocio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSocio.Location = new System.Drawing.Point(-1, 85);
            this.dataSocio.Name = "dataSocio";
            this.dataSocio.ReadOnly = true;
            this.dataSocio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataSocio.Size = new System.Drawing.Size(854, 394);
            this.dataSocio.TabIndex = 73;
            this.dataSocio.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataCompra_CellDoubleClick);
            // 
            // ConsultaSocios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(852, 482);
            this.Controls.Add(this.comboBusqueda);
            this.Controls.Add(this.txtbusqueda);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataSocio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConsultaSocios";
            this.Text = "ConsultaSocios";
            this.Load += new System.EventHandler(this.ConsultaSocios_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ConsultaSocios_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ConsultaSocios_MouseDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSocio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBusqueda;
        private System.Windows.Forms.TextBox txtbusqueda;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picMini;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.DataGridView dataSocio;
    }
}