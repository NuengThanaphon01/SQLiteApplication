using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace SQLiteAPP
{
    class DataAccess1
    {
        public static void InitializeDatabase()
        {

            using (SqliteConnection db =
               new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Customer (uID INTEGER PRIMARY KEY, " +
                    "first_Name NVARCHAR(30), " +
                    "last_Name NVARCHAR(30), " +
                    "email NVARCHAR(50))";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public static void AddData(string inputuID, string inputfirst_Name, string inputlast_Name, string inputemail)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=sqliteSample.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Customer VALUES (@uID, @first_Name, @last_Name, @email);";
                insertCommand.Parameters.AddWithValue("@uID", inputuID);
                insertCommand.Parameters.AddWithValue("@first_Name", inputfirst_Name);
                insertCommand.Parameters.AddWithValue("@last_Name", inputlast_Name);
                insertCommand.Parameters.AddWithValue("@email", inputemail);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }

        public static List<String> GetData()
        {
            List<String> entries = new List<string>();

            using (SqliteConnection db = new SqliteConnection("filename=sqliteSample.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT * from Customer", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                    entries.Add(query.GetString(3));
                }

                db.Close();
            }
            return entries;
        }
    }
}
