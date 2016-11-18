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
            this.checkedListBox1.Items.Clear();
            List<Esterilizacion> lista = Esterilizacion. listaEsterilizacion(true);
            int c=0;
            while(c < lista.Count){
                this.checkedListBox1.Items.Add(lista.ElementAt(c));
                c++;
            }
        }
    }
}
