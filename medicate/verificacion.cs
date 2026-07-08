using medicate.CapaDatos;
using MySql.Data.MySqlClient;
using System;
using System.Data;

public class TestConnection
{
    public static bool ProbarConexion()
    {
        try
        {
            using (MySqlConnection conn = clsConexion.ObtenerConexion())
            {
                return conn.State == ConnectionState.Open;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return false;
        }
    }
}