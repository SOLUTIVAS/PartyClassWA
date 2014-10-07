using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace TC.Datos
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "bd_tourcolombia";
            uid = "root";
            password = "Mae$tro01";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {                
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {                
                return false;
            }
        }

        //Insert statement
        public void Insert()
        {
        }

        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
        }

        //Select statement
        public List<string>[] Select()
        {
            string query = "SELECT * FROM municipio";

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataAdapter da = new MySqlDataAdapter(query, connection);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["idMunicipio"] + "");
                    list[1].Add(dataReader["Nombre"] + "");
                    list[2].Add(dataReader["Categoria"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        public DataSet SelectDS(string sp)
        {
            //Open connection
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.CommandText = sp;

                //asignar paramentros
                cmd.Parameters.AddWithValue("parDepartamento", 7);
                //cmd.Parameters.AddWithValue("param2", pValor2);
                //cmd.Parameters.AddWithValue("param3", pValor3);

                //Create Adapter
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                
                da.Fill(ds, "municipio");
                
                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return ds;
            }
            else
            {
                return new DataSet();
            }
        }

        //Count statement
        public int Count()
        {
            return 0;
        }      
    }
}
