﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SommenFlitser.Models
{
    public class OefeningRepository
    {
        private List<Oefening> oefeningen;
        private List<Oplossing> oplossingen;
        private int oplossingId = 0;

        private static OefeningRepository instance;

        public static OefeningRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new OefeningRepository();
            }

            return instance;
        }

        private OefeningRepository()
        {
            oefeningen = new List<Oefening>();
            CreateOefeningen();
            oplossingen = new List<Oplossing>();
            CreateOplossingen();
        }

        private void CreateOefeningen()
        {
            oefeningen.Add(new Oefening { Id = 0, Vraag = "", Actief = true, Resultaat = 0 });
            oefeningen.Add(new Oefening { Id = 1, Vraag = "7 + 5", Actief = false, Resultaat = 12 });
            oefeningen.Add(new Oefening { Id = 2, Vraag = "2 + 3", Actief = false, Resultaat = 5 });
            oefeningen.Add(new Oefening { Id = 3, Vraag = "8 - 4", Actief = false, Resultaat = 4 });
            oefeningen.Add(new Oefening { Id = 4, Vraag = "12 - 5", Actief = false, Resultaat = 7 });
        }

        private void CreateOplossingen()
        {
            oplossingen.Add(new Oplossing { Id = oplossingId, Antwoord = 0, KindId = 0, OefeningId = 0 });
        }

        public List<Oplossing> SendOplossing(int answer)
        {
            if (answer == 3546)
            {
                oplossingen = new List<Oplossing>();
                CreateOplossingen();
            }
            else
            {
                oplossingId++;
                oplossingen.Add(new Oplossing { Id = oplossingId, Antwoord = answer, KindId = 1, OefeningId = 1 });
            }
            
            return oplossingen;
        }

        public List<Oefening> GetOefeningen()
        {
            return oefeningen;
        }

        public List<Oplossing> GetOplossingen()
        {
            return oplossingen;
        }

        public List<Oefening> GetOefById(int id)
        {
            Oefening oef = oefeningen.FirstOrDefault(x => x.Id == id);
            return ReturnOefinList(oef);
        }

        public List<Oefening> ReturnOefinList(Oefening oef)
        {
            List<Oefening> tmp = new List<Oefening>();
            tmp.Add(oef);
            return tmp;
        }

        public List<Oefening> SetOef(int id)
        {
            foreach (Oefening o in oefeningen)
            {
                o.Actief = false;
            }

            Oefening oef = oefeningen.FirstOrDefault(x => x.Id == id);
            SetOefTrue(oef.Id);
            return ReturnOefinList(oef);
        }

        public void SaveOef(Oefening oef)
        {
            oefeningen.Add(oef);
        }

        public void SetOefTrue(int id)
        {
            Oefening oef = oefeningen.FirstOrDefault(x => x.Id == id);
            int index = oefeningen.IndexOf(oef);
            oef.Actief = true;
            oefeningen[index] = oef;
        }

        public List<Oefening> GetActiveOefening()
        {
            Oefening oef = oefeningen.FirstOrDefault(x => x.Actief == true);
            return ReturnOefinList(oef);
        }


    }
}