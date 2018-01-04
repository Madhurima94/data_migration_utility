using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAccounting.Lib.Utility;

namespace DataMigrationUtility.DataMigrationUtilityCodes
{
    class SeedDataMigration
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


        public static void GetMasterClientIdList()
        {
            object data;
            string datas = "";

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
                    connection6.Close();
                    connection6.Open();
                    using (MySqlCommand command1 = new MySqlCommand("SELECT ClientID FROM clientmaster Where AccountantID = " + AccountantId + "ORDER BY ClientID ASC", connection6))
                    {
                        using (MySqlDataReader reader1 = command1.ExecuteReader())
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

            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
            }

        }

        public static void GetMasterClientIdListForZeroRatedItems()
        {
            object data;
            string datas = "";

            try
            {
                using (MySqlConnection connection6 = new MySqlConnection(cs1))
                {
                    connection6.Open();
                    using (MySqlCommand command1 = new MySqlCommand("SELECT DISTINCT AccountID FROM zerorateditems ORDER BY AccountID ASC", connection6))
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
                                    using (MySqlCommand command = new MySqlCommand("SELECT ClientID FROM temporaryoldnewclientidsassociation Where AccountID = " + AccountId + "ORDER BY ClientID ASC", connection))
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

        public static void GetMasterClientIdListForExemptItems()
        {
            object data;
            string datas = "";

            try
            {
                using (MySqlConnection connection6 = new MySqlConnection(cs1))
                {
                    connection6.Open();
                    using (MySqlCommand command1 = new MySqlCommand("SELECT DISTINCT AccountID FROM exemptitems ORDER BY AccountID ASC", connection6))
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
                                    using (MySqlCommand command = new MySqlCommand("SELECT ClientID FROM temporaryoldnewclientidsassociation Where AccountID = " + AccountId + "ORDER BY ClientID ASC", connection))
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

        public static void GetMasterClientIdListForExemptItemsNon()
        {
            object data;
            string datas = "";

            try
            {
                using (MySqlConnection connection6 = new MySqlConnection(cs1))
                {
                    connection6.Open();
                    using (MySqlCommand command1 = new MySqlCommand("SELECT DISTINCT AccountID FROM exemptitemsnon ORDER BY AccountID ASC", connection6))
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
                                    using (MySqlCommand command = new MySqlCommand("SELECT ClientID FROM temporaryoldnewclientidsassociation Where AccountID = " + AccountId + "ORDER BY ClientID ASC", connection))
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

        public static void GetMasterClientIdListForExpenseSource()
        {
            object data;
            string datas = "";

            try
            {
                using (MySqlConnection connection6 = new MySqlConnection(cs1))
                {
                    connection6.Open();
                    using (MySqlCommand command1 = new MySqlCommand("SELECT DISTINCT AccountID FROM expensesource ORDER BY AccountID ASC", connection6))
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
                                    using (MySqlCommand command = new MySqlCommand("SELECT ClientID FROM temporaryoldnewclientidsassociation Where AccountID = " + AccountId + "ORDER BY ClientID ASC", connection))
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

        public static void GetMasterClientIdListForExpenseType()
        {
            object data;
            string datas = "";

            try
            {
                using (MySqlConnection connection6 = new MySqlConnection(cs1))
                {
                    connection6.Open();
                    using (MySqlCommand command1 = new MySqlCommand("SELECT DISTINCT AccountID FROM expensetype ORDER BY AccountID ASC", connection6))
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
                                    using (MySqlCommand command = new MySqlCommand("SELECT ClientID FROM temporaryoldnewclientidsassociation Where AccountID = " + AccountId + "ORDER BY ClientID ASC", connection))
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

        public static void VATRateTableDataMigration()
        {
            try
            {
                using (MySqlConnection connection1 = new MySqlConnection(cs1))
                {
                    connection1.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM vatrate", connection1))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                for (int i = 1; i < reader.FieldCount; i++)
                                {
                                    data = reader.GetValue(i);
                                    if (datas != "")
                                        datas += ",";

                                    if (data.GetType() == typeof(DateTime))
                                    {
                                        //Changing the format of date
                                        var date = (DateTime)data;
                                        datas += "'" + date.ToString("yyyy-MM-dd hh:mm:ss") + "'";
                                    }
                                    else
                                    {
                                        datas += "'" + Convert.ToString(data) + "'";
                                    }
                                }
                                var q = "INSERT INTO vatratedetail(FromDate, ToDate, StandardRatePercentage, StandardRateRatio, StandardRateRatioLabel, LowerRatePercentage, LowerRateRatio, LowerRateRatioLabel) Values(" + datas + "); ";
                                RunQuery(q);
                                Console.WriteLine();
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

        public static void ZeroRatedItemsDataMigration()
        {
            int index = 0;

            try
            {
                GetMasterClientIdListForZeroRatedItems();
                using (MySqlConnection connection1 = new MySqlConnection(cs1))
                {
                    connection1.Open();

                    using (MySqlCommand command = new MySqlCommand("SELECT DISTINCT AccountID FROM zerorateditems ORDER BY AccountID ASC", connection1))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                ClientId = reader.GetValue(0);
                                MasterClientId = clientIdListMasterDatabase.ElementAt(index++);
                                using (MySqlConnection connection2 = new MySqlConnection(cs1))
                                {
                                    connection2.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT DISTINCT Description FROM zerorateditems Where AccountID =" + ClientId, connection2))
                                    {
                                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                datas = "";
                                                data = reader1.GetValue(0);
                                                if (datas != "")
                                                    datas += ",";
                                                datas += "'" + Convert.ToString(data) + "'";
                                                var q = "INSERT INTO itemtypedetails(ItemName,ItemTypeID) Values(" + datas + "," + "2" + "); ";
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

        public static void ExemptItemsDataMigration()
        {
            int index = 0;

            try
            {
                GetMasterClientIdListForExemptItems();
                using (MySqlConnection connection1 = new MySqlConnection(cs1))
                {
                    connection1.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT DISTINCT AccountID FROM exemptitems ORDER BY AccountID ASC", connection1))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                ClientId = reader.GetValue(0);
                                MasterClientId = clientIdListMasterDatabase.ElementAt(index++);
                                using (MySqlConnection connection2 = new MySqlConnection(cs1))
                                {
                                    connection2.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT DISTINCT Description FROM exemptitems Where AccountID =" + ClientId, connection2))
                                    {
                                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                datas = "";
                                                data = reader1.GetValue(0);
                                                if (datas != "")
                                                    datas += ",";
                                                datas += "'" + Convert.ToString(data) + "'";
                                                var q = "INSERT INTO itemtypedetails(ItemName,ItemTypeID) Values(" + datas + "," + "1" + "); ";
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

        public static void ExemptItemsNonDataMigration()
        {
            int index = 0;

            try
            {
                GetMasterClientIdListForExemptItemsNon();
                using (MySqlConnection connection1 = new MySqlConnection(cs1))
                {
                    connection1.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT DISTINCT AccountID FROM exemptitemsnon ORDER BY AccountID ASC", connection1))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                ClientId = reader.GetValue(0);
                                MasterClientId = clientIdListMasterDatabase.ElementAt(index++);
                                using (MySqlConnection connection2 = new MySqlConnection(cs1))
                                {
                                    connection2.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT DISTINCT Description FROM exemptitemsnon Where AccountID =" + ClientId, connection2))
                                    {
                                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                datas = "";
                                                data = reader1.GetValue(0);
                                                if (datas != "")
                                                    datas += ",";
                                                datas += "'" + Convert.ToString(data) + "'";
                                                var q = "INSERT INTO itemtypedetails(ItemName,ItemTypeID) Values(" + datas + "," + "3" + "); ";
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

        public static void ExpenseSourceDataMigration()
        {
            int index = 0;

            try
            {
                GetMasterClientIdListForExpenseSource();
                using (MySqlConnection connection1 = new MySqlConnection(cs1))
                {
                    connection1.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT DISTINCT AccountID FROM expensesource ORDER BY AccountID ASC", connection1))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                ClientId = reader.GetValue(0);
                                MasterClientId = clientIdListMasterDatabase.ElementAt(index++);
                                using (MySqlConnection connection2 = new MySqlConnection(cs1))
                                {
                                    connection2.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT DISTINCT Source FROM expensesource Where AccountID =" + ClientId, connection2))
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
                                                    datas += '"' + Convert.ToString(data) + '"';
                                                }
                                                var q = "INSERT INTO expensesource(SourceName,Status) Values(" + datas + "," + 1 + "); ";
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

        public static void ExpenseTypeDataMigration()
        {
            int index = 0;

            try
            {
                GetMasterClientIdListForExpenseType();
                using (MySqlConnection connection1 = new MySqlConnection(cs1))
                {
                    connection1.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT DISTINCT AccountID FROM expensetype ORDER BY AccountID ASC", connection1))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                ClientId = reader.GetValue(0);
                                MasterClientId = clientIdListMasterDatabase.ElementAt(index++);
                                using (MySqlConnection connection2 = new MySqlConnection(cs1))
                                {
                                    connection2.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT DISTINCT ExpenseType FROM expensetype Where AccountID =" + ClientId, connection2))
                                    {
                                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                datas = "";
                                                data = reader1.GetValue(0);
                                                if (datas != "")
                                                    datas += ",";
                                                if (Convert.ToString(data).Contains('"'))
                                                {
                                                    datas += "'" + Convert.ToString(data) + "'";
                                                }
                                                else if (data.ToString().Contains("\\"))
                                                {
                                                    datas += '"' + Convert.ToString(data) + '"';
                                                    datas = datas.Replace(@"\", @"\\");
                                                }
                                                else
                                                {
                                                    datas += '"' + Convert.ToString(data) + '"';
                                                }
                                                var q = "INSERT INTO expensetype(ExpenseTypeName) Values(" + datas + "); ";
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

        private static void RunQueryClientDatabase(string query)
        {
            string cs5 = cs2 + MasterClientId;

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


