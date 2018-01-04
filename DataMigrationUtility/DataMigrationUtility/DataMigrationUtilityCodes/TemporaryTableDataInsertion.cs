using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAccounting.Lib.Utility;

namespace DataMigrationUtility.DataMigrationUtilityCodes
{
    class TemporaryTableDataInsertion
    {
        static string cs1 = AppSettingsUtil.ConnectionStringSourceDB;
        static string cs = AppSettingsUtil.ConnectionStringMasterDB;
        static string cs2 = AppSettingsUtil.ConnectionStringClientDB;
        static object data;
        static string datas = "";
        static object ClientId;
        static object MasterClientId;
        static object AccountantId;
        static object AccountId;
        static List<object> clientIdListMasterDatabase = new List<object>();

        public static void InsertDataTemporaryTable()
        {
            try
            {
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

                using (MySqlConnection connection2 = new MySqlConnection(cs1))
                {
                    connection2.Open();
                    using (MySqlCommand command1 = new MySqlCommand("SELECT DISTINCT AccountID FROM account ORDER BY AccountID ASC", connection2))
                    {
                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                AccountId = reader1.GetValue(0);
                                var q = "INSERT INTO temporaryoldnewclientidsassociation(AccountID) Values(" + AccountId + ");";
                                RunQuery(q);
                            }
                        }
                    }
                }

                var dataList = new List<string>();

                using (MySqlConnection connection6 = new MySqlConnection(cs))
                {
                    connection6.Open();
                    using (MySqlCommand command1 = new MySqlCommand("SELECT AccountID FROM temporaryoldnewclientidsassociation Where ClientID IS NULL", connection6))
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
                            using (MySqlCommand command9 = new MySqlCommand("SELECT ClientID FROM clientmaster Where AccountantID = " + AccountantId, connection9))
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
                                        var q = "UPDATE temporaryoldnewclientidsassociation set ClientID =  " + clientIds + "  Where AccountID =" + dataList.ElementAt(i++);
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
                Program.ErrorLoggingForQueries(ex,query);
            }
        }

    }
}
