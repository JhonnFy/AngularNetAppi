using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaIgu
{
    public partial class AppRun : Form
    {
        public AppRun()
        {
            InitializeComponent();
        }

        private void AppRun_Load(object sender, EventArgs e)
        {

            Debug.WriteLine("[****].[OK].[CapaIgu].[AppRun_Load].[Iniciando aplicación]");
            var conexion = new Conexion();
            var resultado = conexion.ProbarConexion();
            Debug.WriteLine("[****].[OK].[CapaIgu].[AppRun_Load].[Conexión a la base de datos ejecutada]");

            MessageBox.Show(
                resultado.mensaje,
                resultado.estado ? "[⚙️ AppRun]" : "Error de conexión",
                MessageBoxButtons.OK,
                resultado.estado ? MessageBoxIcon.Information : MessageBoxIcon.Error
            );
            Debug.WriteLine($"[****].[OK]..[CapaIgu].[AppRun_Load].[UI Inicializada — DataGrid y Botones en construcción]");

            this.BeginInvoke((Action)(() => this.ActiveControl = null));

        }
    }
}
