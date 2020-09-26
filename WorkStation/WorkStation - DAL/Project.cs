using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkStationDAL
{
    public class Project
    {
        SqlConnection connec = new SqlConnection(WorkStationDAL.Properties.Settings.Default.connec);

        private int id_ad;
        private string profile_img;
        private string user_name;
        private string requirements_and_data;
        private string user_first_name;
        private string user_second_name;
        private int stars;
        private string type_project;
        private string txt_review;


        public int IdAd
        {
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Erro");
                }
                else
                {
                    id_ad = value;
                }
            }
            get
            {
                return id_ad;
            }
        }
        public string ProfileImg
        {
            set
            {
                profile_img = value;
            }
            get
            {
                return profile_img;
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
        public string RequirementsAndData
        {
            set
            {
                if (value.Trim().Length > 8000 || value.Trim().Length < 8)
                {
                    throw new Exception("Username Should Be Between 8 And 8000 Characters");
                }
                else
                {
                    requirements_and_data = value.Trim();
                }
            }
            get
            {
                return requirements_and_data;
            }
        }
        public string userFirstName
        {
            set
            {
                if (value.Trim().Length > 50 || value.Trim().Length < 2)
                {
                    throw new Exception("User First Name Should Be Between 2 And 50 Characters");
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
                    throw new Exception("User Second Name Should Be Between 2 And 50 Characters");
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
        public int Stars
        {
            set
            {
                stars = value;
            }
            get
            {
                return stars;
            }
        }
        public string TypeProject
        {
            set
            {
                if (value.Trim().Length < 0 || value.Trim().Length > 50)
                {
                    throw new Exception("Erro on WorkStationDAL, class Project, Method TypeProject. TypeProject can have a minimum of 0 and a maximum of 50 characters");
                }
                else
                {
                    type_project = value;
                }
            }
            get
            {
                return type_project;
            }
        }
        public string Review
        {
            set
            {
                if (value.Trim().Length < 0 || value.Trim().Length > 500)
                {
                    throw new Exception("Erro on WorkStationDAL, class Project, Method Review. The Review can have a minimum of 0 and a maximum of 500 characters");
                }
                else
                {
                    txt_review = value;
                }
            }
            get
            {
                return txt_review;
            }
        }



        public List<Project> ProjectReview(string UserName)
        {
            userName = UserName;

            int idx = 0;
            List<Project> ProjectR = new List<Project>();

            connec.Open();
            SqlCommand cmd = new SqlCommand("spGetProjectReview", connec);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", userName);
            SqlDataReader Rd = cmd.ExecuteReader();

            try
            {
                while (Rd.Read())
                {
                    ProjectR.Add(new Project());
                    ProjectR[idx].ProfileImg = Rd.GetValue(0).ToString();
                    ProjectR[idx].userFirstName = Rd.GetValue(1).ToString();
                    ProjectR[idx].userSecondName = Rd.GetValue(2).ToString();
                    ProjectR[idx].Stars = Convert.ToInt32(Rd.GetValue(3).ToString());
                    ProjectR[idx].TypeProject = Rd.GetValue(4).ToString();
                    ProjectR[idx].Review = Rd.GetValue(5).ToString();
                    idx++;
                }
                connec.Close();
                return ProjectR;
            }
            catch (Exception)
            {
                connec.Close();
                return null;
            }
        }

        public int NewProject(int IdAd, string ClientUsername, string RequirementsAndData)
        {
            this.IdAd = IdAd;
            this.userName = ClientUsername;
            this.RequirementsAndData = RequirementsAndData;

            try
            {
                connec.Open();
                SqlCommand cmd = new SqlCommand("spNewProject", connec);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAd", IdAd);
                cmd.Parameters.AddWithValue("@ClienteUserName", userName);
                cmd.Parameters.AddWithValue("@RequirementsAndData", RequirementsAndData);

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
    }
}
