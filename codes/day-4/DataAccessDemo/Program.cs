using Microsoft.Data.SqlClient;
using System.Data;
using Siemens.DotNetCore.PmsApp.Entities;

AddData();
var products = Products();


static void AddData()
{
    SqlConnection? connection = null;
    SqlCommand? command = null;
    try
    {
        connection = new(@"server=JOYDIP-PC\SQLEXPRESS;database=siemensdb;integrated security=true;Encrypt=False;Trust Server Certificate=True;");
        command = connection.CreateCommand();
        command.CommandText = "spAddProduct";
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(
            new SqlParameter
            {
                ParameterName = "@id",
                Value = "PRO-0003",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar
            });
        command.Parameters.AddWithValue("@name", "hp probook");
        command.Parameters.AddWithValue("@desc", "new laptop from hp");
        command.Parameters.AddWithValue("@price", 115000.00M);

        connection.Open();
        int result = command.ExecuteNonQuery();
        if (result == 0)
            Console.WriteLine("operation failed..");
        else
            Console.WriteLine($"{result} records added");
    }
    catch (SqlException ex)
    {
        Console.WriteLine(ex);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
    finally
    {
        connection?.Close();
    }
}

static IEnumerable<Product>? Products()
{
    SqlConnection? connection = null;
    SqlCommand? command = null;
    SqlDataReader? reader = null;
    HashSet<Product>? products = null;
    try
    {
        connection = new(@"server=JOYDIP-PC\SQLEXPRESS;database=siemensdb;integrated security=true;Encrypt=False;Trust Server Certificate=True;");

        command = new();
        command.Connection = connection;
        command.CommandText = "select * from products";
        //command.CommandType = CommandType.Text;

        //command = connection.CreateCommand();
        //command.CommandText = "spGetProducts";
        //command.CommandType = CommandType.StoredProcedure;
        //command.Parameters.AddWithValue("@id", "PRO-0002");

        connection.Open();
        //Console.WriteLine(connection.State.ToString());

        reader = command.ExecuteReader();
        if (reader != null && reader.HasRows)
        {
            products = new HashSet<Product>();
            while (reader.Read())
            {
                Product product = new Product
                {
                    ProductId = (string)reader["productid"],
                    ProductName = (string)reader["productname"]
                };
                products.Add(product);
            }
        }
    }
    catch (SqlException ex)
    {
        Console.WriteLine(ex);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
    finally
    {
        reader?.Close();
        connection?.Close();
    }
    return products;
}

