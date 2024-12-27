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
        static string connectionString = "Data source=ICS-LT-694S693\\SQLEXPRESS; Initial Catalog=RailwayReservation; Integrated Security = true;";

        static int loggedInUserId;
        static string loggedInUserRole;
        static void Main(string[] args)
        {
            try
            {


                while (true)
                {
                    Console.WriteLine("Hello!! Welcome to  the IRCTC ");
                    Console.WriteLine("----------********-------------");
                    Console.WriteLine("1. Login");
                    Console.WriteLine("2. Register");
                    Console.WriteLine("3. Exit");
                    Console.Write("Enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("----------------------------------------");

                    switch (choice)
                    {
                        case 1:
                            Login();
                            break;
                        case 2:
                            Register();
                            break;
                        case 3:
                            return;

                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }

        static void Login()
        {
            Console.Write("Give Username to continue : ");
            string username = Console.ReadLine();
            Console.Write("Give Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("----------------------------------------");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT UserId, Role from Users where UserName = @UserName AND Password = @Password", con);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", password);
                SqlDataReader read = cmd.ExecuteReader();

                if (read.Read())
                {
                    loggedInUserId = (int)read["UserId"];
                    loggedInUserRole = (string)read["Role"];
                    read.Close();

                    if (loggedInUserRole == "Admin")
                    {
                        AdminMenu();
                    }
                    else
                    {
                        UserMenu();
                    }
                }
                else
                {
                    Console.WriteLine("You Entered Invalid username / password.");
                    Console.WriteLine("----------------------------------------");
                }
            }
        }

        static void Register()
        {
            Console.Write("Give Username to continue: ");
            string username = Console.ReadLine();
            Console.Write("Give Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("----------------------------------------");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (UserName, Password, Role) values (@UserName, @Password, 'User')", con);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Your Registration is successful!! And now you can login.");
                Console.WriteLine("----------------------------------------");
            }
        }

        static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Admin Menu");
                Console.WriteLine("1. Add Train");
                Console.WriteLine("2. Modify Train");
                Console.WriteLine("3. Delete Train");
                Console.WriteLine("4. View Trains");
                Console.WriteLine("5. View Bookings");
                Console.WriteLine("6. View Cancellations");
                Console.WriteLine("7. Logout");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine("----------------------------------------");

                switch (choice)
                {
                    case 1:
                        AddTrain();
                        break;
                    case 2:
                        ModifyTrain();
                        break;
                       
                    case 3:
                        DeleteTrain();
                        break;
                    case 4:
                        ViewTrains();
                        break;
                    case 5:
                        ViewBookings();
                        break;
                    case 6:
                        ViewCancellations();
                        break;
                    
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        static void UserMenu()
        {

            while (true)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("User Menu");
                Console.WriteLine("1. Search Trains");
                Console.WriteLine("2. View Trains");
                Console.WriteLine("3. Book Ticket");
                Console.WriteLine("4. Cancel Ticket");
                Console.WriteLine("5. View My Bookings");
                Console.WriteLine("6. Logout");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine("----------------------------------------");

                switch (choice)
                {
                    case 1:
                        SearchTrains();
                        break;
                    case 2:
                        ViewTrains();
                        break;
                    case 3:
                        BookTicket();
                        break;
                    case 4:
                        CancelTicket();
                        break;
                    case 5:
                        ViewUserBookings();
                        break;
                    
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }
    
}
