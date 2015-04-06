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
    

       public async static Task<Boolean> InsertNewRun(Run run)
       {
           SQLiteConnection connection;
           SQLiteCommand command;
           connection = new SQLiteConnection("data source=FitnessApplication.sqlite");
           command = new SQLiteCommand(connection);
           connection.Open();

           //command.CommandText = "INSERT INTO FitnessTable ("
       }

       
    }
}
