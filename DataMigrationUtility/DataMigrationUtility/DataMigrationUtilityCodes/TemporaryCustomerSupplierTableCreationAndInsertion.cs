using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAccounting.Lib.Utility;

namespace DataMigrationUtility.DataMigrationUtilityCodes
{
    class TemporaryCustomerSupplierTableCreationAndInsertion
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

        public static void CreateTemporaryCustomerSupplierTables()
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
                    using (MySqlCommand command1 = new MySqlCommand("SELECT ClientID FROM clientmaster Where AccountantID = " + AccountantId + " ORDER BY ClientID ASC", connection6))
                    {
                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                MasterClientId = reader1.GetValue(0);
                                var createTableQuery = "CREATE TABLE IF NOT EXISTS `clientedmx_" + MasterClientId + "`" + ".`temporarycustomeridassociation`" + " (`idtemporarycustomeridassociation` INT NOT NULL AUTO_INCREMENT,`SourceCustomerID` INT NULL,`ClientCustomerID` INT NULL, PRIMARY KEY(`idtemporarycustomeridassociation`)); ";
                                RunQueryClientDatabase(createTableQuery);
                                var createTemporarySupplierTableQuery = "CREATE TABLE IF NOT EXISTS `clientedmx_" + MasterClientId + "`" + ".`temporarysupplieridassociation`" + " (`idtemporarysupplieridassociation` INT NOT NULL AUTO_INCREMENT,`SourceSupplierID` INT NULL,`ClientSupplierID` INT NULL, PRIMARY KEY(`idtemporarysupplieridassociation`)); ";
                                RunQueryClientDatabase(createTemporarySupplierTableQuery);
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

        public static void GetMasterClientIdListForCustomer()
        {
            object data;
            string datas = "";

            try
            {
                using (MySqlConnection connection6 = new MySqlConnection(cs1))
                {
                    connection6.Open();
                    using (MySqlCommand command1 = new MySqlCommand("SELECT DISTINCT AccountID FROM customer ORDER BY AccountID ASC", connection6))
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

        public static void GetMasterClientIdListForSupplier()
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

        public static void InsertDataTemporaryCustomerTable()
        {
            int index = 0;

            try
            {
                GetMasterClientIdListForCustomer();
                using (MySqlConnection connection1 = new MySqlConnection(cs1))
                {
                    connection1.Open();

                    using (MySqlCommand command = new MySqlCommand("SELECT DISTINCT AccountID FROM customer ORDER BY AccountID ASC", connection1))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                ClientId = reader.GetValue(0);
                                MasterClientId = clientIdListMasterDatabase.ElementAt(index++);
                                string cs5 = cs2 + MasterClientId;
                                using (MySqlConnection connection2 = new MySqlConnection(cs1))
                                {
                                    connection2.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT CustomerID FROM customer Where AccountID =" + ClientId, connection2))
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
                                                var q = "INSERT INTO temporarycustomeridassociation(SourceCustomerID) Values(" + datas + "); ";
                                                RunQueryClientDatabase(q);
                                            }
                                        }
                                    }
                                }
                                var dataList = new List<string>();

                                using (MySqlConnection connection3 = new MySqlConnection(cs5))
                                {
                                    connection3.Open();
                                    using (MySqlCommand command3 = new MySqlCommand("SELECT SourceCustomerID FROM temporarycustomeridassociation Where ClientCustomerID IS NULL", connection3))
                                    {
                                        using (MySqlDataReader reader3 = command3.ExecuteReader())
                                        {
                                            while (reader3.Read())
                                            {
                                                datas = "";
                                                data = reader3.GetValue(0);
                                                dataList.Add('"' + Convert.ToString(data) + '"');
                                            }
                                        }

                                        string cs9 = cs2 + MasterClientId;
                                        using (MySqlConnection connection9 = new MySqlConnection(cs9))
                                        {
                                            connection9.Open();
                                            using (MySqlCommand command9 = new MySqlCommand("SELECT DISTINCT CustomerID FROM customer ORDER BY CustomerID ASC", connection9))
                                            {
                                                using (MySqlDataReader reader9 = command9.ExecuteReader())
                                                {
                                                    int i = 0;
                                                    while (reader9.Read())
                                                    {
                                                        object Ids = "";
                                                        string customerIds = "";
                                                        Ids = reader9.GetValue(0);
                                                        customerIds = '"' + Convert.ToString(Ids) + '"';
                                                        var q = "UPDATE temporarycustomeridassociation set ClientCustomerID =  " + customerIds + "  Where SourceCustomerID =" + dataList.ElementAt(i++);
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
                }
            }

            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
            }
        }

        public static void InsertDataTemporarySupplierTable()
        {
            int index = 0;

            try
            {
                GetMasterClientIdListForSupplier();
                using (MySqlConnection connection1 = new MySqlConnection(cs1))
                {
                    connection1.Open();

                    using (MySqlCommand command = new MySqlCommand("SELECT DISTINCT AccountID FROM supplier ORDER BY AccountID ASC", connection1))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datas = "";
                                ClientId = reader.GetValue(0);
                                MasterClientId = clientIdListMasterDatabase.ElementAt(index++);
                                string cs5 = cs2 + MasterClientId;
                                using (MySqlConnection connection2 = new MySqlConnection(cs1))
                                {
                                    connection2.Open();
                                    using (MySqlCommand command1 = new MySqlCommand("SELECT SupplierID FROM supplier Where AccountID =" + ClientId, connection2))
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
                                                var q = "INSERT INTO temporarysupplieridassociation(SourceSupplierID) Values(" + datas + "); ";
                                                RunQueryClientDatabase(q);
                                            }
                                        }
                                    }
                                }

                                var dataList = new List<string>();

                                using (MySqlConnection connection3 = new MySqlConnection(cs5))
                                {
                                    connection3.Open();
                                    using (MySqlCommand command3 = new MySqlCommand("SELECT SourceSupplierID FROM temporarysupplieridassociation Where ClientSupplierID IS NULL", connection3))
                                    {
                                        using (MySqlDataReader reader3 = command3.ExecuteReader())
                                        {
                                            while (reader3.Read())
                                            {
                                                datas = "";
                                                data = reader3.GetValue(0);
                                                dataList.Add('"' + Convert.ToString(data) + '"');
                                            }
                                        }

                                        string cs9 = cs2 + MasterClientId;
                                        using (MySqlConnection connection9 = new MySqlConnection(cs9))
                                        {
                                            connection9.Open();
                                            using (MySqlCommand command9 = new MySqlCommand("SELECT DISTINCT SupplierID FROM supplier ORDER BY SupplierID ASC", connection9))
                                            {
                                                using (MySqlDataReader reader9 = command9.ExecuteReader())
                                                {
                                                    int i = 0;
                                                    while (reader9.Read())
                                                    {
                                                        object Ids = "";
                                                        string supplierIds = "";
                                                        Ids = reader9.GetValue(0);
                                                        supplierIds = '"' + Convert.ToString(Ids) + '"';
                                                        var q = "UPDATE temporarysupplieridassociation set ClientSupplierID =  " + supplierIds + "  Where SourceSupplierID =" + dataList.ElementAt(i++);
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
                }
            }

            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
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
