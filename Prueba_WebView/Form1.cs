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

namespace Prueba_WebView
{
    // Si eres iván deberías ver esto (ACTUALIZADO)
    public partial class Form1 : Form
    {
        private Image original;
        private Image hover;
        private Image press;

        public Form1()
        {
            InitializeComponent();

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

        private void Form1_Load(object sender, EventArgs e)
        {

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

        private void bBuscar_Click(object sender, EventArgs e)
        {
            if (webView21 != null && webView21.CoreWebView2 != null)
            {
                webView21.CoreWebView2.Navigate(tBuscar.Text);
            }
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }
    }
}
