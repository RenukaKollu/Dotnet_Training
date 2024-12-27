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
        //static string connectionString = "Server=ICS-LT-694S693\\SQLEXPRESS; Database=RailwayReservationDB; Integrated Security = true;";

        static void ViewUserBookings()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand viewuser = new SqlCommand("select * from Bookings where UserID = @UserID", con);
                viewuser.Parameters.AddWithValue("@UserID", loggedInUserId);
                using (SqlDataReader read = viewuser.ExecuteReader())
                {
                    if (!read.HasRows)
                    {
                        Console.WriteLine("You have no bookings.");
                        return;
                    }

                     while (read.Read())
                     {
                      Console.WriteLine($"BookingID: {read["BookingID"]} TrainNo: {read["TrainNo"]}  SeatsBooked: {read["SeatsBooked"]}  BookingDate:  {read["BookingDate"]}");
                     }
                }
            }
        }
    }
}
