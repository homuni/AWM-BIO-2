using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWM.bio.Web.Data.AWM
{
    public class Gebiet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        ///<summary>
        ///N-Seite der 1:N Beziehung
        ///</summary>

        public virtual List<Partie> Partien { get; set; }
    }
}
