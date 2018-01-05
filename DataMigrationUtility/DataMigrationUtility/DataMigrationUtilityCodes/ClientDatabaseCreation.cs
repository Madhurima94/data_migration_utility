
using DataMigrationUtility.Utility;
using ImageMagick;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Security;
using WebAccounting.Lib.Utility;
using System.Web.WebPages;

namespace DataMigrationUtility.DataMigrationUtilityCodes
{
    class ClientDatabaseCreation
    {
        static string cs = AppSettingsUtil.ConnectionStringMasterDB;
        static string cs1 = AppSettingsUtil.ConnectionStringSourceDB;
        static string cs2 = AppSettingsUtil.ConnectionStringClientDB;
        public static object ClientId;
        static object AccountantId;
        static object MasterDBClientId;
        static object AccountId;
        static List<object> clientUsernamesList = new List<object>();
        static List<object> clientUserIdsList = new List<object>();

        public static void CreateUsersForClients()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cs1))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT DISTINCT AccountID FROM Account ORDER BY AccountID ASC", connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AccountId = reader.GetValue(0);
                                using (MySqlConnection connection1 = new MySqlConnection(cs1))
                                {
                                    string datas;
                                    object data;
                                    connection1.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT Name FROM account Where AccountID =" + AccountId, connection1))
                                    {
                                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                datas = "";
                                                data = reader1.GetValue(0);
                                                datas = '"' + Convert.ToString(data) + AccountId + '"';
                                                clientUsernamesList.Add(datas);
                                                var user = Membership.CreateUser(datas, "password");
                                                user = Membership.GetUser(datas);
                                                var UserId = (int)user.ProviderUserKey;
                                                clientUserIdsList.Add(UserId);
                                                Roles.AddUserToRole(datas, AppSettingsUtil.ROLE.CLIENT.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
            }
        }

        public static void AccountTableDataMigration()
        {
            object data;
            string datas = "";
            try
            {
                var user = Membership.CreateUser("riddhima_94", "password");
                user = Membership.GetUser("riddhima_94");
                var UserId = (int)user.ProviderUserKey;
                Roles.AddUserToRole("riddhima_94", AppSettingsUtil.ROLE.ACCOUNTANT.ToString());

                var q1 = "INSERT INTO accountant (UserID,Name,Address,City,Country,MobilePhone,Email,Status,OfficeTelephone) Values(" + UserId + ",'Riddhima Gupta','PH Street','London','USA','09874544785','guptaRiddhima67@gmail.com',1,'03326945858'); ";
                RunQuery(q1);

                using (MySqlConnection connection6 = new MySqlConnection(cs))
                {
                    connection6.Open();
                    using (MySqlCommand command1 = new MySqlCommand("SELECT AccountantID FROM accountant Where Name = 'Riddhima Gupta'", connection6))
                    {
                        using (MySqlDataReader reader = command1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                data = reader.GetValue(0);
                                datas += '"' + Convert.ToString(data) + '"';
                                AccountantId = datas;
                            }
                        }
                    }
                }

                using (MySqlConnection connection1 = new MySqlConnection(cs1))
                {
                    connection1.Open();
                    CreateUsersForClients();
                    using (MySqlCommand command = new MySqlCommand("SELECT AccountID FROM account ORDER BY AccountID ASC ", connection1))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                string value = "'";
                                ClientId = reader.GetValue(0);

                                using (MySqlConnection connection2 = new MySqlConnection(cs1))
                                {
                                    connection2.Open();
                                    int count = 0;
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT Name,Address1,City,Zip,Country,WorkPhone,MobilePhone,Email,Status,Region FROM account Where AccountID =" + ClientId, connection2))
                                    {
                                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                datas = "";
                                                for (int i = 0; i < reader1.FieldCount; i++)
                                                {
                                                    data = reader1.GetValue(i);
                                                    if (datas != "")
                                                        datas += ",";
                                                    if (Convert.ToString(data).Contains(value))
                                                    {
                                                        datas += '"' + Convert.ToString(data) + '"';
                                                    }
                                                    else
                                                    {
                                                        datas += '"' + Convert.ToString(data) + '"';
                                                    }
                                                }
                                                var q5 = "INSERT INTO clientmaster(Name,Address,City,PostCode,Country,OfficeTelephone,MobilePhone,Email,Status,County,AccountantID,UserID) Values(" + datas + "," + AccountantId + "," + clientUserIdsList.ElementAt(count++) + "); ";
                                                RunQuery(q5);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                using (MySqlConnection connection2 = new MySqlConnection(cs))
                {
                    connection2.Open();
                    using (MySqlCommand command1 = new MySqlCommand("SELECT ClientID FROM clientmaster Where AccountantID = " + AccountantId + "ORDER BY ClientID ASC", connection2))
                    {
                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                MasterDBClientId = reader1.GetValue(0);
                                var status = (int)AppSettingsUtil.ACCOUNTANTCLIENT_STATUS.ACTIVE;
                                var q = "INSERT INTO accountantclient(AccountantID,ClientID,Status) Values(" + AccountantId + "," + MasterDBClientId + "," + status + ");";
                                RunQuery(q);
                            }
                        }
                    }
                }

                using (MySqlConnection connection2 = new MySqlConnection(cs))
                {
                    connection2.Open();
                    using (MySqlCommand command1 = new MySqlCommand("SELECT ClientID FROM clientmaster Where AccountantID =" + AccountantId + "ORDER BY ClientID ASC", connection2))
                    {
                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                datas = "";
                                data = reader1.GetValue(0);
                                if (datas != "")
                                    datas += ",";
                                datas += '"' + Convert.ToString(data) + '"';
                                var q = "INSERT INTO clientscannedinvoice(ClientID,NumberInvoices) Values(" + datas + "," + '0' + "); ";
                                RunQuery(q);
                            }
                        }
                    }
                }

                var clientIdListMasterDatabase = new List<object>();

                using (MySqlConnection connection2 = new MySqlConnection(cs))
                {
                    connection2.Open();
                    using (MySqlCommand command1 = new MySqlCommand("SELECT ClientID FROM clientmaster Where AccountantID = " + AccountantId + " ORDER BY ClientID ASC", connection2))
                    {
                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                MasterDBClientId = reader1.GetValue(0);
                                clientIdListMasterDatabase.Add(MasterDBClientId);
                            }
                        }
                    }
                }

                MatchIdsAndCreateClientDatabase(clientIdListMasterDatabase);

                using (MySqlConnection connection1 = new MySqlConnection(cs1))
                {
                    connection1.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT AccountID FROM account ORDER BY AccountID ASC", connection1))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                ClientId = reader.GetValue(0);

                                using (MySqlConnection connection2 = new MySqlConnection(cs1))
                                {
                                    connection2.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT IndustryTypeID,CompanyName,VATNumber,Logo,InvoiceNumberFormat,InvoiceName,InvoiceAddress1,InvoiceCity,InvoiceZip,InvoiceCountry,VATReturnSchemeID,ESPForLowerRate,ESPForZeroRate,ESPForStandardRate,IsMajoritySaleAtStdRate,CommenceDate,QuarterStartDate,PharmacyNHSSalesForZeroRate,PharmacyRetailSalesForZeroRate,PharmacyNHSSalesForLowerRate,PharmacyRetailSalesForLowerRate FROM account Where AccountID =" + ClientId, connection2))
                                    {
                                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                datas = "";
                                                string value = "'";
                                                for (int j = 0; j < reader1.FieldCount; j++)
                                                {
                                                    data = reader1.GetValue(j);
                                                    if (datas != "")
                                                        datas += ",";
                                                    if (data.GetType() == typeof(DateTime))
                                                    {
                                                        //Changing the format of date
                                                        var date = (DateTime)data;
                                                        datas += '"' + date.ToString("yyyy-MM-dd") + '"';
                                                    }
                                                    else if (Convert.ToString(data).Contains(value))
                                                    {
                                                        datas += '"' + Convert.ToString(data) + '"';
                                                    }
                                                    else
                                                    {
                                                        datas += '"' + Convert.ToString(data) + '"';
                                                    }
                                                }
                                                var q = "INSERT INTO clientdetails(IndustryTypeID,BuisnessName,VATNumber,Logo,InvoiceNumberFormat,InvoiceName,InvoiceAddress,InvoiceCity,InvoicePostCode,InvoiceCountry,VATSchemeID,ESPForLowerRate,ESPForZeroRate,ESPForStandardRate,IsMajoritySaleAtStdRate,CommencedDate,QuarterEnding,PharmacyNHSSalesForZeroRate,PharmacyRetailSalesForZeroRate,PharmacyNHSSalesForLowerRate,PharmacyRetailSalesForLowerRate) Values(" + datas + "); ";
                                                RunQuery(q);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                var dataList = new List<string>();

                using (MySqlConnection connection6 = new MySqlConnection(cs))
                {
                    connection6.Open();
                    using (MySqlCommand command1 = new MySqlCommand("SELECT ClientDetailsID FROM clientdetails Where ClientID IS NULL", connection6))
                    {
                        using (MySqlDataReader reader = command1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                data = reader.GetValue(0);
                                dataList.Add('"' + Convert.ToString(data) + '"');
                            }
                        }

                        using (MySqlConnection connection9 = new MySqlConnection(cs))
                        {
                            connection9.Open();
                            using (MySqlCommand command9 = new MySqlCommand("SELECT ClientID FROM clientmaster Where AccountantID = " + AccountantId + "ORDER BY ClientID ASC", connection9))
                            {
                                using (MySqlDataReader reader9 = command9.ExecuteReader())
                                {
                                    int i = 0;
                                    while (reader9.Read())
                                    {
                                        object Ids = "";
                                        string clientIds = "";
                                        Ids = reader9.GetValue(0);
                                        clientIds = '"' + Convert.ToString(Ids) + '"';
                                        var q = "UPDATE clientdetails set ClientID =  " + clientIds + "  Where ClientDetailsID =" + dataList.ElementAt(i++);
                                        RunQuery(q);
                                    }
                                }

                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
            }
        }

        public static void CreateDatabase(object clientID)
        {
            MySqlConnection conn = null;
            MySqlConnection connection = null;
            try
            {
                string dbName = AppSettingsUtil.DBNAME + clientID;
                string DatabaseName = "'" + dbName + "'";
                conn = new MySqlConnection(AppSettingsUtil.CONNECTIONSTRING);
                connection = new MySqlConnection(AppSettingsUtil.CONNECTIONSTRING);
                int databaseCount = 0;
                connection.Open();

                using (MySqlCommand command = new MySqlCommand("SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = " + DatabaseName + ";", connection))
                {
                    using (MySqlDataReader reader1 = command.ExecuteReader())
                    {
                        while (!reader1.Read() && databaseCount == 0)
                        {
                            databaseCount = databaseCount + 1;
                            if (databaseCount == 1)
                            {
                                conn.Open();
                                using (MySqlCommand cmd = conn.CreateCommand())
                                {
                                    cmd.CommandText = String.Format("CREATE DATABASE {0}", dbName);
                                    cmd.CommandType = CommandType.Text;

                                    int count = cmd.ExecuteNonQuery();
                                    if (count > 0)
                                    {
                                        string scriptFile = "";
                                        var embededFiles = Assembly.GetExecutingAssembly().GetManifestResourceNames();
                                        foreach (var embededFile in embededFiles.Where(x => x.EndsWith("webaccountingdetailScripts.sql")))
                                        {
                                            using (StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(embededFile)))
                                            {
                                                scriptFile = reader.ReadToEnd();
                                            }
                                        }

                                        conn = new MySqlConnection(AppSettingsUtil.CONNECTIONSTRING + "database=" + dbName + ";");

                                        MySqlScript script = new MySqlScript();
                                        script.Connection = conn;
                                        script.Query = scriptFile;
                                        int cnt = script.Execute();
                                        conn.Close();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
            }

            finally
            {
                if (conn != null) conn.Close();
            }

        }

        private static void RunQuery(string query)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cs))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteReader();
                    }
                }
            }
            catch (Exception ex)
            {
                Program.ErrorLoggingForQueries(ex, query);
            }
        }

        public static void MatchIdsAndCreateClientDatabase(List<object> MasterDatabaseClientIdsList)
        {
            var ClientIdsListLength = MasterDatabaseClientIdsList.Count();
            try
            {
                for (int c = 0; c < ClientIdsListLength; c++)
                {
                    CreateDatabase(MasterDatabaseClientIdsList.ElementAt(c));
                }
            }

            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
            }
        }

        
    }
}












