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
            this.bBuscar = new System.Windows.Forms.Button();
            this.tBuscar = new System.Windows.Forms.TextBox();
            this.bCerrar = new System.Windows.Forms.Button();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.bLeer = new System.Windows.Forms.Button();
            this.titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.titleBar.Controls.Add(this.bLeer);
            this.titleBar.Controls.Add(this.bBuscar);
            this.titleBar.Controls.Add(this.tBuscar);
            this.titleBar.Controls.Add(this.bCerrar);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(1094, 49);
            this.titleBar.TabIndex = 0;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseDown);
            // 
            // bBuscar
            // 
            this.bBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bBuscar.BackColor = System.Drawing.Color.White;
            this.bBuscar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bBuscar.Location = new System.Drawing.Point(806, 12);
            this.bBuscar.Name = "bBuscar";
            this.bBuscar.Size = new System.Drawing.Size(72, 24);
            this.bBuscar.TabIndex = 2;
            this.bBuscar.Text = "Insertar";
            this.bBuscar.UseVisualStyleBackColor = false;
            this.bBuscar.Click += new System.EventHandler(this.bBuscar_Click);
            // 
            // tBuscar
            // 
            this.tBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tBuscar.Location = new System.Drawing.Point(28, 12);
            this.tBuscar.Multiline = true;
            this.tBuscar.Name = "tBuscar";
            this.tBuscar.Size = new System.Drawing.Size(772, 24);
            this.tBuscar.TabIndex = 1;
            this.tBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBuscar.WordWrap = false;
            // 
            // bCerrar
            // 
            this.bCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.bCerrar.FlatAppearance.BorderSize = 0;
            this.bCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCerrar.Image = global::Prueba_WebView.Properties.Resources.close;
            this.bCerrar.Location = new System.Drawing.Point(1051, 0);
            this.bCerrar.Name = "bCerrar";
            this.bCerrar.Size = new System.Drawing.Size(43, 49);
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
            this.webView21.Location = new System.Drawing.Point(28, 66);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(928, 551);
            this.webView21.Source = new System.Uri("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_input_test", System.UriKind.Absolute);
            this.webView21.TabIndex = 1;
            this.webView21.ZoomFactor = 1D;
            // 
            // bLeer
            // 
            this.bLeer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bLeer.BackColor = System.Drawing.Color.White;
            this.bLeer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bLeer.Location = new System.Drawing.Point(884, 12);
            this.bLeer.Name = "bLeer";
            this.bLeer.Size = new System.Drawing.Size(72, 24);
            this.bLeer.TabIndex = 3;
            this.bLeer.Text = "Leer";
            this.bLeer.UseVisualStyleBackColor = false;
            this.bLeer.Click += new System.EventHandler(this.bLeer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1094, 642);
            this.ControlBox = false;
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

        }

        #endregion

        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Button bCerrar;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.Button bBuscar;
        private System.Windows.Forms.TextBox tBuscar;
        private System.Windows.Forms.Button bLeer;
    }
}

