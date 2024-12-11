﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Assessment1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server = ICS-LT-694S693\\SQLEXPRESS; Database = InfiniteDB; Trusted_Connection = True;";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                
                using (SqlCommand command = new SqlCommand("InsertProductDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                   
                    command.Parameters.AddWithValue("@ProductName", "Laptop");
                    command.Parameters.AddWithValue("@Price", 70000);

                   
                    SqlParameter productIdParam = new SqlParameter("@GeneratedProductId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(productIdParam);

                    SqlParameter discountedPriceParam = new SqlParameter("@DiscountedPrice", SqlDbType.Decimal)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(discountedPriceParam);

                   
                    command.ExecuteNonQuery();

                   
                    int generatedProductId = (int)productIdParam.Value;
                    decimal discountedPrice = (decimal)discountedPriceParam.Value;

                    
                    Console.WriteLine("Generated Product ID: " + generatedProductId);
                    Console.WriteLine("Discounted Price: " + discountedPrice);
                    Console.Read();
                }
            }
        }
    }
}
