using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Choice_Creator
{
    class DaoMysql
    {

        private static MySql.Data.MySqlClient.MySqlConnection conn;
        private static string myConnectionString = "server=192.168.6.177;uid=kantonio;" + "pwd=123456;database=kantonio;";

        public DaoMysql()
        {
            open();
        }

        public MySql.Data.MySqlClient.MySqlConnection getConnection()
        {
            return conn;
        }

        private static void open()
        {
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

                ex.ToString();
            }

        }//telos h function  open

        public int insertKati()
        {//paradeigma sql query insert...mia kentrikh klash diaxeirhshs
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                int am = 1044000;
                string query = "insert into Persons(PersonID) values(@am);";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@am", am);
                int r=cmd.ExecuteNonQuery(); 
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

                ex.ToString();
            }
            return 1;
        }


        public Boolean Login(String mail, String pass)
        {
            // create connection before
            //open our connection
            int count = 0;
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                // query using dataadapter into our database
                //string query = "SELECT * FROM User";

                string query = "SELECT * FROM User WHERE Email='" + mail + "' AND Password='" + pass + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader mdr = cmd.ExecuteReader();
                // we will using datatable to bing data into datagridview
                while (mdr.Read())
                {
                    count++;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

                ex.ToString();
            }
            if (count == 1)
                return true;
            else
                return false;

        }


        public Boolean register(String name, String last, String mail, String password)
        {
            try {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                //To ar tha alaksei apo vash kai tha ginetai autoassign
                int ar = 06;
                //Tha xrhsimopoihsoume md5 kruptografish kai apokruptografish
                string query = "INSERT INTO User (Id,Email,Password,Fname,Lname) VALUES ("+ar+",'"+mail+"','"+password+"','"+ name + "','" + last +"')";
                string queryCheck = "Select Email from User";
                MySqlCommand cmd2 = new MySqlCommand(queryCheck, conn);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader mdr = cmd.ExecuteReader();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex) {
                ex.ToString();
                return false;
            }
            return true;
        }



        public List<Theme> returnThemeTree()
        {
            List<Theme> myList = new List<Theme>();
            string query = "SELECT * FROM Theme";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    string Id = mdr["Id"].ToString();
                    Theme tempTheme = new Theme(Int32.Parse(mdr["Id"].ToString()), mdr["name"].ToString(), mdr["Description"].ToString(), Int32.Parse(mdr["userId"].ToString()), Int32.Parse(mdr["courseId"].ToString()), Int32.Parse(mdr["Parent"].ToString()));
                    myList.Add(tempTheme);
                    Console.WriteLine(tempTheme.toString());
                    Console.WriteLine("To id einai: "+Id);
                }
                return myList;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

                ex.ToString();
            }
            return myList;
        }

    }

    
    

}//telos namespace Multiple_Choice_Creator
