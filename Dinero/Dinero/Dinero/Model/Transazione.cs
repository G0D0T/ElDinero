using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dinero.Model
{
    public class Transazione
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Importo { get; set; }
        public string Descrizione { get; set; }
        public string Quando { get; set; }
    }
}
