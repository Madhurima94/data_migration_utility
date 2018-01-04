using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAccounting.Lib.Utility;

namespace DataMigrationUtility.DataMigrationUtilityCodes
{
    class SupplierTableDataMigration
    {
        static string cs = AppSettingsUtil.ConnectionStringMasterDB;
        static string cs1 = AppSettingsUtil.ConnectionStringSourceDB;
        static string cs2 = AppSettingsUtil.ConnectionStringClientDB;
        static object ClientId;
        static object AccountantId;
        static object AccountId;
        static object MasterDBClientId;
        static string datas;
        static object data;
        static object MasterClientId;
        static object TransactionId;
        static object CreditNoteId;
        static List<object> clientIdListMasterDatabase = new List<object>();

        public static void GetMasterClientIdForSupplier()
        {
            object data;
            string datas = "";

            try
            {
                using (MySqlConnection connection6 = new MySqlConnection(cs1))
                {
                    connection6.Open();
                    using (MySqlCommand command1 = new MySqlCommand("SELECT DISTINCT AccountID FROM supplier ORDER BY AccountID ASC", connection6))
                    {
                        using (MySqlDataReader reader = command1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                data = reader.GetValue(0);
                                datas += '"' + Convert.ToString(data) + '"';
                                AccountId = datas;
                                using (MySqlConnection connection = new MySqlConnection(cs))
                                {
                                    connection.Open();
                                    using (MySqlCommand command = new MySqlCommand("SELECT ClientID FROM temporaryoldnewclientidsassociation Where AccountID = " + AccountId, connection))
                                    {
                                        using (MySqlDataReader reader1 = command.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                MasterClientId = reader1.GetValue(0);
                                                clientIdListMasterDatabase.Add(MasterClientId);
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

        public static void SupplierTableMigration()
        {
            int index = 0;

            try
            {
                GetMasterClientIdForSupplier();
                using (MySqlConnection connection = new MySqlConnection(cs1))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT DISTINCT AccountID from supplier ORDER BY AccountID ASC", connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                ClientId = reader.GetValue(0);
                                MasterDBClientId = clientIdListMasterDatabase.ElementAt(index++);
                                using (MySqlConnection connection1 = new MySqlConnection(cs1))
                                {
                                    connection1.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT Name,CompanyName,Address1,City,Country,Zip,VATNumber,WorkPhone,MobilePhone,Email,Status,Region,IsRevAlow FROM supplier Where AccountID =" + ClientId, connection1))
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
                                                    if (data.GetType() == typeof(DateTime))
                                                    {
                                                        // Changing the format of date
                                                        var date = (DateTime)data;
                                                        datas += '"' + date.ToString("yyyy-MM-dd hh:mm:ss") + '"';
                                                    }
                                                    if (data.ToString().Contains("\\"))
                                                    {
                                                        datas += '"' + Convert.ToString(data) + '\\' + '"';
                                                    }
                                                    else
                                                    {
                                                        datas += '"' + Convert.ToString(data) + '"';
                                                    }

                                                }
                                                var q = "INSERT INTO supplier(ContactName,CompanyName,CompanyAddress,CompanyCity,CompanyCountry,CompanyPostcode,VATNumber,CompanyPhone,ContactPhone,ContactEmail,Status,CompanyCounty,IsRevAllow) Values(" + datas + "); ";
                                                RunQueryClientDatabase(q);
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

        private static void RunQueryClientDatabase(string query)
        {
            string cs5 = cs2 + MasterDBClientId;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(cs5))
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
                Program.ErrorLoggingForQueries(ex,query);
            }
        }
    }
}
