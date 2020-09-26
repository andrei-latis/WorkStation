using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WorkStationDAL
{
    public class User
    {

        SqlConnection connec = new SqlConnection(WorkStationDAL.Properties.Settings.Default.connec);

        private string user_id;
        private string user_name;
        private string user_first_name;
        private string user_second_name;
        private string user_email;
        private string user_password;
        private string user_profile_img;
        private DateTime user_birthday;
        private int user_level = 0;
        private string user_bio;

        public string userId
        {
            set
            {
                user_id = value.Trim();
            }
            get
            {
                return user_id;
            }
        }
        public string userName
        {
            set
            {
                if (value.Trim().Length > 50 || value.Trim().Length < 6)
                {
                    throw new Exception("Username Should Be Between 6 And 50 Characters");
                }
                else
                {
                    user_name = value.Trim();
                }
            }
            get
            {
                return user_name;
            }
        }
        public string userFirstName
        {
            set
            {
                if (value.Trim().Length > 50 || value.Trim().Length < 2)
                {
                    throw new Exception("Username Should Be Between 2 And 50 Characters");
                }
                else
                {
                    user_first_name = value.Trim();
                }
            }
            get
            {
                return user_first_name;
            }
        }
        public string userSecondName
        {
            set
            {
                if (value.Trim().Length > 50 || value.Trim().Length < 2)
                {
                    throw new Exception("Username Should Be Between 2 And 50 Characters");
                }
                else
                {
                    user_second_name = value.Trim();
                }
            }
            get
            {
                return user_second_name;
            }
        }
        public string userEmail
        {
            set
            {
                if (value.Trim().Length > 50 || IsValidEmail(value.Trim()) == false)
                {
                    throw new Exception("Invalid Email");
                }
                else
                {
                    user_email = value.Trim();
                }
            }
            get
            {
                return user_email;
            }
        }
        public string userPassword
        {
            set
            {
                if (value.Trim().Length != 128)
                {
                    throw new Exception("Invalid Password");
                }
                else
                {
                    user_password = value.Trim();
                }
            }
            get
            {
                return user_password;
            }
        }
        public string userProfileImg
        {
            set
            {
                user_profile_img = value;
            }
            get
            {
                return user_profile_img;
            }
        }
        public DateTime userBirthday
        {
            set
            {
                 user_birthday = value.Date;
            }
            get
            {
                return user_birthday;
            }
        }
        public int userLevelId
        {
            set
            {
                if (value < 0 || value > 5)
                {
                    throw new Exception("Invalid Level");
                }
                else
                {
                    user_level = value;
                }
            }
            get
            {
                return user_level;
            }
        }
        public string userBio
        {
            set
            {
                if (value.Trim().Length > 500)
                {
                    throw new Exception("");
                }
                else
                {
                    user_bio = value.Trim();
                }
            }
            get
            {
                return user_bio;
            }
        }

        //Functions
        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<User> LoginAcc(string Email, string Password)
        {
            userEmail = Email;
            userPassword = Password;


            List<User> UserN_LevelI = new List<User>();
            int idx = 0;
            connec.Open();

            SqlCommand cmd = new SqlCommand("spAccount_Login", connec);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserEmail", userEmail);
            cmd.Parameters.AddWithValue("@UserPassword", userPassword);

            SqlDataReader Rd = cmd.ExecuteReader();

            try
            {
                while (Rd.Read())
                {
                    if (Convert.ToInt32(Rd.GetValue(0)) == -1)
                    {
                        connec.Close();
                        return null;
                    }

                    UserN_LevelI.Add(new User());
                    UserN_LevelI[idx].userLevelId = Convert.ToInt32(Rd.GetValue(0));
                    UserN_LevelI[idx].userName = Rd.GetValue(1).ToString();
                }
                    connec.Close();
                    return UserN_LevelI;
            }
            catch (Exception)
            {
                connec.Close();
                return null;
            }
        }

        public int RegisterAcc(string Username, string FirstName, string SecondName, string Email, string Password, string ProfileImg, DateTime Birthday)
        {
            userName = Username;
            userFirstName = FirstName;
            userSecondName = SecondName;
            userEmail = Email;
            userPassword = Password;
            userProfileImg = ProfileImg;
            userBirthday = Birthday;

            try
            {
                connec.Open();
                SqlCommand cmd = new SqlCommand("spAccount_Create", connec);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", userName);
                cmd.Parameters.AddWithValue("@FirstName", userFirstName);
                cmd.Parameters.AddWithValue("@SecondName", userSecondName);
                cmd.Parameters.AddWithValue("@UserEmail", userEmail);
                cmd.Parameters.AddWithValue("@UserPassword", userPassword);
                cmd.Parameters.AddWithValue("@UserProfileImg", userProfileImg);
                cmd.Parameters.AddWithValue("@UserBirthday", userBirthday);

                //cmd.ExecuteNonQuery();
                SqlDataReader Rd = cmd.ExecuteReader();

                while (Rd.Read())
                {
                    if (Convert.ToInt32(Rd.GetValue(0)) == -1)
                    {
                        connec.Close();
                        return -1;
                    }
                }
                connec.Close();
                return 0;
            }
            catch (Exception)
            {
                connec.Close();
                return -1;
            }
        }

        public int DeletRegister(string Username)
        {
            userName = Username;

            try
            {
                connec.Open();
                SqlCommand cmd = new SqlCommand("DeletRegister", connec);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", userName);

                cmd.ExecuteNonQuery();
                connec.Close();
                return 0;
            }
            catch (Exception)
            {
                connec.Close();
                return -1;
            }
        }

        public List<User> UserProfile(string Username)
        {
            userName = Username;

            List<User> ProfileData = new List<User>();
            int idx = 0;

            try
            {
                connec.Open();
                SqlCommand cmd = new SqlCommand("spUserProfile", connec);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", userName);

                SqlDataReader Rd = cmd.ExecuteReader();

                while (Rd.Read())
                {
                    ProfileData.Add(new User());
                    ProfileData[idx].userProfileImg = Rd.GetValue(0).ToString();
                    ProfileData[idx].userBio = Rd.GetValue(1).ToString();
                    ProfileData[idx].userFirstName = Rd.GetValue(2).ToString();
                    ProfileData[idx].userSecondName = Rd.GetValue(3).ToString();
                    ProfileData[idx].userName = Rd.GetValue(4).ToString();
                }

                connec.Close();
                return ProfileData;
            }
            catch
            {
                connec.Close();
                return null;
            }
        }     
    }
}

