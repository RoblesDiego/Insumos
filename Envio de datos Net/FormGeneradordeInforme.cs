using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaveToMySQL;

namespace Envio_de_datos_Net
{
    public partial class FormGeneradordeInforme : Form
    {
        public FormGeneradordeInforme()
        {
            InitializeComponent();
        }

        private void bCargar_Click(object sender, EventArgs e)
        {
            
        }

        private void bGuardar_Click(object sender, EventArgs e)
        {
            RegistroLote lote = new RegistroLote();
            lote.codigoRegistroLote = this.txbCodigo.Text;
            lote.versionControl = int.Parse(this.txbVersion.Text);
            lote.fecha = this.dateTimePicker1.Value;
            lote.lote = this.txbLote.Text;
            lote.guardar();
            lote.obtenerId();
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    Esterilizacion.actualizarEsterilizacion(int.Parse(dataGridView1.SelectedRows[i].Cells[0].Value.ToString()), lote.id);
                }
            }
            this.dataGridView1.DataSource = Esterilizacion.listaEsterilizacionesSinLote();
            this.dataGridView1.Refresh();
            this.txbLote.Text = "";
            this.txbCodigo.Text = "";
            this.txbVersion.Text = "";
            this.dateTimePicker1.Refresh();
        }

        private void FormGeneradordeInforme_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = Esterilizacion.listaEsterilizacionesSinLote();
        }
    }
}
