using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Prueba_WebView
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private const int EM_SETCUEBANNER = 0x1501;

        private Image original;
        private Image hover;
        private Image press;
        private Image max_max;
        private Image max_normal;
        private Image max_max_hover;
        private Image max_normal_hover;

        string archivoPerfiles = Path.Combine(Application.StartupPath, "perfiles.txt");
        Dictionary<string, string> perfiles = new Dictionary<string, string>();

        // Variables para control de descarga
        private bool descargaEnProceso = false;
        private CancellationTokenSource cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();

            SendMessage(txtRFC.Handle, EM_SETCUEBANNER, 0, "Inserte RFC...");
            SendMessage(txtPassword.Handle, EM_SETCUEBANNER, 0, "Inserte contraseña...");
            SendMessage(txtRutaDescarga.Handle, EM_SETCUEBANNER, 0, "Ruta de descarga...");

            bCerrar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            bCerrar.FlatAppearance.MouseOverBackColor = Color.Transparent;

            bMaximizar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            bMaximizar.FlatAppearance.MouseOverBackColor = Color.Transparent;

            original = Properties.Resources.close;
            hover = Properties.Resources.close_hover;
            press = Properties.Resources.close_press;

            max_max = Properties.Resources.Maxi_1_tamaño_prueba4;
            max_max_hover = Properties.Resources.Maxi_1hover;
            max_normal = Properties.Resources.Maxi_2;
            max_normal_hover = Properties.Resources.Maxi_2hover;

            // Configurar fechas por defecto
            dtpFechaInicio.Value = DateTime.Now.AddDays(-30);
            dtpFechaFin.Value = DateTime.Now;
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
            System.Windows.Forms.ComboBox combo = sender as System.Windows.Forms.ComboBox;
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

        private void bMaximizar_MouseEnter(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                bMaximizar.Image = max_normal_hover;
            }
            else
            {
                bMaximizar.Image = max_max_hover;
            }
        }

        private void bMaximizar_MouseLeave(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                bMaximizar.Image = max_normal;
            }
            else
            {
                bMaximizar.Image = max_max;
            }
        }

        private void bMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                bMaximizar.Image = max_normal_hover;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                bMaximizar.Image = max_max_hover;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        // ==================== FUNCIONALIDADES DE DESCARGA AUTOMATIZADA ====================

        private void btnSeleccionarRuta_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Selecciona la carpeta donde descargar los XMLs";
                folderDialog.ShowNewFolderButton = true;

                if (!string.IsNullOrEmpty(txtRutaDescarga.Text) && Directory.Exists(txtRutaDescarga.Text))
                {
                    folderDialog.SelectedPath = txtRutaDescarga.Text;
                }

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtRutaDescarga.Text = folderDialog.SelectedPath;
                }
            }
        }

        private async void btnIniciarDescarga_Click(object sender, EventArgs e)
        {
            if (descargaEnProceso)
            {
                // Si está en proceso, cancelar
                cancellationTokenSource?.Cancel();
                return;
            }

            // Validaciones
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRutaDescarga.Text))
            {
                MessageBox.Show("Debe especificar una ruta de descarga.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Crear directorio si no existe
                if (!Directory.Exists(txtRutaDescarga.Text))
                {
                    Directory.CreateDirectory(txtRutaDescarga.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el directorio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar que estemos en la página correcta
            string currentUrl = webView21.Source?.ToString() ?? "";
            if (!currentUrl.Contains("portalcfdi.facturaelectronica.sat.gob.mx"))
            {
                MessageBox.Show("Debe estar en la página de Consulta Receptor del SAT para iniciar la descarga.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await IniciarDescargaAutomatizada();
        }

        private async Task IniciarDescargaAutomatizada()
        {
            descargaEnProceso = true;
            cancellationTokenSource = new CancellationTokenSource();

            // Cambiar UI
            btnIniciarDescarga.Text = "CANCELAR";
            btnIniciarDescarga.BackColor = Color.FromArgb(204, 0, 0);
            progressBar.Value = 0;
            lblEstado.Text = "Iniciando descarga...";
            lblEstado.ForeColor = Color.LightBlue;

            try
            {
                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime fechaFin = dtpFechaFin.Value.Date;

                // Calcular total de días
                int totalDias = (int)(fechaFin - fechaInicio).TotalDays + 1;
                progressBar.Maximum = totalDias;

                string rutaDescarga = txtRutaDescarga.Text;
                int xmlsDescargados = 0;

                DateTime fechaActual = fechaInicio;
                int diaActual = 0;

                while (fechaActual <= fechaFin && !cancellationTokenSource.Token.IsCancellationRequested)
                {
                    diaActual++;
                    lblEstado.Text = $"Procesando: {fechaActual.ToString("dd/MM/yyyy")} ({diaActual}/{totalDias})";

                    try
                    {
                        int xmlsDelDia = await ProcesarFecha(fechaActual, rutaDescarga, cancellationTokenSource.Token);
                        xmlsDescargados += xmlsDelDia;

                        lblEstado.Text = $"Fecha {fechaActual.ToString("dd/MM/yyyy")}: {xmlsDelDia} XMLs descargados";

                        progressBar.Value = diaActual;

                        // Pausa entre fechas para no sobrecargar el servidor
                        await Task.Delay(2000, cancellationTokenSource.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch (Exception ex)
                    {
                        lblEstado.Text = $"Error en fecha {fechaActual.ToString("dd/MM/yyyy")}: {ex.Message}";
                        lblEstado.ForeColor = Color.Orange;
                        await Task.Delay(3000); // Pausa en caso de error
                    }

                    fechaActual = fechaActual.AddDays(1);
                }

                if (cancellationTokenSource.Token.IsCancellationRequested)
                {
                    lblEstado.Text = "Descarga cancelada por el usuario";
                    lblEstado.ForeColor = Color.Orange;
                }
                else
                {
                    lblEstado.Text = $"Descarga completada. Total: {xmlsDescargados} XMLs";
                    lblEstado.ForeColor = Color.LightGreen;
                    progressBar.Value = progressBar.Maximum;

                    MessageBox.Show($"Descarga completada exitosamente.\n\nXMLs descargados: {xmlsDescargados}\nRuta: {rutaDescarga}",
                                    "Descarga Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"Error general: {ex.Message}";
                lblEstado.ForeColor = Color.Red;
                MessageBox.Show($"Error durante la descarga: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Restaurar UI
                descargaEnProceso = false;
                btnIniciarDescarga.Text = "INICIAR DESCARGA";
                btnIniciarDescarga.BackColor = Color.FromArgb(0, 122, 204);
                cancellationTokenSource?.Dispose();
                cancellationTokenSource = null;
            }
        }

        private async Task<int> ProcesarFecha(DateTime fecha, string rutaDescarga, CancellationToken cancellationToken)
        {
            int xmlsDescargados = 0;

            try
            {
                // Configurar fecha en los campos del formulario
                await ConfigurarFechaEnFormulario(fecha, cancellationToken);

                // Hacer clic en buscar
                await EjecutarBusqueda(cancellationToken);

                // Esperar a que carguen los resultados
                await Task.Delay(3000, cancellationToken);

                // Verificar si hay resultados y descargarlos
                xmlsDescargados = await DescargarXMLsDeResultados(rutaDescarga, fecha, cancellationToken);

                return xmlsDescargados;
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error procesando fecha {fecha.ToString("dd/MM/yyyy")}: {ex.Message}");
            }
        }

        private async Task ConfigurarFechaEnFormulario(DateTime fecha, CancellationToken cancellationToken)
        {
            string fechaStr = fecha.ToString("dd/MM/yyyy");

            string script = $@"
            (function() {{
                try {{
                    // Buscar los campos de fecha
                    const fechaInicio = document.querySelector('input[id*=""FechaInicial""], input[id*=""fechaInicio""], input[name*=""fecha""]');
                    const fechaFin = document.querySelector('input[id*=""FechaFinal""], input[id*=""fechaFin""], input[name*=""fecha""]');
                    
                    if (fechaInicio) {{
                        fechaInicio.value = '{fechaStr}';
                        fechaInicio.dispatchEvent(new Event('change', {{ bubbles: true }}));
                    }}
                    
                    if (fechaFin && fechaFin !== fechaInicio) {{
                        fechaFin.value = '{fechaStr}';
                        fechaFin.dispatchEvent(new Event('change', {{ bubbles: true }}));
                    }}
                    
                    // Intentar buscar campos alternativos si no se encontraron los anteriores
                    if (!fechaInicio) {{
                        const allInputs = document.querySelectorAll('input[type=""text""]');
                        for (let input of allInputs) {{
                            if (input.placeholder && input.placeholder.toLowerCase().includes('fecha')) {{
                                input.value = '{fechaStr}';
                                input.dispatchEvent(new Event('change', {{ bubbles: true }}));
                                break;
                            }}
                        }}
                    }}
                    
                    return 'OK';
                }} catch (e) {{
                    return 'Error: ' + e.message;
                }}
            }})();
            ";

            await webView21.ExecuteScriptAsync(script);
        }

        private async Task EjecutarBusqueda(CancellationToken cancellationToken)
        {
            string script = @"
            (function() {
                try {
                    // Buscar botón de búsqueda/consultar
                    const btnBuscar = document.querySelector('input[type=""submit""], button[type=""submit""], input[value*=""Buscar""], input[value*=""Consultar""], button[onclick*=""buscar""]');
                    
                    if (btnBuscar) {
                        btnBuscar.click();
                        return 'Búsqueda iniciada';
                    } else {
                        // Buscar por texto del botón
                        const allButtons = document.querySelectorAll('input, button');
                        for (let btn of allButtons) {
                            if (btn.value && (btn.value.includes('Buscar') || btn.value.includes('Consultar'))) {
                                btn.click();
                                return 'Búsqueda iniciada (método alternativo)';
                            }
                        }
                        return 'No se encontró botón de búsqueda';
                    }
                } catch (e) {
                    return 'Error: ' + e.message;
                }
            })();
            ";

            await webView21.ExecuteScriptAsync(script);
        }

        private async Task<int> DescargarXMLsDeResultados(string rutaDescarga, DateTime fecha, CancellationToken cancellationToken)
        {
            int xmlsDescargados = 0;

            try
            {
                // Configurar la descarga para interceptar archivos XML
                string fechaCarpeta = fecha.ToString("yyyy-MM-dd");
                string rutaFecha = Path.Combine(rutaDescarga, fechaCarpeta);

                if (!Directory.Exists(rutaFecha))
                {
                    Directory.CreateDirectory(rutaFecha);
                }

                // Script para buscar y descargar XMLs
                string script = @"
                (function() {
                    try {
                        let xmlsEncontrados = 0;
                        
                        // Buscar enlaces de descarga XML
                        const enlacesXML = document.querySelectorAll('a[href*="".xml""], a[onclick*=""xml""], a[title*=""XML""], a[alt*=""XML""]');
                        
                        for (let enlace of enlacesXML) {
                            if (enlace.href && enlace.href.includes('.xml')) {
                                // Simular clic en el enlace de descarga
                                enlace.click();
                                xmlsEncontrados++;
                            }
                        }
                        
                        // Buscar botones de descarga
                        const botonesDescarga = document.querySelectorAll('input[value*=""Descargar""], button[onclick*=""descargar""], input[title*=""XML""]');
                        
                        for (let boton of botonesDescarga) {
                            boton.click();
                            xmlsEncontrados++;
                        }
                        
                        return xmlsEncontrados;
                    } catch (e) {
                        return 0;
                    }
                })();
                ";

                string resultado = await webView21.ExecuteScriptAsync(script);

                if (int.TryParse(resultado, out int xmlsEncontrados))
                {
                    xmlsDescargados = xmlsEncontrados;
                }

                // Pausa para permitir que se completen las descargas
                if (xmlsDescargados > 0)
                {
                    await Task.Delay(5000, cancellationToken);
                }

                return xmlsDescargados;
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error descargando XMLs: {ex.Message}");
            }
        }
    }
}