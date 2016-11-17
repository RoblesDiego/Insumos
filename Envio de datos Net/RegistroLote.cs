﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveToMySQL
{
    class RegistroLote : IEquatable<RegistroLote>
    {
        public int id { get; set; }
        public string codigoRegistroLote { get; set; }
        public int versionControl { get; set; }
        public string lote { get; set; }
        public DateTime fecha { get; set; }

        public bool guardar()
        {
            string CommandText = string.Format("Insert into registrolote(codigoRegistroLote," +
                                               "versionControl, lote) " +
                                               "values ('{0}','{1}','{2}');", this.codigoRegistroLote,
                                               this.versionControl, this.lote);
            Console.WriteLine(CommandText);
            return ServidorDB.insertar(CommandText);
        }

        public void obtenerId()
        {
            if (this.codigoRegistroLote != null)
            {
                string clausula = "select idRegistroLote from insumosbolivia.registrolote where codigoRegistroLote='" + this.codigoRegistroLote + "'";
                this.id = ServidorDB.obtenerId(clausula, "idRegistroLote");
            }
        }

        public static System.Data.DataTable listaLotes()
        {
            return ServidorDB.listar("SELECT * FROM insumosbolivia.registrolote order by fecha ASC");
        }

        public static List<RegistroLote> listaRegistroLote()
        {
            List<RegistroLote> lotes = new List<RegistroLote>();
            DataTable dt = listaLotes();
            lotes = Utils.ConvertDataTable<RegistroLote>(dt);
            return lotes;
        }

        public override string ToString()
        {
            return this.id.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            RegistroLote p = obj as RegistroLote;
            if (p == null) return false;
            else return Equals(p);
        }

        public override int GetHashCode()
        {
            return id;
        }

        public bool Equals(RegistroLote lote)
        {
            if (lote == null) return false;
            return (this.id.Equals(lote.id));
        }

    }
}