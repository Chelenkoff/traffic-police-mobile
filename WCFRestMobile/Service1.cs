using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFRestMobile.Model;

namespace WCFRestMobile
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string charset;

        public Service1()
        {
            ConnectToDb();
        }

        void ConnectToDb()
        {
            server = "localhost";
            database = "sql7112557";
            uid = "root";
            password = "root";
            charset = "utf8";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "CHARSET=" + charset + ";";

            connection = new MySqlConnection(connectionString);
        }

        //Open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        public User GetUserByIdAndPass(string id, string password)
        {

            string query = String.Format("call get_user_by_id_and_pass({0},\"{1}\")", id, password);


            string userId;
            string firstName;
            string secondName;
            string lastName;
            string isTrafficPoliceman;
            string pwd;

            //Open connection
            if (this.OpenConnection() == true)
            {
                User usr = new User();
                MySqlDataReader dataReader;
                try
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command                    
                    dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        userId = dataReader["user_id"] + "";
                        firstName = dataReader["first_name"] + "";
                        secondName = dataReader["second_name"] + "";
                        lastName = dataReader["last_name"] + "";
                        isTrafficPoliceman = dataReader["is_traffic_policeman"] + "";
                        pwd = dataReader["password"] + "";

                        usr.IsTrafficPoliceman = isTrafficPoliceman == "1" ? true : false;
                        usr.UserId = long.Parse(userId);
                        usr.FirstName = firstName;
                        usr.SecondName = secondName;
                        usr.LastName = lastName;
                        usr.UserPassword = pwd;
                    }
                    dataReader.Close();
                    return usr;
                }
                catch
                {   //Returning empty user with uninitialized properties (UserId = 0)
                    return new User();
                }
                finally
                {
                    this.CloseConnection();
                }

            }
            else
            {
                return null;
            }

        }

        public DriverOwner GetDriverOwnerById(string id)
        {
            string query = String.Format("call get_driverowner_data_by_id({0})", id);



            //Open connection
            if (this.OpenConnection() == true)
            {

                MySqlDataReader dataReader;
                try
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command                    
                    dataReader = cmd.ExecuteReader();

                    //Initializing empty user
                    DriverOwner drOwner = new DriverOwner();
                    drOwner.Categories = new Categories();
                    drOwner.Penalties = new List<Penalty>();

                    //Read the data and store them in the list

                    while (dataReader.Read())
                    {
                        drOwner.DriverOwnerId = Convert.ToInt64(dataReader["driver_owner_id"]);
                        drOwner.FirstName = dataReader["first_name"] + "";
                        drOwner.SecondName = dataReader["second_name"] + "";
                        drOwner.LastName = dataReader["last_name"] + "";
                        drOwner.Sex = ((dataReader["sex"] + "") == "М") ? SexEnum.Man : SexEnum.Woman;
                        drOwner.Nationality = dataReader["nationality"] + "";
                        drOwner.BirthDate = Convert.ToDateTime(dataReader["birth_date"]);
                        drOwner.BirthPlace = dataReader["birth_place"] + "";
                        drOwner.Residence = dataReader["residence"] + "";
                        drOwner.TelNum = dataReader["tel_num"] + "";
                        drOwner.Email = dataReader["email"] + "";
                        drOwner.RemainingPts = Convert.ToByte(dataReader["remaining_pts"]);
                        drOwner.LicenceIssueDate = Convert.ToDateTime(dataReader["licence_issue_date"]);
                        drOwner.LicenceExpiryDate = Convert.ToDateTime(dataReader["licence_expiry_date"]);
                        drOwner.LicenceIssuedBy = dataReader["licence_issued_by"] + "";

                        //Constructing 'Categories'


                        drOwner.Categories.a1AcquiryDate = dataReader["a1_acquiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["a1_acquiry_date"]);
                        drOwner.Categories.a1ExpiryDate = dataReader["a1_expiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["a1_expiry_date"]);
                        drOwner.Categories.a1Restrictions = dataReader["a1_restrictions"].ToString();

                        drOwner.Categories.aAcquiryDate = dataReader["a_acquiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["a_acquiry_date"]);
                        drOwner.Categories.aExpiryDate = dataReader["a_expiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["a_expiry_date"]);
                        drOwner.Categories.aRestrictions = dataReader["a_restrictions"].ToString();

                        drOwner.Categories.b1AcquiryDate = dataReader["b1_acquiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["b1_acquiry_date"]);
                        drOwner.Categories.b1ExpiryDate = dataReader["b1_expiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["b1_expiry_date"]);
                        drOwner.Categories.b1Restrictions = dataReader["b1_restrictions"].ToString();

                        drOwner.Categories.bAcquiryDate = dataReader["b_acquiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["b_acquiry_date"]);
                        drOwner.Categories.bExpiryDate = dataReader["b_expiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["b_expiry_date"]);
                        drOwner.Categories.bRestrictions = dataReader["b_restrictions"].ToString();

                        drOwner.Categories.c1AcquiryDate = dataReader["c1_acquiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["c1_acquiry_date"]);
                        drOwner.Categories.c1ExpiryDate = dataReader["c1_expiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["c1_expiry_date"]);
                        drOwner.Categories.c1Restrictions = dataReader["c1_restrictions"].ToString();

                        drOwner.Categories.cAcquiryDate = dataReader["c_acquiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["c_acquiry_date"]);
                        drOwner.Categories.cExpiryDate = dataReader["c_expiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["c_expiry_date"]);
                        drOwner.Categories.cRestrictions = dataReader["c_restrictions"].ToString();

                        drOwner.Categories.d1AcquiryDate = dataReader["d1_acquiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["d1_acquiry_date"]);
                        drOwner.Categories.d1ExpiryDate = dataReader["d1_expiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["d1_expiry_date"]);
                        drOwner.Categories.d1Restrictions = dataReader["d1_restrictions"].ToString();

                        drOwner.Categories.dAcquiryDate = dataReader["d_acquiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["d_acquiry_date"]);
                        drOwner.Categories.dExpiryDate = dataReader["d_expiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["d_expiry_date"]);
                        drOwner.Categories.dRestrictions = dataReader["d_restrictions"].ToString();

                        drOwner.Categories.beAcquiryDate = dataReader["be_acquiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["be_acquiry_date"]);
                        drOwner.Categories.beExpiryDate = dataReader["be_expiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["be_expiry_date"]);
                        drOwner.Categories.beRestrictions = dataReader["be_restrictions"].ToString();

                        drOwner.Categories.c1eAcquiryDate = dataReader["c1e_acquiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["c1e_acquiry_date"]);
                        drOwner.Categories.c1eExpiryDate = dataReader["c1e_expiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["c1e_expiry_date"]);
                        drOwner.Categories.c1eRestrictions = dataReader["c1e_restrictions"].ToString();

                        drOwner.Categories.ceAcquiryDate = dataReader["ce_acquiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["ce_acquiry_date"]);
                        drOwner.Categories.ceAcquiryDate = dataReader["ce_expiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["ce_expiry_date"]);
                        drOwner.Categories.ceRestrictions = dataReader["ce_restrictions"].ToString();

                        drOwner.Categories.d1eAcquiryDate = dataReader["d1e_acquiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["d1e_acquiry_date"]);
                        drOwner.Categories.d1eExpiryDate = dataReader["d1e_expiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["d1e_expiry_date"]);
                        drOwner.Categories.d1eRestrictions = dataReader["d1e_restrictions"].ToString();

                        drOwner.Categories.deAcquiryDate = dataReader["de_acquiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["de_acquiry_date"]);
                        drOwner.Categories.deExpiryDate = dataReader["de_expiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["de_expiry_date"]);
                        drOwner.Categories.deRestrictions = dataReader["de_restrictions"].ToString();

                        drOwner.Categories.ttbAcquiryDate = dataReader["ttb_acquiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["ttb_acquiry_date"]);
                        drOwner.Categories.ttbExpiryDate = dataReader["ttb_expiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["ttb_expiry_date"]);
                        drOwner.Categories.ttbRestrictions = dataReader["ttb_restrictions"].ToString();

                        drOwner.Categories.ttmAcquiryDate = dataReader["ttm_acquiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["ttm_acquiry_date"]);
                        drOwner.Categories.ttmExpiryDate = dataReader["ttm_expiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["ttm_expiry_date"]);
                        drOwner.Categories.ttmRestrictions = dataReader["ttm_restrictions"].ToString();

                        drOwner.Categories.tktAcquiryDate = dataReader["tkt_acquiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["tkt_acquiry_date"]);
                        drOwner.Categories.tktExpiryDate = dataReader["tkt_expiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["tkt_expiry_date"]);
                        drOwner.Categories.tktRestrictions = dataReader["tkt_restrictions"].ToString();

                        drOwner.Categories.mAcquiryDate = dataReader["m_acquiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["m_acquiry_date"]);
                        drOwner.Categories.mExpiryDate = dataReader["m_expiry_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["m_expiry_date"]);
                        drOwner.Categories.mRestrictions = dataReader["m_restrictions"].ToString();

                    }
                    //Closing current reader and prepare for the new one for the nex query
                    dataReader.Close();

                    query = String.Format("call get_driverowner_penalties_info({0})", id);
                    cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command                    
                    dataReader = cmd.ExecuteReader();
                    Penalty penalty;
                    while (dataReader.Read())
                    {
                        penalty = new Penalty();
                        //Fetch penalty info
                        penalty.PenaltyId = Convert.ToUInt64(dataReader["penalty_id"]);
                        penalty.IssuerId = Convert.ToInt64(dataReader["user_id"]);
                        penalty.DriverOwnerId = Convert.ToInt64(dataReader["driver_owner_id"]);
                        penalty.IssuedDateTime = Convert.ToDateTime(dataReader["date_time_issued"]);
                        penalty.HappenedDateTime = Convert.ToDateTime(dataReader["penalty_date_time"]);
                        penalty.Location = dataReader["location"].ToString();
                        penalty.Description = dataReader["description"].ToString();
                        penalty.Disagreement = dataReader["disagreement"].ToString();

                        drOwner.Penalties.Add(penalty);
                    }


                    dataReader.Close();
                    return drOwner;
                }
                catch
                {   //Returning empty user with uninitialized properties (UserId = 0)
                    return new DriverOwner();
                }
                finally
                {
                    this.CloseConnection();
                }

            }
            else
            {
                return null;
            }
        }

        public Registration getRegByRegNum(string regNum)
        {
            string query = String.Format("CALL get_reg_by_regnum(\"{0}\")", regNum);
            //Open connection
            if (this.OpenConnection() == true)
            {
                Registration reg = new Registration();
                MySqlDataReader dataReader;
                try
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command                    
                    dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        reg.RegNum = dataReader["reg_num"] + "";
                        reg.DriverOwnerId = Convert.ToInt64(dataReader["driver_owner_id"]);
                        reg.CarManufacturer = dataReader["car_manufacturer"] + "";
                        reg.CarModel = dataReader["car_model"] + "";
                        reg.CarColor = dataReader["car_color"] + "";
                        reg.CarType = dataReader["car_type"] + "";
                        reg.CarCubage = Convert.ToInt32(dataReader["car_cubage"]);
                        reg.CarHp = Convert.ToInt32(dataReader["car_hp"]);
                        reg.CarVin = dataReader["car_vin"] + "";
                        reg.FirstRegDate = Convert.ToDateTime(dataReader["first_reg_date"]);
                        reg.RecentRegDate = Convert.ToDateTime(dataReader["recent_certificate_reg_date"]);

                        reg.HasCivilInsurance = Convert.ToBoolean(dataReader["civil_insurance"]);
                        reg.CivilInsurer = dataReader["civil_insurer"] + "";
                        reg.CivilInsuranceStartDate = dataReader["civil_insurance_start_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["civil_insurance_start_date"]);
                        reg.CivilInsuranceEndDate = dataReader["civil_insurance_end_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["civil_insurance_end_date"]);

                        reg.HasVignette = Convert.ToBoolean(dataReader["has_vignette"]);
                        reg.VignetteValidUntil = dataReader["vignette_valid_until"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["vignette_valid_until"]);

                        reg.HasDamageInsurance = Convert.ToBoolean(dataReader["damage_insurance"]);
                        reg.DamageInsurer = dataReader["damage_insurer"] + "";
                        reg.DamageInsuranceStartDate = dataReader["damage_insurance_start_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["damage_insurance_start_date"]);
                        reg.DamageInsuranceEndDate = dataReader["damage_insurance_end_date"] == DBNull.Value ? Convert.ToDateTime("01/01/0001") : Convert.ToDateTime(dataReader["damage_insurance_end_date"]);


                    }
                    dataReader.Close();
                    return reg;
                }
                catch
                {   //Returning empty reg with uninitialized properties (regNum = null)
                    return new Registration();
                }
                finally
                {
                    this.CloseConnection();
                }

            }
            else
            {
                return null;
            }

        }

        public string addPenaltyToDriverOwner(Penalty pen)
        {
            ////////Test
            string insertQuery = "CALL add_penalty_to_driverowner(@user_id,@driver_owner_id,@date_time_issued,@penalty_date_time," +
                                             "@location,@latitude,@longtitude,@description,@disagreement)";
            //DB - Connected
            if (this.OpenConnection() == true)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(insertQuery, connection);

                    ///////////////////////////Test
                    //Declaring query params
                    cmd.Parameters.Add("@user_id", MySqlDbType.UInt64, 10);
                    cmd.Parameters.Add("@driver_owner_id", MySqlDbType.UInt64, 10);
                    cmd.Parameters.Add("@date_time_issued", MySqlDbType.DateTime);
                    cmd.Parameters.Add("@penalty_date_time", MySqlDbType.DateTime);
                    cmd.Parameters.Add("@location", MySqlDbType.VarChar,100);
                    cmd.Parameters.Add("@latitude", MySqlDbType.Double);
                    cmd.Parameters.Add("@longtitude", MySqlDbType.Double);
                    cmd.Parameters.Add("@description", MySqlDbType.TinyText);
                    cmd.Parameters.Add("@disagreement", MySqlDbType.MediumText);


                    //Setting params
                    cmd.Parameters["@user_id"].Value = pen.IssuerId;
                    cmd.Parameters["@driver_owner_id"].Value = pen.DriverOwnerId;
                    cmd.Parameters["@date_time_issued"].Value = pen.IssuedDateTime;
                    cmd.Parameters["@penalty_date_time"].Value = pen.HappenedDateTime;
                    cmd.Parameters["@location"].Value = pen.Location;
                    cmd.Parameters["@latitude"].Value = pen.Latitude;
                    cmd.Parameters["@longtitude"].Value = pen.Longtitude;
                    cmd.Parameters["@description"].Value = pen.Description;
                    cmd.Parameters["@disagreement"].Value = pen.Disagreement;

                    cmd.ExecuteNonQuery();
                    return "SUCCESS";
                }
                catch
                {

                    return "QUERY_ERROR";
                }
                finally
                {
                    this.CloseConnection();
                }

            }
            else
            {
                //DB - Not connected
                return "DB_ERROR";
            }
        }
    }
}
