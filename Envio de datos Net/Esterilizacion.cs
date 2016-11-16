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


        public void guardarRegistros(DataGridView data, int presion, int temperatura, DateTime horainicio, DateTime horafin,
            int tiempoC, int tiempoE)
        {

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
            if (this.registroLote != null)
            {
                string clausula = "SELECT idEsterilizacion FROM insumosbolivia.esterilizacion order by idEsterilizacion DESC LIMIT 1";
                this.id = ServidorDB.obtenerId(clausula, "idEsterilizacion");
            }
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
