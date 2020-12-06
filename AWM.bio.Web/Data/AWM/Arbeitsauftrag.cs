using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AWM.bio.Web.Data.AWM
{
    public class Arbeitsauftrag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public virtual Kontrolleur Kontrolleur { get; set; }

        public virtual Schichtplan Schichtplan { get; set; }

    }
}
