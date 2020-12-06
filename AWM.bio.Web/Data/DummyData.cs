using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWM.bio.Web.Data.AWM;

namespace AWM.bio.Web.Data
{
    public class DummyData
    {
        public static void Initialize(TonnenDbContext db)
        {
            // Objekte anlegen
            var t1 = new Tonne { Volumen = 80, Bewertungen = new List<Bewertung>() };
            var t2 = new Tonne { Volumen = 120, Bewertungen = new List<Bewertung>() };
            var t3 = new Tonne { Volumen = 120, Bewertungen = new List<Bewertung>() };
            var t4 = new Tonne { Volumen = 80, Bewertungen = new List<Bewertung>() };
            var t5 = new Tonne { Volumen = 120, Bewertungen = new List<Bewertung>() };

            var p1 = new Partie {Adresse = "Lothstr.", Stellplatznotiz = "Tiefgarage", Tonnen = new List<Tonne>()};
            var p2 = new Partie { Adresse = "Pasingstr.", Stellplatznotiz = "Innenhof", Tonnen = new List<Tonne>()};
            var p3 = new Partie { Adresse = "Karlstr.", Stellplatznotiz = "Innenhof", Tonnen = new List<Tonne>() };

            var ko1 = new Kontrolleur {UserId="Michal Kuh", Arbeitsauftraege = new List<Arbeitsauftrag>() };
            var ko2 = new Kontrolleur { UserId = "Anna Krieg", Arbeitsauftraege = new List<Arbeitsauftrag>() };

            var g1 = new Gebiet { Name = "Pasing" , Partien = new List<Partie>()};
            var g2 = new Gebiet { Name = "Schwabing", Partien = new List<Partie>()};
            var g3 = new Gebiet { Name = "Hauptbahnhof", Partien = new List<Partie>() };

            var ku1 = new Kunde { KontaktAdresse = "Apfelstr. 2", Vorname = "Tom", Nachname = "Schiller", Partien = new List<Partie>() };
            var ku2 = new Kunde { KontaktAdresse = "Orangestr. 2", Vorname = "Hans", Nachname = "Beck" , Partien = new List<Partie>()};

            var b1 = new Bewertung { Code = "gruen" };
            var b2 = new Bewertung { Code = "gruen" };
            var b3 = new Bewertung { Code = "rot" };
            var b4 = new Bewertung { Code = "rot" };
            var b5 = new Bewertung { Code = "gelb" };
            var b6 = new Bewertung { Code = "gelb" };
            var b7 = new Bewertung { Code = "gelb" };

            var a1 = new Arbeitsauftrag { };
            var a2 = new Arbeitsauftrag { };

            var s1 = new Schichtplan { Arbeitsauftraege = new List<Arbeitsauftrag>(), Gebiete = new List<Gebiet>(), Bewertungen = new List<Bewertung>() };
            var s2 = new Schichtplan { Arbeitsauftraege = new List<Arbeitsauftrag>(), Gebiete = new List<Gebiet>(), Bewertungen = new List<Bewertung>() };

            // Objekte verbinden
            p1.Tonnen.Add(t1);
            p1.Tonnen.Add(t5);

            p2.Tonnen.Add(t2);
            p2.Tonnen.Add(t3);
            p3.Tonnen.Add(t4);

            g1.Partien.Add(p1);
            g2.Partien.Add(p2);
            g1.Partien.Add(p3);

            ku1.Partien.Add(p1);
            ku1.Partien.Add(p3);
            ku2.Partien.Add(p2);
          

            t1.Bewertungen.Add(b1);
            t1.Bewertungen.Add(b2);
            t2.Bewertungen.Add(b3);
            t3.Bewertungen.Add(b4);
            t3.Bewertungen.Add(b5);
            t4.Bewertungen.Add(b6);
            t5.Bewertungen.Add(b7);

            s1.Bewertungen.Add(b1);
            s1.Bewertungen.Add(b2);
            s2.Bewertungen.Add(b3);
            s2.Bewertungen.Add(b4);
            s1.Bewertungen.Add(b5);
            s1.Bewertungen.Add(b6);
            s2.Bewertungen.Add(b7);

            ko1.Arbeitsauftraege.Add(a1);
            ko2.Arbeitsauftraege.Add(a2);

            s1.Arbeitsauftraege.Add(a1);
            s2.Arbeitsauftraege.Add(a2);

            s1.Gebiete.Add(g1);
            s1.Gebiete.Add(g2);
            s2.Gebiete.Add(g3);

            // Die Objekte der Datenbank hinzufügen
            db.Tonnen.Add(t1);
            db.Tonnen.Add(t2);
            db.Tonnen.Add(t3);
            db.Tonnen.Add(t4);
            db.Tonnen.Add(t5);

            db.Partien.Add(p1);
            db.Partien.Add(p2);
            db.Partien.Add(p3);

            db.Gebiete.Add(g1);
            db.Gebiete.Add(g2);
            db.Gebiete.Add(g3);

            db.Kontrolleure.Add(ko1);
            db.Kontrolleure.Add(ko2);

            db.Kunden.Add(ku1);
            db.Kunden.Add(ku2);

            db.Bewertungen.Add(b1);
            db.Bewertungen.Add(b2);
            db.Bewertungen.Add(b3);
            db.Bewertungen.Add(b4);
            db.Bewertungen.Add(b5);
            db.Bewertungen.Add(b6);
            db.Bewertungen.Add(b7);

            db.Arbeitsauftraege.Add(a1);
            db.Arbeitsauftraege.Add(a2);

            db.Schichtplaene.Add(s1);
            db.Schichtplaene.Add(s2);

            // Änderungen in der Datenbank speichern
            db.SaveChanges();
        }
    }
}
