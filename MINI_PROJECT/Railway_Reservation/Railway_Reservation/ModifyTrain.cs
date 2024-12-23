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
        static void ModifyTrain()
        {
            Console.Write("Enter Train No to modify: ");
            int trainNo = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // First, retrieve the current details of the train
                SqlCommand fetchCommand = new SqlCommand("SELECT * FROM Trains WHERE TrainNo = @TrainNo", con);
                fetchCommand.Parameters.AddWithValue("@TrainNo", trainNo);
                SqlDataReader reader = fetchCommand.ExecuteReader();

                if (reader.Read())
                {
                    string currentTrainName = reader["TrainName"].ToString();
                    string currentFromStation = reader["FromStation"].ToString();
                    string currentToStation = reader["ToStation"].ToString();
                    decimal currentPrice = Convert.ToDecimal(reader["Price"]);
                    string currentClassOfTravel = reader["ClassofTravel"].ToString();
                    string currentTrainStatus = reader["TrainStatus"].ToString();
                    int currentSeatsAvailable = Convert.ToInt32(reader["SeatsAvailable"]);

                    // Close the reader to open a new command for updating
                    reader.Close();

                    // Prompt user for new details or keep existing
                    Console.WriteLine($"Current Train Name: {currentTrainName}");
                    Console.Write("Enter new Train Name (leave blank to keep existing): ");
                    string trainName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(trainName)) trainName = currentTrainName;

                    Console.WriteLine($"Current From Station: {currentFromStation}");
                    Console.Write("Enter new From Station (leave blank to keep existing): ");
                    string fromStation = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(fromStation)) fromStation = currentFromStation;

                    Console.WriteLine($"Current To Station: {currentToStation}");
                    Console.Write("Enter new To Station (leave blank to keep existing): ");
                    string toStation = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(toStation)) toStation = currentToStation;

                    Console.WriteLine($"Current Price: {currentPrice}");
                    Console.Write("Enter new Price (leave blank to keep existing): ");
                    string priceInput = Console.ReadLine();
                    decimal price;
                    if (string.IsNullOrWhiteSpace(priceInput))
                    {
                        // If blank or just spaces, use current price
                        price = currentPrice;
                    }
                    else
                    {
                        // Try parsing the price
                        if (!decimal.TryParse(priceInput, out price))
                        {
                            Console.WriteLine("Invalid price format. Using the existing value.");
                            price = currentPrice;
                        }
                    }

                    Console.WriteLine($"Current Class of Travel: {currentClassOfTravel}");
                    Console.Write("Enter new Class of Travel (leave blank to keep existing): ");
                    string classOfTravel = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(classOfTravel)) classOfTravel = currentClassOfTravel;

                    Console.WriteLine($"Current Train Status: {currentTrainStatus}");
                    Console.Write("Enter new Train Status (leave blank to keep existing): ");
                    string trainStatus = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(trainStatus)) trainStatus = currentTrainStatus;

                    Console.WriteLine($"Current Seats Available: {currentSeatsAvailable}");
                    Console.Write("Enter new Seats Available (leave blank to keep existing): ");
                    string seatsInput = Console.ReadLine();

                    int seatsAvailable;
                    if (string.IsNullOrWhiteSpace(seatsInput))
                    {
                        // If blank or just spaces, use current seats available
                        seatsAvailable = currentSeatsAvailable;
                    }
                    else
                    {
                        // Try parsing the seats
                        if (!int.TryParse(seatsInput, out seatsAvailable))
                        {
                            Console.WriteLine("Invalid number of seats. Using the existing value.");
                            seatsAvailable = currentSeatsAvailable;
                        }
                    }
                    // Update the train information in the database
                    SqlCommand updateCommand = new SqlCommand(
                        "UPDATE Trains SET TrainName = @TrainName, FromStation = @FromStation, ToStation = @ToStation, Price = @Price, ClassofTravel = @ClassofTravel, TrainStatus = @TrainStatus, SeatsAvailable = @SeatsAvailable WHERE TrainNo = @TrainNo",
                        con);
                    updateCommand.Parameters.AddWithValue("@TrainNo", trainNo);
                    updateCommand.Parameters.AddWithValue("@TrainName", string.IsNullOrWhiteSpace(trainName) ? currentTrainName : trainName);
                    updateCommand.Parameters.AddWithValue("@FromStation", string.IsNullOrWhiteSpace(fromStation) ? currentFromStation : fromStation);
                    updateCommand.Parameters.AddWithValue("@ToStation", string.IsNullOrWhiteSpace(toStation) ? currentToStation : toStation);
                    updateCommand.Parameters.AddWithValue("@Price", price);
                    updateCommand.Parameters.AddWithValue("@ClassofTravel", string.IsNullOrWhiteSpace(classOfTravel) ? currentClassOfTravel : classOfTravel);
                    updateCommand.Parameters.AddWithValue("@TrainStatus", string.IsNullOrWhiteSpace(trainStatus) ? currentTrainStatus : trainStatus);
                    updateCommand.Parameters.AddWithValue("@SeatsAvailable", seatsAvailable);


                    updateCommand.ExecuteNonQuery();
                    Console.WriteLine("Train details updated successfully!");
                }
                else
                {
                    Console.WriteLine("Train with the specified Train No does not exist.");
                }
            }
        }
    }
}

