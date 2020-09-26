using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkStationDAL
{
    public class Skills
    {
        SqlConnection connec = new SqlConnection(WorkStationDAL.Properties.Settings.Default.connec);

        private int id_technical_language;
        private int id_technology;
        private int id_language;
        private string user_name;
        private string language;
        private string technical_language;
        private string technology;

        public int IdTechnicalLanguage
        {
            set
            {
                id_technical_language = value;
            }
            get
            {
                return id_technical_language;
            }
        }
        public int IdTechnology
        {
            set
            {
                id_technology = value;
            }
            get
            {
                return id_technology;
            }
        }
        public int IdLanguage
        {
            set
            {
                id_language = value;
            }
            get
            {
                return id_language;
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
        public string Language
        {
            set
            {
                language = value;
            }
            get
            {
                return language;
            }
        }
        public string TechnicalLanguage
        {
            set
            {
                technical_language = value;
            }
            get
            {
                return technical_language;
            }
        }
        public string Technology
        {
            set
            {
                technology = value;
            }
            get
            {
                return technology;
            }
        }

        //To view userskils
        public List<Skills> TechnologySkills(string UserName)
        {
            userName = UserName;

            int idx = 0;
            List<Skills> TechnologyS = new List<Skills>();

            connec.Open();
            SqlCommand cmd = new SqlCommand("spTechnology", connec);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", userName);
            SqlDataReader Rd = cmd.ExecuteReader();

            try
            {
                while (Rd.Read())
                {
                    TechnologyS.Add(new Skills());
                    TechnologyS[idx].Technology = Rd.GetValue(0).ToString();

                    idx++;
                }
                connec.Close();
                return TechnologyS;
            }
            catch (Exception)
            {
                connec.Close();
                return null;
            }
        }
        public List<Skills> TechnicalLanguageSkills(string UserName)
        {
            userName = UserName;

            int idx = 0;
            List<Skills> TechnicalLanguageS = new List<Skills>();

            connec.Open();
            SqlCommand cmd = new SqlCommand("spTechnicalLanguage", connec);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", userName);
            SqlDataReader Rd = cmd.ExecuteReader();

            try
            {
                while (Rd.Read())
                {
                    TechnicalLanguageS.Add(new Skills());
                    TechnicalLanguageS[idx].TechnicalLanguage = Rd.GetValue(0).ToString();

                    idx++;
                }
                connec.Close();
                return TechnicalLanguageS;
            }
            catch (Exception)
            {
                connec.Close();
                return null;
            }
        }
        public List<Skills> LanguageSkills(string UserName)
        {
            userName = UserName;

            int idx = 0;
            List<Skills> LanguageS = new List<Skills>();

            connec.Open();
            SqlCommand cmd = new SqlCommand("spLanguage", connec);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", userName);
            SqlDataReader Rd = cmd.ExecuteReader();

            try
            {
                while (Rd.Read())
                {
                    LanguageS.Add(new Skills());
                    LanguageS[idx].Language = Rd.GetValue(0).ToString();

                    idx++;
                }
                connec.Close();
                return LanguageS;
            }
            catch (Exception)
            {
                connec.Close();
                return null;
            }
        }

        //To view skills
        public List<Skills> ViewTechnologySkills()
        {
            int idx = 0;
            List<Skills> ViewTechnology = new List<Skills>();

            try
            {
                connec.Open();
                SqlCommand cmd = new SqlCommand("spViewTechnologySkills", connec);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader Rd = cmd.ExecuteReader();

                while (Rd.Read())
                {
                    ViewTechnology.Add(new Skills());
                    ViewTechnology[idx].IdTechnology = Convert.ToInt32(Rd.GetValue(0).ToString());
                    ViewTechnology[idx].Technology = Rd.GetValue(1).ToString();

                    idx++;
                }
                connec.Close();
                return ViewTechnology;
            }
            catch (Exception)
            {
                connec.Close();
                return null;
            }
        }
        public List<Skills> ViewTechnicalLanguageSkills()
        {
            int idx = 0;
            List<Skills> ViewTechnicalLanguage = new List<Skills>();

            try
            {
                connec.Open();
                SqlCommand cmd = new SqlCommand("spViewTechnicalLanguageSkills", connec);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader Rd = cmd.ExecuteReader();

                while (Rd.Read())
                {
                    ViewTechnicalLanguage.Add(new Skills());
                    ViewTechnicalLanguage[idx].IdTechnicalLanguage = Convert.ToInt32(Rd.GetValue(0).ToString());
                    ViewTechnicalLanguage[idx].TechnicalLanguage = Rd.GetValue(1).ToString();

                    idx++;
                }
                connec.Close();
                return ViewTechnicalLanguage;
            }
            catch (Exception)
            {
                connec.Close();
                return null;
            }
        }
        public List<Skills> ViewLanguageSkills()
        {
            int idx = 0;
            List<Skills> ViewLanguage = new List<Skills>();

            try
            {
                connec.Open();
                SqlCommand cmd = new SqlCommand("spViewLanguageSkills", connec);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader Rd = cmd.ExecuteReader();

                while (Rd.Read())
                {
                    ViewLanguage.Add(new Skills());
                    ViewLanguage[idx].IdLanguage = Convert.ToInt32(Rd.GetValue(0).ToString());
                    ViewLanguage[idx].Language = Rd.GetValue(1).ToString();

                    idx++;
                }
                connec.Close();
                return ViewLanguage;
            }
            catch (Exception)
            {
                connec.Close();
                return null;
            }
        }

        //To create new skills
        public int TechnologyNewSkill(string Technology)
        {
            this.Technology = Technology;

            try
            {
                connec.Open();
                SqlCommand cmd = new SqlCommand("spTechnologyNewSkill", connec);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Technology", this.Technology);

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
            catch
            {
                connec.Close();
                return -1;
            }
        }
        public int TechnicalLanguageNewSkill(string TechnicalLanguage)
        {
            this.TechnicalLanguage = TechnicalLanguage;

            try
            {
                connec.Open();
                SqlCommand cmd = new SqlCommand("spTechnicalLanguageNewSkill", connec);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TechnicalLanguage", this.TechnicalLanguage);

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
            catch
            {
                connec.Close();
                return -1;
            }
        }
        public int LanguageNewSkill(string Language)
        {
            this.Language = Language;

            try
            {
                connec.Open();
                SqlCommand cmd = new SqlCommand("spLanguageNewSkill", connec);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Language", this.Language);

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
            catch
            {
                connec.Close();
                return -1;
            }
        }

        //To delete skills
        public int DeleteLanguageSkill(string Language)
        {
            this.Language = Language;

            try
            {
                connec.Open();
                SqlCommand cmd = new SqlCommand("spDeleteLanguageSkill", connec);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Language", this.Language);

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
            catch
            {
                connec.Close();
                return -1;
            }
        }
        public int DeleteTechnicalLanguageSkill(string TechnicalLanguage)
        {
            this.TechnicalLanguage = TechnicalLanguage;

            try
            {
                connec.Open();
                SqlCommand cmd = new SqlCommand("spDeleteTechnicalLanguageSkill", connec);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TechnicalLanguage", this.TechnicalLanguage);

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
            catch
            {
                connec.Close();
                return -1;
            }
        }
        public int DeleteTechnologySkill(string Technology)
        {
            this.Technology = Technology;

            try
            {
                connec.Open();
                SqlCommand cmd = new SqlCommand("spDeleteTechnologySkill", connec);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Technology", this.Technology);

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
            catch
            {
                connec.Close();
                return -1;
            }
        }
    }
}
