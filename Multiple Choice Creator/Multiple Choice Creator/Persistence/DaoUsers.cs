using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multiple_Choice_Creator.Model;
using MySql.Data.MySqlClient;
namespace Multiple_Choice_Creator.Persistence
{
    public class DaoUsers
    {
        private static MySql.Data.MySqlClient.MySqlConnection conn;
        private static string myConnectionString = "server=192.168.6.177;uid=kantonio;"
            + "pwd=123456;database=kantonio;";
        private static DaoUsers instance;
        public static DaoUsers getInstance()
        {
            if (instance == null)
            {
                instance = new DaoUsers();
            }
            return instance;
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
                Console.WriteLine(ex.ToString());
            }
        }

        public bool login(User user)
        {//an den dumbei kanena exception tote elegxoume an mas epestrepse count=1 to query mas
         //praktika elegxoume an yparxei enas user me email=user.getEmail() kai password=user.getPassword()
         //an uparxei tote to query mas tha mas epistrepsei 1 

            open();//open a new connection
            int logged=0;
            try {
                string query = "select count(*) from Users where Email=@email and Password=md5(@passwd)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Prepare();//pernaei to h entolh mas apo merikous standar elegxous
                cmd.Parameters.AddWithValue("@email", user.getEmail());//opou sunantame @email bazoume to email tou user pou paei na kanei login
                cmd.Parameters.AddWithValue("@passwd", user.getPassword());
                Object count = cmd.ExecuteScalar();
                logged = Convert.ToInt32(count);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            if (logged == 1)
            {
                return true;
            }
            return false;
        }

        public Boolean register(String name, String last, String mail, String password)
        {
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                //Tha xrhsimopoihsoume md5 kruptografish kai apokruptografish
                string query = "INSERT INTO User (Email,Password,Fname,Lname) VALUES ('" + mail + "',md5('" + password + "'),'" + name + "','" + last + "')";
                string queryCheck = "Select Email from User";
                MySqlCommand cmd2 = new MySqlCommand(queryCheck, conn);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader mdr = cmd.ExecuteReader();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                ex.ToString();
                return false;
            }
            return true;
        }

    }//end of class DaoUsers

    }//end of added namespace

