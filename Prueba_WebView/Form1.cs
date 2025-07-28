using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Threading;
using Microsoft.Web.WebView2.Core;
using System.IO;

namespace Prueba_WebView
{
    //nueva rama
    
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private const int EM_SETCUEBANNER = 0x1501;


        private Image original;
        private Image hover;
        private Image press;

        string archivoPerfiles = Path.Combine(Application.StartupPath, "perfiles.txt");
        Dictionary<string, string> perfiles = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();

            SendMessage(txtRFC.Handle, EM_SETCUEBANNER, 0, "Inserte RFC...");
            SendMessage(txtPassword.Handle, EM_SETCUEBANNER, 0, "Inserte contraseña...");


            bCerrar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            bCerrar.FlatAppearance.MouseOverBackColor = Color.Transparent;


            original = Properties.Resources.close;
            hover = Properties.Resources.close_hover;
            press = Properties.Resources.close_press;

        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private async void Form1_Load(object sender, EventArgs e)
        {
            comboPerfiles.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPerfiles.DrawMode = DrawMode.OwnerDrawFixed;

            await webView21.EnsureCoreWebView2Async();

            if (File.Exists(archivoPerfiles))
            {
                foreach (var linea in File.ReadAllLines(archivoPerfiles))
                {
                    var partes = linea.Split('|');
                    if (partes.Length == 2)
                    {
                        string rfc = partes[0];
                        string pass = partes[1];
                        perfiles[rfc] = pass;

                        comboPerfiles.Items.Add(rfc);
                    }
                }
            }
        }

        private void titleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void bCerrar_MouseEnter(object sender, EventArgs e)
        {
            bCerrar.Image = hover;
        }

        private void bCerrar_MouseLeave(object sender, EventArgs e)
        {
            bCerrar.Image = original;
        }

        private void bCerrar_MouseDown(object sender, MouseEventArgs e)
        {
            bCerrar.Image = press;
        }

        private void bCerrar_MouseUp(object sender, MouseEventArgs e)
        {
            Thread.Sleep(100);
            System.Environment.Exit(0);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;
            const int HTCLIENT = 1;
            const int HTLEFT = 10;
            const int HTRIGHT = 11;
            const int HTTOP = 12;
            const int HTTOPLEFT = 13;
            const int HTTOPRIGHT = 14;
            const int HTBOTTOM = 15;
            const int HTBOTTOMLEFT = 16;
            const int HTBOTTOMRIGHT = 17;

            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);

                Point pos = PointToClient(new Point(m.LParam.ToInt32()));
                int gripSize = 20;

                if (pos.X <= gripSize && pos.Y <= gripSize)
                    m.Result = (IntPtr)HTTOPLEFT;
                else if (pos.X >= Width - gripSize && pos.Y <= gripSize)
                    m.Result = (IntPtr)HTTOPRIGHT;
                else if (pos.X <= gripSize && pos.Y >= Height - gripSize)
                    m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (pos.X >= Width - gripSize && pos.Y >= Height - gripSize)
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                else if (pos.X <= gripSize)
                    m.Result = (IntPtr)HTLEFT;
                else if (pos.X >= Width - gripSize)
                    m.Result = (IntPtr)HTRIGHT;
                else if (pos.Y <= gripSize)
                    m.Result = (IntPtr)HTTOP;
                else if (pos.Y >= Height - gripSize)
                    m.Result = (IntPtr)HTBOTTOM;
                else
                    m.Result = (IntPtr)HTCLIENT;

                return;
            }

            base.WndProc(ref m);
        }

        private async void bBuscar_Click(object sender, EventArgs e)
        {
            string texto = tBuscar.Text.Replace("'", "\\'"); // Reemplazarr comillas simples

            // Script para insertar el texto en el campo de búsqueda
            string insertarScript = $@"
            (function() {{
                const iframe = document.getElementById(""iframeResult"");
                const input = iframe.contentDocument.getElementsByName(""fname"")[0];
                if (input) {{
                    input.value = '{texto}';
                }}
            }})();
            ";

            await webView21.ExecuteScriptAsync(insertarScript);
        }

        private async void bLeer_Click(object sender, EventArgs e)
        {
            string leerScript = @"
                (function() {
                    const iframe = document.getElementById('iframeResult');
                    const input1 = iframe.contentDocument.getElementsByName('fname')[0];
                    const input2 = iframe.contentDocument.getElementsByName('lname')[0];
                    if (input1.value != '' && input2.value != '') {
                        alert('Nombre: ' + input1.value + '\nApellido: ' + input2.value);
                    } else {
                        alert('Por favor llene el formulario');
                    }
                })();
            ";

            string resultado = await webView21.ExecuteScriptAsync(leerScript);
        }

        private async void bBuscar2_Click(object sender, EventArgs e)
        {
            string texto = tBuscar.Text.Replace("'", "\\'"); // Reemplazarr comillas simples

            // Script para insertar el texto en el campo de búsqueda
            string insertarScript2 = $@"
            (function() {{
                const iframe = document.getElementById(""iframeResult"");
                const input = iframe.contentDocument.getElementsByName(""lname"")[0];
                if (input) {{
                    input.value = '{texto}';
                }}
            }})();
            ";

            await webView21.ExecuteScriptAsync(insertarScript2);
        }

        private void webView21_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (webView21.Source.ToString().TrimEnd('/') == "https://portal.facturaelectronica.sat.gob.mx/TerminosCondiciones")
            {
                webView21.CoreWebView2.Navigate("https://portalcfdi.facturaelectronica.sat.gob.mx/ConsultaReceptor.aspx");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string rfc = txtRFC.Text.Trim();
            string password = txtPassword.Text;

            if (!string.IsNullOrWhiteSpace(rfc) && !string.IsNullOrWhiteSpace(password))
            {
                perfiles[rfc] = password;

                if (!comboPerfiles.Items.Contains(rfc))
                    comboPerfiles.Items.Add(rfc);

                // Guardar todos los perfiles al archivo
                File.WriteAllLines(archivoPerfiles, perfiles.Select(p => $"{p.Key}|{p.Value}"));

                MessageBox.Show("Perfil guardado.");
            }
            else
            {
                MessageBox.Show("RFC y contraseña no pueden estar vacíos.");
            }
        }

        private async void btnInsertar_Click(object sender, EventArgs e)
        {
            string perfilSeleccionado = comboPerfiles.SelectedItem?.ToString();

            if (perfilSeleccionado != null && perfiles.ContainsKey(perfilSeleccionado))
            {
                string rfc = perfilSeleccionado;
                string password = perfiles[perfilSeleccionado];

                string script = $@"
        (function() {{
            const inputRFC = document.getElementsByName('Ecom_User_ID')[0];
            const inputCONTRA = document.getElementsByName('Ecom_Password')[0];                    
            if(inputRFC && inputCONTRA) {{
                inputRFC.value = '{rfc}';
                inputCONTRA.value = '{password}';
            }} else {{
                alert('No se encontraron los campos de RFC o contraseña.');
            }}
        }})();
        ";

                await webView21.ExecuteScriptAsync(script);
            }
            else
            {
                MessageBox.Show("Selecciona un perfil válido.");
            }
        }

        private void comboPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rfc = comboPerfiles.SelectedItem?.ToString();

            if (rfc != null && perfiles.ContainsKey(rfc))
            {
                txtRFC.Text = rfc;
                txtPassword.Text = perfiles[rfc];
            }
        }

        private void comboPerfiles_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            e.DrawBackground();

            string texto = "";

            if (e.Index < 0)
            {
                // Si no hay selección, mostramos el placeholder
                texto = "Sin perfil...";
                using (Brush brush = new SolidBrush(Color.Gray))
                {
                    e.Graphics.DrawString(texto, combo.Font, brush, e.Bounds);
                }
            }
            else
            {
                // Ítem normal
                texto = combo.Items[e.Index].ToString();
                using (Brush brush = new SolidBrush(combo.ForeColor))
                {
                    e.Graphics.DrawString(texto, combo.Font, brush, e.Bounds);
                }
            }

            e.DrawFocusRectangle();
        }
    }
}
