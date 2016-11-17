using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveToMySQL
{
    class Esterilizacion : IEquatable<Esterilizacion>
    {
        public int id { get; set; }
        public string noEsterilizacion { get; set; }
        public string tipoPresentacion { get; set; }
        public int presion { get; set; }
        public int temperatura { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaFinal { get; set; }
        public int tiempoCalentamiento { get; set; }
        public int tiempoEsterilizado { get; set; }
        public string observacion { get; set; }

        public RegistroLote registroLote { get; set; }


        public bool guardarRegistros(DataGridView grd, Esterilizacion es)
        {
            bool guardo = false;
            char[] limitadores = {':',' '};
            for (int i = 0; i < grd.Rows.Count - 1; )
            {
                RegistroEsterilizacion registro = new RegistroEsterilizacion();
                //item hora presion temperatura estado
                string [] cadenas = grd.Rows[i].Cells[1].Value.ToString().Split(limitadores);
                registro.fechaHora = new DateTime(1,1,1, int.Parse(cadenas[0]), int.Parse(cadenas[0]), int.Parse(cadenas[0]));
                registro.presion = int.Parse(grd.Rows[i].Cells[2].Value.ToString());
                registro.temperatura = int.Parse(grd.Rows[i].Cells[3].Value.ToString());
                registro.etapa = grd.Rows[i].Cells[4].Value.ToString();
                registro.esterilizacionid = es.id;
                registro.guardar();
                i++;
                guardo = true;
            }
            return guardo;
        }

        public bool guardar()
        {
            string CommandText = string.Format("Insert into Esterilizacion(noEsterilizacion, " +
                                               "tipoPresentacion, presion, temperatura, horaInicio, horaFinal, " +
                                               "tiempoCalentamiento, tiempoEsterilizado, Observacion) " +
                                               "values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}');",
                                               (this.noEsterilizacion == null ? "0" : this.noEsterilizacion), (this.tipoPresentacion == null ? "0" : this.tipoPresentacion), 
                                               this.presion, this.temperatura,
                                               this.horaInicio.ToLongTimeString(), this.horaFinal.ToLongTimeString(), this.tiempoCalentamiento, this.tiempoEsterilizado,
                                               (this.observacion == null ? "N/A" : this.observacion));
            Console.WriteLine(CommandText);
            return ServidorDB.insertar(CommandText);
        }

        public void obtenerId()
        {
                string clausula = "SELECT idEsterilizacion FROM insumosbolivia.esterilizacion order by idEsterilizacion DESC LIMIT 1";
                this.id = ServidorDB.obtenerId(clausula, "idEsterilizacion");
        }

        public static System.Data.DataTable listaLotes()
        {
            return ServidorDB.listar("SELECT * FROM insumosbolivia.Esterilizacion order by fecha ASC");
        }

        public static List<Esterilizacion> listaEsterilizacion()
        {
            List<Esterilizacion> lotes = new List<Esterilizacion>();
            System.Data.DataTable dt = listaLotes();
            lotes = Utils.ConvertDataTable<Esterilizacion>(dt);
            return lotes;
        }

        public override string ToString()
        {
            return this.id.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Esterilizacion p = obj as Esterilizacion;
            if (p == null) return false;
            else return Equals(p);
        }

        public override int GetHashCode()
        {
            return id;
        }

        public bool Equals(Esterilizacion e)
        {
            if (e == null) return false;
            return (this.id.Equals(e.id));
        }
    }
}
