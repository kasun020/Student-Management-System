using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.IO;
using System.Windows;
namespace StudentManagementSystem.Model
{
    internal class DataContext: DbConfiguration
    {
        public DataContext()
        {
            
        }
        public bool ExecuteWrite(string query, Dictionary<string, object> args)  
        {  
            string path = Directory.GetCurrentDirectory()+@"\./Database.db;";
  
            //setup the connection to the database  
            using (var con = new SQLiteConnection(@"Data Source="+path))  
            {  
                con.Open();  
  
                //open a new command  
                using (var cmd = new SQLiteCommand(query, con))  
                {  
                    //set the arguments given in the query  
                    foreach (var pair in args)  
                    {  
                        cmd.Parameters.AddWithValue(pair.Key, pair.Value);  
                    }  
  
                    cmd.ExecuteNonQuery();  
                    return true;
                } 
  
            }

            
        }  
  
        public DataTable Execute(string query, Dictionary<string, object> args)  
        {  
            if (string.IsNullOrEmpty(query.Trim()))  
                return null;

            string path = Directory.GetCurrentDirectory()+@"\./Database.db;";
  
            using (var con = new SQLiteConnection(@"Data Source="+path))  
            {  
                con.Open();  
                using (var cmd = new SQLiteCommand(query, con))  
                {  
                    foreach (KeyValuePair<string, object> entry in args)  
                    {  
                        cmd.Parameters.AddWithValue(entry.Key, entry.Value);  
                    }  
  
                    var da = new SQLiteDataAdapter(cmd);  
  
                    var dt = new DataTable();  
                    da.Fill(dt);  
  
                    da.Dispose();  
                    return dt;  
                }  
            }  
        } 

        public void SaveImageToDatabase(string imagePath, byte[] imageBytes)
        {
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\./Database.db;";
                /*string connectionString = "Data Source=image_database.db;Version=3;";*/
                string connectionString = "Data Source="+path;

                // Create database file if not exists
                /*if (!File.Exists("image_database.db"))
                {
                    SQLiteConnection.CreateFile("image_database.db");
                }*/

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    /*
                    string sql = "CREATE TABLE IF NOT EXISTS Images (ImagePath TEXT, ImageData BLOB)";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }*/

                    // Insert image into the database
                    string sql = "INSERT INTO tblUsers (ImagePath, ImageData) VALUES (@ImagePath, @ImageData)";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ImagePath", imagePath);
                        command.Parameters.AddWithValue("@ImageData", imageBytes);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Image saved to database successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
