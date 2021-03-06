﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SommenFlitser.Models
{
    public class OefeningRepository
    {
        private List<Oefening> oefeningen;
        //private List<Oplossing> oplossingen;
        private List<Kind> kinderen;
        //private int oplossingId = 0;

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
            //oplossingen = new List<Oplossing>();
            kinderen = new List<Kind>();
            CreateKids();
        }

        private void CreateOefeningen()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(
                    @"Server=.\SQLExpress; Database=SommenFlitser; Integrated Security = SSPI"))
                using (SqlCommand command = new SqlCommand(
                    "SELECT Id, Vraag, Actief, Resultaat FROM dbo.Oefening", connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Oefening oef = new Oefening();
                            oef.Id = Convert.ToInt32(reader[0]);
                            oef.Vraag = Convert.ToString(reader[1]);
                            oef.Actief = Convert.ToBoolean(reader[2]);
                            oef.Resultaat = Convert.ToInt32(reader[3]);

                            oefeningen.Add(oef);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            //string[] sommen = new string[] {"", "7+2", "2+3", "8-4", "12-5" };
            //int[] res = new int[] {0, 9, 5, 4, 7 };
            //int i = 0;

            //foreach (string s in sommen)
            //{
            //    oefeningen.Add(new Oefening { Id = i, Vraag = s, Actief = false, Resultaat = res[i] });
            //    i++;
            //}
        }

        private void CreateKids()
        {
            string[] kids = new string[] { "Marie", "Jonas", "Stan", "Emma", "Ward" };
            string[] colors = new string[] { "Red", "Green", "Blue", "Gold", "Brown" };
            int i = 1;

            foreach (string k in kids)
            {
                kinderen.Add(new Kind { Id = i, Naam = k, Actief = false, Color = colors[i-1] });
                i++;
            }

        }

        //private void CreateOplossingen()
        //{
        //    oplossingen.Add(new Oplossing { Id = oplossingId, Antwoord = 0, KindId = 0, OefeningId = 0 });
        //}

        

        //public List<Oplossing> SendOplossing(int answer, int kindId, int oefeningId)
        //{
        //    if (answer == 3546)
        //    {
        //        oplossingen = new List<Oplossing>();
        //    }
        //    else
        //    {
        //        oplossingId++;
        //        Kind kind = kinderen.FirstOrDefault(k => k.Id == kindId);
        //        string kleur = kind.Color;
        //        oplossingen.Add(new Oplossing { Id = oplossingId, Antwoord = answer, KindId = kindId, OefeningId = oefeningId, Kleur = kleur });

        //        //database start
        //        try
        //        {
        //            using (SqlConnection connection = new SqlConnection(
        //                @"Server=.\SQLExpress; Database=SommenFlitser; Integrated Security = SSPI"))
        //            using (SqlCommand command = new SqlCommand(
        //                "INSERT INTO dbo.Oplossing (KindId, OefeningId, Antwoord, Kleur)"
        //                + "VALUES (@KindId, @OefeningId, @Antwoord, @Kleur)", connection))
        //            {
        //                command.Parameters.Add("KindId", SqlDbType.Int).Value = kindId;
        //                command.Parameters.Add("OefeningId", SqlDbType.Int).Value = oefeningId;
        //                command.Parameters.Add("Antwoord", SqlDbType.Int).Value = answer;
        //                command.Parameters.Add("Kleur", SqlDbType.VarChar, 50).Value = kleur;

        //                connection.Open();
        //                command.ExecuteNonQuery();
        //            }
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //    //database stop
        //    return oplossingen;
        //}

        public List<Oefening> GetOefeningen()
        {
            return oefeningen;
        }

        //public List<Oplossing> GetOplossingen()
        //{
        //    return oplossingen;
        //}

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

        public List<Kind> SetKid(int id)
        {
            List<Kind> tmp = new List<Kind>();

            if (id == 0)
            {
                kinderen = new List<Kind>();
                CreateKids();
            }
            else
            {
                SetKidActive(id);
                tmp.Add(kinderen[id - 1]);
            }

            return tmp;
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

        public void SetKidActive(int id)
        {
            Kind kid = kinderen.FirstOrDefault(k => k.Id == id);
            int index = kinderen.IndexOf(kid);
            kid.Actief = true;
            kinderen[index] = kid;
        }

        public List<Oefening> GetActiveOefening()
        {
            Oefening oef = oefeningen.FirstOrDefault(x => x.Actief == true);
            return ReturnOefinList(oef);
        }

        public List<Kind> GetActiveKids()
        {
            List<Kind> kids = kinderen.Where(k => k.Actief == true).ToList();
            return kids;
        }

        public List<Kind> GetKids()
        {
            return kinderen;
        }
    }
}