using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Railway_Reservation
{
    public  partial class Program

    {
      
        static void ViewCancellations()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Cancellations", con);
                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    if (!read.HasRows)
                    {
                        Console.WriteLine("There are no cancellation records available to show.");
                        return;
                    }

                    Console.WriteLine("CancellationID, BookingID, CancelledSeats, CancellationDate");
                    while (read.Read())
                    {
                        Console.WriteLine($"{read["CancellationID"]}, {read["BookingID"]}, {read["CancelledSeats"]}, {read["CancellationDate"]}");
                    }
                }
            }
        }
    }
}
