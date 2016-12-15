using System;
using System.Collections.Generic;
using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multiple_Choice_Creator.Model;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Net;

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
            //sendMail(user);
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
                Console.WriteLine("logged= "+logged);
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

        public Boolean register(User user)
        {
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                //Tha xrhsimopoihsoume md5 kruptografish kai apokruptografish
                string query = "INSERT INTO Users (Email,Password,Fname,Lname) VALUES ('" + user.getEmail()+ "',md5('" + user.getPassword() + "'),'" + user.getFname() + "','" + user.getLname() + "')";
                string queryCheck = "Select Email from Users";
                MySqlCommand cmd2 = new MySqlCommand(queryCheck, conn);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader mdr = cmd.ExecuteReader();
                UsersTableAdapter uta = new UsersTableAdapter();
                int apot = Convert.ToInt32(uta.getUserID(user.getEmail()));
                user.setUserID(apot);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                ex.ToString();
                return false;
            }
            return true;
        }


        //This method is to create a 8 digit random text for the mail verification
        private static Random random = new Random();
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //This method is to send mail to the user for the mail verification
        public string sendMail(User user,int way)
        {
            MailMessage msg = new MailMessage();
            msg=addMailParameters(msg,user,way);
            SmtpClient client = new SmtpClient();
            client = addClientParameters(client);
            try
            {
                client.Send(msg);

                //Uplode to the table for the verification codes the data
                //tha prepei na exei perastei to user kai to munima na einai kati se fash Welcome user.getName() bla bla 
                return "Mail has been successfully sent!";
            }
            catch (Exception ex)
            {
                return "Fail Has error" + ex.Message;
            }
            finally
            {
                msg.Dispose();
            }
        }

        //this method is to add parameters to the mail 
        private MailMessage addMailParameters(MailMessage msg, User user,int way)
        {
            msg.From = new MailAddress("multiplechoiceteamteithe@gmail.com");
            msg.To.Add(user.getEmail());
            msg.Subject = "Multiple Choise Team Mail Verification" + DateTime.Now.ToString();
            string verificationCode = RandomString();
            msg.Body = "Welcome " + user.getFname() + " Verification Code: '" + verificationCode + "'";
            if (way == 0) { 
                insertVerificationCode(user.getUserID(), verificationCode);
            }else if (way == 1)
            {
                reSendVerificationCode(user.getUserID(), verificationCode);
            }
            //Edw tha kaleite h methodos gia na ginete to insert toy id tou xrhsth kai to verification code sto ACK
            return msg;
        }
        
        //this method is to add parameters to the Client of the mail
        private SmtpClient addClientParameters(SmtpClient client)
        {
            client.UseDefaultCredentials = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("multiplechoiceteamteithe@gmail.com", "123456789Multiple");
            client.Timeout = 20000;
            return client;

        }

        //This method is to check on login if the user has verified his mail
        public bool checkIfVerified(User user)
        {
            
                bool result = false;
                try
                {
                    ACKTableAdapter ackAdapter = new ACKTableAdapter();
                    int apot = Convert.ToInt32(ackAdapter.countVerification(user.getUserID()));//apo authn thn entolh an to apotelesma einai 1 tote exei kanei verify
                    Console.WriteLine("Result= " + result);
                    if (apot == 0)
                    {
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            return result;
        }

        public void insertVerificationCode(int userID,string verificationCode)
        {
            try
            {
                ACKTableAdapter ackAdapter = new ACKTableAdapter();
                ackAdapter.insertAckNumber(verificationCode, userID, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //pop a message here!
            }
        }

        public void reSendVerificationCode(int userID, string verificationCode)
        {
            try
            {
                ACKTableAdapter ackAdapter = new ACKTableAdapter();
                ackAdapter.updateAckNumber(verificationCode, userID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //pop a message here!
            }
        }


        public bool checkTheVerificationCode(User user,String VerificationCode)
        {
            bool result = false;
            try
            {
                ACKTableAdapter ackAdapter = new ACKTableAdapter();
                ackAdapter.deleteACKnumber(VerificationCode, user.getUserID());//Na to tsekarw!!
                if (checkIfVerified(user))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }
        

    }//end of class DaoUsers

}//end of added namespace

