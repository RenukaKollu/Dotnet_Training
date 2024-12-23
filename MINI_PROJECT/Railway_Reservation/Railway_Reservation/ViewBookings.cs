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
      
        static void ViewBookings()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Bookings", con);
                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    if (!read.HasRows)
                    {
                        Console.WriteLine("There are no bookings yet to show.");
                        return;
                    }

                    Console.WriteLine("BookingID, UserID, TrainNo, SeatsBooked, BookingDate");
                    while (read.Read())
                    {
                        Console.WriteLine($"{read["BookingID"]}, {read["UserID"]}, {read["TrainNo"]}, {read["SeatsBooked"]}, {read["BookingDate"]}");
                    }
                }
            }
        }

    }
}
