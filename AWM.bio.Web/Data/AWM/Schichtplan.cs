using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace AWM.bio.Web.Data.AWM
{
    public class Schichtplan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime SchichtDatum { get; set; }

        public virtual List<Gebiet> Gebiete { get; set; }
        public virtual List<Arbeitsauftrag> Arbeitsauftraege { get; set; }
        public virtual List<Bewertung> Bewertungen { get; set; }
    }
}