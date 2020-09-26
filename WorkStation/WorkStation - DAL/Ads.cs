using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkStationDAL
{
    public class Ads
    {
        SqlConnection connec = new SqlConnection(WorkStationDAL.Properties.Settings.Default.connec);


        //Ad Table
        private int id_ad;
        private string ad_name;
        private string ad_description;
        private string ad_img1;
        private int ad_creator_id;
        private double project_price;
        private int project_type;
        private int ad_closed;

        //TypeProject Table
        private int type_project_id;
        private string type_project_txt;

        private string user_name;
        private int stars;
        private string user_profile_img;

        //Ad Table
        public int IdAd
        {
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Erro on WorkStationDAL, class Ads, Method IdAd");
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
        public string AdName
        {
            set
            {
                if (value.Trim().Length < 0 || value.Trim().Length > 50)
                {
                    throw new Exception("Erro on WorkStationDAL, class Ads, Method AdName. AdName can have a minimum of 0 and a maximum of 50 characters");
                }
                else
                {
                    ad_name = value;
                }
            }
            get
            {
                return ad_name;
            }
        }
        public string AdDescription
        {
            set
            {
                if (value.Trim().Length < 0 || value.Trim().Length > 200)
                {
                    throw new Exception("Erro on WorkStationDAL, class Ads, Method AdDescription. AdDescription can have a minimum of 0 and a maximum of 50 characters");
                }
                else
                {
                    ad_description = value;
                }
            }
            get
            {
                return ad_description;
            }
        }
        public string AdImg1
        {
            set
            {
                if (value.Trim().Length < 0)
                {
                    throw new Exception("Erro on WorkStationDAL, class Ads, Method AdImg1.");
                }
                else
                {
                    ad_img1 = value;
                }
            }
            get
            {
                return ad_img1;
            }
        }
        public int AdCreatoId
        {
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Erro on WorkStationDAL, class Ads, Method AdCreatoId");
                }
                else
                {
                    ad_creator_id = value;
                }
            }
            get
            {
                return ad_creator_id;
            }
        }
        public double ProjectPrice
        {
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Erro on WorkStationDAL, class Ads, Method ProjectPrice");
                }
                else
                {
                    project_price = value;
                }
            }
            get
            {
                return project_price;
            }
        }
        public int ProjectType
        {
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Erro on WorkStationDAL, class Ads, Method ProjectType");
                }
                else
                {
                    project_type = value;
                }
            }
            get
            {
                return project_type;
            }
        }
        public int AdClosed
        {
            set
            {
                if (value != 0 && value != 1)
                {
                    throw new Exception("Erro on WorkStationDAL, class Ads, Method AdClosed");
                }
                else
                {
                    ad_closed = value;
                }
            }
            get
            {
                return ad_closed;
            }
        }

        //TypeProject Table
        public int TypeProjectId
        {
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Erro on WorkStationDAL, class Ads, Method TypeProjectId");
                }
                else
                {
                    type_project_id = value;
                }
            }
            get
            {
                return type_project_id;
            }
        }
        public string TypeProjectTxt
        {
            set
            {
                if (value.Trim().Length < 0 || value.Trim().Length > 300)
                {
                    throw new Exception("Erro on WorkStationDAL, class Ads, Method TypeProjectTxt. TypeProjectTxt can have a minimum of 0 and a maximum of 50 characters");
                }
                else
                {
                    type_project_txt = value;
                }
            }
            get
            {
                return type_project_txt;
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



        public List<Ads> Ad(string TypeProject)
        {
            this.TypeProjectTxt = TypeProject;

            List<Ads> tryin = new List<Ads>();
            int idx = 0;

            connec.Open();
            SqlCommand cmd = new SqlCommand("GetAds", connec);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProjectType", TypeProjectTxt);

            SqlDataReader Rd = cmd.ExecuteReader();

            try
            {
                while (Rd.Read())
                {
                    tryin.Add(new Ads());
                    tryin[idx].AdName = Rd.GetValue(0).ToString();
                    tryin[idx].TypeProjectTxt = Rd.GetValue(1).ToString();
                    tryin[idx].ProjectPrice = Convert.ToDouble(Rd.GetValue(2));
                    tryin[idx].AdImg1 = Rd.GetValue(3).ToString();
                    tryin[idx].AdDescription = Rd.GetValue(4).ToString();
                    tryin[idx].userName = Rd.GetValue(5).ToString();
                    tryin[idx].userProfileImg = Rd.GetValue(6).ToString();
                    tryin[idx].IdAd = Convert.ToInt32(Rd.GetValue(7));

                    idx++;
                }

                connec.Close();
                return tryin;
            }
            catch (Exception)
            {
                connec.Close();
                return null;
            }
        }

        public List<Ads> ProjectTypeList()
        {
            List<Ads> ProjectType = new List<Ads>();
            int idx = 0;

            connec.Open();
            SqlCommand cmd = new SqlCommand("spProjectTypeList", connec);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader Rd = cmd.ExecuteReader();

            try
            {
                while (Rd.Read())
                {
                    ProjectType.Add(new Ads());
                    ProjectType[idx].TypeProjectId = Convert.ToInt32(Rd.GetValue(0));
                    ProjectType[idx].TypeProjectTxt = Rd.GetValue(1).ToString();

                    idx++;
                }

                connec.Close();
                return ProjectType;
            }
            catch (Exception)
            {
                connec.Close();
                return null;
            }
        }

        public int CreateAd(string AdName, string AdDescription, string AdImage, string AdCreatorUsername, double ProjectPrice, string project_type)
        {
            this.AdName = AdName;
            this.AdDescription = AdDescription;
            this.AdImg1 = AdImage;
            this.userName = AdCreatorUsername;
            this.ProjectPrice = ProjectPrice;
            this.TypeProjectTxt = project_type;

            try
            {
                connec.Open();
                SqlCommand cmd = new SqlCommand("spCreateAd", connec);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AdName", AdName);
                cmd.Parameters.AddWithValue("@AdDescription", AdDescription);
                cmd.Parameters.AddWithValue("@AdImage", AdImage);
                cmd.Parameters.AddWithValue("@AdCreatorUsename", AdCreatorUsername);
                cmd.Parameters.AddWithValue("@ProjectPrice", ProjectPrice);
                cmd.Parameters.AddWithValue("@project_type", project_type);

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
