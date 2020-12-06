using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWM.bio.Web.Data.AWM
{
    public class Kunde
    {
        public Guid Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string KontaktAdresse { get; set; }


        public virtual List<Partie> Partien { get; set; }
    }
}
