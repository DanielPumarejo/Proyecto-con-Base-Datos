namespace Proyecto
{
    partial class FrmBodega
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
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnBuscarBodg = new System.Windows.Forms.Button();
            this.dtgProductos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAtras
            // 
            this.btnAtras.FlatAppearance.BorderSize = 0;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.Image = global::Proyecto.Properties.Resources.atras2;
            this.btnAtras.Location = new System.Drawing.Point(6, 5);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(70, 72);
            this.btnAtras.TabIndex = 7;
            this.btnAtras.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnBuscarBodg
            // 
            this.btnBuscarBodg.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarBodg.FlatAppearance.BorderSize = 0;
            this.btnBuscarBodg.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBuscarBodg.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBuscarBodg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarBodg.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarBodg.Image = global::Proyecto.Properties.Resources.buscar11;
            this.btnBuscarBodg.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscarBodg.Location = new System.Drawing.Point(519, 22);
            this.btnBuscarBodg.Name = "btnBuscarBodg";
            this.btnBuscarBodg.Size = new System.Drawing.Size(71, 55);
            this.btnBuscarBodg.TabIndex = 4;
            this.btnBuscarBodg.Text = "Buscar";
            this.btnBuscarBodg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarBodg.UseVisualStyleBackColor = false;
            this.btnBuscarBodg.Click += new System.EventHandler(this.btnBuscarBodg_Click);
            // 
            // dtgProductos
            // 
            this.dtgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProductos.Location = new System.Drawing.Point(23, 97);
            this.dtgProductos.Name = "dtgProductos";
            this.dtgProductos.Size = new System.Drawing.Size(596, 223);
            this.dtgProductos.TabIndex = 8;
            this.dtgProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgProductos_CellContentClick);
            this.dtgProductos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgProductos_CellMouseDoubleClick);
            // 
            // FrmBodega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 343);
            this.Controls.Add(this.dtgProductos);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnBuscarBodg);
            this.Name = "FrmBodega";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.TransparencyKey = System.Drawing.Color.LavenderBlush;
            this.Load += new System.EventHandler(this.FrmBodega_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBuscarBodg;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.DataGridView dtgProductos;
    }
}