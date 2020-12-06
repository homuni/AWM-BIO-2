using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWM.bio.Web.Data.AWM
{
    public class Kontrolleur
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Verweis auf das Benutzerkonto des Amwemders
        /// IdentityUser im Identity-System
        /// </summary>
        public string UserId { get; set; }

        public virtual List<Arbeitsauftrag> Arbeitsauftraege { get; set; }
    }
}
