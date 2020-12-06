using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AWM.bio.Web.Data;

namespace AWM.bio.Web.Data.AWM
{
    public class Tonne
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int Volumen { get; set; }

        public virtual List<Bewertung> Bewertungen { get; set; }
        public virtual Partie Partie { get; set; }

    }
}