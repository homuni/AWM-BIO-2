using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWM.bio.Web.Data.AWM
{
    public class Bewertung
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Notiz { get; set; }
        public TimeSpan Datum { get; set; }
        
        public byte[] Foto { get; set; }

        public string FileType { get; set; }

        public string Defekt { get; set; }


        public virtual Tonne Tonne { get; set; }
        public virtual Schichtplan Schichtplan { get; set; }
    }
}