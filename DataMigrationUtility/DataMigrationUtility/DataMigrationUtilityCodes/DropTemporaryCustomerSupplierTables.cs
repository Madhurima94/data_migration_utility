using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAccounting.Lib.Utility;

namespace DataMigrationUtility.DataMigrationUtilityCodes
{
    class DropTemporaryCustomerSupplierTables
    {
        static string cs1 = AppSettingsUtil.ConnectionStringSourceDB;
        static string cs = AppSettingsUtil.ConnectionStringMasterDB;
        static string cs2 = AppSettingsUtil.ConnectionStringClientDB;
        static object data;
        static string datas;
        static object MasterClientId;
        static object AccountantId;

        public static void DropTemporaryCustomerAndSupplierClientTables()
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
                                var dropTableQuery = "DROP TABLE IF EXISTS `clientedmx_" + MasterClientId + "`" + ".`temporarycustomeridassociation`";
                                RunQueryClientDatabase(dropTableQuery);
                                var dropTemporarySupplierTableQuery = "DROP TABLE IF EXISTS `clientedmx_" + MasterClientId + "`" + ".`temporarysupplieridassociation`";
                                RunQueryClientDatabase(dropTemporarySupplierTableQuery);
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
