﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasporedIspitaPoSalama.SRSPS.Models
{
    class DefaultPodaci
    {
        public static void Initialize(RasporedIspitaPoSalamaDbContext context)
        {
            try
            {
                if (!context.Sale.Any())
                {
                    context.Sale.AddRange(
                    new Sala("S1")
                    {
                        salaID = 1,
                        kapacitet = 40

                    }
                    );
                    context.SaveChanges();
                }
                if (!context.Predmeti.Any())
                {
                    context.Predmeti.AddRange(
                    new Predmet()
                    {
                        predmetID = 1,
                        naziv = "IM2",
                        ects = 6,
                        brojUpisanihStudenata = 10000,
                        godina = 1,
                        semestar = 2,

                    }
                    );

                    context.SaveChanges();
                }
                if (!context.Ispiti.Any())
                {
                    context.Ispiti.AddRange(
                    new Ispit()
                    {
                        ispitID = 1,
                        brojPrijavljenih = 10000,

                    }
                    );
                }
            }
            catch(ArgumentNullException e)
            {
                
                string s=e.Source.ToString();
                int x = 1;
            }
            
        }
    }
}
