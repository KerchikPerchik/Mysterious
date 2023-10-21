using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

public class MySQL
{
    private static readonly string connStr = "server=localhost;user=root;database=MySQL;password=1234;Pooling=true;";

    public static void Test()
    {
        using MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            conn.Open();
            conn.Close();
            NAPI.Util.ConsoleOutput("Подключение к MySQL успешно");
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput(ex.ToString());
            NAPI.Util.ConsoleOutput("Подключение к MySQL не успешно");
        }
    }

    public static void Query(MySqlCommand command)
    {
        if (command == null || command.CommandText.Length < 1)
        {
            NAPI.Util.ConsoleOutput("Wrong command arg: null or empty");
            return;
        }
        using MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            conn.Open();
            command.Connection = conn;
            command.ExecuteNonQuery();
            conn.Close();

        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput(ex.ToString());
        }
    }

    public static DataTable QueryRead(MySqlCommand command)
    {
        if (command == null || command.CommandText.Length < 1)
        {
            NAPI.Util.ConsoleOutput("Wrong command arg: null or empty");
            return null;
        }
        using MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            conn.Open();
            command.Connection = conn;

            using MySqlDataReader reader = command.ExecuteReader();
            using (DataTable dt = new DataTable())
            {
                dt.Load(reader);
                return dt;
            }
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput(ex.ToString());
            return null;
        }
    }
}