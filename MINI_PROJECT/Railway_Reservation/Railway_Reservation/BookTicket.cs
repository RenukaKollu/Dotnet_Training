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
       
        static void BookTicket()
        {
            Console.Write("Enter Train No to book the ticket" + ": ");
            int trainNo = int.Parse(Console.ReadLine());
            Console.Write("Enter number of seats to book (Max only 3): ");
            int seatsToBook = int.Parse(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Check available seats 
                SqlCommand checkSeatsCmd = new SqlCommand("SELECT SeatsAvailable from Trains where TrainNo = @TrainNo", con);
                checkSeatsCmd.Parameters.AddWithValue("@TrainNo", trainNo);

                int availableSeats = 0;
                using (SqlDataReader read = checkSeatsCmd.ExecuteReader())
                {
                    if (read.Read())
                    {
                        availableSeats = read.GetInt32(0);
                    }
                    else
                    {
                        Console.WriteLine("Train not found.");
                        return;
                    }
                }

                if (availableSeats < seatsToBook)
                {
                    Console.WriteLine("sorry..!! Not enough seats available to book.");
                    return;
                }

                // Insert booking record
                SqlCommand book = new SqlCommand("INSERT INTO Bookings (UserID, TrainNo, SeatsBooked, BookingDate) VALUES (@UserID, @TrainNo, @SeatsBooked, @BookingDate)", con);
                book.Parameters.AddWithValue("@UserID", loggedInUserId);
                book.Parameters.AddWithValue("@TrainNo", trainNo);
                book.Parameters.AddWithValue("@SeatsBooked", seatsToBook);
                book.Parameters.AddWithValue("@BookingDate", DateTime.Now);
                book.ExecuteNonQuery();

                // Update seats available in Trains table
                SqlCommand updateSeats = new SqlCommand("UPDATE Trains SET SeatsAvailable = SeatsAvailable - @SeatsBooked WHERE TrainNo = @TrainNo", con);
                updateSeats.Parameters.AddWithValue("@SeatsBooked", seatsToBook);
                updateSeats.Parameters.AddWithValue("@TrainNo", trainNo);
                updateSeats.ExecuteNonQuery();

                Console.WriteLine("Booking successful!");
                
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}
