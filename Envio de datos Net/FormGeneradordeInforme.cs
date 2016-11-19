using System;
using System.Collections.Generic;
using System.Linq;
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
            if (this.txbCodigo.Text != null && this.txbLote.Text != null && this.txbVersion != null)
            {
                MessageBox.Show("Debe ingresar todos los campos (*) requeridos!");
            }
            else
            {
                Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount <= 0)
                {
                    MessageBox.Show("Debe seleccionar minimamente una esterilizacion!");
                }
                else
                {
                    RegistroLote lote = new RegistroLote();
                    lote.codigoRegistroLote = this.txbCodigo.Text;
                    lote.versionControl = int.Parse(this.txbVersion.Text);
                    lote.fecha = this.dateTimePicker1.Value;
                    lote.lote = this.txbLote.Text;
                    lote.guardar();
                    lote.obtenerId();
                    if (selectedRowCount > 0)
                    {
                        for (int i = 0; i < selectedRowCount; i++)
                        {
                            Esterilizacion.actualizarEsterilizacion(int.Parse(dataGridView1.SelectedRows[i].Cells[0].Value.ToString()), lote.idRegistroLote);
                        }
                    }
                    this.dataGridView1.DataSource = Esterilizacion.listaEsterilizacionesSinLote();
                    this.dataGridView1.Refresh();
                    this.txbLote.Text = "";
                    this.txbCodigo.Text = "";
                    this.txbVersion.Text = "";
                    this.dateTimePicker1.Refresh();
                }
            }
        }

        private void FormGeneradordeInforme_Load(object sender, EventArgs e)
        {

            
        }

        private void bRegistrarLote_Click(object sender, EventArgs e)
        {
            this.panelRegistrarLote.Enabled = true;
            this.panelGeneradorInforme.Visible = false;
            this.panelGeneradorInforme.Refresh();
            this.dataGridView1.DataSource = Esterilizacion.listaEsterilizacionesSinLote();
            this.panelRegistrarLote.Visible = true;
            this.panelRegistrarLote.Refresh();
        }

        private void bGenerarInforme_Click(object sender, EventArgs e)
        {
            this.panelRegistrarLote.Visible = false;
            this.panelRegistrarLote.Refresh();
            lotes = RegistroLote.listaRegistroLote();
            if (lotes.Count > 0)
            {
                RegistroLote lote = lotes.First();
                this.posicionLote = 0;
                this.txbFGCodigo.Text = lote.codigoRegistroLote;
                this.txbFGFecha.Text = lote.fecha.ToShortDateString();
                this.txbFGLote.Text = lote.lote;
                this.txbFGVersion.Text = lote.versionControl.ToString();
                this.ListarEsterilizaciones(lote.idRegistroLote);
                this.NavegacionGenerarInforme();
                this.bGenerarInforme.Enabled = true;
            }
            this.panelGeneradorInforme.Visible = true;
            this.panelGeneradorInforme.Refresh();
        }

        private void NavegacionGenerarInforme(){
            if(this.posicionLote < this.lotes.Count){
                this.bSiguiente.Enabled = true;
            }
            else
            {
                this.bSiguiente.Enabled = false;
            }
            if (this.posicionLote > 0)
            {
                this.bAnterior.Enabled = true;
            }
            else
            {
                this.bAnterior.Enabled = false;
            }
        }

        public int posicionLote { get; set; }

        private List<RegistroLote> lotes;
        private List<RegistroLote> lotesByFecha;

        private void ListarEsterilizaciones(int idLote)
        {
            System.Data.DataTable testerilizaciones = Esterilizacion.listaEsterilizacionesLote(idLote);
            if(testerilizaciones.Rows.Count > 0){
                this.dataGridView2.DataSource = testerilizaciones;
            }
            else
            {
                this.dataGridView2.DataSource = null;
            }
            this.dataGridView2.Refresh();
        }

        private void bSiguiente_Click(object sender, EventArgs e)
        {
            this.posicionLote++;
            if (this.posicionLote < lotes.Count)
            {
                RegistroLote lote = lotes.ElementAt(this.posicionLote);
                this.txbFGCodigo.Text = lote.codigoRegistroLote;
                this.txbFGFecha.Text = lote.fecha.ToShortDateString();
                this.txbFGLote.Text = lote.lote;
                this.txbFGVersion.Text = lote.versionControl.ToString();
                this.ListarEsterilizaciones(lote.idRegistroLote);
                this.bGInforme.Enabled = true;
            }
            this.NavegacionGenerarInforme();
        }

        private void bAnterior_Click(object sender, EventArgs e)
        {
            this.posicionLote--;
            if (this.posicionLote < lotes.Count && this.posicionLote >= 0)
            {
                RegistroLote lote = lotes.ElementAt(this.posicionLote);
                this.txbFGCodigo.Text = lote.codigoRegistroLote;
                this.txbFGFecha.Text = lote.fecha.ToShortDateString();
                this.txbFGLote.Text = lote.lote;
                this.txbFGVersion.Text = lote.versionControl.ToString();
                this.ListarEsterilizaciones(lote.idRegistroLote);
                this.bGInforme.Enabled = true;
            }
            this.NavegacionGenerarInforme();
        }

        private void bBuscarLote_Click(object sender, EventArgs e)
        {
            lotesByFecha = (from lote in lotes
                               where lote.fecha >= this.dateTimePickerBuscarLote.Value
                               orderby lote.fecha
                               select lote).ToList();
        }

        private void bGInforme_Click(object sender, EventArgs e)
        {
            this.UpdateExcel();
        }

        private void UpdateExcel()
        {
            Microsoft.Office.Interop.Excel.Application oXL = null;
            Microsoft.Office.Interop.Excel._Workbook oWB = null;
            Microsoft.Office.Interop.Excel._Worksheet oSheet = null;

            try
            {
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oWB = oXL.Workbooks.Open("c:\\InsumosBoliviaTemplate.xlsx");
                oSheet = String.IsNullOrEmpty("Hoja1") ? (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet : (Microsoft.Office.Interop.Excel._Worksheet)oWB.Worksheets["Hoja1"];
                oSheet.Cells[2, 8] = this.txbFGCodigo.Text;
                oSheet.Cells[3, 8] = this.txbFGVersion.Text;
                oSheet.Cells[5, 3] = this.txbFGFecha.Text;
                oSheet.Cells[5, 8] = this.txbFGLote.Text;
                for (int i = 0; i < dataGridView2.Rows.Count-1; i++)
                {
                    oSheet.Cells[8 + i, 1] = i+1;
                    oSheet.Cells[8 + i, 2] = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    oSheet.Cells[8 + i, 3] = dataGridView2.Rows[i].Cells[2].Value.ToString();
                    oSheet.Cells[8 + i, 4] = dataGridView2.Rows[i].Cells[3].Value.ToString();
                    oSheet.Cells[8 + i, 5] = dataGridView2.Rows[i].Cells[4].Value.ToString();
                    oSheet.Cells[8 + i, 6] = dataGridView2.Rows[i].Cells[5].Value.ToString();
                    oSheet.Cells[8 + i, 7] = dataGridView2.Rows[i].Cells[6].Value.ToString();
                    oSheet.Cells[8 + i, 8] = dataGridView2.Rows[i].Cells[7].Value.ToString();
                    oSheet.Cells[8 + i, 9] = dataGridView2.Rows[i].Cells[8].Value.ToString();
                }

                oWB.SaveAs("c:\\InsumosBolivia1.xlsx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (oWB != null)
                    oWB.Close();
            }
        }

    }
}
