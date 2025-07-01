namespace Prueba_WebView
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bBuscar2 = new System.Windows.Forms.Button();
            this.bBuscar = new System.Windows.Forms.Button();
            this.tBuscar = new System.Windows.Forms.TextBox();
            this.bCerrar = new System.Windows.Forms.Button();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.bLeer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.comboPerfiles = new System.Windows.Forms.ComboBox();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.titleBar.Controls.Add(this.label1);
            this.titleBar.Controls.Add(this.bBuscar2);
            this.titleBar.Controls.Add(this.bBuscar);
            this.titleBar.Controls.Add(this.tBuscar);
            this.titleBar.Controls.Add(this.bCerrar);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(1294, 63);
            this.titleBar.TabIndex = 0;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("JetBrainsMonoNL NF SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dscarga XML automatizada";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // bBuscar2
            // 
            this.bBuscar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bBuscar2.BackColor = System.Drawing.Color.White;
            this.bBuscar2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bBuscar2.Font = new System.Drawing.Font("JetBrainsMono NFM", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBuscar2.Location = new System.Drawing.Point(1071, 26);
            this.bBuscar2.Name = "bBuscar2";
            this.bBuscar2.Size = new System.Drawing.Size(85, 24);
            this.bBuscar2.TabIndex = 3;
            this.bBuscar2.Text = "Apellido";
            this.bBuscar2.UseVisualStyleBackColor = false;
            this.bBuscar2.Click += new System.EventHandler(this.bBuscar2_Click);
            // 
            // bBuscar
            // 
            this.bBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bBuscar.BackColor = System.Drawing.Color.White;
            this.bBuscar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bBuscar.Font = new System.Drawing.Font("JetBrainsMono NFM", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBuscar.Location = new System.Drawing.Point(986, 26);
            this.bBuscar.Name = "bBuscar";
            this.bBuscar.Size = new System.Drawing.Size(74, 25);
            this.bBuscar.TabIndex = 2;
            this.bBuscar.Text = "Nombre";
            this.bBuscar.UseVisualStyleBackColor = false;
            this.bBuscar.Click += new System.EventHandler(this.bBuscar_Click);
            // 
            // tBuscar
            // 
            this.tBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBuscar.Font = new System.Drawing.Font("JetBrainsMono NFM", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBuscar.Location = new System.Drawing.Point(298, 26);
            this.tBuscar.Multiline = true;
            this.tBuscar.Name = "tBuscar";
            this.tBuscar.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tBuscar.Size = new System.Drawing.Size(673, 24);
            this.tBuscar.TabIndex = 1;
            this.tBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bCerrar
            // 
            this.bCerrar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bCerrar.FlatAppearance.BorderSize = 0;
            this.bCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCerrar.Image = global::Prueba_WebView.Properties.Resources.close;
            this.bCerrar.Location = new System.Drawing.Point(1231, 16);
            this.bCerrar.Margin = new System.Windows.Forms.Padding(0);
            this.bCerrar.Name = "bCerrar";
            this.bCerrar.Size = new System.Drawing.Size(63, 44);
            this.bCerrar.TabIndex = 0;
            this.bCerrar.UseVisualStyleBackColor = true;
            this.bCerrar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bCerrar_MouseDown);
            this.bCerrar.MouseEnter += new System.EventHandler(this.bCerrar_MouseEnter);
            this.bCerrar.MouseLeave += new System.EventHandler(this.bCerrar_MouseLeave);
            this.bCerrar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bCerrar_MouseUp);
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(28, 86);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(1059, 631);
            this.webView21.Source = new System.Uri("https://portal.facturaelectronica.sat.gob.mx/", System.UriKind.Absolute);
            this.webView21.TabIndex = 1;
            this.webView21.ZoomFactor = 1D;
            this.webView21.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.webView21_NavigationCompleted);
            // 
            // bLeer
            // 
            this.bLeer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bLeer.BackColor = System.Drawing.Color.White;
            this.bLeer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bLeer.Font = new System.Drawing.Font("JetBrainsMono NFM", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLeer.Location = new System.Drawing.Point(1174, 85);
            this.bLeer.Name = "bLeer";
            this.bLeer.Size = new System.Drawing.Size(0, 0);
            this.bLeer.TabIndex = 3;
            this.bLeer.Text = "Leer";
            this.bLeer.UseVisualStyleBackColor = false;
            this.bLeer.Click += new System.EventHandler(this.bLeer_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("JetBrainsMonoNL NF SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1112, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Auto-Insert RFC";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsertar.Image = global::Prueba_WebView.Properties.Resources.enter2;
            this.btnInsertar.Location = new System.Drawing.Point(1116, 127);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(75, 43);
            this.btnInsertar.TabIndex = 6;
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // comboPerfiles
            // 
            this.comboPerfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboPerfiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboPerfiles.Font = new System.Drawing.Font("JetBrainsMonoNL NF", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPerfiles.FormattingEnabled = true;
            this.comboPerfiles.Location = new System.Drawing.Point(1116, 265);
            this.comboPerfiles.Name = "comboPerfiles";
            this.comboPerfiles.Size = new System.Drawing.Size(156, 26);
            this.comboPerfiles.TabIndex = 7;
            this.comboPerfiles.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboPerfiles_DrawItem);
            this.comboPerfiles.SelectedIndexChanged += new System.EventHandler(this.comboPerfiles_SelectedIndexChanged);
            // 
            // txtRFC
            // 
            this.txtRFC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRFC.Font = new System.Drawing.Font("JetBrainsMono NFM", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFC.Location = new System.Drawing.Point(1116, 185);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtRFC.Size = new System.Drawing.Size(156, 25);
            this.txtRFC.TabIndex = 8;
            this.txtRFC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Font = new System.Drawing.Font("JetBrainsMono NFM", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(1116, 225);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtPassword.Size = new System.Drawing.Size(156, 25);
            this.txtPassword.TabIndex = 9;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Image = global::Prueba_WebView.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(1197, 127);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 43);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1294, 742);
            this.ControlBox = false;
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtRFC);
            this.Controls.Add(this.comboPerfiles);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bLeer);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.titleBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Button bCerrar;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.Button bBuscar;
        private System.Windows.Forms.TextBox tBuscar;
        private System.Windows.Forms.Button bBuscar2;
        private System.Windows.Forms.Button bLeer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.ComboBox comboPerfiles;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnGuardar;
    }
}

