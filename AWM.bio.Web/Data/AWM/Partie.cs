using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWM.bio.Web.Data.AWM
{
    public class Partie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Adresse { get; set; }

        public string Stellplatznotiz { get; set; }

        /// <summary>
        /// 1-Seite der 1:N
        /// </summary>


        public virtual Gebiet Gebiet { get; set; }
        public virtual List<Tonne> Tonnen { get; set; }
        public virtual Kunde Kunde { get; set; }
    }
}
