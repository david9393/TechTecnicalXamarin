using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.TechnicalTest.Models
{
    public class TipModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        [Ignore]
        public string FechaFormat
        {
            get => Fecha.ToString("MM-dd-yyyy");
        }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
    }
}
