using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

        
    }//telos class DaoMysql

}//telos namespace Multiple_Choice_Creator
