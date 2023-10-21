using GTANetworkAPI;
using MySql.Data.MySqlClient;

public class Events : Script
{
    [ServerEvent(Event.ResourceStart)]
    public void OnResourceStart()
    {
        NAPI.Util.ConsoleOutput("Hello world");
        MySQL.Test();

        string insertQuery = "INSERT INTO users.address (idaddress) (address) VALUES (@idaddress) (@address)";
        using MySqlCommand insertCommand = new MySqlCommand(insertQuery);
        insertCommand.Parameters.AddWithValue("@idaddress", 1);
        insertCommand.Parameters.AddWithValue("@address", "Kirill_Mukhachev");

        MySQL.Query(insertCommand);
    }
}