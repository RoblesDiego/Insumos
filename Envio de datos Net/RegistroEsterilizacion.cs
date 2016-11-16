using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToMySQL
{
    class RegistroEsterilizacion : IEquatable<RegistroEsterilizacion>
    {
        public int id { get; set; }
        public DateTime fechaHora { get; set; }
        public int presion { get; set; }
        public int temperatura { get; set; }
        public string etapa { get; set; }
        public Esterilizacion esterilizacion { get; set; }

        public bool guardar()
        {
            string CommandText = string.Format("Insert into RegistroEsterilizacion(fechahora, " +
                                               "temperatura, presion, etapa," +
                                               "Esterilizacion_idEsterilizacion) " +
                                               "values ('{0}','{1}','{2}','{3}','{4}');", 
                                               this.fechaHora, this.temperatura, this.presion, this.etapa,
                                               this.esterilizacion.id);
            Console.WriteLine(CommandText);
            return ServidorDB.insertar(CommandText);
        }

        public void obtenerId()
        {
            if (this.esterilizacion != null)
            {
                string clausula = "SELECT idRegistroEsterilizacion FROM insumosbolivia.RegistroEsterilizacion order by idRegistroEsterilizacion DESC LIMIT 1";
                this.id = ServidorDB.obtenerId(clausula, "idRegistroEsterilizacion");
            }
        }

        public static System.Data.DataTable listaLotes()
        {
            return ServidorDB.listar("SELECT * FROM insumosbolivia.RegistroEsterilizacion order by fecha ASC");
        }

        public static List<RegistroEsterilizacion> listaRegistroEsterilizacion()
        {
            List<RegistroEsterilizacion> lotes = new List<RegistroEsterilizacion>();
            System.Data.DataTable dt = listaLotes();
            lotes = Utils.ConvertDataTable<RegistroEsterilizacion>(dt);
            return lotes;
        }

        public override string ToString()
        {
            return this.id.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            RegistroEsterilizacion p = obj as RegistroEsterilizacion;
            if (p == null) return false;
            else return Equals(p);
        }

        public override int GetHashCode()
        {
            return id;
        }

        public bool Equals(RegistroEsterilizacion e)
        {
            if (e == null) return false;
            return (this.id.Equals(e.id));
        }
    }
}
