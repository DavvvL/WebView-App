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

        /*private async void bLeer_Click(object sender, EventArgs e)
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
        }*/

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
                lblEstado.Text = $"Configurando fecha: {fecha.ToString("dd/MM/yyyy")}";

                // Configurar fecha en los campos del formulario
                await ConfigurarFechaEnFormulario(fecha, cancellationToken);

                lblEstado.Text = $"Ejecutando búsqueda para: {fecha.ToString("dd/MM/yyyy")}";

                // Hacer clic en buscar
                await EjecutarBusqueda(cancellationToken);

                // Esperar más tiempo a que carguen los resultados
                lblEstado.Text = $"Esperando resultados para: {fecha.ToString("dd/MM/yyyy")}";
                await Task.Delay(8000, cancellationToken); // Aumentar a 8 segundos

                // VERIFICAR que la página cambió antes de descargar
                string verificarScript = @"
        (function() {
            // Buscar indicadores de que hay resultados nuevos
            var tablas = document.querySelectorAll('table');
            var filas = document.querySelectorAll('tr');
            var elementosDescarga = document.querySelectorAll('[onclick*=""AccionCfdi""]');
            
            return {
                tablas: tablas.length,
                filas: filas.length,
                descargas: elementosDescarga.length
            };
        })();
        ";

                string resultadoVerif = await webView21.ExecuteScriptAsync(verificarScript);
                lblEstado.Text = $"Página actualizada para {fecha.ToString("dd/MM/yyyy")}. Descargando...";

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
            try
            {
                // Primero asegurar que el radio button de fechas esté seleccionado
                string scriptRadio = @"
        (function() {
            try {
                const radioFechas = document.getElementById('ctl00_MainContent_RdoFechas');
                if (radioFechas && !radioFechas.checked) {
                    radioFechas.checked = true;
                    radioFechas.click();
                    radioFechas.dispatchEvent(new Event('change', { bubbles: true }));
                    return 'Radio button seleccionado';
                }
                return 'Radio button ya estaba seleccionado o no encontrado';
            } catch (e) {
                return 'Error: ' + e.message;
            }
        })();
        ";

                await webView21.ExecuteScriptAsync(scriptRadio);
                await Task.Delay(1000, cancellationToken); // Esperar a que se active el formulario

                // Configurar los selectores de fecha
                string anio = fecha.Year.ToString();
                string mes = fecha.Month.ToString();
                string dia = fecha.Day.ToString("00"); // Formato con ceros a la izquierda

                string scriptFecha = $@"
        (function() {{
            try {{
                var resultado = 'Configurando fecha: {fecha.ToString("dd/MM/yyyy")}\n';
                
                // PASO 1: Configurar año
                var selectAnio = document.getElementById('DdlAnio') || 
                               document.querySelector('select[name*=""DdlAnio""]') ||
                               document.querySelector('select[id*=""DdlAnio""]');
                
                if (selectAnio) {{
                    selectAnio.value = '{anio}';
                    selectAnio.dispatchEvent(new Event('change', {{ bubbles: true }}));
                    resultado += 'Año configurado: {anio}\n';
                }} else {{
                    resultado += 'ERROR: No se encontró selector de año\n';
                }}
                
                // PASO 2: Configurar mes (esperar un poco por si hay validaciones)
                setTimeout(function() {{
                    var selectMes = document.getElementById('ctl00_MainContent_CldFecha_DdlMes') || 
                                   document.querySelector('select[name*=""DdlMes""]') ||
                                   document.querySelector('select[id*=""DdlMes""]');
                    
                    if (selectMes) {{
                        selectMes.value = '{mes}';
                        selectMes.dispatchEvent(new Event('change', {{ bubbles: true }}));
                        resultado += 'Mes configurado: {mes}\n';
                        
                        // PASO 3: Configurar día (esperar a que se actualice el selector de días)
                        setTimeout(function() {{
                            var selectDia = document.getElementById('ctl00_MainContent_CldFecha_DdlDia') || 
                                           document.querySelector('select[name*=""DdlDia""]') ||
                                           document.querySelector('select[id*=""DdlDia""]');
                            
                            if (selectDia) {{
                                selectDia.value = '{dia}';
                                selectDia.dispatchEvent(new Event('change', {{ bubbles: true }}));
                                resultado += 'Día configurado: {dia}\n';
                            }} else {{
                                resultado += 'ERROR: No se encontró selector de día\n';
                            }}
                        }}, 500);
                        
                    }} else {{
                        resultado += 'ERROR: No se encontró selector de mes\n';
                    }}
                }}, 500);
                
                return resultado;
            }} catch (e) {{
                return 'Error: ' + e.message;
            }}
        }})();
        ";

                await webView21.ExecuteScriptAsync(scriptFecha);

                // Esperar más tiempo para que se procesen todos los cambios
                await Task.Delay(3000, cancellationToken);

                // Verificar que la fecha se configuró correctamente
                string scriptVerificacion = @"
        (function() {
            try {
                var anio = document.getElementById('DdlAnio')?.value || 'No encontrado';
                var mes = document.getElementById('ctl00_MainContent_CldFecha_DdlMes')?.value || 'No encontrado';
                var dia = document.getElementById('ctl00_MainContent_CldFecha_DdlDia')?.value || 'No encontrado';
                
                return 'Verificación - Año: ' + anio + ', Mes: ' + mes + ', Día: ' + dia;
            } catch (e) {
                return 'Error en verificación: ' + e.message;
            }
        })();
        ";

                string verificacion = await webView21.ExecuteScriptAsync(scriptVerificacion);
                System.Diagnostics.Debug.WriteLine($"Verificación de fecha: {verificacion}");

            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error configurando fecha: {ex.Message}");
            }
        }

        // Función temporal para diagnosticar la página - puedes llamarla antes de configurar la fecha
        private async Task DiagnosticarPagina()
        {
            string scriptDiagnostico = @"
    (function() {
        var informe = 'DIAGNÓSTICO DE LA PÁGINA DEL SAT:\n\n';
        
        // Verificar radio button
        var radioFechas = document.getElementById('ctl00_MainContent_RdoFechas');
        informe += '1. Radio button de fechas: ' + (radioFechas ? 'ENCONTRADO' : 'NO ENCONTRADO') + '\n';
        if (radioFechas) {
            informe += '   - Está marcado: ' + radioFechas.checked + '\n';
        }
        
        // Verificar selectores de fecha
        var selectAnio = document.getElementById('DdlAnio');
        var selectMes = document.getElementById('ctl00_MainContent_CldFecha_DdlMes');
        var selectDia = document.getElementById('ctl00_MainContent_CldFecha_DdlDia');
        
        informe += '\n2. Selectores de fecha:\n';
        informe += '   - Año: ' + (selectAnio ? 'ENCONTRADO (' + selectAnio.value + ')' : 'NO ENCONTRADO') + '\n';
        informe += '   - Mes: ' + (selectMes ? 'ENCONTRADO (' + selectMes.value + ')' : 'NO ENCONTRADO') + '\n';
        informe += '   - Día: ' + (selectDia ? 'ENCONTRADO (' + selectDia.value + ')' : 'NO ENCONTRADO') + '\n';
        
        // Verificar botón de búsqueda
        var btnBuscar = document.getElementById('ctl00_MainContent_BtnBusqueda');
        informe += '\n3. Botón de búsqueda: ' + (btnBuscar ? 'ENCONTRADO' : 'NO ENCONTRADO') + '\n';
        
        // Listar todos los selectores que contengan fecha en su name o id
        var todosSelects = document.querySelectorAll('select');
        informe += '\n4. Todos los selectores encontrados:\n';
        todosSelects.forEach(function(select, index) {
            var name = select.name || 'Sin name';
            var id = select.id || 'Sin id';
            informe += '   ' + (index + 1) + '. Name: ' + name + ', ID: ' + id + '\n';
        });
        
        return informe;
    })();
    ";

            string resultado = await webView21.ExecuteScriptAsync(scriptDiagnostico);
            MessageBox.Show(resultado, "Diagnóstico de la Página", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // await DiagnosticarPagina();

        private async Task EjecutarBusqueda(CancellationToken cancellationToken)
        {
            string script = @"
    (function() {
        try {
            var resultado = 'Ejecutando búsqueda...\n';
            var botonEncontrado = false;
            
            // PASO 1: Buscar botón de búsqueda por ID específico del SAT
            var btnBuscar = document.getElementById('ctl00_MainContent_BtnBusqueda');
            if (btnBuscar) {
                btnBuscar.click();
                resultado += 'Búsqueda iniciada con botón principal\n';
                botonEncontrado = true;
            }
            
            // PASO 2: Si no se encontró, buscar por otros IDs comunes
            if (!botonEncontrado) {
                var otrosIds = ['ctl00_MainContent_BtnConsultar', 'BtnBusqueda', 'BtnConsultar'];
                otrosIds.forEach(function(id) {
                    if (!botonEncontrado) {
                        var btn = document.getElementById(id);
                        if (btn) {
                            btn.click();
                            resultado += 'Búsqueda iniciada con ID: ' + id + '\n';
                            botonEncontrado = true;
                        }
                    }
                });
            }
            
            // PASO 3: Buscar por valor del botón
            if (!botonEncontrado) {
                var todosInputs = document.querySelectorAll('input[type=""submit""], input[type=""button""], button');
                todosInputs.forEach(function(btn) {
                    if (!botonEncontrado) {
                        var valor = (btn.value || '').toLowerCase();
                        var texto = (btn.innerText || btn.textContent || '').toLowerCase();
                        
                        if (valor.includes('buscar') || valor.includes('consultar') || 
                            texto.includes('buscar') || texto.includes('consultar')) {
                            btn.click();
                            resultado += 'Búsqueda iniciada por texto/valor\n';
                            botonEncontrado = true;
                        }
                    }
                });
            }
            
            if (!botonEncontrado) {
                resultado += 'ADVERTENCIA: No se encontró botón de búsqueda\n';
                
                // Como último recurso, intentar enviar el formulario
                var forms = document.getElementsByTagName('form');
                if (forms.length > 0) {
                    forms[0].submit();
                    resultado += 'Formulario enviado directamente\n';
                }
            }
            
            return resultado;
        } catch (e) {
            return 'Error: ' + e.message;
        }
    })();
    ";

            string resultado = await webView21.ExecuteScriptAsync(script);
            System.Diagnostics.Debug.WriteLine($"Resultado búsqueda: {resultado}");

            // Esperar un poco después de hacer clic
            await Task.Delay(1000, cancellationToken);
        }

        // Agregar esta función temporal para diagnóstico
        private async Task DiagnosticarElementos()
        {
            string scriptDiagnostico = @"
    (function() {
        var informe = 'DIAGNÓSTICO DE ELEMENTOS:\n\n';
        
        // Buscar todos los elementos que podrían ser de descarga
        var todosElementos = document.querySelectorAll('*[onclick], a[href], button, input');
        informe += 'Total elementos con onclick/href: ' + todosElementos.length + '\n\n';
        
        var candidatos = [];
        
        todosElementos.forEach(function(elem, index) {
            var onclick = elem.getAttribute('onclick') || '';
            var href = elem.getAttribute('href') || '';
            var texto = (elem.innerText || elem.textContent || '').trim();
            var clase = elem.className || '';
            var id = elem.id || '';
            
            // Buscar cualquier referencia a descarga o XML
            if (onclick.includes('AccionCfdi') || 
                onclick.toLowerCase().includes('xml') ||
                onclick.toLowerCase().includes('descarga') ||
                href.toLowerCase().includes('xml') ||
                texto.toLowerCase().includes('xml') ||
                texto.toLowerCase().includes('descarga') ||
                clase.toLowerCase().includes('download') ||
                clase.toLowerCase().includes('descarga')) {
                
                candidatos.push({
                    index: index,
                    tagName: elem.tagName,
                    id: id,
                    className: clase,
                    onclick: onclick.substring(0, 100), // Primeros 100 chars
                    href: href,
                    texto: texto.substring(0, 50) // Primeros 50 chars
                });
            }
        });
        
        informe += 'CANDIDATOS ENCONTRADOS: ' + candidatos.length + '\n\n';
        
        candidatos.forEach(function(cand, i) {
            informe += '--- Candidato ' + (i+1) + ' ---\n';
            informe += 'Tag: ' + cand.tagName + '\n';
            informe += 'ID: ' + cand.id + '\n';
            informe += 'Clase: ' + cand.className + '\n';
            informe += 'OnClick: ' + cand.onclick + '\n';
            informe += 'Href: ' + cand.href + '\n';
            informe += 'Texto: ' + cand.texto + '\n\n';
        });
        
        return informe;
    })();
    ";

            string resultado = await webView21.ExecuteScriptAsync(scriptDiagnostico);
            MessageBox.Show(resultado, "Diagnóstico de Elementos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task<int> DescargarXMLsDeResultados(string rutaDescarga, DateTime fecha, CancellationToken cancellationToken)
        {
            int xmlsDescargados = 0;
            HashSet<string> urlsDescargadas = new HashSet<string>();

            try
            {
                string fechaCarpeta = fecha.ToString("yyyy-MM-dd");
                string rutaFecha = Path.Combine(rutaDescarga, fechaCarpeta);

                if (!Directory.Exists(rutaFecha))
                {
                    Directory.CreateDirectory(rutaFecha);
                }

                EventHandler<CoreWebView2DownloadStartingEventArgs> downloadHandler = null;
                downloadHandler = (sender, e) =>
                {
                    try
                    {
                        string urlDescarga = e.DownloadOperation.Uri;

                        // Solo filtrar PDFs explícitos, permitir todo lo demás inicialmente
                        if (urlDescarga.ToLower().Contains(".pdf"))
                        {
                            e.Cancel = true;
                            return;
                        }

                        // Evitar duplicados
                        if (urlsDescargadas.Contains(urlDescarga))
                        {
                            e.Cancel = true;
                            return;
                        }

                        urlsDescargadas.Add(urlDescarga);

                        string nombreArchivo = $"Descarga_{DateTime.Now:HHmmss}_{xmlsDescargados + 1}";
                        string extension = Path.GetExtension(e.DownloadOperation.ResultFilePath);
                        if (string.IsNullOrEmpty(extension))
                        {
                            extension = ".xml"; // Asumir XML si no hay extensión
                        }

                        string rutaCompleta = Path.Combine(rutaFecha, nombreArchivo + extension);

                        e.ResultFilePath = rutaCompleta;
                        e.Cancel = false;

                        xmlsDescargados++;

                        if (lblEstado.InvokeRequired)
                        {
                            lblEstado.Invoke(new Action(() => {
                                lblEstado.Text = $"Descargando archivo {xmlsDescargados}: {nombreArchivo + extension}";
                            }));
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error en descarga: {ex.Message}");
                    }
                };

                webView21.CoreWebView2.DownloadStarting += downloadHandler;

                try
                {
                    // Script más permisivo para encontrar elementos
                    string script = @"
            (function() {
                try {
                    var encontrados = 0;
                    const baseUrl = 'https://portalcfdi.facturaelectronica.sat.gob.mx/';
                    
                    // Buscar TODOS los elementos con onclick que contengan AccionCfdi
                    var elementosAccionCfdi = document.querySelectorAll('[onclick*=""AccionCfdi""]');
                    
                    elementosAccionCfdi.forEach(function(elemento, index) {
                        setTimeout(function() {
                            try {
                                var onclick = elemento.getAttribute('onclick');
                                var match = onclick.match(/AccionCfdi\('([^']+)'/);
                                if (match && match[1]) {
                                    var urlCompleta = baseUrl + match[1];
                                    window.open(urlCompleta, '_blank');
                                    encontrados++;
                                }
                            } catch (e) {
                                console.log('Error:', e);
                            }
                        }, index * 2000);
                    });
                    
                    // También buscar elementos con clases de descarga comunes
                    var iconosDescarga = document.querySelectorAll('.glyphicon-cloud-download, .glyphicon-download');
                    iconosDescarga.forEach(function(icono, index) {
                        setTimeout(function() {
                            try {
                                icono.click();
                                encontrados++;
                            } catch (e) {
                                console.log('Error en icono:', e);
                            }
                        }, (elementosAccionCfdi.length + index) * 2000);
                    });
                    
                    return elementosAccionCfdi.length + iconosDescarga.length;
                } catch (e) {
                    return 0;
                }
            })();
            ";

                    string resultado = await webView21.ExecuteScriptAsync(script);

                    if (int.TryParse(resultado, out int elementosEncontrados))
                    {
                        if (elementosEncontrados > 0)
                        {
                            int tiempoEspera = (elementosEncontrados * 3000) + 5000;
                            await Task.Delay(tiempoEspera, cancellationToken);
                        }
                        else
                        {
                            await Task.Delay(3000, cancellationToken);
                        }
                    }
                }
                finally
                {
                    webView21.CoreWebView2.DownloadStarting -= downloadHandler;
                    // IMPORTANTE: Limpiar URLs para la siguiente fecha
                    urlsDescargadas.Clear();
                }

                return xmlsDescargados;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error descargando XMLs: {ex.Message}");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await DiagnosticarPagina();
        }
    }
}