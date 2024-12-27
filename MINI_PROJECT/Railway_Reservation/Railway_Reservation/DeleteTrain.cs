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
        static void DeleteTrain()
        {
            
            Console.Write("Enter Train No to delete: ");
            int trainNo = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                
                SqlCommand fetchCommand = new SqlCommand("SELECT * FROM Trains WHERE TrainNo = @TrainNo", con);
                fetchCommand.Parameters.AddWithValue("@TrainNo", trainNo);
                SqlDataReader reader = fetchCommand.ExecuteReader();

                if (reader.Read())
                {
                   
                    string trainName = reader["TrainName"].ToString();
                    string fromStation = reader["FromStation"].ToString();
                    string toStation = reader["ToStation"].ToString();
                    decimal price = Convert.ToDecimal(reader["Price"]);
                    string classOfTravel = reader["ClassofTravel"].ToString();
                    string trainStatus = reader["TrainStatus"].ToString();
                    int seatsAvailable = Convert.ToInt32(reader["SeatsAvailable"]);

                   
                    reader.Close();

                   
                    Console.WriteLine($"Train Details to be deleted:");
                    Console.WriteLine($"Train No: {trainNo}");
                    Console.WriteLine($"Train Name: {trainName}");
                    Console.WriteLine($"From Station: {fromStation}");
                    Console.WriteLine($"To Station: {toStation}");
                    Console.WriteLine($"Price: {price}");
                    Console.WriteLine($"Class of Travel: {classOfTravel}");
                    Console.WriteLine($"Train Status: {trainStatus}");
                    Console.WriteLine($"Seats Available: {seatsAvailable}");

                    Console.Write("Are you sure you want to delete this train? (y/n): ");
                    string confirmation = Console.ReadLine().ToLower();

                   
                    if (confirmation == "y")
                    {
                       
                        SqlCommand deleteCommand = new SqlCommand("DELETE FROM Trains WHERE TrainNo = @TrainNo", con);
                        deleteCommand.Parameters.AddWithValue("@TrainNo", trainNo);

                        int rowsAffected = deleteCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Train deleted successfully!");
                            Console.WriteLine("----------------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("Error: Train could not be deleted.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Train deletion canceled.");
                    }
                }
                else
                {
                    Console.WriteLine("No train found with the specified Train No.");
                }
            }
        }
    }
}
