using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace Multiple_Choice_Creator
{
    //class to manage local database
    class LocalDatabase
    {
        SqlConnection conn;
        public LocalDatabase()
        {
            connect();
        }

        //connection to local server
        private void connect()
        {
            string pathj = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            pathj = pathj.Remove(pathj.Length - 9) + "Database.mdf"; //talimpania
            //string path = @"C:\Users\Lucifer\Source\Repos\MultipleChoiceCreator\Multiple Choice Creator\Multiple Choice Creator\Database.mdf";
            string dataSource = @"(LocalDB)\MSSQLLocalDB";
            conn = new SqlConnection("Data Source=" + dataSource +";AttachDbFilename=" + pathj +";Integrated Security=True");

            try
            {
                conn.Open();
                Debug.WriteLine("Open Connection " + pathj);
            } catch ( Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

        }
        //inserting course, incomplete.
        public void insertCourse(String name)
        {
            connect();
            SqlCommand comm = new SqlCommand("insert into Course(name) VALUES('" + name + "')", conn);
            comm.ExecuteNonQuery();
        }
    }
}
