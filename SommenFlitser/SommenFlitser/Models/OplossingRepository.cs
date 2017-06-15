using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SommenFlitser.Models
{
    public class OplossingRepository
    {
        private List<Oplossing> oplossingen;
        private int oplossingId = 0;
       

        private static OplossingRepository instance;

        public static OplossingRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new OplossingRepository();
            }

            return instance;
        }

        private OplossingRepository()
        {
            oplossingen = new List<Oplossing>();

        }

        public List<Oplossing> GetOplossingen()
        {
            return oplossingen;
        }

        public List<Oplossing> SendOplossing(int answer, int Id, int oefeningId)
        {
            Kind k = new Kind();

            if (answer == 3546)
            {
                oplossingen = new List<Oplossing>();
            }
            else
            {
                oplossingId++;

                //database start
                try
                {
                    using (SqlConnection connection = new SqlConnection(
                        @"Server=.\SQLExpress; Database=SommenFlitser; Integrated Security = SSPI"))
                    using (SqlCommand commandKind = new SqlCommand(
                        "SELECT Id, Naam, Actief, Color FROM dbo.Kind" + " WHERE Id = @Id", connection))
                    {
                        commandKind.Parameters.AddWithValue("Id", Id);
                        connection.Open();
                        using (SqlDataReader reader = commandKind.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                k = new Kind();
                                k.Id = Convert.ToInt32(reader[0]);
                                k.Naam = Convert.ToString(reader[1]);
                                k.Actief = Convert.ToBoolean(reader[2]);
                                k.Color = Convert.ToString(reader[3]);

                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }

                oplossingen.Add(new Oplossing { Id = oplossingId, Antwoord = answer, KindId = Id, OefeningId = oefeningId, Kleur = k.Color });

                try
                {
                    using (SqlConnection connection = new SqlConnection(
                        @"Server=.\SQLExpress; Database=SommenFlitser; Integrated Security = SSPI"))

                    using (SqlCommand commandOplossing = new SqlCommand(
                        "INSERT INTO dbo.Oplossing (KindId, OefeningId, Antwoord, Kleur)"
                        + "VALUES (@KindId, @OefeningId, @Antwoord, @Kleur)", connection))
                    {
                        commandOplossing.Parameters.Add("KindId", SqlDbType.Int).Value = Id;
                        commandOplossing.Parameters.Add("OefeningId", SqlDbType.Int).Value = oefeningId;
                        commandOplossing.Parameters.Add("Antwoord", SqlDbType.Int).Value = answer;
                        commandOplossing.Parameters.Add("Kleur", SqlDbType.VarChar, 50).Value = k.Color;

                        connection.Open();
                        commandOplossing.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            
            
            return oplossingen;
        }
            
        
    }
}