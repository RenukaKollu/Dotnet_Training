using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;

namespace Railway_Reservation
{
    public partial class Program
        
    {
      
        static void ViewTrains()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Trains", con);
                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    if (!read.HasRows)
                    {
                        Console.WriteLine("No train list is available to show.");
                        return;
                    }

                    Console.WriteLine("TrainNo, TrainName, FromStation, ToStation, Price, ClassofTravel, TrainStatus, SeatsAvailable");
                    while (read.Read())
                    {
                        Console.WriteLine($"{read["TrainNo"]}, {read["TrainName"]}, {read["FromStation"]}, {read["ToStation"]}, {read["Price"]}, {read["ClassofTravel"]}, {read["TrainStatus"]}, {read["SeatsAvailable"]}");
                    }
                }
            }
        }
    }
}

