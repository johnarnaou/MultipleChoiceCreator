﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Choice_Creator.Persistence
{
    class DaoTagQuest
    {
        private static DaoTagQuest instance;
        public static DaoTagQuest getInstance()
        {
            if (instance == null)
            {
                instance = new DaoTagQuest();
            }
            return instance;
        }

        private static void open()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString = "server=192.168.6.177;uid=kantonio;"
                + "pwd=123456;database=kantonio;";
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
    }
}
