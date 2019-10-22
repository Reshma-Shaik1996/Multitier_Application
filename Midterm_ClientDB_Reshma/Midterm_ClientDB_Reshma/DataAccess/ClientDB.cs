using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//SqlServer Database
using System.Windows.Forms;
using Midterm_ClientDB_Reshma.Business;

namespace Midterm_ClientDB_Reshma.DataAccess
{
   public static class ClientDB
    {

        public static bool IsUniqueId(int cliId)
        {

            //connect the database
            SqlConnection connDB = UtilityDB.ConnectDB();
            //create and customize an object of type SqlCommand
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "SELECT * FROM ClientDB " +
                                " WHERE ClientID= " + cliId;
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            MessageBox.Show(id.ToString()); // debug code
            if (id != 0)
            {
                return false;
            }

            // true if unique 
            return true;

        }


        public static void SaveRecord(Client cli)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "INSERT INTO ClientDB(ClientID,FirstName,LastName,PhoneNumber,Email) " +
                              " VALUES(@ClientID,@FirstName,@LastName,@PhoneNumber, @Email) ";
            cmd.Parameters.AddWithValue("@ClientID", cli.CLientID);
            cmd.Parameters.AddWithValue("@FirstName", cli.FirstName);
            cmd.Parameters.AddWithValue("@LastName", cli.LastName);
            cmd.Parameters.AddWithValue("@PhoneNumber", cli.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", cli.Email);

            cmd.ExecuteNonQuery();
            connDB.Close();

        }
        public static Client SearchRecord(int cliId)
        {
            Client cli = new Client();
            //Connect DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            //SqlCommand object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "SELECT * FROM ClientDB " +
                              "WHERE ClientID = @ClientID ";
            cmd.Parameters.AddWithValue("@ClientID", cliId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                cli.CLientID = Convert.ToInt32(reader["CLientID"]);
                cli.FirstName = reader["FirstName"].ToString();
                cli.LastName = reader["LastName"].ToString();
                cli.PhoneNumber = reader["PhoneNumber"].ToString();
                cli.Email = reader["Email"].ToString();

            }
            else
            {
                cli = null;
            }
            connDB.Close();
            //Close DB

            return cli;
        }

        public static List<Client> SearchRecord(int option, string name)
        {
            List<Client> listcli = new List<Client>();
            using (SqlConnection connDB = UtilityDB.ConnectDB())
            {
                switch (option)
                {
                    case 1: // search by FirstName
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = connDB;
                        cmd.CommandText = "SELECT * FROM ClientDB " +
                                          "WHERE FirstName = @FirstName ";

                        cmd.Parameters.AddWithValue("@FirstName", name);
                        SqlDataReader reader = cmd.ExecuteReader();
                        Client cli;
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                cli = new Client();
                                cli.CLientID = Convert.ToInt32(reader["CLientID"]);
                                cli.FirstName = reader["FirstName"].ToString();
                                cli.LastName = reader["LastName"].ToString();
                                cli.PhoneNumber = reader["PhoneNumber"].ToString();
                                cli.Email = reader["Email"].ToString();

                                listcli.Add(cli);
                            }

                        }
                        else
                        {
                            listcli = null;
                        }
                        break;
                  
                }
            }

            return listcli;
        }

        public static List<Client> ListRecord()
        {
            List<Client> listEmp = new List<Client>();

            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM CLientDB", connDB);
            SqlDataReader reader = cmd.ExecuteReader();
            Client cli;
            while (reader.Read())
            {
                cli = new Client();
                cli.CLientID = Convert.ToInt32(reader["CLientID"]);
                cli.FirstName = reader["FirstName"].ToString();
                cli.LastName = reader["LastName"].ToString();
                cli.PhoneNumber = reader["PhoneNumber"].ToString();
                cli.Email = reader["Email"].ToString();

                listEmp.Add(cli);
            }
            return listEmp;
        }

        public static void UpdateRecord(Client cli)
        {
            using (SqlConnection connDB = UtilityDB.ConnectDB())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connDB;
                cmd.CommandText = "UPDATE ClientDB " +
                                  " set FirstName = @FirstName, " +
                                    " LastName = @LastName, " +
                                    " PhoneNumber = @PhoneNumber " +
                                     " Email = @Email " +
                                    " WHERE CLientID = @CLientID ";
                cmd.Parameters.AddWithValue("@CLientID", cli.CLientID);
                cmd.Parameters.AddWithValue("@FirstName", cli.FirstName);
                cmd.Parameters.AddWithValue("@LastName", cli.LastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", cli.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", cli.Email);

                cmd.ExecuteNonQuery();
            }

        }
        public static void DeleteRecord(int empId)
        {

        }










    }
}
