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
            this.bMaximizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bCerrar = new System.Windows.Forms.Button();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.bLeer = new System.Windows.Forms.Button();
            this.comboPerfiles = new System.Windows.Forms.ComboBox();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.titleBar.Controls.Add(this.bMaximizar);
            this.titleBar.Controls.Add(this.label1);
            this.titleBar.Controls.Add(this.bCerrar);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(1294, 63);
            this.titleBar.TabIndex = 0;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseDown);
            // 
            // bMaximizar
            // 
            this.bMaximizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bMaximizar.FlatAppearance.BorderSize = 0;
            this.bMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMaximizar.Image = global::Prueba_WebView.Properties.Resources.Maxi_1_tamaño_prueba4;
            this.bMaximizar.Location = new System.Drawing.Point(1195, 16);
            this.bMaximizar.Margin = new System.Windows.Forms.Padding(0);
            this.bMaximizar.Name = "bMaximizar";
            this.bMaximizar.Size = new System.Drawing.Size(41, 44);
            this.bMaximizar.TabIndex = 5;
            this.bMaximizar.UseVisualStyleBackColor = true;
            this.bMaximizar.Click += new System.EventHandler(this.bMaximizar_Click);
            this.bMaximizar.MouseEnter += new System.EventHandler(this.bMaximizar_MouseEnter);
            this.bMaximizar.MouseLeave += new System.EventHandler(this.bMaximizar_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Descarga XML automatizada";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.webView21.Size = new System.Drawing.Size(1007, 631);
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
            this.bLeer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLeer.Location = new System.Drawing.Point(1174, 85);
            this.bLeer.Name = "bLeer";
            this.bLeer.Size = new System.Drawing.Size(0, 0);
            this.bLeer.TabIndex = 3;
            this.bLeer.Text = "Leer";
            this.bLeer.UseVisualStyleBackColor = false;
            this.bLeer.Click += new System.EventHandler(this.bLeer_Click);
            // 
            // comboPerfiles
            // 
            this.comboPerfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboPerfiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboPerfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPerfiles.FormattingEnabled = true;
            this.comboPerfiles.Location = new System.Drawing.Point(1116, 265);
            this.comboPerfiles.Name = "comboPerfiles";
            this.comboPerfiles.Size = new System.Drawing.Size(156, 23);
            this.comboPerfiles.TabIndex = 7;
            this.comboPerfiles.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboPerfiles_DrawItem);
            this.comboPerfiles.SelectedIndexChanged += new System.EventHandler(this.comboPerfiles_SelectedIndexChanged);
            // 
            // txtRFC
            // 
            this.txtRFC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFC.Location = new System.Drawing.Point(1116, 185);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtRFC.Size = new System.Drawing.Size(156, 22);
            this.txtRFC.TabIndex = 8;
            this.txtRFC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(1140, 225);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtPassword.Size = new System.Drawing.Size(132, 22);
            this.txtPassword.TabIndex = 9;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1049, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "RFC";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1046, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Contraseña";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1050, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Perfil";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.panel1.Location = new System.Drawing.Point(1051, 307);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 17);
            this.panel1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1056, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Autorrellenar datos";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Image = global::Prueba_WebView.Properties.Resources.guardar3;
            this.btnGuardar.Location = new System.Drawing.Point(1170, 127);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 43);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsertar.Image = global::Prueba_WebView.Properties.Resources.enter3;
            this.btnInsertar.Location = new System.Drawing.Point(1051, 127);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(100, 43);
            this.btnInsertar.TabIndex = 6;
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1294, 742);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtRFC);
            this.Controls.Add(this.comboPerfiles);
            this.Controls.Add(this.btnInsertar);
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
        private System.Windows.Forms.Button bLeer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.ComboBox comboPerfiles;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bMaximizar;
    }
}

