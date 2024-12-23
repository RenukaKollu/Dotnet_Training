using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Policy;


namespace Railway_Reservation
{
    public partial class Program
    {
        
        static void CancelTicket()
        {
            Console.Write("Enter the Booking ID to cancel the ticket: ");
            int bookingId = int.Parse(Console.ReadLine());
            Console.Write("Enter number of seats to cancel: ");
            int seatsToCancel = int.Parse(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Check booking and booked seats 
                SqlCommand checkBooking = new SqlCommand("SELECT SeatsBooked, TrainNo FROM Bookings WHERE BookingID = @BookingID AND UserID = @UserID", con);
                checkBooking.Parameters.AddWithValue("@BookingID", bookingId);
                checkBooking.Parameters.AddWithValue("@UserID", loggedInUserId);

                int seatsBooked = 0;
                int trainNo = 0;
                using (SqlDataReader read = checkBooking.ExecuteReader())
                {
                    if (read.Read())
                    {
                        seatsBooked = read.GetInt32(0);
                        trainNo = read.GetInt32(1);
                    }
                    else
                    {
                        Console.WriteLine("Booking not found.");
                        return;
                    }
                }

                if (seatsToCancel > seatsBooked)
                {
                    Console.WriteLine("Cannot cancel more seats than booked.");
                    return;
                }

                // Insert cancellation record
                SqlCommand cancel = new SqlCommand("INSERT INTO Cancellations (BookingID, CancelledSeats, CancellationDate) VALUES (@BookingID, @CancelledSeats, @CancellationDate)", con);
                cancel.Parameters.AddWithValue("@BookingID", bookingId);
                cancel.Parameters.AddWithValue("@CancelledSeats", seatsToCancel);
                cancel.Parameters.AddWithValue("@CancellationDate", DateTime.Now);
                cancel.ExecuteNonQuery();

                // Update seats available in Trains table
                SqlCommand updateSeats = new SqlCommand("UPDATE Trains SET SeatsAvailable = SeatsAvailable + @CancelledSeats WHERE TrainNo = @TrainNo", con);
                updateSeats.Parameters.AddWithValue("@CancelledSeats", seatsToCancel);
                updateSeats.Parameters.AddWithValue("@TrainNo", trainNo);
                updateSeats.ExecuteNonQuery();

                // Update seats booked in Bookings table
                SqlCommand updateBooking = new SqlCommand("UPDATE Bookings SET SeatsBooked = SeatsBooked - @CancelledSeats WHERE BookingID = @BookingID", con);
                updateBooking.Parameters.AddWithValue("@CancelledSeats", seatsToCancel);
                updateBooking.Parameters.AddWithValue("@BookingID", bookingId);
                updateBooking.ExecuteNonQuery();

                Console.WriteLine(" your Cancellation is successful !!! And Your payment for the cancelled tickets will be refunded soon.");
            }
        }
    }
}
