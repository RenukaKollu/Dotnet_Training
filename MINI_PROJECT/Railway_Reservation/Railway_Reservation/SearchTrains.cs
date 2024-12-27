using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Railway_Reservation
{
    public partial class Program
    {
      
        static void SearchTrains()
        {
            Console.Write("Enter From Station to start travel: ");
            string fromStation = Console.ReadLine();
            Console.Write("Enter To Station to end: ");
            string toStation = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand search = new SqlCommand("Select * from Trains where FromStation = @FromStation AND ToStation = @ToStation AND TrainStatus = 'Active'", con);
                search.Parameters.AddWithValue("@FromStation", fromStation);
                search.Parameters.AddWithValue("@ToStation", toStation);
                using (SqlDataReader read = search.ExecuteReader())
                {
                    if (!read.HasRows)
                    {
                        Console.WriteLine("No trains found.");
                        Console.WriteLine("----------------------------------------");
                        return;
                    }

                    
                    while (read.Read())
                    {
                        Console.WriteLine($"TrainNo: {read["TrainNo"]}, TrainName: {read["TrainName"]}, Price: {read["Price"]}, ClassofTravel: {read["ClassofTravel"]}, SeatsAvailable:{read["SeatsAvailable"]}");
                    }
                }
            }
        }
    }
}
