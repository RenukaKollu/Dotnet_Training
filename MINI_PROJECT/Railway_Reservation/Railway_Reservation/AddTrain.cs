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
        
        static void AddTrain()
        {
            Console.Write("Enter Train No: ");
            int trainNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Train Name: ");
            string trainName = Console.ReadLine();
            Console.Write("Enter From Station: ");
            string fromStation = Console.ReadLine();
            Console.Write("Enter To Station: ");
            string toStation = Console.ReadLine();
            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Class of Travel: ");
            string classOfTravel = Console.ReadLine();
            Console.Write("Enter Train Status: ");
            string trainStatus = Console.ReadLine();
            Console.Write("Enter Seats Available: ");
            int seatsAvailable = int.Parse(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand add = new SqlCommand("INSERT INTO Trains (TrainNo, TrainName, FromStation, ToStation, Price, ClassofTravel, TrainStatus, SeatsAvailable) VALUES (@TrainNo, @TrainName, @FromStation, @ToStation, @Price, @ClassofTravel, @TrainStatus, @SeatsAvailable)", con);
                add.Parameters.AddWithValue("@TrainNo", trainNo);
                add.Parameters.AddWithValue("@TrainName", trainName);
                add.Parameters.AddWithValue("@FromStation", fromStation);
                add.Parameters.AddWithValue("@ToStation", toStation);
                add.Parameters.AddWithValue("@Price", price);
                add.Parameters.AddWithValue("@ClassofTravel", classOfTravel);
                add.Parameters.AddWithValue("@TrainStatus", trainStatus);
                add.Parameters.AddWithValue("@SeatsAvailable", seatsAvailable);
                add.ExecuteNonQuery();

                Console.WriteLine("Train is added successfully in IRCTC!");
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}
