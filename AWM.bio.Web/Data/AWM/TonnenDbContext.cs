using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AWM.bio.Web.Data.AWM
{
    public class TonnenDbContext : DbContext
    {
        public TonnenDbContext(DbContextOptions<TonnenDbContext> options)
            : base(options)
        {
        }

        public DbSet<Arbeitsauftrag> Arbeitsauftraege { get; set; }

        public DbSet<Bewertung> Bewertungen { get; set; }

        public DbSet<Gebiet> Gebiete { get; set; }

        public DbSet<Kontrolleur> Kontrolleure { get; set; }

        public DbSet<Partie> Partien { get; set; }

        public DbSet<Schichtplan> Schichtplaene { get; set; }

        public DbSet<Tonne> Tonnen { get; set; }

        public DbSet<Kunde> Kunden { get; set; }

    }
}
