using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DBBroker;



public class ConnectionBroker
{

    private SqlConnection connection;
    private SqlTransaction transaction;

    public ConnectionBroker()
    {
        connection = new SqlConnection(ConfigurationManager.ConnectionStrings["projekat_baza"].ConnectionString);
        //connection = new SqlConnection(@"Data Source=DESKTOP-NLH7J2U;Initial Catalog=projekat_baza;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;");
    }

    public void OpenConnection()
    {
        Console.WriteLine("Pokusaj otvaranja konekcije");
        connection?.Open();
        Console.WriteLine("Uspesno otvaranje konekcije!");
    }

    public void CloseConnection()
    {
        connection?.Close();
        Console.WriteLine("Uspesno zatvorena konekcija!");
    }

    public void BeginTransaction()
    {
        transaction=connection.BeginTransaction();
    }

    public void Commit()
    {
        transaction?.Commit();
    }

    public void Rollback()
    {
        transaction?.Rollback();
    }

    public SqlCommand CreateCommand()
    {
        return new SqlCommand("", connection, transaction);
    }
}
