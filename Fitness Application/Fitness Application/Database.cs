using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Fitness_Application
{
   public static  class Database
    {
    

       public static void InsertNewRun(Run run)
       {
           SQLiteConnection connection = new SQLiteConnection("data source=FitnessApplication.sqlite"); ;
           SQLiteCommand command= new SQLiteCommand(connection);
           try
           {
           
           command.CommandText = "INSERT INTO FitnessTable (Time, Distance) Values (@time, @distance)";
           command.Parameters.AddWithValue("@time", run.time);
           command.Parameters.AddWithValue("@distance", run.distance);
           connection.Open();
           command.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               Console.WriteLine("Error inserting run.");

           }
           finally
           {
               connection.Close();
           }
           
           
       }

    }
}
